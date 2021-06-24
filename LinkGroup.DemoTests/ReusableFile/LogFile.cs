using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGroup.DemoTests.ReusableFile
{
    class LogFile
    {
        public static void LogInformation(string str)
        {
            Console.WriteLine(str);
        }

        public static void LogErrorInformation(string str)
        {
            Console.WriteLine(str);
        }
    }
}
