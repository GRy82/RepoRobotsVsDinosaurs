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
        string controller;

        public Fleet(List<Robot> robotFleetList, string controller)
        {
            this.robotFleetList = robotFleetList;
            this.LivingMembersCount = robotFleetList.Count;
            this.controller = controller;
        }
    }
}
