using Assets.Components.ArrowWaypointer.Scripts;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Controllers.WaypointController
{
    public class ArrowIndicatorController : MonoBehaviour
    {
        #region Fields

        public WaypointArrow WaypointArrow;
        public HexGrid HexGrid;
        public GameObject PrefabWaypointer;

        private Vector3 _lastPick; 

        #endregion


        #region UnityMethods

        protected void Start()
        {
            if (PrefabWaypointer)
            {
                WaypointArrow.InstantiateWaypointer(PrefabWaypointer);
            }
        }

        protected void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (HexGrid.LastPick != _lastPick)
                {
                    _lastPick = HexGrid.LastPick;

                    WaypointArrow.SetDesiredPosition(HexGrid.LastPick);
                }
                else
                {
                    WaypointArrow.GoTrue();
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                WaypointArrow.DClearDestination();
            }
        }

        protected void OnEnable()
        {
            WaypointArrow.EReleaseDestination += DReleaseDestination;
        }

        protected void OnDisable()
        {
            WaypointArrow.EReleaseDestination -= DReleaseDestination;
        }

        #endregion


        #region Methods

        protected void DReleaseDestination(Vector3 destinationToRelease)
        {
            HexGrid.ReleaseColorCell(destinationToRelease);
        } 

        #endregion
    }
}