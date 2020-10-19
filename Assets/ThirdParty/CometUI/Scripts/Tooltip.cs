using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace CometUI
{
    public class Tooltip : MonoBehaviour
    {
        [TextArea]
        public string TextLeft;
        [TextArea]
        public string TextRight;
        [Tooltip("Assign custom TooltipView here (instead of default)")]
        public TooltipView TooltipViewPrefab;
        [Tooltip("Target RectTransform")]
        public RectTransform Target;
        [Header("Appearing")]
        public PlaceAppear Appearing = PlaceAppear.Right;
        public bool KeepInScreen = true;
        public float TooltipDelay = 0.4f;
        public float MaxDuration = 3;
        public Vector2 MouseOffset = new Vector2(20, 20);
        public bool ShowWhenMouseMoving = false;

        internal TooltipView TooltipInstance;

        void Start()
        {
            UIManager.Instance?.RegisterTooltip(this);
        }

        private void OnDestroy()
        {
            UIManager.Instance?.UnRegisterTooltip(this);
        }
    }
}