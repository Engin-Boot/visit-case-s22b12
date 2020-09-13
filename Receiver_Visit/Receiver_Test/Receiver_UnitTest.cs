using Xunit;
using Receiver_Visit;
using System;
using System.Data;
using System.IO;
using System.Globalization;
using Sender_Visit;


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



    }
}
