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
        List<Guests> guestsList = new List<Guests>();
        List<Group> groupList = new List<Group>();
        List<Rows> RowsList = new List<Rows>();
        List<Seats> SeatsList = new List<Seats>();


        public List<Area> makeAreas()
        {
            Random rnd = new Random();
            //making the areas with rows

            for (int i = 1; i < rnd.Next(1, 10); i++)
            {
                //make the areas
                Area area = new Area(i, rnd.Next(1, 3));
                areaList.Add(area);
            }
            return areaList;
        }
        public List<Rows> makeRows(List<Area> areasList)
        {
            int rowId = 1;
            Random random = new Random();
            for (int i = 0; i < areasList.Count; i++)
            {
                for (int j = 0; j < areaList[i].amOfRows; j++)
                {
                    Rows rows = new Rows(rowId, random.Next(3, 10), areaList[i].id);
                    RowsList.Add(rows);
                    rowId++;
                }
            }
            return RowsList;
        }

        public List<Seats> makeSeats(List<Rows> rowsList)
        {
            int seatId = 1;
            Random random = new Random();
            for (int i = 0; i < rowsList.Count; i++)
            {
                for (int j = 0; j < rowsList[i].amOfPlacesInRow; j++)
                {
                    Seats seats = new Seats(seatId, rowsList[i].id, rowsList[i].areaId);
                    SeatsList.Add(seats);
                    seatId++;
                }
            }
            return SeatsList;
        }

        public List<Guests> makeGuests()
        {
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(20, 100); i++)
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

                //gebruikers die niet op tijd zijn, worden uit de lijst gezet
                if (guestsList[i].OnTime == false)
                {
                    guestsList.RemoveAt(i);
                }
            }
            return guestsList;
        }

        public bool checkAvailability(List<Rows> rowList, List<Guests> guestList)
        {
            //check of alle bezoekers een plaats hebben
            int amountOfPlaces = 0;
            for (int i = 0; i < rowList.Count; i++)
            {
                for (int j = 0; j < rowList[i].amOfPlacesInRow; j++)
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

                guestGroups.Add(new Group(groupId, maxGroupSize, groupSize, GroupHasAdult, members));
                groupId++;
            }
            //exclude al groups without an adult 

            return guestGroups.ToArray();
        }

        public void CountSeats(List<Guests> guestList, List<Group> groupList, List<Rows> rowList)
        {
            int amountOfPlaces = 0;
            for (int i = 0; i < rowList.Count; i++)
            {
                for (int j = 0; j < rowList[i].amOfPlacesInRow; j++)
                {
                    amountOfPlaces++;
                }
            }
        } 

        public int CountPlacesInFrontRow(List<Rows> rowList)
        {
            int amOfPlacesInFrontRow = 0;
            int areaId = 0;
            for (int i = 0; i < rowList.Count; i++)
            {
                if (RowsList[i].areaId != areaId)
                {
                    areaId = RowsList[i].areaId;
                    for (int j = 0; j < rowList[i].amOfPlacesInRow; j++)
                    {
                        amOfPlacesInFrontRow++;
                    }
                }
            }
            return amOfPlacesInFrontRow;
        }
    }
}
