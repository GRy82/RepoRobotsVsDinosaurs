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
        public Weapon(string type)
        {
            this.type = type;
            switch (this.type) {
                case "Laser Gun":
                    this.attackPower = 10;
                    break;
                case "Energy Sword":
                    this.attackPower = 20;
                    break;
                case "Self-Destruct":
                    this.attackPower = 40;
                    break;
            }
        }
    }
}
