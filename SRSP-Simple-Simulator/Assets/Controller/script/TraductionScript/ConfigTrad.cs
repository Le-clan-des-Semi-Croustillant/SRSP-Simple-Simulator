using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;
using System.Text;
using TMPro;

namespace Traductionscript
{
    public class ConfigTrad : MonoBehaviour
    {
        /// <summary>
        /// Script Traduction on the configuration scene
        /// </summary>
        public SavedConfigReader.SavedConfig conf;

        public int currentLanguage;

        List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
        Dictionary<string, string> obj;
        public TextAsset dictionary;

        public string save;
        public string verify;
        public string back;
        public string configuration;

        public Text textSave;
        public Text textVerify;
        public Text textSave1;
        public Text textVerify1;
        public Text textBack;
        public TextMeshProUGUI textConfig;

        private void Awake()
        {
            Reader();
        }

        /// <summary>
        /// replace the text of Text object with translation associated
        /// </summary>
        void Update()
        {
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            currentLanguage = conf.language - 1;

            languages[currentLanguage].TryGetValue("Configuration", out configuration);
            languages[currentLanguage].TryGetValue("Back", out back);
            languages[currentLanguage].TryGetValue("Verify", out verify);
            languages[currentLanguage].TryGetValue("Save", out save);

            textBack.text = back;
            textConfig.text = configuration;
            textSave.text = save;
            textSave1.text = save;
            textVerify.text = verify;
            textVerify1.text = verify;
        }

        /// <summary>
        /// Load a dictionary with the xml link to the traduction
        /// </summary>
        void Reader()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(dictionary.text);
            XmlNodeList LanguageList = xmlDoc.GetElementsByTagName("language");
            foreach (XmlNode languageValue in LanguageList)
            {
                XmlNodeList languageContent = languageValue.ChildNodes;
                obj = new Dictionary<string, string>();

                foreach (XmlNode value in languageContent)
                {
                    if (value.Name == "Configuration")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Save")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Back")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Verify")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                }
                languages.Add(obj);
            }
        }
    }
}
