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
        public int health;
        public int powerLevel;
        public Weapon weapon;

        public Robot(int powerLevel, Weapon weapon, string name)
        {
            this.powerLevel = powerLevel;
            this.weapon = weapon;
            this.health = 100;
            this.name = name;
        }

        Attack()
        {

        }
    }
}
