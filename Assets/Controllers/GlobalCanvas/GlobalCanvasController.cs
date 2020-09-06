using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers.GlobalCanvas
{
    public class GlobalCanvasController : MonoBehaviour
    {
        public string HpText
        {
            get => _hpText.text;

            set => _hpText.text = value;
        }

        public string NameText
        {
            get => _nameText.text;

            set => _nameText.text = value;
        }

        public string ArmorText
        {
            get => _armorText.text;

            set => _armorText.text = value;
        }

        public string DamageText
        {
            get => _damageText.text;

            set => _damageText.text = value;
        }

        [SerializeField] 
        private Text _hpText = default;

        [SerializeField]
        private Text _nameText = default;

        [SerializeField]
        private Text _armorText = default;

        [SerializeField]
        private Text _damageText = default;

    }
}
