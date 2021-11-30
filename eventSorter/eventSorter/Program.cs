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
            Program p = new Program();
            p.Show(areaList);
        }
        public void Show(List<Area> areaList)
        {
            foreach (var item in areaList)
            {
                Console.WriteLine("Area " +item.id + " , amountOfRows " + item.amOfRows + ", seats " + item.amOfPlacesInRow);
                Console.WriteLine("-------------------------");
            }
            Console.Read();
        }
    }
}
