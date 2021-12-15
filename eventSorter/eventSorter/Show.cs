using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eventSorter
{
    class Show
    {
        static void Main(string[] args)
        {
            Event ev = new Event();
            List < Area > areaList = ev.makeAreas();
            List < Guests > guestList = ev.makeGuests();
            List<Rows> rowsList = ev.makeRows(areaList);
            List<Seats> seatList = ev.makeSeats(rowsList);
            Show p = new Show();

            p.ShowAreas(areaList);
            p.ShowGuests(ev.FormGroupsAndExtract(guestList), guestList);
            bool k = ev.checkAvailability(rowsList, guestList);
            ev.FormGroupsAndExtract(guestList);
            ev.CountPlacesInFrontRow( rowsList);
            Console.Read();
        }

        public void ShowAreas(List<Area> areaList)
        {
            foreach (var item in areaList)
            {
                Console.WriteLine("Area " +item.id + " , amountOfRows " + item.amOfRows + ", seats ");
                Console.WriteLine("-------------------------");
            }
        }
        public void ShowGuests( Group[] groups, List<Guests> guestList)
        {

            foreach (var item in groups)
            {
                Console.WriteLine("Group " + item.GroupId + " , amountOfPeople " + item.AmountOfPeopleInGroup + ", hasadult? " + item.HasAdult);
                Console.WriteLine("-------------------------");
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
                foreach (var items in item.GuestList)
                {
                    Console.WriteLine("Guest " + items.Id + " , age " + items.Age + ", onetime? " + items.OnTime + ", IsAdult?" + items.IsAdult);
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("");
                }
                Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            }
            Console.WriteLine("overige gasten");

            foreach (var item in guestList)
            {
                Console.WriteLine("Guest " + item.Id + " , age " + item.Age + ", IsAdult?" + item.IsAdult);
                Console.WriteLine("-------------------------");
            }

        }
    }
}
