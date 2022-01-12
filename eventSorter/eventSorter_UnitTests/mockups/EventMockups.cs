using eventSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eventSorter_UnitTests.mockups
{
    public class EventMockups
    {
        public List<Guests> guestListWithParent = new List<Guests>();
        public List<Guests> guestListWithoutParent = new List<Guests>();
        public List<Guests> guestListOnlyParents = new List<Guests>();

        public List<Group> groupList = new List<Group>();

        public List<Area> areaListWithRowsAndSeats = new List<Area>();
        public List<Area> areaListWithRowsAndNoSeats = new List<Area>();

        public List<Seats> seatsList = new List<Seats>();
        public List<Seats> EmptyseatsList = new List<Seats>();
        public List<Seats> FalseseatsList = new List<Seats>();
        public EventMockups()
        {
            //makeguestListwithParent
            guestListWithParent.Add(new Guests(1, false, 1, true, 1));
            guestListWithParent.Add(new Guests(2, false, 1, false, 1));
            guestListWithParent.Add(new Guests(3, true, 15, true, 2));
            guestListWithParent.Add(new Guests(4, false, 1, false, 2));
            //makeGuestListWithoutParent
            guestListWithoutParent.Add(new Guests(1, false, 1, true, 1));
            guestListWithoutParent.Add(new Guests(2, false, 1, false, 1));
            guestListWithoutParent.Add(new Guests(3, false, 1, true, 2));
            guestListWithoutParent.Add(new Guests(4, false, 1, false, 2));
            //makeGuestListWithoutParent
            guestListOnlyParents.Add(new Guests(1, false, 15, true, 1));
            guestListOnlyParents.Add(new Guests(2, false, 15, false, 1));
            guestListOnlyParents.Add(new Guests(3, false, 15, true, 2));
            guestListOnlyParents.Add(new Guests(4, false, 15, false, 2));

            groupList.Add(new Group(1, guestListWithParent));
            //area
            //first make seats and rows
            List<Rows> rowsList = new List<Rows>();
            List<Rows> rowsListNoSeats = new List<Rows>();
            seatsList.Add(new Seats(1, 1, 1));
            seatsList.Add(new Seats(2, 1, 1));
            seatsList.Add(new Seats(3, 1, 1));
            seatsList.Add(new Seats(4, 1, 1));
            //
            seatsList.Add(new Seats(5, 2, 1));
            seatsList.Add(new Seats(6, 2, 1));
            seatsList.Add(new Seats(7, 3, 1));
            seatsList.Add(new Seats(8, 4, 1));
            //
            seatsList.Add(new Seats(9, 1, 2));
            seatsList.Add(new Seats(10, 1, 2));
            seatsList.Add(new Seats(11, 1, 2));
            seatsList.Add(new Seats(12, 1, 2));
            //
            seatsList.Add(new Seats(13, 2, 2));
            seatsList.Add(new Seats(14, 2, 2));
            seatsList.Add(new Seats(15, 2, 2));
            seatsList.Add(new Seats(16, 2, 2));
            for (int i = 0; i < 3; i++)
            {
                rowsList.Add(new Rows(i, seatsList, 1));
            }
            areaListWithRowsAndSeats.Add(new Area(1, rowsList));
            for (int i = 0; i < 3; i++)
            {
                rowsListNoSeats.Add(new Rows(i, EmptyseatsList, 2));
            }
            areaListWithRowsAndNoSeats.Add(new Area(1, rowsListNoSeats));

        }
        public List<Group> MakeGroups(List<Guests> guestList)
        {
            int count = 0;
            List<Group> guestGroups = new List<Group>();

            for (int i = 0; i < guestList.Count; i++)
            {
                if (guestList[i].GroupId == count)
                {
                    guestGroups.Add(new Group(count, guestList.Where(x => x.GroupId == count).ToList()));
                    count++;
                }
            }
            return guestGroups;
        }
        
    }
}
