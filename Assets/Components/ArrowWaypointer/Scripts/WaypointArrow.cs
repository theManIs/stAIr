using Assets.Scripts;
using UnityEngine;

namespace Assets.Components.Arrow_WayPointer
{
    public class WaypointArrow : MonoBehaviour
    {
        public Vector3 DesiredPosition;

        public void SetDesiredPosition(Vector3 newPos)
        {
            newPos.y = transform.position.y;
            DesiredPosition = newPos;
        }

        protected void Update()
        {
            MoveIfDidNotGetDestination();
        }

        protected void MoveIfDidNotGetDestination()
        {
            if (transform.position != DesiredPosition && DesiredPosition != default)
            {
                transform.position = Vector3.Lerp(transform.position, DesiredPosition, Time.deltaTime);
            }
        }
    }
}
