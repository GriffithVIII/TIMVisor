using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.AxHost;

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
        void FolderView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Brush HeaderColor = new SolidBrush(Color.FromArgb(51, 45, 45));
            Pen BorderColor = new Pen(new SolidBrush(Color.FromArgb(89, 89, 89)));

            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                e.Graphics.FillRectangle(HeaderColor, e.Bounds);
                e.Graphics.DrawRectangle(BorderColor, e.Bounds);
                e.Graphics.DrawString(e.Header.Text, Font,
                Brushes.White, e.Bounds, sf);
            }
        }

        void FolderView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Brush ItemColor = new SolidBrush(Color.FromArgb(66, 66, 66));
            Brush ItemHoverColor = new SolidBrush(Color.FromArgb(92, 92, 92));
            Pen BorderColor = new Pen(new SolidBrush(Color.FromArgb(89, 89, 89)));

            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                e.Graphics.FillRectangle(ItemColor, e.Bounds);
                if (e.Item.Selected)
                    e.Graphics.FillRectangle(ItemHoverColor, e.Bounds);
                else
                    e.Graphics.FillRectangle(ItemColor, e.Bounds);

                e.Graphics.DrawRectangle(BorderColor, e.Bounds);

                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawRectangle(BorderColor, e.Bounds);
                e.Graphics.DrawString(e.SubItem.Text, Font,
                Brushes.White, e.Bounds, sf);
            }
        }

        void OnClientSizeChanged(Object sender, EventArgs e)
        {
            FolderView.Height = panel1.Location.Y;
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            LoadFolder = new Button();
            textureBox = new PictureBox();
            FolderView = new ListView();
            cFilename = new ColumnHeader();
            cType = new ColumnHeader();
            cSize = new ColumnHeader();
            CopyButton = new Button();
            ExportButton = new Button();
            ImportButton = new Button();
            FileButton = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            ClutListView = new ListView();
            InfoCWidth = new ColumnHeader();
            InfoCHeight = new ColumnHeader();
            InfoCVRAM_X = new ColumnHeader();
            InfoCVRAM_Y = new ColumnHeader();
            TextureListView = new ListView();
            InfoTWidth = new ColumnHeader();
            InfoTHeight = new ColumnHeader();
            InfoTVRAM_X = new ColumnHeader();
            InfoTVRAM_Y = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)textureBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LoadFolder
            // 
            LoadFolder.BackColor = Color.FromArgb(66, 66, 66);
            LoadFolder.FlatStyle = FlatStyle.Flat;
            LoadFolder.Location = new Point(0, 0);
            LoadFolder.Name = "LoadFolder";
            LoadFolder.Size = new Size(72, 25);
            LoadFolder.TabIndex = 0;
            LoadFolder.Text = "Folder";
            LoadFolder.UseVisualStyleBackColor = true;
            LoadFolder.Click += LoadFolder_Click;
            // 
            // textureBox
            // 
            textureBox.Location = new Point(307, 47);
            textureBox.Name = "textureBox";
            textureBox.Size = new Size(315, 237);
            textureBox.TabIndex = 1;
            textureBox.TabStop = false;
            // 
            // FolderView
            // 
            FolderView.BackColor = Color.FromArgb(66, 66, 66);
            FolderView.BorderStyle = BorderStyle.None;
            FolderView.Columns.AddRange(new ColumnHeader[] { cFilename, cType, cSize });
            FolderView.ForeColor = SystemColors.WindowText;
            FolderView.FullRowSelect = true;
            FolderView.Location = new Point(0, 47);
            FolderView.Name = "FolderView";
            FolderView.OwnerDraw = true;
            FolderView.Size = new Size(301, 391);
            FolderView.TabIndex = 5;
            FolderView.UseCompatibleStateImageBehavior = false;
            FolderView.View = View.Details;
            FolderView.DrawColumnHeader += FolderView_DrawColumnHeader;
            FolderView.DrawSubItem += FolderView_DrawSubItem;
            FolderView.SelectedIndexChanged += FolderView_SelectedIndexChanged;
            // 
            // cFilename
            // 
            cFilename.Text = "Filename";
            cFilename.Width = 150;
            // 
            // cType
            // 
            cType.Text = "Type";
            // 
            // cSize
            // 
            cSize.Text = "Size";
            cSize.Width = 91;
            // 
            // CopyButton
            // 
            CopyButton.BackColor = Color.FromArgb(66, 66, 66);
            CopyButton.FlatStyle = FlatStyle.Flat;
            CopyButton.Location = new Point(720, 0);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(75, 25);
            CopyButton.TabIndex = 6;
            CopyButton.Text = "Copy";
            CopyButton.UseVisualStyleBackColor = false;
            CopyButton.Click += CopyButton_Click;
            // 
            // ExportButton
            // 
            ExportButton.BackColor = Color.FromArgb(66, 66, 66);
            ExportButton.FlatStyle = FlatStyle.Flat;
            ExportButton.Location = new Point(226, 0);
            ExportButton.Name = "ExportButton";
            ExportButton.Size = new Size(75, 25);
            ExportButton.TabIndex = 7;
            ExportButton.Text = "Export";
            ExportButton.UseVisualStyleBackColor = false;
            ExportButton.Click += ExportButton_Click;
            // 
            // ImportButton
            // 
            ImportButton.BackColor = Color.FromArgb(66, 66, 66);
            ImportButton.FlatStyle = FlatStyle.Flat;
            ImportButton.Location = new Point(150, 0);
            ImportButton.Name = "ImportButton";
            ImportButton.Size = new Size(75, 25);
            ImportButton.TabIndex = 8;
            ImportButton.Text = "Import";
            ImportButton.UseVisualStyleBackColor = true;
            ImportButton.Click += ImportButton_Click;
            // 
            // FileButton
            // 
            FileButton.BackColor = Color.FromArgb(66, 66, 66);
            FileButton.FlatStyle = FlatStyle.Flat;
            FileButton.Location = new Point(73, 0);
            FileButton.Name = "FileButton";
            FileButton.Size = new Size(75, 25);
            FileButton.TabIndex = 9;
            FileButton.Text = "File";
            FileButton.UseVisualStyleBackColor = true;
            FileButton.Click += FileButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ClutListView);
            panel1.Controls.Add(TextureListView);
            panel1.Location = new Point(0, 439);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 158);
            panel1.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 14;
            label2.Text = "Texture";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 80);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 13;
            label1.Text = "CLUT";
            // 
            // ClutListView
            // 
            ClutListView.BackColor = Color.FromArgb(66, 66, 66);
            ClutListView.Columns.AddRange(new ColumnHeader[] { InfoCWidth, InfoCHeight, InfoCVRAM_X, InfoCVRAM_Y });
            ClutListView.Location = new Point(0, 97);
            ClutListView.Name = "ClutListView";
            ClutListView.OwnerDraw = true;
            ClutListView.Size = new Size(301, 47);
            ClutListView.TabIndex = 1;
            ClutListView.UseCompatibleStateImageBehavior = false;
            ClutListView.View = View.Details;
            ClutListView.DrawColumnHeader += FolderView_DrawColumnHeader;
            ClutListView.DrawSubItem += FolderView_DrawSubItem;
            // 
            // InfoCWidth
            // 
            InfoCWidth.Text = "Colors";
            InfoCWidth.Width = 74;
            // 
            // InfoCHeight
            // 
            InfoCHeight.Text = "CLUTs";
            InfoCHeight.Width = 74;
            // 
            // InfoCVRAM_X
            // 
            InfoCVRAM_X.Text = "VRAM X";
            InfoCVRAM_X.Width = 74;
            // 
            // InfoCVRAM_Y
            // 
            InfoCVRAM_Y.Text = "VRAM Y";
            InfoCVRAM_Y.Width = 74;
            // 
            // TextureListView
            // 
            TextureListView.BackColor = Color.FromArgb(66, 66, 66);
            TextureListView.Columns.AddRange(new ColumnHeader[] { InfoTWidth, InfoTHeight, InfoTVRAM_X, InfoTVRAM_Y });
            TextureListView.Location = new Point(0, 25);
            TextureListView.Name = "TextureListView";
            TextureListView.OwnerDraw = true;
            TextureListView.Size = new Size(301, 47);
            TextureListView.TabIndex = 0;
            TextureListView.UseCompatibleStateImageBehavior = false;
            TextureListView.View = View.Details;
            TextureListView.DrawColumnHeader += FolderView_DrawColumnHeader;
            TextureListView.DrawSubItem += FolderView_DrawSubItem;
            // 
            // InfoTWidth
            // 
            InfoTWidth.Text = "Width";
            InfoTWidth.Width = 74;
            // 
            // InfoTHeight
            // 
            InfoTHeight.Text = "Height";
            InfoTHeight.Width = 74;
            // 
            // InfoTVRAM_X
            // 
            InfoTVRAM_X.Text = "VRAM X";
            InfoTVRAM_X.Width = 74;
            // 
            // InfoTVRAM_Y
            // 
            InfoTVRAM_Y.Text = "VRAM Y";
            InfoTVRAM_Y.Width = 74;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(48, 48, 48);
            ClientSize = new Size(1052, 583);
            Controls.Add(panel1);
            Controls.Add(FileButton);
            Controls.Add(ImportButton);
            Controls.Add(ExportButton);
            Controls.Add(CopyButton);
            Controls.Add(FolderView);
            Controls.Add(textureBox);
            Controls.Add(LoadFolder);
            ForeColor = SystemColors.Window;
            Name = "Main";
            Text = "Form1";
            ClientSizeChanged += OnClientSizeChanged;
            ((System.ComponentModel.ISupportInitialize)textureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Button ExportButton;
        private Button ImportButton;
        private Button FileButton;
        private Panel panel1;
        private ListView ClutListView;
        private ColumnHeader InfoCWidth;
        private ColumnHeader InfoCHeight;
        private ColumnHeader InfoCVRAM_X;
        private ColumnHeader InfoCVRAM_Y;
        private ListView TextureListView;
        private ColumnHeader InfoTWidth;
        private ColumnHeader InfoTHeight;
        private ColumnHeader InfoTVRAM_X;
        private ColumnHeader InfoTVRAM_Y;
        private Label label2;
        private Label label1;
    }
}