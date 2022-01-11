using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
     public class Event
    {

        public Guests guestClass = new Guests();
        Group groupClass = new Group();
        AreaContainer areaContainer = new AreaContainer();
        GroupContainer groupContainerClass = new GroupContainer();
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
            groupList = groupContainerClass.SortGroupsInChildrenDesc(groupList);

            //checken of de groepen geplaatst kunnen worden in een area
            for (int group = 0; group < groupList.Count; group++)
            {
                for (int area = 0; area < areaList.Count; area++)
                {
                    if (groupClass.IsGroupAdded(groupList[group]) == false)
                    {
                        if (CheckIfFrontRowIsAvailable(areaList[area], groupList[group]) != null && CheckIfOtherRowsPlacesAreAvialable(areaList[area], groupList[group]) != null)
                        {
                            //whole group can be placed in the area
                            groupClass.AddGroup(groupList[group]);
                            addGroupsToSeats(areaList[area], groupList[group]);
                        }
                    }
                }
                if (groupClass.IsGroupAdded(groupList[group]) == false)
                {
                    //EXCLUDE GROUP
                    groupList.RemoveAt(group);
                }
            }
         
        }
        public void addGroupsToSeats(Area area, Group group)
        {
            for (int i = 0; i < group.GuestList.Count(); i++)
            {
                if (guestClass.checkForAdult(group.GuestList[i]) == false)
                {
                    AddChildrenOfGroupToFrontRow(area, group.GuestList[i]);
                }
                else
                {
                    AddAdultsOfGroupToOtherRows(area, group.GuestList[i]);
                }
            }

        }

        public Area CheckIfFrontRowIsAvailable(Area area, Group group)
        {
            int amountOfTakenSeatsInFrontRow = 0;
            for (int seat = 0; seat < area.rowsList[0].seatList.Count; seat++)
            {
                if (area.rowsList[0].seatList[seat].seatTaken == true)
                {
                    amountOfTakenSeatsInFrontRow++;
                }

            }
            if (amountOfTakenSeatsInFrontRow <= groupClass.CountChildrenInGroup(group) && area.rowsList[0].seatList.Count >= groupClass.CountChildrenInGroup(group))
            {
                return area;
            }
            return null;
        }

        public Area CheckIfOtherRowsPlacesAreAvialable(Area area, Group group)
        {
            //check te remaining rows
            for (int rows = 1; rows < area.rowsList.Count; rows++)
            {
                int amountOfTakenPlacesInAreaMinusFrontRow = 0;
                for (int seat = 0; seat < area.rowsList[rows].seatList.Count; seat++)
                {
                    if (area.rowsList[rows].seatList[seat].seatTaken == true)
                    {
                        amountOfTakenPlacesInAreaMinusFrontRow++;
                    }
                }
                for (int i = 0; i < area.rowsList.Count; i++)
                {
                    if (amountOfTakenPlacesInAreaMinusFrontRow <= groupClass.CountAdultsInGroup(group) && area.rowsList[i].seatList.Count >= groupClass.CountAdultsInGroup(group))
                    {
                        return area;
                    }
                }
            }
            return null;
        }

        public void AddChildrenOfGroupToFrontRow(Area area, Guests guest)
        {
            int guestId = 123451234;
            for (int j = 0; j < area.rowsList[0].seatList.Count; j++)
            {
                if (area.rowsList[0].seatList[j].seatTaken == false && guest.TakenSeatId != guestId)
                {
                    guest.TakenSeatId = area.rowsList[0].seatList[j].Id;
                    guestId = area.rowsList[0].seatList[j].Id;
                    area.rowsList[0].seatList[j].Guest = guest;
                    area.rowsList[0].seatList[j].seatTaken = true;
                }
            }
        }
        public void AddAdultsOfGroupToOtherRows(Area area, Guests guest)
        {
            int guestId = 1132422;
            for (int k = 1; k < area.rowsList.Count; k++)
            {
                for (int j = 0; j < area.rowsList[k].seatList.Count; j++)
                {
                    if (area.rowsList[k].seatList[j].seatTaken == false && guest.TakenSeatId != guestId)
                    {
                        guest.TakenSeatId = area.rowsList[k].seatList[j].Id;
                        guestId = area.rowsList[0].seatList[j].Id;
                        
                        area.rowsList[k].seatList[j].Guest = guest;
                        area.rowsList[k].seatList[j].seatTaken = true;
                    }
                }
            }
        }
    }
}
