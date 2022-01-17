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
        Area areaClass = new Area();
        public List<Group> failedGroups = new List<Group>();

        public void PlaceGroups(List<Group> groupList, List<Area> areaList)
        {
            // Sort the groups in amount of children in descending order
            groupList = groupContainerClass.SortGroupsInChildrenDesc(groupList);
            //checken of de groepen geplaatst kunnen worden in een area
            for (int group = 0; group < groupList.Count; group++)
            {
                bool isAdded = false;
                for (int area = 0; area < areaList.Count; area++)
                {
                    if (groupClass.CountChildrenInGroup(groupList[group]) == 0 && areaClass.CheckIfOtherRowsPlacesAreAvialable(areaList[area], groupList[group]) != null)
                    {
                        addGroupsToSeats(areaList[area], groupList[group]);
                        isAdded = true;
                        break;
                    }
                    if (areaClass.CheckIfFrontRowIsAvailable(areaList[area], groupList[group]) != null && areaClass.CheckIfOtherRowsPlacesAreAvialable(areaList[area], groupList[group]) != null)
                    {
                        //whole group can be placed in the area
                        addGroupsToSeats(areaList[area], groupList[group]);
                        isAdded = true;
                        break;
                    }
                }
                //check if the Group has been added
                if (isAdded == false)
                {
                    failedGroups.Add(groupList[group]);
                }
            }
            foreach (var item in failedGroups)
            {
                Console.WriteLine(item);
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
        public void AddChildrenOfGroupToFrontRow(Area area, Guests guest)
        {
            for (int j = 0; j < area.rowsList[0].seatList.Count; j++)
            {
                if (area.rowsList[0].seatList[j].Guest == null)
                {
                    // guest.TakenSeatId = area.rowsList[0].seatList[j].Id;
                    area.rowsList[0].seatList[j].Guest = guest;
                    break;
                }
            }
        }
        public void AddAdultsOfGroupToOtherRows(Area area, Guests guest)
        {
            for (int k = 1; k < area.rowsList.Count; k++)
            {
                for (int j = 0; j < area.rowsList[k].seatList.Count; j++)
                {
                    if (area.rowsList[k].seatList[j].Guest == null)
                    {
                        area.rowsList[k].seatList[j].Guest = guest;
                        return;
                    }
                }
            }
        }
    }
}