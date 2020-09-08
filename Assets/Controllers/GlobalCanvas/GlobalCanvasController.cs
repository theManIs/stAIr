using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers.GlobalCanvas
{
    public class GlobalCanvasController : MonoBehaviour
    {
        public void DisableCharacterPanel()
        {
            _nameText.gameObject.SetActive(false);
            _characterPortrait.gameObject.SetActive(false);
            _healthBar.gameObject.SetActive(false);
            _shieldBar.gameObject.SetActive(false);
            _movementBar.gameObject.SetActive(false);
            _pulseBar.gameObject.SetActive(false);
        }

        public void EnableCharacterPanel()
        {
            _nameText.gameObject.SetActive(true);
            _characterPortrait.gameObject.SetActive(true);
            _healthBar.gameObject.SetActive(true);
            _shieldBar.gameObject.SetActive(true);
            _movementBar.gameObject.SetActive(true);
            _pulseBar.gameObject.SetActive(true);
        }

        [SerializeField]
        private Text _hpText = default;
        public string NameText
        {
            get => _nameText.text;

            set => _nameText.text = value;
        }

        [SerializeField]
        private Image _characterPortrait;
        public Sprite CharacterPortrait
        {
            get => _characterPortrait.sprite;

            set => _characterPortrait.sprite = value;
        }

        [SerializeField]
        private Slider _healthBar;
        public float HealthBar
        {
            get => _healthBar.value;

            set => _healthBar.value = value;
        }

        [SerializeField]
        private Slider _shieldBar;
        public float ShieldBar
        {
            get => _shieldBar.value;

            set => _shieldBar.value = value;
        }

        [SerializeField]
        private Slider _movementBar;
        public float MovementBar
        {
            get => _movementBar.value;

            set => _movementBar.value = value;
        }

        [SerializeField]
        private Slider _pulseBar;
        public float PulseBar
        {
            get => _pulseBar.value;

            set => _pulseBar.value = value;
        }

        public string HpText
        {
            get => _hpText.text;

            set => _hpText.text = value;
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
        private Text _nameText = default;

        [SerializeField]
        private Text _armorText = default;

        [SerializeField]
        private Text _damageText = default;

    }
}
