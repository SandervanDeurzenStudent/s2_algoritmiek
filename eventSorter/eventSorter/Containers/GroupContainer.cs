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
        Group groupClass = new Group();
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
            groupList.RemoveAll(x => x.GuestList.Count - x.AmountOfChildrenInGroup == 0);
            groupList = groupList.OrderByDescending(x => x.AmountOfChildrenInGroup).ToList();
            //sorteer de groep van meeste kinderen naar minste X
            return groupList;
        }
    }
}
