using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace ConferenceTrackManagement
{
    public class ConferenceTrackerManagement
    {
        static void Main(string[] args)
        {
        }

        public string RunTrackerCode(bool InputFound, string[] _readlines)
        {
            string sresult = string.Empty;
            if (InputFound)
            {
                List<Session_Talk> _talkList = CreateTalkList(_readlines);//create a sorted (ascending) list of all the Talks in it
                List<ConferenceTrack> _conferenceTrack = CreateTracks(2);//create empty Conference Tracks based on input NumberOfTracks
                Scheduler(_talkList, _conferenceTrack);//schedule the final program by allocating talk based on the available timeslots
                sresult = RunConfrenceTrackerManager(_conferenceTrack);//write the final program in ConferenceProgram.txt file
                Console.WriteLine("Conference Program available");
            }
            return sresult!=string.Empty? sresult : "No Output";
        }

        public static List<Session_Talk> CreateTalkList(string[] _lines)//method to create a sorted chosen TalkList
        {
            List<Session_Talk> SelectedTalks = new List<Session_Talk>();
            foreach (string line in _lines)
            {
                Session_Talk _newTalk = new Session_Talk(line);
                SelectedTalks.Add(_newTalk);
            }
            List<Session_Talk> SortedTalkList = SelectedTalks.OrderBy(o => o.Duration._value).ToList();
            return SortedTalkList;
        }

        public static List<ConferenceTrack> CreateTracks(int NumberOfTracks)//method to create Conference Tracks
        {
            List<ConferenceTrack> CT = new List<ConferenceTrack>();
            ConferenceTrack TrackProgram;
            for (int i = 0; i < NumberOfTracks; i++)
            {
                TrackProgram = new ConferenceTrack(i + 1);
                CT.Add(TrackProgram);
            }
            return CT;
        }

        public static void Scheduler(List<Session_Talk> _talkList, List<ConferenceTrack> _conferenceTrack)//method to schedule the final program
        {
            foreach (ConferenceTrack CT in _conferenceTrack)
            {
                bool MorningSessionFull = false;
                bool EveningSessionFull = false;

                //morning session -->
                TimeSpan morningTS = CT.MorningSession.Duration;
                double tempTime = morningTS.TotalMinutes;
                for (int i = _talkList.Count - 1; i >= 0; i--)
                {
                    //for morning Session -->
                    if ((tempTime >= double.Parse(_talkList[i].Duration._value.ToString())) && (!MorningSessionFull))
                    {
                        CT.MorningSession.SessionTalks.Add(_talkList[i]);
                        tempTime = tempTime - double.Parse(_talkList[i].Duration._value.ToString());
                        _talkList.RemoveAt(i);
                        if (tempTime == 0)
                        {
                            MorningSessionFull = true;
                        }
                    }
                }

                CT.TimeSaved += int.Parse(tempTime.ToString());//total time saved in the morning session only

                //evening session -->
                TimeSpan eveningTS = CT.EveningSession.Duration;
                tempTime = eveningTS.TotalMinutes;
                for (int i = _talkList.Count - 1; i >= 0; i--)
                {
                    //for evening session -->
                    if (MorningSessionFull)
                    {
                        if ((tempTime >= double.Parse(_talkList[i].Duration._value.ToString())) && (!EveningSessionFull))
                        {
                            CT.EveningSession.SessionTalks.Add(_talkList[i]);
                            tempTime = tempTime - double.Parse(_talkList[i].Duration._value.ToString());
                            _talkList.RemoveAt(i);
                            if (tempTime == 0)
                            {
                                EveningSessionFull = true;
                            }
                        }
                    }
                }

                CT.TimeSaved += int.Parse(tempTime.ToString());//total time saved in the whole track

            }
        }

        public static string RunConfrenceTrackerManager(List<ConferenceTrack> _conferenceTrack)//method to write the final program
        {
            StringBuilder fs = new StringBuilder();
            try
            {
                string info = "Conference Track Program:";
                fs.Append(info, 0, info.Length);
                string newline = Environment.NewLine;
                fs.Append(newline, 0, newline.Length);
                foreach (ConferenceTrack CT in _conferenceTrack)
                {
                    var currentTime = new TimeSpan(9, 0, 0);
                    //trackNumber
                    info = "Track " + CT.TrackNumber.ToString() + ":";
                    fs.Append(info, 0, info.Length);
                    fs.Append(newline, 0, newline.Length);

                    //calculate the time ->//morning
                    TimeSpan resultTimeMorning = TimeSpan.FromHours(9);
                    resultTimeMorning = TimeSpan.FromMinutes(resultTimeMorning.TotalMinutes);
                    string fromTimeStringM = resultTimeMorning.ToString("hh':'mm");
                    //evening
                    TimeSpan resultTimeEvening = TimeSpan.FromHours(1);
                    resultTimeEvening = TimeSpan.FromMinutes(resultTimeEvening.TotalMinutes);
                    string fromTimeStringE = resultTimeEvening.ToString("hh':'mm");
                    //<- time calculation ends here

                    info = "Morning Session:";
                    fs.Append(info, 0, info.Length);
                    fs.Append(newline, 0, newline.Length);
                    for (int i = 0; i < CT.MorningSession.SessionTalks.Count; i++)
                    {


                        fromTimeStringM = resultTimeMorning.ToString("hh':'mm");
                        info = fromTimeStringM + "AM " + CT.MorningSession.SessionTalks[i].sTopic;
                        fs.Append(info, 0, info.Length);
                        fs.Append(newline, 0, newline.Length);

                        int time = CT.MorningSession.SessionTalks[i].Duration._value;
                        resultTimeMorning = TimeSpan.FromMinutes(resultTimeMorning.TotalMinutes + time);

                    }

                    info = "12:00PM Lunch";
                    fs.Append(info, 0, info.Length);
                    fs.Append(newline, 0, newline.Length);

                    info = "Evening Session:";
                    fs.Append(info, 0, info.Length);
                    fs.Append(newline, 0, newline.Length);
                    for (int i = 0; i < CT.EveningSession.SessionTalks.Count; i++)
                    {


                        fromTimeStringE = resultTimeEvening.ToString("hh':'mm");
                        info = fromTimeStringE + "PM " + CT.EveningSession.SessionTalks[i].sTopic;
                        fs.Append(info, 0, info.Length);
                        fs.Append(newline, 0, newline.Length);

                        int time = CT.EveningSession.SessionTalks[i].Duration._value;
                        resultTimeEvening = TimeSpan.FromMinutes(resultTimeEvening.TotalMinutes + time);

                    }

                    //networking event
                    if (resultTimeEvening < TimeSpan.FromHours(4))
                        resultTimeEvening = TimeSpan.FromHours(4);
                    if (resultTimeEvening > TimeSpan.FromHours(5))
                        resultTimeEvening = TimeSpan.FromHours(5);
                    fromTimeStringE = resultTimeEvening.ToString("hh':'mm");
                    info = fromTimeStringE + "PM Networking Event";
                    fs.Append(info, 0, info.Length);
                    fs.Append(newline, 0, newline.Length);
                }
            }

            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return fs.ToString();

        }
    }
}
