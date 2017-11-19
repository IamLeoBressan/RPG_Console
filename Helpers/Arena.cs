using RPG.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Helpers
{
    static class Arena
    {
        public static bool Fight(Character player, Monster monster)
        {
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
