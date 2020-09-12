using System;

namespace ZeroSys.Azure.VoiceAssistent.Commands
{
    /// <summary>
    /// The Help of the Command
    /// </summary>
    public class HelpCommand
    {

        /// <summary>
        /// Run VoiceAssistent Command
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool RunCmd(string cmd, string[] args)
        {
            return true;
        }

        /// <summary>
        /// Throw Exeption while ERROR ocour while running
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Exception ThrowException(string type, string message)
        {
            switch (type)
            {
                case "normal":
                    return new Exception(message);
                case "invalidcast":
                    return new InvalidCastException(message);
                default:
                    return new Exception(message);
            }
        }

    }
}
