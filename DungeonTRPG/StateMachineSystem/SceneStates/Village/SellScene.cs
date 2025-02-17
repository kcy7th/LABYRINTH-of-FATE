﻿using DungeonTRPG.EntitySystem.Utility;
using DungeonTRPG.Items;
using DungeonTRPG.ShopSystem;
using DungeonTRPG.StateMachineSystem.SceneStates.Combat;
using DungeonTRPG.Utility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DungeonTRPG.StateMachineSystem.SceneStates.Village
{
    internal class SellScene : SceneState
    {
        private Shop shop;

        public SellScene(StateMachine stateMachine) : base(stateMachine)
        {
            shop = new Shop();
        }

        protected override void View()
        {
            ViewInventoryItems();
        }

        private void ViewInventoryItems()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("상점");
            Console.ResetColor();
            Console.WriteLine(" - [판매]");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(player.Gold);
            Console.ResetColor();
            Console.WriteLine("G");
            Console.WriteLine();

            var inventoryItems = stateMachine.Player.Inventory.GetItems();
            if (inventoryItems.Count == 0)
            {
                Console.WriteLine("판매할 수 있는 아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < inventoryItems.Count; i++)
                {
                    Console.WriteLine($"- {i + 1} {inventoryItems[i].GetItemInformation()} | 판매가 : {(int)(inventoryItems[i].Price * 0.8)} G");
                }
            }

            Console.WriteLine();
            Console.WriteLine("0. 돌아가기");
            Console.WriteLine();
            InputField("판매하실 아이템 번호를 입력하세요.");
        }

        private void SellItem(int index)
        {
            var inventoryItems = player.Inventory.GetItems();
            Item selectedItem = inventoryItems[index];

            int sellPrice = (int)(selectedItem.Price * 0.8);
            stateMachine.Player.EarnGold(sellPrice);
            stateMachine.Player.Inventory.RemoveItem(selectedItem);
            SendMessage($"{selectedItem.GetName()}을(를) {sellPrice} 골드에 판매했습니다!");
        }

        protected override void Control()
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out var num))
            {
                if (num == 0) stateMachine.GoPreviousState();
                else if (0 < num && num <= stateMachine.Player.Inventory.GetItems().Count)
                {
                    var inventoryItems = player.Inventory.GetItems();
                    Item item = inventoryItems[num - 1];
                    if(item is EquipItem)
                    {
                        EquipItem equipItem = item as EquipItem;
                        if (equipItem.IsEquipped == false) SellItem(num - 1);
                        else SendMessage("장착중인 아이템 입니다.");
                    }
                    else SellItem(num - 1);
                }
                else SendMessage("잘못된 입력입니다.");
            }
            else SendMessage("잘못된 입력입니다.");
        }
    }
}

