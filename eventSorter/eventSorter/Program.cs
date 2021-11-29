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
        
        List<Area> areaList = new List<Area>();
        List<Area> areaList2 = new List<Area>();
        List<Rows> RowList = new List<Rows>();
        static void Main(string[] args)
        {
           
            Program p = new Program();
            p.makeAreas();
            
            
        }
        public void makeAreas()
        {
            Random rnd = new Random();
            int rowsAmount = rnd.Next(1, 3);
            int k = 0;
            char c1 = 'A';

            //making of increment alphabet
            string currentCell = "A1";
            int currentRow = int.Parse(Regex.Match(currentCell, @"\d+").Value);
            string currentCol = Regex.Match(currentCell, @"[A-Z]+").Value;
            foreach (string column in GetColumns())
            {
                Console.WriteLine(column + currentRow);
            }
            for (int i = 0; i < 4; i++)
            {
                Area area = new Area(i, rnd.Next(1, 3));
                areaList.Add(area);
                for (int j = 0; j < area.amOfRows; j++)
                {
                    //k++;
                    Area areas = new Area(c1, rnd.Next(1, 3), rnd.Next(3, 10));
                    areaList2.Add(areas);
                    c1++; // c1 is 'B' now

                }
            }


            



            //addToArea

            //for (int i = 0; i < areaList.Count(); i++)
            //{
            //    Rows row = new Rows(i, rnd.Next(3, 10));
            //    RowList.Add(row);

            //}
            foreach (var item in areaList2)
            {
                Console.WriteLine("Area " +item.id + " , amountOfRows " + item.amOfRows + ", seats " + item.amOfPlacesInRow);
                Console.WriteLine("-------------------------");
            }
            //foreach (var item in RowList)
            //{
            //    Console.WriteLine(item.amOfRows);
            //    Console.WriteLine("--------------------");
            //}
            Console.Read();
        }
        public static IEnumerable<string> GetColumns()
        {
            string s = null;
            for (char c2 = 'A'; c2 <= 'Z' + 1; c2++)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    yield return s + c;
                }
                s = c2.ToString();
            }
        }
    }
}
