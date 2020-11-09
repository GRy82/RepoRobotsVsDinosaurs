using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Herd
    {
        List<Dinosaur> dinosaurHerdList;
        int LivingMembersCount;
        string controller;

        public Herd(List<Dinosaur> dinosaurHerdList, string controller)
        {
            this.dinosaurHerdList = dinosaurHerdList;
            this.LivingMembersCount = dinosaurHerdList.Count;
            this.controller = controller;
        }
    }
}
