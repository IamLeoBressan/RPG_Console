using System;
using System.Collections.Generic;
using System.Text;
using RPG_New.Char;

namespace RPG_New.Inimigos
{
    class Inimigo : Character
    {
        public int Exp
        {
            get
            {
                Random rnd = new Random();
                
                return rnd.Next(this.Level * 2, this.Level * 5);
            }
        }
        public Inimigo(int id, string nome, int level): base(nome)
        {
            Random rnd = new Random();

            this.Level = level;

            this.Forca = rnd.Next(1, (8 + this.Level));
            this.Estamina = rnd.Next(1, (8 + this.Level));
            this.Defesa = rnd.Next(1, (8 + this.Level));
        }
        
    }
}
