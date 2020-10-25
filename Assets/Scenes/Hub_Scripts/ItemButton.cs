using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Coffee.UIEffects;
using Model;

namespace Hub_UI
{
    /// <summary>Предназначен для перетаскивания Item в слоты и из слотов</summary>
    partial class ItemButton : BaseView
    {
        UIShadow outlineEffect;

        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(bt, () => Bus.ShowItemInfo += item );
            outlineEffect = GetComponentInChildren<UIShadow>();
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Model.IItem item, int count, bool isActive
            //copy data to UI controls here
            Set(txCount, count.ToString());
            SetActive(imCountCircle, count > 1);
            SetInteractable(bt, isActive);
            Set(bt, GameSettings.Instance.GetIcon(item));
            GetComponentInChildren<Tooltip>().TextLeft = item.Name.Prepare();

            DragMode = count > 1 ? DragMode.Copy : DragMode.Move;
        }

        public Slot MySlot;

        public override void OnStartDrag()
        {
            base.OnStartDrag();
            SetActive(imCountCircle, false);
            outlineEffect.enabled = false;
            MySlot = GetComponentInParent<Slot>();
        }

        public override void OnDropped(BaseView acceptor)
        {
            base.OnDropped(acceptor);

            outlineEffect.enabled = true;
            if (acceptor is SellSlot sellSlot)
            {
                var mySlot = MySlot;
                UIManager.ShowDialog(this, "Продать за $" + item.SellPrice + " ?", "Продать", "Отмена", 
                    onClosed: (res)=>
                    {
                        if (res == DialogResult.Ok)
                        {
                            if (mySlot != null)
                                Player.Instance.SellFromSlot(mySlot.unit, item, mySlot.SlotIndex);
                            else
                                Player.Instance.SellFromStorage(item);
                            Bus.ShowItemInfo += null;
                        }
                        Bus.PlayerStorageChanged += true;
                    });
            }else
            if (acceptor is Slot slot)
            {
                if (MySlot != null)
                    ChangeSlot(MySlot, slot);
                else
                    MoveFromStorageToSlot(slot);
            }
            else
            if (MySlot != null && acceptor is StoragePanel)
                RemoveFromSlotToStorage(MySlot);
                
            MySlot = null;

            //destroy
            Close();
            Destroy(gameObject);

            Bus.ShowItemInfo += item;
        }

        public override void OnCancelDrag()
        {
            base.OnCancelDrag();
            outlineEffect.enabled = true;
            MySlot = null;

            Bus.PlayerStorageChanged += true;
        }

        private void MoveFromStorageToSlot(Slot slot)
        {
            slot.unit.AddItemFromStorage(item, slot.SlotIndex);
        }

        private void RemoveFromSlotToStorage(Slot mySlot)
        {
            mySlot.unit.RemoveFromSlotToStorage(item, MySlot.SlotIndex);
        }

        private void ChangeSlot(Slot from, Slot to)
        {
            from.unit.ChangeSlot(from.item, from.SlotIndex, to.SlotIndex);
        }
    }
}