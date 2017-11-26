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
                
                return rnd.Next(this.Level * 5, this.Level * 10);
            }
        }
        public Inimigo(int id, string nome, int level): base(nome)
        {
            Random rnd = new Random();

            this.Level = level;

            this.Forca = rnd.Next(5, (10 + this.Level));
            this.Estamina = rnd.Next(5, (10 + this.Level));
            this.Defesa = rnd.Next(5, (10 + this.Level));
        }
        
    }
}
