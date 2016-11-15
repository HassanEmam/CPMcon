using Calendars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Calendars
{
    public class Calendar : ICalendar
    {
        private List<DateTime> _holidays;
        private List<DayOfWeek> _weekEndDays;
        private float _hoursADay;
        private float _hoursAWeek;
        private float _hoursAMonth;
        private float _hoursAYear;

        public Calendar()
        {

        }
        public Calendar(List<DayOfWeek> weekEndDays, List<DateTime> holiDaysList, float hoursPerDay = 8, float hoursPerWeek = 40, float hoursPerMonth = 172, float hoursPerYear = 2076)
        {

        }

        public Calendar(List<DateTime> holidays, List<DayOfWeek> weekEndDays, float hoursADay, float hoursAWeek, float hoursAMonth, float hoursAYear)
        {
            this.Holidays = holidays;
            this.WeekEndDays = weekEndDays;
            this.HoursADay = hoursADay;
            this.HoursAWeek = hoursAWeek;
            this.HoursAMonth = hoursAMonth;
            this.HoursAYear = hoursAYear;
        }

        public List<DateTime> Holidays
        {
            get
            {
                return _holidays;
            }

            set
            {
                _holidays = value;
            }
        }

        public List<DayOfWeek> WeekEndDays
        {
            get
            {
                return _weekEndDays;
            }

            set
            {
                _weekEndDays = value;
            }
        }

        public float HoursADay
        {
            get
            {
                return _hoursADay;
            }

            set
            {
                _hoursADay = value;
            }
        }

        public float HoursAWeek
        {
            get
            {
                return _hoursAWeek;
            }

            set
            {
                _hoursAWeek = value;
            }
        }

        public float HoursAMonth
        {
            get
            {
                return _hoursAMonth;
            }

            set
            {
                _hoursAMonth = value;
            }
        }

        public float HoursAYear
        {
            get
            {
                return _hoursAYear;
            }

            set
            {
                _hoursAYear = value;
            }
        }

    }
}

