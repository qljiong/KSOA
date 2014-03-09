using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Common
{
    public class StopWatch
    {
        private readonly DateTime startTime;
        private DateTime lastMeasureTime;
        private DateTime endTime;

        public StopWatch()
        {
            lastMeasureTime = startTime = DateTime.Now;
        }

        public void Stop()
        {
            endTime = DateTime.Now;
        }

        public long ElapsedMs()
        {
            return (long)endTime.Subtract(startTime).TotalMilliseconds;
        }

        public long LastElapsedMs()
        {
            long ms = (long)DateTime.Now.Subtract(lastMeasureTime).TotalMilliseconds;
            lastMeasureTime = DateTime.Now;
            return ms;
        }
    }
}
