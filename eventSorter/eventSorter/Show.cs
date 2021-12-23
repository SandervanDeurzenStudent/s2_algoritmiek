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
            List < Area > areaList = ev.MakeAreas();
            List < Guests > guestList = ev.makeGuests();
            
            Show p = new Show();
            ev.CountPlacesInFrontRow(areaList);
            List< Group > grouplist = ev.FormGroupsAndExtract(guestList);
            ev.PlaceGroups(grouplist, areaList);

            p.ShowAreas(areaList);
            p.ShowGuests(ev.FormGroupsAndExtract(guestList), guestList);
           // bool k = ev.checkAvailability(rowsList, guestList);
            
          
            Console.Read();
        }

        public void ShowAreas(List<Area> areaList)
        {
            foreach (var item in areaList)
            {
                Console.WriteLine("AREA " + item.id);
                foreach (var items in item.rowsList)
                {
                        Console.WriteLine("   ROW " + items.id);
                        foreach (var itemss in items.seatList)
                        {
                            Console.WriteLine("     SEAT " + itemss.Id);
                        }
                        Console.WriteLine("_____________");
                }
                Console.WriteLine("______________________________________");
            }
        }
        public void ShowGuests( List < Group> groups, List<Guests> guestList)
        {

            foreach (var item in groups)
            {
                Console.WriteLine("Group " + item.GroupId + " , amountOfPeople " + item.AmountOfPeopleInGroup + ", hasadult? " + item.HasAdult);
                Console.WriteLine("_________________");
                Console.WriteLine("");
                foreach (var items in item.GuestList)
                {
                    if (items.IsAdult == true)
                    {
                        Console.WriteLine("Guest " + items.Id + " , age " + items.Age + ", onetime " + items.OnTime + " Adult ");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Guest " + items.Id + " , age " + items.Age + ", onetime " + items.OnTime + " Child");
                        Console.WriteLine("");
                    }
                    
                }
                Console.WriteLine("**************************************************************");
            }
        }
    }
}
