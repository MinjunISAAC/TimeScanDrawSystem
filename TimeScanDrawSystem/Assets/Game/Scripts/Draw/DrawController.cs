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
        [Header("Camera Group")]
        [SerializeField] private Camera _camera = null;
        
        [Header("Draw Infos")]
        [SerializeField] private List<DrawItemInfo> _drawInfos           = new List<DrawItemInfo>();
        [SerializeField] private Transform          _spawnPoint          = null;
        [SerializeField] private LayerMask          _drawItem_LayerMask  = -1;
        [SerializeField] private LayerMask          _movePanel_LayerMask = -1;

        [Header("ETC")]
        [SerializeField] private ParticleSystem _itemSmoke = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private EItemType _itemType     = EItemType.Unknown;
        private DrawItem  _drawItem     = null;

        private Vector3 _inputPrevVec  = Vector3.zero;
        private Vector3 _moveOffsetVec = Vector3.zero;
        private Vector3 _prevMovePos   = Vector3.zero;
        private Vector3 _currMovePos   = Vector3.zero;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Update()
        {
            _MoveDrawItem();
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void SeletedToDrawItem(EItemType itemType)
        {
            if (_itemType != EItemType.Unknown)
                return;

            _itemType = itemType;
        }

        public void ShowDrawItem()
        {
            DrawItem resultItem = null;

            for (int i = 0; i < _drawInfos.Count; i++)
            {
                var drawInfo = _drawInfos[i];
                if (drawInfo.ItemType == _itemType)
                {
                    resultItem = Instantiate(drawInfo.DrawItem, _spawnPoint.transform);
                    resultItem.transform.position = _spawnPoint.position;
                    break;
                }
            }

            if (resultItem == null)
                Debug.LogError($"<color=red>[DrawController.SelectedToDrawItem] 해당 아이템 타입을 가진 아이템이 존재하지 않습니다.</color>");

            _itemSmoke.transform.position = resultItem.transform.position;
            _itemSmoke.Play();
        }

        private void _MoveDrawItem()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(touchRay, out var touchPad, Mathf.Infinity, _movePanel_LayerMask))
                    _prevMovePos = touchPad.point;

                if (Physics.Raycast(touchRay, out touchPad, Mathf.Infinity, _drawItem_LayerMask))
                {
                    touchPad.transform.TryGetComponent<DrawItem>(out var targetItem);

                    _moveOffsetVec = targetItem.transform.position - _prevMovePos;
                    _drawItem = targetItem;
                }
            }

            if (Input.GetMouseButton(0))
            {
                var touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                Debug.DrawRay(touchRay.origin, touchRay.direction * 1000, Color.yellow);

                if (Physics.Raycast(touchRay, out var hit_plane, Mathf.Infinity, _movePanel_LayerMask))
                {
                    if (_drawItem != null)
                    {
                        if (_drawItem == null) return;

                        _currMovePos = hit_plane.point;

                        _drawItem.transform.position = _currMovePos + _moveOffsetVec;
                    }
                }
            }
        }
    }
}