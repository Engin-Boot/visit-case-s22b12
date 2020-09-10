using System;
using System.Data;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            int Columncount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Columncount; i++)
            {
                dt.Columns.Add(Console.ReadLine());
            }

            int RowCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(RowCount);
            for (int i = 1; i < RowCount; i++)
            {
                for (int j = 0; j < Columncount; j++)
                {
                    dt.Rows.Add(Console.ReadLine());
                }
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < Columncount; j++)
                {
                    Console.Write(dt.Rows[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
