using eventSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eventSorter_UnitTests.mockups
{
    public class GroupMockup
    {
        Guests guestClass = new Guests();
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
                    Guests guests = new Guests(i,rnd.Next(1, 20), false, rnd.Next(0, 10));
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
    }
}
