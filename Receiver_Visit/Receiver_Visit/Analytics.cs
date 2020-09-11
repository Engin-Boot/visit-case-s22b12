using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;




namespace Receiver_Visit
{
    class Analytics
    {
        public static List<string> GetDates(int year, int month)
        {
            var dates = new List<String>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                string[] datess = date.ToString().Split(" ");
                dates.Add(datess[0]);
            }

            return dates;
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

        public void AverageInHour(DataTable dt, DateTime Datein)
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
            Console.WriteLine(visitcount/8.0);
        }

        public void AvergaeInweek(DataTable dt, DateTime Date)
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
            Console.WriteLine(visitcount / 7.0);
        }




        public void PeakLastMonth(DataTable dt)
        {
            DateTime date = DateTime.Now;
            var previousmonth = Convert.ToInt32(date.AddMonths(-2).Month.ToString());
            var year = Convert.ToInt32(DateTime.Now.Year.ToString());
            List<String> DateInPreviousMonth = GetDates(year,previousmonth);
            int visitcount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (DateInPreviousMonth.Contains(dt.Rows[i][0]))
                {
                    visitcount += 1;
                }
            }
            Console.WriteLine(visitcount/Convert.ToDouble(DateInPreviousMonth.Count));
           
        }




    }
}