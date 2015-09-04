using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace IDAProSelector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (!Utils.CheckInstallation()) {
                MessageBox.Show("IDA Pro has not detected", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            DragEnter += MainForm_DragEnter;
            DragDrop += MainForm_DragDrop;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string fn = ((string[])e.Data.GetData(DataFormats.FileDrop)).First();
            var arch = Utils.DetectExecutableArchicture(fn);
            Utils.RunIDA(arch, cb_RunAsAdmin.Checked, fn);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var version = FileVersionInfo.GetVersionInfo("idaq.exe");
            lbl_DetectedVersion.Text = version.ProductVersion;
        }

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }
            tb_SelectedFileName.Text = dialog.FileName;
            var arch = Utils.DetectExecutableArchicture(dialog.FileName);
            Utils.RunIDA(arch, cb_RunAsAdmin.Checked, dialog.FileName);
        }

        private void btn_Start32bit_Click(object sender, EventArgs e)
        {
            Utils.RunIDA(FileArchitecture.Pe32, cb_RunAsAdmin.Checked);
        }

        private void btn_Start64bit_Click(object sender, EventArgs e)
        {
            Utils.RunIDA(FileArchitecture.Pe32P, cb_RunAsAdmin.Checked);
        }
    }
}
