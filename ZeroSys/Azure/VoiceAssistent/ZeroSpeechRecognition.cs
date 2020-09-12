using Microsoft.CognitiveServices.Speech;
using System;
using System.Threading.Tasks;
using ZeroSys.Azure.VoiceAssistent.Commands;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : VA SpeechRecognition         *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Azure.VoiceAssistent
{
    /// <summary>
    /// VoiceAssistent recognition of User Input
    /// </summary>
    public class ZeroSpeechRecognition
    {

        //GrammarList g = GrammarList.FromRecognizer(recognizer);
        //Grammar citiesGrammar = Grammar.FromStorageId("xml/Test.xml");
        //g.Add(citiesGrammar);

        /// <summary>
        /// Recognizer Controller
        /// </summary>
        /// <returns></returns>
        public static async Task RecognizeSpeechAsync()
        {

            VoiceController.speechRecognizerName.Recognized += recognizeName;
            VoiceController.speechRecognizer.Recognized += recognize;

            try
            {

                //var result = await VoiceControler.speechRecognizer.RecognizeOnceAsync().ConfigureAwait(false);//await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                //if (result.Reason == ResultReason.RecognizedSpeech)
                //{
                //    Console.WriteLine($"We recognized: {result.Text}");
                //    //VoiceAssistentStartSpeaking();//GIVE ANSWER
                //}
                //else if (result.Reason == ResultReason.NoMatch)
                //{
                //    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                //}
                //else if (result.Reason == ResultReason.Canceled)
                //{
                //    var cancellation = CancellationDetails.FromResult(result);
                //    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                //    if (cancellation.Reason == CancellationReason.Error)
                //    {
                //        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                //        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                //        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                //    }
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.Source + "\n" + e.StackTrace + "\n" + e.Data);
            }

        }

        /// <summary>
        /// Trigger the Reaction if you say his Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void recognizeName(object sender, SpeechRecognitionEventArgs e)
        {

            String result = e.ToString().Split('<')[1].Replace(">.", "");
            //Console.WriteLine(e);
            //Console.WriteLine(result);

            //MainWindow.listen = true;
            VoiceController.speechRecognizer.RecognizeOnceAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Trigger the Reaction if you say an Command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void recognize(object sender, RecognitionEventArgs e)
        {

            String result = e.ToString().Split('<')[1].Replace(">.", "").ToLower();
            Console.WriteLine(result);

            //MainWindow.listen = false;
            CommandController.OnCommand(result, new String[0]);

        }

    }
}
