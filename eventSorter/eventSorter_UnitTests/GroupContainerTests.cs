using eventSorter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace eventSorter_UnitTests
{
    class GroupContainerTests
    {
        //Make groups
        [Test]
        public void makeGroups_shouldmake_Groups()
        {
            //arrange
            Group groupClass = new Group();
            GroupContainer GroupContainerClass = new GroupContainer();
            //act
            List<Group> group = GroupContainerClass.MakeGroups(groupClass.makeGuests());
            //assert
            Assert.AreNotEqual(group.Count, 0);
        }
    }
}
