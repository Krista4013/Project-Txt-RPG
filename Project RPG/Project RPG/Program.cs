using Project_RPG.Project_RPG;
using System.Numerics;

namespace Project_RPG
{
    internal class Program
    {

        public static Player player = new Player
        {
            Name = "PLAYER",
            JobClass = "백수",
            Level = 1,
            Exp = 0,
            Gold = 1000,
            MaxHp = 100,
            Hp = 100,
            Atk = 10,
            Def = 5,
            Inventory = new List<ItemSet>()
        };

        static void Main(string[] args)
        {

            Start start = new Start();
            start.StartScreen();
        }
    }
}