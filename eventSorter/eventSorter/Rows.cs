using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Rows
    {
        public int id { get; set; }
        public int areaId { get; set; }
        public List<Seats> seatList { get; set; }

        public Rows(int RowId, List<Seats> SeatList, int AreaId)
        {
            id = RowId;
            seatList = SeatList;
            areaId = AreaId;
        }
        // haal de lijst op van areas
        // for loop van het aantal rows van die lijst en daaruit een rnd van 3 tot 10 doen
    }
}
