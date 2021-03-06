using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class AreaContainer
    {
        public List<Area> MakeAreas()
        {
            List<Area> areaList = new List<Area>();
            Random rnd = new Random();
            //making the areas with rows
            for (int i = 0; i < rnd.Next(2,7); i++)
            {
                int numberOfSeats = rnd.Next(3, 11);
                List<Rows> RowsList = new List<Rows>();

                //make the Rows
                for (int j = 0; j < rnd.Next(2, 4); j++)
                {
                    List<Seats> SeatsList = new List<Seats>();
                    //make the seats
                    for (int k = 0; k < numberOfSeats; k++)
                    {
                        SeatsList.Add(new Seats(k));
                    }
                    RowsList.Add(new Rows(j, SeatsList));
                }
                areaList.Add(new Area(i, RowsList));
            }
            return areaList;
        }
    }
}
