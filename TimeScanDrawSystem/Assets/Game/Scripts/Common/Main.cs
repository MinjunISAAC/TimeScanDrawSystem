// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForState;
using InGame.ForUI;
using InGame.ForUnit;

namespace InGame
{
    public class Main : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Manage Group")]
        [SerializeField] private UnitController _unitController = null;

        [Space] [Header("UI")]
        [SerializeField] private MainUI         _mainUI         = null;

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

        public UnitController UnitController => _unitController;
        public MainUI         MainUI         => _mainUI;    

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Awake() { NullableInstance = this; }

        private IEnumerator Start()
        {
            // State �ʱ�ȭ
            StateMachine.Instance.ChangeState(EStateType.Ready, null);

            yield return null;
        }
    }
}