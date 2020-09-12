using Xunit;
using Sender_Visit;
using System.IO;
using System;

namespace Sender_Visit_UnitTest
{
    public class SenderUnittest
    {
        [Fact]
        public static void WhenFileisInputedThenItsExistenceisChecked()
        {
            var fr = new Sender_Visit.FileReader();
            string file = "DateTimeSpaCustomer.csv";
            string path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            Console.WriteLine(path);
            Assert.True(fr.CheckFileExists(path));
            
        }

        [Fact]
        public static void WhenCSVFileisConvertedThenDataTableMustBeNotNull()
        {
            string file = "DateTimeSpaCustomer.csv";
            string path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            Console.WriteLine(path);
            System.Data.DataTable dt = CsvToDatatable.ConvertCSVtoDataTable(path);
            Assert.False(dt == null) ;           
        }

        [Fact]
        public static void WhenDatatableisReturnedThenNumberofColumnsMustbe2()
        {
            string file = "DateTimeSpaCustomer.csv";
            string path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            Console.WriteLine(path);
            System.Data.DataTable dt = CsvToDatatable.ConvertCSVtoDataTable(path);
            Assert.True(dt.Columns.Count == 2);
        }
 
    }

}
