using System;
using System.Collections.Generic;
using System.Text;
using eventSorter;
using eventSorter_UnitTests.mockups;
using NUnit.Framework;

namespace eventSorter_UnitTests
{
    public class GuestTests
    {
        Guests guestClass = new Guests();

        [Test]
        public void CheckForAdult_ShouldReturn_True()
        {
            //arrange
            Guests guest = new Guests(1, true, 14, true, 2);
            //act
            bool enoughPlaces = guestClass.checkForAdult(guest);
            //assert
            Assert.IsTrue(enoughPlaces);
        }

        [Test]
        public void CheckForAdult_ShouldReturn_False()
        {
            //arrange
            Guests guest = new Guests(1, true, 3, true, 2);
            //act
            bool enoughPlaces = guestClass.checkForAdult(guest);
            //assert
            Assert.IsFalse(enoughPlaces);
        }

        [Test]
        public void CheckForOnTIme_ShouldReturn_True()
        {
            //arrange
            Guests guest = new Guests(1, true, 14, true, 2);
            //act
            bool enoughPlaces = guestClass.CheckForOnTime(guest);
            //assert
            Assert.IsTrue(enoughPlaces);
        }

        [Test]
        public void CheckForOnTIme_ShouldReturn_False()
        {
            //arrange
            Guests guest = new Guests(1, true, 14, false, 2);
            //act
            bool enoughPlaces = guestClass.CheckForOnTime(guest);
            //assert
            Assert.IsFalse(enoughPlaces);
        }
    }
}
