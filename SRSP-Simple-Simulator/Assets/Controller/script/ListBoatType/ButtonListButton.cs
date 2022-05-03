using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unityscript
{
    /// <summary>
    /// Prefab of a generated button to use it on our dynamique list button
    /// </summary>
    public class ButtonListButton : MonoBehaviour
    {
        [SerializeField]
        private Text mytext;
        [SerializeField]
        private ButtonListControl buttonControl;

        private string myTextString;

        public void SetText(string textString)
        {
            myTextString = textString;
            mytext.text = textString;
        }

        public void OnClick()
        {
            //buttonControl.ButtonClicked(myTextString);
        }
    }
}
