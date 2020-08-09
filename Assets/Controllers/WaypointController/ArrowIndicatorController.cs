using Assets.Components.ArrowWaypointer.Scripts;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Controllers.WaypointController
{
    public class ArrowIndicatorController : MonoBehaviour
    {
        public WaypointArrow WaypointArrow;
        public HexGrid HexGrid;

        private Vector3 _lastPick;

        protected void Update()
        {
            if (HexGrid.LastPick != _lastPick)
            {
                _lastPick = HexGrid.LastPick;

                WaypointArrow.SetDesiredPosition(HexGrid.LastPick);
            }
        }

        private void OnEnable()
        {
            WaypointArrow.EReleaseDestination += DReleaseDestination;
        }

        private void DReleaseDestination(Vector3 destinationToRelease)
        {
            HexGrid.ReleaseColorCell(destinationToRelease);
        }
    }
}