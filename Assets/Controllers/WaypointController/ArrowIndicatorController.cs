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

        public HexGrid HexGrid;
        public HexMapEditor HexEditor;
        public TurnShifterController.TurnShifterController TurnShifterController;
        public FindRouteController FindRouteController;

        private Vector3 _currentPick = Vector3.back;
        private Vector3 _lastPick = Vector3.back;
        private GameObject _goTrial;
        private Queue<Vector3> _pointerRoadmap = new Queue<Vector3>();
        private Vector3 _nextTrailPoint;
        private List<Vector3> _lastCells = new List<Vector3>();
        private bool _goMode;
        private bool _wasSelectedThisFrame = false;
        private bool _startProcessing;
        private WaypointArrow _waypointArrow = null;

        #endregion


        #region UnityMethods

        protected void OnEnable()
        {
            TurnShifterController.SelectionChanged += SelectionChanged;
        }

        private void SelectionChanged(WaypointArrow oldSelection, WaypointArrow newSelection)
        {
            if (!newSelection && oldSelection)
            {
//                if (!_goMode)
//                {
                    oldSelection.DClearDestination();

                    oldSelection.EReleaseDestination -= DReleaseDestination;

                    HexEditor.ClearRange();

                    _waypointArrow = null;
                    _currentPick = Vector3.back;
                    _lastPick = Vector3.back;

//                    Debug.Log("Deselect any object");
//                }
            } 
            else if (oldSelection && newSelection)
            {
//                if (!_goMode)
//                {
                    oldSelection.DClearDestination();
//                    newSelection.DClearDestination();

                    oldSelection.EReleaseDestination -= DReleaseDestination;
//                    newSelection.EReleaseDestination -= DReleaseDestination;

                    HexEditor.ClearRange();

                    _waypointArrow = newSelection;
                    _currentPick = Vector3.back;
                    _lastPick = Vector3.back;

                    newSelection.EReleaseDestination += DReleaseDestination;

//                    Debug.Log("Selection shifts");
//                }
            }
            else if (!oldSelection && newSelection)
            {
                _waypointArrow = newSelection;

                newSelection.EReleaseDestination += DReleaseDestination;

//                Debug.Log("A brand new selection " + _wasSelectedThisFrame + " " + Time.time);
            }

            /*if (oldSelection)
            {
                oldSelection.DClearDestination();
                oldSelection.ClearMovementQueue();
            }*/
        }

        protected void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                UserUpdate();
            }

            if (_waypointArrow && _waypointArrow.GetMovementQueue().Count == 0)
            {
                _goMode = false;

                TurnShifterController.SetBlockSelection(_goMode);
            }

        }

        #endregion


        #region Methods

        protected void UserUpdate()
        {
            if (!_goMode)
            {
                if (_waypointArrow != null)
                {
                    _currentPick = _currentPick != Vector3.back ? _currentPick : _waypointArrow.transform.position;
                    Vector3[] newPositioning = FindRouteController.GetRoute(_currentPick);

                    HexEditor.TouchingCell();

                    if (HexGrid.LastPick != _currentPick)
                    {
                        _lastPick = _currentPick;
                        _currentPick = HexGrid.LastPick;

                        _waypointArrow.SetQueuePositions(newPositioning);
                        _waypointArrow.SetDesiredPosition(_currentPick);

                        ColorPath(newPositioning, _lastPick != _waypointArrow.transform.position ? _lastPick : Vector3.back);
                    }
                    else
                    {
                        _waypointArrow.GoTrue();

                        _goMode = true;
                        _currentPick = Vector3.back;

                        ClearColorPath();
                        TurnShifterController.SetBlockSelection(_goMode);
                    }
                }
            }
        }

        protected void ColorPath(Vector3[] pathVector3, Vector3 lastPick)
        {
            HexEditor.ColorTargetActive();
            HexEditor.ColorRange(pathVector3);

            if (lastPick != Vector3.back)
            {
                HexEditor.ColorTargetSecond(lastPick);
            }
        }

        protected void ClearColorPath()
        {
            HexEditor.ClearRange();
        }

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
//            Debug.Log("Manually clear destination " + Time.time);

//            Debug.Log(destinationToRelease.z.Equals(_lastPick.z) + " " +  destinationToRelease.x.Equals(_lastPick.x));
            if (destinationToRelease.z.Equals(_currentPick.z) && destinationToRelease.x.Equals(_currentPick.x))
            {
                HexEditor._lastHit = default;
            }

            HexGrid.ReleaseColorCell(destinationToRelease);
        }

       
        #endregion
    }
}