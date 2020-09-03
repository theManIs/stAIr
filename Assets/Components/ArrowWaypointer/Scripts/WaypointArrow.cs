using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Components.ArrowWaypointer.Scripts
{
    public class WaypointArrow : MonoBehaviour
    {
        #region Fields

        public event Action<Vector3> EReleaseDestination;

        public Vector3 DesiredPosition;
        public int MarkerSpeed = 1000;
        public int CloseRange = 10;
        public const int SpeedDivider = 1000;
        public Transform PlacePointer;
        public GameObject PrefabWaypointer;

        private readonly Queue<Vector3> _pointerRoadmap = new Queue<Vector3>();
        private float _timeProgress = 0;
        private bool _go = false;

        #endregion


        #region UnityMethods

        protected void Start()
        {
            if (PrefabWaypointer)
            {
                InstantiateWaypointer(PrefabWaypointer);
            }
        }

        protected void Update() => MoveIfDidNotGetDestination();

        #endregion


        #region Methods

        public Queue<Vector3> GetMovementQueue() => _pointerRoadmap;
        public void ClearMovementQueue() => _pointerRoadmap.Clear();

        public void InstantiateWaypointer(GameObject prefabWaypointer) =>
            Instantiate(prefabWaypointer, PlacePointer.transform, false);

        public void DClearDestination()
        {
//            Queue<Vector3> localRoadMap = new Queue<Vector3>(_pointerRoadmap);
            int queueCount = _pointerRoadmap.Count;
//            _pointerRoadmap.Clear();

            for (int i = 0; i < queueCount; i++)
            {
                EReleaseDestination?.Invoke(_pointerRoadmap.Dequeue());
            }

//            while (localRoadMap.Count > 0)
//            {
//                EReleaseDestination?.Invoke(localRoadMap.Dequeue());
//            }
        }

        public void GoTrue()
        {
            _go = true;
        }

        public void SetDesiredPosition(Vector3 newPos)
        {
            newPos.y = transform.position.y;

            _pointerRoadmap.Enqueue(newPos);
        }

        public void SetQueuePositions(Vector3[] queueOfPositions)
        {
            foreach (Vector3 queueOfPosition in queueOfPositions)
            {
                SetDesiredPosition(queueOfPosition);
            }
        }

        protected void MoveIfDidNotGetDestination()
        {
            if (!HasReachedDestination() && HasDestination() && _go)
            {
                MoveToDesignatedPosition();
            }
            else if (HasDestination() && _go)
            {
                ReleaseDestination();
            }
            else if (!HasDestination() && HasItemsInQueue() && _go)
            {
                DequeuePosition();
            }
            else
            {
                _go = false;
            }
        }

        protected void MoveToDesignatedPosition()
        {
            transform.position = Vector3.Lerp(transform.position, DesiredPosition, (Time.deltaTime + _timeProgress) / SpeedDivider * MarkerSpeed);
            _timeProgress += Time.deltaTime;
        }

        protected void ReleaseDestination()
        {
            EReleaseDestination?.Invoke(DesiredPosition);

            DesiredPosition = default;
            _timeProgress = 0;
        }

        protected bool HasDestination() => DesiredPosition != default;

        protected bool HasReachedDestination() => (DesiredPosition - transform.position).sqrMagnitude < CloseRange;

        protected bool HasItemsInQueue() => _pointerRoadmap.Count > 0;

        protected void DequeuePosition() => DesiredPosition = _pointerRoadmap.Dequeue(); 

        #endregion
    }
}
