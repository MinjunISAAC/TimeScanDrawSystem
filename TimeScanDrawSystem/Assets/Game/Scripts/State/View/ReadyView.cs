// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.ForState.ForUI
{
    public class ReadyView : StateView
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private Button    _BTN_Start = null;
        [SerializeField] private Animation _animation = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        private const string SHOW_TRIGGER = "BTN_ShowStart";
        private const float  SHOW_DELAY   = 2f;

        // ----- Private
        private Coroutine _co_Show = null;

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

        public void ShowToStartButton() 
        {
            if (_co_Show == null)
            {
                _co_Show = StartCoroutine(_Co_Show());
                return;
            }
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_Show() 
        {
            yield return new WaitForSeconds(SHOW_DELAY);

            _animation.clip = _animation.GetClip(SHOW_TRIGGER);
            _animation.Play();

            _co_Show = null;
        }
    }
}