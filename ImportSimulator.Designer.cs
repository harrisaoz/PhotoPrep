namespace PhotoPrep
{
    partial class ImportSimulator
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
            this.detailBox = new System.Windows.Forms.TextBox();
            this.summaryBox = new System.Windows.Forms.TextBox();
            this.skippedInfoBox = new System.Windows.Forms.TextBox();
            this.runImport = new System.Windows.Forms.Button();
            this.topInfoPanel = new System.Windows.Forms.Panel();
            this.simulationProgress = new System.Windows.Forms.ProgressBar();
            this.simulationWorker = new System.ComponentModel.BackgroundWorker();
            this.topInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailBox
            // 
            this.detailBox.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            this.detailBox.BackColor = System.Drawing.SystemColors.Info;
            this.detailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.detailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.detailBox.Location = new System.Drawing.Point(0, 91);
            this.detailBox.MaxLength = 500000;
            this.detailBox.Multiline = true;
            this.detailBox.Name = "detailBox";
            this.detailBox.ReadOnly = true;
            this.detailBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailBox.Size = new System.Drawing.Size(1206, 457);
            this.detailBox.TabIndex = 1;
            this.detailBox.Text = "Simulation Log:\r\n";
            // 
            // summaryBox
            // 
            this.summaryBox.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.summaryBox.BackColor = System.Drawing.Color.White;
            this.summaryBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.summaryBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.summaryBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.summaryBox.Location = new System.Drawing.Point(12, 12);
            this.summaryBox.Name = "summaryBox";
            this.summaryBox.ReadOnly = true;
            this.summaryBox.Size = new System.Drawing.Size(585, 16);
            this.summaryBox.TabIndex = 1;
            this.summaryBox.Text = "Loading summary information...";
            // 
            // skippedInfoBox
            // 
            this.skippedInfoBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.skippedInfoBox.BackColor = System.Drawing.Color.White;
            this.skippedInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skippedInfoBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.skippedInfoBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skippedInfoBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.skippedInfoBox.Location = new System.Drawing.Point(603, 12);
            this.skippedInfoBox.Name = "skippedInfoBox";
            this.skippedInfoBox.ReadOnly = true;
            this.skippedInfoBox.Size = new System.Drawing.Size(591, 16);
            this.skippedInfoBox.TabIndex = 2;
            this.skippedInfoBox.Text = "Warnings will be reported here.";
            // 
            // runImport
            // 
            this.runImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.runImport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.runImport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.runImport.FlatAppearance.BorderSize = 0;
            this.runImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runImport.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runImport.Location = new System.Drawing.Point(0, 488);
            this.runImport.Name = "runImport";
            this.runImport.Size = new System.Drawing.Size(1206, 60);
            this.runImport.TabIndex = 0;
            this.runImport.Text = "Start Import";
            this.runImport.UseVisualStyleBackColor = false;
            this.runImport.Click += new System.EventHandler(this.runImport_Click);
            // 
            // topInfoPanel
            // 
            this.topInfoPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.topInfoPanel.Controls.Add(this.simulationProgress);
            this.topInfoPanel.Controls.Add(this.skippedInfoBox);
            this.topInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.topInfoPanel.Name = "topInfoPanel";
            this.topInfoPanel.Size = new System.Drawing.Size(1206, 91);
            this.topInfoPanel.TabIndex = 3;
            // 
            // simulationProgress
            // 
            this.simulationProgress.Location = new System.Drawing.Point(12, 51);
            this.simulationProgress.Name = "simulationProgress";
            this.simulationProgress.Size = new System.Drawing.Size(1182, 23);
            this.simulationProgress.TabIndex = 0;
            // 
            // ImportSimulator
            // 
            this.AcceptButton = this.runImport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1206, 548);
            this.Controls.Add(this.runImport);
            this.Controls.Add(this.summaryBox);
            this.Controls.Add(this.detailBox);
            this.Controls.Add(this.topInfoPanel);
            this.Name = "ImportSimulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Simulating Import of Photos and Videos";
            this.Load += new System.EventHandler(this.ImportActionFinishedForm_Load);
            this.topInfoPanel.ResumeLayout(false);
            this.topInfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox detailBox;
        private System.Windows.Forms.TextBox summaryBox;
        private System.Windows.Forms.TextBox skippedInfoBox;
        private System.Windows.Forms.Button runImport;
        private System.Windows.Forms.Panel topInfoPanel;
        private System.ComponentModel.BackgroundWorker simulationWorker;
        private System.Windows.Forms.ProgressBar simulationProgress;
    }
}