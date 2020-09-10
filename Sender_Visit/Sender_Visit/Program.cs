using System;
using System.IO;
using System.Data;
namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            String file = System.Configuration.ConfigurationManager.AppSettings["filename"];
            String path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            FileReader fileReader = new FileReader();

            DataTable dt = null;
            if (fileReader.CheckFileExists(path))
            {
                dt = CSVToDatatable.ConvertCSVtoDataTable(path);
                int Columns = dt.Columns.Count;
                Console.WriteLine(Columns);
                foreach (var columns in dt.Columns)
                {
                    Console.WriteLine(columns.ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        Console.Write(dt.Rows[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
