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
            Show show = new Show();
            Group group = new Group();
            AreaContainer areaContainer = new AreaContainer();
            GroupContainer groupContainer = new GroupContainer();
            
            List <Area> areaList = areaContainer.MakeAreas();
            List<Group> grouplist = groupContainer.MakeGroups(group.makeGuests());
            
            Event ev = new Event();
            ev.PlaceGroups(grouplist, areaList);

            
            show.ShowAreas(areaList);
            show.ShowGuests(grouplist);
            Console.Read();
        }
        public void ShowAreas(List<Area> areaList)
        {
            foreach (var item in areaList)
            {
                Console.WriteLine(item);
                foreach (var row in item.rowsList)
                {
                    Console.WriteLine(row);
                    foreach (var seat in row.seatList)
                    {
                        Console.WriteLine(seat);
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
                Console.WriteLine(item);
                Console.WriteLine(" ");
            }
            
        }
    }
}
