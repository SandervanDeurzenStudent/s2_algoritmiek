using eventSorter;
using System;
using System.Collections.Generic;
using System.Text;

namespace eventSorter_UnitTests.mockups
{
    public class EventMockups
    {
        public List<Guests> guestList = new List<Guests>();
        public List<Area> areaList = new List<Area>();
        public List<Seats> seatsList = new List<Seats>();
        public List<Seats> FalseseatsList = new List<Seats>();
        public EventMockups()
        {
            guestList.Add(new Guests(1, false, 13, true, 1));
            guestList.Add(new Guests(2, true, 13, false, 1));
            guestList.Add(new Guests(3, true, 13, true, 2));
            guestList.Add(new Guests(4, false, 13, false, 2));

            //area
            //first make seats and rows
            List<Rows> rowsList = new List<Rows>();
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
            areaList.Add(new Area(1, rowsList));
            for (int i = 0; i < 3; i++)
            {
                rowsList.Add(new Rows(i, seatsList, 2));
            }
            areaList.Add(new Area(2, rowsList));

        }
       
    }
}
