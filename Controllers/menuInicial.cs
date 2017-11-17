using System;
using System.Linq;
using System.Collections.Generic;

namespace RPG{
    class MenuInicial{

        public MenuChar menuChar = new MenuChar();
        public StartGame startGame = new StartGame();
        public MenuInicial()
        {
            int opcao = 0;

            while(opcao != 3){
                opcao = ChooseOption();
                switch(opcao){
                    case 1:
                        this.startGame.IniciarGame();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        this.menuChar.StartMenuChar();
                        break;
                    default:
                        System.Console.WriteLine("Opção invalida!");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private int ChooseOption(){
            
            string menu = "1 - Start\n"
            + "2 - Ranking\n"
            + "3 - Exit\n"
            + "4 - ADM\n"
            + "\nDigite a opção desejada";

            Console.Clear();
            Console.WriteLine(menu);
            return Convert.ToInt32(Console.ReadLine());

        }
    }
}