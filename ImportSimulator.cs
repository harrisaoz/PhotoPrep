using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace PhotoPrep
{
    using GroupedCopyRequest = IGrouping<ValueTuple<int, int>, ValueTuple<FileInfo, string>>;

    public partial class ImportSimulator : Form
    {
        IEnumerable<(FileInfo, string, bool)> effectiveRenames;
        IEnumerable<GroupedCopyRequest> copyRequests;
        DirectoryInfo sourceDir;
        DirectoryInfo targetDir;
        ImportWorker worker;

        public ImportSimulator(
            DirectoryInfo sourceDir,
            DirectoryInfo targetDir,
            IEnumerable<(FileInfo, string, bool)> renameRequests
        )
        {
            InitializeComponent();

            this.sourceDir = sourceDir;
            this.targetDir = targetDir;
            this.effectiveRenames = renameRequests.Where(r => r.Item3);
            this.copyRequests = ImportAction.GetCopyRequests(renameRequests, targetDir);

            // Summary Box
            summaryBox.Text = String.Format(
                "{0} file{1} to be renamed",
                effectiveRenames.Count(),
                effectiveRenames.Count() != 1 ? "s" : ""
            );

            // Skipped Info Box
            skippedInfoBox.Text = string.Format(
                "{0} file{1} not renamed",
                renameRequests.Where(r => !r.Item3).Count(),
                renameRequests.Where(r => !r.Item3).Count() != 1 ? "s" : ""
            );


            worker = new ImportWorker(
                description: "Import Simulation",
                worker: this.simulationWorker,
                workItems: System.Linq.Enumerable.Concat(
                    RenameAction.SimulateRequestedRenames(
                        parentDir: sourceDir,
                        renameRequests: effectiveRenames
                    ),
                    ImportAction.SimulateRequestedFileCopies(
                        dstDir: targetDir,
                        requests: copyRequests
                    )
                ),
                totalWorkItems: effectiveRenames.Count() +
                    ImportAction.UngroupCopyRequests(copyRequests).Count(),
                infoBox: detailBox,
                progressBar: this.simulationProgress
            );
        }

        private void ImportActionFinishedForm_Load(object sender, EventArgs e)
        {
            worker.RunASync("Commencing simulation. Only proceed to Import after checking the simulated actions.");
        }

        private void runImport_Click(object sender, EventArgs e)
        {
            new ImportRunner(sourceDir, targetDir, effectiveRenames, copyRequests).ShowDialog();
        }
    }
}
