using System;
using System.Linq;
using System.Collections.Generic;

namespace RPG{
    class StartGame{
        public List<Character> Chars = DataHelper.GetChars();
        public Character Player { get; private set; }
        
        public void IniciarGame(){

            Console.Clear();

            int option = -1;

            while (!Chars.Where(c => c.Id == option).Any()){
                option = ChooseChar();
            }

            this.Player = Chars.Where(c => c.Id == option).SingleOrDefault();

            int opcao = 0;

            while(opcao != 3){
                opcao = ChooseAction();
                switch(opcao){
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    default:
                        System.Console.WriteLine("Opção invalida!");
                        Console.ReadLine();
                        break;
                }
            }


        }
        private int ChooseChar(){

            string menu = "";

            foreach (var charact in Chars)
            {
                menu += charact.Id + " - " + charact.Nome + "  Level: " + charact.Level + " Classe: " + charact.Classe + "\n" ;
            }

            menu += "\nDigite o Id que deseja entrar!";

            System.Console.WriteLine(menu);
            return Convert.ToInt32(Console.ReadLine());

        }

        private int ChooseAction(){
            
            Console.Clear();

            string menu = Player.MenuSuperiorChar()
            + "1 - Atacar\n"
            + "2 - Explorar\n"
            + "3 - Sair\n\n"
            + "Digite a opção desejada!";

            System.Console.WriteLine(menu);
            return Convert.ToInt32(Console.ReadLine());

        }

    }
}