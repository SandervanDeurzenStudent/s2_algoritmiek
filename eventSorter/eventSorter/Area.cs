using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Area
    {
        public int id { get; set; }
        public List<Rows> rowsList { get; set; }
        public Area(int AreaId, List<Rows> RowsList)
        {
            id = AreaId;
            rowsList = RowsList;
        }
        public Area()
        {

        }
        Group groupClass = new Group();
        public Area CheckIfFrontRowIsAvailable(Area area, Group group)
        {
            int amountOfTakenSeatsInFrontRow = 0;
            for (int seat = 0; seat < area.rowsList[0].seatList.Count; seat++)
            {
                if (area.rowsList[0].seatList[seat].seatTaken == true)
                {
                    amountOfTakenSeatsInFrontRow++;
                }

            }
            if (amountOfTakenSeatsInFrontRow <= groupClass.CountChildrenInGroup(group) && area.rowsList[0].seatList.Count >= groupClass.CountChildrenInGroup(group))
            {
                return area;
            }
            return null;
        }
    }
}
