using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace RobotsAndDinosaurs
{
    class Dinosaur
    {
        public string type;
        public double health;
        public double healthCapacity;
        public double energy;
        public double attackPower;
        public string name;
        public string controller;

        public Dinosaur(int energy, string type, string controller)
        {
            this.name = null;
            this.energy = energy;
            this.type = type;
            this.controller = controller;
            switch (this.type) {
                case "T-Rex":
                    this.healthCapacity = 100;
                    this.attackPower = 20;
                    break;
                case "Velociraptor":
                    this.healthCapacity = 60;
                    this.attackPower = 50;
                    break;
                case "Brachiosaurus":
                    this.healthCapacity = 150;
                    this.attackPower = 10;
                    break;
            }
            
            this.health = this.healthCapacity;
        }


        public double Attack()
        {
            double attackValue;
            if (controller == "Human")
            {
                int attackOption = SelectAttackMenu();
                attackValue = SwitchAttack(attackOption);
            }
            else
            {
                attackValue = RandomizeAttack();
            }
            Random randAttack = new Random();
            double randomDeviation = attackValue * .15;
            randomDeviation = Math.Round(randomDeviation);
            int lowerLimit = Convert.ToInt32(attackValue - randomDeviation);
            int upperLimit = Convert.ToInt32(attackValue + randomDeviation);
            double resultantAttack = randAttack.Next(lowerLimit, upperLimit);
            return resultantAttack;
        }

        public double RandomizeAttack()
        {
            double attackValue;
            Random randAttack = new Random();
            int randomSkill = randAttack.Next(10);
            if (randomSkill >= 0 && randomSkill < 6) {
                attackValue = attackPower;
                energy -= 10;
            }
            else if (randomSkill >= 7 && randomSkill < 9) {
                attackValue = attackPower * 1.2;
                energy -= 15;
            }
            else {
                attackValue = attackPower * 1.4;
                energy -= 20;
            }

            double randomDeviation = .15 * attackValue;
            attackValue = randAttack.Next(Convert.ToInt32(attackValue - randomDeviation), Convert.ToInt32(attackValue + randomDeviation));
            return attackValue;
        }

        public void DisplayAttackTypes()
        {
            Console.WriteLine("______________________________________________");
            Console.WriteLine("| Attack Type  | %-weapon dmg | Cost(energy) |");
            Console.WriteLine("|     Claw     |     100      |      10      |");
            Console.WriteLine("|     Bite     |     120      |      15      |");
            Console.WriteLine("|    Pounce    |     140      |      20      |");
            Console.WriteLine("|______________|______________|______________|");

        }

        public int SelectAttackMenu()
        {
            List<string> attackOptions = new List<string> { "Claw", "Bite", "Pounce" };
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
                    energy -= 10;
                    return attackPower;
                case 2:
                    energy -= 15;
                    return attackPower * 1.2;
                case 3:
                    energy -= 20;
                    return attackPower * 1.4;
                default:
                    return 0;
            }
        }
    }
}
