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
            // create timer
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);

            // add method to elapsed-event
            timer.Elapsed += (source, e) =>
            {
                method();
            };

            // start timer
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
            // create timer
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);

            // add method to elapsed-event
            timer.Elapsed += (source, e) =>
            {
                method();
            };

            // remove auto-restart
            timer.AutoReset = false;

            // start timer
            timer.Enabled = true;
            timer.Start();

            // Returns stop handle which can be used for stopping
            return timer as IDisposable;
        }
    }
}