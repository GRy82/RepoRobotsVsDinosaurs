﻿using System;
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
            Random rand = new Random();
            int firstAttack = rand.Next(1);//Randomizes who attacks first.
            string lastAttacking = "Dinosaurs";
            if (firstAttack == 0) {
                lastAttacking = "Robots";
            }
            while (herd.livingMembersCount > 0 && fleet.livingMembersCount > 0)
            {
                DisplayStaging();
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
                    double attack = fleet.Attack(target);
                    herd.TakeDamage(attack, target);
                    lastAttacking = "Robots";
                }
            }
            DisplayResultsModule();
        }
        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------
      
        //Display functions.
        void DisplayStaging()
        {
            //create top table border
            for (int i = 0; i < 14; i++) {
                Console.Write("_______");//7 underscores per segment
            }
            Console.Write("_\n");
            //display team labels
            string characterSpaces = "              "; //14 spaces to allow for proper alignment.
            Console.WriteLine("|" + characterSpaces + characterSpaces + leftTeam + characterSpaces + characterSpaces + rightTeam + characterSpaces + "|");
            //Display healthbars
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

            string[] attributeHeaders = new string[4] { "Name", "Weapon/type", "Energy", "Attack Power" };
            
            DisplayAttributes(attributeHeaders, dinoAttributes, roboAttributes);
            //create bottom table border
            Console.Write("|");
            for (int i = 0; i < 14; i++)
            {
                Console.Write("_______");//7 underscores per segment
            }
            Console.Write("|\n");
            Console.WriteLine("\n"); 
        }
        //Dinosaur herd  and robot fleet health bar creation and display.
        void DisplayHealth()
        {   //Dinosaur herd health bar creation
            //1 health bar will represent 1/10 of their health.
            //Construct list of number of health bars foreach dinosaur.
            List<double> dinoHealthBars = new List<double> { };
            for (int l = 0; l < herd.dinosaurHerdList.Count; l++) {
                double tenthOftotalHealth = herd.dinosaurHerdList[l].healthCapacity / 10;
                double dinoHealthBar = herd.dinosaurHerdList[l].health / tenthOftotalHealth;
                if (herd.dinosaurHerdList[l].health < 5 && herd.dinosaurHerdList[l].health > 0)
                {
                    dinoHealthBar = 1;
                }
                dinoHealthBar = Math.Round(dinoHealthBar);
                dinoHealthBars.Add(dinoHealthBar);
            }
            //string to be added to and later printed.
            string dinosaurHealthString = null; 
            //construct string.
            for (int i = 0; i < dinoHealthBars.Count; i++) {           
                double afterSpace = 10 - dinoHealthBars[i];
                dinosaurHealthString += " |";
                for (int j = 0; j < dinoHealthBars[i]; j++) {
                    dinosaurHealthString += "=";
                }
                for (int k = 0; k < afterSpace; k++) {
                    dinosaurHealthString += " ";
                }
                dinosaurHealthString += "| ";
            }
            //Robot fleet health bar creation. Previous steps repeated.
            List<double> roboHealthBars = new List<double> { };
            for (int l = 0; l < fleet.robotFleetList.Count; l++)
            {
                double tenthOftotalHealth = 10;
                double roboHealthBar = fleet.robotFleetList[l].health / tenthOftotalHealth;
                if (fleet.robotFleetList[l].health < 5 && fleet.robotFleetList[l].health > 0)
                {
                    roboHealthBar = 1;
                }
                roboHealthBar = Math.Round(roboHealthBar);
                roboHealthBars.Add(roboHealthBar);
            }
            string roboHealthString = null;

            for (int i = 0; i < roboHealthBars.Count; i++)
            {
                double afterSpace = 10 - roboHealthBars[i];
                roboHealthString += " |";
                for (int j = 0; j < roboHealthBars[i]; j++)
                {
                    roboHealthString += "=";
                }
                for (int k = 0; k < afterSpace; k++)
                {
                    roboHealthString += " ";
                }
                roboHealthString += "| ";
            }
            
            OrderAndPrint("Health", dinosaurHealthString, roboHealthString);
        }

        //Responsible for construting the strings for a row of a single attribute. 
        void DisplayAttributes(string[] attributeHeaders, string[,] dinoAttribute, string[,] roboAttribute)
        {
            for (int j = 0; j < 4; j++)
            {//hard coded for the 4 different attributes displayed. This could change at some point
                string dinoAttributeString = null;//Reset these at the start of each iteration of outer for-loop.
                string roboAttributeString = null; 
                for (int i = 0; i < herd.dinosaurHerdList.Count; i++)
                {
                    dinoAttributeString += Centering(dinoAttribute[j, i]); //add dino
                }
                for (int i = 0; i < fleet.robotFleetList.Count; i++)
                {
                    roboAttributeString += Centering(roboAttribute[j, i]);
                }
                OrderAndPrint(attributeHeaders[j], dinoAttributeString, roboAttributeString);
            }
        }
        //centers the attribute with the correct amount of spacing around so it can be 
        //used to create oragnized table.
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
        //Puts the strings together in single line. Whichever team represents the use gets placed 
        //on the left half of the table.
        void OrderAndPrint(string rowName, string stringDino, string stringRobo)
        {
            rowName = Centering(rowName);
            Console.Write("|");
            Console.Write(rowName);
            if (herd.controller == "Human") {
                Console.Write(stringDino + stringRobo);
            }
            else {
                Console.Write(stringRobo + stringDino);
            }
            Console.WriteLine("|");
        }


        //------------------------------------------------------------------------------------
        void DisplayResultsModule()
        {
            string winningTeam = "Dinosaurs";
            string extraPhrase = "For the dinosaurs, it was a walk in the jurassic park. The robots will require expensive repairs.\n\n";
            if (herd.livingMembersCount == 0)
            {
                winningTeam = "Robots";
                extraPhrase = "Look at them all doing 'The Robot' and 'The Robo-boogie' while the losing team nurses their dino-sores.\n\n";
            }
            Console.WriteLine("\nThe winning team is the " + winningTeam + "!!!\n");
            Console.WriteLine(extraPhrase);

            Console.WriteLine("Press 'enter' to continue...");
            Console.ReadLine();
        }
        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------


    }
}
