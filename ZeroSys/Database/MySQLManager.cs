using MySql.Data.MySqlClient;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : MySQL DB Manager             *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Database
{
   /// <summary>
   /// MySQL DB Manager
   /// </summary>
   public class MySQLManager
   {

      //https://www.c-sharpcorner.com/UploadFile/9582c9/insert-update-delete-display-data-in-mysql-using-C-Sharp/f
      private static string connectionString;
      private static MySqlConnection sqlConnection;

      /// <summary>
      /// Initialize MySQLManager
      /// </summary>
      public MySQLManager()
      {
         //
      }

      /// <summary>
      /// Initialize MySQLManager
      /// </summary>
      /// <param name="server"></param>
      /// <param name="port"></param>
      /// <param name="user"></param>
      /// <param name="password"></param>
      /// <param name="database"></param>
      public MySQLManager(string server, int port, string user, string password, string database)
      {
         connectionString += "server=" + server;
         connectionString += "port=" + port;
         connectionString += "uid=" + user;
         connectionString += "password=" + password;
         connectionString += "database=" + database;
         sqlConnection = new MySqlConnection(connectionString);
         sqlConnection.Open();
      }

      /// <summary>
      /// Create MySql Server Connection
      /// </summary>
      /// <param name="server"></param>
      /// <param name="port"></param>
      /// <param name="user"></param>
      /// <param name="password"></param>
      /// <param name="database"></param>
      public void CreateConnection(string server, int port, string user, string password, string database)
      {
         connectionString += "server=" + server;
         connectionString += "port=" + port;
         connectionString += "uid=" + user;
         connectionString += "password=" + password;
         connectionString += "database=" + database;
         sqlConnection = new MySqlConnection(connectionString);
         sqlConnection.Open();
      }

      /// <summary>
      /// Close MySql Server Connection
      /// </summary>
      public void CloseConnection()
      {
         sqlConnection.Close();
      }


      //
      public void AddEntry(string table, string[] keys, string[] values)
      {
         string valueString = "";
         string keyString = "";

         if (keys.Length == values.Length)
         {
            for (int i = 0; i < keys.Length - 1; i++)
            {
               keyString += keys[i] + ",";
               valueString += values[i] + ",";
            }
            keyString.Substring(0, keyString.Length - 1);
         }
         string command = string.Format($"insert into {0}({1}) values({2})", table, keyString, valueString);
         //Create DB ENTRY!!!
      }

      //
      public void UpdateEntry(string table)
      {
         //string command = $"update ";
      }

      //
      public void DeleteEntry(string table)
      {
         //
         //string command = $"delete from ... where ...";
      }

      //
      public void GetEntry(string table)
      {
         //
         //string command = $"select * from ...";
      }

      //
      public void BuildQuerryString()
      {
         //2 string arrays key und content = erstelle insert command etc...
      }

      //
      public void CreateBackupFile()
      {

      }

      //
      public void CreateBackup()
      {

      }

      //
      public void MoveDBFromTo()
      {

      }

   }
}
