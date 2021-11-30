using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    class Event
    {
        List<Area> areaList = new List<Area>();
        List<Area> areaList2 = new List<Area>();

        public List<Area> makeAreas()
        {
            Random rnd = new Random();
            int rowsAmount = rnd.Next(1, 3);

            for (int i = 1; i < 3; i++)
            {
                //make the areas
                Area area = new Area(i, rnd.Next(2, 6));
                areaList.Add(area);
            }
            //making the amount ofplaces
            for (int i = 0; i < areaList.Count; i++)
            {
                int PlacesInRow = rnd.Next(3, 10);
                for (int j = 0; j < areaList[i].amOfRows; j++)
                {
                    //make the rows
                    Area areas = new Area(areaList[i].id, areaList[i].amOfRows, PlacesInRow);
                    areaList2.Add(areas);
                }
            }
            return areaList2;
        }
    }
}
