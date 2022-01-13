using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Rows
    {
        private int id { get; set; }
        public List<Seats> seatList { get; set; }

        public Rows(int RowId, List<Seats> SeatList)
        {
            id = RowId;
            seatList = SeatList;
        }
        public override string ToString()
        {
            return "   ROW " + id;
        }


    }
}
