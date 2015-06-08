using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_ReXcape
{
    public static class EasyTimer
    {
        /// <summary>
        /// set interval for looping by given delay
        /// </summary>
        /// <param name="method"></param>
        /// <param name="delayInMilliseconds"></param>
        /// <returns>Timer / itself</returns>
        public static IDisposable SetInterval(Action method, int delayInMilliseconds)
        {
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);
            timer.Elapsed += (source, e) =>
            {
                method();
            };

            timer.Enabled = true;
            timer.Start();
            
            // Returns stop handle which can be used for stopping
            return timer as IDisposable;
        }

        /// <summary>
        /// set timeout. wait given time.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="delayInMilliseconds"></param>
        /// <returns>Timer / itself</returns>
        public static IDisposable SetTimeout(Action method, int delayInMilliseconds)
        {
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);
            timer.Elapsed += (source, e) =>
            {
                method();
            };

            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Start();

            // Returns stop handle which can be used for stopping
            return timer as IDisposable;
        }
    }
}