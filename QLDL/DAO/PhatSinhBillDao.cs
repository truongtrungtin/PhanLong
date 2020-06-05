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
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
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

        public List<CTBill> ListCheck(int[] chkId)
        {
            var model = new List<CTBill>();

            foreach (var item in chkId)
            {
                var a = db.CTBills.Find(item);
                model.Add(a);
            }
            return model.ToList();
        }
        
    }
}