using System;
using System.IO;
using System.Windows.Forms;

namespace IDAProSelector
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            } else {
                var fileName = args[0];
                if (!File.Exists(fileName)) {
                    Environment.Exit(1);
                }
                if (!Utils.CheckInstallation()) {
                    Environment.Exit(2);
                }
                var arch = Utils.DetectExecutableArchicture(fileName);
                Utils.RunIDA(arch, false, fileName);
            }
        }
    }
}
