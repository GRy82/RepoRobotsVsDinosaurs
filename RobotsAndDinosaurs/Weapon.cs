using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Weapon
    {
        public string type;
        public int attackPower;
        public int energyCost;
        public int meleeDamage;

        public Weapon(string type)
        {
            this.type = type;
            switch (this.type) {
                case "Laser Gun":
                    this.attackPower = 15;
                    this.energyCost = 5;
                    this.meleeDamage = 12;
                    break;
                case "Energy Sword":
                    this.attackPower = 25;
                    this.energyCost = 10;
                    this.meleeDamage = 10;
                    break;
                case "Flame Thrower":
                    this.attackPower = 40;
                    this.energyCost = 20;
                    this.meleeDamage = 5;
                    break;
            }
        }
    }
}
