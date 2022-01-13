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
        public List<Guests> make10000Guests()
        {
            List<Guests> guestsList = new List<Guests>();

            Random rnd = new Random();
            // maakt 40 tot 100 gasten aan
            for (int i = 1; i < 1000; i++)
            {
                //een 30% kans of de guest niet op tijd is
                if (rnd.Next(0, 100) < 30)
                {
                    Guests guests = new Guests(i, rnd.Next(1, 20), false, rnd.Next(0, 200));
                    guestsList.Add(guests);
                }
                else
                {
                    Guests guests = new Guests(i, rnd.Next(1, 20), true, rnd.Next(0, 200));
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
        public List<Guests> make8Guests4Adults4Children()
        {
            //return a guestList of 8 children and 8 adults. 
            //every group has 2 adults and 2 children
            //guest are all ontime 
            List<Guests> guestsList = new List<Guests>();
            //group1, 4 children, 4 adults
            guestsList.Add(new Guests(0, 14, true, 1));
            guestsList.Add(new Guests(1, 14, true, 1));
            guestsList.Add(new Guests(2, 10, true, 1));
            guestsList.Add(new Guests(3, 10, true, 1));
         
            //group 2
            guestsList.Add(new Guests(4, 14, true, 0));
            guestsList.Add(new Guests(5, 14, true, 0));
            guestsList.Add(new Guests(6, 10, true, 0));
            guestsList.Add(new Guests(7, 10, true, 0));
         

            return guestsList;
        }
    }
}
