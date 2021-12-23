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
        public List<Group> FormGroupsAndExtract(List<Guests> guestList)
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
            //the remaining guests go in to individual groups
            while (guestList.Count != 0)
            {
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
            return guestGroups;

        }
        public bool checkAvailability(List<Seats> seatsList, List<Guests> guestList)
        {
            //check of alle bezoekers een plaats hebben
            if (guestList.Count > seatsList.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int CountPlacesInFrontRow(List<Area> AreaList)
        {
            int amOfPlacesInFrontRow = 0;
            for (int i = 0; i < areaList.Count; i++)
            {
                for (int k = 0; k < 1; k++)
                {
                    amOfPlacesInFrontRow = amOfPlacesInFrontRow + areaList[i].rowsList[0].seatList.Count;
                }
                
            }
            return amOfPlacesInFrontRow;
        }
        public void PlaceGroups(List<Group> groupList, List<Area> areaList)
        {
            // count children in group
            for (int i = 0; i < groupList.Count(); i++)
            {
                int amountOfChildrenInGroup = 0;
                for (int j = 0; j < groupList[i].GuestList.Count(); j++)
                {
                    if (groupList[i].GuestList[j].IsAdult == false)
                    {
                        amountOfChildrenInGroup++;
                    }
                }
                groupList[i].AmountOfChildrenInGroup = amountOfChildrenInGroup;
            }
            //sorteer de groep van meeste kinderen naar minste X
             groupList = groupList.OrderByDescending(x => x.AmountOfChildrenInGroup).ToList();




            // passen de kinderen uit de groep in de voorste rij?
            // past de groep in de area?
            // pak groep met meeste kinderen x
            for (int i = 0; i < groupList.Count; i++)
            {
                //checks if group only has adults
                if (groupList[i].AmountOfChildrenInGroup == 0)
                {
                    //groep heeft geen kinderen, dus gelijk kijken of hij past
                }
                //form places 
                for (int j = 0; j < areaList.Count; j++)
                {
                    //only get the first row
                    for (int k = 0; k < 1; k++)
                    {
                        bool EnoughPlacesOnFrontRow = false;
                        bool SeatAvailable = false;
                        //1st check the children
                        if (areaList[j].rowsList[0].seatList.Count > groupList[i].AmountOfChildrenInGroup)
                        {
                            //the amount of seats in the front row of that area are more than the amount of children, so its OK!
                            EnoughPlacesOnFrontRow = true;

                        }
                        else
                        {
                            break;
                        }
                        if (EnoughPlacesOnFrontRow == true)
                        {
                            //add guest to seat
                            for (int l = 0; l < areaList[j].rowsList[0].seatList.Count; l++)
                            {
                                if (areaList[j].rowsList[0].seatList[l].seatTaken == false)
                                {
                                    for (int r = 0; r < groupList[i].GuestList.Count(); r++)
                                    {
                                        if (groupList[i].GuestList[r].IsAdult == false)
                                        {
                                            areaList[j].rowsList[0].seatList[l].Guest = groupList[i].GuestList[r];
                                            areaList[j].rowsList[0].seatList[l].seatTaken = true;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    //goes trough all areas, at the end the group gets excluded
                }
                //EXCLUDE GROUP
                groupList.RemoveAt(i);
            }
            //all groups are now empty and gone, every validate guest got a place
        }
    }
}
