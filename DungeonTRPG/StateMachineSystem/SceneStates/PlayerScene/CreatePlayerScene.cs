﻿using DungeonTRPG.Entity;
using DungeonTRPG.Entity.Player;
using DungeonTRPG.Entity.Utility;
using DungeonTRPG.Utility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonTRPG.StateMachineSystem.SceneStates.PlayerScene
{
    internal class CreatePlayerScene : SceneState
    {
        private Player player;

        internal Job Job { get; private set; }  

        public CreatePlayerScene(StateMachine stateMachine) : base(stateMachine)
        {
            player = stateMachine.Player;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }

        protected override void View()
        {
            Console.WriteLine("사용하실 이름을 입력해주세요");
            string name = Console.ReadLine();

            player.SetName(name);

            if (name != null)
            {                
                Console.WriteLine($"안녕하세요 '{name}'님 DungeonTRPG에 오신 것을 환영합니다.");
                Console.WriteLine("");
                Console.WriteLine("===========================================================================");
                Console.WriteLine("||                       원하는 직업을 선택해주세요                      ||");
                Console.WriteLine("||              1. 전사    2. 법사    3. 궁수   0. 게임 종료             ||");
                Console.WriteLine("===========================================================================");
                Console.WriteLine("");

                string input = Console.ReadLine();
                switch (input)
                {
                    // 전사
                    case "1":
                        player.Job = Job.Warrior;
                        stateMachine.ChangeState(stateMachine.VillageScene);
                        break;
                    // 법사
                    case "2":
                        player.Job = Job.Mage;
                        stateMachine.ChangeState(stateMachine.VillageScene);
                        break;
                    // 궁수
                    case "3":
                        player.Job = Job.Archer;
                        stateMachine.ChangeState(stateMachine.VillageScene);
                        break;
                    // 게임 종료
                    case "0":
                        stateMachine.isGameOver = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }            

        protected override void Control()
        {
            
        }        
    }
}
