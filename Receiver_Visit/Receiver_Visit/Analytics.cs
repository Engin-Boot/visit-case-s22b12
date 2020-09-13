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
            var dates = new List<string>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                var datess = date.ToString(CultureInfo.CurrentCulture).Split(" ");
                dates.Add(datess[0]);
                
            }

            return dates;
        }

        private static Dictionary<string,int> CreateDictionary(List<String> dates,Dictionary<String,int> dic)
        {
            foreach(String date in dates)
            {
                dic.Add(date,0);
            }
            return dic;
        }

        private static int FindPeak(Dictionary<string,int> dic)
        {
            return dic.Keys.Select(key => dic[key]).Prepend(0).Max();
        }

        private static List<string> AddDaysofaWeek(List<string> dates,DateTime date)
        {
            for (var i = 0; i < 8; i++)
            {
                var adddays = date.AddDays(i).ToString(CultureInfo.CurrentCulture).Split(" ");

                dates.Add(adddays[0]);
            }
            return dates;
        }

        public static double AverageInHour(DataTable dt, DateTime datein)
        {
            var date = datein.Date.ToString(CultureInfo.CurrentCulture).Split(" ");
            var visitcount = 0;
            for (var i = 0; i < dt.Rows.Count; i++)
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
            var visitcount = 0;
            var dates = new List<string>();

            dates = AddDaysofaWeek(dates, date);
            for (var i = 0; i < dt.Rows.Count; i++)
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
          
            var date = DateTime.Now;
            var previousmonth = Convert.ToInt32(date.AddMonths(-2).Month.ToString());
            var year = Convert.ToInt32(DateTime.Now.Year.ToString());
            
            var dateInPreviousMonth = GetDates(year,previousmonth);
            Dictionary<string, int> datastorage= new Dictionary<string, int>();
            datastorage = CreateDictionary(dateInPreviousMonth, datastorage);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                if (dateInPreviousMonth.Contains(dt.Rows[i][0]))
                {
                    // ReSharper disable once AssignNullToNotNullAttribute
                    datastorage[dt.Rows[i][0].ToString()] += 1;
                }
            }
            return FindPeak(datastorage);           
        }

    }
}
