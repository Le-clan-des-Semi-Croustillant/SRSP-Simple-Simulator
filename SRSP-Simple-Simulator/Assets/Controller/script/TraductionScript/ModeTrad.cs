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
     /// <summary>
     /// Script Traduction on the mode selection scene
     /// </summary>
    public class ModeTrad : MonoBehaviour
    {
        public SavedConfigReader.SavedConfig conf;

        public int currentLanguage;

        public string modeSelection;
        public string training;
        public string asynchronus;
        public string synchronus;
        public string cancel;

        public Text textMode;
        public Text textTrain;
        public Text textAsyn;
        public Text textSyn;
        public Text textCancel;

        List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
        Dictionary<string, string> obj;
        public TextAsset dictionary;
        private void Awake()
        {
            Reader();
        }
        /// <summary>
        /// replace the text of Text object with translation associated
        /// </summary>
        void Start()
        {
            //get the current language
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            currentLanguage = conf.language - 1;

            languages[currentLanguage].TryGetValue("ModeSelection", out modeSelection);
            languages[currentLanguage].TryGetValue("Training", out training);
            languages[currentLanguage].TryGetValue("Asynchronus", out asynchronus);
            languages[currentLanguage].TryGetValue("Synchronus", out synchronus);
            languages[currentLanguage].TryGetValue("Cancel", out cancel);

            textMode.text = modeSelection;
            textTrain.text = training;
            textAsyn.text = asynchronus;
            textSyn.text = synchronus;
            textCancel.text = cancel;

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
                    if (value.Name == "ModeSelection")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Training")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Asynchronus")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Synchronus")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Cancel")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }

                }
                languages.Add(obj);
            }
        }
    }
}
