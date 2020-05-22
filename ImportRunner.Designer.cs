namespace PhotoPrep
{
    partial class ImportRunner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topInfoPanel = new System.Windows.Forms.Panel();
            this.importProgress = new System.Windows.Forms.ProgressBar();
            this.importLog = new System.Windows.Forms.TextBox();
            this.asyncImportWorker = new System.ComponentModel.BackgroundWorker();
            this.topInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topInfoPanel
            // 
            this.topInfoPanel.Controls.Add(this.importProgress);
            this.topInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.topInfoPanel.Name = "topInfoPanel";
            this.topInfoPanel.Size = new System.Drawing.Size(800, 100);
            this.topInfoPanel.TabIndex = 0;
            // 
            // importProgress
            // 
            this.importProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.importProgress.Location = new System.Drawing.Point(0, 0);
            this.importProgress.Name = "importProgress";
            this.importProgress.Size = new System.Drawing.Size(800, 23);
            this.importProgress.TabIndex = 0;
            // 
            // importLog
            // 
            this.importLog.BackColor = System.Drawing.SystemColors.Info;
            this.importLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importLog.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importLog.Location = new System.Drawing.Point(0, 100);
            this.importLog.MaxLength = 1000000;
            this.importLog.Multiline = true;
            this.importLog.Name = "importLog";
            this.importLog.ReadOnly = true;
            this.importLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.importLog.Size = new System.Drawing.Size(800, 350);
            this.importLog.TabIndex = 1;
            this.importLog.Text = "Import Log:\r\n";
            // 
            // ImportRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.importLog);
            this.Controls.Add(this.topInfoPanel);
            this.Name = "ImportRunner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportRunner";
            this.Load += new System.EventHandler(this.ImportRunner_Load);
            this.topInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topInfoPanel;
        private System.Windows.Forms.ProgressBar importProgress;
        private System.Windows.Forms.TextBox importLog;
        private System.ComponentModel.BackgroundWorker asyncImportWorker;
    }
}