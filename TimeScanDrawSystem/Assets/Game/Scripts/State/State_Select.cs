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
    public class State_Select : SimpleState<EStateType>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Owner
        private Main           _owner          = null;

        // ----- UI
        private SelectView     _selectView     = null;

        // ----- Manage
        private UnitController _unitController = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public override EStateType StateType => EStateType.Select;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        protected override void _Start(EStateType preStateKey, object startParam)
        {
            Debug.Log($"<color=yellow>[State_Select._Start] Select State�� �����Ͽ����ϴ�.</color>");

            #region <Manage Group>
            _owner = Main.NullableInstance;
            if (_owner == null)
            {
                Debug.LogError($"<color=red>[State_Select._Start] Main�� Null �����Դϴ�.</color>");
                return;
            }

            _unitController = _owner.UnitController;
            if (_unitController == null)
            {
                Debug.LogError($"<color=red>[State_Select._Start] Unit Controller�� Null �����Դϴ�.</color>");
                return;
            }

            _selectView = (SelectView)_owner.MainUI.GetStateUI();
            if (_selectView == null)
            {
                Debug.LogError($"<color=red>[State_Select._Start] Select View�� Null �����Դϴ�.</color>");
                return;
            }
            #endregion

            // State UI �ʱ�ȭ
            _selectView.gameObject.SetActive(true);
            _selectView.OnInit();
            _selectView.VisiableToSelectItemButton(true, () => { });
        }

        protected override void _Finish(EStateType nextStateKey)
        {
            Debug.Log($"<color=yellow>[State_Select._Start] Select State�� ��Ż�Ͽ����ϴ�.</color>");

            _selectView.gameObject.SetActive(false);
        }

        // ----- Private
    }
}