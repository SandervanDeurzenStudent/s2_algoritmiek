using NUnit.Framework;
using eventSorter;
using System.Collections.Generic;
using eventSorter_UnitTests.mockups;

namespace Tests
{
    public class Tests
    {
        //Make Guests
        [Test]
        public void makeGuest_shouldmake_GuestList()
        {
            //arrange
            Event eventclass = new Event();
            //act
            eventclass.makeGuests();
            //assert
            Assert.AreNotEqual(eventclass.guestsList.Count, 0);
        }

        [Test]
        public void makeGuest_shouldReturn_Null()
        {
            //arrange
            Event eventclass = new Event();
            //act
            eventclass.makeGuests();
            //assert
            Assert.AreNotEqual(eventclass.guestsList.Count, 0);
        }
        //Make area
        [Test]
        public void makeAreas_shouldmake_AreaList()
        {
            //arrange
            Event eventclass = new Event();
            //act
            List<Area> area = eventclass.MakeAreas();
            //assert
            Assert.AreNotEqual(area.Count, 0);
        }
        [Test]
        public void makeAreas_shouldgive_exception()
        {
            //arrange
            Event eventclass = new Event();
            //act
            List<Area> area = eventclass.MakeAreas();
            //assert
            Assert.AreNotEqual(area.Count, 0);
        }


        //Make groups
        [Test]
        public void makeGroups_shouldmake_Groups()
        {
            //arrange
            Event eventclass = new Event();
            //act
            List <Group> group =  eventclass.MakeGroups(eventclass.makeGuests());
            //assert
            Assert.AreNotEqual(group.Count, 0);
        }

        //checkAvailability
        [Test]
        public void checkAvailability_should_returnTrue()
        {
            //arrange
            Event eventclass = new Event();
            EventMockups eventMockups = new EventMockups();
            //act
            bool enoughPlaces = eventclass.checkAvailability(eventMockups.seatsList, eventMockups.guestList);
            //assert
            Assert.IsTrue(enoughPlaces);
        }
        
        [Test]
        public void checkAvailability_should_ReturnFalse()
        {
            //arrange
            Event eventclass = new Event();
            EventMockups eventMockups = new EventMockups();
            //act
            bool enoughPlaces = eventclass.checkAvailability(eventMockups.FalseseatsList, eventMockups.guestList);
            //assert
            Assert.IsFalse(enoughPlaces);
        }

        //addgroupsToList
        [Test]
        public void addGroupsToSeats_should_returnList()
        {
            //arrange
            Event eventclass = new Event();
            EventMockups eventMockups = new EventMockups();
            //act
           // bool enoughPlaces = eventclass.addGroupsToSeats(eventMockups.areaList[0], eventMockups.gro);
            //assert
            //Assert.IsFalse(enoughPlaces);
        }
    }
}