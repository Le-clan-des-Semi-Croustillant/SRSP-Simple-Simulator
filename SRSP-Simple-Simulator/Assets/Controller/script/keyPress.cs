using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unityscript
{
    /// <summary>
    /// Allow user to press F1/F2/F3 to display environment panels
    /// and TAB to switch in between heading mode and wind mode
    /// </summary>
    public class keyPress : MonoBehaviour
    {
        public SwitchMode switchMode;
        public EnvPanel envPanel;
        private void Start()
        {
            switchMode = FindObjectOfType<SwitchMode>();
            envPanel = FindObjectOfType<EnvPanel>();
        }
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                switchMode.tabpress();
            }
            if (Input.GetKeyUp(KeyCode.F1))
            {
                envPanel.pressfone();
            }
            if (Input.GetKeyUp(KeyCode.F2))
            {
                envPanel.pressftwo();
            }
            if (Input.GetKeyUp(KeyCode.F3))
            {
                envPanel.pressfthree();
            }
        }
    }
}

