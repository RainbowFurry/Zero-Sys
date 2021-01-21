using System;
using System.Net;

namespace ZeroSys.Manager.Web
{
   /// <summary>
   /// WebPageInfoManager
   /// </summary>
   public class WebPageInfoManager
   {

      //TODO
      //GET IF PAGE IS written in c#, angular, etc...
      //get if server is windows/Linux
      //IpAdress ip = new ...
      //https://www.c-sharpcorner.com/blogs/identify-hosted-asp-net-website-version-from-browser

      private static Uri uri;
      private static IPAddress ip;
      private static HttpWebRequest request;
      private static HttpWebResponse response;

      /// <summary>
      /// Get Complete Server Info
      /// </summary>
      /// <param name="serverAddress"></param>
      public static void GetServerInfo(string serverAddress)
      {

         uri = new Uri(serverAddress);
         ip = Dns.GetHostAddresses(uri.Host)[0];

         Console.WriteLine("IP: " + ip);
         Console.WriteLine("Host: " + uri.Host);
         Console.WriteLine("Scheme: " + uri.Scheme);
         Console.WriteLine("Authority: " + uri.Authority);
         Console.WriteLine("Port: " + uri.Port);
         Console.WriteLine("IsPortDefault: " + uri.IsDefaultPort);
         Console.WriteLine("Segment: " + uri.Segments[0]);
         Console.WriteLine("HostName(ServerName): " + Dns.GetHostEntry(ip).HostName);

         Console.WriteLine("AddressFamily: " + Dns.GetHostAddresses(uri.Host)[0].AddressFamily);
         Console.WriteLine("MapToIPv4: " + Dns.GetHostAddresses(uri.Host)[0].MapToIPv4());
         Console.WriteLine("MapToIPv6: " + Dns.GetHostAddresses(uri.Host)[0].MapToIPv6());
         Console.WriteLine("IsIPv4MappedToIPv6: " + Dns.GetHostAddresses(uri.Host)[0].IsIPv4MappedToIPv6);
         Console.WriteLine("IsIPv6LinkLocal: " + Dns.GetHostAddresses(uri.Host)[0].IsIPv6LinkLocal);
         Console.WriteLine("IsIPv6Multicast: " + Dns.GetHostAddresses(uri.Host)[0].IsIPv6Multicast);
         Console.WriteLine("IsIPv6SiteLocal: " + Dns.GetHostAddresses(uri.Host)[0].IsIPv6SiteLocal);

      }

      /// <summary>
      /// Get the Ip Address of the Server by Address
      /// </summary>
      /// <param name="domainName"></param>
      /// <returns></returns>
      public static string GetIp(string domainName)
      {
         uri = new Uri(domainName);
         return Dns.GetHostAddresses(uri.Host)[0].ToString();
      }

      /// <summary>
      /// Get the Scheme (http/https/custom)
      /// </summary>
      /// <param name="serverAddress"></param>
      /// <returns></returns>
      public static string GetScheme(string serverAddress)
      {
         uri = new Uri(serverAddress);
         return uri.Scheme;
      }

      /// <summary>
      /// Get the used Port for the Address
      /// </summary>
      /// <param name="serverAddress"></param>
      /// <returns></returns>
      public static int GetPort(string serverAddress)
      {
         uri = new Uri(serverAddress);
         return uri.Port;
      }

      /// <summary>
      /// Get the Servers (Maschine) Name
      /// </summary>
      /// <param name="serverAddress"></param>
      /// <returns></returns>
      public static string GetServerName(string serverAddress)
      {
         uri = new Uri(serverAddress);
         return Dns.GetHostEntry(ip).HostName;
      }

      /// <summary>
      /// Get the Server State if the Server is online or offline
      /// </summary>
      /// <param name="serverAddress"></param>
      /// <returns></returns>
      public static bool GetServerState(string serverAddress)
      {

         HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(serverAddress);
         httpReq.AllowAutoRedirect = false;

         HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();

         if (httpRes.StatusCode == HttpStatusCode.OK)
         {
            return true;
         }

         // Close the response.
         httpRes.Close();
         return false;
      }

      /// <summary>
      /// Get Server Type (Linux, Windows, Nginx, Apache)
      /// Open Browser and press STRG + C
      /// Then Open Network and press record + F5 and stop after 5sec.
      /// Select the firest File and select Headers.
      /// There you go.
      /// </summary>
      /// <param name="serverURL"></param>
      /// <returns></returns>
      public static string GetServerType(string serverAddress)
      {
         request = (HttpWebRequest)WebRequest.Create(serverAddress);
         response = (HttpWebResponse)request.GetResponse();

         string serverType = response.Headers.Get("server");

         if (!String.IsNullOrEmpty(serverType))
            return serverType;
         return null;
      }


      /*
       Uri uri = new Uri("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName");

Console.WriteLine($"AbsolutePath: {uri.AbsolutePath}");
Console.WriteLine($"AbsoluteUri: {uri.AbsoluteUri}");
Console.WriteLine($"DnsSafeHost: {uri.DnsSafeHost}");
Console.WriteLine($"Fragment: {uri.Fragment}");
Console.WriteLine($"Host: {uri.Host}");
Console.WriteLine($"HostNameType: {uri.HostNameType}");
Console.WriteLine($"IdnHost: {uri.IdnHost}");
Console.WriteLine($"IsAbsoluteUri: {uri.IsAbsoluteUri}");
Console.WriteLine($"IsDefaultPort: {uri.IsDefaultPort}");
Console.WriteLine($"IsFile: {uri.IsFile}");
Console.WriteLine($"IsLoopback: {uri.IsLoopback}");
Console.WriteLine($"IsUnc: {uri.IsUnc}");
Console.WriteLine($"LocalPath: {uri.LocalPath}");
Console.WriteLine($"OriginalString: {uri.OriginalString}");
Console.WriteLine($"PathAndQuery: {uri.PathAndQuery}");
Console.WriteLine($"Port: {uri.Port}");
Console.WriteLine($"Query: {uri.Query}");
Console.WriteLine($"Scheme: {uri.Scheme}");
Console.WriteLine($"Segments: {string.Join(", ", uri.Segments)}");
Console.WriteLine($"UserEscaped: {uri.UserEscaped}");
Console.WriteLine($"UserInfo: {uri.UserInfo}");
       */

      /*
                HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("https://docs.microsoft.com/de-de/azure/?product=featured");
        Uri myUri = new Uri("https://docs.microsoft.com/de-de/azure/?product=featured");
        HttpClient myHttpClient = new HttpClient();
        HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();

        Console.WriteLine("Request");
        foreach (string s in HttpWReq.Headers.AllKeys)
        {
           Console.WriteLine(HttpWReq.Headers.Get(s));
        }

        Console.WriteLine("\n\nResponse");
        foreach (string s in HttpWResp.Headers.AllKeys)
        {
           Console.WriteLine(HttpWResp.Headers.Get(s));
        }
       */

   }
}
