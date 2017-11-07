using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStop.Objects
{
    public class BusManager
    {
        public List<Bus> Busses { get; protected set; } = new List<Bus>();
        public List<Rider> Riders { get; protected set; } = new List<Rider>();

        public BusManager()
        {
            Busses = new List<Bus>();
            Riders = new List<Rider>();
        }
        public BusManager(List<Bus> busses, List<Rider> riders)
        {
            Busses = busses;
            Riders = riders;
        }

        public void LoadBusses(List<Bus> busses)
        {
            Busses = busses;
        }
        public void AddBus(Bus bus) { Busses.Add(bus); }
        public Bus GetBus(Bus bus)
        {
            Bus foundBus = null;
            Busses.ForEach((b) => { if (b.Equals(bus)) { foundBus = b; } });
            return foundBus;
        }

        public void LoadRiders(List<Rider> riders)
        {
            Riders = riders;
        }

        public bool BussesRunning
        {
            get
            {
                bool running = false;
                Busses.ForEach((b) => { if (!running) running = b.Running; });
                return running;
            }
        }

        public List<Rider> GetRidersFromStop(Stop stop)
        {
            List<Rider> ridersAtStop = new List<Rider>();
            Riders.ForEach((r) => { if (r.Pickup.Equals(stop)) ridersAtStop.Add(r); });
            return ridersAtStop;
        }

        public void Run()
        {
            foreach(Bus bus in Busses)
            {
                Task.Run(() => {

                    bus.StartRote();
                });
            }
        }
    }
}
