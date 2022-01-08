using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSorter
{
    public abstract class BaseGuestsMaker
    {
        protected Guests _guests { get; private set; }

        public BaseGuestsMaker(Guests guests)
        {
            _guests = guests;
        }

        public abstract int ChanceOfOnTime();
    }

    public class SeniorGuestMaker : BaseGuestsMaker
    {
        public SeniorGuestMaker(Guests guests)
            : base(guests)
        {
        }
        public override int ChanceOfOnTime() => 40;

      
    }

    public class JuniorGuestMaker : BaseGuestsMaker
    {
        Random rnd = new Random();
        public JuniorGuestMaker(Guests guests)
            : base(guests)
        {
        }
        public override int ChanceOfOnTime() => 20;


    }
}
