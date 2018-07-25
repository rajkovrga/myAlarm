using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace MyAlarm
{
  
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Alarm Time");
            string time = Console.ReadLine();
            Console.WriteLine("youtube link(alarm sound)b");
            string link = Console.ReadLine();
            int nowMinute = DateTime.Now.Minute;
            int nowHours = DateTime.Now.Hour;
            DateTime wanted = DateTime.Parse(time);

            while (nowMinute != wanted.Minute || nowHours != wanted.Hour)
            {
                nowMinute = DateTime.Now.Minute;
                nowHours = DateTime.Now.Hour;
                Thread.Sleep(1000);
            }

            ProcessStartInfo chrome = new ProcessStartInfo("chrome.exe")
            {
               Arguments = link
            };
           Process.Start(chrome);
        }

       
    }
}
