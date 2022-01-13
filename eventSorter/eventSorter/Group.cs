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
            for (int i = 0; i < guestGroup.GuestList.Count; i++)
            {
                if (guestClass.checkForAdult(guestGroup.GuestList[i]) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Guests> makeGuests()
        {
        List<Guests> guestsList = new List<Guests>();

        Random rnd = new Random();
            // maakt 40 tot 100 gasten aan
            for (int i = 1; i < rnd.Next(60, 140); i++)
            {
                //een 30% kans of de guest niet op tijd is
                if (rnd.Next(0, 100) < 30)
                {
                    Guests guests = new Guests(i, rnd.Next(1, 20), false, rnd.Next(0, 10));
                    guestsList.Add(guests);
                }
                else
                {
                    Guests guests = new Guests(i, rnd.Next(1, 20), true, rnd.Next(0, 10));
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
            int amountOfChildren = 0;
            for (int j = 0; j < group.GuestList.Count(); j++)
            {
                if (guestClass.checkForAdult(group.GuestList[j]) == false)
                {
                    amountOfChildren++;
                }
            }
            return amountOfChildren;
        }
        public int CountAdultsInGroup(Group group)
        {
            return group.GuestList.Count - CountChildrenInGroup(group);
        }
        public override string ToString()
        {
            return "Group " + GroupId + ": " + "Guests: " + GuestList.Count + " - " + "AmountOfChildren " + AmountOfChildrenInGroup;
        }
    }
}
