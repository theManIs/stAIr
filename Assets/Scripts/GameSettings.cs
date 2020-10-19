using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public GameResources GameResources;

    public GameSettings()
    {
        Instance = this;
    }
}
