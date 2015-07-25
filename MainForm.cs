using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IDAProSelector
{
    public partial class MainForm : Form
    {
        private bool CheckInstallation()
        {
            var currentDir = Environment.CurrentDirectory;
            var files = Directory.GetFiles(currentDir).Select(file => new FileInfo(file).Name).ToList();
            return files.Contains("idaq.exe") && files.Contains("idaq64.exe");
        }

        private void RunIDA(bool pe32, string fileName = null)
        {
            var exeFileName = pe32 ? "idaq.exe" : "idaq64.exe";
            var info = new ProcessStartInfo(exeFileName);
            if (fileName != null) {
                info.Arguments = $"\"{fileName}\"";
            }
            if (cb_RunAsAdmin.Checked) {
                info.Verb = "runas";
            }
            Process.Start(info);
            Environment.Exit(0);
        }

        public MainForm()
        {
            InitializeComponent();
            if (!CheckInstallation()) {
                MessageBox.Show("IDA Pro has not detected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            RunIDA(arch == FileArchitecture.Pe32, fn);
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
            if (result == DialogResult.OK) {
                tb_SelectedFileName.Text = dialog.FileName;
            }
            var arch = Utils.DetectExecutableArchicture(dialog.FileName);
            RunIDA(arch == FileArchitecture.Pe32, dialog.FileName);
        }

        private void btn_Start32bit_Click(object sender, EventArgs e)
        {
            RunIDA(true);
        }

        private void btn_Start64bit_Click(object sender, EventArgs e)
        {
            RunIDA(false);
        }
    }
}
