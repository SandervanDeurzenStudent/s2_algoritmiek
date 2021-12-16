using NUnit.Framework;
using eventSorter;
namespace Tests
{
    public class Tests
    {
        [SetUp]

        [Test]
        public void countSeats_shouldReturn_Number()
        {
            //arrange
            //Event eventclass = new Event();
            //act
            //eventclass.CountSeats(ne);
            //assert
            //Assert.Pass();
        }


        [Test]
        public void makeGuest_shouldmake_GuestList()
        {
            //arrange
            Event eventclass = new Event();
            //act
            eventclass.makeGuests();
            //assert
            Assert.AreNotEqual(eventclass.guestsList.Count, 0);
        }
    }
}