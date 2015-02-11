using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RPiSensorLog
{
    class Program
    {
        static void Main(string[] args)
        {
            helpScreen();
            showOptions();
            Console.ReadKey();
        }

        static void showOptions()
        {
            var options =  ReadOptionsFile();
            var sensors = ReadSensorsFile();
            Console.WriteLine("Default delay: " + options.delay);
            Console.WriteLine("sensor 1: " + sensors.sensorList[0].name);
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

        public static AppOptions ReadOptionsFile()
         {
             System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(AppOptions));
             System.IO.StreamReader file = new System.IO.StreamReader(string.Format(@"{0}\options.xml", Environment.CurrentDirectory));
             var options = (AppOptions)reader.Deserialize(file);
             return options;
         }
 
         public static SensorDirectory ReadSensorsFile()
         {
             System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(SensorDirectory));
             System.IO.StreamReader file = new System.IO.StreamReader(string.Format(@"{0}\sensors.xml", Environment.CurrentDirectory));
             var sensorDirectory = (SensorDirectory)reader.Deserialize(file);
             return sensorDirectory;
         }
    }

    public class AppOptions
    {
        public int delay{ get; set; }
        public string logFile { get; set; }
        public string logType { get; set; }
    }
 
    public class SensorDirectory
    {
        [XmlElement("Sensor")]
        public List<Sensor> sensorList = new List<Sensor>();
    }
 
    public class Sensor
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int GPIO_PIN { get; set; }
    }

    
}
