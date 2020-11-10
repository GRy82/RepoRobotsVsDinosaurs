using ProblemSolving1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Fleet
    {
        public List<Robot> robotFleetList;
        public int livingMembersCount;
        public string controller;
        public Robot currentAttacker;

        public Fleet(List<Robot> robotFleetList, string controller)
        {
            this.robotFleetList = robotFleetList;
            this.livingMembersCount = robotFleetList.Count;
            this.controller = controller;
            this.currentAttacker = robotFleetList[robotFleetList.Count - 1];
        }

        public double Attack(int opponentSelected)
        {
            double attack = currentAttacker.Attack();
            return attack;
        }

        public int AutomatedTargetSelection(Herd herd)
        {
            Random rand = new Random();
            double leastHealth = 100;
            Dinosaur target;
            int targetIndex = 0;
            int totalLiving = 0;
            foreach (Dinosaur dinosaur in herd.dinosaurHerdList)
            {
                if (dinosaur.health > 0)
                {
                    totalLiving++;
                    if (dinosaur.health < leastHealth)
                    {
                        leastHealth = dinosaur.health;
                        target = dinosaur;
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

        public int SelectTarget(Herd herd)
        {
            currentAttacker = DetermineAttacker(robotFleetList.IndexOf(currentAttacker));
            Console.WriteLine("It is now " + currentAttacker.name + "'s turn to attack. Choose their target.");
            List<string> opponentNames = GetDinosaurNames(herd);
            ConsoleOptionsInterface targetsMenu = new ConsoleOptionsInterface(opponentNames, false);
            int opponentSelected = targetsMenu.Launch();
            return opponentSelected;
        }

        public List<string> GetDinosaurNames(Herd herd)
        {
            List<string> opponentNames = new List<string> { };
            foreach (Dinosaur dinosaur in herd.dinosaurHerdList)
            {
                if (dinosaur.health > 0)
                {
                    opponentNames.Add(dinosaur.name);
                }
            }
            return opponentNames;
        }



        public Robot DetermineAttacker(int robotIndex)
        {
            robotIndex++;
            if (robotIndex >= robotFleetList.Count)
            {
                robotIndex = 0;
            }
            while (robotFleetList[robotIndex].health <= 0)
            {
                robotIndex++;
                if (robotIndex >= robotFleetList.Count)
                {
                    robotIndex = 0;
                }
            }
            return robotFleetList[robotIndex];
        }

        public void TakeDamage(double incomingDamage, int Target)
        {
            List<Robot> livingMembers = new List<Robot> { };
            Target -= 1;
            foreach(Robot robot in robotFleetList)
            {
                if (robot.health > 0)
                {
                    livingMembers.Add(robot);
                }
            }
            livingMembers[Target].health -= incomingDamage;
            if (livingMembers[Target].health < 0) {
                livingMembers[Target].health = 0;
                livingMembersCount -= 1;
                Console.WriteLine(livingMembers[Target].name + " has been killed.\n");
            }
            PrintAttackResult(incomingDamage, livingMembers[Target].name);
        }
        
        public void PrintAttackResult(double damageDone, string targetName)
        {
            Console.Clear();
            Console.WriteLine(targetName+ " was attacked for " + damageDone+ " damage\n\n");
          
        }
    }
}
