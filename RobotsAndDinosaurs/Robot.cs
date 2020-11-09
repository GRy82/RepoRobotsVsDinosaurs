using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Robot
    {
        string name;
        int health;
        int powerLevel;
        Weapon weapon;

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
