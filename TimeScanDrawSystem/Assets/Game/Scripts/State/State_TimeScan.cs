// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.SimpleFSM;
using InGame.ForDraw.Manage;
using InGame.ForState.ForUI;
using InGame.ForUnit;

namespace InGame.ForState
{
    public class State_TimeScan : SimpleState<EStateType>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Owner
        private Main           _owner          = null;

        // ----- UI
        private TimeScanView   _timeScanView   = null;

        // ----- Manage
        private UnitController _unitController = null;
        private DrawController _drawController = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public override EStateType StateType => EStateType.TimeScan;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        protected override void _Start(EStateType preStateKey, object startParam)
        {
            Debug.Log($"<color=yellow>[State_TimeScan._Start] Time Scan State�� �����Ͽ����ϴ�.</color>");

            #region <Manage Group>
            _owner = Main.NullableInstance;
            if (_owner == null)
            {
                Debug.LogError($"<color=red>[State_TimeScan._Start] Main�� Null �����Դϴ�.</color>");
                return;
            }

            _unitController = _owner.UnitController;
            if (_unitController == null)
            {
                Debug.LogError($"<color=red>[State_TimeScan._Start] Unit Controller�� Null �����Դϴ�.</color>");
                return;
            }

            _drawController = _owner.DrawController;
            if (_drawController == null)
            {
                Debug.LogError($"<color=red>[State_TimeScan._Start] Draw Controller�� Null �����Դϴ�.</color>");
                return;
            }

            _timeScanView = (TimeScanView)_owner.MainUI.GetStateUI();
            if (_timeScanView == null)
            {
                Debug.LogError($"<color=red>[State_TimeScan._Start] Time Scan View�� Null �����Դϴ�.</color>");
                return;
            }
            #endregion

            // Draw Controller �ʱ�ȭ
            _drawController.ShowDrawItem();

            // UI �ʱ�ȭ
            _timeScanView.gameObject.SetActive(true);
            _timeScanView.TimeScan(null);
        }

        protected override void _Finish(EStateType nextStateKey)
        {
            Debug.Log($"<color=yellow>[State_TimeScan._Start] Time Scan State�� ��Ż�Ͽ����ϴ�.</color>");

            _timeScanView.gameObject.SetActive(false);
        }
    }
}