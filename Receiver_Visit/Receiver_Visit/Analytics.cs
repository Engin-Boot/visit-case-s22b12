using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.IO;

namespace Receiver_Visit
{
    public class Analytics
    {
        Dictionary<String, int> datestorage = new Dictionary<String, int>();
        public static List<string> GetDates(int year, int month,Dictionary<String,int> dic)
        {
            var dates = new List<String>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                string[] datess = date.ToString().Split(" ");
                dates.Add(datess[0]);
                dic.Add(datess[0], 0);
            }

            return dates;
        }

        public static int FindPeak(Dictionary<String,int> dic)
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

        public static List<String> AddDaysofaWeek(List<String> dates,DateTime Date)
        {
            for (int i = 0; i < 8; i++)
            {
                string[] adddays = Date.AddDays(i).ToString().Split(" ");

                dates.Add(adddays[0]);
            }
            return dates;
        }

        public static double AverageInHour(DataTable dt, DateTime Datein)
        {
            string[] date = Datein.Date.ToString().Split(" ");
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

        public static double AvergaeInweek(DataTable dt, DateTime Date)
        {
            int visitcount = 0;
            List<String> dates = new List<String>();

            dates = AddDaysofaWeek(dates, Date);
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
            
            List<String> DateInPreviousMonth = GetDates(year,previousmonth, obj.datestorage);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (DateInPreviousMonth.Contains(dt.Rows[i][0]))
                {
                    obj.datestorage[dt.Rows[i][0].ToString()] += 1;
                }
            }
             return FindPeak(obj.datestorage);
           
        }




    }
}
