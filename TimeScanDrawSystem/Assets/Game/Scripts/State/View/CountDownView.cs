// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using TMPro;

// ----- User Defined
using InGame.ForState.ForUI;

public class CountDownView : StateView
{
    // --------------------------------------------------
    // Components
    // --------------------------------------------------
    [SerializeField] private TextMeshProUGUI _TMP_Count = null;
    [SerializeField] private Animation       _animation = null;

    // --------------------------------------------------
    // Variables
    // --------------------------------------------------
    private Coroutine _co_CountDown = null;

    // --------------------------------------------------
    // Functions - Nomal
    // --------------------------------------------------
    public void CountDown(int countValue, Action doneCallBack) 
    {
        if (_co_CountDown == null)
            _co_CountDown = StartCoroutine(_Co_CountDown(countValue, doneCallBack));
    }

    // --------------------------------------------------
    // Functions - Coroutine
    // --------------------------------------------------
    private IEnumerator _Co_CountDown(int countValue, Action doneCallBack)
    {
        int count = countValue;

        for (int i = 0; i < count; i++)
        {
            Debug.Log($"왜 안되니? {count}");
            
            _TMP_Count.text = $"{count - i}";
            _animation.Play();

            yield return new WaitForSeconds(1f);
        }

        doneCallBack?.Invoke();
        _co_CountDown = null;
    }
}