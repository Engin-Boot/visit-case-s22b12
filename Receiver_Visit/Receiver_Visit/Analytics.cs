using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;


namespace Receiver_Visit
{
    class Analytics
    {
        public void AverageInHour(DataTable dt)
        {
            var qry = from row in dt.AsEnumerable()
                      group row by row.Field<string>("source") into grp
                      select new
                      {
                          source = grp.Key,
                          avg = new TimeSpan(0, 0, (int)(grp.Average(r => r.Field<DateTime>("Time").TimeOfDay.TotalSeconds))),
                      };
            foreach (var grp in qry)
            {
                Console.WriteLine(String.Format("average per hour = {0}", grp.avg));
            }

        }

        public void AvergaeInweek(DataTable dt)
        {
            var qry = from row in dt.AsEnumerable()

                      group row by row.Field<string>("source") into grp
                      select new
                      {

                          source = grp.Key,
                          avg = new TimeSpan(0, 0, (int)(grp.Average(r => r.Field<DateTime>("Time").TimeOfDay.TotalSeconds))),
                          //avg2 = new TimeSpan(0, 0, (int)(grp.Average(r => r.Field<DateTime>("Time").TimeOfDay.TotalSeconds))),



                      };
            foreach (var grp in qry)
            {
                Console.WriteLine(String.Format("average = {0}", grp.avg));
            }

        }

        public void PeakLastMonth(DataTable dt)
        {
            var qry = from row in dt.AsEnumerable()
                      group row by row.Field<string>("source") into grp
                      select new
                      {
                          source = grp.Key,
                          avg = new TimeSpan(0,0, (int)(grp.Max(r => r.Field<DateTime>("Time").TimeOfDay.TotalSeconds))),

                      };
            foreach (var grp in qry)
            {
                Console.WriteLine(String.Format("Maximum = {0}", (grp.avg)));


            }
        }
    }
}
