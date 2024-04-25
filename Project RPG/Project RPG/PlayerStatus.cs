using Project_RPG.Project_RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Project_RPG
{
    internal class PlayerStatus
    {
        private Player player = new Player();

        public void PlayerScreen()
        {
            Console.Clear();

            Console.WriteLine("-=+ " + ConsoleColors.Yellow + "상태창" + ConsoleColors.Reset + " +=-");
            Console.WriteLine();

            Console.WriteLine(ConsoleColors.White + Program.player.Name + ConsoleColors.Reset + " (" + ConsoleColors.Purple + Program.player.JobClass + ConsoleColors.Reset + ")");
            Console.WriteLine("레벨 : " + ConsoleColors.Cyan + Program.player.Level + ConsoleColors.Reset);
            Console.WriteLine("경험치 : " + ConsoleColors.Green + Program.player.Exp + ConsoleColors.Reset + " / 100");
            Console.WriteLine("체력 : " + ConsoleColors.Green + Program.player.Hp + ConsoleColors.Reset + " / " + Program.player.MaxHp);
            Console.WriteLine("공격력 : " + ConsoleColors.Red + Program.player.Atk + GetAtkBonusText() + ConsoleColors.Reset);
            Console.WriteLine("방어력 : " + ConsoleColors.Blue + Program.player.Def + GetDefBonusText() + ConsoleColors.Reset);
            Console.WriteLine("돈 : " + ConsoleColors.Yellow + Program.player.Gold + ConsoleColors.Reset);

            Console.WriteLine();
            Console.WriteLine("1. 돌아가기");
            Console.Write("입력해주세요 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Main.MainScreen();
                    break;

                default:
                    Console.WriteLine("다시 입력해주세요.");
                    PlayerScreen();
                    break;
            }
        }

        private int GetEquipmentAtkBonus()
        {
            var totalBonus = 0;
            foreach (var item in Program.player.Inventory)
            {
                if (!string.IsNullOrEmpty(item.Eq) && item.Atk > 0)
                {
                    totalBonus += item.Atk;
                }
            }
            return totalBonus;
        }

        private int GetEquipmentDefBonus()
        {
            var totalBonus = 0;
            foreach (var item in Program.player.Inventory)
            {
                if (!string.IsNullOrEmpty(item.Eq) && item.Def > 0)
                {
                    totalBonus += item.Def;
                }
            }
            return totalBonus;
        }

        private string GetAtkBonusText()
        {
            var totalBonus = GetEquipmentAtkBonus();
            return totalBonus > 0 ? $" (+{totalBonus})" : "";
        }

        private string GetDefBonusText()
        {
            var totalBonus = GetEquipmentDefBonus();
            return totalBonus > 0 ? $" (+{totalBonus})" : "";
        }
    }
}