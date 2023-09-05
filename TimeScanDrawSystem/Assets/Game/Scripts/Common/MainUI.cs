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
        public StateView GetStateUI()
        {
            var currentState = StateMachine.Instance.CurrentState;
            switch (currentState)
            {
                case EStateType.Ready: return _readyView;
                default:               return null;
            }
        }
    }
}