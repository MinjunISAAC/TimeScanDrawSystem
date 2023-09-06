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
    public class SelectView : StateView
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private List<Btn_SelectItem> _BTN_Items = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        private float BTN_SHOW_DELAY = 0.2f;

        // ----- Private
        private EItemType _itemType       = EItemType.Unknown;
        private Coroutine _co_BtnVisiable = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public EItemType SelectItemType => _itemType;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit(Action onClickSelectBtn)
        {
            for (int i = 0; i < _BTN_Items.Count; i++)
            {
                var btn = _BTN_Items[i];
                btn.OnInit
                (
                    () => 
                    { 
                        _itemType = btn.ItemType;
                        onClickSelectBtn?.Invoke();
                    }
                ); 
            }
        }

        public void VisiableToSelectItemButton(bool visiable, Action doneCallBack)
        {
            if (_co_BtnVisiable == null)
            {
                _co_BtnVisiable = StartCoroutine(_Co_VisiableItemButton(visiable, doneCallBack));
                return;
            }
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_VisiableItemButton(bool visiable, Action doneCallBack)
        {
            for( int i = 0; i < _BTN_Items.Count; i++ )
            {
                var btn = _BTN_Items[i];
                btn.Visiable(visiable);

                yield return new WaitForSeconds(BTN_SHOW_DELAY);
            }

            doneCallBack?.Invoke();
            _co_BtnVisiable = null;
        }
    }
}