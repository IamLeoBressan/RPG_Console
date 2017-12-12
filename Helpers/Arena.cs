using System;
using System.Collections.Generic;
using System.Text;
using RPG_New.Inimigos;
using RPG_New.Char;

namespace RPG_New.Helpers
{
    static class Arena
    {
        public static bool Fight(Heroi player)
        {
            Inimigo monster = DataHelper.GetMonster(player.Level);


            Console.Clear();
            System.Console.WriteLine("Voce estava caminhando para a proxima sala quando ouve algo estranho no escuro\n");
            Console.WriteLine($"Um {monster.Nome} apareceu\n\n");
            Console.ReadLine();

            if(player.TemItens())
            {
                int option = 0;
                string menu = "O que deseja fazer ?\n"
                + "1 - Atacar\n"
                + "2 - Usar algum Item";

                
                while (option < 1 || option > 2)
                {
                    Console.WriteLine(menu);
                    string aux = Console.ReadLine();
                    option = (aux ==""?0:Convert.ToInt16(aux));
                    switch(option)
                    {
                        case 1:
                            break;
                        case 2:
                            player.EscolherItem();
                            break;
                        default:
                            System.Console.WriteLine("Opção invalida, tente novamente");
                            Console.ReadLine();
                            break;
                    }
                }
            }

            bool playerRound = true;
            while (player.RealHealth > 0 && monster.RealHealth > 0)
            {
                if (playerRound)
                {
                    Console.WriteLine(monster.GetDamage(player.SimpleAtack()));
                    playerRound = false;
                }
                else
                {
                    Console.WriteLine(player.GetDamage(monster.SimpleAtack()));
                    playerRound = true;
                }
            }

            player.RemoveItemEquipado();

            if(player.RealHealth <= 0)
            {
                return false;
            }
            else
            {
                player.AddExp(monster.Exp);

                return true;
            }

        }

    }
}
