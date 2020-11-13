using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ZeroSys.Manager.Security
{
    internal class ZeroCrypt
    {

        //Split content by \n und dann in file
        //wenn alles geht pentest...

        private char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ', '.', ',', ';', ':', '?', '!', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'ö', 'ä', 'ü', 'ß' };//
        private char[] randomAlphabet;
        private int encryptIndex;
        private string FinalContent;

        /// <summary>
        /// Encrypt (Verschlüssel) your Content
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public ZeroCrypt ZeroEncrypt(string content)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            randomAlphabet = CreateRandomAlphabet();
            encryptIndex = CreateRandomIndex();
            string result = CreateContent();
            Time();

            char[] CreateRandomAlphabet()
            {
                char[] alphabetTemp = new char[alphabet.Length];
                int tnull = 0;

                foreach (char c in alphabet)
                {
                    Random random = new Random();
                    bool success = false;
                    while (success == false)
                    {
                        int next = random.Next(0, alphabet.Length);
                        if (alphabetTemp[next] == '\0')
                        {
                            if (c == '0')
                            {
                                alphabetTemp[next] = 'X';
                                tnull = next;
                                success = true;
                            }
                            else
                            {
                                alphabetTemp[next] = c;
                                //Console.WriteLine("Next: " + next + " mapped to " + c);
                                success = true;
                            }
                        }
                    }
                }
                alphabetTemp[tnull] = '0';//Correcture
                return alphabetTemp;
            }//Create random alphabet
            int CreateRandomIndex()
            {
                Random random = new Random();
                return random.Next(0, randomAlphabet.Length - 1);
            }//Create random movement Index
            string CreateContent()
            {

                //Console.WriteLine("[Encrypt][Before] " + content);

                string returnContent = "";

                foreach (char c in content)
                {
                    bool uppercase;
                    for (int i = 0; i < randomAlphabet.Length; i++)
                    {
                        if (c.ToString().ToLower().Equals(randomAlphabet[i].ToString()))
                        {
                            if (c.ToString() == randomAlphabet[i].ToString())
                                uppercase = false;
                            else
                                uppercase = true;

                            if ((i + encryptIndex) >= randomAlphabet.Length)
                            {
                                if (uppercase == false)
                                    returnContent += randomAlphabet[(i + encryptIndex) - randomAlphabet.Length];
                                else
                                    returnContent += randomAlphabet[(i + encryptIndex) - randomAlphabet.Length].ToString().ToUpper();
                                break;
                            }
                            else
                            {
                                if (uppercase == false)
                                    returnContent += randomAlphabet[i + encryptIndex];
                                else
                                    returnContent += randomAlphabet[i + encryptIndex].ToString().ToUpper();
                                break;
                            }
                        }
                    }
                }

                //Console.WriteLine("[Encrypt][After] " + returnContent);

                return returnContent;
            }//Create Key Content
            void Time()
            {
                stopWatch.Stop();

                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Encryption RunTime: " + elapsedTime);

            }//Time Key needed to be created

            result = ConvertToBase64String(ConvertToBinary(result));//Convert to Base64
            FinalContent = result;
            return this;
        }

        /// <summary>
        /// Decrypt your Content from File
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string ZeroDecryptFromFile(string filePath)
        {

            filePath = Environment.CurrentDirectory + @"\" + filePath;

            string[] keyContent = File.ReadAllLines(filePath);
            randomAlphabet = FromHex(keyContent[0]).ToCharArray();//Convert from Hex

            //Get Index
            var b = new byte[2];
            b[0] = Convert.ToByte(keyContent[1].Split(':')[0]);
            if (Convert.ToByte(keyContent[1].Split(':')[1]) != 0)
                b[1] = Convert.ToByte(keyContent[1].Split(':')[1]);


            encryptIndex = Convert.ToInt32(Encoding.Default.GetString(b));//Convert from Binary
            byte[] byteContent = Convert.FromBase64String(keyContent[2]);//Convert To Binary and then to String

            string content = Encoding.UTF8.GetString(byteContent);
            //Console.WriteLine("[Decrypt][INDEX][BEFORER] " + keyContent[1]);
            //Console.WriteLine("[Decrypt][INDEX][AFTER] " + encryptIndex);
            //Console.WriteLine("[Decrypt][CHARS][BEFORER] " + keyContent[0]);
            //Console.WriteLine("[Decrypt][CHARS][AFTER] " + FromHex(keyContent[0]));
            //Console.WriteLine("[Decrypt][Before:BEFORE] " + keyContent[2]);
            //Console.WriteLine("[Decrypt][Before] " + content);

            string returnContent = "";

            foreach (char c in content)
            {
                for (int i = 0; i < randomAlphabet.Length; i++)
                {
                    bool uppercase;

                    if (c.ToString().ToLower().Equals(randomAlphabet[i].ToString()))
                    {
                        if (c.ToString() == randomAlphabet[i].ToString())
                            uppercase = false;
                        else
                            uppercase = true;


                        if ((i - encryptIndex) <= 0)
                        {
                            if (i - encryptIndex + randomAlphabet.Length > randomAlphabet.Length)
                            {
                                if (uppercase == false)
                                    returnContent += randomAlphabet[randomAlphabet.Length - (i - encryptIndex)];
                                else
                                    returnContent += randomAlphabet[randomAlphabet.Length - (i - encryptIndex)].ToString().ToUpper();
                                break;
                            }
                            else
                            {
                                if (uppercase == false)
                                    returnContent += randomAlphabet[(i - encryptIndex) + randomAlphabet.Length];
                                else
                                    returnContent += randomAlphabet[(i - encryptIndex) + randomAlphabet.Length].ToString().ToUpper();
                                break;
                            }
                        }
                        else
                        {
                            if (uppercase == false)
                                returnContent += randomAlphabet[i - encryptIndex];
                            else
                                returnContent += randomAlphabet[i - encryptIndex].ToString().ToUpper();
                            break;
                        }
                    }
                }
            }

            //Console.WriteLine("[Decrypt][After] " + returnContent);
            return returnContent;

        }

        /// <summary>
        /// Create Hash Value
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string ZeroHash(string content)
        {

            //

            return null;
        }

        /// <summary>
        /// Create File with the Encrypted ContentKey
        /// </summary>
        public void CreateFile(string name)
        {
            Random random = new Random();
            string path;

            if (name == null)
                path = Environment.CurrentDirectory + @"\" + random.Next(0, 999) + ".txt";
            else
                path = Environment.CurrentDirectory + @"\" + name + ".txt";

            string a = "";
            foreach (char c in randomAlphabet)
            {
                a += c;
            }

            using (StreamWriter streamWriter = File.CreateText(path))
            {
                streamWriter.WriteLine(ConvertToHexa(a));//Hexa
                //Console.WriteLine("Index BEFORE: " + encryptIndex.ToString());
                //Console.WriteLine("Index AFTER: " + ConvertToBinary(encryptIndex.ToString())[0] + ":" + ConvertToBinary(encryptIndex.ToString())[1]);
                streamWriter.WriteLine(ConvertToBinary(encryptIndex.ToString())[0] + ":" + ConvertToBinary(encryptIndex.ToString())[1]);//Binary
                streamWriter.WriteLine(FinalContent);//Encrypt
            }

            Console.WriteLine("File Created: " + path.Replace(Environment.CurrentDirectory + @"\", ""));

        }


        private string ConvertToBase64String(byte[] content)
        {
            //Console.WriteLine("[ConvertToBase64String][Before] " + content);
            //.WriteLine("[ConvertToBase64String][After] " + Convert.ToBase64String(content));
            return Convert.ToBase64String(content);
        }

        private byte[] ConvertToBinary(string content)
        {
            //Console.WriteLine("[ConvertToBinary][Before] " + content);
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            //Console.WriteLine("[ConvertToBinary][After] ");
            foreach (byte b in bytes)
            {
                //Console.Write(b + " ");
            }
            return bytes;
        }

        private string ConvertToHexa(string content)
        {
            //Console.WriteLine("[ConvertToHexa][Before] " + content);
            char[] chars = content.ToCharArray();
            string newContent = "";

            foreach (char c in chars)
            {
                newContent += Convert.ToInt32(c).ToString("x");
            }

            //Console.WriteLine("[ConvertToHexa][After] " + newContent);
            return newContent;
        }

        private string ConvertToHash(string content)
        {
            //Console.WriteLine("[ConvertToHash][Before] " + content);
            // SHA512 is disposable by inheritance.
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(content));
                // Get the hashed string.
                string result = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                //Console.WriteLine("[ConvertToHash][After] " + result);
                return result;
            }

        }

        private string FromHex(string hex)
        {
            //Console.WriteLine("From Hexa To String BEFORE: " + hex);
            hex = hex.Replace("-", "").Replace(" ", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            string result = Encoding.Default.GetString(raw);

            //Console.WriteLine("From Hexa To String AFTER: " + result);
            return result;
        }

    }
}
