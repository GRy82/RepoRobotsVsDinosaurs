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
        public string controller;

        public Robot(int powerLevel, Weapon weapon, string name, string controller)
        {
            this.powerLevel = powerLevel;
            this.weapon = weapon;
            this.health = 100;
            this.healthCapacity = 100;
            this.name = name;
            this.controller = controller;

        }

        public double Attack(Herd herd)
        {
            double attackValue;
            if (controller == "Human")
            {
                int attackOption = SelectAttackMenu();
                attackValue = SwitchAttack(attackOption, herd);
            }
            else {
                attackValue = RandomizeAttack(herd);
            }
            Random randAttack = new Random();
            double randomDeviation = attackValue * .15;
            randomDeviation = Math.Round(randomDeviation);
            int lowerLimit = Convert.ToInt32(attackValue - randomDeviation);
            int upperLimit = Convert.ToInt32(attackValue + randomDeviation);
            double resultantAttack = randAttack.Next(lowerLimit, upperLimit);
            return resultantAttack;
        }

        public double RandomizeAttack(Herd herd)
        {
            double attackValue;
            Random randAttack = new Random();
            int randomSkill = randAttack.Next(10);
            if (randomSkill >= 0 && randomSkill < 6)
            {
                attackValue = weapon.attackPower;
                powerLevel -= weapon.energyCost;
            }
            else if (randomSkill >= 7 && randomSkill < 9)
            {
                attackValue = 5;
            }
            else
            {
                attackValue = 0;
                health = 0;
                foreach (Dinosaur dinosaur in herd.dinosaurHerdList)
                {
                    dinosaur.health -= 30;
                }
            }

            double randomDeviation = .15 * attackValue;
            attackValue = randAttack.Next(Convert.ToInt32(attackValue - randomDeviation), Convert.ToInt32(attackValue + randomDeviation));
            return attackValue;
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
            Console.WriteLine("|" + weaponType +"|"+ damage + "|"+ cost + "|");
            Console.WriteLine("|     Melee    |" + meleeDamage + "|       0      |");
            Console.WriteLine("|Self-Destruct |" + selfDestructMessage + "|" + destructCost + "|");
            Console.WriteLine("|______________|______________|______________|");

        }

        public int SelectAttackMenu()
        {
            List<string> attackOptions = new List<string> { "Weapon attack", "Melee attack", "Self-Destruct"};
            ConsoleOptionsInterface attackMenu = new ConsoleOptionsInterface(attackOptions, false);
            Console.WriteLine("\nChoose how to attack.");
            int option = attackMenu.Launch();
            return option;
        }

        public double SwitchAttack(int attackOption, Herd herd)
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
                    foreach (Dinosaur dinosaur in herd.dinosaurHerdList)
                    {
                        dinosaur.health -= 30;
                        if(dinosaur.health <= 0)
                        {
                            dinosaur.health = 0;
                            herd.livingMembersCount -= 1;
                        }
                    }
                    return 0;
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
