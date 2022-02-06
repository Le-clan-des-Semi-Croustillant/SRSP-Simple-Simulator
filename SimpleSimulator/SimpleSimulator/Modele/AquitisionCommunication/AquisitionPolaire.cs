using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquitisionCommunication
{
    public class AquisitionPolaire
    {
        public AquisitionPolaire()
        {

        }

        public Dictionary<float, Dictionary<float,float>> ReadPolaire(string filePath)
        {
            List<string> file = File.ReadLines(filePath).ToList();
            List<string> speed = file.ElementAt(0).Split("\t").ToList();
            speed = speed.Where(x => x != "").ToList();
            file = file.GetRange(1, file.Count - 1);

            for (int i = 0; i < file.Count; i++)
            {
                file[i] = file.ElementAt(i).Replace(".", ",");
            }

            List<string> file1 = file.ElementAt(0).Split('\t').ToList().Where(x => x != "").ToList();

            Dictionary<float, Dictionary<float, float>> pol = new Dictionary<float, Dictionary<float, float>>();
            List<int> seq = Enumerable.Range(1, speed.Count - 1).ToList();

            foreach (string ligne in file)
            {
                List<string> filei = ligne.Split('\t').ToList().Where(x => x != "").ToList();
                Console.WriteLine(filei);
                Console.WriteLine(speed);
                Dictionary<float, float> dictAngle = new Dictionary<float, float>();
                foreach (int j in seq)
                {

                    dictAngle.Add(float.Parse(speed.ElementAt(j)), float.Parse(filei[j]));
                }
                pol.Add(float.Parse(filei[0]), dictAngle);
            }
            return pol;
        }

        public List<Dictionary<float, Dictionary<float, float>>> ReadMultiplePolaire(List<string> ListFilePath)
        {
            List<Dictionary<float, Dictionary<float, float>>> listPol = new List<Dictionary<float, Dictionary<float, float>>>() ;
            foreach(string filePath in ListFilePath){
                listPol.Add(ReadPolaire(filePath));
            }
            return listPol;
        }
    }
}
