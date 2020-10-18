using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers.GlobalCanvas
{
    public class GlobalCanvasController : MonoBehaviour
    {
        public void DisableCharacterPanel()
        {
            _nameText.gameObject.SetActive(false);
            _characterAbilities.gameObject.SetActive(false);
            _characterPortrait.gameObject.SetActive(false);
            _healthBar.gameObject.SetActive(false);
            _shieldBar.gameObject.SetActive(false);
            _movementBar.gameObject.SetActive(false);
            _pulseBar.gameObject.SetActive(false);
            _weaponAvatar.gameObject.SetActive(false);
            _fireRate.gameObject.SetActive(false);
            _weaponAim.gameObject.SetActive(false);
            _weaponDamage.gameObject.SetActive(false);
            _amoCount.gameObject.SetActive(false);
            _consumableItems.gameObject.SetActive(false);
        }

        public void EnableCharacterPanel()
        {
            _nameText.gameObject.SetActive(true);
            _characterAbilities.gameObject.SetActive(true);
            _characterPortrait.gameObject.SetActive(true);
            _healthBar.gameObject.SetActive(true);
            _shieldBar.gameObject.SetActive(true);
            _movementBar.gameObject.SetActive(true);
            _pulseBar.gameObject.SetActive(true);
            _weaponAvatar.gameObject.SetActive(true);
            _fireRate.gameObject.SetActive(true);
            _weaponAim.gameObject.SetActive(true);
            _weaponDamage.gameObject.SetActive(true);
            _amoCount.gameObject.SetActive(true);
            _consumableItems.gameObject.SetActive(true);
        }

        [SerializeField]
        private Image _characterAbilities;

        [SerializeField]
        private Text _nameText = default;
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

        [SerializeField]
        private Image _weaponAvatar;
        public Sprite WeaponAvatar
        {
            get => _weaponAvatar.sprite;

            set => _weaponAvatar.sprite = value;
        }

        [SerializeField]
        private Text _fireRate = default;
        public string WeaponType
        {
            get => _fireRate.text;

            set => _fireRate.text = value;
        }

        [SerializeField]
        private Text _weaponAim = default;
        public string WeaponAim
        {
            get => _weaponAim.text;

            set => _weaponAim.text = value;
        }

        [SerializeField]
        private Text _weaponDamage = default;
        public string WeaponDamage
        {
            get => _weaponDamage.text;

            set => _weaponDamage.text = value;
        }

        [SerializeField]
        private Text _amoCount = default;
        public string AmoCount
        {
            get => _amoCount.text;

            set => _amoCount.text = value;
        }

        [SerializeField]
        private Image _consumableItems;

        [SerializeField]
        private Text _openFireHotKey = default;
        public string OpenFireHotKey
        {
            get => _openFireHotKey.text;

            set => _openFireHotKey.text = value;
        }

        [SerializeField]
        private RectTransform _accuracyPanel = default;
        public Vector3 AccuracyPanel
        {
            get => _accuracyPanel.position;

            set => _accuracyPanel.position = value;
        }
        public bool AccuracyPanelActive
        {
            get => _accuracyPanel.gameObject.activeSelf;

            set => _accuracyPanel.gameObject.SetActive(value);
        }


        [SerializeField]
        private Text _accuracyText = default;
        public string AccuracyText
        {
            get => _accuracyText.text;

            set => _accuracyText.text = value;
        }
    }
}
