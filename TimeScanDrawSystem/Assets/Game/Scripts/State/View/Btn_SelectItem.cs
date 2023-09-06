// ----- C#
using InGame.ForItem;
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.ForState.ForUI
{
    public class Btn_SelectItem : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private EItemType _itemType   = EItemType.Unknown;
        [SerializeField] private Button    _BTN_Select = null;
        [SerializeField] private Animation _animation  = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        private const string SHOW_TRIIGER = "BTN_ShowToSelectItem";
        private const string HIDE_TRIIGER = "BTN_HideToSelectItem";

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public EItemType ItemType => _itemType;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void OnDestroy()
        {
            _BTN_Select.onClick.RemoveAllListeners();
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit(Action onClickBtn)
        {
            _BTN_Select.onClick.AddListener(() => onClickBtn());
        }

        public void Visiable(bool isShow)
        { 
            if (isShow) _animation.clip = _animation.GetClip(SHOW_TRIIGER);
            else        _animation.clip = _animation.GetClip(HIDE_TRIIGER);

            _animation.Play();
        }
    }
}