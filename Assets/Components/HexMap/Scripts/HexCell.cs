using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    #region Fields

    public HexCoordinates HexCoordinates;
    public Color DefaultColor = default;

    private Color _currentColor = default;

    #endregion
    
    #region Properties

    public Color Color
    {
        get => _currentColor;
        set
        {
            if (DefaultColor == default)
            {
                DefaultColor = value;
            }

            _currentColor = value;
        }
    }

    #endregion
}
