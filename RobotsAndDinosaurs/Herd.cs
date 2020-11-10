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

        public Herd(List<Dinosaur> dinosaurHerdList, string controller)
        {
            this.dinosaurHerdList = dinosaurHerdList;
            this.livingMembersCount = dinosaurHerdList.Count;
            this.controller = controller;
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
