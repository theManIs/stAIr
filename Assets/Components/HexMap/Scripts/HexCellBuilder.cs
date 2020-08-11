using Assets.Components.HexMap.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class HexCellBuilder
    {
        public static HexCell BuildOne(HexCell hexCellPrototype, Vector3 position, Transform parentTransform, int cellColumn, int cellRow, Color defaultColor)
        {
            HexCell cell = Object.Instantiate<HexCell>(hexCellPrototype);
            cell.transform.SetParent(parentTransform, false);
            cell.transform.localPosition = position;
            cell.HexCoordinates = HexCoordinates.FromOffsetCoordinates(cellColumn, cellRow);
            cell.HexCoordinates.SetWorldPosition(position.x, position.z);
            cell.Color = PickRandomColor(defaultColor);

            return cell;
        }

        public static Color PickRandomColor(Color defaultColor)
        {
            Color changedColor = defaultColor;

            if (Object.FindObjectOfType<HexMapEditor>())
            {
                Color[] colorInUse = Object.FindObjectOfType<HexMapEditor>().Colors;
                changedColor = colorInUse[Mathf.RoundToInt(Random.Range(0, 3))];
            }

            return changedColor;
        }
    }
}