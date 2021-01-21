using NAudio.CoreAudioApi;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using ZeroSys.Manager;
using ZeroSys.SystemController.Hardware;

namespace ZeroSysTestsFramework
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {

        public class JsonLogContent : Exception
        {
            public string Date = DateTime.Today.ToString("D");
            public string Time = DateTime.Now.ToString().Split(' ')[1];
            public string Tag { get; set; } = "[TAG]";
            public Exception exception { get; set; } = new Exception("Unknown Exeption");

        }

        public static void CreateJsonLog(string tag, Exception exception)
        {

            JsonLogContent log = new JsonLogContent()
            {
                Tag = tag,
                exception = exception
            };

            Console.WriteLine("Date: " + log.Date);
            Console.WriteLine("Time: " + log.Time);
            Console.WriteLine("Tag: " + log.Tag);
            Console.WriteLine("Exeption: " + log.exception);

            string json = JsonConvert.SerializeObject(log);
            Console.WriteLine(json);

            //to json
            //print json
            //save json

        }

        private static void Test()
        {

            Dictionary<string, string> kp = Cpu.GetAllCores();
            Console.WriteLine(kp["2"]);

        }

        [STAThread]
        private static void Main(string[] args)
        {

            Test();

            //string[] a = new string[10];

            //try
            //{
            //    Console.WriteLine(a[11]);
            //}
            //catch (Exception)//JsonLogContent
            //{
            //    CreateJsonLog("test", new Exception("Test Exeption"));
            //}

            //---------------------------

            //AddUpdateAppSettings("JasonJT", "JasonJT");
            //ReadSetting("JasonJT");

            //

            //Thread t1 = new Thread(new ThreadStart(Incrementer));
            //Thread t2 = new Thread(new ThreadStart(Decrementer));

            //// Threads starten
            //t1.Start();
            //t2.Start();

            //START STOP TIMER AND GET RESULT

            //

            //FileInfoManager.GetFileInformation(@"C:\Users\jhoffmann\Documents\Vorlage_Etiketten_Pilot3.docx");

            //test(new Program());
            //t();
            Console.Read();
        }

        //
        public static void Regexes()
        {
            //ToDo: ANCHOR, Flags, Substition, Quantifiers & Alternation
            //Start Tag
            //End Tag
            // was ist mit ^ u +
            // /g = filter option rows...
            //^abc$ = start/end of string

            //https://regexr.com
            //^ = negativ/verneint
            // \w = Word | \W = noWord
            // \d = digit | \D noDigit
            // \s = whitespace | \S = noWhiteSpace
            // \s\S = match any
            //* + etc...
            //OTHER MATCHER = \.=. \*=* \\=\ \t=tab \0=null
            //at the END OF THE REGEX ADD /g=GLOBAL /m=multiLine /s=singleLine

            //string lettersUpper = "[A-Z]";
            //string lettersLower = "[a-z]";
            //string numbers = "[0-9]";
            //string match = [abAB12.]; - filter alles was da drin ist also suche klein a u A
            // string match = (Test); = match exakt dem wort Test.
            //string ignore = "[^aeiou]"; // ignoriere aeiou
            //[0-9]{3} - Finde alles fas in dem Suchradius ohne unterbrechung ist und dem Filter entspricht

        }

        //Get IP Extern - aber auch intern...
        private IPAddress GetMyIP()
        {
            string Ip, Url = "http://bot.whatismyipaddress.com/";

            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(Url);

            using (HttpWebResponse Res = (HttpWebResponse)Req.GetResponse())
            {
                using (StreamReader Str = new StreamReader(Res.GetResponseStream()))
                {
                    Ip = Str.ReadToEnd();
                }
            }

            return IPAddress.Parse(Ip);
        }


        public static void Incrementer()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Incrementer: {0}", i);
            }
        }

        public static void Decrementer()
        {
            for (int i = 100; i >= 0; i--)
            {
                Console.WriteLine("Decrementer: {0}", i);
            }
        }



        public static void Culture()
        {

            var usCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(DateTime.Now.ToString(usCulture.Name));
            Console.WriteLine(DateTime.Now.ToString(usCulture.DisplayName));
            Console.WriteLine(DateTime.Now.ToString(usCulture.CompareInfo.Name));
            Console.WriteLine(DateTime.Now.ToString(usCulture.DateTimeFormat));
            Console.WriteLine(DateTime.Now.ToString(usCulture.IetfLanguageTag));
            Console.WriteLine(DateTime.Now.ToString(usCulture.KeyboardLayoutId.ToString()));
            Console.WriteLine(DateTime.Now.ToString(usCulture.TwoLetterISOLanguageName));
            Console.WriteLine(DateTime.Now.ToString(usCulture.TextInfo.CultureName));
            Console.WriteLine(DateTime.Now.ToString(usCulture.Parent));
            Console.WriteLine(DateTime.Now.ToString(usCulture.NumberFormat));

        }

        public static void DateTimeTest()
        {

            //DateTime dob = new DateTime(2002, 10, 22);
            DateTime dob = DateTime.Now;
            Console.WriteLine("d: " + dob.ToString("d"));
            Console.WriteLine("D: " + dob.ToString("D"));
            Console.WriteLine("f: " + dob.ToString("f"));//
            Console.WriteLine("F: " + dob.ToString("F"));//
            Console.WriteLine("g: " + dob.ToString("g"));//
            Console.WriteLine("G: " + dob.ToString("G"));//
            Console.WriteLine("m: " + dob.ToString("m"));
            Console.WriteLine("M: " + dob.ToString("M"));
            Console.WriteLine("o: " + dob.ToString("o"));
            Console.WriteLine("O: " + dob.ToString("O"));
            Console.WriteLine("r: " + dob.ToString("r"));
            Console.WriteLine("R: " + dob.ToString("R"));
            Console.WriteLine("s: " + dob.ToString("s"));//
            Console.WriteLine("t: " + dob.ToString("t"));
            Console.WriteLine("T: " + dob.ToString("T"));
            Console.WriteLine("u: " + dob.ToString("u"));//
            Console.WriteLine("U: " + dob.ToString("U"));//
            Console.WriteLine("y: " + dob.ToString("y"));
            Console.WriteLine("Y: " + dob.ToString("Y"));

            Console.WriteLine("ToString: " + dob.ToString());
            Console.WriteLine("ToBinary: " + dob.ToBinary());
            Console.WriteLine("ToFileTime: " + dob.ToFileTime());
            Console.WriteLine("ToLocalTime: " + dob.ToLocalTime());
            Console.WriteLine("ToLongDateString: " + dob.ToLongDateString());
            Console.WriteLine("ToLongTimeString: " + dob.ToLongTimeString());
            Console.WriteLine("ToOADate: " + dob.ToOADate());
            Console.WriteLine("ToShortDateString: " + dob.ToShortDateString());
            Console.WriteLine("ToShortTimeString: " + dob.ToShortTimeString());
            Console.WriteLine("ToUniversalTime: " + dob.ToUniversalTime());

            var usCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine("US: " + DateTime.Now.ToString(usCulture.DateTimeFormat));

        }

        public static void AudioRecord()
        {

            MMDevice m = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Define the output wav file of the recorded audio
            string outputFilePath = @"C:\Users\DarkS\Documents\HeimServer\Test.wav";

            // Redefine the capturer instance with a new instance of the LoopbackCapture class
            WasapiLoopbackCapture CaptureInstance = new WasapiLoopbackCapture(m);

            // Redefine the audio writer instance with the given configuration
            WaveFileWriter RecordedAudioWriter = new WaveFileWriter(outputFilePath, CaptureInstance.WaveFormat);

            // When the capturer receives audio, start writing the buffer into the mentioned file
            CaptureInstance.DataAvailable += (s, a) =>
            {
                // Write buffer into the file of the writer instance
                RecordedAudioWriter.Write(a.Buffer, 0, a.BytesRecorded);
            };

            // When the Capturer Stops, dispose instances of the capturer and writer
            CaptureInstance.RecordingStopped += (s, a) =>
            {
                RecordedAudioWriter.Dispose();
                RecordedAudioWriter = null;
                CaptureInstance.Dispose();
            };

            Console.WriteLine("Press a Key to Record");
            Console.Read();
            // Start audio recording !
            CaptureInstance.StartRecording();
            Console.WriteLine("Press a Key to Stop!");
            Console.Read();
            CaptureInstance.StopRecording();

        }

        public void TestPossibillity()
        {

            //Possibillity p1 = new Possibillity()
            //{
            //   Name = "Red Ball",
            //   Ammount = 7
            //};

            //Possibillity p2 = new Possibillity()
            //{
            //   Name = "Blue Ball",
            //   Ammount = 4
            //};

            //Possibillity p3 = new Possibillity()
            //{
            //   Name = "Yellow Ball",
            //   Ammount = 2
            //};

            //Possibillity[] possibillities = new Possibillity[] { p1, p2, p3 };

            //ttt(possibillities);

        }

        private static void test(object obj)
        {
            //
        }

        private static void t()
        {

            //
            ProcessManager.StartNewConsoleCommand("ping google.de", true);
        }

        private static string Mirro(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //

        public static bool IsMatching(Color a, Color b, int percent)
        {
            //this method is used to identify whether two pixels, 
            //of color a and b match, as in they can be considered
            //a solid color based on the acceptance value (percent)

            int thresh = percent * 255;

            return Math.Abs(a.R - b.R) < thresh &&
                   Math.Abs(a.G - b.G) < thresh &&
                   Math.Abs(a.B - b.B) < thresh;
        }

        public static void ttt(Possibillity[] possibillities)
        {

            int maxPossible = 0;

            foreach (Possibillity pc in possibillities)
            {
                maxPossible = maxPossible + pc.Ammount;
            }

            foreach (Possibillity p in possibillities)
            {
                double result = p.Ammount / (double)maxPossible * 100;
                Console.WriteLine(p.Name + ": " + result.ToString("00.00") + " %");
            }

        }

    }


    public class Possibillity
    {
        public string Name { get; set; }
        public int Ammount { get; set; }
    }

}
