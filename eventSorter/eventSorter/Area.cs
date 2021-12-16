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
    }
}
