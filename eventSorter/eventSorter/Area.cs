using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    class Area
    {
        public int id { get; set; }
        public int amOfRows { get; set; }
        public int amOfPlacesInRow { get; set; }

        public Area(int AreaId, int AreaSize)
        {
            id = AreaId;
            amOfRows = AreaSize;
        }
        public Area(int AreaId, int AreaSize, int amOfPlaces)
        {
            id = AreaId;
            amOfRows = AreaSize;
            amOfPlacesInRow = amOfPlaces;
        }

    }
}
