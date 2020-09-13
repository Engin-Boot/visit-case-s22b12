using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;


namespace Receiver_Visit
{   // ReSharper disable IdentifierTypo
    public static class Analytics
    {
        private static List<string> GetDates(int year, int month)
        {
            var dates = new List<String>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                string[] datess = date.ToString(CultureInfo.CurrentCulture).Split(" ");
                dates.Add(datess[0]);
                
            }

            return dates;
        }

        private static Dictionary<string,int> CreateDictionary(List<string> dates,Dictionary<string,int> dic)
        {
            foreach(string date in dates)
            {
                dic.Add(date, 0);
            }
            return dic;
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
           // Analytics obj = new Analytics();
            DateTime date = DateTime.Now;
            var previousmonth = Convert.ToInt32(date.AddMonths(-2).Month.ToString());
            var year = Convert.ToInt32(DateTime.Now.Year.ToString());
            Dictionary<String, int> datestorage = new Dictionary<String, int>();

            List<String> dateInPreviousMonth = GetDates(year,previousmonth);
            datestorage = CreateDictionary(dateInPreviousMonth, datestorage);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dateInPreviousMonth.Contains(dt.Rows[i][0]))
                {
                    datestorage[dt.Rows[i][0].ToString() ?? throw new InvalidOperationException()] += 1;
                }
            }
            return FindPeak(datestorage);           
        }

    }
}
