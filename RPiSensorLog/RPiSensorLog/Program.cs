using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPiSensorLog
{
    class Program
    {
        static void Main(string[] args)
        {
            helpScreen();
            //Console.ReadKey();
        }

        static void helpScreen()
        {
            Console.WriteLine("Raspberry Pi Sensor Log ver. " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            Console.WriteLine(String.Format("OS: {0}", Environment.OSVersion));
            Console.WriteLine(string.Format("Local Time: {0}", DateTime.Now));
            Console.WriteLine();
            Console.WriteLine("[-help] Shows this screen");
            Console.WriteLine("[-view] <delay> View connected sensors with refresh on <delay>");
            Console.WriteLine("[-start] <delay> <file> Start logging to <file>");
            Console.WriteLine("[-stop] Stop logging");
            Console.WriteLine("Default values for <optional parameters> can be edited in the options.cfg file.");
            Console.WriteLine();
            //Console.WriteLine("Press any key to exit");
        }
    }
}
