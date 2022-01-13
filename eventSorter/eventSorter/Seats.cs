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
        public Seats(int id, Guests guest)
        {
            Id = id;
            Guest = guest;
        }

        public override string ToString()
        {
            return "     SEAT " + Id + "  " + Guest;
        }
    }
}
