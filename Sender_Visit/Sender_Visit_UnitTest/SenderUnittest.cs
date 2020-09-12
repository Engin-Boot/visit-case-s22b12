using Sender_Visit;
using System.IO;
using System;
using Xunit;

namespace Sender_Visit_UnitTest
{
    public static class SenderUnittest
    {
        [Fact]
        public static void WhenFileisInputedThenItsExistenceisChecked()
        {
            var fr = new FileReader();
            string file = "DateTimeSpaCustomer.csv";
            string path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            Console.WriteLine(path);
            Assert.True(fr.CheckFileExists(path));
            
        }

        [Fact]
        public static void WhenCsvFileisConvertedThenDataTableMustBeNotNull()
        {
            string file = "DateTimeSpaCustomer.csv";
            string path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            Console.WriteLine(path);
            System.Data.DataTable dt = CsvToDatatable.ConvertCsvtoDatatable(path);
            Assert.False(dt == null) ;           
        }

        [Fact]
        public static void WhenDatatableisReturnedThenNumberofColumnsMustbe2()
        {
            string file = "DateTimeSpaCustomer.csv";
            string path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            Console.WriteLine(path);
            System.Data.DataTable dt = CsvToDatatable.ConvertCsvtoDatatable(path);
            Assert.True(dt.Columns.Count == 2);
        }
 
    }

}
