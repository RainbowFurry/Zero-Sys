using System;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : VA Command Interface         *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Azure.VoiceAssistent.Commands
{
    /// <summary>
    /// The Interface of The VoiceAssistent Commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Run the Command
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        bool RunCmd(string cmd, string[] args);

        /// <summary>
        /// Throw an Exepthion if an ERROR ocour while running
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Exception ThrowException(string type, string message);

    }
}
