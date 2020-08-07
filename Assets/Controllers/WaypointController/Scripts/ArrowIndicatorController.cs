using Assets.Components.Arrow_WayPointer;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Controllers.WaypointController.Scripts
{
    public class ArrowIndicatorController : MonoBehaviour
    {
        public WaypointArrow WaypointArrow;
        public HexGrid HexGrid;

        protected void Update()
        {
            WaypointArrow.SetDesiredPosition(HexGrid.LastPick);
        }
    }
}