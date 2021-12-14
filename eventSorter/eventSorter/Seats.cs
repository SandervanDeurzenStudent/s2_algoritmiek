using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    class Seats
    {
        public int Id { get; set; }

        public int RowId { get; set; }

        public int Areaid { get; set; }

        public Seats(int id, int rowId, int areaId)
        {
            Id = id;
            RowId = RowId;
            Areaid = areaId;
        }
    }
}
