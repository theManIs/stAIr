using System.Collections.Generic;
using Assets.Components.ArrowWaypointer.Scripts;
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

        private Vector3 _lastPick = default;
        private GameObject _goTrial;
        private Queue<Vector3> _pointerRoadmap = new Queue<Vector3>();
        private Vector3 _nextTrailPoint;

        #endregion


        #region UnityMethods

//        protected void Start()
//        {
//            if (PrefabWaypointer)
//            {
//                WaypointArrow.InstantiateWaypointer(PrefabWaypointer);
//            }
//        }

        protected void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                WaypointArrow = TurnShifterController.GetHighlighted();

                if (WaypointArrow)
                {
                    AttachDetachCellRelease();

                    if (TurnShifterController.HasSelectionBefore)
                    {
                        HexEditor.HandleInput();
                    }

                    if (HexGrid.LastPick != _lastPick)
                    {
                        _lastPick = HexGrid.LastPick;

                        WaypointArrow.SetDesiredPosition(HexGrid.LastPick);
                        /*CreateTrialRenderer(); todo*/
                    }
                    else
                    {
                        WaypointArrow.GoTrue();

                        /*Destroy(_goTrial); todo*/
                    }
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

            
            /*if (_goTrial && ((_nextTrailPoint - _goTrial.transform.position).sqrMagnitude < 1 || _nextTrailPoint == default))
            {
                ChangeNextPoint();
            }


            if (_nextTrailPoint != default && _goTrial)
            {
                MoveToNextPoint();
            } todo*/
        }

//        protected void OnEnable()
//        {
//            WaypointArrow.EReleaseDestination += DReleaseDestination;
//        }
//
//        protected void OnDisable()
//        {
//            WaypointArrow.EReleaseDestination -= DReleaseDestination;
//        }

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

        protected void CreateTrialRenderer()
        {
            if (_goTrial)
            {
                Destroy(_goTrial);
            }

            _goTrial = new GameObject("TrialRenderer");
            _goTrial.transform.position = WaypointArrow.transform.position;
            TrailRenderer tr = _goTrial.AddComponent<TrailRenderer>();
            tr.autodestruct = false;
            tr.time = int.MaxValue;

            _pointerRoadmap = new Queue<Vector3>(WaypointArrow.GetMovementQueue());
        }

        protected void MoveToNextPoint()
        {
            _goTrial.transform.position = Vector3.Lerp(_goTrial.transform.position, _nextTrailPoint, Time.deltaTime * 3);
        }

        protected void ChangeNextPoint()
        {
            _nextTrailPoint = _pointerRoadmap.Count > 0 ? _pointerRoadmap.Dequeue() : _nextTrailPoint;
            _nextTrailPoint.y = 0.2f;
        }

        #endregion
    }
}