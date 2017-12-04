using System;
using RPG_New.Char;
using RPG_New.Helpers;
using RPG_New.Itens;

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

            int TpRoom = ExecutaRoom();

            int option = 99;

            while (SalaAtual < TotalSalas && Player.Lives)
            {
                int auxSala = this.SalaAtual;

                if(TpRoom == 0)
                {
                    TpRoom = ExecutaRoom();
                }
                else
                {
                    while(auxSala == this.SalaAtual && Player.Lives)
                    {
                        Console.Clear();
                        Console.WriteLine(Player.MenuSuperior());
                        Console.WriteLine($"Voce está na sala {SalaAtual} de {TotalSalas}\n");

                        option = ChooseOption();

                        switch (option)
                        {
                            case 1:
                                TpRoom = this.ExecutaRoom();
                                break;
                            case 2:
                                EscolherItem();
                                break;
                            default:
                                System.Console.WriteLine("Opcao invalida, tente novamente");
                                break;
                        }
                    }
                }
                
            }

            if(Player.Lives){
                System.Console.WriteLine("Você estava prestes a sair da Dungeon quando sente um tremor");
                Console.ReadLine();
            }
        }
        public int ExecutaRoom()
        {
            int typeRoom = this.GetTypeRoom();

            if(typeRoom == 0)
            {
                Console.Clear();
                System.Console.WriteLine("Voce estava caminhando para a proxima sala e de repente ouve algo estranho no escuro");
                bool resultado = Arena.Fight(Player);
                Console.ReadLine();
                if (resultado) SalaAtual++;
            }
            else if(typeRoom == 1)
            {
                string msg = "Você entrou em uma sala vazia, não tem nada aqui. \n";
                System.Console.WriteLine(msg);
                Console.ReadLine();
                SalaAtual++;
            }
            else
            {
                ItemEncontrado();
                this.SalaAtual++;
            }

            return typeRoom;
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
            //+ "3 - Chorar\n"
            + "Digite a opção desejada!";;

            Console.WriteLine(menu);
            string option = Console.ReadLine();

            return (option == "" ? 99 : Convert.ToInt32(option));
        }

        public void ItemEncontrado(){
            Item itemEncontrado = DataHelper.GetItem();

            string menuOndeColocar = $"Você encontrou um {itemEncontrado.Nome}\n\n"
            + "O que deseja fazer com ele ?\n"
            + "1 - Adicionar no cinto\n"
            + "2 - Adicionar na mochila\n"
            + "3 - Descartar";

            int option = 0;

            while(option < 1 || option > 3)
            {
                Console.Clear();
                Console.WriteLine(menuOndeColocar);

                string aux = Console.ReadLine();

                option = (aux == ""?99:Convert.ToInt32(aux));

                switch (option)
                {
                    case 1:
                        Player.Cinto.AdicionaItem(itemEncontrado);
                        break;
                    case 2:
                        Player.Mochila.AdicionaItem(itemEncontrado);
                        break;
                    case 3:

                        break;
                    default:
                        Console.WriteLine("Opção Invalida, tente novamente");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void EscolherItem(){
            
            if((Player.Cinto.TotalItens > 0) || (Player.Mochila.TotalItens > 0))
            {
                string menu = "Deseja usar itens de onde ?\n"
                    + "1 - Cinto\n"
                    + "2 - Mochila\n";

                int option = 0;

                while(option < 1 || option > 2)
                {
                    Console.Clear();
                    System.Console.WriteLine(menu);;
                    string aux = Console.ReadLine();
                    option = (aux == ""?0:Convert.ToInt32(aux));

                    switch(option){
                        case 1:
                            if(Player.Cinto.TotalItens > 0)
                            {
                                Player.BuscarItemCinto();
                            }
                            else
                            {
                                Console.WriteLine("Voce nao tem itens no cinto");
                                Console.ReadLine();
                            }
                            
                            break;
                        case 2:
                            if(Player.Mochila.TotalItens > 0)
                            {
                                Player.BuscarItemMochila();
                            }
                            else
                            {
                                Console.WriteLine("Voce nao tem itens na mochila");
                                Console.ReadLine();
                            }
                            
                            break;
                        default:
                            System.Console.WriteLine("Opção invalida, tente novamente");
                            Console.ReadLine();
                            break;
                    }

                }
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("Você não tem nenhum item para ser usado");
                Console.ReadLine();
            }
        }
    }
}