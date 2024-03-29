﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoPrep
{
    public partial class ImportForm : Form
    {
        public ImportForm()
        {
            InitializeComponent();

            this.fromDirName.Text = Properties.Settings.Default.SourceFolderName;
            this.toDirName.Text = Properties.Settings.Default.TargetFolderName;
        }

        private void chooseFromDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
                SelectedPath = Properties.Settings.Default.SourceFolderName,
                ShowNewFolderButton = false
            };
            DialogResult folderSelectionResult = folderBrowserDialog.ShowDialog();

            if (folderSelectionResult.Equals(DialogResult.OK))
            {
                Properties.Settings.Default.SourceFolderName = this.fromDirName.Text = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
                setActionButtonState();
            }
        }

        private void chooseToDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
                SelectedPath = Properties.Settings.Default.TargetFolderName,
                ShowNewFolderButton = true
            };
            DialogResult folderSelectionResult = folderBrowserDialog.ShowDialog();

            if (folderSelectionResult.Equals(DialogResult.OK))
            {
                Properties.Settings.Default.TargetFolderName = this.toDirName.Text = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
                setActionButtonState();
            }
        }

        private void setActionButtonState()
        {
            if (shouldEnableActionButtons())
            {
                setActionButtonsEnabled(true);
            }
            else
            {
                setActionButtonsEnabled(false);
            }
        }

        private bool shouldEnableActionButtons()
        {
            return this.fromDirName.Text.Length > 0 && this.toDirName.Text.Length > 0;
        }

        private void setActionButtonsEnabled(bool enabled)
        {
            this.previewButton.Enabled = enabled;
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo fromDir = new System.IO.DirectoryInfo(this.fromDirName.Text);
            System.IO.DirectoryInfo toDir = new System.IO.DirectoryInfo(this.toDirName.Text);

            var fileRenames = RenameAction.GetNewNames(
                sourceDir: fromDir,
                fileExtensionFilter: new[] { "jpg", "jpeg", "heic", "heif", "mov", "mp4", "nef" },
                shouldUseDateWritten: shouldUseDateWritten.Checked,
                shouldIncludeSerialNumber: true,
                prefixToRemove: prefixToRemove.Text,
                cameraLabel: cameraIdentifier.Text);

            System.Windows.Forms.Form importSimulation = new ImportSimulator(
                sourceDir: fromDir,
                targetDir: toDir,
                fileRenames);

            importSimulation.ShowDialog();
        }

        private void fromDirName_TextChanged(object sender, EventArgs e)
        {
            setActionButtonState();
        }

        private void toDirName_TextChanged(object sender, EventArgs e)
        {
            setActionButtonState();
        }
    }
}
