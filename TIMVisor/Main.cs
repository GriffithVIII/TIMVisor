using TIMVisor.Graphics.PNG;
using TIMVisor.Helpers;

namespace TIMVisor
{
    public partial class Main : Form
    {
        public string curFolder;
        public Main()
        {
            InitializeComponent();
        }

        private void LoadFolder_Click(object sender, EventArgs e)
        {
            FolderView.Items.Clear();
            FolderBrowserDialog oFolder = new();
            if (oFolder.ShowDialog() != DialogResult.OK)
                return;

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

            var bmp = FileHandler.GetTIMConverted(path, type);
            //DisplayConvertedTexture(bmp);
        }

        private void FolderView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var curItem = FolderView.FocusedItem;
            LoadFolderTexture(curItem);
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
    }
}