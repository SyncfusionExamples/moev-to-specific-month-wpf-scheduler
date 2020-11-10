using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace WpfScheduler
{
    public class Meeting
    {
        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Brush color { get; set; }

    }
}
