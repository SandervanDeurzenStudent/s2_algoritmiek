using NUnit.Framework;
using eventSorter;
using System.Collections.Generic;
using eventSorter_UnitTests.mockups;

namespace Tests
{
    public class EventTests
    {
        //checkAvailability
        [Test]
        public void checkAvailability_should_returnTrue()
        {
            //arrange
            Event eventclass = new Event();
            EventMockups eventMockups = new EventMockups();
            //act
            bool enoughPlaces = eventclass.checkAvailability(eventMockups.seatsList, eventMockups.guestListWithParent);
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
            bool enoughPlaces = eventclass.checkAvailability(eventMockups.FalseseatsList, eventMockups.guestListWithParent);
            //assert
            Assert.IsFalse(enoughPlaces);
        }

        //addgroupsToList
        [Test]
        public void addGroupsToSeats_should_returnList()
        {
            
        }
    }
}