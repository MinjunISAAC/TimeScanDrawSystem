// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForUnit;

namespace InGame.ForUnit
{
    public class UnitController : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private Unit _targetUnit = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit()
        {
            if (_targetUnit == null)
            {
                Debug.LogError($"<color=red>[UnitController.OnInit] Target Unit이 지정되지 않았습니다.</color>");
                return;
            }

            _targetUnit.OnInit();
        }
    }
}