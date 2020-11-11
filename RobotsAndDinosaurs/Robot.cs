using ProblemSolving1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Robot
    {
        public string name;
        public double health;
        public double healthCapacity;
        public double powerLevel;
        public Weapon weapon;

        public Robot(int powerLevel, Weapon weapon, string name)
        {
            this.powerLevel = powerLevel;
            this.weapon = weapon;
            this.health = 100;
            this.healthCapacity = 100;
            this.name = name;
        }

        public double Attack()
        {
            DisplayAttackTypes();
            int attackOption = SelectAttackMenu();
            double attackValue;
            Random randAttack = new Random();
            double randomDeviation = weapon.attackPower * .15;
            randomDeviation = Math.Round(randomDeviation);
            int lowerLimit = Convert.ToInt32(weapon.attackPower - randomDeviation);
            int upperLimit = Convert.ToInt32(weapon.attackPower + randomDeviation);
            double resultantAttack = randAttack.Next(lowerLimit, upperLimit);
            return resultantAttack;
        }

        public void DisplayAttackTypes()
        {
            string weaponType = Centering(weapon.type);
            string damage = Centering(Convert.ToString(weapon.attackPower));
            string cost = Centering(Convert.ToString(weapon.energyCost));
            
            Console.WriteLine(" Attack Type  |  weapon dmg  | Cost(energy) ");
            Console.WriteLine(weaponType + damage + cost);
            Console.WriteLine("");

            
        }

        public string Centering(string initialString)
        {
            string newString = null;
            double leftSpace = 0;
            double rightSpace = 0;
            int emptySpace = 14 - initialString.Length;
            if (emptySpace % 2 == 0)
            {
                leftSpace = emptySpace / 2;
                rightSpace = leftSpace;
            }
            else
            {
                leftSpace = Convert.ToInt32(emptySpace / 2);
                rightSpace = emptySpace - leftSpace;
            }
            for (int i = 0; i < leftSpace; i++)
            {
                newString += " ";
            }
            newString += initialString;
            for (int j = 0; j < rightSpace; j++)
            {
                newString += " ";
            }
            return newString;
        }

        public int SelectAttackMenu()
        {
            ConsoleOptionsInterface attackMenu = new ConsoleOptionsInterface(weapon.type);
        }




    }
}
