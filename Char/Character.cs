using System;
using System.Collections.Generic;

namespace RPG_New.Char
{
    class Character
    {
        public int Id;
        public string Nome;
        public int Level;
        public int FullHealth
        {
            get
            {
                return this.Estamina * 10;
            }
        }
        public int RealHealth { get; protected set; }
        public bool Lives 
        {
            get
            {
                return (this.RealHealth > 1 );
            }
        }
        public int Forca { get; protected set; }
        public int Estamina { get; protected set; }
        public int Defesa { get; protected set; }
        public Character(string nome)
        {
            this.Nome = nome;
            this.Level = 1;
            this.Estamina = 10;
            this.Forca = 10;
            this.Defesa = 10;
            this.RealHealth = this.FullHealth;
        }
        public void GanharVida(int vida)
        {
            RealHealth += vida;
            RealHealth = (RealHealth > FullHealth?FullHealth:RealHealth);
        }
        public virtual int SimpleAtack()
        {
            Random rnd = new Random();

            int atackStart = this.Forca / 2;
            int atackFim = this.Forca + (this.Forca /2);

            return Convert.ToInt32(rnd.Next(atackStart, atackFim));
        }
        public virtual string GetDamage(int ataque)
        {
            Random rnd = new Random();

            int defStart = this.Defesa / 5;
            int defFim = this.Defesa;

            int damage = ataque - rnd.Next(defStart, defFim);

            damage = (damage < 0 ? 0 : damage);

            this.RealHealth -= damage;

            string msg;

            if (RealHealth <= 0)
            {
                msg = $"{this.Nome} recebeu {damage} de dano e morreu";
            }
            else if(damage == 0)
            {
                msg = $"{this.Nome} bloqueou o ataque e não recebeu dano";
            }
            else
            {
                msg = $"{this.Nome} recebeu {damage} de dano e ficou com {this.RealHealth}";
            }

            return msg;
        }
        public override string ToString(){
            return $"Nome: {this.Nome}";
        }
    }
}
