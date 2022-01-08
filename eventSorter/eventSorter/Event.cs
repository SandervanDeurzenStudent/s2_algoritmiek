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
            for (int i = 1; i < rnd.Next(20, 101); i++)
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

            for (int group = 0; group < groupList.Count; group++)
            {
                //checks if group only has adults
                if (groupList[group].AmountOfChildrenInGroup == 0)
                {
                    //groep heeft geen kinderen, dus gelijk kijken of hij past
                }
                int amountOfTakenPlacesInFrontRow = 0;
               
                int amountOfAdultsInGroup = groupList[group].AmountOfPeopleInGroup - groupList[group].AmountOfChildrenInGroup;
                bool EnoughPlacesOnFrontRowForChildren = false;
                bool EnoughPlacesInAreaForAdults = false;
                //form places on front row
                for (int area = 0; area < areaList.Count; area++)
                {
                    
                    //only get the first row
                    for (int row = 0; row < 1; row++)
                    {
                        //List<Seats> avialableSeats = areaList[area].rowsList[row].seatList.Count -
                        int amountOfTakenSeatsInFrontRow = 0;
                        for (int seat = 0; seat < areaList[area].rowsList[row].seatList.Count; seat++)
                        {
                            if (areaList[area].rowsList[row].seatList[seat].seatTaken == true)
                            {
                                amountOfTakenSeatsInFrontRow++;
                            }
                        }
                         
                        // the amount of children in a group can not be higher than te amount of places in te front row
                        if (amountOfTakenSeatsInFrontRow <= groupList[group].AmountOfChildrenInGroup)
                        {
                            EnoughPlacesOnFrontRowForChildren = true;
                            //check for total amountofplacesinarea
                        }
                        break;
                    }


                    for (int row = 1; row < areaList[area].rowsList.Count; row++)
                    {
                        int amountOfTakenPlacesInAreaMinusFrontRow = 0;
                        for (int seat = 0; seat < areaList[area].rowsList[row].seatList.Count; seat++)
                        {
                            if (areaList[area].rowsList[row].seatList[seat].seatTaken == true)
                            {
                                amountOfTakenPlacesInAreaMinusFrontRow++;
                            }
                        }

                        // the amount of adults in a group can not be higher than te amount of places in the remaining rows
                        if (amountOfTakenPlacesInAreaMinusFrontRow <= amountOfAdultsInGroup)
                        {
                            EnoughPlacesInAreaForAdults = true;
                        }
                        break;
                    }
                    if (EnoughPlacesOnFrontRowForChildren == true && EnoughPlacesInAreaForAdults == true)
                    {
                         //whole group can be placed in the area
                         this.placeGroups(areaList[area], groupList[group]);
                    }
                }
               
               //goes trough all areas, at the end the group gets excluded
                
               //EXCLUDE GROUP
               groupList.RemoveAt(group);
            }
        }
        public void placeGroups(Area area, Group group)
        {
            int Guestnr = 0;
            for (int i = 0; i < group.GuestList.Count(); i++)
            {
                if (group.GuestList[i].IsAdult == false)
                {
                    int guestId = 123451234;
                    for (int j = 0; j < area.rowsList[0].seatList.Count; j++)
                    {
                        
                        if (area.rowsList[0].seatList[j].seatTaken == false && group.GuestList[i].TakenSeatId != guestId)
                        {
                            group.GuestList[i].TakenSeatId = area.rowsList[0].seatList[j].Id;
                            guestId = area.rowsList[0].seatList[j].Id;
                            area.rowsList[0].seatList[j].seatTaken = true;
                            
                        }

                    }
                }
                //else
                //{
                //    for (int k = 0; k < area.rowsList.Count; k++)
                //    {
                //        for (int j = 0; j < area.rowsList[j].seatList.Count; j++)
                //        {
                //            if (area.rowsList[k].seatList[j].seatTaken == false && group.GuestList[i].TakenSeatId != 0)
                //            {
                //                group.GuestList[Guestnr].TakenSeatId = area.rowsList[k].seatList[j].Id;
                //                area.rowsList[k].seatList[j].seatTaken = true;
                //                Guestnr++;
                //            }
                //        }
                //    }
                    
                //}
            }

        }

        public void k(Guests guest, Seats seat)
        {

        }
        
    }
}
