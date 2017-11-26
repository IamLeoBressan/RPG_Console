using System;

namespace RPG_New.Itens
{
    class Item{

        public string Nome { get; private set; }
        public int peso { get; private set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}