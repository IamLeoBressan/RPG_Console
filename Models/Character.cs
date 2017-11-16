using System;

namespace RPG
{
    class Character
    {
        public int Id;
        public string Nome;
        public string Classe = "Aprendiz";
        public int STR { get; private set; }
        public int STA { get; private set; }
        public int DEX { get; private set; }
        public int AGI { get; private set; }
        public int LUK { get; private set; }
        public int INT { get; private set; }

        public string FullDescr{
            get{
                string descr = ""
                + "Nome: " + this.Nome + "\n"
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
        public Character(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            
            this.STR = 10;
            this.STA = 10;
            this.DEX = 10;
            this.AGI = 10;
            this.LUK = 10;
            this.INT = 10;
        }
        public string Descricao(){
            return "   ID: " + this.Id + " Nome: " + this.Nome;
        }
        public override string ToString(){
            return $"   ID: {this.Id}  Nome: {this.Nome}";
        }
    }
}
