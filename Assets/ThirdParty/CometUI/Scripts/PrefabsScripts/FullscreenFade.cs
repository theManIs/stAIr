using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace CometUI
{
    public class FullscreenFade : BaseView
    {
        public bool OverrideSorting = false;
        public bool CloseOwnerOnTap = false;

        private void Start()
        {
            var canvas = GetComponent<Canvas>();
            if (canvas)
                canvas.overrideSorting = OverrideSorting;
        }

        protected override void OnDisable()
        {
            Destroy(gameObject);
            base.OnDisable();
        }

        public override void OnGesture(GestureInfo info)
        {
            base.OnGesture(info);

            if (!info.IsHandled && info.Gesture == Gesture.Tap && CloseOwnerOnTap && Owner != null)
            {
                info.IsHandled = true;
                Owner.Close();
            }
        }
    }
}

