using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
     public class Event
    {
        public List<Area> areaList = new List<Area>();
        public List<Group> groupList  = new List<Group>();
        public List<Guests> guestsList = new List<Guests>();

        public Guests guestClass = new Guests();
        Group groupClass = new Group();
        public List<Area> MakeAreas()
        {
            Random rnd = new Random();
            //making the areas with rows
            for (int i = 0; i < rnd.Next(2, 6); i++)
            {
                int numberOfSeats = rnd.Next(3, 11);
                List<Rows> RowsList = new List<Rows>();

                //make the Rows
                for (int j = 0; j < rnd.Next(1, 4); j++)
                {
                    List<Seats> SeatsList = new List<Seats>();
                    //make the seats
                    for (int k = 0; k < numberOfSeats; k++)
                    {
                        SeatsList.Add(new Seats(k, j, i));
                    }
                    RowsList.Add(new Rows(j, SeatsList, i));
                }
                areaList.Add(new Area(i, RowsList));
            }
            return areaList;
        }
        

        
        public List<Group> MakeGroups(List<Guests> guestList)
        {
            int GroupId = 0;
            int count = 0;
            List<Group> guestGroups = new List<Group>();
            for (int i = 0; i < guestList.Count; i++)
            {
                if (guestList[i].GroupId == GroupId)
                {
                    guestGroups.Add(new Group(i, guestList.Where(x => x.GroupId == count).ToList()));
                    count++;
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

       
        public void PlaceGroups(List<Group> groupList, List<Area> areaList)
        {
            // Sort the groups in amount of children in descending order
            groupClass.SortGroupsInChildrenDesc(groupList);
 

            ////checken of de groepen geplaatst kunnen worden in een area
            //for (int group = 0; group < groupList.Count; group++)
            //{
            //    //checks if group only has adults
            //    if (groupList[group].AmountOfChildrenInGroup == 0)
            //    {
            //        //groep heeft geen kinderen, dus gelijk kijken of hij past
            //    }
            //    int amountOfAdultsInGroup = groupList[group].AmountOfPeopleInGroup - groupList[group].AmountOfChildrenInGroup;
            //    bool EnoughPlacesOnFrontRowForChildren = false;
            //    bool EnoughPlacesInAreaForAdults = false;
            //    //form places on front row
            //    for (int area = 0; area < areaList.Count; area++)
            //    {
            //        if (groupList[group].IsAdded == false)
            //        { 
            //            //only get the first row
            //            for (int row = 0; row < 1; row++)
            //            {
            //                //List<Seats> avialableSeats = areaList[area].rowsList[row].seatList.Count -
            //                int amountOfTakenSeatsInFrontRow = 0;
            //                for (int seat = 0; seat < areaList[area].rowsList[row].seatList.Count; seat++)
            //                {
            //                    if (areaList[area].rowsList[row].seatList[seat].seatTaken == true)
            //                    {
            //                        amountOfTakenSeatsInFrontRow++;
            //                    }
            //                }
            //                // the amount of children in a group can not be higher than te amount of places in te front row
            //                if (amountOfTakenSeatsInFrontRow <= groupList[group].AmountOfChildrenInGroup)
            //                {
            //                    EnoughPlacesOnFrontRowForChildren = true;
            //                    //check for total amountofplacesinarea
            //                }
            //            }
            //            //check te remaining rows
            //            for (int rows = 1; rows < areaList[area].rowsList.Count; rows++)
            //            {
            //                int amountOfTakenPlacesInAreaMinusFrontRow = 0;
            //                for (int seat = 0; seat < areaList[area].rowsList[rows].seatList.Count; seat++)
            //                {
            //                    if (areaList[area].rowsList[rows].seatList[seat].seatTaken == true)
            //                    {
            //                        amountOfTakenPlacesInAreaMinusFrontRow++;
            //                    }
            //                }
            //                // the amount of adults in a group can not be higher than te amount of places in the remaining rows
            //                if (amountOfTakenPlacesInAreaMinusFrontRow <= amountOfAdultsInGroup)
            //                {
            //                    EnoughPlacesInAreaForAdults = true;
            //                }
            //                break;
            //            }
            //            if (EnoughPlacesOnFrontRowForChildren == true && EnoughPlacesInAreaForAdults == true)
            //            {
            //                //whole group can be placed in the area
            //                this.addGroupsToSeats(areaList[area], groupList[group]);
            //                groupList[group].IsAdded = true;
            //            }
            //        }
            //    }

            //    //EXCLUDE GROUP
            //    groupList.RemoveAt(group);
            //}
        }
        public void addGroupsToSeats(Area area, Group group)
        {
        //    for (int i = 0; i < group.GuestList.Count(); i++)
        //    {
        //        if (guestClass.checkForAdult( group.GuestList[i]) == false)
        //        {
        //            int guestId = 123451234;
        //            for (int j = 0; j < area.rowsList[0].seatList.Count; j++)
        //            {
        //                if (area.rowsList[0].seatList[j].seatTaken == false && group.GuestList[i].TakenSeatId != guestId)
        //                {
        //                    group.GuestList[i].TakenSeatId = area.rowsList[0].seatList[j].Id;
        //                    guestId = area.rowsList[0].seatList[j].Id;
        //                    area.rowsList[0].seatList[j].seatTaken = true;
                            
        //                }
        //            }
        //        }
        //        else
        //        {
        //            int guestId = 1132422;
        //            for (int k = 0; k < area.rowsList.Count; k++)
        //            {
        //                for (int j = 0; j < area.rowsList[k].seatList.Count; j++)
        //                {
        //                    if (area.rowsList[k].seatList[j].seatTaken == false && group.GuestList[i].TakenSeatId != guestId)
        //                    {
        //                        group.GuestList[i].TakenSeatId = area.rowsList[k].seatList[j].Id;
        //                        guestId = area.rowsList[0].seatList[j].Id;
        //                        area.rowsList[k].seatList[j].seatTaken = true;
                                
        //                    }
        //                }
        //            }
        //        }
        //    }

        }


    }
}
