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
    /// Script Traduction on the initialisation scene
    /// </summary>
    public class InitialisationTrad : MonoBehaviour
    {
        public SavedConfigReader.SavedConfig conf;

        public int currentLanguage;

        List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
        Dictionary<string, string> obj;
        public TextAsset dictionary;

        public string question;
        public string onqtvlm;
        public string yes;
        public string no;

        public Text textQuestion;
        public Text textOnQTVLM;
        public Text textYes;
        public Text textNo;
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

            languages[currentLanguage].TryGetValue("QuestionInit", out question);
            languages[currentLanguage].TryGetValue("QTVLM", out onqtvlm);
            languages[currentLanguage].TryGetValue("No", out no);
            languages[currentLanguage].TryGetValue("Yes", out yes);

            textQuestion.text = question;
            textOnQTVLM.text = onqtvlm;
            textYes.text = yes;
            textNo.text = no;

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
                    if (value.Name == "QuestionInit")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "QTVLM")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Yes")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "No")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                }
                languages.Add(obj);
            }
        }
    }
}