using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Alarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alarm Time");
            DateTime wanted;
            string time = Console.ReadLine();
            Console.WriteLine("youtube link(alarm sound)b");
            string link = Console.ReadLine();
            if (link == null || Regex.IsMatch(@"https?://(www\.)?youtube.com/watch", link))
            {
                Console.WriteLine("Link must be passed in!");
            }
            int nowMinute = DateTime.Now.Minute;
            int nowHours = DateTime.Now.Hour;
            try
            {
                wanted = DateTime.Parse(time);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            while (nowMinute != wanted.Minute || nowHours != wanted.Hour)
            {
                nowMinute = DateTime.Now.Minute;
                nowHours = DateTime.Now.Hour;
                Thread.Sleep(1000);
            }

            ProcessStartInfo chrome = new ProcessStartInfo("chrome.exe")
            {
                Arguments = link ?? throw new InvalidYoutubeException()
            };
            Process.Start(chrome);
        }
    }
}
