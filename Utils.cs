using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace IDAProSelector
{
    public enum FileArchitecture
    {
        Pe32 = 0x10b,
        Pe32P = 0x20b
    }

    public static class Utils
    {
        public static string GetWrapperDirectory()
        {
            var exeFile = System.Reflection.Assembly.GetEntryAssembly().Location;
            return Path.GetDirectoryName(exeFile);
        }

        public static bool CheckInstallation()
        {
            var fileList = Directory.GetFiles(GetWrapperDirectory());
            var files = fileList.Select(file => new FileInfo(file).Name).ToList();
            return files.Contains("idaq.exe") && files.Contains("idaq64.exe");
        }

        public static void RunIDA(FileArchitecture arch, bool asAdmin, string fileName = null)
        {
            var exeFileName = (arch == FileArchitecture.Pe32 ? "idaq.exe" : "idaq64.exe");
            var exePath = Path.Combine(GetWrapperDirectory(), exeFileName);
            var info = new ProcessStartInfo(exePath);
            if (fileName != null) {
                info.Arguments = $"\"{fileName}\"";
            }
            if (asAdmin) {
                info.Verb = "runas";
            }
            Process.Start(info);
            Environment.Exit(0);
        }

        public static FileArchitecture DetectExecutableArchicture(string pFilePath)
        {
            ushort architecture = 0;
            using (var fStream = new FileStream(pFilePath, FileMode.Open, FileAccess.Read)) {
                using (var bReader = new BinaryReader(fStream)) {
                    if (bReader.ReadUInt16() == 23117) {
                        fStream.Seek(0x3A, SeekOrigin.Current);
                        fStream.Seek(bReader.ReadUInt32(), SeekOrigin.Begin);
                        if (bReader.ReadUInt32() == 17744) {
                            fStream.Seek(20, SeekOrigin.Current);
                            architecture = bReader.ReadUInt16();
                        }
                    }
                }
            }
            return (FileArchitecture)architecture;
        }
    }
}
