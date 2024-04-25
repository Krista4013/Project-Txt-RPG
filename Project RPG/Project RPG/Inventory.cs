using Project_RPG.Project_RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPG
{
    internal class Inventory
    {
        public void InventoryScreen()
        {
            Console.Clear();
            Console.WriteLine(@"`7MMF'                                     mm                              
  MM                                       MM                              
  MM `7MMpMMMb`7M'   `MF'.gP""Ya `7MMpMMMbmmMMmm ,pW""Wq.`7Mb,od8 `7M'   `MF'
  MM   MM    MM VA   ,V ,M'   Yb  MM    MM MM  6W'   `Wb MM' ""'   VA   ,V  
  MM   MM    MM  VA ,V  8M""""""""""""  MM    MM MM  8M     M8 MM        VA ,V   
  MM   MM    MM   VVV   YM.    ,  MM    MM MM  YA.   ,A9 MM         VVV    
.JMML.JMML  JMML.  W     `Mbmmd'.JMML  JMML`Mbmo`Ybmd9'.JMML.       ,V     
                                                                   ,V      
                                                                OOb""       ");
            Console.WriteLine();
            Console.WriteLine();


            List<ItemSet> Inventory = Program.player.Inventory;

            void ItemStatus(int itemIndex)
            {
                var Eqitem = Inventory[itemIndex];
            }

            if (Inventory.Count == 0)
            {
                Console.WriteLine("인벤토리가 비었습니다.");
            }

            for (var i = 0; i < Inventory.Count; i++)
            {
                var item = Inventory[i];
                Console.WriteLine($"{i + 1}. [{item.Eq}] {item.ItemName} | {item.Description} | {Shop.GetItemOptionText(item)}");
            }

            Console.WriteLine();
            Console.WriteLine(@"

                                            1. 장착하기
                                            2. 해제하기
                                            0. 돌아가기

");
            Console.Write("입력해주세요 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Main.MainScreen();
                    break;

                case "1":
                    Console.WriteLine("장비할 아이템을 선택해주세요.");
                    var input2 = Console.ReadLine();
                    if (!int.TryParse(input2, out int itemIndex))
                    {
                        Console.WriteLine("숫자를 입력해주세요.");
                        Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                        Console.ReadLine();
                        InventoryScreen();
                        break;
                    }

                    itemIndex--; // 1부터 시작하는 인덱스를 0부터 시작하도록 변환
                    if (itemIndex >= 0 && itemIndex < Inventory.Count)
                    {
                        var eqItem = Inventory[itemIndex];
                        if (eqItem.Eq == "")
                        {
                            Console.WriteLine("장비 하였습니다."); 
                            eqItem.Eq = "E";
                        }
                        else
                        {
                            Console.WriteLine("이미 장착된 아이템입니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                        Console.ReadLine();
                    }
                    InventoryScreen();
                    break;

                case "2":
                    Console.WriteLine("해제할 아이템을 선택해주세요.");
                    if (int.TryParse(Console.ReadLine(), out int itemIndex2))
                    {
                        itemIndex2--; // 1부터 시작하는 인덱스를 0부터 시작하도록 변환
                        if (itemIndex2 >= 0 && itemIndex2 < Inventory.Count)
                        {
                            var eqItem = Inventory[itemIndex2];
                            if (eqItem.Eq != "")
                            {
                                Console.WriteLine("해제 하였습니다.");
                                eqItem.Eq = "";
                            }
                            else
                            {
                                Console.WriteLine("아이템이 장착되지 않았습니다.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                            Console.ReadLine();
                            InventoryScreen();
                        }
                    }
                    else
                    {
                        Console.WriteLine("숫자를 입력해주세요.");
                        Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                        Console.ReadLine();
                        InventoryScreen();

                    }

                    Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                    Console.ReadLine();
                    InventoryScreen();
                    break;

                default:
                    Console.WriteLine("다시 입력해주세요.");
                    Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                    Console.ReadLine();
                    InventoryScreen();
                    break;
            }
        }
    }
}