using System;
using System.IO;
using System.Data;

namespace Sender_Visit
{
    public static  class Program
    {
        private static void WriteOnConsole(DataTable dt)
        {
            int cols = dt.Columns.Count;
            Console.WriteLine(cols);
            foreach (var columns in dt.Columns)
            {
                Console.WriteLine(columns.ToString());
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j <cols; j++)
                {
                    Console.WriteLine(dt.Rows[i][j]);
                }
            }
        }
        static void Main()
        {
            String file = System.Configuration.ConfigurationManager.AppSettings["filename"];
            String path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            FileReader fileReader = new FileReader();

            DataTable dt = null;
            if (fileReader.CheckFileExists(path))
            {
                
                dt = CsvToDatatable.ConvertCsvtoDatatable(path);
            }
            if(dt!=null)
            {
                WriteOnConsole(dt);
                
            }
        }
    }
}
