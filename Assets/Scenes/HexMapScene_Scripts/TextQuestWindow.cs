using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using RedBlueGames.Tools.TextTyper;
using Hub_UI;

namespace HexMapScene_UI
{
    partial class TextQuestWindow : BaseView
    {
        TextTyper typer;
        int phase;
        QuestResult questResult;

        public override void Init()
        {
            base.Init();
            Bus.ShowTextQuest.Subscribe(this, (i) => ShowQuest(i)).CallWhenInactive();
            typer = txDesc.GetComponent<TextTyper>();
            typer.PrintCompleted.AddListener(OnPrintCompleted);
            Subscribe(btClose, () => { phase = 2; Close(); });
        }

        private void ShowQuest(int index)
        {
            var quest = Resources.Load<TextQuest>("TextQuests/Quest " + index);
            if (quest != null)
            {
                phase = 0;
                Build(quest);
                Show(null);
            }
        }

        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            DestroyDynamicallyCreatedChildren();
            //copy data to UI controls here
            Set(txName, quest.Name);
            Set(imImage, quest.Image);
            Set(txDesc, "");
            Invoke("StartType", 0.5f);
            SetActive(btClose, false);
        }

        void StartType()
        {
            switch (phase)
            {
                case 0:
                    typer.GetComponent<AudioSource>().Play();
                    typer.TypeText(quest?.Text ?? "Ooops!");
                    break;
                case 1:
                    typer.GetComponent<AudioSource>().Play();
                    typer.TypeText((questResult?.Text.Highlight() ) ?? "Ooops!");
                    break;
            }
        }

        private void OnPrintCompleted()
        {
            typer.GetComponent<AudioSource>().Stop();
            switch(phase)
            {
                case 0:
                    foreach (var variant in quest.Variants)
                    {
                        var v = Instantiate(pnTextQuestVariant);
                        v.Build(variant);
                        v.Show(this);
                        v.Clicked += () => UserSelectedVariant(variant);
                    }
                    break;
                case 1:
                    SetActive(btClose, true);
                    break;
            }
        }

        private void UserSelectedVariant(QuestVariant variant)
        {
            phase = 1;
            questResult = quest.OnPlayerSelectedVariant(variant);
            Rebuild();
        }
    }
}