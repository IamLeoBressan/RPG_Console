using System;
using System.Collections.Generic;
using RPG_New.Itens;

namespace RPG_New.Char
{
    class Heroi : Character
    {
        public string Classe = "Aprendiz";
        public int Atributos { get; protected set; } = 0;
        public int Experience { get; protected set; }
        public Mochila Mochila = new Mochila();
        public Cinto Cinto = new Cinto();        
        public int NextLevelExp 
        {
            get
            {
                return Convert.ToInt32( Math.Pow(this.Level + 1, 2) * 10 );
            }
        }        
        public Heroi(string nome) : base(nome)
        {
            this.Experience = 0;
        }
        public void AddExp(int exp)
        {
            this.Experience += exp;

            if(this.Experience >= this.NextLevelExp)
            {
                this.Experience = this.Experience - this.NextLevelExp;
                this.LevelUp();
            }
        }        
        public virtual void LevelUp()
        {
            this.Atributos += 5;
            this.Level++;

            string menu =
                "1 - Forca\n" +
                "2 - Estamina\n" +
                "3 - Defesa\n" +
                "Digite o atributo desejado";

            while (this.Atributos > 0)
            {
                Console.Clear();
                Console.WriteLine($"Você passou para o Level {this.Level}");
                Console.WriteLine($"Você tem {this.Atributos} pontos para distribuir");
                Console.WriteLine(menu);

                string opcaoPrev = Console.ReadLine();

                int opcao = (opcaoPrev == ""?99:Convert.ToInt32(opcaoPrev));

                switch (opcao)
                {
                    case 1:
                        this.Forca ++;
                        this.Atributos--;
                        break;
                    case 2:
                        this.Estamina ++;
                        this.Atributos--;
                        break;
                    case 3:
                        this.Defesa ++;
                        this.Atributos--;
                        break;
                    default:
                        Console.WriteLine("Opção invalida, tente novamente");
                        break;
                }
            }
            
            this.RealHealth = this.FullHealth;
            System.Console.WriteLine("Pontos Distribuidos com sucesso");

        }        
        public string MenuSuperior()
        {
            string aux = $"Nome: {this.Nome} Level: {this.Level} \n"
                + $"Health: {this.RealHealth}/{this.FullHealth}   Experiência: {this.Experience}/{this.NextLevelExp}\n"
                + "--------------------------------------------------------------------------\n";
            return aux;
        }        
        public string PerfilCompleto()
        {
            return $"Nome: {this.Nome} Level: {this.Level} \n"
                + $"Health: {this.RealHealth}/{this.FullHealth}   Experiência: {this.Experience}/{this.NextLevelExp}\n"
                + $"Itens no Cinto: {this.Cinto.ShowItens()}\n"
                + $"Item no topo da Mochila: {this.Mochila.UltimoItem()}\n"
                + "Atributos: \n"
                + $"   Força: {this.Forca}\n"
                + $"   Estamina: {this.Estamina}\n"
                + $"   Defesa: {this.Defesa}\n";

        }
    }
}
