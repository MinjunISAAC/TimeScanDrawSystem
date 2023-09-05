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

        [Space] [Header("State - Ready")]
        [SerializeField] private Transform _startTrans = null;
        [SerializeField] private Transform _endTrans   = null;
        [SerializeField] private float     _moveDuration    = 0.0f;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        [SerializeField] private EUnitState _unitState       = EUnitState.Unknown;
        private Coroutine  _co_CurrentState = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Public
        public void OnInit()
        {
            _ChangeToUnitState
            (
                EUnitState.Walk, 
                () => 
                {
                    _ChangeToUnitState
                    (
                        EUnitState.TurnRight,
                        null
                    );
                }
            );
        }

        public void ChangeToUnitState(EUnitState unitState, Action doneCallBack) => _ChangeToUnitState(unitState, doneCallBack);

        // ----- Private
        private void _ChangeToUnitState(EUnitState unitState, Action doneCallBack = null)
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
                case EUnitState.Walk:      _State_Walk(doneCallBack);      break;
                case EUnitState.TurnRight: _State_TurnRight(doneCallBack); break;
                case EUnitState.Pozing:    _State_Pozing(doneCallBack);    break;
            }
        }

        private void _State_Walk(Action doneCallBack)
        {
            if (_co_CurrentState == null)
            {
                _co_CurrentState = StartCoroutine(_Co_Walk(doneCallBack));
                return;
            }

            StopCoroutine(_co_CurrentState);
            _co_CurrentState = StartCoroutine(_Co_Walk(doneCallBack));
        }

        private void _State_TurnRight(Action doneCallBack)
        {
            if (_co_CurrentState == null)
            {
                _co_CurrentState = StartCoroutine(_Co_TurnRight(doneCallBack));
                return;
            }

            StopCoroutine(_co_CurrentState);
            _co_CurrentState = StartCoroutine(_Co_TurnRight(doneCallBack));
        }

        private void _State_Pozing(Action doneCallBack)
        {
            if (_co_CurrentState == null)
            {
                _co_CurrentState = StartCoroutine(_Co_Pozing(doneCallBack));
                return;
            }

            StopCoroutine(_co_CurrentState);
            _co_CurrentState = StartCoroutine(_Co_Pozing(doneCallBack));
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_Walk(Action doneCallBack)
        {
            var sec      = 0.0f;
            var startPos = _startTrans.position;
            var endPos   = _endTrans.position;

            _animator.SetTrigger("Walk");

            while (sec < _moveDuration)
            {
                sec += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, endPos, sec / _moveDuration);
                yield return null;
            }

            transform.position = endPos;

            doneCallBack?.Invoke();
        }

        private IEnumerator _Co_TurnRight(Action doneCallBack)
        {
            _animator.SetTrigger("TurnRight");

            yield return new WaitForSeconds(1f);

            _animator.SetTrigger("Idle");

            doneCallBack?.Invoke();
        }

        private IEnumerator _Co_Pozing(Action doneCallBack)
        {
            while (_unitState == EUnitState.Pozing)
            {
                yield return null;
            }

            doneCallBack?.Invoke();
        }
    }
}