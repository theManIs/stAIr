using UnityEngine;

namespace Assets.Controllers.GeneralKeyController
{
    public class QuitGameController : MonoBehaviour
    {
        #region UnityMethods

        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        } 

        #endregion
    }
}
