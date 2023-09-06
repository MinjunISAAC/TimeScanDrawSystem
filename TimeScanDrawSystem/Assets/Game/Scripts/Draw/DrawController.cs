// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForItem;
using System;

namespace InGame.ForDraw.Manage
{
    public class DrawController : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------




        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private EItemType _itemType = EItemType.Unknown;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void SetToSeleteItem(EItemType itemType)
        {
            // [TODO] 테스트 후 삭제 부분
            if (_itemType != EItemType.Unknown)
            {
                if (Enum.IsDefined(typeof(EItemType), itemType))
                    _itemType = itemType;

                return;
            }
        }
    }
}