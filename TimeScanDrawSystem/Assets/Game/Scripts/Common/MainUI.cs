// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForState.ForUI;
using InGame.ForState;

namespace InGame.ForUI
{
    public class MainUI : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("State UI")]
        [SerializeField] private ReadyView _readyView = null;

        // --------------------------------------------------
        // Fucntions - Nomal
        // --------------------------------------------------
        public void OnInit(Action readyBtnOnClick)
        {
            _readyView.OnInit(readyBtnOnClick);
        }

        public void VisiablesToStateUI(EStateType stateType, bool isVisiable)
        {
            switch (stateType)
            {
                case EStateType.Ready: _readyView.gameObject.SetActive(isVisiable); break;
            }
        }
    }
}