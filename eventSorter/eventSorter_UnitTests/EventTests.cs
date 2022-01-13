using NUnit.Framework;
using eventSorter;
using System.Collections.Generic;
using eventSorter_UnitTests.mockups;

namespace Tests
{
    public class EventTests
    {
        GroupContainerMockup groupContainer = new GroupContainerMockup();
        AreaContainerMockup areaContainer = new AreaContainerMockup();
        GroupMockup groupClass = new GroupMockup();

        //PlaceGroups

        //This Function is set to have the exact amount of guests that can have a seat, that means that no groups can be left over and every seat has been occupied by a guest
        //areas - 2 areas, 2 rows, 2 seats for both areas!(total of 16 seats)
        //groups - 2 groups, 4 adults, 4 children(total of 16 guests)
        [Test]
        public void PlaceGroups_shouldPlaceAllGroups_WithMultipleGroupsAndAreas()
        {
            //arrange
            Event eventClass = new Event();

            List<Group> groupList = groupContainer.MakeGroups(groupClass.make8Guests4Adults4Children());
            List<Area> areaList = areaContainer.MakeAreasWith2Areas2Rows2Seats();
            //act
            eventClass.PlaceGroups(groupList, areaList);
            //assert
            //goes trough all seats and check if a user has been seated to its
            for (int i = 0; i < areaList.Count; i++)
            {
                for (int j = 0; j < areaList[i].rowsList.Count; j++)
                {
                    for (int k = 0; k < areaList[i].rowsList[j].seatList.Count; k++)
                    {
                        Assert.NotNull(areaList[i].rowsList[j].seatList[k].Guest);
                    }
                }
            }
        }

        //This Function is set to have the exact amount of guests that can have a seat, that means that no groups can be left over
        //areas - 2 areas, 2 rows, 2 seats for both areas!(total of 16 seats)
        //groups - 2 groups, 4 adults, 4 children(total of 16 guests)
        [Test]
        public void PlaceGroups_shouldHave_NoFailedGroups_WithMultipleGroupsAndAreas()
        {
            //arrange
            Event eventClass = new Event();
            List<Group> groupList = groupContainer.MakeGroups(groupClass.make8Guests4Adults4Children());
            List<Area> areaList = areaContainer.MakeAreasWith2Areas2Rows2Seats();
            //act
            eventClass.PlaceGroups(groupList, areaList);
            //assert
            Assert.AreEqual(eventClass.failedGroups.Count, 0);
        }

        //In this function there will be more Guests than places, not all groups can be seated. These groups go in a failedGroup List.
        [Test]
        public void PlaceGroups_shouldHave_FailedGroups_WithMultipleGroupsAndAreas()
        {
            //arrange
            Event eventClass = new Event();
            List<Group> groupList = groupContainer.MakeGroups(groupClass.make10000Guests());
            List<Area> areaList = areaContainer.MakeAreasWith2Areas2Rows2Seats();
            //act
            eventClass.PlaceGroups( groupList,  areaList);
            //assert
            Assert.AreNotEqual(eventClass.failedGroups.Count, 0);
        }



        //Because we did al the checks if places are avialable for the groups, these methods cant have failed returns, thats why these tests test only the correct outcome.
        //addGroupsToSeats
        [Test]
        public void AddGroupToSeats_should_returnFilledSeat()
        {
            //arrange
            Event eventClass = new Event();
            List<Group> groupList = groupContainer.MakeGroups(groupClass.make8Guests4Adults4Children());
            List<Area> areaList = areaContainer.MakeAreasWith2Areas2Rows2Seats();

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
            Guests guest = new Guests(0, 3, true, 1);
            List<Area> areaList = areaContainer.MakeAreasWith2Areas2Rows2Seats();

            //act
            eventClass.AddChildrenOfGroupToFrontRow(areaList[0], guest);

            //Assert
            Assert.NotNull(areaList[0].rowsList[0].seatList[0].Guest);
        }

        //addAdultToSeat
        [Test]
        public void AddAdultsOfGroupToOtherRows_should_returnFilledSeat()
        {
            //arrange
            Event eventClass = new Event();
            Guests guest = new Guests(0, 30, true, 1);
            List<Area> areaList = areaContainer.MakeAreasWith2Areas2Rows2Seats();

            //act
            eventClass.AddAdultsOfGroupToOtherRows(areaList[0], guest);

            //Assert
            Assert.NotNull(areaList[0].rowsList[1].seatList[0].Guest);
        }

        //addAdultToSeat
        [Test]
        public void AddAdultsOfGroupToOtherRows_should_returnFilledSeat_OnOtherRow()
        {
            //arrange
            Event eventClass = new Event();
            Guests guest = new Guests(0, 30, true, 1);

                //making an area that alreasy has guests on the first row
            List<Seats> EmptyseatList = new List<Seats>();
            EmptyseatList.Add(new Seats(1));
            List<Seats> seatList = new List<Seats>();
            seatList.Add(new Seats(1, guest));

                //making 2 rows
            List<Rows> rowsList = new List<Rows>();
            rowsList.Add(new Rows(0, seatList, 1));
            rowsList.Add(new Rows(1, seatList, 1));
            rowsList.Add(new Rows(2, EmptyseatList, 1));

                //An Area has been made with the first rows already having a guest. This means that the new user must be added to the next row that is empty
            Area area = new Area(1, rowsList);

            //act
            eventClass.AddAdultsOfGroupToOtherRows(area, guest);

            //Assert
            Assert.NotNull(area.rowsList[2].seatList[0].Guest);
        }
    }
}