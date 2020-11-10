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
        public string leftTeam;
        public string rightTeam;
        

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
        }

        public void runBattle()
        {
            Random rand = new Random();
            int firstAttack = rand.Next(1);
            int turn = 1; //keeps track of who's turn it is. Odd number represents turns of first attacker. 
            while (herd.livingMembersCount > 0 && fleet.livingMembersCount > 0)
            {
                if (turn == 10) {
                    turn = 1;
                }
                Console.Clear();
                DisplayStaging();
                switch (firstAttack) {
                    case 1:
                        herd.Attack();
                        Console.Clear();
                        DisplayStaging();
                        fleet.Attack();
                        turn++;
                        break;
                    case 2:
                        fleet.Attack();
                        Console.Clear();
                        DisplayStaging();
                        herd.Attack();
                        turn++;
                        break;
                }
            }
            DisplayResultsModule();
        }

        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------
        //Display functions.
        void DisplayStaging()
        {
            //display team labels
            string characterSpaces = "              "; //14 spaces to allow for proper alignment.
            Console.WriteLine(characterSpaces + leftTeam + characterSpaces + rightTeam);
            //Display healthbars
            Console.WriteLine(characterSpaces + characterSpaces + " Health Bars  ");
            DisplayHealth();

            //display attributes: name, type, energy, attack power.
            string[,] dinoAttributes = new string[4, 3];
            for(int i = 0; i < herd.dinosaurHerdList.Count; i++)//load multidimensional dinosaur attributes array
            {
                dinoAttributes[0, i] = herd.dinosaurHerdList[i].name;
                dinoAttributes[1, i] = herd.dinosaurHerdList[i].type;
                dinoAttributes[2, i] = Convert.ToString(herd.dinosaurHerdList[i].energy);
                dinoAttributes[3, i] = Convert.ToString(herd.dinosaurHerdList[i].attackPower);
            }
            string[,] roboAttributes = new string[4, 3];
            for (int i = 0; i < fleet.robotFleetList.Count; i++)//load multidimensional robot attributes array
            {
                roboAttributes[0, i] = fleet.robotFleetList[i].name;
                roboAttributes[1, i] = fleet.robotFleetList[i].weapon.type;
                roboAttributes[2, i] = Convert.ToString(fleet.robotFleetList[i].powerLevel);
                roboAttributes[3, i] = Convert.ToString(fleet.robotFleetList[i].weapon.attackPower);
            }
            
            for (int i = 0; i < 4; i++)
            {
                DisplayAttribute(dinoAttributes[i], roboAttributes[i]);
            }
        }

        void DisplayHealth()
        {   //Dinosaur herd health bar creation
            double health1 = herd.dinosaurHerdList[0].health;
            double dinoHealthBars1 = Math.Round(health1 / 10);
            double health2 = herd.dinosaurHerdList[1].health;
            double dinoHealthBars2 = Math.Round(health2 / 10);
            double health3 = herd.dinosaurHerdList[2].health;
            double dinoHealthBars3 = Math.Round(health3 / 10);
            string dinosaurHealthString = null; 
            List<double> dinoHealthBars = new List<double> { dinoHealthBars1, dinoHealthBars2, dinoHealthBars3};
            for (int i = 0; i < dinoHealthBars.Count; i++) {
                double afterSpace = 10 - dinoHealthBars[i];
                dinosaurHealthString += " |";
                for (int j = 0; j < dinoHealthBars[j]; j++) {
                    dinosaurHealthString += "=";
                }
                for (int k = 0; k < afterSpace; k++) {
                    dinosaurHealthString += " ";
                }
                dinosaurHealthString += "| ";
            }
            //Robot fleed health bar creation
            double healthR1 = fleet.robotFleetList[0].health;
            double roboHealthBars1 = Math.Round(healthR1 / 10);
            double healthR2 = fleet.robotFleetList[1].health;
            double roboHealthBars2 = Math.Round(healthR2 / 10);
            double healthR3 = fleet.robotFleetList[2].health;
            double roboHealthBars3 = Math.Round(healthR3 / 10);
            string roboHealthString = null;
            List<double> roboHealthBars = new List<double> { roboHealthBars1, roboHealthBars2, roboHealthBars3 };
            for (int i = 0; i < roboHealthBars.Count; i++)
            {
                double afterSpace = 10 - roboHealthBars[i];
                roboHealthString += " |";
                for (int j = 0; j < roboHealthBars[j]; j++)
                {
                    roboHealthString += "=";
                }
                for (int k = 0; k < afterSpace; k++)
                {
                    roboHealthString += " ";
                }
                roboHealthString += "| ";
            }

            OrderAndPrint(dinosaurHealthString, roboHealthString);
        }


        void DisplayAttribute(string[] dinoAttribute, string[] roboAttribute)
        {
            string dinoNames = null;
            for (int i = 0; i < fleet.robotFleetList.Count; i++)
            {
                dinoNames += Centering(fleet.robotFleetList[i].name);
            }
            string roboNames = null;
            for (int i = 0; i < herd.dinosaurHerdList.Count; i++)
            {
                roboNames += Centering(herd.dinosaurHerdList[i].name);
            }
            OrderAndPrint(dinoNames, roboNames);
        }


        void DisplayWeaponOrType()
        {

        }

        string Centering(string initialString)
        {
            string newString = null;
            double leftSpace = 0;
            double rightSpace = 0;
            int emptySpace = 14 - initialString.Length;
            if (emptySpace % 2 == 0) {
                leftSpace = emptySpace / 2;
                rightSpace = leftSpace;
            }
            else {
                leftSpace = Convert.ToInt32(emptySpace / 2);
                rightSpace = emptySpace - leftSpace;
            }
            for (int i = 0; i < leftSpace; i++)
            {
                newString += " ";
            }
            newString += initialString;
            for (int j = 0; j < rightSpace; j++)
            {
                newString += " ";
            }
            return newString; 
        }

        void OrderAndPrint(string stringDino, string stringRobo)
        {
            if (leftTeam == "Dinosaurs") {
                Console.WriteLine(stringDino + stringRobo);
            }
            else {
                Console.WriteLine(stringRobo + stringDino);
            }
        }


        //------------------------------------------------------------------------------------
        void DisplayResultsModule()
        {

        }
        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------


    }
}
