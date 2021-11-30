using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eventSorter
{
    class Program
    {
     
        static void Main(string[] args)
        {
            Event ev = new Event();
            List < Area > areaList = ev.makeAreas();
            List < Guests > guestList = ev.makeGuests();
            Program p = new Program();
            p.ShowAreas(areaList);
            p.ShowGuests(guestList);
            bool k = ev.checkAvailability(areaList, guestList);
            Console.Read();
        }
        public void ShowAreas(List<Area> areaList)
        {
            foreach (var item in areaList)
            {
                Console.WriteLine("Area " +item.id + " , amountOfRows " + item.amOfRows + ", seats " + item.amOfPlacesInRow);
                Console.WriteLine("-------------------------");
            }
        }
        public void ShowGuests(List<Guests> guestList)
        {
            foreach (var item in guestList)
            {
                Console.WriteLine("Guest " + item.Id + " , age " + item.Age + ", onetime? " + item.OnTime);
                Console.WriteLine("-------------------------");
            }
        }
    }
}
