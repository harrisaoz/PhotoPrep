using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoPrep
{
    using GroupedCopyRequest = IGrouping<ValueTuple<int, int>, ValueTuple<FileInfo, string>>;

    public partial class ImportRunner : Form
    {
        ImportWorker worker;

        public ImportRunner(
            DirectoryInfo sourceDir,
            DirectoryInfo targetDir,
            IEnumerable<(FileInfo, string, bool)> renameRequests,
            IEnumerable<GroupedCopyRequest> copyRequests)
        {
            InitializeComponent();

            var effectiveRenames = renameRequests.Where(r => r.Item3);
            var copyRequestsUngrouped = copyRequests.SelectMany(g => g.AsEnumerable());

            worker = new ImportWorker(
                description: "Import",
                worker: this.asyncImportWorker,
                workItems: Enumerable.Concat(
                    RenameAction.PerformRequestedRenames(
                        parentDir: sourceDir,
                        renameRequests: renameRequests.Where(r => r.Item3)
                    ),
                    ImportAction.PerformRequestedFileCopies(
                        dstDir: targetDir,
                        requests: copyRequests
                    )
                ),
                totalWorkItems: effectiveRenames.Count() + copyRequestsUngrouped.Count(),
                infoBox: this.importLog,
                progressBar: this.importProgress
            );
        }

        private void ImportRunner_Load(object sender, EventArgs e)
        {
            worker.RunASync("Commencing import of photos and videos. Please be patient.");
        }
    }
}
