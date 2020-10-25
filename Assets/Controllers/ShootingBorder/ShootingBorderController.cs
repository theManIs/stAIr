using Assets.Components.Level2.TurnShifter.Scripts;
using Assets.Components.Static.StaticClasses;
using Assets.Components.UserClass.Scripts;
using Assets.Components.WeaponsStock.Scripts;
using Assets.Controllers.GlobalCanvas;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Controllers.ShootingBorder
{
    public class ShootingBorderController : MonoBehaviour
    {
        public Camera MainCamera;
        public AudioSource AudioSource;
        public TurnShifterController.TurnShifterController TurnShifterController;
        public int MaxRayCastDistance = 1000;
        public GlobalCanvasController GlobalCanvasController;
        public float AccuracyPanelShift = 1.5f;

        private CommonUser _commonUser;

        private bool _aimLock = false;

        private bool _accuracyPanelDisplayed = true;
        private Vector3 _accuracyPanelTransform = Vector3.zero;

        public void Start()
        {

        }

        private void Update()
        {
            //block any interaction while fullscreen window is opened
            if (Bus.IsAnyFullScreenWindowOpened)
                return;

            CommonUserUpdate();
            PullOnTheTrigger();
            DisplayAccuracyPanel();
        }

        private void CommonUserUpdate()
        {
            _commonUser = TurnShifterController?.LastPickedWaypointArrow?.GetComponent<CommonUser>();
        }

        private void PullOnTheTrigger()
        {
            if (Input.GetKeyDown(KeyCode.A) && _commonUser)
            {
                _aimLock = true;
            }

            if (_aimLock && Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit, MaxRayCastDistance))
                {
                    if (raycastHit.collider.gameObject.GetComponent<SpriteOutline>())
                    {
//                        Debug.Log(_commonUser.CharacterWeapon.AudioClip);
                        AudioSource.clip = _commonUser.CharacterWeapon.AudioClip;

//                        AudioSource.Play();

//                        Invoke(nameof(StopPlaying), 0.6f);
                    }
                }

                _aimLock = false;
            }

            if (Input.GetMouseButtonDown(1))
            {
                _aimLock = false;
            }
        }

        private void DisplayAccuracyPanel()
        {
            _accuracyPanelDisplayed = false;

            if (_aimLock)
            {
                if (Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit, MaxRayCastDistance))
                {
                    if (raycastHit.collider.gameObject.GetComponent<SpriteOutline>())
                    {
                        _accuracyPanelTransform = raycastHit.collider.transform.position;
                        _accuracyPanelTransform.z += AccuracyPanelShift * HexMetrics.OuterRadius;
                        _accuracyPanelTransform = MainCamera.WorldToScreenPoint(_accuracyPanelTransform);
                        _accuracyPanelDisplayed = true;
                    }
                }
            }

            if (_accuracyPanelDisplayed)
            {
                GlobalCanvasController.AccuracyPanel = _accuracyPanelTransform;
                GlobalCanvasController.AccuracyPanelActive = _accuracyPanelDisplayed;
                GlobalCanvasController.AccuracyText = $"{CountAccuracy():f0}%";
            }
            else
            {
                GlobalCanvasController.AccuracyPanelActive = _accuracyPanelDisplayed;
            }
        }

        public float CountAccuracy()
        {
            float[] mas = { 0.8f, 0.6f, 0.4f, 0,2f};
            CharacterPreferences up = _commonUser.UserPreferences;

            return GameMath.GetTargetAccuracy(mas, 1, up.BaseAim, up.BaseDodge, 0.2f);
        }

        public void StopPlaying()
        {
//            AudioSource.Stop();
        }
    }
}