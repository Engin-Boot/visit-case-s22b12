using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Receiver_Visit
{
    public static class DataTableTocsv
    {
       
            public static void ToCsv(DataTable dt, string strFilePath)
            {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(strFilePath, sb.ToString());
        }
        }
    
}
