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
            Group group = new Group();
            AreaContainer areaContainer = new AreaContainer();
            GroupContainer groupContainer = new GroupContainer();
            
            List < Area > areaList = areaContainer.MakeAreas();
            List< Group > grouplist = groupContainer.MakeGroups(group.makeGuests());

            Event ev = new Event();
            ev.PlaceGroups(grouplist, areaList);

            Show show = new Show();
            show.ShowGuests(grouplist);
            show.ShowAreas(areaList);
            
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
                            Console.WriteLine("     SEAT " + itemss.Id + " seattaken? " + itemss.seatTaken);
                        }
                        Console.WriteLine("_____________");
                }
                Console.WriteLine("______________________________________");
            }
        }
        public void ShowGuests( List<Group> groupList)
        {
            foreach (var item in groupList)
            {
                foreach (var items in item.GuestList)
                {
                    Console.WriteLine(items);
                    Console.WriteLine("**************************************************************");
                }
            }
            
        }
    }
}
