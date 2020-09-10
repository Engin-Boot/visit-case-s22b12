// ﻿using System;
// using System.Data;


// namespace Receiver_Visit
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             DataTable dt = new DataTable();
//             ReadConsole datatablereader = new ReadConsole();
//             dt = datatablereader.AddColumns(dt);
//             dt = datatablereader.AddRows(dt);

//             for (int i = 0; i < dt.Rows.Count; i++)
//             {
                
//                 for (int j = 0; j < dt.Columns.Count; j++)
//                 {
//                     Console.Write(dt.Rows[i][j] + " ");
//                 }
//                 Console.WriteLine();
//             }
//         }
//     }
// }

using System;
using System.Data;


namespace Receiver_Visit
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Time", typeof(DateTime));
            dt.Columns.Add("source");
            dt.Rows.Add("2020-01-10 07:12:06.163");
            dt.Rows.Add("2020-2-10 09:10:06.163");
            dt.Rows.Add("2020-3-10 09:15:06.163");
            dt.Rows.Add("2020-4-10 05:14:06.163");
            dt.Rows.Add("2020-5-10 07:20:06.163");
            dt.Rows.Add("2020-6-10 08:20:06.163");
            dt.Rows.Add("2020-11-10 08:20:06.163");

            foreach (DataRow dataRow in dt.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }

            Analytics an = new Analytics();
            an.AverageInHour(dt);
            an.AvergaeInweek(dt);
            an.PeakLastMonth(dt);


        }
    }

}




