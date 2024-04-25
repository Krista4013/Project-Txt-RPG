using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPG
{
    namespace Project_RPG
    {
        public static class ConsoleColors
        {
            public const string Reset = "\x1b[0m";
            public const string Black = "\x1b[30m";
            public const string Red = "\x1b[31m";
            public const string Green = "\x1b[32m";
            public const string Yellow = "\x1b[33m";
            public const string Blue = "\x1b[34m";
            public const string Purple = "\x1b[35m";
            public const string Cyan = "\x1b[36m";
            public const string White = "\x1b[37m";
        }
        public enum Rarity
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary
        }
        public enum ItemType
    {
        Weapon,
        Armor,
        Consumable
    }
        public class ItemSet
        {
            public string ItemName { get; set; }
            public ItemType Type { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Atk { get; set; }
            public int Def { get; set; }
            public int MaxHp { get; set; }
            public string Eq { get; set; }
            public Rarity ItemRarity { get; set; }

            public string GetColoredAtk()
            {
                return ConsoleColors.Red + Atk + ConsoleColors.Reset;
            }

            public string GetColoredDef()
            {
                return ConsoleColors.Blue + Def + ConsoleColors.Reset;
            }

            public string GetColoredPrice()
            {
                return ConsoleColors.Yellow + Price + ConsoleColors.Reset;
            }

            public string GetColoredName()
            {
                string color = GetColorByRarity(ItemRarity);
                return color + ItemName + ConsoleColors.Reset;
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
        }

        public static class Items
        {
            public static ItemSet OldSword = new ItemSet()
            {
                ItemName = "낡은 검",
                Type = ItemType.Weapon,
                Description = "낡고 낡은 검. 둔기보다 못하다...",
                Price = 100,
                Atk = 5,
                Eq = "",
                ItemRarity = Rarity.Common
            };

            public static ItemSet LongSword = new ItemSet()
            {
                ItemName = "브로드 소드",
                Type = ItemType.Weapon,
                Description = "밸런스 있는 검. 가볍고 휘두르기 편하다.",
                Price = 100,
                Atk = 7,
                Eq = "",
                ItemRarity = Rarity.Uncommon
            };

            public static ItemSet BronzeAxe = new ItemSet()
            {
                ItemName = "롱 소드",
                Type = ItemType.Weapon,
                Description = "더 길고 전문적인 검. 부족한 부분은 없다..!",
                Price = 300,
                Atk = 10,
                Eq = "",
                ItemRarity = Rarity.Rare
            };

            public static ItemSet SpearOfSparta = new ItemSet()
            {
                ItemName = "스파르타의 창",
                Type = ItemType.Weapon,
                Description = "능숙한 전사가 다룬 창. 예리함과 더해 파괴력은 막강하다...",
                Price = 1000,
                Atk = 15,
                Eq = "",
                ItemRarity = Rarity.Epic
            };

            public static ItemSet JihyoHammer = new ItemSet()
            {
                ItemName = "죄악의 뿅망치",
                Type = ItemType.Weapon,
                Description = "효쪽이의 애장망치. 이걸 든 효쪽이를 막을 이는 없다...",
                Price = 990000,
                Atk = 9999,
                Eq = "",
                ItemRarity = Rarity.Legendary
            };

            public static ItemSet HyunchangFist = new ItemSet()
            {
                ItemName = "지옥 불주먹",
                Type = ItemType.Weapon,
                Description = "헬창남 현창의 불주먹. 5시에 더욱 불타오르는것 같다...",
                Price = 990000,
                Atk = 9999,
                Eq = "",
                ItemRarity = Rarity.Legendary
            };

            public static ItemSet NormalArmor = new ItemSet()
            {
                ItemName = "낡은 갑옷",
                Type = ItemType.Armor,
                Description = "낡아빠진 갑옷. 옷 역할이라도 한다...",
                Price = 100,
                Def = 5,
                Eq = "",
                ItemRarity = Rarity.Common
            };

            public static ItemSet IronArmor = new ItemSet()
            {
                ItemName = "무쇠 갑옷",
                Type = ItemType.Armor,
                Description = "철로 만들어진 단단한 갑옷. 단단해서 움직이기 힘들다",
                Price = 500,
                Def = 7,
                Eq = "",
                ItemRarity = Rarity.Uncommon
            };

            public static ItemSet ChainArmor = new ItemSet()
            {
                ItemName = "사슬 갑옷",
                Type = ItemType.Armor,
                Description = "움직이기 편한 갑옷. 사슬로 만들어 가벼워지고 기동성이 좋아졌다.",
                Price = 500,
                Def = 7,
                Eq = "",
                ItemRarity = Rarity.Rare
            };

            public static ItemSet ArmorOfSparta = new ItemSet()
            {
                ItemName = "스파르타의 갑옷",
                Type = ItemType.Armor,
                Description = "능숙한 전사가 입었던 갑옷. 많은 전사들에게 사랑받는 전문적인 갑옷.",
                Price = 1000,
                Def = 15,
                Eq = "",
                ItemRarity = Rarity.Epic
            };

            public static ItemSet JiHunArmor = new ItemSet()
            {
                ItemName = "기만자의 손길",
                Type = ItemType.Armor,
                Description = "기만의 신 지훈의 갑옷. 입고 있으면 모든 이들을 *상습기만* 할 수 있다...",
                Price = 990000,
                Def = 9999,
                Eq = "",
                ItemRarity = Rarity.Legendary
            };

        }
    }
}
