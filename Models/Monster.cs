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
        public void LevelUp(int lvl){
            this.Level = lvl;
        }
        public Monster(int id, string nome, int level): base(id, nome)
        {
            Random rnd = new Random();

            this.Level = level;

            this.STR = rnd.Next(1, (8 + this.Level));
            this.STA = rnd.Next(1, (8 + this.Level));
            this.DEX = rnd.Next(1, (8 + this.Level));
            this.AGI = rnd.Next(1, (8 + this.Level));
            this.LUK = rnd.Next(1, (8 + this.Level));
            this.INT = rnd.Next(1, (8 + this.Level));
        }
        
    }
}
