using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{

    class Battlefield
    {
        Herd herd;
        Fleet fleet;

        public Battlefield(Herd herd, Fleet fleet)
        {
            this.herd = herd;
            this.fleet = fleet;
        }

        public void runBattle()
        {
            Random rand = new Random;
            int firstAttack = rand.Next(1);
            while (herd.livingMembersCount > 0 && fleet.livingMembersCount > 0)
            {
                DisplayBattleModule();
                switch (firstAttack) {
                    case 1:
                        herd.Attack();
                        fleet.Attack();
                        break;
                    case 2:
                        fleet.Attack();
                        herd.Attack();
                        break;
                }
            }
            DisplayResultsModule();
        }

        void DisplayBattleModule()
        {

        }

        void DisplayResultsModule()
        {

        }


    }
}
