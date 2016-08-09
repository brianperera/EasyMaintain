using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DataAccess
{
    interface IDbHelper
    {
        IDbConnection CreateConnection(DatabaseSettings dbSettings);

        void ChangeDatabase(IDbConnection db, String strDB);
        void CreateDatabase(DatabaseSettings dbSettings);
        void CompactDatabase(DatabaseSettings dbSettings, DatabaseSettings newDbSettings);
        bool VerifyDatabase(DatabaseSettings dbSettings, bool deleteCorruptRows);
        void DropDatabase(DatabaseSettings dbSettings);

        IDataReader ExecuteReaderSql(IDbConnection db, String sql);
        IDataReader ExecuteReaderSql(IDbConnection db, String sql, IDbTransaction trans);
        void ExecuteSql(IDbConnection db, String sql);
        void ExecuteSql(IDbConnection db, String sql, IDbTransaction trans);

        IDbCommand GetDbCommand();
        IDbCommand GetDbCommand(IDbConnection db);
    }
}
