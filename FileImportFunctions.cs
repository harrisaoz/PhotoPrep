using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoPrep
{
    public class FileImportFunctions
    {
        public static Func<string, IEnumerable<FileInfo>> EnumerateFilesByExtension(DirectoryInfo dir)
        {
            return fileExtension => dir.EnumerateFiles(string.Format("*.{0}", fileExtension));
        }

        public static bool DoesFileNameMatchFileDate(FileInfo file) {
            return DoesNameMatchDate(file.Name, file.LastWriteTimeUtc);
        }

        public static bool DoesNameMatchDate(string filename, DateTime matchDate)
        {
            var yyyyMM = string.Format("{0}{1:d2}", matchDate.Year, matchDate.Month);
            return filename.StartsWith(yyyyMM);
        }
    }
}
