// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

// ----- User Defined

namespace InGame.ForState.ForUI
{
    public class TimeScanView : StateView
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Rect Group")]
        [SerializeField] private RectTransform _RECT_Canvas = null;
        [SerializeField] private RectTransform _RECT_Lazer  = null;

        [Header("Speed Value")]
        [SerializeField] private float         _speedValue  = 0.25f;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Private
        private Coroutine _co_TimeScan = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit()
        {

        }

        public void TimeScan(Action doneCallBack)
        {
            if (_co_TimeScan == null)
            {
                _co_TimeScan = StartCoroutine(_Co_TimeScan(doneCallBack));
                return;
            }
        }
        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_TimeScan(Action doneCallBack)
        {
            var width         = _RECT_Canvas.rect.size.x;
            var height        = _RECT_Canvas.rect.size.y;
            var lazerPosition = _RECT_Lazer.anchoredPosition;

            _RECT_Lazer.sizeDelta = new Vector2(width, _RECT_Lazer.sizeDelta.y);

            while (_RECT_Lazer.anchoredPosition.y > -1 * height / 2f )
            {
                Debug.DrawRay(_RECT_Lazer.position, _RECT_Lazer.forward * 100f, Color.red);

                lazerPosition.y      -= _speedValue;

                _RECT_Lazer.anchoredPosition = lazerPosition;
                yield return null;
            }

            doneCallBack?.Invoke();
            _co_TimeScan = null;
        }
    }
}