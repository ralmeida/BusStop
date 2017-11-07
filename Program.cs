using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusStop.Objects;

namespace BusStop
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Stops

            Stop busDepot = new Stop();
            Stop stop01 = new Stop(1, 0);
            Stop stop02 = new Stop(1, 1);
            Stop stop03 = new Stop(1, 2);
            Stop stop04 = new Stop(1, 3);
            Stop stop05 = new Stop(1, 4);
            Stop stop06 = new Stop(1, 5);
            Stop stop07 = new Stop(2, 0);
            Stop stop08 = new Stop(2, 1);
            Stop stop09 = new Stop(2, 2);
            Stop stop10 = new Stop(2, 3);
            Stop stop11 = new Stop(2, 4);
            Stop stop12 = new Stop(2, 5);

            #endregion

            List<Stop> Bus1Stops = new List<Stop>() { busDepot, stop01, stop02, stop03, stop04, stop05, stop06 };
            
            List<Stop> Bus2Stops = new List<Stop>() { busDepot, stop07, stop08, stop09, stop10, stop11, stop12 };

            List<Rider> Riders = new List<Rider>()
            {
                new Rider("Janice Dupree", stop01, stop03),
                new Rider("Frankly Rizzo", stop08, stop12)
            };

            BusManager busManager = new BusManager();
            busManager.LoadRiders(Riders);

            List<Bus> Busses = new List<Bus>()
            {
                new Bus("Blue Bus", busManager, Bus1Stops),
                new Bus("Red Bus", busManager, Bus2Stops)
            };

            busManager.Run();

            Console.ReadKey();
        }
    }
}
