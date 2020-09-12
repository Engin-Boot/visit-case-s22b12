using System;

using System.IO;


namespace Sender_Visit
{

    public class FileReader
    {
        bool _fileexists = true;
        private void CheckFilename(String file)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file);
                if (fileinfo.Name.Equals("DateTimeSpaCustomer.csv"))
                {
                    return;
                }
                _fileexists = false;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CheckFileExtension(String file)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file);
                if (fileinfo.Extension.Equals(".csv"))
                {
                    return;
                }
                _fileexists = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
        }

        private void CheckFileLocation(String file)
        {
            try
            {
               
                if (File.Exists(file))
                {

                    return;
                }
                _fileexists = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
        public bool CheckFileExists(String file)
        {
            try
            {
                CheckFilename(file);
                CheckFileExtension(file);
                CheckFileLocation(file);
                if (_fileexists)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}
