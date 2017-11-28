using System;
using System.Collections.Generic;

namespace RPG_New.Itens
{
    class Mochila{
        public Stack<Item> itens = new Stack<Item>();

        public string UltimoItem()
        {

            if(itens.Count > 0)
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
    }
}