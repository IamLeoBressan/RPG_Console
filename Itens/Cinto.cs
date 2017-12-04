using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_New.Itens
{
    class Cinto
    {
        private List<Item> itens = new List<Item>();
        public List<Item> Itens{
            get{
                return itens;
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
            if(itens.Count >= 3)
            {
                int opcao = 5;

                string menu = "O cinto está cheio, o que deseja fazer ?\n\n"
                    + $"1 - Substituir {itens[0]}\n"
                    + $"2 - Substituir {itens[1]}\n"
                    + $"3 - Substituir {itens[2]}\n"
                    + $"4 - Descartar";

                while(opcao < 1 || opcao > 4)
                {
                    Console.Clear();
                    System.Console.WriteLine(menu);

                    string aux = Console.ReadLine();

                    opcao = (aux == ""?99:Convert.ToInt32(aux));

                    switch(opcao)
                    {
                        case 1:
                            itens[0] = item;
                            break;
                        case 2:
                            itens[1] = item;
                            break;
                        case 3:
                            itens[2] = item;
                            break;
                        case 4:
                            break;
                        default:
                            System.Console.WriteLine("Opção invalida, tente novamente");
                            Console.ReadLine();
                            break;
                    }
                }
                System.Console.WriteLine("Item adicionado com sucesso");
                Console.ReadLine();
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