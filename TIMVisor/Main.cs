using System.Windows.Forms;
using TIMVisor.Graphics.PNG;
using TIMVisor.Graphics.Format;
using TIMVisor.Helpers;
using System.Drawing;
using TIMVisor.Graphics.TIMLib;

namespace TIMVisor
{
    public partial class Main : Form
    {
        public string curFolder = "";
        public string curFile = "";
        public TIM curTim = new();
        public INI curIni = new();

        public Main()
        {
            InitializeComponent();
        }

        private void LoadFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog oFolder = new();
            if (oFolder.ShowDialog() != DialogResult.OK)
                return;

            FolderView.Items.Clear();
            TextureListView.Items.Clear();
            ClutListView.Items.Clear();
            string fname = oFolder.SelectedPath;
            curFolder = oFolder.SelectedPath;

            var filteredItems = FileHandler.FilterFolderFiles(fname);
            foreach (var file in filteredItems)
            {
                ListViewItem item = new(file.Info.Name);
                item.SubItems.Add(file.BPP);
                item.SubItems.Add($"{file.Info.Length}");
                FolderView.Items.Add(item);
            }
        }

        private void LoadFolderTexture(ListViewItem file)
        {
            string path = Path.Combine(curFolder, file.SubItems[0].Text);
            string type = file.SubItems[1].Text;

            (var bmp, var tim) = FileHandler.GetTIMConverted(path, type);
            curTim = tim;
            curFile = path;
            DisplayConvertedTexture(bmp);
            ShowTextureInfo();
        }

        private void FolderView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var curItem = FolderView.FocusedItem;
            LoadFolderTexture(curItem);
        }

        private void ShowTextureInfo()
        {
            TextureListView.Items.Clear();
            ClutListView.Items.Clear();
            //# Shows texture information
            var textureInfo = curTim.Image;
            ListViewItem item = new(textureInfo.Width.ToString());
            item.SubItems.Add(textureInfo.Height.ToString());
            item.SubItems.Add(textureInfo.VRAM_X.ToString());
            item.SubItems.Add(textureInfo.VRAM_Y.ToString());
            TextureListView.Items.Add(item);

            //# Shows first CLUT block information
            var paletteInfo = curTim.CLUT;
            ListViewItem itemN = new(paletteInfo.NumColors.ToString());
            itemN.SubItems.Add(paletteInfo.NumCLUTs.ToString());
            itemN.SubItems.Add(paletteInfo.VRAM_X.ToString());
            itemN.SubItems.Add(paletteInfo.VRAM_Y.ToString());
            ClutListView.Items.Add(itemN);
        }

        public void DisplayConvertedTexture(Bitmap bmp)
        {
            textureBox.Image = bmp;
            textureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textureBox.Image);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog oExport = new();
            oExport.Filter = "All supported formats(*.png;*.tim)|*.png;*.json|Portable Network Graphics PNG|*.png|TIM|*.tim";
            oExport.Title = "Save an Image File";
            oExport.ShowDialog();
            if (oExport.FileName != "")
            {
                switch(oExport.FilterIndex)
                {
                    case 1:
                        FileStream fs = (FileStream)oExport.OpenFile();
                        textureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        fs.Close();

                        var ini = JsonHandler.GetINI(curTim);
                        string path = Path.ChangeExtension(oExport.FileName, ".json");
                        JsonHandler.ExportINI(path, ini);
                        break;

                    case 2:
                        FileHandler.ExportTIM(curTim, oExport.FileName);
                        break;
                }
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fOpen = new();
            fOpen.Filter = "All supported formats(*.png;*.json)|*.png;*.json|Portable Network Graphics PNG|*.png|TIM data|*.json";
            fOpen.Title = "Import file";
            if (fOpen.ShowDialog() == DialogResult.OK)
            {
                switch (fOpen.FilterIndex)
                {
                    case 1:
                        LoadImportedData(Path.ChangeExtension(fOpen.FileName, ".json"));
                        LoadImportedImage(fOpen.FileName);
                        ShowTextureInfo();
                        FolderView.Items.Clear();
                        break;

                    case 2:
                        LoadImportedData(fOpen.FileName);
                        LoadImportedImage(Path.ChangeExtension(fOpen.FileName, ".png"));
                        ShowTextureInfo();
                        FolderView.Items.Clear();
                        break;
                }
            }
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fOpen = new();
            fOpen.Filter = "TIM|*.tim";
            fOpen.Title = "Load file";
            if (fOpen.ShowDialog() == DialogResult.OK)
            {
                var info = FileHandler.FilterFile(fOpen.FileName);

                string path = fOpen.FileName;
                string type = info.BPP;

                (var bmp, var tim) = FileHandler.GetTIMConverted(path, type);
                curTim = tim;
                curFile = path;
                DisplayConvertedTexture(bmp);
                ShowTextureInfo();
                FolderView.Items.Clear();
            }
        }

        private void DisplayOnlyFileView(TextureInfo file)
        {
            FolderView.Items.Clear();

            ListViewItem item = new(file.Info.Name);
            item.SubItems.Add(file.BPP);
            item.SubItems.Add($"{file.Info.Length}");
            FolderView.Items.Add(item);
        }

        private void LoadImportedImage(string path)
        {
            Bitmap bmp = new(path);

            curTim = FileHandler.GetPNGConverted(bmp, curIni);

            DisplayConvertedTexture(bmp);
        }

        private void LoadImportedData(string path)
        {
            var ini = JsonHandler.ImportINI(path);
            curIni = ini;
        }
    }
}