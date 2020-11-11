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

        public Dinosaur(int energy, string type)
        {
            this.name = null;
            this.energy = energy;
            this.type = type;
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
                    return attackPower;
                case 2:
                    return attackPower * 1.2;
                case 3:
                    return attackPower * 1.4;
                default:
                    return 0;
            }
        }
    }
}
