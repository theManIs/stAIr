using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class HexMesh : MonoBehaviour
    {
        public MeshFilter HexMeshFilter;
        public MeshRenderer HexMeshRenderer;
        public List<Vector3> HexVertices;
        public List<int> HexTriangles;
        public List<Color> HexColors;

        protected Mesh HexCellMesh;
        protected MeshCollider HexMeshCollider;

        void Awake()
        {
            HexMeshCollider = gameObject.AddComponent<MeshCollider>();
            HexMeshFilter.mesh = HexCellMesh = new Mesh();
            HexCellMesh.name = "HexMesh";
            HexVertices = new List<Vector3>();
            HexTriangles = new List<int>();
            HexColors = new List<Color>();
        }

        public void Triangulate(HexCell[] cells)
        {
            HexCellMesh.Clear();
            HexVertices.Clear();
            HexTriangles.Clear();
            HexColors.Clear();

            for (int i = 0; i < cells.Length; i++)
            {
                Triangulate(cells[i]);
            }
            HexCellMesh.vertices = HexVertices.ToArray();
            HexCellMesh.colors = HexColors.ToArray();
            HexCellMesh.triangles = HexTriangles.ToArray();
            HexCellMesh.RecalculateNormals();

            HexMeshCollider.sharedMesh = HexCellMesh;
        }

        void Triangulate(HexCell cell)
        {
            Vector3 center = cell.transform.localPosition;
            int numVertices = HexMetrics.Corners.Length;

            for (int i = 0; i < numVertices - 1; i++)
            {
                AddTriangle(
                    center,
                    center + HexMetrics.Corners[i],
                    center + HexMetrics.Corners[i + 1]
                );
                AddTriangleColor(cell.Color);
            }
        }
        
        public void AddTriangleColor(Color color)
        {
            HexColors.Add(color);
            HexColors.Add(color);
            HexColors.Add(color);
        }

        void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            int vertexIndex = HexVertices.Count;
            HexVertices.Add(v1);
            HexVertices.Add(v2);
            HexVertices.Add(v3);
            HexTriangles.Add(vertexIndex);
            HexTriangles.Add(vertexIndex + 1);
            HexTriangles.Add(vertexIndex + 2);
        }

    }
}
