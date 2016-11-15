using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICalendar
    {
        List<DateTime> Holidays { get; set; }
        float HoursADay { get; set; }
        float HoursAMonth { get; set; }
        float HoursAWeek { get; set; }
        float HoursAYear { get; set; }
        List<DayOfWeek> WeekEndDays { get; set; }
    }
}