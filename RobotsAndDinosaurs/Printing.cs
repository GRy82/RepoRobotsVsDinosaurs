using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Printing
    {
        Battlefield battlefield;

        public Printing(Battlefield battlefield)
        {
            this.battlefield = battlefield;
        }

        public void DisplayStaging()
        {
            //create top table border
            for (int i = 0; i < 14; i++)
            {
                Console.Write("_______");//7 underscores per segment
            }
            Console.Write("_\n");
            //display team labels
            string characterSpaces = "              "; //14 spaces to allow for proper alignment.
            Console.WriteLine("|" + characterSpaces + characterSpaces + battlefield.leftTeam + characterSpaces + characterSpaces + battlefield.rightTeam + characterSpaces + "|");
            //Display healthbars
            DisplayHealth();

            //display attributes: name, type, energy, attack power.
            string[,] dinoAttributes = new string[4, 3];
            for (int i = 0; i < battlefield.herd.dinosaurHerdList.Count; i++)//load multidimensional dinosaur attributes array
            {
                dinoAttributes[0, i] = battlefield.herd.dinosaurHerdList[i].name;
                dinoAttributes[1, i] = battlefield.herd.dinosaurHerdList[i].type;
                dinoAttributes[2, i] = Convert.ToString(battlefield.herd.dinosaurHerdList[i].energy);
                dinoAttributes[3, i] = Convert.ToString(battlefield.herd.dinosaurHerdList[i].attackPower);
            }
            string[,] roboAttributes = new string[4, 3];
            for (int i = 0; i < battlefield.fleet.robotFleetList.Count; i++)//load multidimensional robot attributes array
            {
                roboAttributes[0, i] = battlefield.fleet.robotFleetList[i].name;
                roboAttributes[1, i] = battlefield.fleet.robotFleetList[i].weapon.type;
                roboAttributes[2, i] = Convert.ToString(battlefield.fleet.robotFleetList[i].powerLevel);
                roboAttributes[3, i] = Convert.ToString(battlefield.fleet.robotFleetList[i].weapon.attackPower);
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
        public void DisplayHealth()
        {   //Dinosaur herd health bar creation
            //1 health bar will represent 1/10 of their health.
            //Construct list of number of health bars foreach dinosaur.
            List<double> dinoHealthBars = new List<double> { };
            for (int l = 0; l < battlefield.herd.dinosaurHerdList.Count; l++)
            {
                double tenthOftotalHealth = battlefield.herd.dinosaurHerdList[l].healthCapacity / 10;
                double dinoHealthBar = battlefield.herd.dinosaurHerdList[l].health / tenthOftotalHealth;
                if (battlefield.herd.dinosaurHerdList[l].health < 5 && battlefield.herd.dinosaurHerdList[l].health > 0)
                {
                    dinoHealthBar = 1;
                }
                dinoHealthBar = Math.Round(dinoHealthBar);
                dinoHealthBars.Add(dinoHealthBar);
            }
            //string to be added to and later printed.
            string dinosaurHealthString = null;
            //construct string.
            for (int i = 0; i < dinoHealthBars.Count; i++)
            {
                double afterSpace = 10 - dinoHealthBars[i];
                dinosaurHealthString += " |";
                for (int j = 0; j < dinoHealthBars[i]; j++)
                {
                    dinosaurHealthString += "=";
                }
                for (int k = 0; k < afterSpace; k++)
                {
                    dinosaurHealthString += " ";
                }
                dinosaurHealthString += "| ";
            }
            //Robot fleet health bar creation. Previous steps repeated.
            List<double> roboHealthBars = new List<double> { };
            for (int l = 0; l < battlefield.fleet.robotFleetList.Count; l++)
            {
                double tenthOftotalHealth = 10;
                double roboHealthBar = battlefield.fleet.robotFleetList[l].health / tenthOftotalHealth;
                if (battlefield.fleet.robotFleetList[l].health < 5 && battlefield.fleet.robotFleetList[l].health > 0)
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
        public void DisplayAttributes(string[] attributeHeaders, string[,] dinoAttribute, string[,] roboAttribute)
        {
            for (int j = 0; j < 4; j++)
            {//hard coded for the 4 different attributes displayed. This could change at some point
                string dinoAttributeString = null;//Reset these at the start of each iteration of outer for-loop.
                string roboAttributeString = null;
                for (int i = 0; i < battlefield.herd.dinosaurHerdList.Count; i++)
                {
                    dinoAttributeString += Centering(dinoAttribute[j, i]); //add dino
                }
                for (int i = 0; i < battlefield.fleet.robotFleetList.Count; i++)
                {
                    roboAttributeString += Centering(roboAttribute[j, i]);
                }
                OrderAndPrint(attributeHeaders[j], dinoAttributeString, roboAttributeString);
            }
        }
        //centers the attribute with the correct amount of spacing around so it can be 
        //used to create oragnized table.
        public string Centering(string initialString)
        {
            string newString = null;
            double leftSpace = 0;
            double rightSpace = 0;
            int emptySpace = 14 - initialString.Length;
            if (emptySpace % 2 == 0)
            {
                leftSpace = emptySpace / 2;
                rightSpace = leftSpace;
            }
            else
            {
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
        public void OrderAndPrint(string rowName, string stringDino, string stringRobo)
        {
            rowName = Centering(rowName);
            Console.Write("|");
            Console.Write(rowName);
            if (battlefield.herd.controller == "Human")
            {
                Console.Write(stringDino + stringRobo);
            }
            else
            {
                Console.Write(stringRobo + stringDino);
            }
            Console.WriteLine("|");
        }


        //------------------------------------------------------------------------------------
        public void DisplayResultsModule()
        {
            string winningTeam = "Dinosaurs";
            string extraPhrase = "For the dinosaurs, it was a walk in the jurassic park. The robots will require expensive repairs.\n\n";
            if (battlefield.herd.livingMembersCount == 0)
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
