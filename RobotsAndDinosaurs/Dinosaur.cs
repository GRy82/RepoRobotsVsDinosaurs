using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Dinosaur
    {
        string type;
        int health;
        int energy;
        int attackPower;

        public Dinosaur(int energy, string type)
        {
            this.energy = energy;
            this.type = type;
            switch (this.type) {
                case "T-Rex":
                    this.health = 100;
                    this.attackPower = 20;
                    break;
                case "Velociraptor":
                    this.health = 60;
                    this.attackPower = 50;
                    break;
                case "Bronchiosaurus":
                    this.health = 150;
                    this.attackPower = 10;
                    break;
            }
        }

        Attack()
        {

        }
    }
}
