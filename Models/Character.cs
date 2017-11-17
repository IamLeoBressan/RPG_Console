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
        public int FullHealth { get; private set; }
        public int RealHealth { get; private set; }
        public int STR { get; private set; }
        public int STA { get; private set; }
        public int DEX { get; private set; }
        public int AGI { get; private set; }
        public int LUK { get; private set; }
        public int INT { get; private set; }
        public Character(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Level = 1;
            this.Experience = 0;
            this.FullHealth = 100;
            this.RealHealth = 100;
            this.STR = 10;
            this.STA = 10;
            this.DEX = 10;
            this.AGI = 10;
            this.LUK = 10;
            this.INT = 10;
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
        public void AddExp(){

        }
        public string MenuSuperiorChar(){
            string aux = "Nome: " + this.Nome + " Level: " + this.Level + " Classe: " + this.Classe + " \n"
            + "Health: " + this.RealHealth + "/" + this.FullHealth + "   Experiência: " + this.Experience + "/" + this.NextLevelExp + "\n"
            + "--------------------------------------------------------------------------\n";
            return aux;
        }
        public string Descricao(){
            return "   ID: " + this.Id + " Nome: " + this.Nome;
        }
        public override string ToString(){
            return $"   ID: {this.Id}  Nome: {this.Nome}";
        }
    }
}
