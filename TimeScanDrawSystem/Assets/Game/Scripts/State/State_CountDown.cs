// ----- C#
using InGame.ForState.ForUI;
using InGame.ForUnit;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.SimpleFSM;

namespace InGame.ForState
{
    public class State_CountDown : SimpleState<EStateType>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Owner
        private Main          _owner           = null;

        // ----- Manage
        private UnitController _unitController = null;

        // ----- UI
        private CountDownView _countDownView   = null;

        // ----- Count Down Value
        private const int     COUNT_DOWN_VALUE = 3;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public override EStateType StateType => EStateType.CountDown;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        protected override void _Start(EStateType preStateKey, object startParam)
        {
            Debug.Log($"<color=yellow>[State_CountDown._Start] CountDown State�� �����Ͽ����ϴ�.</color>");

            #region <Manage Group>
            _owner = Main.NullableInstance;
            if (_owner == null)
            {
                Debug.LogError($"<color=red>[State_CountDown._Start] Main�� Null �����Դϴ�.</color>");
                return;
            }

            _unitController = _owner.UnitController;
            if (_unitController == null)
            {
                Debug.LogError($"<color=red>[State_CountDown._Start] Unit Controller�� Null �����Դϴ�.</color>");
                return;
            }

            _countDownView = (CountDownView)_owner.MainUI.GetStateUI();
            if (_countDownView == null)
            {
                Debug.LogError($"<color=red>[State_CountDown._Start] CountDown View�� Null �����Դϴ�.</color>");
                return;
            }
            #endregion

            // Unit ����
            _unitController.ChangeToUnitState(Unit.EUnitState.Pozing);

            // UI �ʱ�ȭ
            _countDownView.gameObject.SetActive(true);
            _countDownView.CountDown
            (
                COUNT_DOWN_VALUE, 
                () => 
                {
                    StateMachine.Instance.ChangeState(EStateType.TimeScan, null);
                }
            );
        }

        protected override void _Finish(EStateType nextStateKey)
        {
            Debug.Log($"<color=yellow>[State_CountDown._Start] CountDown State�� ��Ż�Ͽ����ϴ�.</color>");
            _countDownView.gameObject.SetActive(false);
        }
    }
}