using System;
using System.Data;
using System.Globalization;
using System.IO;
using Sender_Visit;


namespace Receiver_Visit
{

    
   public static class Program
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
        private static DataTable CreateDataTableResults(DataTable dtresults,double avghour,double avgweek,int avgpeak)
        {
            dtresults.Columns.Add("FunctionName");
            dtresults.Columns.Add("Result");

            dtresults.Rows.Add("AverageinHour", avghour);
            dtresults.Rows.Add("Averageinweek", avgweek);
            dtresults.Rows.Add("PeakLastMonth", avgpeak);

            return dtresults;

        }


        static void Main()
        {
            DataTable dt = new DataTable();
            try
            {

                ReadConsole datatablereader = new ReadConsole();
                dt = datatablereader.AddColumns(dt);
                dt = datatablereader.AddRows(dt);
                Console.WriteLine("The file is Read using Console Redirection");
            }
            catch (Exception)
            {
                try
                {
                    Console.WriteLine("The file is running without Console Redirection");
                    String file = System.Configuration.ConfigurationManager.AppSettings["filename"];
                    String path = Directory.GetCurrentDirectory();
                    path += @"\" + file;
                    dt = CsvToDatatable.ConvertCsvtoDatatable(path);

                }
                catch (Exception)
                {
                    Console.WriteLine("Some error occured");                  

                }
            }
            finally
            {
                CultureInfo culture = new CultureInfo("en-US");
                string dateString = "07-01-2020";
                DateTime date = DateTime.ParseExact(dateString, new[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy" }, culture, DateTimeStyles.None);

                if (dt != null)
                {
                    double avghour = Analytics.AverageInHour(dt, date);
                    double avgweek = Analytics.AvergaeInweek(dt, date);
                    int avgpeak = Analytics.PeakLastMonth(dt);

                    DataTable dtresults = new DataTable();

                    String storingresultsfile = "Results.csv";
                    String pathtoresultfile = Directory.GetCurrentDirectory();
                    pathtoresultfile += @"\" + storingresultsfile;

                    FileExistsfunction(pathtoresultfile);
                    dtresults = CreateDataTableResults(dtresults, avghour, avgweek, avgpeak);
                    DataTableTocsv.ToCsv(dtresults, pathtoresultfile);
                    Console.WriteLine("The result is stored in " + pathtoresultfile);
                }
                else
                {
                    Console.WriteLine("DataTable is Null Check your file stream");
                }
            }
        }
    }

}




