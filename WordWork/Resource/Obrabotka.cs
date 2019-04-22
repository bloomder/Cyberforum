using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWork.Resource
{
    static class Obrabotka
    {
        public static bool CheckDir(string dir)
        {
            if (Directory.Exists(dir)) return true;
            else return false;
        }
    }
    
}
