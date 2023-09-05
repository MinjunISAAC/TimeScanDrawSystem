// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.ForState.ForUI
{
    public class ReadyView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private Button _BTN_Start = null;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void OnDestroy() { _BTN_Start.onClick.RemoveAllListeners(); }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit(Action onClickBtn)
        {
            _BTN_Start.onClick.AddListener
            (
                () => onClickBtn()
            );
        }
    }
}