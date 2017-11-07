using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStop.Objects
{
    public class Rider
    {
        public string Name { get; set; }

        public Stop Pickup { get; set; }
        public Stop Destination { get; set; }

        public Bus Bus { get; protected set; } = null;
        public bool OnBus { get { return Bus != null; } }
        public bool AtDestination { get; protected set; } = false;

        public Rider(string name, Stop start, Stop end)
        {
            Name = name;
            Pickup = start;
            Destination = end;
        }

        public void GetOnBus(Bus bus)
        {
            Bus = bus;
            bus.AddRider(this);
        }

        public void GetOffBus()
        {
            Bus = null;
            AtDestination = true;
        }

        public override string ToString()
        {
            return string.Format("Rider[{0}]", Name);
        }
    }
}
