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
        [SerializeField] private ReadyView     _readyView     = null;
        [SerializeField] private SelectView    _selectView    = null;
        [SerializeField] private CountDownView _countDownView = null;
        [SerializeField] private TimeScanView  _timeScanView  = null;

        // --------------------------------------------------
        // Fucntions - Nomal
        // --------------------------------------------------
        public StateView GetStateUI()
        {
            var currentState = StateMachine.Instance.CurrentState;
            switch (currentState)
            {
                case EStateType.Ready:     return _readyView;
                case EStateType.Select:    return _selectView;
                case EStateType.CountDown: return _countDownView;
                case EStateType.TimeScan:  return _timeScanView;
                default:                   return null;
            }
        }
    }
}