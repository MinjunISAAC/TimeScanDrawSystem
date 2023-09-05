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
                Debug.LogError($"<color=red>[UnitController.OnInit] Target Unit�� �������� �ʾҽ��ϴ�.</color>");
                return;
            }

            _targetUnit.OnInit();
        }
    }
}