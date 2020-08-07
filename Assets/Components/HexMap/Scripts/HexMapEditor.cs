using Assets.Scripts;
using UnityEngine;

public class HexMapEditor : MonoBehaviour
{

    public Color[] Colors;

    public HexGrid HexGrid;

    private Color _activeColor;

    void Awake()
    {
        SelectColor(0);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            HexGrid.ColorCell(hit.point, _activeColor);
        }
    }

    public void SelectColor(int index)
    {
        _activeColor = Colors[index];
    }
}