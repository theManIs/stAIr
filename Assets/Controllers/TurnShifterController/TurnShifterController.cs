using Assets.Components.ArrowWaypointer.Scripts;
using UnityEngine;

namespace Assets.Controllers.TurnShifterController
{
    public class TurnShifterController : MonoBehaviour
    {
        public WaypointArrow[] TurnShift = new WaypointArrow[0];
        public bool HasSelectionBefore = false;
        public WaypointArrow LastPickedWaypointArrow;

        public WaypointArrow GetHighlighted()
        {
            if (TurnShift.Length > 0)
            {
                for (int i = 0; i < TurnShift.Length; i++)
                {
                    SpriteOutline so = TurnShift[i].GetComponentInChildren<SpriteOutline>();

                    if (so.IsSelected)
                    {
                        HasSelectionBefore = LastPickedWaypointArrow == TurnShift[i];
                        LastPickedWaypointArrow = TurnShift[i];

                        return TurnShift[i];
                    }
                }
            }

            return null;
        }
    }
}
