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
            int attackOption = SelectAttackMenu();
            double attackValue = SwitchAttack(attackOption);
            Random randAttack = new Random();
            double randomDeviation = attackValue * .15;
            randomDeviation = Math.Round(randomDeviation);
            int lowerLimit = Convert.ToInt32(attackValue - randomDeviation);
            int upperLimit = Convert.ToInt32(attackValue + randomDeviation);
            double resultantAttack = randAttack.Next(lowerLimit, upperLimit);
            return resultantAttack;
        }

        public void DisplayAttackTypes()
        {
            string weaponType = Centering(weapon.type);
            string damage = Centering(Convert.ToString(weapon.attackPower));
            string cost = Centering(Convert.ToString(weapon.energyCost));
            string meleeDamage = Centering(Convert.ToString(weapon.meleeDamage));
            string selfDestructMessage = Centering("30 per dino");
            string destructCost = Centering("100 health");
            Console.WriteLine("______________________________________________");
            Console.WriteLine("| Attack Type  |  weapon dmg  | Cost(energy) |");
            Console.WriteLine("|" + weaponType + damage + cost + "|");
            Console.WriteLine("|     Melee    |" + meleeDamage + "|       0      |");
            Console.WriteLine("|Self-Destruct |" + selfDestructMessage + "|" + destructCost + "|");
            Console.WriteLine("_______________|______________|______________|");

        }

        public int SelectAttackMenu()
        {
            List<string> attackOptions = new List<string> { "Weapon attack", "Melee attack", "Self-Destruct"};
            ConsoleOptionsInterface attackMenu = new ConsoleOptionsInterface(attackOptions, false);
            Console.WriteLine("\nChoose how to attack.");
            int option = attackMenu.Launch();
            return option;
        }

        public double SwitchAttack(int attackOption)
        {
            switch (attackOption)
            {
                case 1:
                    powerLevel -= weapon.energyCost;
                    return weapon.attackPower;  
                case 2:
                    return weapon.meleeDamage;                   
                case 3:
                    health = 0;
                    return 30;
                default:
                    return 0;
            }
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

    }
}
