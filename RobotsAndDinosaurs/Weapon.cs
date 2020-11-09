using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Weapon
    {
        string type;
        int attackPower;
        public Weapon(string type)
        {
            this.type = type;
            switch (this.type) {
                case "laserGun":
                    this.attackPower = 10;
                    break;
                case "energySword":
                    this.attackPower = 20;
                    break;
            }
        }
    }
}
