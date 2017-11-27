using System;
using RPG_New.Char;
using RPG_New.Helpers;

namespace RPG_New
{
    class Dungeon
    {
        public int SalaAtual { get; private set; } = 0;
        public int TotalSalas { get; private set; }
        public int Dificuldade { get; private set; }

        public Heroi Player { get; private set; }
        public Dungeon(Heroi player, int dificuldade)
        {
            this.Dificuldade = dificuldade;
            this.Player = player;
            this.TotalSalas = TamanhoDungeon();

            Console.WriteLine($"Você entrou na Dungeon, ela tem {this.TotalSalas} Salas");
            Console.ReadLine();

            bool Live = ExecutaRoom();

            int option = 99;

            while (SalaAtual < TotalSalas && Live)
            {
                int auxSala = this.SalaAtual;

                while(auxSala == this.SalaAtual && Live)
                {

                    Console.Clear();
                    Console.WriteLine(Player.MenuSuperior());
                    Console.WriteLine($"Voce está na sala {SalaAtual} de {TotalSalas}\n");

                    option = ChooseOption();

                    switch (option)
                    {
                        case 1:
                            Live = this.ExecutaRoom();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:

                            break;
                    }
                }
            }

        }
        public bool ExecutaRoom()
        {
            
            int typeRoom = this.GetTypeRoom();

            if(typeRoom == 0)
            {

                bool resultado = Arena.Fight(Player);
                Console.ReadLine();
                if (resultado) SalaAtual++;

                return resultado;
            }
            else if(typeRoom == 1)
            {
                string msg = "Você entrou em uma sala vazia, não tem nada aqui. \n";
                System.Console.WriteLine(msg);
                Console.ReadLine();
                SalaAtual++;
                return true;
            }
            else{
                this.SalaAtual++;
                return true;
            }
        }
        public int TamanhoDungeon()
        {

            Random rnd = new Random();

            if (this.Dificuldade == 0)
            {
                return rnd.Next(6, 8);
            }
            else if (this.Dificuldade == 1)
            {
                return rnd.Next(6, 10);
            }
            else
            {
                return rnd.Next(6, 12);
            }
        }
        public int GetTypeRoom()
        {

            Random rnd = new Random();

            int ProbMonstro;
            int ProbEmpty;
            int ProbItem;

            if(this.Dificuldade == 0){
                ProbMonstro = 40;
                ProbEmpty = 20;
                ProbItem = 40;
            }
            else if(this.Dificuldade == 1)
            {
                ProbMonstro = 50;
                ProbEmpty = 20;
                ProbItem = 30;
            }
            else
            {
                ProbMonstro = 60;
                ProbEmpty = 20;
                ProbItem = 20;
            }

            int Prob = rnd.Next(1, 100);

            if(Prob < ProbMonstro)
            {
                return 0;
            }
            else if(Prob < (ProbMonstro + ProbEmpty))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public int ChooseOption(){
            string menu = "O que deseja fazer ?\n"
            + "1 - Ir para Proxima sala\n"
            + "2 - Usar Itens\n"
            + "3 - Chorar\n"
            + "Digite a opção desejada!";;

            Console.WriteLine(menu);
            string option = Console.ReadLine();

            return (option == "" ? 99 : Convert.ToInt32(option));
        }

    }
}