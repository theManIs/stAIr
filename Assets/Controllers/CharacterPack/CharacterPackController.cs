using System;
using System.Globalization;
using Assets.Components.ArrowWaypointer.Scripts;
using Assets.Components.UserClass.Scripts;
using Assets.Controllers.GlobalCanvas;
using Assets.Controllers.WaypointController;
using UnityEngine;

namespace Assets.Controllers.CharacterPack
{
    public class CharacterPackController : MonoBehaviour
    {
        public TurnShifterController.TurnShifterController TurnShifterController;
        public GlobalCanvasController GlobCanvasController;

        private CommonUser _selectCommonUser;

        #region UinityMethods

        private void OnEnable()
        {
            TurnShifterController.SelectionChanged += SelectionChanged;
        }

        private void OnDisable()
        {
            TurnShifterController.SelectionChanged -= SelectionChanged;
        }

        private void Update()
        {
            if (_selectCommonUser)
            {
                GlobCanvasController.NameText = _selectCommonUser.UserPreferences.CharacterOfficialName;
                GlobCanvasController.CharacterPortrait = _selectCommonUser.UserPreferences.CharacterPortrait;
                GlobCanvasController.HealthBar = _selectCommonUser.ActualHealth / _selectCommonUser.UserPreferences.BaseHealth * 100;
                GlobCanvasController.ShieldBar = _selectCommonUser.ActualShield / _selectCommonUser.UserPreferences.BaseShield * 100;
                GlobCanvasController.MovementBar = _selectCommonUser.ActualMovePoints / _selectCommonUser.UserPreferences.BaseMovePoints * 100;

                GlobCanvasController.EnableCharacterPanel();
            }
            else
            {
               GlobCanvasController.DisableCharacterPanel();;
            }
        }

        #endregion

        private void SelectionChanged(WaypointArrow previousSelection, WaypointArrow brandNewSelection)
        {
            if (!previousSelection && brandNewSelection)
            {
//                Debug.Log("Brand new selection");

                brandNewSelection.TryGetComponent(out _selectCommonUser);
            } 
            else if (previousSelection && brandNewSelection)
            {
//                Debug.Log("Changed selection");

                brandNewSelection.TryGetComponent(out _selectCommonUser);
            }
            else if (previousSelection && !brandNewSelection)
            {
//                Debug.Log("Disable selection");

                _selectCommonUser = null;
            }
        }
    }
}
