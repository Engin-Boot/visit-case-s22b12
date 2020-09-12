using Xunit;
using Receiver_Visit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;


namespace Receiver_Test
{
    public class Receiver_UnitTest 
    {
        [Fact]
        public static void TestCasesForAnlyticsModule()
        {

            DataTable dt = new DataTable();
            String file = "DateTimeSpaCustomer.csv";
            String path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            dt = CSVToDatatable.ConvertCSVtoDataTable(path);
            CultureInfo culture = new CultureInfo("en-US");
            string dateString = "07-07-2020";
            DateTime date = DateTime.ParseExact(dateString, new string[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy" }, culture, DateTimeStyles.None);
        
            
            double actualavghour = Analytics.AverageInHour(dt, date);
            double expectedavghour = 2.5;
            Assert.Equal(expectedavghour, actualavghour);
           
            double actualavgweek = Analytics.AvergaeInweek(dt,date);
            double expectedavgweek = 18;
            Assert.Equal(expectedavgweek, actualavgweek);
            
            int actualavgmonth= Analytics.PeakLastMonth(dt);
            double expectedavgmonth = 25;
            Assert.Equal(expectedavgmonth, actualavgmonth);

        }

        [Fact]
        public static void WhenCSVFileisConvertedThenDataTableMustBeNotNull()
        {
            DataTable dt = new DataTable();
            String file = "DateTimeSpaCustomer.csv";
            String path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            dt = CSVToDatatable.ConvertCSVtoDataTable(path);
            Assert.False(dt == null);
        }

    }
}
