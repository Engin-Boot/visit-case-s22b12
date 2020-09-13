using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;


namespace Receiver_Visit
{   // ReSharper disable IdentifierTypo
    public class Analytics
    {
        public Dictionary<String, int> Datestorage = new Dictionary<String, int>();
        private static List<string> GetDates(int year, int month,Dictionary<String,int> dic)
        {
            var dates = new List<String>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                string[] datess = date.ToString(CultureInfo.CurrentCulture).Split(" ");
                dates.Add(datess[0]);
                dic.Add(datess[0], 0);
            }

            return dates;
        }

        private static int FindPeak(Dictionary<String,int> dic)
        {
            int max = 0;
            foreach(String key in dic.Keys)
            {
                if(dic[key]>max)
                {
                    max = dic[key];
                }
            }
            return max;
        }

        private static List<String> AddDaysofaWeek(List<String> dates,DateTime date)
        {
            for (int i = 0; i < 8; i++)
            {
                string[] adddays = date.AddDays(i).ToString(CultureInfo.CurrentCulture).Split(" ");

                dates.Add(adddays[0]);
            }
            return dates;
        }

        public static double AverageInHour(DataTable dt, DateTime datein)
        {
            string[] date = datein.Date.ToString(CultureInfo.CurrentCulture).Split(" ");
            int visitcount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dateintable = dt.Rows[i][0];
                if (dateintable.Equals(date[0]))
                {
                    visitcount += 1;
                }
            }
            return visitcount/8.0;
        }

        public static double AvergaeInweek(DataTable dt, DateTime date)
        {
            int visitcount = 0;
            List<String> dates = new List<String>();

            dates = AddDaysofaWeek(dates, date);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dates.Contains(dt.Rows[i][0]))
                {
                    visitcount += 1;
                }
                    
            }
            return visitcount / 7.0;
        }




        public static int PeakLastMonth(DataTable dt)
        {
            Analytics obj = new Analytics();
            DateTime date = DateTime.Now;
            var previousmonth = Convert.ToInt32(date.AddMonths(-2).Month.ToString());
            var year = Convert.ToInt32(DateTime.Now.Year.ToString());
            
            List<String> dateInPreviousMonth = GetDates(year,previousmonth, obj.Datestorage);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dateInPreviousMonth.Contains(dt.Rows[i][0]))
                {
                   obj.Datestorage[dt.Rows[i][0].ToString()] += 1;
                }
            }
            return FindPeak(obj.Datestorage);           
        }

    }
}
