using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace EasyMaintain.DataAccess
{
    public class DatabaseSettings
    {
        public string mDatabaseServer;
        public string mDBCatalog;
        public int mPort;
        public int mTimeout;
        public string mUsername;
        private string mPassword;
        public int mMinPoolSize { get; set; }
        public int mMaxPoolSize { get; set; }

        public DatabaseSettings(string databaseServer, int port, string catalog, string username, string password, int timeOut)
        {
            mDatabaseServer = databaseServer;
            mPort = port;
            mDBCatalog = catalog;
            mUsername = username;
            mPassword = password;
            mTimeout = timeOut;
        }

        public String GetConnectionString()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = mDatabaseServer;
            sb.InitialCatalog = mDBCatalog;
            if (mUsername == null)
            {
                sb.IntegratedSecurity = true;
            }
            else
            {
                sb.UserID = mUsername;
                sb.Password = DecryptPassword();
                sb.PersistSecurityInfo = false;
            }
            sb.ConnectTimeout = mTimeout;
            sb.Pooling = true;
            //sb.MaxPoolSize = mMaxPoolSize;
            //sb.MinPoolSize = mMinPoolSize;
            return sb.ToString();
        }

        private string DecryptPassword()
        {
            //TODO
            return mPassword;
            //throw new NotImplementedException();
        }


    }
}
