using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    class Event
    {
        public int PlacesAvailable { get; set; }

        List<Area> areaList = new List<Area>();
        List<Area> areaList2 = new List<Area>();
        List<Guests> guestsList = new List<Guests>();

        public List<Area> makeAreas()
        {
            Random rnd = new Random();
            int rowsAmount = rnd.Next(1, 3);
            //making the areas with rows
            for (int i = 1; i < 3; i++)
            {
                //make the areas
                Area area = new Area(i, rnd.Next(2, 6));
                areaList.Add(area);
            }
            //Creating places in row 
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

        public List<Guests> makeGuests()
        {
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(1, 100); i++)
            {
                Guests guests = new Guests(i,  true, rnd.Next(1, 80), false);
                guestsList.Add(guests);
            }
            return guestsList;
        }

        public bool checkAvailability(List<Area> areaList, List<Guests> guestList)
        {
            int amountOfPlaces = 0;
            for (int i = 0; i < areaList.Count; i++)
            {
                for (int j = 0; j < areaList[i].amOfPlacesInRow; j++)
                {
                    amountOfPlaces++;
                }
            }
            if (guestList.Count > amountOfPlaces)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
