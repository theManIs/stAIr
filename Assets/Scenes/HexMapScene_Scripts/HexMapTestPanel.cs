using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using UnityEngine.SceneManagement;
using Model;

namespace HexMapScene_UI
{
    partial class HexMapTestPanel : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(btTextQuest, OpenTextQuest);
            Subscribe(btClose, () => SceneManager.LoadScene("SceneSelection"));
        }

        private void OpenTextQuest()
        {
            var index = GetInt(ifQuestIndex);
            if (index < 0 || index >= Database.Quests.Count)
                return;
            Bus.ShowQuest += Database.Quests[index];
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
            //Set(ifQuestIndex, default);
        }
        
        protected override void OnChanged()
        {
            //copy data from UI controls to data object
            //...
            base.OnChanged();
        }
    }
}