using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Seats
    {
        public int Id { get; set; }
        public int RowId { get; set; }
        public int Areaid { get; set; }
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
    }
}
