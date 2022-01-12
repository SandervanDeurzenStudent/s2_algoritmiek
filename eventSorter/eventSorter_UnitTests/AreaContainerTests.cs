using eventSorter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace eventSorter_UnitTests
{
    class AreaContainerTests
    {
        //Make area
        [Test]
        public void makeAreas_shouldmake_AreaList()
        {
            //arrange
            AreaContainer areaContainer = new AreaContainer();
            //act
            List<Area> area = areaContainer.MakeAreas();
            //assert
            Assert.AreNotEqual(area.Count, 0);
        }
        [Test]
        public void makeAreas_shouldgive_exception()
        {
            //arrange
            AreaContainer areaContainer = new AreaContainer();
            //act
            List<Area> area = areaContainer.MakeAreas();
            //assert
            Assert.AreNotEqual(area.Count, 0);
        }
    }
}
