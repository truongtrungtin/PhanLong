using PhanLong.EF;
using System.Collections.Generic;
using System.Linq;

namespace PhanLong.DAO
{
    public class RolesDao
    {
        PhanLongDBContext db = null;
        public RolesDao()
        {
            db = new PhanLongDBContext();
        }
        //public bool checkbox(int[] chkId)
        //{
        //    try
        //    {
        //        for (int i = 0; i < chkId.Length; i++)
        //        {
        //            int temp = chkId[i];
        //            var article = db.Credentials.Where(x => x.UserId == temp && x.RoleId ==).SingleOrDefault();
        //            db.DMBills.Remove(article);
        //        }
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }

        //}

        public List<Role> ListAll()
        {
            return db.Roles.ToList();
        }
    }
}