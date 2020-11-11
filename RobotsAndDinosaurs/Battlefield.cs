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
        public Herd herd;
        public Fleet fleet;
        public string leftTeam;
        public string rightTeam;
        public int totalLivingEntities;
        public Battlefield(Herd herd, Fleet fleet)
        {
            this.herd = herd;
            this.fleet = fleet;
            if (this.herd.controller == "Human") {
                this.leftTeam = "  Dinosaurs   "; //2 space on the left side, 3 on right
                this.rightTeam = "    Robots    ";//4 spaces on either side
            }
            else {
                this.leftTeam = "    Robots    ";
                this.rightTeam = "   Dinosaurs  ";
            }
            this.totalLivingEntities = herd.livingMembersCount + fleet.livingMembersCount;
        }

        public void RunBattle()
        {
            Printing printing = new Printing(this);
            Random rand = new Random();
            int firstAttack = rand.Next(2);//Randomizes who attacks first.
            string lastAttacking = "Dinosaurs";
            if (firstAttack == 0) {
                lastAttacking = "Robots"; //Dinos go first
            }
            while (herd.livingMembersCount > 0 && fleet.livingMembersCount > 0)
            {
                //Start of 1 turn cycle--------------------------------------
                printing.DisplayStaging();
                int target;
                if (lastAttacking == "Robots") {
                    if (herd.controller == "Human") {
                        target = herd.SelectTarget(fleet);
                    }
                    else {
                        Console.WriteLine("Press 'enter' to continue...");
                        Console.ReadLine();
                        target = herd.AutomatedTargetSelection(fleet);
                    }
                    double attack = herd.Attack(target);
                    fleet.TakeDamage(attack, target);
                    lastAttacking = "Dinosaurs";
                }
                else if (lastAttacking == "Dinosaurs") {
                    if (fleet.controller == "Human") {
                        target = fleet.SelectTarget(herd);
                    }
                    else {
                        Console.WriteLine("Press 'enter' to continue...");
                        Console.ReadLine();
                        target = fleet.AutomatedTargetSelection(herd);
                    }
                    double attack = fleet.Attack(target, herd);
                    herd.TakeDamage(attack, target);
                    lastAttacking = "Robots";
                }
                //End of 1 turn cycle--------------------------------------
            }
            printing.DisplayResultsModule();
        }
    }
}
