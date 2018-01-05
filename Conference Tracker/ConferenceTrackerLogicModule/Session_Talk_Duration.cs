using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackerLogicModule
{
    public class Session_Talk_Duration
    {
        public int _value;
        public Session_Talk_Duration(int duration)
        {
            try
            {
                if (IsDurationisInLimit(duration))
                    throw new Exception("Talk Duration is Invalid");
                _value = duration;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool IsDurationisInLimit(int _duration)
        {
            if ((_duration < 0) || (_duration > 60))
                return true;
            return false;
        }
    }
}
