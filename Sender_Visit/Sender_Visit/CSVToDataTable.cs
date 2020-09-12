using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Sender_Visit
{
   public static class CsvToDatatable
    {
        public static DataTable AddColumns(DataTable dt,String[] headers)
        {
            try
            {
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                return dt;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static DataTable AddNewRows(DataTable dt,String[] Header,StreamReader sr)
        {
            string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            DataRow dr = dt.NewRow();

           
            for (int i = 0; i < Header.Length; i++)
            {
                dr[i] = rows[i];
            }
            dt.Rows.Add(dr);
            return dt;
        }
        public static DataTable AddRows(DataTable dt,StreamReader sr,String[] Header)
        {
            try
            {
                while (!sr.EndOfStream)
                {
                    dt = AddNewRows(dt, Header, sr);
                }
                return dt;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            try
            {
                StreamReader sr = new StreamReader(strFilePath);
                string[] headers = sr.ReadLine().Split(',');
                DataTable dt = new DataTable();
                dt = CsvToDatatable.AddColumns(dt,headers);
                dt = CsvToDatatable.AddRows(dt, sr, headers);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
