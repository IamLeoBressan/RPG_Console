using System;
using System.Linq;
using System.Collections.Generic;
using RPG_New.Inimigos;

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

    }

}