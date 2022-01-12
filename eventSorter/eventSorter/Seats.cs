using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Seats
    {
        private int Id { get; set; }
        private int RowId { get; set; }
        private int Areaid { get; set; }
        public Guests Guest { get; set; }

        public Seats(int id, int rowId, int areaId)
        {
            Id = id;
            RowId = RowId;
            Areaid = areaId;
        }
        public Seats(int id, int rowId, int areaId, Guests guest)
        {
            Id = id;
            RowId = RowId;
            Areaid = areaId;
            Guest = guest;
        }

        public override string ToString()
        {
            return "     SEAT " + Id + "  " + Guest;
        }
    }
}
