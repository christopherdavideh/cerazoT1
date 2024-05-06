using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cerazoT1.Helper
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, fileName);
        }
    }
}
