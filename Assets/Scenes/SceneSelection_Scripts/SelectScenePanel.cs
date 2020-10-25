using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using UnityEngine.SceneManagement;
using Model;

namespace SceneSelection_UI
{
    partial class SelectScenePanel : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(btHub, () => SceneManager.LoadScene("Hub", LoadSceneMode.Single));
            Subscribe(btHexMap, () => SceneManager.LoadScene("HexMapScene", LoadSceneMode.Single));
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
        }
    }
}