using System;
using System.Collections.Generic;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Motherboard Info         *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemControll.Hardware
{
    /// <summary>
    /// Get Motherboard Information
    /// </summary>
    public class Motherboard
    {

        private static readonly ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\\.\root\cimv2", "SELECT * FROM Win32_BIOS");
        private static Dictionary<string, string> motherboardInformation = new Dictionary<string, string>();

        /// <summary>
        /// Get the Complete Information about your MotherBoard
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetMotherBoardInformation()
        {

            Dictionary<string, string> motherboard = new Dictionary<string, string>();

            foreach (var _object in searcher.Get())
            {

                if (_object != null)
                {

                    try
                    {

                        motherboard.Add("BiosCharacteristics", _object["BiosCharacteristics"].ToString());
                        motherboard.Add("BIOSVersion", _object["BIOSVersion"].ToString());
                        motherboard.Add("BuildNumber", _object["BuildNumber"].ToString());
                        motherboard.Add("Caption", _object["Caption"].ToString());
                        motherboard.Add("CodeSet", _object["CodeSet"].ToString());
                        motherboard.Add("CurrentLanguage", _object["CurrentLanguage"].ToString());
                        motherboard.Add("Description", _object["Description"].ToString());
                        motherboard.Add("EmbeddedControllerMinorVersion", _object["EmbeddedControllerMinorVersion"].ToString());
                        motherboard.Add("EmbeddedControllerMajorVersion", _object["EmbeddedControllerMajorVersion"].ToString());
                        motherboard.Add("IdentificationCode", _object["IdentificationCode"].ToString());
                        motherboard.Add("InstallableLanguages", _object["InstallableLanguages"].ToString());
                        motherboard.Add("InstallDate", _object["InstallDate"].ToString());
                        motherboard.Add("LanguageEdition", _object["LanguageEdition"].ToString());
                        motherboard.Add("ListOfLanguages", _object["ListOfLanguages"].ToString());
                        motherboard.Add("Manufacturer", _object["Manufacturer"].ToString());
                        motherboard.Add("Name", _object["Name"].ToString());
                        motherboard.Add("OtherTargetOS", _object["OtherTargetOS"].ToString());
                        motherboard.Add("PrimaryBIOS", _object["PrimaryBIOS"].ToString());
                        motherboard.Add("ReleaseDate", _object["ReleaseDate"].ToString());
                        motherboard.Add("SerialNumber", _object["SerialNumber"].ToString());
                        motherboard.Add("SMBIOSBIOSVersion", _object["SMBIOSBIOSVersion"].ToString());
                        motherboard.Add("SMBIOSMajorVersion", _object["SMBIOSMajorVersion"].ToString());
                        motherboard.Add("SMBIOSMinorVersion", _object["SMBIOSMinorVersion"].ToString());
                        motherboard.Add("SMBIOSPresent", _object["SMBIOSPresent"].ToString());
                        motherboard.Add("SoftwareElementID", _object["SoftwareElementID"].ToString());
                        motherboard.Add("SoftwareElementState", _object["SoftwareElementState"].ToString());
                        motherboard.Add("System", _object["System"].ToString());
                        motherboard.Add("SystemBiosMajorVersion", _object["SystemBiosMajorVersion"].ToString());
                        motherboard.Add("SystemBiosMinorVersion", _object["SystemBiosMinorVersion"].ToString());
                        motherboard.Add("TargetOperatingSystem", _object["TargetOperatingSystem"].ToString());
                        motherboard.Add("Version", _object["Version"].ToString());

                    }
                    catch (Exception exeption)
                    {
                        Console.WriteLine(exeption.Message);
                    }

                }

            }

            return motherboard;
        }

        /// <summary>
        /// Get a specific Value of your MotherBoard
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetMotherBoardValue(string Value)
        {
            if (motherboardInformation.ContainsKey(Value))
                return motherboardInformation[Value];
            else
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    if (String.IsNullOrEmpty(obj[Value].ToString()))
                        motherboardInformation.Add(Value, obj[Value].ToString());
                }
                return motherboardInformation[Value];
            }
        }

        /// <summary>
        /// MotherBoard Values to get from MotherBoard
        /// </summary>
        public class MotherBoardValues
        {
            public static string BiosCharacteristics { get { return "BiosCharacteristics"; } }
            public string BIOSVersion { get { return "BIOSVersion"; } }
            public string BuildNumber { get { return "BuildNumber"; } }
            public string Caption { get { return "Caption"; } }
            public string CodeSet { get { return "CodeSet"; } }
            public string CurrentLanguage { get { return "CurrentLanguage"; } }
            public string Description { get { return "Description"; } }
            public string EmbeddedControllerMinorVersion { get { return "EmbeddedControllerMinorVersion"; } }
            public string EmbeddedControllerMajorVersion { get { return "EmbeddedControllerMajorVersion"; } }
            public string IdentificationCode { get { return "IdentificationCode"; } }
            public string InstallableLanguages { get { return "InstallableLanguages"; } }
            public string InstallDate { get { return "InstallDate"; } }
            public string LanguageEdition { get { return "LanguageEdition"; } }
            public string ListOfLanguages { get { return "ListOfLanguages"; } }
            public string Manufacturer { get { return "Manufacturer"; } }
            public string Name { get { return "Name"; } }
            public string OtherTargetOS { get { return "OtherTargetOS"; } }
            public string PrimaryBIOS { get { return "PrimaryBIOS"; } }
            public string ReleaseDate { get { return "ReleaseDate"; } }
            public string SerialNumber { get { return "SerialNumber"; } }
            public string SMBIOSBIOSVersion { get { return "SMBIOSBIOSVersion"; } }
            public string SMBIOSMajorVersion { get { return "SMBIOSMajorVersion"; } }
            public string SMBIOSMinorVersion { get { return "SMBIOSMinorVersion"; } }
            public string SMBIOSPresent { get { return "SMBIOSPresent"; } }
            public string SoftwareElementID { get { return "SoftwareElementID"; } }
            public string SoftwareElementState { get { return "SoftwareElementState"; } }
            public string Status { get { return "Status"; } }
            public string SystemBiosMajorVersion { get { return "SystemBiosMajorVersion"; } }
            public string SystemBiosMinorVersion { get { return "SystemBiosMinorVersion"; } }
            public string TargetOperatingSystem { get { return "TargetOperatingSystem"; } }
            public string Version { get { return "Version"; } }
        }

    }
}
