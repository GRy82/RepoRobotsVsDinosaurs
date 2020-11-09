using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Fleet
    {
        List<Robot> robotFleetList;
        int LivingMembersCount;

        public Fleet(List<Robot> robotFleetList)
        {
            this.robotFleetList = robotFleetList;
            this.LivingMembersCount = robotFleetList.Count;
        }
    }
}
