using System.IO;

namespace IDAProSelector
{
    public enum FileArchitecture { Pe32 = 0x10b, Pe32P = 0x20b }

    public static class Utils
    {
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
