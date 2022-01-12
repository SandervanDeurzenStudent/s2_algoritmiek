using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Seats
    {
        private int Id { get; set; }
        public Guests Guest { get; set; }

        public Seats(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return "     SEAT " + Id + "  " + Guest;
        }
    }
}
