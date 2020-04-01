namespace Ksu.Cis._300.FileSystem
{
    partial class UserInterface
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
            this.uxTextBox = new System.Windows.Forms.TextBox();
            this.uxMakeFolderButton = new System.Windows.Forms.Button();
            this.uxMakeFileButton = new System.Windows.Forms.Button();
            this.uxRemoveButton = new System.Windows.Forms.Button();
            this.uxLabel1 = new System.Windows.Forms.Label();
            this.uxPathLabel = new System.Windows.Forms.Label();
            this.uxLabel3 = new System.Windows.Forms.Label();
            this.uxListBox = new System.Windows.Forms.ListBox();
            this.uxUpOneLevelButton = new System.Windows.Forms.Button();
            this.uxGoToButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(89, 31);
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.Size = new System.Drawing.Size(608, 31);
            this.uxTextBox.TabIndex = 0;
            this.uxTextBox.Text = "Enter Folder or File Name";
            // 
            // uxMakeFolderButton
            // 
            this.uxMakeFolderButton.Location = new System.Drawing.Point(89, 90);
            this.uxMakeFolderButton.Name = "uxMakeFolderButton";
            this.uxMakeFolderButton.Size = new System.Drawing.Size(173, 61);
            this.uxMakeFolderButton.TabIndex = 1;
            this.uxMakeFolderButton.Text = "Make Folder";
            this.uxMakeFolderButton.UseVisualStyleBackColor = true;
            // 
            // uxMakeFileButton
            // 
            this.uxMakeFileButton.Location = new System.Drawing.Point(306, 90);
            this.uxMakeFileButton.Name = "uxMakeFileButton";
            this.uxMakeFileButton.Size = new System.Drawing.Size(173, 61);
            this.uxMakeFileButton.TabIndex = 2;
            this.uxMakeFileButton.Text = "Make File";
            this.uxMakeFileButton.UseVisualStyleBackColor = true;
            // 
            // uxRemoveButton
            // 
            this.uxRemoveButton.Enabled = false;
            this.uxRemoveButton.Location = new System.Drawing.Point(524, 90);
            this.uxRemoveButton.Name = "uxRemoveButton";
            this.uxRemoveButton.Size = new System.Drawing.Size(173, 61);
            this.uxRemoveButton.TabIndex = 3;
            this.uxRemoveButton.Text = "Remove";
            this.uxRemoveButton.UseVisualStyleBackColor = true;
            // 
            // uxLabel1
            // 
            this.uxLabel1.AutoSize = true;
            this.uxLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabel1.Location = new System.Drawing.Point(89, 169);
            this.uxLabel1.Name = "uxLabel1";
            this.uxLabel1.Size = new System.Drawing.Size(97, 37);
            this.uxLabel1.TabIndex = 4;
            this.uxLabel1.Text = "Path:";
            // 
            // uxPathLabel
            // 
            this.uxPathLabel.AutoSize = true;
            this.uxPathLabel.Location = new System.Drawing.Point(91, 206);
            this.uxPathLabel.Name = "uxPathLabel";
            this.uxPathLabel.Size = new System.Drawing.Size(49, 25);
            this.uxPathLabel.TabIndex = 5;
            this.uxPathLabel.Text = "root";
            // 
            // uxLabel3
            // 
            this.uxLabel3.AutoSize = true;
            this.uxLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabel3.Location = new System.Drawing.Point(89, 273);
            this.uxLabel3.Name = "uxLabel3";
            this.uxLabel3.Size = new System.Drawing.Size(146, 37);
            this.uxLabel3.TabIndex = 6;
            this.uxLabel3.Text = "Content:";
            // 
            // uxListBox
            // 
            this.uxListBox.Enabled = false;
            this.uxListBox.FormattingEnabled = true;
            this.uxListBox.ItemHeight = 25;
            this.uxListBox.Location = new System.Drawing.Point(96, 339);
            this.uxListBox.Name = "uxListBox";
            this.uxListBox.Size = new System.Drawing.Size(601, 354);
            this.uxListBox.TabIndex = 7;
            // 
            // uxUpOneLevelButton
            // 
            this.uxUpOneLevelButton.Enabled = false;
            this.uxUpOneLevelButton.Location = new System.Drawing.Point(436, 720);
            this.uxUpOneLevelButton.Name = "uxUpOneLevelButton";
            this.uxUpOneLevelButton.Size = new System.Drawing.Size(261, 61);
            this.uxUpOneLevelButton.TabIndex = 8;
            this.uxUpOneLevelButton.Text = "Up One Level";
            this.uxUpOneLevelButton.UseVisualStyleBackColor = true;
            // 
            // uxGoToButton
            // 
            this.uxGoToButton.Enabled = false;
            this.uxGoToButton.Location = new System.Drawing.Point(96, 720);
            this.uxGoToButton.Name = "uxGoToButton";
            this.uxGoToButton.Size = new System.Drawing.Size(261, 61);
            this.uxGoToButton.TabIndex = 9;
            this.uxGoToButton.Text = "Go To";
            this.uxGoToButton.UseVisualStyleBackColor = true;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 793);
            this.Controls.Add(this.uxGoToButton);
            this.Controls.Add(this.uxUpOneLevelButton);
            this.Controls.Add(this.uxListBox);
            this.Controls.Add(this.uxLabel3);
            this.Controls.Add(this.uxPathLabel);
            this.Controls.Add(this.uxLabel1);
            this.Controls.Add(this.uxRemoveButton);
            this.Controls.Add(this.uxMakeFileButton);
            this.Controls.Add(this.uxMakeFolderButton);
            this.Controls.Add(this.uxTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "UserInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxTextBox;
        private System.Windows.Forms.Button uxMakeFolderButton;
        private System.Windows.Forms.Button uxMakeFileButton;
        private System.Windows.Forms.Button uxRemoveButton;
        private System.Windows.Forms.Label uxLabel1;
        private System.Windows.Forms.Label uxPathLabel;
        private System.Windows.Forms.Label uxLabel3;
        private System.Windows.Forms.ListBox uxListBox;
        private System.Windows.Forms.Button uxUpOneLevelButton;
        private System.Windows.Forms.Button uxGoToButton;
    }
}

