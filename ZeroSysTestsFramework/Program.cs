using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using ZeroSys.Manager;

namespace ZeroSysTestsFramework
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {

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

        //
        public static bool IsMailAddress(String MailAddress)
        {
            // var foo = new EmailAddressAttribute();
            //if (new EmailAddressAttribute().IsValid("someone@somewhere.com"))

            return Regex.IsMatch(MailAddress, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }

        //        using System.ComponentModel.DataAnnotations;
        //public bool IsValidEmail(string source)
        //    {
        //        return new EmailAddressAttribute().IsValid(source);
        //    }

        //
        public static bool IsPhoneNumber(string number)
        {
            //return Regex.Match(number, @"^([\+]?61[-]?|[0])?[1-9][0-9]{8}$").Success;
            return Regex.Match(number, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").Success;
        }

        //
        public static bool IsIp(string ipAddress)
        {
            IPAddress ip;
            bool ValidateIP = IPAddress.TryParse(ipAddress, out ip);
            return ValidateIP;
        }

        //
        public static bool IsURL(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            //bool result = Regex.IsMatch(url, @"(http|https)://(([www\.])?|([\da-z-\.]+))\.([a-z\.]{2,3})$");
            return result;
        }

        //ProjectConfigManager
        //ConfigManager
        private static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        private static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
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
