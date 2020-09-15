using Sender_Visit;
using System.IO;
using System;
using Xunit;

namespace Sender_Visit_UnitTest
{
    public static class SenderUnittest
    {
        private static string ReturnPath(String file)
        {
            
            string path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            return path;
        }
        [Fact]
        public static void WhenFileisInputedThenItsExistenceisChecked()
        {
            var fr = new FileChecker();
            String path = ReturnPath("DateTimeSpaCustomer.csv");
            Assert.True(fr.CheckFileExists(path));
            
        }

        [Fact]
        public static void WhenCsvFileisConvertedThenDataTableMustBeNotNull()
        {

            String path = ReturnPath("DateTimeSpaCustomer.csv");
            System.Data.DataTable dt = CsvToDatatable.ConvertCsvtoDatatable(path);
            Assert.False(dt == null) ;           
        }

        [Fact]
        public static void WhenDatatableisReturnedThenNumberofColumnsMustbe2()
        {

            String path = ReturnPath("DateTimeSpaCustomer.csv");
            System.Data.DataTable dt = CsvToDatatable.ConvertCsvtoDatatable(path);
            Assert.True(dt.Columns.Count == 2);
        }

        [Fact]
        public static void WhenWrongFileisInputedThenDataTableMustBeNull()
        {
            String path = ReturnPath("Someone.csv");
            System.Data.DataTable dt = CsvToDatatable.ConvertCsvtoDatatable(path);
            Assert.True(dt == null);
        }


    }

}
