using System;
using System.Linq;
using System.Collections.Generic;
using RPG.Models;
using RPG.Helpers;

namespace RPG{
    class StartGame
    {
        public List<Character> Chars = DataHelper.GetChars();
        public Character Player { get; private set; }        
        public void IniciarGame()
        {
            Console.Clear();

            int option = -1;

            while (!Chars.Where(c => c.Id == option).Any())
            {
                option = ChooseChar();
            }
            this.Player = Chars.Where(c => c.Id == option).SingleOrDefault();

            int opcao = 0;

            while(opcao != 4)
            {
                opcao = ChooseAction();
                switch(opcao){
                    case 1:
                        this.AtaqueMonster();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        this.UsePotion();
                        break;
                    case 4:
                        break;
                    case 5:
                        this.AtacandoIgualRetardado();

                        break;                        
                    default:
                        System.Console.WriteLine("Opção invalida!");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private void UsePotion(){
            if(Player.Potions>0){
                Player.UsePotion();
            }else{
                System.Console.WriteLine("Você não tem potions disponiveis, tente explorar para encontrar mais.");
            }
            Console.ReadLine();
        }
        private int ChooseChar()
        {
            string menu = "";

            foreach (var charact in Chars)
            {
                menu += charact.Id + " - " + charact.Nome + "  Level: " + charact.Level + " Classe: " + charact.Classe + "\n" ;
            }

            menu += "\nDigite o Id que deseja entrar!";

            System.Console.WriteLine(menu);
            return Convert.ToInt32(Console.ReadLine());
        }
        private int ChooseAction()
        {
            Console.Clear();

            string menu = Player.MenuSuperiorChar()
            + "1 - Atacar\n"
            + "2 - Explorar\n"
            + "3 - Potion\n"
            + "4 - Sair\n"
            + "5 - Atacar Igual um retardado\n\n"
            + "Digite a opção desejada!";

            System.Console.WriteLine(menu);

            string opcao = Console.ReadLine();

            return (opcao == ""?99:Convert.ToInt32(opcao));
        }
        private void AtaqueMonster()
        {
            Monster monster = new Monster(0, "Deviling", Player.Level);

            Console.WriteLine($"Um {monster.Nome} apareceu");
            Console.ReadLine();

            if(Arena.Fight(Player, monster))
            {

            }
            Console.ReadLine();
        }
        private void AtacandoIgualRetardado()
        {
            while (Player.RealHealth>50){
                Monster monster = new Monster(0, "Deviling", Player.Level);

                Console.WriteLine($"Um {monster.Nome} apareceu");

                if(Arena.Fight(Player, monster))
                {

                }
            }

            Console.ReadLine();
        }
    }
}