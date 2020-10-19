﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CometUI
{
    public class HoverCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Texture2D cursor;
        [SerializeField] Vector2 hotSpotMouse = new Vector2(32, 32);

        public void OnPointerEnter(PointerEventData eventData)
        {
            //isHover = true;
            Cursor.SetCursor(cursor, hotSpotMouse, CursorMode.Auto);
        }

        //bool isHover;

        public void OnPointerExit(PointerEventData eventData)
        {
            //isHover = false;
            //if (eventData.dragging)
            //    return;

            Cursor.SetCursor(null, hotSpotMouse, CursorMode.Auto);
        }
    }
}