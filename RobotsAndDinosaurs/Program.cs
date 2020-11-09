﻿using ProblemSolving1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (MainMenu()) {
                string chosenTeam = ChooseSidesMenu();
                List<string> playerTypesOrWeapons;
                List<string> computerTypesOrWeapons;
                if (chosenTeam == "Dinosaurs") {
                    playerTypesOrWeapons = DinosaurTypeSelection();
                    computerTypesOrWeapons = RandomTypeAssignment("Robots");
                }
                else {
                    playerTypesOrWeapons = RobotWeaponSelection();
                    computerTypesOrWeapons = RandomTypeAssignment("Dinosaurs");
                }
                Battlefield battlefield = LoadObjects(chosenTeam);
                battlefield.runBattle();
            }
        }

        public static Battlefield LoadObjects(string chosenTeam)
        {
            int mana = 100;
            string dinosaursController = "Human";
            string robotsController = "AI";

            if (chosenTeam == "Robots") {
                robotsController = "Human";
                dinosaursController = "AI";
            }

            Robot robotOne = new Robot(mana);
            Robot robotTwo = new Robot(mana);
            Robot robotThree = new Robot(mana);
            List<Robot> robotList = new List<Robot> { robotOne, robotTwo, robotThree };

            Dinosaur dinosaurOne = new Dinosaur(mana);
            Dinosaur dinosaurTwo = new Dinosaur(mana);
            Dinosaur dinosaurThree = new Dinosaur(mana);
            List<Dinosaur> dinosaurList = new List<Dinosaur> { dinosaurOne, dinosaurTwo, dinosaurThree };

            Fleet fleet = new Fleet(robotList, robotsController);
            Herd herd = new Herd(dinosaurList, dinosaursController);

            Battlefield battlefield = new Battlefield(herd, fleet);
            return battlefield;
        }

        public static bool MainMenu()
        {
            List<string> mainMenuList = new List<string> { "Start New Battle", "Exit Game" }; //main menu options stored as strings.
            ConsoleOptionsInterface mainMenu = new ConsoleOptionsInterface(mainMenuList, true); //menu generated through this menu object.
            
            Console.WriteLine("Welcome to Robots And Dinosaurs! by GRy-Dev");
            int optionNumber = mainMenu.Launch();
            if (optionNumber == 1) {
                return true;
            }
            return false;
        }

        public static string ChooseSidesMenu()
        {
            List<string> sidesList = new List<string> { "Dinosaurs", "Robots" }; //menu options stored as strings.
            ConsoleOptionsInterface sidesMenu = new ConsoleOptionsInterface(sidesList, false); //menu generated through this menu object.

            Console.WriteLine("Choose what side of the war you will join!");
            int numericTeam = sidesMenu.Launch();
            string teamName = "Dinosaurs";
            if (numericTeam == 2) {
                teamName = "Robots";
            }
            return teamName;
        }

        public static List<string> DinosaurTypeSelection()
        {
            List<string> dinoTypesMenuList = new List<string> { "T-Rex", "Velociraptor", "Brachiosaurus" }; //menu options stored as strings.
            ConsoleOptionsInterface dinoTypesMenu = new ConsoleOptionsInterface(dinoTypesMenuList, false); //menu generated through this menu object.

            List<string> dinoTypes = new List<string> { };

            Console.WriteLine("Each the 3 dinosaurs in your herd requires a type to be selected.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Choose type for dinosaur #" + i + 1);
                int dinoTypeChoice = dinoTypesMenu.Launch();
                switch (dinoTypeChoice)
                {
                    case 1:
                        dinoTypes[i] = "T-Rex";
                        break;
                    case 2:
                        dinoTypes[i] = "Velociraptor";
                        break;
                    case 3:
                        dinoTypes[i] = "Brachiosaurus";
                        break;
                }
            }

            return dinoTypes;

        }

        public static List<string> RobotWeaponSelection()
        {
            List<string> roboTypesMenuList = new List<string> { "Energy Sword", "Laser Gun", "Self-Destruct Switch" }; //menu options stored as strings.
            ConsoleOptionsInterface roboTypesMenu = new ConsoleOptionsInterface(roboTypesMenuList, false); //menu generated through this menu object.

            List<string> roboWeapons = new List<string> { };

            Console.WriteLine("Each the 3 robots in your fleet requires a weapon.");
            for (int i = 0; i < 3; i++) {
                Console.WriteLine("Choose weapon for Robot #" + i + 1);
                int weaponChoice = roboTypesMenu.Launch();
                switch (weaponChoice) {
                    case 1:
                        roboWeapons[i] = "Energy Sword";
                        break;
                    case 2:
                        roboWeapons[i] = "Laser Gun";
                        break;
                    case 3:
                        roboWeapons[i] = "Self-Destruct Switch";
                        break;
                }
            }

            return roboWeapons;
        }
    }

        public static List<string> RandomTypeAssignment(string team)
        {

        }
    }
}
