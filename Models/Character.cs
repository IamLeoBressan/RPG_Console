using System;

namespace RPG
{
    class Character
    {
        public int Id;
        public string Nome;
        public int Level;
        public int Experience { get; private set; }
        public int NextLevelExp 
        {
            get
            {
                return Convert.ToInt32( Math.Pow(this.Level + 1, 2) * (10 * this.Level) );
            }
        }
        public string Classe = "Aprendiz";
        public int FullHealth
        {
            get
            {
                return this.STA * 10;
            }
        }
        public int RealHealth { get; protected set; }
        public int STR { get; protected set; }
        public int STA { get; protected set; }
        public int DEX { get; protected set; }
        public int AGI { get; protected set; }
        public int LUK { get; protected set; }
        public int INT { get; protected set; }
        public Character(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Level = 1;
            this.Experience = 0;
            this.STR = 10;
            this.STA = 10;
            this.DEX = 10;
            this.AGI = 10;
            this.LUK = 10;
            this.INT = 10;

            this.RealHealth = this.FullHealth;
        }
        public string FullDescr{
            get{
                string descr = ""
                + "Nome: " + this.Nome + "\n"
                + "Level: " + this.Level + "\n"
                + "Classe: " + this.Classe + "\n"
                + "STR: " + this.STR + "\n"
                + "STA: " + this.STA + "\n"
                + "DEX: " + this.DEX + "\n"
                + "AGI: " + this.AGI + "\n"
                + "LUK: " + this.LUK + "\n"
                + "INT: " + this.INT;

                return descr;
            }
        }
        public int SimpleAtack()
        {
            Random rnd = new Random();

            int atackStart = this.STR / 2;
            int atackFim = this.STR + (this.LUK + (this.LUK /2));

            return Convert.ToInt32(rnd.Next(atackStart, atackFim));
        }
        public string GetDamage(int ataque)
        {
            Random rnd = new Random();

            int defStart = this.AGI / 2;
            int defFim = this.AGI;

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
        public void AddExp(int exp){
            this.Experience += exp;

            if(this.Experience >= this.NextLevelExp)
            {
                this.Experience = this.Experience - this.NextLevelExp;
                this.Level++;
            }
        }
        public string MenuSuperiorChar(){
            string aux = "Nome: " + this.Nome + " Level: " + this.Level + " Classe: " + this.Classe + " \n"
            + "Health: " + this.RealHealth + "/" + this.FullHealth + "   Experiência: " + this.Experience + "/" + this.NextLevelExp + "\n"
            + "--------------------------------------------------------------------------\n";
            return aux;
        }
        public override string ToString(){
            return $"   ID: {this.Id}  Nome: {this.Nome}";
        }
    }
}
