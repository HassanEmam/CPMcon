using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class HelperFunctions
    {
        private static List<DateTime> _holiDays = new List<DateTime>();
        public static DateTime AddWorkdays(DateTime originalDate, int workDays, List<DateTime> holidays=null)
        {
            _holiDays = holidays;
            DateTime tmpDate = originalDate.AddDays(-1);
            while (workDays >= 1)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    !tmpDate.IsHoliday())
                    workDays--;
                

            }
            return tmpDate;
        }

        public static bool IsHoliday(this DateTime originalDate)
        {
            if (_holiDays != null)
            {
                foreach (DateTime day in _holiDays)
                {
                    if (originalDate.Equals(day))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
