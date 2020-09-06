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
//                GlobCanvasController.HpText = "HP " + Convert.ToString(_selectCommonUser.UserPreferences.BaseHp, CultureInfo.InvariantCulture);
//                GlobCanvasController.DamageText = "Damage " + Convert.ToString(_selectCommonUser.UserPreferences.BaseDamage, CultureInfo.InvariantCulture);
//                GlobCanvasController.ArmorText = "Armor " + Convert.ToString(_selectCommonUser.UserPreferences.BaseArmor, CultureInfo.InvariantCulture);
                GlobCanvasController.HpText = "HP " + _selectCommonUser.UserPreferences.GetString("BaseHp");
                GlobCanvasController.DamageText = "Damage " + _selectCommonUser.UserPreferences.GetString("BaseDamage");
                GlobCanvasController.ArmorText = "Armor " + _selectCommonUser.UserPreferences.GetString("BaseArmor");
            }
            else
            {
                GlobCanvasController.HpText = "";
                GlobCanvasController.NameText = "";
                GlobCanvasController.DamageText = "";
                GlobCanvasController.ArmorText = "";
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
