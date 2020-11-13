using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : VoiceAssistent Controller    *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Azure.VoiceAssistent
{
    /// <summary>
    /// Initialize the VoiceAssistent
    /// </summary>
    public class VoiceController
    {
        /// <summary>
        /// Subscription Key From Microsoft Azure VoiceAssisten
        /// </summary>
        public static string _VoiceSubscriptionKey;//"8f4e71eef45f401a92686277cbc5590e"
        /// <summary>
        /// Voice Region from your setup VoiceAssisten on Microsoft Azure
        /// </summary>
        public static string _VoiceRegion;//westeurope

        /// <summary>
        /// Speech Recognition Config
        /// </summary>
        public static SpeechConfig speechRecognitionConfig;
        /// <summary>
        /// Speech Syntheniser Config
        /// </summary>
        public static SpeechConfig speechSyntheniserConfig;

        public static SpeechRecognizer speechRecognizerName;
        public static SpeechRecognizer speechRecognizer;
        public static SpeechSynthesizer say;

        /// <summary>
        /// Initialize VoiceController
        /// </summary>
        /// <param name="VoiceSubscriptionKey"></param>
        /// <param name="VoiceRegion"></param>
        public VoiceController(string VoiceSubscriptionKey, string VoiceRegion)
        {
            _VoiceRegion = VoiceRegion;
            _VoiceSubscriptionKey = VoiceSubscriptionKey;
            speechRecognitionConfig = SpeechConfig.FromSubscription(_VoiceSubscriptionKey, _VoiceRegion);
            speechSyntheniserConfig = SpeechConfig.FromSubscription(_VoiceSubscriptionKey, _VoiceRegion);
        }

        /// <summary>
        /// Initialize VoiceAssistent Config and Commands.
        /// Start VoiceRecognition.
        /// </summary>
        public void initializeVoiceAssistent(string Language, string ReactNameFilePath)
        {

            //Register Config
            speechRecognitionConfig.SpeechRecognitionLanguage = Language; //de-DE oder us-US en-EN
            speechRecognitionConfig.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Audio16Khz32KBitRateMonoMp3);

            //Add Config to VoiceAssistent
            speechRecognizerName = new SpeechRecognizer(speechRecognitionConfig);//listen only on Name
            speechRecognizer = new SpeechRecognizer(speechRecognitionConfig);//listen to everything
            //speechRecognizer.RecognizeOnceAsync().ConfigureAwait(false); //Listen loop

            speechSyntheniserConfig.SpeechSynthesisLanguage = Language;
            say = new SpeechSynthesizer(speechSyntheniserConfig, AudioConfig.FromDefaultSpeakerOutput());//DEVICE CHANGEABLE

            KeywordRecognitionModel k = KeywordRecognitionModel.FromFile(ReactNameFilePath);
            speechRecognizerName.StartKeywordRecognitionAsync(k).ConfigureAwait(false);

            //new CommandController();

            ZeroSpeechRecognition.RecognizeSpeechAsync().Wait();//Register Output

        }

    }
}
