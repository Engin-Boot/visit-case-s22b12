using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Sender_Visit
{
   public static class CsvToDatatable
    {
        private static DataTable AddColumns(DataTable dt,String[] headers)
        {
            try
            {
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                return dt;
            }
            catch(Exception )
            {
                
                return null;
            }
        }
        private static DataTable AddNewRows(DataTable dt,String[] header,StreamReader sr)
        {
            
            string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            DataRow dr = dt.NewRow();

           
            for (int i = 0; i < header.Length; i++)
            {
                dr[i] = rows[i];
            }
            dt.Rows.Add(dr);
            return dt;
        }
        private static DataTable AddRows(DataTable dt,StreamReader sr,String[] header)
        {
            try
            {
                while (!sr.EndOfStream)
                {
                    dt = AddNewRows(dt, header, sr);
                }
                return dt;
            }
            catch(Exception)
            {
                
                return null;
            }
        }

        public static DataTable ConvertCsvtoDatatable(string strFilePath)
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
            catch (Exception)
            {
               
                return null;
            }
        }
    }
}
