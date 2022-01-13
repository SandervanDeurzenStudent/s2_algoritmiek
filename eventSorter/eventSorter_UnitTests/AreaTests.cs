using eventSorter;
using eventSorter_UnitTests.mockups;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace eventSorter_UnitTests
{
    class AreaTests
    {
        Area areaClass = new Area();
        EventMockups eventMockups = new EventMockups();
        AreaContainerMockup areaContainerMockup = new AreaContainerMockup();
        //CheckIfFrontRowIsAvialable
        [Test]
        public void CheckIfFrontRowIsAvailable_ShouldReturn_List()
        {
            //arrange
            List<Area> area = areaContainerMockup.MakeAreasWith100Areas100Rows100Seats();

            Group group = eventMockups.groupList[0];
            //act
            area[0] = areaClass.CheckIfFrontRowIsAvailable(area[0], group);
            //assert
            Assert.AreNotEqual(area[0], 0);
        }

        [Test]
        public void CheckIfFrontRowIsAvailable_ShouldReturn_null()
        {
            //arrange
            List<Area> area = areaContainerMockup.MakeAreasWith1Area1Row0Seats();
            Group group = eventMockups.groupList[0];
            //act
            area[0] = areaClass.CheckIfFrontRowIsAvailable(area[0], group);
            //assert
            Assert.AreEqual(area[0], null);
        }

        //CheckIfOtherRowsAreAvialable
        [Test]
        public void CheckIfOtherRowsPlacesAreAvialable_ShouldReturn_List()
        {
            //arrange
            List<Area> area = areaContainerMockup.MakeAreasWith100Areas100Rows100Seats();

            Group group = eventMockups.groupList[0];
            //act
            area[0] = areaClass.CheckIfOtherRowsPlacesAreAvialable(area[0], group);
            //assert
            Assert.AreNotEqual(area[0], 0);
        }

        [Test]
        public void CheckIfOtherRowsPlacesAreAvialable_ShouldReturn_null()
        {
            //arrange
            List<Area> area = areaContainerMockup.MakeAreasWith1Area1Row0Seats();
            Group group = eventMockups.groupList[0];
            //act
            area[0] = areaClass.CheckIfFrontRowIsAvailable(area[0], group);
            //assert
            Assert.AreEqual(area[0], null);
        }

    }
}
