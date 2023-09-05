// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForState;
using InGame.ForUI;

namespace InGame
{
    public class Main : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("UI")]
        [SerializeField] private MainUI _mainUI = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------

        // --------------------------------------------------
        // Property
        // --------------------------------------------------
        public static Main NullableInstance
        {
            get;
            private set;
        } = null;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Awake() { NullableInstance = this; }

        private IEnumerator Start()
        {
            // State �ʱ�ȭ
            StateMachine.Instance.ChangeState(EStateType.Ready, null);

            // UI �ʱ�ȭ
            _mainUI.OnInit( _SetReadyButton );

            yield return null;
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        private void _SetReadyButton()
        {
            // State ����
            StateMachine.Instance.ChangeState(EStateType.TimeScan, null);

            // UI ����
            _mainUI.VisiablesToStateUI(EStateType.Ready, false);
        }
    }
}