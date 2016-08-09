using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DataAccess
{
    public class DatabaseConnection
    {
        static DatabaseSettings mDbSetting;

        public DatabaseConnection(DatabaseSettings dbSetting)
        {
            mDbSetting = dbSetting;
        }

        public void ChangeDatabase(IDbConnection db, String strDB)
        { 
        
        }

        public void CreateDatabase(DatabaseSettings dbSettings)
        { 
        
        }

        public void CompactDatabase(DatabaseSettings dbSettings, DatabaseSettings newDbSettings)
        {

        }

        public bool VerifyDatabase(DatabaseSettings dbSettings, bool deleteCorruptRows)
        {
            return true;
        }

        public void DropDatabase(DatabaseSettings dbSettings)
        {

        }
        
        public IDataReader ExecuteReaderSql(IDbConnection db, String sql)
        {
            SqlDataReader reader = new SqlDataReader();
            return reader;
        }

        public IDataReader ExecuteReaderSql(IDbConnection db, String sql, IDbTransaction trans)
        {
            SqlDataReader reader = new SqlDataReader();

            return reader;
        }

        public void ExecuteSql(IDbConnection db, String sql)
        {

        }

        public void ExecuteSql(IDbConnection db, String sql, IDbTransaction trans)
        {

        }


        public IDbCommand GetDbCommand()
        {

        }

        public IDbCommand GetDbCommand(IDbConnection db)
        {

        }
        
        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(mDbSetting.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
