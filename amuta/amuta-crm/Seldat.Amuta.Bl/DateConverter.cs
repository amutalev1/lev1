using System;
using System.Globalization;


namespace Seldat.Amuta.Bl
{
    public class DateConverter
    {
        public static string GetHebrewDate(DateTime gregorianDate)
        {
            Calendar HebCal = new HebrewCalendar();
            string hebrewDate = $"{HebCal.GetYear(gregorianDate)}-{HebCal.GetMonth(gregorianDate)}-{HebCal.GetDayOfMonth(gregorianDate)}";
            return hebrewDate;
        }

    }
}
