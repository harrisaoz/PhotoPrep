using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PhotoPrep
{
    using Fif = FileImportFunctions;

    public class RenameAction
    {
        public static IEnumerable<(string, FileInfo)> SimulateRequestedRenames(
            DirectoryInfo parentDir,
            IEnumerable<(FileInfo, string, bool)> renameRequests
        )
        {
            return MaybePerformRequestedRenames(
                parentDir: parentDir,
                renameRequests: renameRequests,
                simulateOnly: true
            );
        }

        public static IEnumerable<(string, FileInfo)> PerformRequestedRenames(
            DirectoryInfo parentDir,
            IEnumerable<(FileInfo, string, bool)> renameRequests
        )
        {
            return MaybePerformRequestedRenames(
                parentDir: parentDir,
                renameRequests: renameRequests,
                simulateOnly: false
            );
        }

        public static IEnumerable<(string, FileInfo)> MaybePerformRequestedRenames(
            DirectoryInfo parentDir,
            IEnumerable<(FileInfo, string, bool)> renameRequests,
            bool simulateOnly = true
        )
        {
            return renameRequests
                .Where(req => req.Item3)
                .Select(PerformRequestedRename(
                    simulateOnly: simulateOnly));
        }

        static Func<(FileInfo, string, bool), (string, FileInfo)> PerformRequestedRename(
            bool simulateOnly = true
        )
        {
            return req =>
            {
                var (original, newName, shouldRename) = req;
                var newFullName = Path.Combine(original.DirectoryName, newName);

                if (!simulateOnly)
                {
                    original.MoveTo(newFullName);
                }

                var msg = simulateOnly
                    ? "[Simulation] In [{0}] Move {1} -> {2}"
                    : "In [{0}] Moved {1} -> {2}";

                return (
                    string.Format(msg, original.DirectoryName, original.Name, newName),
                    new FileInfo(newFullName)
                );
            };
        }

        public static IEnumerable<(FileInfo, string, bool)> GetNewNames(
            DirectoryInfo sourceDir,
            IEnumerable<string> fileExtensionFilter,
            bool shouldUseDateWritten,
            bool shouldIncludeSerialNumber,
            string prefixToRemove,
            string cameraLabel)
        {
            return fileExtensionFilter
                .SelectMany(Fif.EnumerateFilesByExtension(sourceDir))
                .Select(sourceFile =>
                    (
                        sourceFile,
                        shouldUseDateWritten
                            ? GetNewName(sourceFile, shouldIncludeSerialNumber, prefixToRemove, cameraLabel)
                            : sourceFile.Name,
                        shouldUseDateWritten && !Fif.DoesFileNameMatchFileDate(sourceFile)
                    )
                );
        }

        static string GetNewName(
            FileInfo original,
            bool shouldIncludeSerialNumber,
            string prefixToRemove,
            string cameraLabel)
        {
            var dateTimeLabel = original.LastWriteTimeUtc.ToString("yyyyMMdd_HHmmssfff");
            var labels = shouldIncludeSerialNumber
                ? new[] { dateTimeLabel, TranslateText(GetBaseName(original), prefixToRemove), cameraLabel }
                : new[] { dateTimeLabel, cameraLabel };

            return string.Format("{0}{1}", string.Join("_", labels), original.Extension);
        }

        private static string GetBaseName(FileInfo file)
        {
            var (name, ext) = (file.Name, file.Extension);

            return ext.Length > 0
                ? name.Remove(name.Length - ext.Length)
                : name;
        }

        private static string TranslateText(string input, string toReplace, string replacement = "")
        {
            return toReplace.Length > 0 ? input.Replace(toReplace, replacement) : input;
        }
    }
}
