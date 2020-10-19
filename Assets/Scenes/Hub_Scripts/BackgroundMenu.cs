using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using UnityEngine.SceneManagement;

namespace Hub_UI
{
    partial class BackgroundMenu : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(btMission, () => {;});
            Subscribe(btShipUpgrade, () => {;});
            Subscribe(btSettings, () => SceneManager.LoadScene("SceneSelection"));
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
        }
    }
}