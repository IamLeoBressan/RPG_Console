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
        public Item ItemEquipado { get; private set; }
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
            string aux = $"Nome: {this.Nome}    Level: {this.Level}    Item Equipado: {(ItemEquipado == null?"Vazio":ItemEquipado.Nome)}\n"
                + $"Health: {this.RealHealth}/{this.FullHealth}   Experiência: {this.Experience}/{this.NextLevelExp}\n"
                + $"Itens no Cinto: {this.Cinto.ShowItens()}\n"
                + $"Item no topo da Mochila: {this.Mochila.UltimoItem()}\n"
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
        public void BuscarItemMochila()
        {
            string menu = $"O item do topo da mochila é uma {Mochila.UltimoItem()}\n\n"
                + "O que deseja fazer ?\n"
                + "1 - Usar\n"
                + "2 - Descartar\n"
                + "3 - Cancelar ação\n";

            int option = 0;

            while(option < 1 || option > 3)
            {
                Console.Clear();
                System.Console.WriteLine(menu);
                string aux = Console.ReadLine();
                option = (aux == ""?0:Convert.ToInt32(aux));
                
                switch(option){
                    case 1:
                        UsarItem(Mochila.PegarUltimoItem());
                        break;
                    case 2:
                        Mochila.PegarUltimoItem();
                        break;
                    case 3:
                        break;
                    default:
                        System.Console.WriteLine("Opção invalida, tente novamente.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public override int SimpleAtack()
        {
            Random rnd = new Random();

            int forca = this.Forca + (this.ItemEquipado == null?0:this.ItemEquipado.Forca);

            int atackStart = this.Forca / 2;
            int atackFim = this.Forca + (this.Forca /2);

            return Convert.ToInt32(rnd.Next(atackStart, atackFim));
        }
        public override string GetDamage(int ataque)
        {
            Random rnd = new Random();

            int defesa = this.Defesa + (this.ItemEquipado == null?0:this.ItemEquipado.Defesa);

            int defStart = defesa / 5;
            int defFim = defesa;

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
        public void BuscarItemCinto()
        {


        }
        public void UsarItem(Item item){
            if(item.Tipo == 1) // Equip
            {
                ItemEquipado = item;
            }
            else // Potes
            {
                GanharVida(item.Health);
            }
        }
    }
}
