using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public GameResources GameResources;

    public GameSettings()
    {
        Instance = this;
    }

    public Sprite GetIcon(IItem item)
    {
        var img = Resources.Load<Sprite>("Items/" + item.Image);
        if (img != null)
            return img;
        if (item is Weapon) return GameResources.DefaultWeaponIcon;
        if (item is Armor) return GameResources.DefaultArmorIcon;
        if (item is Module) return GameResources.DefaultModuleIcon;

        return null;
    }

    public Sprite GetFace(int index)
    {
        return GameResources.Faces[index % GameResources.Faces.Length];
    }
}
