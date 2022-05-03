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
    /// Script Traduction on the menu scene
    /// </summary>
    public class MenuTrad : MonoBehaviour
    {
        public SavedConfigReader.SavedConfig conf;

        public int currentLanguage;

        public string menu;
        public string continueNav;
        public string newNav;
        public string configuration;
        public string exit;

        public Text textMenu;
        public Text textContinue;
        public Text textNew;
        public Text textConf;
        public Text textExit;

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
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            currentLanguage = conf.language - 1;

            languages[currentLanguage].TryGetValue("Menu", out menu);
            languages[currentLanguage].TryGetValue("Continue", out continueNav);
            languages[currentLanguage].TryGetValue("NewNavigation", out newNav);
            languages[currentLanguage].TryGetValue("Configuration", out configuration);
            languages[currentLanguage].TryGetValue("Exit", out exit);

            textMenu.text = menu;
            textContinue.text = continueNav;
            textNew.text = newNav;
            textConf.text = configuration;
            textExit.text = exit;
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
                    if (value.Name == "Menu")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Continue")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "NewNavigation")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Configuration")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Exit")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }

                }
                languages.Add(obj);
            }
        }
    }
}
