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
                Battlefield battlefield = LoadObjects();
                battlefield.runBattle();
            }
        }

        public static Battlefield LoadObjects()
        {
            Robot robotOne = new Robot();
            Robot robotTwo = new Robot();
            Robot robotThree = new Robot();
            List<Robot> robotList = new List<Robot> { robotOne, robotTwo, robotThree };

            Dinosaur dinosaurOne = new Dinosaur();
            Dinosaur dinosaurTwo = new Dinosaur();
            Dinosaur dinosaurThree = new Dinosaur();
            List<Dinosaur> dinosaurList = new List<Dinosaur> { dinosaurOne, dinosaurTwo, dinosaurThree };

            Fleet fleet = new Fleet(robotList);
            Herd herd = new Herd(dinosaurList);

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
    }
}
