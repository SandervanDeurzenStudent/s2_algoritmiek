using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    class Guests
    {
        public int Id { get; set; }
        public bool IsAdult { get; set; }
        public int Age { get; set; }
        public bool OnTime { get; set; }

        public Guests(int id, bool isAdult, int age, bool onTime)
        {
            Id = id;
            IsAdult = IsAdult;
            Age = age;
            OnTime = onTime;
        }
    }
}
