﻿using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoPrep
{
    using ActionItem = ValueTuple<string, FileInfo>;

    public class ImportWorker
    {
        private string description;
        private IEnumerable<ActionItem> workItems;
        private int workItemsComplete = 0;
        private int totalWorkItems;
        private BackgroundWorker worker;
        private TextBox infoBox;
        private ProgressBar progressBar;

        public ImportWorker(
            string description,
            BackgroundWorker worker,
            IEnumerable<ActionItem> workItems,
            int totalWorkItems,
            TextBox infoBox,
            ProgressBar progressBar)
        {
            this.description = description;
            this.workItems = workItems;
            this.totalWorkItems = totalWorkItems;
            this.infoBox = infoBox;
            this.progressBar = progressBar;

            this.worker = worker;
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(
                this.DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(
                this.OnProgress);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(
                this.OnComplete);
        }

        private string logInfo(string msg)
        {
            var logLine = string.Format("[{0}] {1}\r\n", this.description, msg);
            infoBox.AppendText(logLine);
            return logLine;
        }

        public void RunASync(string startMessage)
        {
            logInfo(startMessage);

            worker.RunWorkerAsync(workItems.GetEnumerator());
        }

        void DoWork(object sender, DoWorkEventArgs eventArgs)
        {
            BackgroundWorker localWorker = sender as BackgroundWorker;

            IEnumerator<ActionItem> enumerator = (IEnumerator<ActionItem>) eventArgs.Argument;

            eventArgs.Result = SimulateAction(enumerator, localWorker, eventArgs);
        }

        void OnProgress(object sender, ProgressChangedEventArgs eventArgs)
        {
            this.progressBar.Value = eventArgs.ProgressPercentage;
            var msg = (string) eventArgs.UserState;

            logInfo(msg);
        }

        void OnComplete(object sender, RunWorkerCompletedEventArgs eventArgs)
        {
            this.progressBar.Value = 100;
            logInfo(string.Format(
                "Complete - {0} action{1} processed",
                this.workItemsComplete,
                this.workItemsComplete == 1 ? "" : "s"
            ));
        }

        private int SimulateAction(
            IEnumerator<ActionItem> enumerator,
            BackgroundWorker localWorker,
            DoWorkEventArgs args
        )
        {
            var (msg, _) = enumerator.Current;
            int percentComplete = this.workItemsComplete * 100 / this.totalWorkItems;
            localWorker.ReportProgress(percentProgress: percentComplete, msg);

            if (enumerator.MoveNext())
            {
                this.workItemsComplete++;

                SimulateAction(enumerator, worker, args);
            }

            return this.workItemsComplete;
        }
    }
}
