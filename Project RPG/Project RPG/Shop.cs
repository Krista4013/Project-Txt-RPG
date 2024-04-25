using Project_RPG.Project_RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPG
{
    internal class Shop
    {
        public void ShopScreen()
        {
            Console.Clear();

            var shopItems = new List<ItemSet>()
            {
                Items.OldSword,
                Items.LongSword,
                Items.BronzeAxe,
                Items.SpearOfSparta,
                Items.JihyoHammer,
                Items.HyunchangFist,
                Items.NormalArmor,
                Items.IronArmor,
                Items.ArmorOfSparta,
                Items.JiHunArmor
            };

            PrintTitle();
            Console.WriteLine();
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine();
            Console.WriteLine(@$"
                                         여기저기서 제련하는 소리가 들린다
                                                      ......
                                                    {ConsoleColors.Yellow}<{ConsoleColors.Reset}{ConsoleColors.Red}대장장이{ConsoleColors.Reset}{ConsoleColors.Yellow}>{ConsoleColors.Reset}
                                                 필요한건 다 있다.
                                               물론 돈만 있다면.....
");
            Console.WriteLine();
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine();

            Console.WriteLine($"                                              -=[ {ConsoleColors.Yellow}판매중인 아이템{ConsoleColors.Reset} ]=-");
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < shopItems.Count; i++)
            {
                var item = shopItems[i];
                string priceText = Program.player.Inventory.Contains(item) ? "재고없음" : $"{ConsoleColors.Yellow}{item.Price}골드{ConsoleColors.Reset}";
                Console.WriteLine($"{i + 1}. {GetItemNameWithColor(item)} {ConsoleColors.Cyan}|{ConsoleColors.Reset}" +
                    $" {item.Description} {ConsoleColors.Cyan}|{ConsoleColors.Reset} " +
                    $"{GetItemOptionText(item)} {ConsoleColors.Cyan}|{ConsoleColors.Reset} {priceText}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine();
            Console.WriteLine(@"

                                               1. 아이템 구매하기
                                               2. 아이템 판매하기
                                               0. 돌아가기

");

            string input;
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("입력해주세요 : ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Main.MainScreen();
                        return;
                    case "1":
                        BuyItem(shopItems);
                        validInput = true;
                        break;
                    case "2":
                        SellItem();
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                        Console.ReadLine();
                        Console.Clear();
                        ShopScreen();
                        return;
                }
            }
        }

        private void BuyItem(List<ItemSet> shopItems)
        {
            Console.Write("구매하실 아이템의 번호를 입력해주세요. : ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.Clear();
                ShopScreen();
                return;
            }

            if (int.TryParse(input, out int itemIndex) && itemIndex > 0 && itemIndex <= shopItems.Count)
            {
                var selectedItem = shopItems[itemIndex - 1];
                if (Program.player.Inventory.Contains(selectedItem))
                {
                    Console.WriteLine("이미 보유중인 아이템입니다.");
                    Console.WriteLine("다시 시도하려면 아무 키나 눌러주세요.");
                    Console.ReadLine();
                    BuyItem(shopItems);
                    return;
                }
                else if (Program.player.Gold < selectedItem.Price)
                {
                    Console.WriteLine("골드가 부족합니다.");
                    Console.WriteLine("다시 시도하려면 아무 키나 눌러주세요.");
                    Console.ReadLine();
                    BuyItem(shopItems);
                    return;
                }
                else
                {
                    Program.player.Inventory.Add(selectedItem);
                    Program.player.Gold -= selectedItem.Price;
                    Console.WriteLine($"{selectedItem.ItemName}을(를) 구매했습니다.");
                    Console.WriteLine("뒤로가기 위해 아무 키나 눌러주세요.");
                    Console.ReadLine();
                    Console.Clear();
                    ShopScreen();
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine("뒤로가기 위해 아무 키나 눌러주세요.");
                Console.ReadLine();
                Console.Clear();
                ShopScreen();
            }
        }

        private void SellItem()
        {
            Console.Clear();
            
            PrintTitle();


            // 사용자의 인벤토리에 있는 아이템 리스트를 가져옵니다.
            List<ItemSet> userInventory = Program.player.Inventory;

            // 인벤토리에 있는 아이템들을 표시합니다.
            for (int i = 0; i < userInventory.Count; i++)
            {
                var item = userInventory[i];
                string equippedIndicator = (item.Eq != "") ? "[E] " : ""; // 아이템이 착용 중인지 확인하고 [E]를 출력합니다.
                Console.WriteLine($"{i + 1}. {equippedIndicator}{GetItemNameWithColor(item)} {ConsoleColors.Cyan}|{ConsoleColors.Reset}" +
                    $" {item.Description} {ConsoleColors.Cyan}|{ConsoleColors.Reset} " +
                    $"{GetItemOptionText(item)} {ConsoleColors.Cyan}|{ConsoleColors.Reset} " +
                    $"{ConsoleColors.Yellow}{item.Price * 0.85}골드{ConsoleColors.Reset}"); // 판매 가격은 아이템 가격의 85%
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("0. 뒤로가기");
            Console.Write("판매할 아이템을 선택해주세요. : ");

            // 인벤토리에 아이템이 있는지 확인합니다.
            if (userInventory.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
                Console.WriteLine("뒤로가려면 아무 키나 눌러주세요.");
                Console.ReadLine();
                Console.Clear();
                ShopScreen(); // 상점 화면으로 돌아갑니다.
                return;
            }

            // 사용자로부터 아이템 선택을 받습니다.
            string input = Console.ReadLine();

            // 사용자의 입력을 처리합니다.
            if (input == "0")
            {
                Console.Clear();
                ShopScreen();
                return;
            }

            if (int.TryParse(input, out int itemIndex) && itemIndex > 0 && itemIndex <= userInventory.Count)
            {
                var selectedItem = userInventory[itemIndex - 1];
                if (selectedItem.Eq != "")
                {
                    Console.WriteLine("이 아이템은 장착 중입니다.");
                    Console.WriteLine("다시 시도하려면 아무 키나 눌러주세요.");
                    Console.ReadLine();
                    SellItem();
                    return;
                }
                else
                {
                    // 아이템을 판매합니다.
                    userInventory.Remove(selectedItem);
                    int sellPrice = (int)(selectedItem.Price * 0.85); // 판매 가격은 아이템 가격의 85%
                    Program.player.Gold += sellPrice;
                    Console.WriteLine($"{selectedItem.ItemName}을(를) 판매했습니다. 받은 골드: {sellPrice}");
                    Console.WriteLine("뒤로가기 위해 아무 키나 눌러주세요.");
                    Console.ReadLine();
                    Console.Clear();
                    ShopScreen();
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine("뒤로가기 위해 아무 키나 눌러주세요.");
                Console.ReadLine();
                Console.Clear();
                ShopScreen();
            }
        }

        public static string GetItemOptionText(ItemSet item)
        {
            var optionText = "";
            if (item.Atk > 0)
            {
                optionText += $"{ConsoleColors.Red}공격력 + {item.Atk} {ConsoleColors.Reset}";
            }

            if (item.Def > 0)
            {
                optionText += $"{ConsoleColors.Blue}방어력 +{item.Def} {ConsoleColors.Reset}";
            }

            return optionText;
        }

        // 아이템 이름을 특정 색으로 반환하는 메서드
        private string GetItemNameWithColor(ItemSet item)
        {
            string color = GetColorByRarity(item.ItemRarity);
            return color + item.ItemName + ConsoleColors.Reset;
        }

        private string GetColorByRarity(Rarity rarity)
        {
            switch (rarity)
            {
                case Rarity.Common:
                    return ConsoleColors.White;
                case Rarity.Uncommon:
                    return ConsoleColors.Green;
                case Rarity.Rare:
                    return ConsoleColors.Blue;
                case Rarity.Epic:
                    return ConsoleColors.Purple;
                case Rarity.Legendary:
                    return ConsoleColors.Yellow;
                default:
                    return ConsoleColors.White;
            }
        }

        private void PrintTitle()
        {
            Console.WriteLine(@"oooooooooo.  oooo                      oooo                                         o8o      .   oooo        
`888'   `Y8b `888                      `888                                         `""'    .o8   `888        
 888     888  888   .oooo.    .ooooo.   888  oooo        .oooo.o ooo. .oo.  .oo.   oooo  .o888oo  888 .oo.   
 888oooo888'  888  `P  )88b  d88' `""Y8  888 .8P'        d88(  ""8 `888P""Y88bP""Y88b  `888    888    888P""Y88b  
 888    `88b  888   .oP""888  888        888888.         `""Y88b.   888   888   888   888    888    888   888  
 888    .88P  888  d8(  888  888   .o8  888 `88b.       o.  )88b  888   888   888   888    888 .  888   888  
o888bood8P'  o888o `Y888""""8o `Y8bod8P' o888o o888o      8""""888P' o888o o888o o888o o888o   ""888"" o888o o888o 
                                                                                                              ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}