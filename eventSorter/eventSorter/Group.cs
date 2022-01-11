using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Group
    {
        //lijst van guests
        //groep moet adult hebben
        public int GroupId { get; set; }
        public List<Guests> GuestList { get; set; }
        public int AmountOfChildrenInGroup { get; set; }

        private bool isAdded { get; set; }
        public List<Guests> guestsList = new List<Guests>();

        Guests guestClass = new Guests();
        public Group(int id,  List<Guests> guestList)
        {
            GroupId = id;
            GuestList = guestList;
        }
        public Group()
        {
        }
        public bool hasParent(Group guestGroup)
        {
            //if (guestClass.checkForAdult(guest) == true)
            //{
            //    GroupHasAdult = true;
            //}
            return true;
        }
        public List<Guests> makeGuests()
        {
            Random rnd = new Random();
            // maakt 20 tot 100 gasten aan
            for (int i = 1; i < rnd.Next(40, 101); i++)
            {
                //een 30% kans of de guest niet op tijd is
                if (rnd.Next(0, 100) < 30)
                {
                    Guests guests = new Guests(i, false, rnd.Next(1, 20), false, rnd.Next(0, 6));
                    guestsList.Add(guests);
                }
                else
                {
                    Guests guests = new Guests(i, false, rnd.Next(1, 20), true, rnd.Next(0, 6));
                    guestsList.Add(guests);
                }
            }

            //gebruikers die onder 12 jaar zijn, wordt de isAdult op false gezet
            for (int i = 0; i < guestsList.Count; i++)
            {
                guestClass.checkForAdult(guestsList[i]);
                //check if the guest is ontime
                if (guestClass.CheckForOnTime(guestsList[i]) == false)
                {
                    guestsList.RemoveAt(i);
                    i--;
                }
            }
            // Order by group_id -> ascending 
            guestsList = guestsList.OrderBy(x => x.GroupId).ToList();
            return guestsList;
        }
        
        public int CountChildrenInGroup(Group group)
        {
            return group.AmountOfChildrenInGroup;
        }
        public int CountAdultsInGroup(Group group)
        {
           
            return group.GuestList.Count - group.AmountOfChildrenInGroup;
        }
        public bool IsGroupAdded(Group group)
        {
            if (group.isAdded == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddGroup(Group group)
        {
            group.isAdded = true;
        }
    }
}
