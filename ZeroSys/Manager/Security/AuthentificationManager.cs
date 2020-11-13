using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ZeroSys.Model;

namespace ZeroSys.Manager.Security
{
    public class AuthentificationManager
    {

        private string table;
        private string database;

        private string connectionString;
        private MongoClient client;//Mongo Client Connection
        private IMongoDatabase db;//Database
        private IMongoCollection<User> collection;//User Collection 

        private List<User> LoggedInUsers = new List<User>();


        /// <summary>
        /// Class Initialisation
        /// </summary>
        public AuthentificationManager(string user, string password, string host, int port, string database, string table)
        {
            this.table = table;
            this.database = database;

            connectionString = "mongodb://" + user + ":" + password + "@" + host + ":" + port + "/" + database;
            client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
            collection = db.GetCollection<User>(table);
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="userName">User Display Name</param>
        /// <param name="password">User Password (Unsecured) it will be hashed</param>
        /// <param name="confirmPassword">The Confirm Password</param>
        public User CreateUser(string userName, string password, string confirmPassword)
        {

            User user = new User()
            {
                ID = Guid.NewGuid().ToString(),
                Name = userName,
                Password = CreateHash(password),
                ConfirmPassword = CreateHash(confirmPassword),
                //permission
            };

            if (user.Password == user.ConfirmPassword)
            {
                collection.InsertOne(user);
                Console.WriteLine("New User has been Created");
                return user;
            }
            else
            {
                Console.WriteLine("New User couldn't be created.");
                throw new Exception("The Password and ConfirmPassword do not match!");
                return null;
            }

            //db.GetCollection<BsonDocument>(collection).InsertOne(table);
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="userName">User Display Name</param>
        /// <param name="password">User Password (Unsecured) it will be hashed</param>
        /// <param name="confirmPassword">The Confirm Password</param>
        /// <param name="permissions">User Permissions</param>
        public User CreateUser(string userName, string password, string confirmPassword, List<string> permissions)
        {
            User user = new User();

            user.ID = Guid.NewGuid().ToString();
            user.Name = userName;
            user.Password = CreateHash(password);
            user.ConfirmPassword = CreateHash(confirmPassword);
            user.Permissions = permissions;

            if (user.Password == user.ConfirmPassword)
            {
                collection.InsertOne(user);
                Console.WriteLine("New User has been Created");
                return user;
            }
            else
            {
                Console.WriteLine("New User couldn't be created.");
                throw new Exception("The Password and ConfirmPassword do not match!");
                return null;
            }

            //db.GetCollection<BsonDocument>(collection).InsertOne(table);
        }

        /// <summary>
        /// Create new User by Class
        /// </summary>
        /// <param name="user">@ZeroAuthentification.Model</param>
        public void CreateUser(User user)
        {
            user.ID = Guid.NewGuid().ToString();
            collection.InsertOne(user);
            Console.WriteLine("New User has been Created");
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            var filter = Builders<User>.Filter;
            collection.DeleteOne(filter.Eq(x => x.ID, user.ID));
        }

        /// <summary>
        /// Check if User has Permission
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool HasPermission(User user, string permission)
        {
            var filter = Builders<User>.Filter;
            User collectionUser = db.GetCollection<User>(table).Find(filter.Eq(x => x.ID, user.ID)).FirstOrDefault();

            if (user.Permissions != null && user.Permissions.Count > 0)
            {
                if (user.Permissions.Contains(permission))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if User has Permissions
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public bool HasPermissions(User user, List<string> permissions)
        {
            var filter = Builders<User>.Filter;
            User collectionUser = db.GetCollection<User>(table).Find(filter.Eq(x => x.ID, user.ID)).FirstOrDefault();

            if (user.Permissions != null && user.Permissions.Count > 0)
            {
                bool hasPermission = true;
                foreach (string permission in permissions)
                {
                    //Check if User has Permission
                    if (!user.Permissions.Contains(permission))
                        hasPermission = false;
                }

                return hasPermission;//all Permissions found
            }

            return false;//one or more Permission missiong
        }

        /// <summary>
        /// Add Permission to User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permission"></param>
        public void AddPermission(User user, string permission)
        {
            var filter = Builders<User>.Filter;
            User collectionUser = db.GetCollection<User>(table).Find(filter.Eq(x => x.ID, user.ID)).FirstOrDefault();

            user.Permissions.Add(permission);
            db.GetCollection<User>(table).FindOneAndReplace(filter.Eq(x => x.ID, user.ID), user);
        }

        /// <summary>
        /// Add Permissions to User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permissions"></param>
        public void AddPermissions(User user, List<string> permissions)
        {
            var filter = Builders<User>.Filter;
            User collectionUser = db.GetCollection<User>(table).Find(filter.Eq(x => x.ID, user.ID)).FirstOrDefault();

            foreach (string permission in permissions)
            {
                user.Permissions.Add(permission);
            }

            db.GetCollection<User>(table).FindOneAndReplace(filter.Eq(x => x.ID, user.ID), user);
        }

        /// <summary>
        /// Remove Permission from User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permission"></param>
        public void RemovePermission(User user, string permission)
        {
            var filter = Builders<User>.Filter;
            User collectionUser = db.GetCollection<User>(table).Find(filter.Eq(x => x.ID, user.ID)).FirstOrDefault();

            if (user.Permissions != null && user.Permissions.Count > 0)
            {
                if (user.Permissions.Contains(permission))
                {
                    user.Permissions.Remove(permission);
                }
            }
            db.GetCollection<User>(table).FindOneAndReplace(filter.Eq(x => x.ID, user.ID), user);
        }

        /// <summary>
        /// Remove Permissions from User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permissions"></param>
        public void RemovePermissions(User user, List<string> permissions)
        {
            var filter = Builders<User>.Filter;
            User collectionUser = db.GetCollection<User>(table).Find(filter.Eq(x => x.ID, user.ID)).FirstOrDefault();

            if (user.Permissions != null && user.Permissions.Count > 0)
            {
                foreach (string permission in permissions)
                {
                    //Check if Permission already granted
                    if (permission.Contains(permission))
                    {
                        user.Permissions.Remove(permission);
                    }
                }

                db.GetCollection<User>(table).FindOneAndReplace(filter.Eq(x => x.ID, user.ID), user);
            }
        }

        /// <summary>
        /// Is User logged in
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsLoggedInUser(User user)
        {
            if (LoggedInUsers.Contains(user))
            {
                Console.WriteLine("User is LoggedIn: " + user.Name);
                return true;
            }
            else
            {
                Console.WriteLine("User is LoggedIn: -");
            }
            return false;
        }

        /// <summary>
        /// Does the User exists?
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UserExists(User user)
        {
            try
            {
                var collection = db.GetCollection<User>(table);
                User findUser = collection.Find<User>(searchUser => searchUser.Name == user.Name).FirstOrDefault();
                //List<User> findUser = collection.Find<User>(searchUser => searchUser.Name == user.Name).ToList<User>();

                if (findUser != null)
                {
                    Console.WriteLine("User Exists: ");
                    Console.WriteLine(findUser.Name);
                    return true;
                }
                else
                {
                    Console.WriteLine("User does not Exists: ");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public (User, bool) Login(string userName, string password)
        {
            User user = new User()
            {
                Name = userName,
                Password = password,
            };

            var t = Login(user);

            return (t.Item1, t.Item2);
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public (User, bool) Login(User user)
        {

            var collection = db.GetCollection<User>(table);
            User findUser = collection.Find<User>(searchUser => searchUser.Name == user.Name).FirstOrDefault();

            if (findUser != null)
            {
                if (findUser.Password == CreateHash(user.Password))
                {
                    Console.WriteLine("User Loggedin: ");
                    Console.WriteLine(findUser.Name);
                    LoggedInUsers.Add(user);
                    return (findUser, true);
                }
                else
                {
                    Console.WriteLine("Wrong Password");
                }
            }
            else
            {
                Console.WriteLine("User does not Exists: ");
                return (null, false);
            }

            return (null, false);
        }

        /// <summary>
        /// Logout User
        /// </summary>
        /// <param name="user"></param>
        public void Logout(User user)
        {
            var collection = db.GetCollection<User>(table);
            User findUser = collection.Find<User>(searchUser => searchUser.Name == user.Name).FirstOrDefault();

            if (findUser != null)
            {
                Console.WriteLine("User Loggedout: ");
                Console.WriteLine(findUser.Name);
                LoggedInUsers.Remove(user);
            }
            else
            {
                Console.WriteLine("User does not Exists: ");
            }

        }

        /// <summary>
        /// Create Default Users
        /// </summary>
        /// <param name="users"></param>
        public void CreateDefaultUsers(List<User> users)
        {
            foreach (User user in users)
            {
                if (!UserExists(user))
                    CreateUser(user);
            }
        }


        /// <summary>
        /// Create Hash Value
        /// </summary>
        /// <param name="text">Password</param>
        /// <returns>Secure Password</returns>
        public string CreateHash(string text)
        {
            // SHA512 is disposable by inheritance.
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
}
