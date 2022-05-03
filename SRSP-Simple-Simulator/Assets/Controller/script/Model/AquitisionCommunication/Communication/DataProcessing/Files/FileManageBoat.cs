using Communication.DataProcessing.Json;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Communication.DataProcessing.Files
{
    /// <summary>
    /// Management of boat to add him to BoatTypesList <see cref="BoatType"/>
    /// </summary>
    public partial class FileManageData
    {
        /// <summary>
        /// Save boat of a <see cref="BoatType"/> on spécific json file
        /// </summary>
        /// <param name="DataBoat"> all information of boat</param>
        public static void CreateBoatJson(BoatType DataBoat)
        {
            string pathFile = pathDataBoat + DataBoat.Name + "_" + DataBoat.ID + ".json";
            string jsonString = JsonConvert.SerializeObject(DataBoat);
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, jsonString);
        }

        /// <summary>
        /// Add to BoatTypesList all boat already exist on local file
        /// </summary>
        public static void UpdateAllBoatTypesList()
        {
            string[] filesBoat = Directory.GetFiles(pathDataBoat);

            for (int i = 0; i < filesBoat.Length; i++)
            {
                UpdateBoatTypesList(filesBoat[i]);
            }
        }

        /// <summary>
        /// Add to BoatTypesList boat already exist on local file
        /// </summary>
        /// <param name="path"> complete path of file you want to read</param>
        public static void UpdateBoatTypesList(string path)
        {
            string dataFile = File.ReadAllText(path);
            Console.WriteLine(dataFile);
            var infoFile = JsonConvert.DeserializeObject<BoatType>(dataFile);
            if (!BoatType.BoatTypesList.Contains(infoFile))
            {
                BoatType.BoatTypesList.Add(infoFile);
            }
        }

        /// <summary>
        /// Delete dyrectori of all files and recreate him
        /// </summary>
        public static void ResetAllFiles()
        {
            //supprimer tout le dossier racine
            if (Directory.Exists(pathData))
            {
                Directory.Delete(pathData, true);
            }
            //recrée le dossier racine
            CheckFilesFolderData();
        }

        /// <summary>
        /// Delete boat of a <see cref="BoatType"/>
        /// </summary>
        public static void ResetBoatList()
        {
            BoatType.BoatTypesList.Clear();
        }
    }
}
