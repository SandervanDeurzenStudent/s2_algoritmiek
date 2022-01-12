using eventSorter;
using eventSorter_UnitTests.mockups;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace eventSorter_UnitTests
{
    class GroupTests
    {
        Group groupClass = new Group();
        EventMockups eventMockups = new EventMockups();

        //hasParent
        [Test]
        public void hasParent_should_returnTrue()
        {
            //arrange
            List < Guests > guestList = eventMockups.guestListWithParent;
            Group groupWithParent = new Group(1, guestList);
            //act
            bool HasParent = groupClass.hasParent(groupWithParent);
            //assert
            Assert.IsTrue(HasParent);
        }

        [Test]
        public void HasParents_ShouldReturn_False()
        {
            //arrange
            List<Guests> guestList = eventMockups.guestListWithoutParent;
            Group group = new Group(1, guestList);
            //act
            bool enoughPlaces = groupClass.hasParent(group);
            //assert
            Assert.IsFalse(enoughPlaces);
        }

        [Test]
        public void makeGuests_should_returnGuestList()
        {
            //arrange
           
            //act
            List<Guests> enoughPlaces = groupClass.makeGuests();
            //assert
            Assert.AreNotEqual(enoughPlaces.Count, 0);
        }

        //countChildrenInGroup
        [Test]
        public void countChildrenInGroup_ShouldReturn_True()
        {
            //arrange
            List<Guests> GuestList = eventMockups.guestListWithParent;
            Group group = new Group(1, GuestList);
            //act
            int Count = groupClass.CountChildrenInGroup(group);
            //assert
            Assert.AreNotEqual(Count, 0);
        }

        //countChildrenInGroup
        [Test]
        public void countChildrenInGroup_ShouldReturn_False()
        {
            //arrange
            List<Guests> guestList = eventMockups.guestListOnlyParents;
            Group group = new Group(1, guestList);
            //act
            int Count = groupClass.CountChildrenInGroup(group);
            //assert
            Assert.AreEqual(Count, 0);
        }

        //countChildrenInGroup
        [Test]
        public void countAdultsInGroup_ShouldReturn_True()
        {
            //arrange
            List<Guests> GuestList = eventMockups.guestListWithParent;
            Group group = new Group(1, GuestList);
            //act
            int Count = groupClass.CountAdultsInGroup(group);
            //assert
            Assert.AreNotEqual(Count, 0);
        }

        [Test]
        public void countAdultsInGroup_ShouldReturn_False()
        {
            //arrange
            List<Guests> GuestList = eventMockups.guestListWithoutParent;
            Group group = new Group(1, GuestList);
            //act
            int Count = groupClass.CountAdultsInGroup(group);
            //assert
            Assert.AreEqual(Count, 0);
        }
    }
}
