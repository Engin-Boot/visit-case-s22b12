using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sender
{

    class FileReader
    {
        public bool CheckFilename(String file)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file);
                if (fileinfo.Name.Equals("DateTimeSpaCustomer.csv") && CheckFileExtension(file))
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

        public bool CheckFileExtension(String file)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file);
                if (!fileinfo.Extension.Equals(".csv"))
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool CheckFileExists(String file)
        {
            try
            {
                if (File.Exists(file) && CheckFilename(file))
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
