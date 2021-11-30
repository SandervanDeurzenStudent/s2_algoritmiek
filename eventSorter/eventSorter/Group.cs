using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    class Group
    {
        //lijst van guests
        //groep moet adult hebben
        public int GroupId { get; set; }
        public int AmountOfPeopleInGroup { get; set; }
        public bool hasAdult { get; set; }

        List<Guests> GuestList = new List<Guests>();
    }
}
