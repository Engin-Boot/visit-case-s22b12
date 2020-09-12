using System;
using System.Data;
using System.Globalization;
using System.IO;


namespace Receiver_Visit
{

    
    class Program
    {

        static void FileExistsfunction(String file)
        {
            if(File.Exists(file))
            {
                File.Delete(file);
                var myfile= File.Create(file);
                myfile.Close();
                
            }
            else
            {
                var myFile=File.Create(file);
                myFile.Close();
            }

        }
        static public DataTable CreateDataTableResults(DataTable dtresults,double avghour,double avgweek,int avgpeak)
        {
            dtresults.Columns.Add("FunctionName");
            dtresults.Columns.Add("Result");

            dtresults.Rows.Add("AverageinHour", avghour);
            dtresults.Rows.Add("Averageinweek", avgweek);
            dtresults.Rows.Add("PeakLastMonth", avgpeak);

            return dtresults;

        }
        static void Main(string[] args)
        {
            String file = System.Configuration.ConfigurationManager.AppSettings["filename"];
            String path = Directory.GetCurrentDirectory();
            path += @"\" + file;
            DataTable dt = new DataTable();
            dt = CSVToDatatable.ConvertCSVtoDataTable(path);

            CultureInfo culture = new CultureInfo("en-US");
            string dateString = "07-01-2020";
            DateTime date= DateTime.ParseExact(dateString, new string[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy" }, culture, DateTimeStyles.None);

            if(dt!=null)
            {
                Analytics an = new Analytics();
                double avghour=Analytics.AverageInHour(dt,date);
                double avgweek= Analytics.AvergaeInweek(dt, date);
                int avgpeak= Analytics.PeakLastMonth(dt);
                Console.WriteLine(avghour);
                Console.WriteLine(avgweek);
                Console.WriteLine(avgpeak);

                DataTable dtresults = new DataTable();

                String storingresultsfile = "Results.csv";
                String pathtoresultfile = Directory.GetCurrentDirectory();
                pathtoresultfile += @"\" + storingresultsfile;

                FileExistsfunction(pathtoresultfile);
                dtresults = CreateDataTableResults(dtresults, avghour, avgweek, avgpeak);




                DataTableTOCSV.ToCSV(dtresults, pathtoresultfile);



            }

            

            


        }
    }

}




