using eventSorter;
using eventSorter_UnitTests.mockups;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace eventSorter_UnitTests
{
    class GroupContainerTests
    {
        GroupMockup groupClass = new GroupMockup();
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

        //Make groups
        [Test]
        public void SortGroupsInChildrenDesc_ShouldSortGroupsInAmountOfChildrenDescendingOrder()
        {
            //arrange
            GroupContainer groupContainerClass = new GroupContainer();
            List<Group> groupList = groupContainerClass.MakeGroups(groupClass.make10000Guests());

            //act
            List<Group> groupsDesc = groupContainerClass.SortGroupsInChildrenDesc(groupList);
            //assert

                //the loop keeps checking if the group above the other group in the list has more children or equal amount of childrenn
            int groupUnderOtherGroup = groupsDesc.Count - 1;
            bool hasMoreChildren = false;
            for (int i = groupsDesc.Count; i < groupsDesc.Count; i--)
            {
                groupUnderOtherGroup++;
                if (groupsDesc[i].AmountOfChildrenInGroup <= groupsDesc[groupUnderOtherGroup].AmountOfChildrenInGroup)
                {
                    hasMoreChildren = true;
                }
                Assert.IsTrue(hasMoreChildren);
            }
        }
    }
}
