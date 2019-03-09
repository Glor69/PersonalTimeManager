using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace PersonalTimeManager.Model
{
    public class DispatcherForTimers
    {
    }

    public class CoustumDT : DispatcherTimer
    {

    }

    // singleton
    public static class Clock 
    {
        private static readonly DispatcherTimer dispatcherTimer;

        static Clock()
        {
            dispatcherTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
        }

        public static void Action(EventHandler<object> action)
        {
            dispatcherTimer.Tick += action;
        }

        public static void Start()
        {
            dispatcherTimer.Start();
        }

        public static void Stop()
        {
            dispatcherTimer.Stop();
        }
    }
}
