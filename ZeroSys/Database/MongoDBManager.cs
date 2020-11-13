using MongoDB.Driver;
using System;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : MongoDB Manager              *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Database
{
    /// <summary>
    /// MongoDB Manager
    /// </summary>
    public class MongoDBManager
    {

        private string database;
        private string connectionString;
        private MongoClient client;//Mongo Client Connection
        private IMongoDatabase db;//Database
        //private IMongoCollection<User> collection;//User Collection 

        /// <summary>
        /// Initialize MongoDBManager
        /// </summary>
        public MongoDBManager()
        {

        }

        /// <summary>
        /// Initialize MongoDBManager
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="database"></param>
        /// <param name="table"></param>
        public MongoDBManager(string user, string password, string host, int port, string database)
        {
            this.database = database;

            connectionString = "mongodb://" + user + ":" + password + "@" + host + ":" + port + "/" + database;
            client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
        }

        /// <summary>
        /// Create DB Connection
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="database"></param>
        /// <param name="table"></param>
        public void CreateConnection(string user, string password, string host, int port, string database)
        {
            this.database = database;

            connectionString = "mongodb://" + user + ":" + password + "@" + host + ":" + port + "/" + database;
            client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
        }



        //
        public void CreateNewDBEntry(string table, Type moddel)
        {

        }

        //
        public void UpdateEntry()
        {

        }

        //
        public void DeleteEntry()
        {

        }

        //
        public void GetEntry()
        {

        }

    }
}
