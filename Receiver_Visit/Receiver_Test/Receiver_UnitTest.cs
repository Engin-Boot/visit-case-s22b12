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
            dt = CSVToDatatable.ConvertCSVtoDataTable(@"C:\Users\320087401\source\repos\visit-case-s22b12\Receiver_Visit\Receiver_Test\DateTimeSpaCustomer.csv");
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
            System.Data.DataTable dt = CSVToDatatable.ConvertCSVtoDataTable(@"C:\Users\320087401\source\repos\visit-case-s22b12\Receiver_Visit\Receiver_Test\DateTimeSpaCustomer.csv");
            Assert.False(dt == null);
        }

    }
}
