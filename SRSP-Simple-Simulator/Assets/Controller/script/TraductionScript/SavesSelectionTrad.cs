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
    /// Script Traduction on the save selection scene
    /// </summary>
    public class SavesSelectionTrad : MonoBehaviour
    {
        public SavedConfigReader.SavedConfig conf;

        public int currentLanguage;

        List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
        Dictionary<string, string> obj;
        public TextAsset dictionary;

        public string saveSelection;
        public string ok;
        public string cancel;

        public TextMeshProUGUI textSaveSelect;
        public TextMeshProUGUI textOk;
        public TextMeshProUGUI textCancel;



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

            languages[currentLanguage].TryGetValue("SaveSelection", out saveSelection);
            languages[currentLanguage].TryGetValue("Ok", out ok);
            languages[currentLanguage].TryGetValue("Cancel", out cancel);

            textSaveSelect.text = saveSelection;
            textOk.text = ok;
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
                    if (value.Name == "SaveSelection")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Ok")
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
