using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Components.FindRoute.Scripts
{
    public class FindRoute
    {

        public GameObject[] HexGrid;
        public int HexWidth;
        public Transform HostObject;

//        [SerializeField] private int _startCell;

        private List<Vector3> _routePosition = new List<Vector3>();

        public  int _currentIndex;

//        private void Start()
//        {
//            _currentIndex = _startCell;
//        }

        public List<Vector3> RoutePositions(Vector3 startPoint)
        {
            _currentIndex = HexCoordinates.FromPosition(startPoint).ToIndexIfWith(HexWidth);

            UpdateOnRequest();

            return _routePosition;
        }

        private void UpdateOnRequest()
        {
            int index = FindTouch();

            if (index != _currentIndex)
            {
                FindingRoute(index);
            }
        }

        private void FindingRoute(int index) 
        {
            _routePosition.Clear();

            int currentLine = Convert.ToInt32(_currentIndex / HexWidth);
            int nextLine = Convert.ToInt32(index / HexWidth);

            while (_currentIndex != index)
            {
                bool hasLineChanged = false;
                int currentOrdinalHex = _currentIndex - currentLine * HexWidth;
                int targetOrdinalHex = index - nextLine * HexWidth;

                if (nextLine > currentLine)
                {
                    currentLine++;
                    _currentIndex += HexWidth;
                    hasLineChanged = true;
                }
                else if (currentLine > nextLine)
                {
                    currentLine--;
                    _currentIndex -= HexWidth;
                    hasLineChanged = true;
                }

                if (targetOrdinalHex > currentOrdinalHex)
                {
                    if (!hasLineChanged || currentLine % 2 == 0)
                    {
                        _currentIndex++;
                    }
                }
                else if (currentOrdinalHex > targetOrdinalHex)
                {
                    if (!hasLineChanged || currentLine % 2 == 1)
                    {
                        _currentIndex--;
                    }
                }

                _routePosition.Add(HexGrid[_currentIndex].transform.position);
            }

            _currentIndex = index;
        }

        private int FindTouch()
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit))
            {
                Vector3 position = hit.point;
                
                position = HostObject.InverseTransformPoint(position);
                
                HexCoordinates coordinates = HexCoordinates.FromPosition(position);

                return coordinates.X + coordinates.Z * HexWidth + coordinates.Z / 2;
            }
            else
            {
                return -1;
            }
        }
    }
}
