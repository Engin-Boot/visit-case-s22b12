using System;
using System.Data;


namespace Receiver_Visit
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            ReadConsole datatablereader = new ReadConsole();
            dt = datatablereader.AddColumns(dt);
            dt = datatablereader.AddRows(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
