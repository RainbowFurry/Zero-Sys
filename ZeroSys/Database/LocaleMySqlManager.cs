using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ZeroSys.Database
{
   /// <summary>
   /// LocaleMySqlManager
   /// </summary>
   public class LocaleMySqlManager
   {

      //NOT DONE

      private string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; Integrated Security = True; Connect Timeout = 30; ";

      //
      public LocaleMySqlManager()
      {

      }

      /// <summary>
      /// Create Locale MySQL DB
      /// </summary>
      /// <param name="dbSavePath"></param>
      /// <param name="dbFileName"></param>
      public void CreateLocaleDB(string dbSavePath, string dbFileName)
      {

         SqlConnection myConn = new SqlConnection(connectionString);

         string str = "CREATE DATABASE " + dbFileName + " ON PRIMARY " +
             "(NAME = " + dbFileName + "_Data, " +
             "FILENAME = '" + dbSavePath + "\\" + dbFileName + ".mdf', " +
             "SIZE = 4MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
             "LOG ON (NAME = " + dbFileName + "_Log, " +
             "FILENAME = '" + dbSavePath + "\\" + dbFileName + ".ldf', " +
             "SIZE = 1MB, " +
             "MAXSIZE = 5MB, " +
             "FILEGROWTH = 10%)";

         SqlCommand myCommand = new SqlCommand(str, myConn);

         try
         {
            myConn.Open();
            myCommand.ExecuteNonQuery();
            MessageBox.Show("DataBase '" + dbFileName + "' was created successfully");
         }
         catch (Exception ex)
         {
            MessageBox.Show("Exception in CreateDatabase " + ex.ToString(), "Exception in CreateDatabase", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
         finally
         {
            if (myConn.State == ConnectionState.Open)
            {
               myConn.Close();
            }
         }

      }

      //
      public void UpdateLocaleDB()
      {

      }

      //
      public void DeleteLocaleDB()
      {

      }

      //
      public void LocaleDBExists()
      {

      }

      //public void GetValueFromLocaleDB

   }
}
