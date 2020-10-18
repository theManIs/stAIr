using UnityEngine;

namespace Assets.Components.HommCamera.Scripts
{
    public class HommTopdownCamers : MonoBehaviour
    {
        public PositioningVector[] PositioningVector = new PositioningVector[1];
        public Camera AttachedCamera;
        public float CameraAcceleration = 1f;
        public int ActiveCameraState = 0;
        public bool CanMove = true;

        private Vector3 _desiredVector3 = Vector3.zero;


        // Start is called before the first frame update
        void Start()
        {
            _desiredVector3 = AttachedCamera.transform.position;
            _desiredVector3.x = PositioningVector[ActiveCameraState].TransformX;
            _desiredVector3.y = PositioningVector[ActiveCameraState].TransformY;
            _desiredVector3.z = PositioningVector[ActiveCameraState].TransformZ;
            AttachedCamera.transform.position = _desiredVector3;
        }

        // Update is called once per frame
        void Update()
        {
            if (CanMove &&  AttachedCamera)
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                PositioningVector pv = PositioningVector[ActiveCameraState];

                if (!h.Equals(0.0f) || !v.Equals(0.0f))
                {
                    _desiredVector3 += (Vector3.forward * v + Vector3.right * h);
                    _desiredVector3.x = Mathf.Clamp(_desiredVector3.x, pv.ClampMinX, pv.ClampMaxX);
                    _desiredVector3.y = Mathf.Clamp(_desiredVector3.y, pv.ClampMinY, pv.ClampMaxY);
                    _desiredVector3.z = Mathf.Clamp(_desiredVector3.z, pv.ClampMinZ, pv.ClampMaxZ);

                    AttachedCamera.transform.position = 
                        Vector3.Lerp(AttachedCamera.transform.position, _desiredVector3, Time.deltaTime * CameraAcceleration);
                }
            }
            
        }
    }
}
