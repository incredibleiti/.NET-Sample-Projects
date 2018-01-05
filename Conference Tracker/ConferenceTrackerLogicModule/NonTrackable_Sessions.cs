using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackerLogicModule
{
    public class NonTrackable_Sessions
    {
        private string name;
        private TimeSpan duration;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
            }
        }

        public NonTrackable_Sessions(string name, int Hours)
        {
            Name = name;
            Duration = new TimeSpan(Hours, 0, 0);
        }
    }
}
