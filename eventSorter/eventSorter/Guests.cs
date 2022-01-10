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
        private bool IsAdult { get; set; }
        private int Age { get; set; }
        private bool OnTime { get; set; }
        public int GroupId { get; set; }
        public int TakenSeatId { get; set; }

        public Guests()
        {

        }
        public Guests(int id, bool isAdult, int age, bool onTime, int groupId)
        {
            Id = id;
            IsAdult = isAdult;
            Age = age;
            OnTime = onTime;
            GroupId = groupId;
        }
        public override string ToString()
        {
            return "Guest " + Id + ": " + "On Time: " + OnTime + " - " + "Is Adult: " + IsAdult + " - " + "Group ID: " + GroupId + " takenSeatId " + TakenSeatId;
        }
        public bool checkForAdult(Guests guest)
        {
            if (guest.Age > 12)
            {
                guest.IsAdult = true;

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
