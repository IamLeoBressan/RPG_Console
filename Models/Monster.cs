using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Models
{
    class Monster : Character
    {
        public int Exp
        {
            get
            {
                Random rnd = new Random();
                
                return rnd.Next(this.Level * 5, this.Level * 20);
            }
        }

        public Monster(int id, string nome): base(id, nome)
        {
            Random rnd = new Random();

            this.STR = rnd.Next(1, 10);
            this.STA = rnd.Next(1, 10);
            this.DEX = rnd.Next(1, 10);
            this.AGI = rnd.Next(1, 10);
            this.LUK = rnd.Next(1, 10);
            this.INT = rnd.Next(1, 10);
        }
        
    }
}
