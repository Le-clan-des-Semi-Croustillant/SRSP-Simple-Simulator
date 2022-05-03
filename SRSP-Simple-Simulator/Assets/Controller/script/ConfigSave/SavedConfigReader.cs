using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class SavedConfigReader
{
    public class SavedConfig
    {
        public string ipQTVL;
        public int portQTVL;
        public string ipRM;
        public int portRM;
        public int language;
        private SavedConfigReader reader;

        public SavedConfig(SavedConfigReader reader)
        {
            this.reader = reader;
        }

        public void Update(string ipQTVL = null, int? portQTVL = null, string ipRM = null, int? portRM = null, int? language = null)
        {
            if (!string.IsNullOrEmpty(ipQTVL))
            {
                this.ipQTVL = ipQTVL;
            }
            if (portQTVL.HasValue)
            {
                this.portQTVL = (int)portQTVL;
            }
            if (!string.IsNullOrEmpty(ipRM))
            {
                this.ipRM = ipRM;
            }
            if (portRM.HasValue)
            {
                this.portRM = (int)portRM;
            }
            if (language.HasValue)
            {
                this.language = (int)language;
            }
            this.reader.save();

        }

        public void SetReader(SavedConfigReader reader)
        {
            this.reader = reader;
        }
    }

    private SavedConfig config;
    private string configPath = "Assets//config.json";
   
    public SavedConfigReader()
    {
        this.config = new SavedConfig(this);
        this.loadfile();
        this.config.SetReader(this);
    }

    public SavedConfig getConfig()
    {
        return this.config;
    }

    public void loadfile()
    {
        string json = "";
        using (StreamReader r = new StreamReader(configPath))
        {
            json = r.ReadToEnd();
        }
        this.config = (SavedConfig)JsonConvert.DeserializeObject(json, this.config.GetType());
    }

    public void save()
    {
        this.config.SetReader(null);
        string json = JsonConvert.SerializeObject(this.config);
        this.config.SetReader(this);
        if (File.Exists(configPath))
        {
            File.Delete(configPath);
        }
        using (FileStream fs = File.Create(configPath))
        {
            byte[] jsonUTF = new UTF8Encoding(true).GetBytes(json);
            fs.Write(jsonUTF, 0, jsonUTF.Length);
        }
    }
}
