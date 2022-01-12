using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Guests
    {
        private int Id { get; set; }
        private int Age { get; set; }
        private bool OnTime { get; set; }
        public int GroupId { get; set; }

        public Guests()
        {

        }
        public Guests(int id, int age, bool onTime, int groupId)
        {
            Id = id;
            Age = age;
            OnTime = onTime;
            GroupId = groupId;
        }
        public override string ToString()
        {
            return "Guest " + Id + " - " + "Age: " + Age + " - " + "Group ID: " + GroupId;
        }
        public bool checkForAdult(Guests guest)
        {
            if (guest.Age > 12)
            {
                

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckForOnTime(Guests guest)
        {
            if (guest.OnTime == false)
            {
                return false;
            }
            else
            {
                return true;

            }
        }
    }
}
