using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using RedBlueGames.Tools.TextTyper;
using Model;
using System.Linq;

namespace HexMapScene_UI
{
    partial class TextQuestWindow : BaseView
    {
        TextTyper typer;
        int phase;
        Model.QuestResult questResult;
        [SerializeField] Sprite defaultImage;

        public override void Init()
        {
            base.Init();
            Bus.ShowQuest.Subscribe(this, (i) => ShowQuest(i)).CallWhenInactive();
            typer = txDesc.GetComponent<TextTyper>();
            typer.PrintCompleted.AddListener(OnPrintCompleted);
            Subscribe(btClose, () => { phase = 2; Close(); });
        }

        private void ShowQuest(Quest quest)
        {
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
            //
            var image = Resources.Load<Sprite>("Quests/" + quest.Image);
            //copy data to UI controls here
            Set(txName, quest.Name);
            Set(imImage, image ?? defaultImage);
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
                    typer.TypeText(quest?.Description ?? "Ooops!");
                    break;
                case 1:
                    typer.GetComponent<AudioSource>().Play();
                    typer.TypeText((questResult?.FullDescription ) ?? "Ooops!");
                    break;
            }
        }

        private void OnPrintCompleted()
        {
            typer.GetComponent<AudioSource>().Stop();
            switch(phase)
            {
                case 0:
                    var varinats = quest.GenerateVariants().ToList();
                    if (varinats.Count == 0)
                    {
                        SetActive(btClose, true);
                        return;
                    }
                    foreach (var variant in varinats)
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
            questResult = quest.GenerateResult(variant);
            Rebuild();
        }
    }
}