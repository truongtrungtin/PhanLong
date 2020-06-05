using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class PhatSinhBillDao
    {
        QLDLDBContext db = new QLDLDBContext();

        public bool checkboxguibai(CTBill cTBill,int[] chkId)
        {
            try
            {
                foreach (var item in chkId)
                {
                    int temp = chkId[item];
                    var article = db.CTBills.Where(x => x.Id == temp).SingleOrDefault();
                    article.NgayGui = cTBill.NgayGui;
                    article.BaiGui = cTBill.BaiGui;
                    article.SoXe = cTBill.SoXe;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public CTBill GetById(int[] chkId)
        {

        }

    }
}