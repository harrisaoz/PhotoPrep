using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PhotoPrep
{
    using YearMonth = ValueTuple<int, int>;
    using CopyRequest = ValueTuple<FileInfo, string>;
    using IndexedCopyRequest = ValueTuple<int, int, FileInfo, string>;
    using GroupedCopyRequest = IGrouping<ValueTuple<int, int>, ValueTuple<FileInfo, string>>;
    using Fif = FileImportFunctions;

    class ImportAction
    {
        public static IEnumerable<CopyRequest> UngroupCopyRequests(IEnumerable<GroupedCopyRequest> grouped) {
            return grouped.SelectMany(group => group.AsEnumerable());
        }

        public static IEnumerable<Func<(string, FileInfo)>> SimulateRequestedFileCopies(
            DirectoryInfo dstDir,
            IEnumerable<GroupedCopyRequest> requests)
        {
            return MaybePerformRequestedFileCopies(
                dstDir: dstDir,
                requests: requests,
                simulateOnly: true
            );
        }
        
        public static IEnumerable<Func<(string, FileInfo)>> PerformRequestedFileCopies(
            DirectoryInfo dstDir,
            IEnumerable<GroupedCopyRequest> requests)
        {
            return MaybePerformRequestedFileCopies(
                dstDir: dstDir,
                requests: requests,
                simulateOnly: false
            );
        }

        public static IEnumerable<Func<(string, FileInfo)>> MaybePerformRequestedFileCopies(
            DirectoryInfo dstDir,
            IEnumerable<GroupedCopyRequest> requests,
            bool simulateOnly = true)
        {
            var actions = requests
                .Select(PrepareFolder(dstDir: dstDir, simulateOnly: simulateOnly))
                .SelectMany(group => group.AsEnumerable())
                .Select(PerformRequestedFileCopy(simulateOnly: simulateOnly));

            return actions;
        }

        public static Func<CopyRequest, Func<(string, FileInfo)>> PerformRequestedFileCopy(
            bool simulateOnly = true)
        {
            return request => () =>
            {
                var (original, dstFullName) = request;

                if (File.Exists(dstFullName))
                {
                    Console.WriteLine("File exists [{0}]", dstFullName);
                }
                else
                {
                    if (simulateOnly)
                    {
                        Console.WriteLine("[Simulation] Copy {0} -> {1}", original.FullName, dstFullName);
                    }
                    else
                    {
                        File.Copy(original.FullName, dstFullName);
                    }
                }

                var msg = simulateOnly
                    ? "[Simulation] Copy {0} -> {1}"
                    : "Copied {0} -> {1}";

                return (
                    string.Format(msg, original.FullName, dstFullName),
                    new FileInfo(dstFullName)
                );
            };
        }

        public static Func<GroupedCopyRequest, GroupedCopyRequest> PrepareFolder(
            DirectoryInfo dstDir,
            bool simulateOnly = true)
        {
            return record =>
            {
                var (year, month) = record.Key;

                EnsureMonthFolderExists(dstDir, year, month, simulateOnly);

                return record;
            };
        }

        public static bool CopyExists((FileInfo, string) copyInfo)
        {
            return File.Exists(copyInfo.Item2);
        }

        public static FileInfo CopyFile(FileInfo original, string newFullname)
        {
            if (File.Exists(newFullname))
            {
                Console.WriteLine("File exists [{0}]", newFullname);
            } else
            {
                File.Copy(original.FullName, newFullname);
            }

            return new FileInfo(newFullname);
        }

        public static IEnumerable<GroupedCopyRequest> GetCopyRequests(
            IEnumerable<(FileInfo, string, bool)> fileRenameRequests,
            DirectoryInfo targetDir
        )
        {
            return fileRenameRequests
                .Select(req => {
                    var (original, newName, shouldBeRenamed) = req;

                    var fileInfo = shouldBeRenamed
                        ? new FileInfo(Path.Combine(original.DirectoryName, newName))
                        : original;
                    
                    return (fileInfo, original.LastWriteTimeUtc);
                })
                .Where(newInfo => {
                    var (fileInfo, lastWriteTime) = newInfo;

                    return Fif.DoesNameMatchDate(fileInfo.Name, lastWriteTime);
                })
                .Select(newInfo => {
                    var (fileInfo, lastWriteTime) = newInfo;

                    return (
                        lastWriteTime.Year,
                        lastWriteTime.Month,
                        fileInfo,
                        FilenameOfCopy(
                            targetDir,
                            fileInfo,
                            lastWriteTime.Year,
                            lastWriteTime.Month)
                    );
                })
                .GroupBy(GroupCopyInfoByYearMonth, CopyInfoProjection);
        }

        static string FilenameOfCopy(
            DirectoryInfo copyTo,
            FileInfo original,
            int year,
            int month)
        {
            return Path.Combine(
                GetMonthFolder(copyTo, year, month).FullName,
                original.Name);
        }

        static YearMonth GroupCopyInfoByYearMonth(IndexedCopyRequest request)
        {
            var (yyyy, mm, _1, _2) = request;
            return (yyyy, mm);
        }

        static CopyRequest CopyInfoProjection(IndexedCopyRequest request)
        {
            var (_1, _2, srcFile, dstFilename) = request;
            return (srcFile, dstFilename);
        }

        public static DirectoryInfo EnsureMonthFolderExists(
            DirectoryInfo parent,
            int year,
            int month,
            bool simulateOnly = true)
        {
            var yearFolder = EnsureSubfolderExists(parent, string.Format("{0:d4}", year), simulateOnly);
            return EnsureSubfolderExists(yearFolder, string.Format("{0:d2}", month), simulateOnly);
        }

        static DirectoryInfo GetMonthFolder(
            DirectoryInfo parent,
            int year,
            int month)
        {
            return EnsureMonthFolderExists(parent, year, month, simulateOnly: true);
        }

        /// <summary>
        /// Ensure that the named sub-folder exists as a child of the given parent folder.
        /// </summary>
        /// <param name="parent">folder in which to create a new sub-folder if the named folder does not yet exist</param>
        /// <param name="subfolderName">MUST NOT contain wildcards (MUST BE literal)</param>
        /// <returns></returns>
        public static DirectoryInfo EnsureSubfolderExists(
            DirectoryInfo parent,
            string subfolderName,
            bool simulateOnly = true)
        {
            var newDir = new DirectoryInfo(Path.Combine(
                    parent.FullName,
                    subfolderName
                ));

            if (simulateOnly || newDir.Exists) {
            } else {
                Console.WriteLine("Create folder {0}", subfolderName);
                newDir.Create();
            }

            return newDir;
        }
    }
}
