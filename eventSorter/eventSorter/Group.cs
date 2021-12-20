using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Group
    {
        //lijst van guests
        //groep moet adult hebben
        public int GroupId { get; set; }
        public int MaxGroupSize { get; set; }
        public int AmountOfPeopleInGroup { get; set; }
        public bool HasAdult { get; set; }

        public int AmountOfChildrenInGroup { get; set; }
        public Guests[] GuestList { get; set; }

        public Group(int id, int maxGroupSize ,int amOfPeopleInGroup, bool hasAdult, Guests[] guestList)
        {
            GroupId = id;
            MaxGroupSize = maxGroupSize;
            AmountOfPeopleInGroup = amOfPeopleInGroup;
            HasAdult = hasAdult;
            GuestList = guestList;
        }
        public Group(int id, int maxGroupSize, int amOfPeopleInGroup, bool hasAdult, int amountOfChildrenInGroup, Guests[] guestList)
        {
            GroupId = id;
            MaxGroupSize = maxGroupSize;
            AmountOfPeopleInGroup = amOfPeopleInGroup;
            HasAdult = hasAdult;
            AmountOfChildrenInGroup = amountOfChildrenInGroup;
            GuestList = guestList;
        }
        public Group(int id, int maxGroupSize, int amOfPeopleInGroup, bool hasAdult)
        {
            GroupId = id;
            MaxGroupSize = maxGroupSize;
            AmountOfPeopleInGroup = amOfPeopleInGroup;
            HasAdult = hasAdult;
        }
    }
}
