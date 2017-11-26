using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_New.Itens
{
    class Cinto
    {
        private List<Item> itens = new List<Item>();

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
        
    }
}