using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsAndDinosaurs
{
    class Fleet
    {
        public List<Robot> robotFleetList;
        public int livingMembersCount;
        public string controller;
        public Robot currentAttacker;

        public Fleet(List<Robot> robotFleetList, string controller)
        {
            this.robotFleetList = robotFleetList;
            this.livingMembersCount = robotFleetList.Count;
            this.controller = controller;
            this.currentAttacker = robotFleetList[0];
        }

        public void Attack()
        {

        }
        
    }
}
