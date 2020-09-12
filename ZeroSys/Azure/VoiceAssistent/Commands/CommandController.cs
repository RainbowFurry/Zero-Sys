using System;
using System.Collections.Generic;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : VA Command Controller        *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Azure.VoiceAssistent.Commands
{
    /// <summary>
    /// This Controlls the Commands of the VoiceAssistent
    /// </summary>
    public class CommandController
    {

        //NICHT FERTIG!!!!

        private static Dictionary<string, ICommand> CommandMap;

        public CommandController()
        {
            CommandMap = new Dictionary<string, ICommand>();
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            registerSmaltalkCommands();
            registerInternControlCommands();
            registerInformationCommands();
            registerComputerControle();
        }

        public static void OnCommand(string cmd, string[] args)
        {
            if (CommandMap.ContainsKey(cmd.ToLower()))
            {
                ICommand command = CommandMap[cmd];
                if (!command.RunCmd(cmd, args))
                {
                    // Cmd error
                    command.ThrowException("", "");
                }
            }
            else
            {
                // Cmd nicht vorhanden
            }
        }

        /// <summary>
        /// Return an Random Result of an Multiple 
        /// </summary>
        /// <param name="commandResult"></param>
        /// <returns></returns>
        public static string randomCommandResultOutput(string commandResult)
        {

            string[] results = commandResult.Split(';');
            Random random = new Random();

            return results[random.Next(results.Length)];
        }


        #region Register Commands
        private void registerSmaltalkCommands()
        {

            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("Hellow_Question"), new Hellow());//GEHT NICHT MEHR
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("WhatsYourName_Question"), new WhatsYourName());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("WhatsMyName_Question"), new WhatsMyName());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("WhereDoYouLive_Question"), new WhereDoYouLive());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("HowOldAreYou_Question"), new HowOldAreYou());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("WhoCreatedYou_Question"), new WhoCreatedYou());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("TellAJoke_Question"), new TellMeAJoke());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("YouAreNotFunny_Question"), new YouArentFunny());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("ShutUp_Question"), new ShutUp());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("HowAreYou_Question"), new HowAreYou());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("WhereDoYouComeFrom_Question"), new WhereDoYouComeFrom());
            //CommandMap.Add(db.DatabaseManager.loadSmalTalkDBValue("DoYouLikeMe_Question"), new DoYouLikeMe());

            //suche im internet nach...
            //suche auf youtube nach...
            //suche auf amazon nach...

            //Welche musik magst du
            //was ist dein lieblings lied
            //was ist dein lieblings fild
            //was hälst du von XYZ? random generelle antwort
            //wie weit ist es nach...
            //was ergibt MATH EXERCIZE

        }

        private void registerInternControlCommands()
        {
            //Deaktiviere dich 
            //lautstärke setting..
            //Spiele Musik...
            //öffne settings
        }

        private void registerInformationCommands()
        {
            //CommandMap.Add(db.DatabaseManager.loadInformationDBValue("WhatTimeIsIt_Question"), new GetCurrentTime()); //Alias -> CommandMap.Add("Wie spät ist es", CommandMap["Wie spät ist es?"]);
            //CommandMap.Add(db.DatabaseManager.loadInformationDBValue("WhatDayIsItToday_Question"), new GetCurrentDate());
            //CommandMap.Add(db.DatabaseManager.loadInformationDBValue("Tagesinfo_Question"), new DailyInfo());
            //suche im Internet nach...
            //öffne PROGRAMM ...
        }

        private void registerComputerControle()
        {
            //CommandMap.Add(db.DatabaseManager.loadComputerControleDBValue("ShutdownComputer_Question"), new Shutdown());
            //CommandMap.Add(db.DatabaseManager.loadComputerControleDBValue("RestartComputer_Question"), new Restart());
            //zeit bezogenes herunterfahren
        }
        #endregion

    }
}
