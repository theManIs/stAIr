using System;
using Assets.Components.ArrowWaypointer.Scripts;
using Assets.Components.Level2.TurnShifter.Scripts;
using UnityEngine;

namespace Assets.Controllers.TurnShifterController
{
    public class TurnShifterController : MonoBehaviour
    {
        public event Action<WaypointArrow, WaypointArrow> SelectionChanged;

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

//                    Debug.Log(so.transform.position + " " + so.IsSelected + " " + nameof(TurnShifterController) + "23");

                    if (so.IsSelected)
                    {
                        HasSelectionBefore = LastPickedWaypointArrow == TurnShift[i];

                        if (!HasSelectionBefore)
                        {
                            SelectionChanged?.Invoke(LastPickedWaypointArrow, TurnShift[i]);
                        }

                        LastPickedWaypointArrow = TurnShift[i];

                        return TurnShift[i];
                    }
                }

                if (LastPickedWaypointArrow != default)
                {
                    SelectionChanged?.Invoke(LastPickedWaypointArrow, null);
                }
            }

            LastPickedWaypointArrow = default;
            HasSelectionBefore = false;

            return null;
        }

        public void SetBlockSelection(bool blockSelection)
        {
            if (TurnShift.Length > 0)
            {
                for (int i = 0; i < TurnShift.Length; i++)
                {
                    SpriteOutline so = TurnShift[i].GetComponentInChildren<SpriteOutline>();

                    if (so)
                    {
                        so.SelectBlock = blockSelection;
                    }
                }
            }
        }

        protected void Update()
        {
            GetHighlighted();
        }
    }
}
