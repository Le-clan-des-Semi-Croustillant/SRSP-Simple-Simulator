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
    /// <summary>
    /// Script Traduction on the boat selection scene
    /// </summary>
    public class BoatSelectTrad : MonoBehaviour
    {
        public SavedConfigReader.SavedConfig conf;

        public int currentLanguage;
        public string boatSelection;
        public string refresh;
        public string cancel;

        public TextMeshProUGUI textBoatSelect;
        public TextMeshProUGUI textRefresh;
        public TextMeshProUGUI textCancel;

        List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
        Dictionary<string, string> obj;
        public TextAsset dictionary;

        void Awake()
        {
            Reader();
        }
        /// <summary>
        /// replace the text of Text object with translation associated
        /// </summary>
        private void Start()
        {
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            currentLanguage = conf.language - 1;

            languages[currentLanguage].TryGetValue("BoatSelection", out boatSelection);
            languages[currentLanguage].TryGetValue("Refresh", out refresh);
            languages[currentLanguage].TryGetValue("Cancel", out cancel);

            textBoatSelect.text = boatSelection;
            textRefresh.text = refresh;
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
                    if (value.Name == "BoatSelection")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Refresh")
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
