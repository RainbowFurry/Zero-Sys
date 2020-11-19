using registry = Microsoft.Win32;

namespace ZeroSys.Manager.Registry
{
    internal class URLScheme
    {

        private const string UriScheme = "ZeroWorks";
        private const string FriendlyName = "ZeroWorks";

        public static void RegisterUriSchemeRegistry()
        {
            using (var key = registry.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + UriScheme))
            {
                // Replace typeof(App) by the class that contains the Main method or any class located in the project that produces the exe.
                // or replace typeof(App).Assembly.Location by anything that gives the full path to the exe
                string applicationLocation = "";//typeof("App").Assembly.Location;

                key.SetValue("", "URL:" + FriendlyName);
                key.SetValue("URL Protocol", "");

                using (var defaultIcon = key.CreateSubKey("DefaultIcon"))
                {
                    defaultIcon.SetValue("", applicationLocation + ",1");
                }

                using (var commandKey = key.CreateSubKey(@"shell\open\command"))
                {
                    commandKey.SetValue("", "\"" + applicationLocation + "\" \"%1\"");
                }
            }
        }

    }
}
