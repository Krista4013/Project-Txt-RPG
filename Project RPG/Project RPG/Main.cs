using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPG
{
    internal class Main
    {
        public static void MainScreen()
        {
            Console.Clear();

            Console.WriteLine("1. 상태창");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전");
            Console.WriteLine("5. 뒤로가기");
            Console.WriteLine();

            string input;
            do
            {
                Console.Write("입력해주세요 : ");
                input = Console.ReadLine();

                // 현재 출력된 내용의 길이만큼 공백 문자열을 출력하여 이전 메시지를 덮어씁니다.
                Console.CursorTop -= 1;
                Console.Write(new string(' ', Console.WindowWidth));
                Console.CursorTop -= 1;

                switch (input)
                {
                    case "1":
                        // Player창 띄우기
                        PlayerStatus status = new PlayerStatus();
                        status.PlayerScreen();
                        break;

                    case "2":
                        // Inventory창 띄우기
                        Inventory inventory = new Inventory();
                        inventory.InventoryScreen();
                        break;

                    case "3":
                        // Shop창 띄우기
                        Shop shop = new Shop();
                        shop.ShopScreen();
                        break;

                    case "4":
                        // Dungeon창 띄우기
                        Dungeon dungeon = new Dungeon();
                        dungeon.DungeonScreen();
                        break;

                    case "5":
                        // 뒤로가기
                        Start start = new Start();
                        start.StartScreen();
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                        Console.ReadLine();
                        Console.Clear();
                        MainScreen();
                        break;
                }
            } while (input != "1" && input != "2" && input != "3");
        }
    }
}