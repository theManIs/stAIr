using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Assets.Components.Level2.TurnShifter.Scripts
{
    public class SpriteOutline : MonoBehaviour
    {

        [SerializeField] private Color OutlineColor = Color.white;
        [SerializeField] [Range(0, 16)] private int outlineSize = 1;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private static readonly List<SpriteOutline> _instances = new List<SpriteOutline>();

        public ReadOnlyCollection<SpriteOutline> Instances => _instances.AsReadOnly();

        private static SpriteOutline _currentSelection;

        public static SpriteOutline CurrentSelection => _currentSelection;

        public bool _isSelected;

        public int index = -1;

        public bool SelectBlock = false;


        public bool IsSelected
        {
            get => _isSelected;
            set
            {
//            if (value == _isSelected) return;
                //if (_currentSelection && _currentSelection != this) _currentSelection.IsSelected = false;

                _isSelected = value;

                //_currentSelection = value ? this : null;
//            Debug.Log("Unit " + this.gameObject.name + " are going to be highlighted");
                UpdateOutline(enabled, value);
            }
        }

        private void Awake()
        {
            if (!_spriteRenderer) _spriteRenderer = GetComponent<SpriteRenderer>();

            // Register yourself
            _instances.Add(this);

//        _instances.Sort((SpriteOutline a, SpriteOutline b) => 
//            Convert.ToInt32(a.gameObject.name) > Convert.ToInt32(b.gameObject.name) ? 1 : Convert.ToInt32(a.gameObject.name) == Convert.ToInt32(b.gameObject.name) ? 0 : -1);
        }

        private void OnEnable()
        {
            UpdateOutline(true, _isSelected);
        }

        private void OnDisable()
        {
            UpdateOutline(false, _isSelected);
        }

        private void OnMouseDown()
        {
            //block any interaction while fullscreen window is opened
            if (Bus.IsAnyFullScreenWindowOpened)
                return;

            if (!SelectBlock)
            {
                // Toggle selection of this

                bool tempSelected = !IsSelected;

                for (int i = 0; i < _instances.Count; i++)
                {
                    _instances[i].IsSelected = false;
                }

                IsSelected = tempSelected;

                for (int i = 0; i < _instances.Count; i++)
                {
                    //                _instances[index].index = _instances.IndexOf(this);
                    _instances[i].index = _instances.IndexOf(this);
                }

                if (IsSelected)
                {
                    _currentSelection = _instances[index];
                    //                Debug.Log(index);
                }

                // _currentSelection current active object/ojbect
                //            if (_currentSelection)
                //            {
                //                Debug.Log("Unit " + _currentSelection.name + " selected.");
                //            } else
                //            {
                //                Debug.Log("No active units.");
                //            }


            }
        }

        private void Update()
        {
            //block any interaction while fullscreen window is opened
            if (Bus.IsAnyFullScreenWindowOpened)
                return;

            if (!SelectBlock)
            {
                // Deselect units
                if (Input.GetMouseButtonDown(1))
                {
                    IsSelected = false;
                }

                if (Input.GetKeyDown("tab"))
                {
                    //            Debug.Log(index);
                    index = index + 1 >= _instances.Count ? 0 : index + 1;
                    //            Debug.Log(index);
                    if (_instances.Count - 1 == _instances.IndexOf(this))
                    {
                        //                Debug.Log("_instances.IndexOf(this) " + _instances.IndexOf(this) + $" index {index}");


                        _currentSelection = _instances[index];
                        //                Debug.Log("Unit " + _currentSelection.name + " selected.");

                        for (int i = 0; i < _instances.Count; i++)
                        {
                            _instances[i].IsSelected = false;
                            _instances[i].index = index;
                            //                    Debug.Log($"{i} Unit " + _currentSelection.name + $" selected. _instances[i].index {_instances[i].index}");
                        }
                        _currentSelection.IsSelected = true;
                    }
                }
            }
        }

        void UpdateOutline(bool outline, bool selected)
        {
            var mpb = new MaterialPropertyBlock();
            _spriteRenderer.GetPropertyBlock(mpb);
            mpb.SetFloat("_Outline", outline ? 1f : 0);
            mpb.SetColor("_OutlineColor", selected ? OutlineColor : Color.clear);
            mpb.SetFloat("_OutlineSize", outlineSize);
            _spriteRenderer.SetPropertyBlock(mpb);
        }
    }
}