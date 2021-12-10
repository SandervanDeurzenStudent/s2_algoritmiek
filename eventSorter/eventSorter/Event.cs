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
        List<Group> groupList = new List<Group>();


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
            for (int i = 0; i < rnd.Next(10, 100); i++)
            {
                //een 40% kans of de guest niet op tijd is
                if (rnd.Next(0, 100) < 40)
                {
                    Guests guests = new Guests(i, true, rnd.Next(1, 13), false, 0);
                    guestsList.Add(guests);
                }
                else
                {
                    Guests guests = new Guests(i, true, rnd.Next(1, 13), true, 0);
                    guestsList.Add(guests);
                }
            }

            //gebruikers die onder 12 jaar zijn, wordt de isAdult op false gezet
            for (int i = 0; i < guestsList.Count; i++)
            {
                if (guestsList[i].Age < 13)
                {
                    guestsList[i].IsAdult = false;
                }

                if (guestsList[i].OnTime == false)
                {
                    guestsList.RemoveAt(i);
                }
            }
            return guestsList;
        }

        public bool checkAvailability(List<Area> areaList, List<Guests> guestList)
        {
            //check of alle bezoekers een plaats hebben
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

        public Group[] FormGroupsAndExtract(List<Guests> guestList)
        {
            Random _random = new Random();
            int originalGuests = guestList.Count;
            int groupId = 1;
            int maxGroupSize = 5;
            List<Group> guestGroups = new List<Group>();

            while (guestList.Count > maxGroupSize && guestList.Count > originalGuests / 10)
            {
                bool GroupHasAdult = false;
                int groupSize = _random.Next(2, maxGroupSize);
                Guests[] members = new Guests[groupSize];
                for (int i = 0; i < groupSize; i++)
                {
                    Guests guest = guestList[_random.Next(guestList.Count)];
                    if (guest.IsAdult == true)
                    {
                        GroupHasAdult = true;
                    }
                    members[i] = guest;
                    members[i].GroupId = groupId;
                    guestList.Remove(guest);
                }

                guestGroups.Add(new Group ( groupId, maxGroupSize, groupSize, GroupHasAdult, members));
                groupId++;
            }
            //exclude al groups without an adult 

            return guestGroups.ToArray();
        }

        public void FormSeats(List<Guests> guestList, List<Group> groupList, List<Area> areaList)
        {
            int amountOfPlaces = 0;
            for (int i = 0; i < areaList.Count; i++)
            {
                for (int j = 0; j < areaList[i].amOfPlacesInRow; j++)
                {
                    amountOfPlaces++;
                }
            }
        }
    }
}
