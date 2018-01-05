using ConferenceTrackerLogicModule;
using System;
using System.Collections.Generic;

namespace ConferenceTrackManagement
{
    public class ConferenceTrack
    {
        private int trackNumber;
        private int _morningsessionlength = 3;
        private Trackable_Sessions morningSession;
        private NonTrackable_Sessions lunch;
        private int _lunchsessionlength = 1;
        private Trackable_Sessions eveningSession;
        private int _eveningsessionlength = 4;
        private NonTrackable_Sessions networkingEvent;
        private int _networkinglength = 1;
        private int timeSaved;


        public int TrackNumber
        {
            get
            {
                return trackNumber;
            }

            set
            {
                trackNumber = value;
            }
        }
        public Trackable_Sessions MorningSession
        {
            get
            {
                return morningSession;
            }

            set
            {
                morningSession = value;
            }
        }
        public NonTrackable_Sessions Lunch
        {
            get
            {
                return lunch;
            }

            set
            {
                lunch = value;
            }
        }
        public Trackable_Sessions EveningSession
        {
            get
            {
                return eveningSession;
            }

            set
            {
                eveningSession = value;
            }
        }
        public NonTrackable_Sessions NetworkingEvent
        {
            get
            {
                return networkingEvent;
            }

            set
            {
                networkingEvent = value;
            }
        }
        public int TimeSaved
        {
            get
            {
                return timeSaved;
            }

            set
            {
                timeSaved = value;
            }
        }

        public ConferenceTrack(int trackNumber)
        {
            TrackNumber = trackNumber;
            MorningSession = new Trackable_Sessions("MorningSession", _morningsessionlength);
            Lunch = new NonTrackable_Sessions("Lunch", _lunchsessionlength);
            EveningSession = new Trackable_Sessions("EveningSession", _eveningsessionlength);
            NetworkingEvent = new NonTrackable_Sessions("NetworkingEvent", _networkinglength);
            TimeSaved = 0;
        }
    }
   
}