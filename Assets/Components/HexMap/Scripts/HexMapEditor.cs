using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Components.HexMap.Scripts
{
    public class HexMapEditor : MonoBehaviour
    {
        #region Fields
 
        public Color[] Colors;
        public int DefaultIndexColor;
        public HexGrid HexGrid;
        public int DefaultSecondIndexColor = 0;
        public int TheThirdColorIndex = 5;

        private Color _activeColor;
        private Color _secondColor;
        private Color _thirdColor;
        public Vector3 _lastHit = default;
        private List<Vector3> _lastCells = new List<Vector3>();

        #endregion


        #region UnityMethods

        void Awake()
        {
            _activeColor = Colors[DefaultIndexColor];
            _secondColor = Colors[DefaultSecondIndexColor];
            _thirdColor = Colors[TheThirdColorIndex];
        }

        #endregion


        #region Methods

//        public void HandleInput(Vector3 lastPick)
//        {
//            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;
//
//            if (Physics.Raycast(inputRay, out hit))
//            {
//                HexGrid.TouchCell(hit.point);
//                HexGrid.ColorCell(hit.point, _activeColor);
//
//                Debug.Log(lastPick + " " + HexGrid.LastPick);
//                if (lastPick != default && lastPick != HexGrid.LastPick)
//                {
//                    HexGrid.ColorCell(lastPick, _secondColor);
//                }
//
////                _lastHit = HexGrid.LastPick;
//            }
//        }

        public Vector3 TouchingCell()
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit))
            {
                HexGrid.TouchCell(hit.point);

                return hit.point;
            }

            return default;
        }

        public void ColorTargetActive()
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit))
            {
//                HexGrid.TouchCell(hit.point);
                HexGrid.ColorCell(hit.point, _activeColor);
            }
        }

        public void ColorTargetSecond(Vector3 target)
        {
            HexGrid.ColorCell(target, _secondColor);
        }

        public void ColorRange(Vector3[] newPositioning)
        {
            _lastCells.AddRange(newPositioning);

            foreach (var cell in _lastCells)
            {
                HexGrid.ColorCell(cell, _thirdColor);
            }
        }

        public void ClearRange()
        {
            _lastCells.Clear();
        }

//        public void HandleInputHide(Vector3 hiddenHexCell)
//        {
//            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;
//
//            if (Physics.Raycast(inputRay, out hit))
//            {
//                HexGrid.TouchCell(hit.point);
//
//                if (!(hiddenHexCell.x.Equals(HexGrid.LastPick.x) && hiddenHexCell.z.Equals(HexGrid.LastPick.z)))
//                {
////                    Debug.Log(hiddenHexCell.x.Equals(HexGrid.LastPick.x) + $" {hiddenHexCell.x} {HexGrid.LastPick.x}");
////                    Debug.Log(hiddenHexCell.z.Equals(HexGrid.LastPick.z) + $" {hiddenHexCell.z} {HexGrid.LastPick.z}");
////                    Debug.Log(hiddenHexCell + " " + HexGrid.LastPick);
////                    Debug.Log(_secondColor);
//
//                    HexGrid.ColorCell(hit.point, _activeColor);
//
//                    if (_lastHit != default && _lastHit != HexGrid.LastPick)
//                    {
//                        HexGrid.ColorCell(_lastHit, _secondColor);
//                    }
//                }
//
//                _lastHit = HexGrid.LastPick;
//            }
//        }

        #endregion
    }
}