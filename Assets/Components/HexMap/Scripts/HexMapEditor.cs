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
        public int InitMouseClickBlock = 25;
        public int MouseClickBlock = 0;
        public int DefaultSecondIndexColor = 0;

        private Color _activeColor;
        private Color _secondColor;
        public Vector3 _lastHit = default;

        #endregion


        #region UnityMethods

        void Awake()
        {
            SelectColor(DefaultIndexColor);

            _secondColor = Colors[DefaultSecondIndexColor];
        }

        void Update() => HandleInputWithLocker();

        #endregion


        #region Methods

        public void HandleInput()
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit))
            {
                HexGrid.TouchCell(hit.point);
                HexGrid.ColorCell(hit.point, _activeColor);


                if (_lastHit != default && _lastHit != HexGrid.LastPick)
                {
                    HexGrid.ColorCell(_lastHit, _secondColor);
                }

                _lastHit = HexGrid.LastPick;
            }
        }

        public void HandleInputHide(Vector3 hiddenHexCell)
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit))
            {
                HexGrid.TouchCell(hit.point);

                if (!(hiddenHexCell.x.Equals(HexGrid.LastPick.x) && hiddenHexCell.z.Equals(HexGrid.LastPick.z)))
                {
                    Debug.Log(hiddenHexCell.x.Equals(HexGrid.LastPick.x) + $" {hiddenHexCell.x} {HexGrid.LastPick.x}");
                    Debug.Log(hiddenHexCell.z.Equals(HexGrid.LastPick.z) + $" {hiddenHexCell.z} {HexGrid.LastPick.z}");
                    Debug.Log(hiddenHexCell + " " + HexGrid.LastPick);
                    Debug.Log(_secondColor);

                    HexGrid.ColorCell(hit.point, _activeColor);

                    if (_lastHit != default && _lastHit != HexGrid.LastPick)
                    {
                        HexGrid.ColorCell(_lastHit, _secondColor);
                    }
                }

                _lastHit = HexGrid.LastPick;
            }
        }

        protected void HandleInputWithLocker()
        {
//            if (Input.GetMouseButton(0) && MouseClickBlock < 0)
//            {
//                HandleInput();
//
//                MouseClickBlock = InitMouseClickBlock;
//            }
//
//            MouseClickBlock--;
        }

        public void SelectColor(int index)
        {
            _activeColor = Colors[index];
        } 

        #endregion
    }
}