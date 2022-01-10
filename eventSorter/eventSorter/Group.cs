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
        private int AmountOfChildrenInGroup { get; set; }

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
        public List<Group> CountChildrenInGroup(List<Group> groupList)
        {
            Guests guestClass = new Guests();
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
            //sorteer de groep van meeste kinderen naar minste X
            return groupList.OrderByDescending(x => x.AmountOfChildrenInGroup).ToList();
        }
    }
}
