using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    class Rows
    {
        public int id { get; set; }
        public int amOfRows { get; set; }

        

        public Rows(int RowId, int RowSize)
        {
            id = RowId;
            amOfRows = RowSize;
        }
        // haal de lijst op van areas
        // for loop van het aantal rows van die lijst en daaruit een rnd van 3 tot 10 doen
    }
}
