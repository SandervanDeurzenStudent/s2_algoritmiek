using NUnit.Framework;
using eventSorter;
using System.Collections.Generic;
using eventSorter_UnitTests.mockups;

namespace Tests
{
    public class EventTests
    {
        Event eventClass = new Event();
        GroupContainerMockup groupContainer = new GroupContainerMockup();
        AreaContainerMockup areaContainer = new AreaContainerMockup();
        GroupMockup groupClass = new GroupMockup();

        //addgroupsToList
        [Test]
        public void PlaceGroups_should_returnNothing()
        {
            Event eventClass = new Event();
            //because every group can be placed, the failedgroups are empty
            eventClass.PlaceGroups(groupContainer.MakeGroups(groupClass.makeGuests()), areaContainer.MakeAreasWith100Areas100Rows100Seats());
            Assert.AreEqual(eventClass.failedGroups.Count, 0);
        }

        [Test]
        public void PlaceGroups_should_returnList()
        {
            eventClass.PlaceGroups( groupContainer.MakeGroups(groupClass.makeGuests()), areaContainer.MakeAreasWith1Area1Row0Seats());
            Assert.AreNotEqual(eventClass.failedGroups.Count, 0);
        }

        //addGroupsToSeats
        [Test]
        public void AddGroupToSeats_should_returnFilledSeat()
        {
            //arrange
            Event eventClass = new Event();
            List<Group> groupList = groupContainer.MakeGroups(groupClass.makeGuests());
            List<Area> areaList = areaContainer.MakeAreasWith100Areas100Rows100Seats();

            //act
            eventClass.addGroupsToSeats(areaList[0], groupList[0]);

            //assert
            Assert.NotNull(areaList[0].rowsList[0].seatList[0].Guest);
        }

        //addChildrenToSeat
        [Test]
        public void AddChildrenToFrontRow_should_returnFilledSeat()
        {
            //arrange
            Event eventClass = new Event();
            Guests guest = new Guests(1, 3, true, 3);
            List<Area> areaList = areaContainer.MakeAreasWith100Areas100Rows100Seats();

            //act
            eventClass.AddChildrenOfGroupToFrontRow(areaList[0], guest);

            //Assert
            Assert.NotNull(areaList[0].rowsList[0].seatList[0].Guest);
        }

        //addChildrenToSeat
        [Test]
        public void AddAdultToFrontRow_should_returnFilledSeat()
        {
            //arrange
            Event eventClass = new Event();
            Guests guest = new Guests(1, 30, true, 3);
            List<Area> areaList = areaContainer.MakeAreasWith100Areas100Rows100Seats();

            //act
            eventClass.AddChildrenOfGroupToFrontRow(areaList[0], guest);

            //Assert
            Assert.NotNull(areaList[0].rowsList[0].seatList[0].Guest);
        }
    }
}