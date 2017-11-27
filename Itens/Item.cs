using System;

namespace RPG_New.Itens
{
    class Item
    {
        public string Nome { get; private set; }
        public int Tipo { get; private set; }//1 = Equip / 2 = Potion
        public int Dificuldade { get; private set; } //Dificuldade de encontrar
        public int Peso { get; private set; }
        public int Forca { get; private set; }
        public int Estamina { get; private set; }
        public int Defesa { get; private set; }
        public int Health { get; private set; }

        public Item(string nome, int tipo,int dificuldade, int peso, int forca, int estamina, int defesa, int health)
        {
            Nome = nome;
            Tipo = tipo;
            Dificuldade = dificuldade;
            Peso = peso;
            Forca = forca;
            Estamina = estamina;
            Defesa = defesa;
            Health = health;
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}