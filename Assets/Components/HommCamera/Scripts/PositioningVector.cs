using System;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Assets.Components.HommCamera.Scripts
{
    [Serializable]
    public struct PositioningVector
    {
        public string LayoutDescription;
        public float TransformX;
        public float TransformY;
        public float TransformZ;
        public float RotationX;
        public float RotationY;
        public float RotationZ;
        public float ClampMinX;
        public float ClampMinY;
        public float ClampMinZ;
        public float ClampMaxX;
        public float ClampMaxY;
        public float ClampMaxZ;
    }
}