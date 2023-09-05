// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForUnit
{
    public class Unit : MonoBehaviour
    {
        // --------------------------------------------------
        // Unit State Enum
        // --------------------------------------------------
        public enum EUnitState
        {
            Unknown   = 0,
            Walk      = 1,
            TurnRight = 2,
            Pozing    = 3,
        }

        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Animate Group")]
        [SerializeField] private Animator   _animator  = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private EUnitState _unitState       = EUnitState.Unknown;
        private Coroutine  _co_CurrentState = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Public
        public void OnInit()
        {

        }

        public void ChangeToUnitState(EUnitState state)
        {

        }

        // ----- Private
        private void _ChangeToUnitState(EUnitState unitState, float duration = 0.0f, Action doneCallBack = null)
        {
            if (!Enum.IsDefined(typeof(EUnitState), unitState))
            {
                Debug.LogError($"[Unit._ChangeToUnitState] {Enum.GetName(typeof(EUnitState), unitState)}은 정의되어있지 않은 Enum 값입니다.");
                return;
            }

            if (_unitState == unitState)
                return;

            _unitState = unitState;

            if (_co_CurrentState != null)
                StopCoroutine(_co_CurrentState);

            switch (_unitState)
            {
                case EUnitState.Walk:      _State_Walk(); break;
                case EUnitState.TurnRight: _State_TurnRight(); break;
                case EUnitState.Pozing:    _State_Pozing(); break;
            }
        }

        private void _State_Walk()
        {
            if (_co_CurrentState == null)
            {
                _co_CurrentState = StartCoroutine(_Co_Walk());
                return;
            }

            StopCoroutine(_co_CurrentState);
            _co_CurrentState = StartCoroutine(_Co_Walk());
        }

        private void _State_TurnRight()
        {
            if (_co_CurrentState == null)
            {
                _co_CurrentState = StartCoroutine(_Co_TurnRight());
                return;
            }

            StopCoroutine(_co_CurrentState);
            _co_CurrentState = StartCoroutine(_Co_Walk());
        }

        private void _State_Pozing()
        {
            if (_co_CurrentState == null)
            {
                _co_CurrentState = StartCoroutine(_Co_Pozing());
                return;
            }

            StopCoroutine(_co_CurrentState);
            _co_CurrentState = StartCoroutine(_Co_Pozing());
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_Walk()
        {
            while (_unitState == EUnitState.Walk)
            {
                yield return null;
            }
        }

        private IEnumerator _Co_TurnRight()
        {
            while (_unitState == EUnitState.TurnRight)
            {
                yield return null;
            }
        }
        private IEnumerator _Co_Pozing()
        {
            while (_unitState == EUnitState.Pozing)
            {
                yield return null;
            }
        }
    }
}