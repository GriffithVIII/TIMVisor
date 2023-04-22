namespace TIMVisor
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadFolder = new Button();
            textureBox = new PictureBox();
            FolderView = new ListView();
            cFilename = new ColumnHeader();
            cType = new ColumnHeader();
            cSize = new ColumnHeader();
            CopyButton = new Button();
            ((System.ComponentModel.ISupportInitialize)textureBox).BeginInit();
            SuspendLayout();
            // 
            // LoadFolder
            // 
            LoadFolder.Location = new Point(0, 0);
            LoadFolder.Name = "LoadFolder";
            LoadFolder.Size = new Size(97, 23);
            LoadFolder.TabIndex = 0;
            LoadFolder.Text = "Open Folder";
            LoadFolder.UseVisualStyleBackColor = true;
            LoadFolder.Click += LoadFolder_Click;
            // 
            // textureBox
            // 
            textureBox.Location = new Point(480, 69);
            textureBox.Name = "textureBox";
            textureBox.Size = new Size(315, 237);
            textureBox.TabIndex = 1;
            textureBox.TabStop = false;
            // 
            // FolderView
            // 
            FolderView.Columns.AddRange(new ColumnHeader[] { cFilename, cType, cSize });
            FolderView.FullRowSelect = true;
            FolderView.Location = new Point(0, 47);
            FolderView.Name = "FolderView";
            FolderView.Size = new Size(302, 491);
            FolderView.TabIndex = 5;
            FolderView.UseCompatibleStateImageBehavior = false;
            FolderView.View = View.Details;
            FolderView.SelectedIndexChanged += FolderView_SelectedIndexChanged;
            // 
            // cFilename
            // 
            cFilename.Text = "Filename";
            cFilename.Width = 120;
            // 
            // cType
            // 
            cType.Text = "Type";
            // 
            // cSize
            // 
            cSize.Text = "Size";
            cSize.Width = 90;
            // 
            // CopyButton
            // 
            CopyButton.Location = new Point(468, 0);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(75, 23);
            CopyButton.TabIndex = 6;
            CopyButton.Text = "Copy";
            CopyButton.UseVisualStyleBackColor = true;
            CopyButton.Click += CopyButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 561);
            Controls.Add(CopyButton);
            Controls.Add(FolderView);
            Controls.Add(textureBox);
            Controls.Add(LoadFolder);
            Name = "Main";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)textureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button LoadFolder;
        private PictureBox textureBox;
        private ListView FolderView;
        private ColumnHeader cFilename;
        private ColumnHeader cType;
        private ColumnHeader cSize;
        private Button CopyButton;
    }
}