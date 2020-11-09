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
                DisplayStage();
                switch (firstAttack) {
                    case 1:
                        herd.Attack();
                        Console.Clear();
                        DisplayStage();
                        fleet.Attack();
                        turn++;
                        break;
                    case 2:
                        fleet.Attack();
                        Console.Clear();
                        DisplayStage();
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
        void DisplayStage()
        {
            string characterSpaces = "              "; //14 spaces to allow for proper alignment.
            Console.WriteLine(characterSpaces + leftTeam + characterSpaces + rightTeam + characterSpaces);
            foreach )
        }


        //------------------------------------------------------------------------------------
        void DisplayResultsModule()
        {

        }
        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------


    }
}
