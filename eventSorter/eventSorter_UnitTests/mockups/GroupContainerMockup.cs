using eventSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eventSorter_UnitTests.mockups
{
    class GroupContainerMockup
    {
        Guests guestClass = new Guests();
        public List<Group> MakeGroups(List<Guests> guestList)
        {
            List<Group> groups = new List<Group>();
            int allGroups = guestList.Select(x => x.GroupId).Distinct().Count();

            for (int i = 0; i < allGroups; i++)
            {
                //Adds users with group id to group until the next id  
                groups.Add(new Group
                {
                    GroupId = i,
                    GuestList = guestList.Where(x => x.GroupId == i).ToList(),

                });
            }

            groups = groups.OrderBy(x => x.GroupId).ToList();
            return groups;
        }
    }
}
