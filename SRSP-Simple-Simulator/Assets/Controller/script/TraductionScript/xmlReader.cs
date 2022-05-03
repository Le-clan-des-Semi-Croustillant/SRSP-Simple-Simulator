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
    /// Script Traduction on the Main scene
    /// </summary>

    public class xmlReader : MonoBehaviour
    {
        public TextAsset dictionary;

        public string languageName;
        public int currentLanguage;

        public string Language;
        public string Navigation;
        public string Environment;
        public string Help;
        public string AcceletationFactor;

        public string Save;
        public string Exit;
        public string Wind;
        public string Wave;
        public string Current;
        public string Documentation;
        public string HeadingMode;
        public string WindMode;
        public string SwitchH;
        public string SwitchW;
        public string WindS;
        public string WindD;
        public string Amplitude;
        public string Ok;
        public string WaveD;
        public string WaveL;
        public string CurrentSetup;
        public string CurrentS;
        public string CurrentD;
        public string Polar;
        public string SaveFile;
        public string Nopolar;

        public TextMeshProUGUI textNavigation;
        public TextMeshProUGUI textEnvironment;
        public TextMeshProUGUI textHelp;
        public Text textAcceletationFactor;

        public Text textheadingM;
        public Text textwindM;
        public TextMeshProUGUI textSwitchH;
        public TextMeshProUGUI textSwitchW;
        public TextMeshProUGUI textsave;
        public TextMeshProUGUI textsave1;
        public TextMeshProUGUI textexit;
        public TextMeshProUGUI textwind;
        public TextMeshProUGUI textwave;
        public TextMeshProUGUI textcurrent;

        public TextMeshProUGUI textWindset;
        public TextMeshProUGUI textWindS;
        public TextMeshProUGUI textWindD;
        public TextMeshProUGUI textWaveset;
        public TextMeshProUGUI textAmpl;
        public TextMeshProUGUI textWaveD;
        public TextMeshProUGUI textWaveL;
        public TextMeshProUGUI textCurrentset;
        public TextMeshProUGUI textCurrentS;
        public TextMeshProUGUI textCurrentD;

        public TextMeshProUGUI textPolar;
        public TextMeshProUGUI textsaveFile;
        public TextMeshProUGUI textNopolar;

        public Dropdown selectDropdown;
        public SavedConfigReader.SavedConfig conf;

        List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
        Dictionary<string, string> obj;

        void Awake()
        {
            Reader();
        }

        /// <summary>
        /// Get the value of current language by reading the config.json
        /// associated the dropdown object language value 
        /// </summary>
        void Start()
        {
            //read the config.json to get the current language
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            selectDropdown.value = conf.language - 1;
        }

        /// <summary>
        /// replace the text of Text object with translation associated
        /// </summary>
        void Update()
        {
            languages[currentLanguage].TryGetValue("Name", out languageName);
            languages[currentLanguage].TryGetValue("Navigation", out Navigation);
            languages[currentLanguage].TryGetValue("Environment", out Environment);
            languages[currentLanguage].TryGetValue("Help", out Help);
            languages[currentLanguage].TryGetValue("AcceletationFactor", out AcceletationFactor);

            languages[currentLanguage].TryGetValue("Save", out Save);
            languages[currentLanguage].TryGetValue("Wind", out Wind);
            languages[currentLanguage].TryGetValue("Wave", out Wave);
            languages[currentLanguage].TryGetValue("Current", out Current);
            languages[currentLanguage].TryGetValue("Documentation", out Documentation);
            languages[currentLanguage].TryGetValue("HeadingMode", out HeadingMode);
            languages[currentLanguage].TryGetValue("WindMode", out WindMode);
            languages[currentLanguage].TryGetValue("SwitchH", out SwitchH);
            languages[currentLanguage].TryGetValue("SwitchW", out SwitchW);
            languages[currentLanguage].TryGetValue("WindSpeed", out WindS);
            languages[currentLanguage].TryGetValue("WindDirection", out WindD);
            languages[currentLanguage].TryGetValue("Amplitude", out Amplitude);
            languages[currentLanguage].TryGetValue("WaveDirection", out WaveD);
            languages[currentLanguage].TryGetValue("WaveLength", out WaveL);
            languages[currentLanguage].TryGetValue("WaterCurrentSetup", out CurrentSetup);
            languages[currentLanguage].TryGetValue("CurrentSpeed", out CurrentS);
            languages[currentLanguage].TryGetValue("CurrentDirection", out CurrentD);
            languages[currentLanguage].TryGetValue("Polar", out Polar);
            languages[currentLanguage].TryGetValue("SaveFile", out SaveFile);
            languages[currentLanguage].TryGetValue("Exit", out Exit);
            languages[currentLanguage].TryGetValue("NoPolar", out Nopolar);


            textNopolar.text = Nopolar;
            textAmpl.text = Amplitude;
            textwindM.text = WindMode;
            textcurrent.text = Current;
            textCurrentD.text = CurrentD;
            textCurrentS.text = CurrentS;
            textCurrentset.text = CurrentSetup;
            textexit.text = Exit;
            textheadingM.text = HeadingMode;
            textPolar.text = Polar;
            textsave.text = Save;
            textsave1.text = Save;
            textsaveFile.text = SaveFile;
            textSwitchW.text = SwitchW;
            textSwitchH.text = SwitchH;
            textwave.text = Wave;
            textWaveD.text = WaveD;
            textWaveL.text = WaveL;
            textWaveset.text = Wave;
            textwind.text = Wind;
            textWindD.text = WindD;
            textWindS.text = WindS;
            textWindset.text = Wind;

            textNavigation.text = Navigation;
            textEnvironment.text = Environment;
            textHelp.text = Help;
            textAcceletationFactor.text = AcceletationFactor;
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
                    if (value.Name == "Name")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }

                    if (value.Name == "Navigation")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }

                    if (value.Name == "Environment")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }

                    if (value.Name == "Help")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }

                    if (value.Name == "AcceletationFactor")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Save")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Wind")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Wave")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Current")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Documentation")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "HeadingMode")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "WindMode")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "SwitchH")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "SwitchW")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "WindSpeed")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "WindDirection")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Amplitude")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "WaveDirection")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "WaveLength")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "WaterCurrentSetup")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "CurrentSpeed")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "CurrentDirection")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Polar")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "SaveFile")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "Exit")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                    if (value.Name == "NoPolar")
                    {
                        obj.Add(value.Name, value.InnerText);
                    }
                }
                languages.Add(obj);
            }
        }

        /// <summary>
        /// Change the current language and edit the config.json with it
        /// </summary>
        public void ValueChangeCheck()
        {
            currentLanguage = selectDropdown.value;
            if (currentLanguage == 0)
            {
                //Debug.Log(currentLanguage);
                //update the config.json file to the current langue 1 for english 2 for french
                conf.Update(language: 1);
            }
            if (currentLanguage == 1)
            {
                //Debug.Log(currentLanguage);
                conf.Update(language: 2);
            }
        }
    }
}
