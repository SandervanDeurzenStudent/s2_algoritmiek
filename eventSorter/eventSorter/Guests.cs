using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public class Guests
    {
        public int Id { get; set; }
        public bool IsAdult { get; set; }
        public int Age { get; set; }
        public bool OnTime { get; set; }
        public int GroupId { get; set; }

        public Guests()
        {

        }
        public Guests(int id, bool isAdult, int age, bool onTime, int groupId)
        {
            Id = id;
            IsAdult = isAdult;
            Age = age;
            OnTime = onTime;
            GroupId = groupId;
        }
    }
}
