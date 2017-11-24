using System;
using RPG_New.Char;

namespace RPG_New
{
    class Dungeon
    {
        public int SalaAtual { get; private set; } = 1;
        public int TotalSalas { get; private set; }
        public int Dificuldade { get; private set; }
        public Heroi Player { get; private set; }
        public Dungeon(Heroi player)
        {
            this.Player = player;

            System.Console.WriteLine($"você entrou na {this.SalaAtual} sala da Dungeon");

            if()

        }
        public bool ExecutaRoom()
        {
            int typeRoom = this.GetTypeRoom();

            if(typeRoom == 0)
            {
                return true;
            }
            else if(typeRoom == 1)
            {
                string msg = "Você entrou em uma sala vazia, não tem nada aqui, apenas vazio e escuridão \n";
                Console.Clear();
                System.Console.WriteLine(msg);
                Console.ReadLine();
                return true;
            }
            else{
                return true;
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

            
            return 1;
        }

    }
}