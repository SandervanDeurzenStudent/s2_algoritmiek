using eventSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eventSorter_UnitTests.mockups
{
    public class EventMockups
    {
        public List<Guests> guestListWithParent = new List<Guests>();
        public List<Guests> guestListWithoutParent = new List<Guests>();
        public List<Guests> guestListOnlyParents = new List<Guests>();

        public List<Group> groupList = new List<Group>();
        public EventMockups()
        {
            //makeguestListwithParent
            guestListWithParent.Add(new Guests(1, 1, true, 1));
            guestListWithParent.Add(new Guests(2, 1, false, 1));
            guestListWithParent.Add(new Guests(3, 15, true, 2));
            guestListWithParent.Add(new Guests(4,  1, false, 2));
            //makeGuestListWithoutParent
            guestListWithoutParent.Add(new Guests(1,  1, true, 1));
            guestListWithoutParent.Add(new Guests(2, 1, false, 1));
            guestListWithoutParent.Add(new Guests(3,  1, true, 2));
            guestListWithoutParent.Add(new Guests(4,  1, false, 2));
            //makeGuestListWithoutParent
            guestListOnlyParents.Add(new Guests(1,  15, true, 1));
            guestListOnlyParents.Add(new Guests(2,  15, false, 1));
            guestListOnlyParents.Add(new Guests(3,  15, true, 2));
            guestListOnlyParents.Add(new Guests(4,  15, false, 2));

            groupList.Add(new Group(1, guestListWithParent));
         

        }
        public List<Group> MakeGroups(List<Guests> guestList)
        {
            int count = 0;
            List<Group> guestGroups = new List<Group>();

            for (int i = 0; i < guestList.Count; i++)
            {
                if (guestList[i].GroupId == count)
                {
                    guestGroups.Add(new Group(count, guestList.Where(x => x.GroupId == count).ToList()));
                    count++;
                }
            }
            return guestGroups;
        }
        
    }
}
