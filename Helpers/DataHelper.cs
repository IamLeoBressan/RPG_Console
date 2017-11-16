using System;
using System.Linq;
using System.Collections.Generic;

namespace RPG
{
    static class DataHelper
    {
        public static List<Character> GetChars(){

            List<Character> Chars = new List<Character>{
                new Character(0, "Leonardo"),
                new Character(1, "Wilmar"),
                new Character(2, "Felipe"),
                new Character(3, "Sophia"),
                new Character(4, "Marcos"),
                new Character(5, "Eduardo")
            };
            
            return Chars;
        }

    }

}