namespace PhotoPrep
{
    partial class ImportForm
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
            this.chooseFromDir = new System.Windows.Forms.Button();
            this.fromDirName = new System.Windows.Forms.TextBox();
            this.toDirName = new System.Windows.Forms.TextBox();
            this.chooseToDir = new System.Windows.Forms.Button();
            this.shouldUseDateWritten = new System.Windows.Forms.CheckBox();
            this.shouldIncludePhotos = new System.Windows.Forms.CheckBox();
            this.shouldIncludeVideos = new System.Windows.Forms.CheckBox();
            this.prefixToRemoveLabel = new System.Windows.Forms.Label();
            this.prefixToRemove = new System.Windows.Forms.TextBox();
            this.cameraIdentifier = new System.Windows.Forms.TextBox();
            this.cameraIdentifierLabel = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseFromDir
            // 
            this.chooseFromDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.chooseFromDir.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFromDir.Location = new System.Drawing.Point(12, 23);
            this.chooseFromDir.Name = "chooseFromDir";
            this.chooseFromDir.Size = new System.Drawing.Size(130, 23);
            this.chooseFromDir.TabIndex = 1;
            this.chooseFromDir.Text = "From folder";
            this.chooseFromDir.UseVisualStyleBackColor = true;
            this.chooseFromDir.Click += new System.EventHandler(this.chooseFromDir_Click);
            // 
            // fromDirName
            // 
            this.fromDirName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDirName.Location = new System.Drawing.Point(148, 21);
            this.fromDirName.Name = "fromDirName";
            this.fromDirName.Size = new System.Drawing.Size(458, 26);
            this.fromDirName.TabIndex = 100;
            this.fromDirName.TabStop = false;
            this.fromDirName.TextChanged += new System.EventHandler(this.fromDirName_TextChanged);
            this.fromDirName.LostFocus += new System.EventHandler(this.fromDirName_TextChanged);
            // 
            // toDirName
            // 
            this.toDirName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDirName.Location = new System.Drawing.Point(148, 57);
            this.toDirName.Name = "toDirName";
            this.toDirName.Size = new System.Drawing.Size(458, 26);
            this.toDirName.TabIndex = 101;
            this.toDirName.TabStop = false;
            this.toDirName.TextChanged += new System.EventHandler(this.toDirName_TextChanged);
            // 
            // chooseToDir
            // 
            this.chooseToDir.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseToDir.Location = new System.Drawing.Point(12, 59);
            this.chooseToDir.Name = "chooseToDir";
            this.chooseToDir.Size = new System.Drawing.Size(130, 23);
            this.chooseToDir.TabIndex = 2;
            this.chooseToDir.Text = "To folder";
            this.chooseToDir.UseVisualStyleBackColor = true;
            this.chooseToDir.Click += new System.EventHandler(this.chooseToDir_Click);
            // 
            // shouldUseDateWritten
            // 
            this.shouldUseDateWritten.AutoSize = true;
            this.shouldUseDateWritten.Checked = true;
            this.shouldUseDateWritten.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shouldUseDateWritten.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shouldUseDateWritten.Location = new System.Drawing.Point(347, 138);
            this.shouldUseDateWritten.Name = "shouldUseDateWritten";
            this.shouldUseDateWritten.Size = new System.Drawing.Size(226, 22);
            this.shouldUseDateWritten.TabIndex = 20;
            this.shouldUseDateWritten.Text = "Use date taken as new file name";
            this.shouldUseDateWritten.UseVisualStyleBackColor = true;
            // 
            // shouldIncludePhotos
            // 
            this.shouldIncludePhotos.AutoSize = true;
            this.shouldIncludePhotos.Checked = true;
            this.shouldIncludePhotos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shouldIncludePhotos.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shouldIncludePhotos.Location = new System.Drawing.Point(347, 177);
            this.shouldIncludePhotos.Name = "shouldIncludePhotos";
            this.shouldIncludePhotos.Size = new System.Drawing.Size(119, 22);
            this.shouldIncludePhotos.TabIndex = 21;
            this.shouldIncludePhotos.Text = "Include Photos";
            this.shouldIncludePhotos.UseVisualStyleBackColor = true;
            // 
            // shouldIncludeVideos
            // 
            this.shouldIncludeVideos.AutoSize = true;
            this.shouldIncludeVideos.Checked = true;
            this.shouldIncludeVideos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shouldIncludeVideos.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shouldIncludeVideos.Location = new System.Drawing.Point(347, 216);
            this.shouldIncludeVideos.Name = "shouldIncludeVideos";
            this.shouldIncludeVideos.Size = new System.Drawing.Size(119, 22);
            this.shouldIncludeVideos.TabIndex = 22;
            this.shouldIncludeVideos.Text = "Include Videos";
            this.shouldIncludeVideos.UseVisualStyleBackColor = true;
            // 
            // prefixToRemoveLabel
            // 
            this.prefixToRemoveLabel.AutoSize = true;
            this.prefixToRemoveLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prefixToRemoveLabel.Location = new System.Drawing.Point(26, 142);
            this.prefixToRemoveLabel.Name = "prefixToRemoveLabel";
            this.prefixToRemoveLabel.Size = new System.Drawing.Size(151, 18);
            this.prefixToRemoveLabel.TabIndex = 11;
            this.prefixToRemoveLabel.Text = "Name prefix to remove";
            // 
            // prefixToRemove
            // 
            this.prefixToRemove.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prefixToRemove.Location = new System.Drawing.Point(206, 138);
            this.prefixToRemove.Name = "prefixToRemove";
            this.prefixToRemove.Size = new System.Drawing.Size(100, 26);
            this.prefixToRemove.TabIndex = 3;
            // 
            // cameraIdentifier
            // 
            this.cameraIdentifier.AcceptsReturn = true;
            this.cameraIdentifier.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIdentifier.Location = new System.Drawing.Point(206, 176);
            this.cameraIdentifier.Name = "cameraIdentifier";
            this.cameraIdentifier.Size = new System.Drawing.Size(100, 26);
            this.cameraIdentifier.TabIndex = 4;
            // 
            // cameraIdentifierLabel
            // 
            this.cameraIdentifierLabel.AutoSize = true;
            this.cameraIdentifierLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIdentifierLabel.Location = new System.Drawing.Point(84, 180);
            this.cameraIdentifierLabel.Name = "cameraIdentifierLabel";
            this.cameraIdentifierLabel.Size = new System.Drawing.Size(91, 18);
            this.cameraIdentifierLabel.TabIndex = 13;
            this.cameraIdentifierLabel.Text = "Camera Label";
            // 
            // previewButton
            // 
            this.previewButton.Enabled = false;
            this.previewButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewButton.Location = new System.Drawing.Point(148, 296);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(318, 57);
            this.previewButton.TabIndex = 5;
            this.previewButton.Text = "Simulate";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // ImportForm
            // 
            this.AcceptButton = this.previewButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 425);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.cameraIdentifier);
            this.Controls.Add(this.cameraIdentifierLabel);
            this.Controls.Add(this.prefixToRemove);
            this.Controls.Add(this.prefixToRemoveLabel);
            this.Controls.Add(this.shouldIncludeVideos);
            this.Controls.Add(this.shouldIncludePhotos);
            this.Controls.Add(this.shouldUseDateWritten);
            this.Controls.Add(this.toDirName);
            this.Controls.Add(this.chooseToDir);
            this.Controls.Add(this.fromDirName);
            this.Controls.Add(this.chooseFromDir);
            this.Name = "ImportForm";
            this.Text = "Import Photos and Videos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button chooseFromDir;
        private System.Windows.Forms.TextBox fromDirName;
        private System.Windows.Forms.TextBox toDirName;
        private System.Windows.Forms.Button chooseToDir;
        private System.Windows.Forms.CheckBox shouldUseDateWritten;
        private System.Windows.Forms.CheckBox shouldIncludePhotos;
        private System.Windows.Forms.CheckBox shouldIncludeVideos;
        private System.Windows.Forms.Label prefixToRemoveLabel;
        private System.Windows.Forms.TextBox prefixToRemove;
        private System.Windows.Forms.TextBox cameraIdentifier;
        private System.Windows.Forms.Label cameraIdentifierLabel;
        private System.Windows.Forms.Button previewButton;
    }
}

