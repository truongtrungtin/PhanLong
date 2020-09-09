using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class TableDao
    {
        PhanLongDBContext db = null;
        public TableDao()
        {
            db = new PhanLongDBContext();
        }


        public List<string> GetListColumn(string TableName)
        {
            var data = db.Database.SqlQuery<string>("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('" + TableName + "')");
            return data.ToList();

        }



    }
}