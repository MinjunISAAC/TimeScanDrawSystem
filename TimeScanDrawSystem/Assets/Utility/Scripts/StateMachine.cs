// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.SimpleFSM;

namespace Game.ForState
{
    public class StateMachine : SimpleStateMachine<EStateType>
    {
        // --------------------------------------------------
        // Singleton
        // --------------------------------------------------
        // ----- Constructor
        private StateMachine() { }

        // ----- Static Variables
        private static StateMachine _instance = null;

        // ----- Property
        public static StateMachine Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new StateMachine();
                    _instance._InitSingleton();
                }

                return _instance;
            }
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        private class CoroutineExecoutor : MonoBehaviour { }
        private void _InitSingleton()
        {
            if (null == _coroutineExecutor)
            {
                GameObject executorGameObject = new GameObject("CoroutineExecutor");

                _coroutineExecutor = executorGameObject.AddComponent<CoroutineExecoutor>();
                if (null == _coroutineExecutor)
                {
                    Debug.LogError("[StateMachine._InitSingleton] Coroutine �����ڰ� �������� �ʾҽ��ϴ�.");
                    return;
                }
                UnityEngine.Object.DontDestroyOnLoad(executorGameObject);
            }

            OnInit
            (
                new Dictionary<EStateType, SimpleState<EStateType>>()
                {
                    /*
                    Ư�� State Class(SimpleState Class) ���� �ʿ�
                    { EStateType.Ready, new State_Ready() },
                    { EStateType.Play,  new State_Play()  },
                    { EStateType.End,   new State_End()   },
                    */
                },
                _coroutineExecutor,
                null
            );
        }
    }
}