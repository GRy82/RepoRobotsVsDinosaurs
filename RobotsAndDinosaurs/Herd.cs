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

        public Herd(List<Dinosaur> dinosaurHerdList)
        {
            this.dinosaurHerdList = dinosaurHerdList;
            this.LivingMembersCount = dinosaurHerdList.Count;
        }
    }
}
