using System.Collections.Generic;
using System.Linq;
using Assets.Components.HexMap.Scripts;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Components.FindRoute.Scripts
{
    public class FindRouteController : MonoBehaviour
    {
        public FindRoute FindRoute = new FindRoute();
        public HexGrid HexGrid;
        public HexMapEditor HexMapEditor;


        // Start is called before the first frame update
        void Start()
        {

            FindRoute.HexWidth = HexGrid.Width;
            FindRoute.HostObject = HexGrid.transform;

            HexCell[] hexCells = HexGrid.HexCells;
            List<GameObject> gameObjects = new List<GameObject>();

            foreach (HexCell hexCell in hexCells)
            {
                gameObjects.Add(hexCell.gameObject);
            }

            FindRoute.HexGrid = gameObjects.ToArray();
        }

        public Vector3[] GetRoute(Vector3 startPoint)
        {
            return FindRoute.RoutePositions(startPoint).ToArray();
        }


//        // Update is called once per frame
//        void Update()
//        {
//            if (Input.GetMouseButtonDown(1))
//            {
//                Vector3[] route = FindRoute.RoutePositions(0).ToArray();
//
//                foreach (Vector3 vector3 in route)
//                {
//                    Debug.Log(vector3);
//
//                    HexMapEditor.HexGrid.ColorCell(vector3, Color.cyan);
//                }
//            }
//        }
    }
}
