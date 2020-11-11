using ProblemSolving1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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
                Battlefield battlefield = LoadObjects(chosenTeam, playerTypesOrWeapons, computerTypesOrWeapons);
                Console.Clear();
                battlefield.RunBattle();
            }
        }

        public static Battlefield LoadObjects(string chosenTeam, List<string> playerTypesOrWeapons, List<string> computerTypesOrWeapons)
        {
            int mana = 100;
            string dinosaursController = "Human";
            string robotsController = "AI";
            List<string> weaponTypes = computerTypesOrWeapons;
            List<string> dinosaurTypes = playerTypesOrWeapons;

            if (chosenTeam == "Robots") {
                robotsController = "Human";
                dinosaursController = "AI";
                weaponTypes = playerTypesOrWeapons;
                dinosaurTypes = computerTypesOrWeapons;
            }

            Weapon weaponOne = new Weapon(weaponTypes[0]);
            Weapon weaponTwo = new Weapon(weaponTypes[1]);
            Weapon weaponThree = new Weapon(weaponTypes[2]);

            Robot robotOne = new Robot(mana, weaponOne, "ModelA", robotsController);
            Robot robotTwo = new Robot(mana, weaponTwo, "ModelB", robotsController);
            Robot robotThree = new Robot(mana, weaponThree, "ModelC", robotsController);
            List<Robot> robotList = new List<Robot> { robotOne, robotTwo, robotThree };

            Dinosaur dinosaurOne = new Dinosaur(mana, dinosaurTypes[0], dinosaursController);
            Dinosaur dinosaurTwo = new Dinosaur(mana, dinosaurTypes[1], dinosaursController);
            Dinosaur dinosaurThree = new Dinosaur(mana, dinosaurTypes[2], dinosaursController);
            List<Dinosaur> dinosaurList = new List<Dinosaur> { dinosaurOne, dinosaurTwo, dinosaurThree };

            Fleet fleet = new Fleet(robotList, robotsController);
            Herd herd = new Herd(dinosaurList, dinosaursController);

            herd.DetermineNames(); //assign dinosaurs names.

            Battlefield battlefield = new Battlefield(herd, fleet);

            return battlefield;
        }

        public static bool MainMenu()
        {
            List<string> mainMenuList = new List<string> { "Start New Battle" }; //main menu options stored as strings.
            ConsoleOptionsInterface mainMenu = new ConsoleOptionsInterface(mainMenuList, true); //menu generated through this menu object.
            
            Console.WriteLine("\n\nWelcome to Robots And Dinosaurs! by GRy-Dev");
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

            Console.WriteLine("\nChoose what side of the war you will join!");
            int numericTeam = sidesMenu.Launch();
            string teamName = "Dinosaurs";
            if (numericTeam == 2) {
                teamName = "Robots";
            }
            return teamName;
        }

        public static List<string> DinosaurTypeSelection()//Velociraptor has highest attack power. Brachiosaurus has greatest amount fo health.
        {                                                   //T-Rex is balanced.
            List<string> dinoTypesMenuList = new List<string> { "T-Rex", "Velociraptor", "Brachiosaurus" }; //menu options stored as strings.
            ConsoleOptionsInterface dinoTypesMenu = new ConsoleOptionsInterface(dinoTypesMenuList, false); //menu generated through this menu object.

            List<string> dinoTypes = new List<string> { };

            Console.WriteLine("\nEach of the 3 dinosaurs in your herd requires a type to be selected.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\nChoose type for dinosaur #" + (i + 1));
                int dinoTypeChoice = dinoTypesMenu.Launch();
                switch (dinoTypeChoice)
                {
                    case 1:
                        dinoTypes.Add("T-Rex");
                        break;
                    case 2:
                        dinoTypes.Add("Velociraptor");
                        break;
                    case 3:
                        dinoTypes.Add("Brachiosaurus");
                        break;
                }
            }
            return dinoTypes;
        }

        public static List<string> RobotWeaponSelection() //Flame thrower has greatest attack power, but powerLevel cost is commensurate.
        {                                                   //All weapons have melee attack available that does not use energy.
            List<string> roboTypesMenuList = new List<string> { "Energy Sword", "Laser Gun", "Flame Thrower" }; //menu options stored as strings.
            ConsoleOptionsInterface roboTypesMenu = new ConsoleOptionsInterface(roboTypesMenuList, false); //menu generated through this menu object.

            List<string> roboWeapons = new List<string> { };

            Console.WriteLine("\nEach of the 3 robots in your fleet requires a weapon.");
            for (int i = 0; i < 3; i++) {
                Console.WriteLine("\nChoose weapon for Robot #" + (i + 1));
                int weaponChoice = roboTypesMenu.Launch();
                switch (weaponChoice) {
                    case 1:
                        roboWeapons.Add("Energy Sword");
                        break;
                    case 2:
                        roboWeapons.Add("Laser Gun");
                        break;
                    case 3:
                        roboWeapons.Add("Flame Thrower");
                        break;
                }
            }

            return roboWeapons;
        }

        public static List<string> RandomTypeAssignment(string team)
        {
            List<string> randomTypes;
            List<string> computerTypes = new List<string> { };
            Random rand = new Random();
            if (team == "Dinosaurs")
            {
                randomTypes = new List<string> { "T-Rex", "Velociraptor", "Brachiosaurus" };
            }
            else
            {
                randomTypes = new List<string> { "Energy Sword", "Laser Gun", "Flame Thrower" };
            }
            for (int i = 0; i < 3; i++)
            {
                int randomType = rand.Next(3);
                computerTypes.Add(randomTypes[randomType]);
            }

            return computerTypes;
        }
    }
}
