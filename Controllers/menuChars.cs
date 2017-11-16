using System;
using System.Linq;
using System.Collections.Generic;

namespace RPG{
    class MenuChar{
        List<Character> Chars = DataHelper.GetChars();
        public MenuChar(){

            int opcao = 0;

            while(opcao != 6){
                opcao = ChooseOption();
                switch(opcao){
                    case 1:
                        this.Cadastrar();
                        break;
                    case 2:
                        this.ListaGrupo();
                        break;
                    case 3:
                        this.Consultar();
                        break;
                    case 4:
                        this.Remover();
                        break;
                    case 5:
                        this.Editar();
                        break;
                    case 6:
                        break;
                    default:
                        System.Console.WriteLine("Opção invalida!");
                        break;
                }
                Console.ReadLine();
            }
        }
        private void Cadastrar(){
            Console.Clear();
            int Id = Chars.Count;
            Console.WriteLine("Digite o Nome Desejado");
            string nome = Console.ReadLine();

            Chars.Add(new Character(Id, nome));

            System.Console.WriteLine($"{nome} cadastrado com sucesso");
        }
        private void ListaGrupo(){
            Console.Clear();
            foreach(var chars in Chars.GroupBy(g => g.Classe)){
                Console.WriteLine("Classe: " + chars.FirstOrDefault().Classe);

                foreach(var Character in Chars){
                    Console.WriteLine(Character);
                }
                Console.WriteLine("\n");
            }
        }
        private void Consultar(){
            Console.Clear();
            Console.WriteLine("Digite o nome que deseja buscar");
            string nome = Console.ReadLine();
    
            var CharFiltro = Chars.Where(c => c.Nome.Contains(nome));

            if(CharFiltro.Any())
            {
                foreach (var charact in CharFiltro)
                {
                    Console.WriteLine("\n" + charact.FullDescr + "\n");
                }
            }
            else
            {
                Console.WriteLine("Nome não encontrado");
            }
        }
        private void ListaSimples(){
            Console.Clear();
            foreach(var Character in Chars){
                Console.WriteLine(Character);

            }
            Console.WriteLine("\n");
        }
        private void Remover(){
            this.ListaSimples();
            int Id;

            Console.WriteLine("Digite o Id que deseja remover");
            Id = Convert.ToInt32(Console.ReadLine());

            Character FindChar = Chars
                .Where(f => f.Id == Id)
                .FirstOrDefault();

            Chars.Remove(FindChar);

            Console.WriteLine(FindChar.Nome+" removido com sucesso.");

        }
        private void Editar(){
            this.ListaSimples();
            int Id;

            Console.WriteLine("Digite o Id que deseja remover");
            Id = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            
            Character FindChar = Chars
                .Where(f => f.Id == Id)
                .FirstOrDefault();

            Console.WriteLine(FindChar + "\n");

            Console.WriteLine("Digite o Nome Desejado");
            string nome = Console.ReadLine();

            Character newChar = new Character(
                FindChar.Id,
                (nome ==""?FindChar.Nome:nome)
            );

            Chars[Chars.IndexOf(FindChar)] = newChar;

            //Character.Remove(FindChar);

            Console.WriteLine(FindChar.Nome+" editado com sucesso.");
        }
        private int ChooseOption(){

            string menu = "1 - Cadastrar\n"
            + "2 - Listar\n"
            + "3 - Consultar\n"
            + "4 - Remover\n"
            + "5 - Editar\n"
            + "6 - Sair\n"
            + "\nDigite a opção desejada";

            Console.Clear();
            Console.WriteLine(menu);
            return Convert.ToInt32(Console.ReadLine());

        }
    }
}   