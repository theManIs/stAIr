using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Components.ArrowWaypointer.Scripts
{
    public class WaypointArrow : MonoBehaviour
    {
        public event Action<Vector3> EReleaseDestination;   

        public Vector3 DesiredPosition;
        public int MarkerSpeed = 1000;
        public int CloseRange = 10;
        public const int SpeedDivider = 1000;

        private readonly Queue<Vector3> _pointerRoadmap = new Queue<Vector3>();
        private float _timeProgress = 0;

        public void SetDesiredPosition(Vector3 newPos)
        {
            newPos.y = transform.position.y;

            _pointerRoadmap.Enqueue(newPos);
        }

        protected void Update()
        {
            MoveIfDidNotGetDestination();
        }

        protected void MoveIfDidNotGetDestination()
        {
            if (!HasReachedDestination() && HasDestination())
            {
                MoveToDesignatedPosition();
            }
            else if (HasDestination())
            {
                ReleaseDestination();
            } 
            else if (!HasDestination() && HasItemsInQueue())
            {
                DequeuePosition();
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
    }
}
