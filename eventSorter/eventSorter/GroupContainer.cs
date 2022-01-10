using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class GroupContainer
    {
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
