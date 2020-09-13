using System;
using System.Text;
using System.Data;

namespace Receiver_Visit
{
    class ReadConsole
    {
        int _columncount;
        public DataTable AddColumns(DataTable dt)
        {
            
                _columncount = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < _columncount; i++)
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
