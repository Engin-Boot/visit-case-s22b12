using Sender_Visit;
using System.IO;
using System;
using Xunit;

namespace Sender_Visit_UnitTest
{
    public static class SenderUnittest
    {
        private static string ReturnPath()
        {
            
            string file = "DateTimeSpaCustomer.csv";
            string path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            return path;
        }
        [Fact]
        public static void WhenFileisInputedThenItsExistenceisChecked()
        {
            var fr = new FileReader();
            String path = ReturnPath();
            Assert.True(fr.CheckFileExists(path));
            
        }

        [Fact]
        public static void WhenCsvFileisConvertedThenDataTableMustBeNotNull()
        {

            String path = ReturnPath();
            System.Data.DataTable dt = CsvToDatatable.ConvertCsvtoDatatable(path);
            Assert.False(dt == null) ;           
        }

        [Fact]
        public static void WhenDatatableisReturnedThenNumberofColumnsMustbe2()
        {

            String path = ReturnPath();
            System.Data.DataTable dt = CsvToDatatable.ConvertCsvtoDatatable(path);
            Assert.True(dt.Columns.Count == 2);
        }
 
    }

}
