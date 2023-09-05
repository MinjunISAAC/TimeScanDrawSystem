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
            Debug.Log($"[State_Ready._Start] Ready State�� �����Ͽ����ϴ�.");

            #region <Manage Group>
            _owner = Main.NullableInstance;
            if (_owner == null)
            {
                Debug.LogError($"[State_Ready._Start] Main�� Null �����Դϴ�.");
                return;
            }

            _unitController = _owner.UnitController;
            if (_unitController == null)
            {
                Debug.LogError($"[State_Ready._Start] Unit Controller�� Null �����Դϴ�.");
                return;
            }

            _readyView = (ReadyView)_owner.MainUI.GetStateUI();
            if (_readyView == null)
            {
                Debug.LogError($"[State_Ready._Start] ReadyView�� Null �����Դϴ�.");
                return;
            }
            #endregion

            // Unit �ʱ�ȭ
            _unitController.OnInit();

            // UI �ʱ�ȭ
            _readyView.OnInit(_SetReadyButton);

        }

        // ----- Private
        private void _SetReadyButton()
        {
            // State ����
            StateMachine.Instance.ChangeState(EStateType.TimeScan, null);
            
            // UI ����
            _readyView.gameObject.SetActive(false);
        }
    }
}