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
        Rows RowsClass = new Rows();
        public Area CheckIfFrontRowIsAvailable(Area area, Group group)
        {
            if (RowsClass.CountFrontRowSeats(area.rowsList[0])>= groupClass.CountChildrenInGroup(group))
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
                    if (RowsClass.CountFrontRowSeats(area.rowsList[rows]) >= groupClass.CountAdultsInGroup(group))
                    {
                        return area;
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
