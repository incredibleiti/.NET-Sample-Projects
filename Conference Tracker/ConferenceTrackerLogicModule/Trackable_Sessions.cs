using ConferenceTrackManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackerLogicModule
{
    public class Trackable_Sessions
    {
        private string _name;
        private TimeSpan _duration;
        private List<Session_Talk> _sessionTalks;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public TimeSpan Duration
        {
            get
            {
                return _duration;
            }

            set
            {
                _duration = value;
            }
        }
        public List<Session_Talk> SessionTalks
        {
            get
            {
                return _sessionTalks;
            }

            set
            {
                _sessionTalks = value;
            }
        }
        public Trackable_Sessions(string name, int Hours)
        {
            // Class Constructor for
            Name = name;
            Duration = new TimeSpan(Hours, 0, 0);
            SessionTalks = new List<Session_Talk>();
        }
    }
}
