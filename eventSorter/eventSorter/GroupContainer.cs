using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class GroupContainer
    {
        Guests guestClass = new Guests();
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
        public List<Group> SortGroupsInChildrenDesc(List<Group> groupList)
        {
            for (int i = 0; i < groupList.Count(); i++)
            {
                int amountOfChildrenInGroup = 0;
                for (int j = 0; j < groupList[i].GuestList.Count(); j++)
                {
                    if (guestClass.checkForAdult(groupList[i].GuestList[j]) == false)
                    {
                        amountOfChildrenInGroup++;
                    }
                }
                groupList[i].AmountOfChildrenInGroup = amountOfChildrenInGroup;
            }
            groupList = groupList.OrderByDescending(x => x.AmountOfChildrenInGroup).ToList();
            //sorteer de groep van meeste kinderen naar minste X
            return groupList;
        }
    }
}
