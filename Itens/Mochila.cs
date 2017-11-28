using System;
using System.Collections.Generic;

namespace RPG_New.Itens
{
    class Mochila{
        private Stack<Item> itens = new Stack<Item>();

        public int TotalItens{
            get{
                return itens.Count;
            }
        }

        public string UltimoItem()
        {

            if(TotalItens > 0)
            {
                return itens.Peek().Nome;
            }
            else
            {
                return "Vazia";
            }

            
        }
        public void AdicionaItem(Item item){
            itens.Push(item);
        }

        public Item PegarUltimoItem(){
            return itens.Pop();
        }

    }
}