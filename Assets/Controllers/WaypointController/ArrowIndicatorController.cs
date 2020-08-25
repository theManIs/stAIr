using System.Collections.Generic;
using Assets.Components.ArrowWaypointer.Scripts;
using Assets.Components.FindRoute.Scripts;
using Assets.Components.HexMap.Scripts;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Controllers.WaypointController
{
    public class ArrowIndicatorController : MonoBehaviour
    {
        #region Fields

        public WaypointArrow WaypointArrow;
        public HexGrid HexGrid;
        public HexMapEditor HexEditor;
        public TurnShifterController.TurnShifterController TurnShifterController;
        public FindRouteController FindRouteController;

        private Vector3 _lastPick = default;
        private GameObject _goTrial;
        private Queue<Vector3> _pointerRoadmap = new Queue<Vector3>();
        private Vector3 _nextTrailPoint;
        private List<Vector3> _lastCells = new List<Vector3>();
        private bool _goMode;

        #endregion


        #region UnityMethods

        protected void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_goMode)
            {
                WaypointArrow = TurnShifterController.GetHighlighted();

                if (WaypointArrow)
                {
                    AttachDetachCellRelease();

                    Vector3[] newPositioning = FindRouteController.GetRoute(_lastPick);

                    if (TurnShifterController.HasSelectionBefore)
                    {
                        HexEditor.ColorRange(newPositioning);
                        HexEditor.HandleInput();
                    }

                    if (HexGrid.LastPick != _lastPick)
                    {
                        _lastPick = HexGrid.LastPick;

//                        WaypointArrow.SetDesiredPosition(HexGrid.LastPick);
                        WaypointArrow.SetQueuePositions(newPositioning);
                    }
                    else
                    {
                        WaypointArrow.GoTrue();

                        HexEditor.ClearRange();

                        _goMode = true;
                    }
                }
                else
                {
                    TurnShifterController.HasSelectionBefore = false;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (WaypointArrow)
                {
                    WaypointArrow.DClearDestination();

                    TurnShifterController.LastPickedWaypointArrow = null;
                }
            }

            if (WaypointArrow && WaypointArrow.GetMovementQueue().Count == 0)
            {
                _goMode = false;
            }
        }
        #endregion


        #region Methods

        protected void AttachDetachCellRelease()
        {
            foreach (WaypointArrow waypointArrow in TurnShifterController.TurnShift)
            {
                waypointArrow.EReleaseDestination -= DReleaseDestination;
                waypointArrow.EReleaseDestination += DReleaseDestination;
            }
        }

        protected void DReleaseDestination(Vector3 destinationToRelease)
        {
//            Debug.Log(destinationToRelease.z.Equals(_lastPick.z) + " " +  destinationToRelease.x.Equals(_lastPick.x));
            if (destinationToRelease.z.Equals(_lastPick.z) && destinationToRelease.x.Equals(_lastPick.x))
            {
                HexEditor._lastHit = default;
            }

            HexGrid.ReleaseColorCell(destinationToRelease);
        }

       
        #endregion
    }
}