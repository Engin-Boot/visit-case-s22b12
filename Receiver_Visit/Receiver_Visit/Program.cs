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
using System.Globalization;
using System.IO;


namespace Receiver_Visit
{
    class Program
    {
        static void Main(string[] args)
        {
            String file = System.Configuration.ConfigurationManager.AppSettings["filename"];
            String path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            DataTable dt = new DataTable();
            dt = CSVToDatatable.ConvertCSVtoDataTable(path);
            CultureInfo culture = new CultureInfo("en-US");
            string dateString = "07-01-2020";
            DateTime date= DateTime.ParseExact(dateString, new string[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy" }, culture, DateTimeStyles.None);

            if(dt!=null)
            {
                Analytics an = new Analytics();
                an.AverageInHour(dt,date);
                an.AvergaeInweek(dt, date);
                an.PeakLastMonth(dt);

            }

            

            


        }
    }

}




