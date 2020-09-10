using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sender
{

    class FileReader
    {
        bool fileexists = true;
        public void CheckFilename(String file)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file);
                if (fileinfo.Name.Equals("DateTimeSpaCustomer.csv"))
                {
                   
                    return;
                }
                fileexists = false;
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public void CheckFileExtension(String file)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file);
                if (fileinfo.Extension.Equals(".csv"))
                {
                   
                    return;
                }
                fileexists = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public void CheckFileLocation(String file)
        {
            try
            {
               
                if (File.Exists(file))
                {

                    return;
                }
                fileexists = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        public bool CheckFileExists(String file)
        {
            try
            {
                CheckFilename(file);
                CheckFileExtension(file);
                CheckFileLocation(file);
                if (fileexists)
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
