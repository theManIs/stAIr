using UnityEngine;

namespace Assets.Controllers.UpdateController
{
    public class UpdateController : MonoBehaviour
    {
        public delegate void DUpdate();
        public event DUpdate EUpdate;

        void Update()
        {
            EUpdate?.Invoke();
        }
    }
}
