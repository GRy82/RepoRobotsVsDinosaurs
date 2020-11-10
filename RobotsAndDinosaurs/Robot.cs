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

        public double Attack(int opponentSelected)
        {
            Random randAttack = new Random();
            double randomDeviation = weapon.attackPower * .15;
            randomDeviation = Math.Round(randomDeviation);
            int lowerLimit = Convert.ToInt32(weapon.attackPower - randomDeviation);
            int upperLimit = Convert.ToInt32(weapon.attackPower + randomDeviation);
            double resultantAttack = randAttack.Next(lowerLimit, upperLimit);
            return resultantAttack;
        }


    }
}
