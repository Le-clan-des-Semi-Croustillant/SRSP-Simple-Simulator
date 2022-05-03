using Communication.DataProcessing.Json;
using System;
using System.IO;

namespace Communication.DataProcessing.Files
{
    public partial class FileManageData
    {
        public static void CreateFilePolaire(string Name, Int64 ID, string DataPol)
        {
            string pathFile = pathDataPol + Name + "_" + ID.ToString() + ".pol";
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, DataPol);
        }
    }
}
