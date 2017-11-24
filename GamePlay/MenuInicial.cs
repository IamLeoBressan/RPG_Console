using System;
using System.Collections.Generic;
using RPG_New.Char;

namespace RPG_New
{
    class MenuInicial
    {
        public Game Game = new Game();
        public int Dificuldade { get; private set; }
        public MenuInicial()
        {
            this.Dificuldade = 0;
            int opcao = 0;

            while(opcao != 3){
                opcao = ChooseOption();
                switch(opcao){
                    case 1:
                        this.StartGame();
                        break;
                    case 2:
                        this.MenuDificuldade();
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
        private string TraduzDificuldade(int dif){
            switch(dif){
                case 0:
                    return "Facil";
                case 1:
                    return "Média";
                case 2:
                    return "Dificuldade";
                default:
                    return "Erro";
            }
        }
        public void StartGame(){
            Console.Clear();
            System.Console.WriteLine("Vamos começar nossa aventura");
            Console.ReadLine();
            Heroi Player = this.CreateCharacter();

            Game.IniciarGame(Player);
        }
        public Heroi CreateCharacter()
        {
            Console.Clear();
            System.Console.WriteLine("Digite o nome do seu Personagem");
            string nome = Console.ReadLine();

            return new Heroi(nome);
        }
        private void MenuDificuldade()
        {
            string menu = "A Dificuldade atual é " + this.TraduzDificuldade(this.Dificuldade) + "\n"
                + "1 - Facil\n"
                + "2 - Médio\n"
                + "3 - Dificil\n"
                + "4 - Voltar\n\n"
                + "\nDigite a opção desejada";

            int opcao = 0;
            int test = 0;

            while(test == 0)
            {
                Console.Clear();
                Console.WriteLine(menu);
                opcao = Convert.ToInt32(Console.ReadLine());

                switch(opcao){
                    case 1:
                        this.Dificuldade = 0;
                        test = 1;
                        break;
                    case 2:
                        this.Dificuldade = 1;
                        test = 1;
                        break;
                    case 3:
                        this.Dificuldade = 2;
                        test = 1;
                        break;
                    case 4:
                        test = 1;
                        break;                        
                    default:
                        System.Console.WriteLine("Opção invalida!");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private int ChooseOption()
        {
            string menu = "1 - Iniciar\n"
            + "2 - Dificuldade\n"
            + "3 - Sair\n\n"
            + "\nDigite a opção desejada";

            Console.Clear();
            Console.WriteLine(menu);
            return Convert.ToInt32(Console.ReadLine());

        }
    }
}   