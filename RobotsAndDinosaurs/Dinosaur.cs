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
        public int health;
        public int energy;
        public int attackPower;
        public string name;

        public Dinosaur(int energy, string type)
        {
            this.name = null;
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

        string DetermineName()
        {
            return
        }

        Attack()
        {

        }
    }
}
