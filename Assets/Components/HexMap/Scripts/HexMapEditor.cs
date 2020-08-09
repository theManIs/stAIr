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

        private Color _activeColor;

        #endregion


        #region UnityMethods

        void Awake() => SelectColor(DefaultIndexColor);

        void Update() => HandleInputWithLocker();

        #endregion


        #region Methods

        void HandleInput()
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit))
            {
                HexGrid.TouchCell(hit.point);
                HexGrid.ColorCell(hit.point, _activeColor);
            }
        }

        protected void HandleInputWithLocker()
        {
            if (Input.GetMouseButton(0) && MouseClickBlock < 0)
            {
                HandleInput();

                MouseClickBlock = InitMouseClickBlock;
            }

            MouseClickBlock--;
        }

        public void SelectColor(int index)
        {
            _activeColor = Colors[index];
        } 

        #endregion
    }
}