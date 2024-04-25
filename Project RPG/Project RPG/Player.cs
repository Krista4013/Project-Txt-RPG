using Project_RPG.Project_RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPG
{
    public class Player
    {
        public string Name { get; set; }
        public string JobClass { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Gold { get; set; }
        public List<ItemSet> Inventory { get; set; }
    }
}
