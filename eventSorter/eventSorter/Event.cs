using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
     public class Event
    {
        public int PlacesAvailable { get; set; }
        public List<Area> areaList = new List<Area>();

        public List<Group> groupList = new List<Group>();
        public List<Guests> guestsList = new List<Guests>();




        public List<Area> MakeAreas()
        {
            Random rnd = new Random();
            //making the areas with rows
            int i = 0;
            for ( i = 0; i < rnd.Next(2, 5); i++)
            {
                int numberOfSeats = rnd.Next(3, 10);
                List<Rows> RowsList = new List<Rows>();
                //make the Rows
                for (int j = 0; j < rnd.Next(1, 3); j++)
                {
                    List<Seats> SeatsList = new List<Seats>();
                    //make the seats
                    for (int k = 0; k < numberOfSeats; k++)
                    {
                        SeatsList.Add(new Seats(k, j, i));
                    }
                    Rows rows = new Rows(j, SeatsList, i);
                    RowsList.Add(rows);
                }
                areaList.Add(new Area(i, RowsList));
            }
            return areaList;
        }
        public List<Guests> makeGuests()
        {
            Random rnd = new Random();
            // maakt 20 tot 100 gasten aan
            for (int i = 0; i < rnd.Next(20, 100); i++)
            {
                //een 40% kans of de guest niet op tijd is
                if (rnd.Next(0, 100) < 40)
                {
                    Guests guests = new Guests(i, true, rnd.Next(1, 20), false, 0);
                    guestsList.Add(guests);
                }
                else
                {
                    Guests guests = new Guests(i, true, rnd.Next(1, 20), true, 0);
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

                
            }
            for (int i = 0; i < guestsList.Count; i++)
            {
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
            //int amountOfPlaces = 0;
            //for (int i = 0; i < rowList.Count; i++)
            //{
            //    for (int j = 0; j < rowList[i].amOfPlacesInRow; j++)
            //    {
            //        amountOfPlaces++;
            //    }
            //}
            //if (guestList.Count > amountOfPlaces)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return true;
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
                    //if (guest.IsAdult == true)
                    //{
                    //    GroupHasAdult = true;
                    //}
                    members[i] = guest;
                    members[i].GroupId = groupId;
                    guestList.Remove(guest);
                }

                guestGroups.Add(new Group(groupId, maxGroupSize, groupSize, GroupHasAdult, members));
                groupId++;
            }


            //the remaining guests go in to individual groups
            
              
            while (guestList.Count != 0){
                for (int i = 0; i < guestList.Count; i++)
                {
                    groupId++;
                    //remaining guest are individual, so the group size is just 1.
                    Guests[] member = new Guests[0];
                    Guests guest = guestList[0];
                    if (guest.IsAdult == true)
                    {
                        guestGroups.Add(new Group(groupId, 1, 1, true, member));
                        guestList.Remove(guest);
                    }
                    else
                    {
                        guestList.Remove(guest);
                    }
                }
            }
            return guestGroups.ToArray();

        }

        public void CountSeats(List<Guests> guestList, List<Group> groupList, List<Rows> rowList)
        {
            //int amountOfPlaces = 0;
            //for (int i = 0; i < rowList.Count; i++)
            //{
            //    for (int j = 0; j < rowList[i].amOfPlacesInRow; j++)
            //    {
            //        amountOfPlaces++;
            //    }
            //}
        } 

        public int CountPlacesInFrontRow(List<Rows> rowList)
        {
            int amOfPlacesInFrontRow = 0;
            //int areaId = 0;
            //for (int i = 0; i < rowList.Count; i++)
            //{
            //    if (RowsList[i].areaId != areaId)
            //    {
            //        areaId = RowsList[i].areaId;
            //        for (int j = 0; j < rowList[i].amOfPlacesInRow; j++)
            //        {
            //            amOfPlacesInFrontRow++;
            //        }
            //    }
            //}
            return amOfPlacesInFrontRow;
        }

        public void PlaceGroups(List<Group> grouplist, List<Seats> seatList)
        {
            bool hasKid = false;
            for (int i = 0; i < grouplist.Count; i++)
            {
                //checks if group only has adults
                for (int j = 0; j < grouplist[i].GuestList.Length; j++)
                {
                    if (groupList[i].GuestList[j].IsAdult == true)
                    {
                       hasKid = false;
                    }
                    else
                    {
                        hasKid = true;
                        break;
                    }
                }
                if (hasKid == false)
                {
                    //groep heeft geen kinderen, dus gelijk kijken of hij past
                }
            }
        }
    }
}
