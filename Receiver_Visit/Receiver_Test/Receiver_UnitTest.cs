using Xunit;
using Receiver_Visit;
using System;
using System.Data;
using System.IO;
using System.Globalization;
using Sender_Visit;
using System.Linq;


namespace Receiver_Test
{
    public static class ReceiverUnitTest
    {

        // ReSharper disable once RedundantAssignment
        private static DataTable Convert(DataTable dt)
        {
            
            String file = "DateTimeSpaCustomer.csv";
            String path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            dt = CsvToDatatable.ConvertCsvtoDatatable(path);

            return dt;
        }
        [Fact]
        public static void TestCasesForAnalyticModule()
        {

            DataTable dt = new DataTable();
            dt = Convert(dt);
            CultureInfo culture = new CultureInfo("en-US");
            string dateString = "07-07-2020";
            // ReSharper disable once RedundantExplicitArrayCreation
            DateTime date = DateTime.ParseExact(dateString, new string[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy" }, culture, DateTimeStyles.None);

            // ReSharper disable IdentifierTypo
            double actualaveragehour = Analytics.AverageInHour(dt, date);
            double expectedaveragehour = 2.5;
            Assert.Equal(expectedaveragehour, actualaveragehour);

            double actualavgweek = Analytics.AvergaeInweek(dt, date);
            double expectedavgweek = 18;
            Assert.Equal(expectedavgweek, actualavgweek);

            int actualavgmonth = Analytics.PeakLastMonth(dt);
            double expectedavgmonth = 25;
            Assert.Equal(expectedavgmonth, actualavgmonth);


        }
         
        [Fact]
        public static void ProgramReturnsCorrectcsv()
        {
            DataTable dt = new DataTable();
            dt = Convert(dt);

            String storingresultsfile = "Results.csv";
            String pathtoresultfile = Directory.GetCurrentDirectory();
            pathtoresultfile += @"\" + storingresultsfile;
            Assert.True(DataTableTocsv.ToCsv(dt, pathtoresultfile));

        }

        [Fact]
        public static void CheckDatatableColumnName()
        {
            DataTable dt = new DataTable();
            dt = Convert(dt);
            var actual = (from DataColumn x in dt.Columns
                select x.ColumnName).ToArray();

            Assert.Contains("Date", actual[0]);
            Assert.Contains("Time", actual[1]);

        }


    }
}
