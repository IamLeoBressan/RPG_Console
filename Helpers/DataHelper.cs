using System;
using System.Linq;
using System.Collections.Generic;
using RPG_New.Inimigos;
using RPG_New.Itens;

namespace RPG_New
{
    static class DataHelper
    {


        public static Inimigo GetMonster(int lvl)
        {
            Random rnd = new Random();

            List<Inimigo> inimigos = new List<Inimigo>
            {
                new Inimigo(0, "Ent",  lvl),
                new Inimigo(1, "Orc", lvl),
                new Inimigo(2, "Goblin", lvl),
                new Inimigo (3, "Golem", lvl),
                new Inimigo(4, "Duende", lvl),
                new Inimigo(5, "Harpia", lvl),
                new Inimigo(6, "Centauro", lvl),
                new Inimigo(7, "Troll", lvl),
                new Inimigo(8, "Ciclope", lvl),
                new Inimigo(9, "Elemental", lvl)
            };

            return inimigos[rnd.Next(0, inimigos.Count-1)];
        }

        public static Item GetItem()
        {
            Random rnd = new Random();

            List<Item> itens = new List<Item>
            {
                new Item("Pote de Vida Pequeno", 2, 1, 10, 0, 0, 0, 30),
                new Item("Pote de vida Médio", 2, 2, 10, 0, 0, 0, 60),
                new Item("Pote de vida Grande", 2, 3, 10, 0, 0, 0, 120),
                new Item("Espada de Madeira", 1, 1, 20, 5, 0, 0, 0),
                new Item("Espada de Aço", 1, 2, 20, 40, 0, 0, 0),
                new Item("Espada de Diamante", 1, 3, 30, 20, 0, 0, 0),
                new Item("Armadura de Madeira", 1, 1, 20, 0, 2, 3, 0),
                new Item("Armadura de Aço", 1, 2, 20, 0, 4, 6, 0),
                new Item("Armadura de Diamante", 1, 3, 20, 0, 8, 12, 0)

            };

            //Porcentagem para encontrar itens
            int facil = 70;
            int medio = 20;
            //Dificil = 10%

            int probItens = rnd.Next(1, 100);

            int dificuldade = (probItens < facil ? 1 : (probItens < (facil + medio) ? 2 : 3));

            List<Item> ListDificuldade = itens.Where(i => i.Dificuldade == dificuldade).ToList();

            return ListDificuldade[rnd.Next(0, ListDificuldade.Count - 1)];
            
        }

    }

}
