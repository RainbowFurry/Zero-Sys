using System;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : VA Speech Synthenizer        *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Azure.VoiceAssistent
{
    /// <summary>
    /// Voice Output of the VoiceAssistent
    /// </summary>
    public class ZeroSpeechSynthenizer
    {

        /// <summary>
        /// Let the Computer talk what ever you want
        /// </summary>
        /// <param name="content"></param>
        public static void speak(String content)
        {
            VoiceController.say.SpeakTextAsync(content).ConfigureAwait(true);
        }

    }
}
