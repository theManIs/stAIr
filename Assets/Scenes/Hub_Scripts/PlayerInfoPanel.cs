using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    partial class PlayerInfoPanel : BaseView
    {
        [SerializeField] AnimationLink WowAnimation;

        private void Start()
        {
            //subscribe buttons or events here
            Bus.PlayerMoneyChanged.Subscribe(this, ()=> { Rebuild(); AnimationPlayer.Play(txMoney, WowAnimation); UIManager.PlayOneShotSound(GameSettings.Instance.GameResources.CoinsSound); });
            Build();
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
            var player = Player.Instance;
            Set(txMoney, player.Money.ToString("$0."));
        }
    }
}