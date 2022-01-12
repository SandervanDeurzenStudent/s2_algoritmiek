using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Area
    {
        private int id { get; set; }
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
            int amountOfOpenSeatsInFrontRow = 0;
            for (int seat = 0; seat < area.rowsList[0].seatList.Count; seat++)
            {
                if (area.rowsList[0].seatList[seat].Guest == null)
                {
                    amountOfOpenSeatsInFrontRow++;
                }
            }
            if (amountOfOpenSeatsInFrontRow >= groupClass.CountChildrenInGroup(group))
            {
                return area;
            }
            return null;
        }
        public Area CheckIfOtherRowsPlacesAreAvialable(Area area, Group group)
        {
            //check te remaining rows
            for (int rows = 1; rows < area.rowsList.Count; rows++)
            {
                int amountOfOpenPlacesInAreaMinusFrontRow = 0;
                for (int seat = 0; seat < area.rowsList[rows].seatList.Count; seat++)
                {
                    if (area.rowsList[rows].seatList[seat].Guest == null)
                    {
                        amountOfOpenPlacesInAreaMinusFrontRow++;
                    }
                }
                for (int i = 0; i < area.rowsList.Count; i++)
                {
                    if (amountOfOpenPlacesInAreaMinusFrontRow >= groupClass.CountAdultsInGroup(group))
                    {
                        return area;
                    }
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "AREA " + id;
        }
    }
}
