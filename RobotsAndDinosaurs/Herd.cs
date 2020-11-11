using ProblemSolving1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Herd
    {
        public List<Dinosaur> dinosaurHerdList;
        public int livingMembersCount;
        public string controller;
        public Dinosaur currentAttacker;

        public Herd(List<Dinosaur> dinosaurHerdList, string controller)
        {
            this.dinosaurHerdList = dinosaurHerdList;
            this.livingMembersCount = dinosaurHerdList.Count;
            this.controller = controller;
            this.currentAttacker = dinosaurHerdList[dinosaurHerdList.Count - 1];
        }


        public double Attack(int opponentSelected)
        {
            double attack = currentAttacker.Attack();
            return attack;
        }

        public int AutomatedTargetSelection(Fleet fleet)
        {
            currentAttacker = DetermineAttacker(dinosaurHerdList.IndexOf(currentAttacker));
            Random rand = new Random();
            double leastHealth = 100;
            Robot target;
            int targetIndex = 0;
            int totalLiving = 0;
            foreach (Robot robot in fleet.robotFleetList)
            {
                if (robot.health > 0) {
                    totalLiving++;//establishes how many there are to pick from, if you need to randomize.
                    if (robot.health < leastHealth)
                    {
                        leastHealth = robot.health;
                        target = robot;
                        targetIndex++; //not actual index, but "Living index"
                    }
                }
            }
            if (leastHealth == 100)
            {
                targetIndex = rand.Next(1, totalLiving + 1);
                return targetIndex;
            }
            else
            {
                return targetIndex;
            }
        }

        public int SelectTarget(Fleet fleet)
        {
            currentAttacker = DetermineAttacker(dinosaurHerdList.IndexOf(currentAttacker));
            Console.WriteLine("It is now " + currentAttacker.name + "'s turn to attack. Choose their target.");
            if (controller == "Human") {
                currentAttacker.DisplayAttackTypes();
            }
            List<string> opponentNames = GetRobotNames(fleet);
            ConsoleOptionsInterface targetsMenu = new ConsoleOptionsInterface(opponentNames, false);
            int opponentSelected = targetsMenu.Launch();
            return opponentSelected;
        }

        public List<string> GetRobotNames(Fleet fleet)
        {
            List<string> opponentNames = new List<string> { };
            foreach(Robot robot in fleet.robotFleetList)
            {
                if (robot.health > 0)
                {
                    opponentNames.Add(robot.name);
                }
            }
            return opponentNames;
        }



        public Dinosaur DetermineAttacker(int dinosaurIndex)
        {
            dinosaurIndex++;
            if (dinosaurIndex >= dinosaurHerdList.Count)
            {
                dinosaurIndex = 0;
            }
            while (dinosaurHerdList[dinosaurIndex].health <= 0)
            {
                dinosaurIndex++;
                if (dinosaurIndex >= dinosaurHerdList.Count)
                {
                    dinosaurIndex = 0;
                }
            }
            return dinosaurHerdList[dinosaurIndex];
        }

        public void TakeDamage(double incomingDamage, int Target)
        {
            List<Dinosaur> livingMembers = new List<Dinosaur>{ };
            Target -= 1;
            bool newDeath = false;
            foreach (Dinosaur dinosaur in dinosaurHerdList)
            {
                if (dinosaur.health > 0)
                {
                    livingMembers.Add(dinosaur);
                }
            }
            livingMembers[Target].health -= incomingDamage;
            if (livingMembers[Target].health <= 0) {
                livingMembers[Target].health = 0;
                livingMembersCount -= 1;
                newDeath = true;
            }
            if (incomingDamage != 0)  {
                PrintAttackResult(incomingDamage, livingMembers[Target].name, newDeath);
            }
            else {
                Console.Clear();
                Console.Write("\n\nSelf-Destruct was used. The herd was attacked for 30 damage each.  ");
                if (newDeath == true)  {
                    Console.WriteLine("Dinosaur life was lost.");
                }
                Console.WriteLine("\n");
            }

        }

        public void PrintAttackResult(double damageDone, string targetName, bool newDeath)
        {
            Console.Clear();
            Console.Write("\n\n" + targetName + " was attacked for " + damageDone + " damage.  ");
            if (newDeath == true) {
                Console.WriteLine(targetName + " has been killed.");
            }
            Console.WriteLine("\n");
        }


        //If multiple dinosaurs of same type exist, eg. 3 T-Rexes, they'll be named T-Rex, T-Rex1, T-Rex2
        public void DetermineNames()
        {
            List<Dinosaur> brachs = new List<Dinosaur> { };
            List<Dinosaur> raptors = new List<Dinosaur> { };
            List<Dinosaur> rexes = new List<Dinosaur> { };
            int brachCount = 0;
            int raptorCount = 0;
            int rexCount = 0;
            foreach (Dinosaur dinosaur in dinosaurHerdList)
            {
                if (dinosaur.type == "Brachiosaurus") {
                    brachCount++;
                    brachs.Add(dinosaur);
                }
                else if(dinosaur.type == "Velociraptor") {
                    raptorCount++;
                    raptors.Add(dinosaur);
                }
                else {
                    rexCount++;
                    rexes.Add(dinosaur);
                }
            }
            for (int i = 0; i < brachs.Count; i++){
                if (i == 0) {
                    brachs[i].name = brachs[i].type;
                }
                else {
                    brachs[i].name = brachs[i].type + Convert.ToString(i);
                }
            }
            for (int i = 0; i < raptors.Count; i++) {
                if (i == 0)
                {
                    raptors[0].name = raptors[0].type;
                }
                else
                {
                    raptors[i].name = raptors[i].type + Convert.ToString(i);
                }
            }
            for (int i = 0; i < rexes.Count; i++) {
                if (i == 0)
                {
                    rexes[0].name = rexes[0].type;
                }
                else
                {
                    rexes[i].name = rexes[i].type + Convert.ToString(i);
                }
            }

        }
    }
}
