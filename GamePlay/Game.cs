using System;
using System.Linq;
using System.Collections.Generic;
using RPG_New.Char;
using RPG_New.Inimigos;
using RPG_New.Helpers;

namespace RPG_New{
    class Game
    {
        public Heroi Player { get; private set; }    
        public int TotalMapas { get; private set; } = 7;
        public int MapaAtual { get; private set; } = 1;

        public void IniciarGame(Heroi player)
        {
            this.Player = player;

            Console.Clear();
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
        private int ChooseAction()
        {
            Console.Clear();

            string menu = Player.MenuSuperior()
            + $"Você está no Mapa {this.MapaAtual} de {this.TotalMapas}\n"
            + "1 - Entrar na Dungeon\n"
            + "2 - Mercado\n"
            + "3 - Perfil Heroi\n"
            + "4 - Sair\n"
            + "Digite a opção desejada!";

            System.Console.WriteLine(menu);

            string opcao = Console.ReadLine();

            return (opcao == ""?99:Convert.ToInt32(opcao));
        }
        private void StartDungeon()
        {
            Dungeon monster = new Dungeon();
            
        }
        private void AtacandoIgualRetardado()
        {
            while (Player.RealHealth>50){
                Inimigo monster = new Inimigo(0, "Deviling", Player.Level);

                Console.WriteLine($"Um {monster.Nome} apareceu");

                if(Arena.Fight(Player, monster))
                {

                }
            }

            Console.ReadLine();
        }
    }
}