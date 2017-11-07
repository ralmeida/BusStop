using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusStop.Objects
{
    public class Bus
    {
        public Guid ID { get; protected set; }

        public string Name { get; set; }

        protected BusManager BusManager { get; set; }

        public List<Stop> Stops { get; set; } = new List<Stop>();

        public List<Rider> Riders { get; set; } = new List<Rider>();

        public bool Running { get; protected set; } = false;

        public List<int> UsedStops { get; protected set; } = new List<int>();

        public Bus(string name, BusManager busManager, List<Stop> route)
        {
            ID = Guid.NewGuid();
            Name = name;
            BusManager = busManager;
            Stops = route;

            if (BusManager.GetBus(this) == null)
                BusManager.AddBus(this);
        }

        public void StartRote()
        {
            Console.WriteLine("|{0} Starting Rote at: {1}", this, DateTime.Now);

            UsedStops = new List<int>();
            UsedStops.Add(0);
            Running = true;

            while(Running)
            {
                Stop();
                Thread.Sleep(1000); //wait one second
            }
        }

        public void Stop()
        {
            int currentStopIndx = UsedStops.Count;

            if(currentStopIndx < Stops.Count)
            {
                Stop currentStop = Stops[currentStopIndx];

                Console.WriteLine("-|{0} is stopping at {1} [{2}]", this, currentStop, DateTime.Now);

                BusManager.GetRidersFromStop(currentStop).ForEach((rider) => {
                    Console.WriteLine(" -| {0} has Picked up {1} at stop {2} with destination of {3} [{4}]", this, rider, currentStop, rider.Destination, DateTime.Now);
                    rider.GetOnBus(this);
                });

                Riders.ForEach((rider) => {
                    if (rider.Destination.Equals(currentStop)) {
                        Console.WriteLine(" -| {0} has dropped off {1} at stop {2} [{3}]", this, rider, currentStop, DateTime.Now);
                        rider.GetOffBus();
                    }
                });

                //Stops[currentStop]
                UsedStops.Add(currentStopIndx);
            }
            else
                Running = false;
        }

        public void AddRider(Rider rider)
        {
            Riders.Add(rider);
        }
        public void RemoveRider(Rider rider)
        {
            Riders.Remove(rider);
        }

        public bool Equals(Bus otherBus)
        {
            return otherBus.ID == ID;
        }

        public override string ToString()
        {
            return string.Format("Bus[{0}]", Name);
        }
    }
}
