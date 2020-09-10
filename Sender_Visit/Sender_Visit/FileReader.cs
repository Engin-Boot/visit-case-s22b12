using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sender
{

    class FileReader
    {
        bool fileexists = false;
        public void CheckFilename(String file)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file);
                if (fileinfo.Name.Equals("DateTimeSpaCustomer.csv"))
                {
                    fileexists = true;
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
                    fileexists = true;
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
                Console.WriteLine(fileexists);
                if (File.Exists(file) && fileexists)
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
