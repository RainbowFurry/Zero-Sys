using System.Collections.Generic;
using System.Net.NetworkInformation;
using SystemNetwork = System.Net.NetworkInformation;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Network Interface Info   *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemController.Software
{
    /// <summary>
    /// Get Network Interface Information
    /// </summary>
    public class NetworkInterface
    {

        /// <summary>
        /// Get the Complete Information about your NetworkInterface
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> getNetworkInterfaceInformation()
        {

            Dictionary<string, string> networkInterface = new Dictionary<string, string>();

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            SystemNetwork.NetworkInterface[] nics = SystemNetwork.NetworkInterface.GetAllNetworkInterfaces();


            networkInterface.Add("Host", computerProperties.HostName);
            networkInterface.Add("Domain", computerProperties.DomainName);

            if (nics == null || nics.Length < 1)
            {
                networkInterface.Add("NoNetwork", "No network interfaces found.");
                return networkInterface;
            }

            networkInterface.Add("InterfaceAmount", nics.Length.ToString());

            foreach (SystemNetwork.NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                networkInterface.Add("Description", adapter.Description);
                networkInterface.Add("InterfaceType", adapter.NetworkInterfaceType.ToString());
                networkInterface.Add("PhisicalAddress", adapter.GetPhysicalAddress().ToString());
                networkInterface.Add("Status", adapter.OperationalStatus.ToString());

                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }

                networkInterface.Add("IpVersion", versions);

                // The following information is not useful for loopback adapters.
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }

                networkInterface.Add("DNSSuffix", properties.DnsSuffix);

                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {

                    IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                    networkInterface.Add("MTU", ipv4.Mtu.ToString());
                }

                networkInterface.Add("DNSEnabled", properties.IsDnsEnabled.ToString());
                networkInterface.Add("DynamicallyConfiguredDNS", properties.IsDynamicDnsEnabled.ToString());
                networkInterface.Add("ReceiveOnly", adapter.IsReceiveOnly.ToString());
                networkInterface.Add("Multicast", adapter.SupportsMulticast.ToString());

            }

            return networkInterface;
        }

        /// <summary>
        /// Get a specific Value of your NetworkInterface
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string getNetworkInterfaceValue(string value)
        {
            //
            return "";
        }

        /// <summary>
        /// NetworkInterface Values to get from NetworkInterface
        /// </summary>
        public class NetworkInterfaceValues
        {
            public static string Host { get { return "Host"; } }
            public static string Domain { get { return "Domain"; } }
            public static string InterfaceAmount { get { return "InterfaceAmount"; } }
            public static string Description { get { return "Description"; } }
            public static string InterfaceType { get { return "InterfaceType"; } }
            public static string PhisicalAddress { get { return "PhisicalAddress"; } }
            public static string Status { get { return "Status"; } }
            public static string DNSSuffix { get { return "DNSSuffix"; } }
            public static string IpVersion { get { return "IpVersion"; } }
            public static string MTU { get { return "MTU"; } }
            public static string DNSEnabled { get { return "DNSEnabled"; } }
            public static string DynamicallyConfiguredDNS { get { return "DynamicallyConfiguredDNS"; } }
            public static string ReceiveOnly { get { return "ReceiveOnly"; } }
            public static string Multicast { get { return "Multicast"; } }
        }

    }
}
