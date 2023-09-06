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
            Debug.Log($"<color=yellow>[State_Ready._Start] Ready State에 진입하였습니다.</color>");

            #region <Manage Group>
            _owner = Main.NullableInstance;
            if (_owner == null)
            {
                Debug.LogError($"<color=red>[State_Ready._Start] Main이 Null 상태입니다.</color>");
                return;
            }

            _unitController = _owner.UnitController;
            if (_unitController == null)
            {
                Debug.LogError($"<color=red>[State_Ready._Start] Unit Controller가 Null 상태입니다.</color>");
                return;
            }

            _readyView = (ReadyView)_owner.MainUI.GetStateUI();
            if (_readyView == null)
            {
                Debug.LogError($"<color=red>[State_Ready._Start] ReadyView가 Null 상태입니다.</color>");
                return;
            }
            #endregion

            // Unit 초기화
            _unitController.OnInit();

            // UI 초기화
            _readyView.gameObject.SetActive(true);
            _readyView.OnInit(_SetReadyButton);
            _readyView.ShowToStartButton();
        }

        protected override void _Finish(EStateType nextStateKey)
        {
            Debug.Log($"<color=yellow>[State_Ready._Start] Ready State에 이탈하였습니다.</color>");

            _readyView.gameObject.SetActive(false);
        }

        // ----- Private
        private void _SetReadyButton()
        {
            // State 변경
            StateMachine.Instance.ChangeState(EStateType.Select, null);
            
            // UI 설정
            _readyView.gameObject.SetActive(false);
        }

        
    }
}