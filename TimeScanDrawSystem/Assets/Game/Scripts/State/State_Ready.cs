// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.SimpleFSM;
using InGame.ForState.ForUI;
using InGame.ForUnit;

namespace InGame.ForState
{
    public class State_Ready : SimpleState<EStateType>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Owner
        private Main           _owner          = null;

        // ----- UI
        private ReadyView      _readyView      = null;

        // ----- Manage
        private UnitController _unitController = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public override EStateType StateType => EStateType.Ready;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        protected override void _Start(EStateType preStateKey, object startParam)
        {
            Debug.Log($"<color=yellow>[State_Ready._Start] Ready State�� �����Ͽ����ϴ�.</color>");

            #region <Manage Group>
            _owner = Main.NullableInstance;
            if (_owner == null)
            {
                Debug.LogError($"<color=red>[State_Ready._Start] Main�� Null �����Դϴ�.</color>");
                return;
            }

            _unitController = _owner.UnitController;
            if (_unitController == null)
            {
                Debug.LogError($"<color=red>[State_Ready._Start] Unit Controller�� Null �����Դϴ�.</color>");
                return;
            }

            _readyView = (ReadyView)_owner.MainUI.GetStateUI();
            if (_readyView == null)
            {
                Debug.LogError($"<color=red>[State_Ready._Start] ReadyView�� Null �����Դϴ�.</color>");
                return;
            }
            #endregion

            // Unit �ʱ�ȭ
            _unitController.OnInit();

            // UI �ʱ�ȭ
            _readyView.gameObject.SetActive(true);
            _readyView.OnInit(_SetReadyButton);
            _readyView.ShowToStartButton();
        }

        protected override void _Finish(EStateType nextStateKey)
        {
            Debug.Log($"<color=yellow>[State_Ready._Start] Ready State�� ��Ż�Ͽ����ϴ�.</color>");

            _readyView.gameObject.SetActive(false);
        }

        // ----- Private
        private void _SetReadyButton()
        {
            // State ����
            StateMachine.Instance.ChangeState(EStateType.Select, null);
            
            // UI ����
            _readyView.gameObject.SetActive(false);
        }

        
    }
}