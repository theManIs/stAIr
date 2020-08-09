using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HexGrid : MonoBehaviour
    {
        public int Width = 6;
        public int Height = 6;

        public HexCell HexCell;
        public Canvas GlobalCanvas;
        public Text CellLabel;

        public Color DefaultColor = Color.white;
        public Color TouchedColor = Color.magenta;

        public Vector3 LastPick = Vector3.zero;

        public float HexXShift (float x, float z) => (x + z * 0.5f - (int)(z / 2)) * HexMetrics.InnerRadius * 2f;
        public float HexZShift () => HexMetrics.OuterRadius * 1.5f;

        public HexCell[] HexCells;

        protected HexMesh HexMesh;
//        protected int MouseClickBlock = 0;
//        protected int InitMouseClickBlock = 25;

        void Awake()
        {
            HexCells = new HexCell[Height * Width];

            for (int z = 0, i = 0; z < Height; z++)
            {
                for (int x = 0; x < Width; x++)
                {
                    CreateCell(x, z, i++);
                }
            }

            HexMesh = GetComponentInChildren<HexMesh>();
        }

        protected void Start()
        {
            HexMesh.Triangulate(HexCells);
        }


        void CreateCell(int x, int z, int i)
        {
            Vector3 position;
            position.x = HexXShift(x, z);
            position.y = 0f;
            position.z = z * HexZShift();

            HexCell cell = HexCells[i] = HexCellBuilder.BuildOne(HexCell, position, transform, x, z, DefaultColor);
//            HexCell cell = HexCells[i] = Instantiate<HexCell>(HexCell);
//            cell.transform.SetParent(transform, false);
//            cell.transform.localPosition = position;
//            cell.HexCoordinates = HexCoordinates.FromOffsetCoordinates(x, z);
//            cell.HexCoordinates.SetWorldPosition(position.x, position.z);
//            cell.Color = DefaultColor;

            CreateLabel(cell);
        }

        protected void CreateLabel(HexCell hexCell)
        {
            Text label = Instantiate<Text>(CellLabel);
            label.rectTransform.SetParent(GlobalCanvas.transform, false);
            label.rectTransform.anchoredPosition = new Vector2(hexCell.HexCoordinates.PosX, hexCell.HexCoordinates.PosZ);
            label.text = hexCell.HexCoordinates.ToStringOnSeparateLines();
        }

//        void Update()
//        {
//            if (Input.GetMouseButton(0) && MouseClickBlock < 0)
//            {
//                HandleInput();
//
//                MouseClickBlock = InitMouseClickBlock;
//            }
//
//            MouseClickBlock--;
//        }

//        void HandleInput()
//        {
//            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;
//
//            if (Physics.Raycast(inputRay, out hit))
//            {
//                TouchCell(hit.point);
//            }
//        }

        public void TouchCell(Vector3 position)
        {
            position = transform.InverseTransformPoint(position);
            HexCoordinates coordinates = HexCoordinates.FromPosition(position);
            int index = coordinates.X + coordinates.Z * Width + coordinates.Z / 2;
            HexCell cell = HexCells[index];

            LastPick.z = cell.HexCoordinates.PosZ;
            LastPick.x = cell.HexCoordinates.PosX;
        }

        public void ColorCell(Vector3 position, Color color)
        {
            position = transform.InverseTransformPoint(position);
            HexCoordinates coordinates = HexCoordinates.FromPosition(position);
            int index = coordinates.X + coordinates.Z * Width + coordinates.Z / 2;
            HexCell cell = HexCells[index];
            cell.Color = color;
            HexMesh.Triangulate(HexCells);
        }

        public void ReleaseColorCell(Vector3 position)
        {
            position = transform.InverseTransformPoint(position);
            HexCoordinates coordinates = HexCoordinates.FromPosition(position);
            int index = coordinates.X + coordinates.Z * Width + coordinates.Z / 2;
            HexCell cell = HexCells[index];
            cell.Color = cell.DefaultColor;
            HexMesh.Triangulate(HexCells);
        }
    }
}
