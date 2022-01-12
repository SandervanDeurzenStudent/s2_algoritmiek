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
        //CheckIfFrontRowIsAvialable
        [Test]
        public void CheckIfFrontRowIsAvailable_ShouldReturn_List()
        {
            //arrange
            Area area = eventMockups.areaListWithRowsAndSeats[0];
            Group group = eventMockups.groupList[0];
            //act
            area = areaClass.CheckIfFrontRowIsAvailable(area, group);
            //assert
            Assert.AreNotEqual(area, 0);
        }

        [Test]
        public void CheckIfFrontRowIsAvailable_ShouldReturn_null()
        {
            //arrange
            Area area = eventMockups.areaListWithRowsAndNoSeats[0];
            Group group = eventMockups.groupList[0];
            //act
            area = areaClass.CheckIfFrontRowIsAvailable(area, group);
            //assert
            Assert.AreEqual(area, null);
        }


        //CheckIfOtherRowsAreAvialable
        [Test]
        public void CheckIfOtherRowsPlacesAreAvialable_ShouldReturn_List()
        {
            //arrange
            Area area = eventMockups.areaListWithRowsAndSeats[0];
            Group group = eventMockups.groupList[0];
            //act
            area = areaClass.CheckIfOtherRowsPlacesAreAvialable(area, group);
            //assert
            Assert.AreNotEqual(area, 0);
        }

        [Test]
        public void CheckIfOtherRowsPlacesAreAvialable_ShouldReturn_null()
        {
            //arrange
            Area area = eventMockups.areaListWithRowsAndNoSeats[0];
            Group group = eventMockups.groupList[0];
            //act
            area = areaClass.CheckIfOtherRowsPlacesAreAvialable(area, group);
            //assert
            Assert.AreEqual(area, null);
        }

    }
}
