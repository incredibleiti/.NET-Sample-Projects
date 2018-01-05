using ConferenceTrackerLogicModule;
using System;
using System.Text.RegularExpressions;

namespace ConferenceTrackManagement
{
    public class Session_Talk
    {
        public string sTopic;
        public Session_Talk_Duration Duration = null;
        public Session_Talk(string _topicTitle)
        {
            try
            {
                string sTopic = "";
                int ntempDuration = -1;

                GetTalkDetails(_topicTitle, out sTopic, out ntempDuration);

                Duration = new Session_Talk_Duration(ntempDuration);

                if (CheckTitleisValidName(sTopic))
                    throw new Exception("Talk Title cannot be a numeric field");
                this.sTopic = sTopic;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
        private void GetTalkDetails(string _stopicTitle, out string _stopic, out int _nduration)
        {
            _stopic = "";
            _nduration = 0;

            try
            {
                string tempDuration = Regex.Match(_stopicTitle, @"\d+").Value;
                if (tempDuration != string.Empty)
                {
                    string tempNumber = Regex.Match(_stopicTitle.Replace(tempDuration, ""), @"\d+").Value;
                    if (tempNumber != "")
                        throw new Exception("Title Cannot contain multiple numneric values");
                    if (tempDuration.Length > 2)
                        throw new Exception("Talk Duration is Invalid");
                    _stopic = _stopicTitle.Replace(tempDuration, "").Replace("min", "").Replace("MIN", "").Replace("Min", "").Replace("Programg", "Programming");
                    _nduration = int.Parse(tempDuration);
                    return;
                }
                else
                {
                    if ((_stopicTitle.ToLower().Contains("lightning")) || (_stopicTitle.ToUpper().Contains("LIGHTNING")))
                        _stopic = _stopicTitle;
                    _nduration = 5;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        private bool CheckTitleisValidName(string title) //check if the Talk Title doesn't have any numeric value in it
        {
            return Regex.IsMatch(title, @"[0-9]+$");
        }

    }
}
