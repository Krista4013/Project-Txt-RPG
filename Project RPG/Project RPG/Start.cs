using Project_RPG.Project_RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RPG
{
    internal class Start
    {
        public void StartScreen()
        {
            Console.Clear();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(@"                                                                
                                                                
          `7MMF' `YMM' `7MM""""""Mq.  `7MMF' .M""""""bgd MMP""""MM""""YMM   db      
            MM   .M'     MM   `MM.   MM  ,MI    ""Y P'   MM   `7  ;MM:     
            MM .d""       MM   ,M9    MM  `MMb.          MM      ,V^MM.    
            MMMMM.       MMmmdM9     MM    `YMMNq.      MM     ,M  `MM    
            MM  VMA      MM  YM.     MM  .     `MM      MM     AbmmmqMA   
            MM   `MM.    MM   `Mb.   MM  Mb     dM      MM    A'     VML  
          .JMML.   MMb..JMML. .JMM..JMML.P""Ybmmd""     .JMML..AMA.   .AMMA.

                          MMP""""MM""""YMM     MMP""""MM""""YMM                   
                          P'   MM   `7     P'   MM   `7                   
                               MM  `7M'   `MF'  MM                        
                               MM    `VA ,V'    MM                        
                               MM      XMX      MM                        
                               MM    ,V' VA.    MM                        
                             .JMML..AM.   .MA..JMML.                      

                .g8""""""bgd       db      `7MMM.     ,MMF'`7MM""""""YMM        
              .dP'     `M      ;MM:       MMMb    dPMM    MM    `7        
              dM'       `     ,V^MM.      M YM   ,M MM    MM   d          
              MM             ,M  `MM      M  Mb  M' MM    MMmmMM          
              MM.    `7MMF'  AbmmmqMA     M  YM.P'  MM    MM   Y  ,       
              `Mb.     MM   A'     VML    M  `YM'   MM    MM     ,M       
                `""bmmmdPY .AMA.   .AMMA..JML. `'  .JMML..JMMmmmmMMM       
                                                                
                                                                ");

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine(@"                      
                               *******************
                               |                 |
                               |  1. 게임 시작   |
                               |  2. 게임 종료   |
                               |                 |
                               *******************



");

            Console.WriteLine();

            string input;
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("입력해주세요 : ");
                input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        validInput = true;
                        break;

                    case "2":
                        Console.WriteLine("게임을 종료합니다.");
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("뒤로가기 위해 아무키나 눌러주세요.");
                        Console.ReadLine();
                        Console.Clear();
                        StartScreen();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("                                 v 플레이어 생성 v");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.Write("플레이어 이름을 입력하세요: ");
            string playerName = Console.ReadLine();
            Console.Write("플레이어 직업을 입력하세요: ");
            string playerJob = Console.ReadLine();

            // 플레이어 객체 생성 및 초기화
            Program.player = new Player
            {
                Name = playerName,
                JobClass = playerJob,
                Level = 1,
                Exp = 0,
                Gold = 300,
                MaxHp = 100,
                Hp = 100,
                Atk = 5,
                Def = 5,
                Inventory = new List<ItemSet>()
            };

            Main.MainScreen();
        }
    }
}