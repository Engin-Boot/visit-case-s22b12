using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Receiver_Visit
{
    class ReadConsole
    {
        int Columncount;
        public DataTable AddColumns(DataTable dt)
        {
            
                Columncount = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Columncount; i++)
                {
                    dt.Columns.Add(Console.ReadLine());
                }
                return dt;
          
        }
        public DataTable AddRows(DataTable dt)
        {
            
                string input = Console.ReadLine();
                while (!string.IsNullOrEmpty(input))
                {
                    dt.Rows.Add(Console.ReadLine());
                    input = Console.ReadLine();
                }
                return dt;
            
        }
    }
}
