using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YouTubeScript
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeSettings();

            if (CheckURL("https://www.youtube.com/watch?v=sEdzRH0D-5g"))
                Downloader("https://www.youtube.com/watch?v=sEdzRH0D-5g");
            else
                Console.WriteLine("Hatalı Url");

            Console.ReadKey();
        }
        
        static private void InitializeSettings()
        {
            Console.BackgroundColor = ConsoleColor.Blue;

            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
        }

        static public Boolean CheckURL(String URL)
        {
            Regex YoutubeVideoRegex = new Regex("youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)");

            Match isUrl = YoutubeVideoRegex.Match(URL);

            if (isUrl.Success)
                return true;
            return false;
        }

        static public void Downloader(String URL)
        {
            ProcessStartInfo s = new ProcessStartInfo
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                LoadUserProfile = true,
                CreateNoWindow = true,
                FileName = GlobalVariables.YOUTUBE_DL,
                Arguments = URL
            };

            Process p = new Process { StartInfo = s, EnableRaisingEvents = true };

            if(p.Start())
            {
                StreamReader ProcessReader = p.StandardOutput;

                while(!p.StandardOutput.EndOfStream)
                {
                    var reading = ProcessReader.ReadLine().Replace(" ","");

                    try
                    {
                        int perc = reading.IndexOf('%');
                        int cl = reading.IndexOf(']') + 1;

                        String percentage = reading.Substring(cl, (perc - cl));

                        Console.WriteLine("İndiriliyor... {0}", percentage);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                Console.WriteLine("err");
            }
        }
    }
}
