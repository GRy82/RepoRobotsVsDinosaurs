using ProblemSolving1;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
