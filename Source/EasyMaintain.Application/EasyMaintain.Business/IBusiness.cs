using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
    public interface IBusiness
    {
        // Get Data
        object GetData();

        // Save data
        int Save(object record);

        // Insert new record
        int Insert(object record);

        //Delete a record
        void DeleteOne(object record);

        // Undate a record
        bool UpdateOne(object record);
        //find the suppier using an id
    // object Find(object key);
        //update multiple records
        //bool UpdateRecords(List<object> records);

        //Delete multiple Records
        //void DeleteRecords(List<object> records);

        //Refresh Data
        //void Refresh();
    }
}
