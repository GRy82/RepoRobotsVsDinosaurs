using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Random randAttack = new Random();
            double randomDeviation = attackPower * .15;
            randomDeviation = Math.Round(randomDeviation);
            int lowerLimit = Convert.ToInt32(attackPower - randomDeviation);
            int upperLimit = Convert.ToInt32(attackPower + randomDeviation);
            double resultantAttack = randAttack.Next(lowerLimit, upperLimit);
            return resultantAttack;
        }



    }
}
