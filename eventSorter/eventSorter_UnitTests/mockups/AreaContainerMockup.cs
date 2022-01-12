﻿using eventSorter;
using System;
using System.Collections.Generic;
using System.Text;

namespace eventSorter_UnitTests.mockups
{
    class AreaContainerMockup
    {

        public List<Area> MakeAreasWith1Area1Row0Seats()
        {
            List<Area> areaListWith1Area1Row1Seat = new List<Area>();
            Random rnd = new Random();
            //making the areas with rows
            for (int i = 0; i < 1; i++)
            {
                int numberOfSeats = 0;
                List<Rows> RowsList = new List<Rows>();

                //make the Rows
                for (int j = 0; j < 1; j++)
                {
                    List<Seats> SeatsList = new List<Seats>();
                    //make the seats
                    for (int k = 0; k < numberOfSeats; k++)
                    {
                        SeatsList.Add(new Seats(k, j, i));
                    }
                    RowsList.Add(new Rows(j, SeatsList, i));
                }
                areaListWith1Area1Row1Seat.Add(new Area(i, RowsList));
            }
            return areaListWith1Area1Row1Seat;
        }

        public List<Area> MakeAreasWith100Areas100Rows100Seats()
        {
            List<Area> MakeAreasEnoughRowsAndSeats = new List<Area>();
            Random rnd = new Random();
            //making the areas with rows
            for (int i = 0; i < 100; i++)
            {
                int numberOfSeats = 100;
                List<Rows> RowsList = new List<Rows>();

                //make the Rows
                for (int j = 0; j < 100; j++)
                {
                    List<Seats> SeatsList = new List<Seats>();
                    //make the seats
                    for (int k = 0; k < numberOfSeats; k++)
                    {
                        SeatsList.Add(new Seats(k, j, i));
                    }
                    RowsList.Add(new Rows(j, SeatsList, i));
                }
                MakeAreasEnoughRowsAndSeats.Add(new Area(i, RowsList));
            }
            return MakeAreasEnoughRowsAndSeats;
        }
    }
}
