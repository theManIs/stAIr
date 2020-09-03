using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Components.Level2.TurnShifter.Scripts;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public List<SpriteOutline> objects;

    private void Start()
    {
        objects = FindObjectsOfType<SpriteOutline>().ToList();
        objects.Sort((SpriteOutline a, SpriteOutline b) =>
            Convert.ToInt32(a.gameObject.name) > Convert.ToInt32(b.gameObject.name) ? 1 : Convert.ToInt32(a.gameObject.name) == Convert.ToInt32(b.gameObject.name) ? 0 : -1);
    }
}