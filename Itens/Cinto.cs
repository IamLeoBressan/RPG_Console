using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_New.Itens
{
    class Cinto
    {
        private List<Item> itens = new List<Item>();
        public int PesoTotalCinto { get; private set; } = 50;
        public List<Item> Itens{
            get{
                return itens;
            }
        }
        public int PesoAtualCinto
        { 
            get
            {
                return itens.Sum(i => i.Peso);
            }
        }
        public int TotalItens {
            get{
                return itens.Count;
            }
        }
        public void RemoverItem(Item item)
        {
            itens.Remove(item);
        }
        public string ShowItens()
        {
            if (itens.Any())
            {
                return string.Join(", ", itens);
            }
            else
            {
                return "Vazio";
            }
        }
        public void AdicionaItem(Item item)
        {
            if((PesoAtualCinto + item.Peso) > PesoTotalCinto)
            {
                int opcao = 0;

                string menu = "O cinto está cheio, o que deseja fazer ?\n\n";

                int i;

                for (i = 0; i < itens.Count; i++)
                {
                    menu += $"{i+1} - Substituir {itens[i]}\n";
                }
                menu += $"{i+1} - Descartar\n";

                while(opcao < 1 || opcao > (i + 1) )
                {
                    Console.Clear();
                    System.Console.WriteLine(menu);

                    string aux = Console.ReadLine();

                    opcao = (aux == ""?99:Convert.ToInt32(aux));

                    if(opcao < 1 || opcao > (i + 1) )
                    {
                        System.Console.WriteLine("Opção invalida, tente novamente");
                        Console.ReadLine();
                    }
                    else if(opcao == (i + 1)){
                        System.Console.WriteLine("Item descartado com sucesso");
                        Console.ReadLine();
                    }
                    else{
                        itens[i-1] = item;
                        System.Console.WriteLine("Item adicionado com sucesso");
                        Console.ReadLine();
                    }
                }
            }
            else
            {
                itens.Add(item);
                System.Console.WriteLine("Item adicionado com sucesso");
                Console.ReadLine();
            }
        }
    }
}