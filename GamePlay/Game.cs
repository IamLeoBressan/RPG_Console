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
        public int Dificuldade { get; private set; }
        public void IniciarGame(Heroi player, int dificuldade)
        {
            this.Dificuldade = dificuldade;
            this.Player = player;

            Console.Clear();
            int opcao = 0;

            while((opcao != 4) && (player.RealHealth > 0) && (MapaAtual < TotalMapas))
            {
                opcao = ChooseAction();
                switch(opcao){
                    case 1:
                        this.StartDungeon();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        Console.WriteLine(this.Player.PerfilCompleto());
                        Console.ReadLine();
                        break;
                    case 4:
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
            Dungeon dg = new Dungeon(this.Player, this.Dificuldade);
            
            if(this.Player.RealHealth > 0)
            {
                this.MapaAtual++;
                Console.WriteLine("Você Conseguiu atravessar a Dungeon");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Você morreu, tente de novo");
                Console.ReadLine();
            }
        }
    }
}