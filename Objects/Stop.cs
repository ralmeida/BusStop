using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStop.Objects
{
    public class Stop
    {
        public float X { get; set; } = 0f;
        public float Y { get; set; } = 0f;

        public Stop(float x=0f, float y=0f)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Stop otherStop)
        {
            return otherStop.X == X && otherStop.Y == Y;
        }

        public override string ToString()
        {
            return string.Format("Stop[{0}]-[{1}]", X, Y);
        }
    }
}
