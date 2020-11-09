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

        public string DetermineName(Dinosaur dinosaurObject)
        {
            int check = 0;
            foreach (Dinosaur dinosaur in dinosaurHerdList)
            {
                if (dinosaurObject.type != dinosaur.name) {
                    check++;
                }
            }
            string dinosaurName = dinosaurObject.type;
            
           if (check < dinosaurHerdList.Count) {
                dinosaurName += Convert.ToString(dinosaurHerdList.Count - check);
           }
            return dinosaurName;
        }

        public Attack()
        {

        }
    }
}
