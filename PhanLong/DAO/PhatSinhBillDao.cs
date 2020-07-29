﻿using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class PhatSinhBillDao
    {
        PhanLongDBContext db = new PhanLongDBContext();

        public bool checkbox(CTBill cTBill,int[] chkId, string gui, string giao)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.CTBills.Where(x => x.Id == temp).SingleOrDefault();
                    if (gui != null)
                    {
                        if (cTBill.NgayGui != null)
                        {
                            article.NgayGui = cTBill.NgayGui;
                        }
                        if (cTBill.BaiGui != null)
                        {
                            article.BaiGui = cTBill.BaiGui;
                        }
                        if (cTBill.SoXe != null)
                        {
                            article.SoXe = cTBill.SoXe;
                        }
                    }
                    if (giao != null)
                    {
                        article.NgayGiao = cTBill.NgayGiao;
                    }
                    if (cTBill.GhiChu != null)
                    {
                        article.GhiChu = cTBill.GhiChu;
                    }
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool checkboxngaygiao(CTBill cTBill, int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.CTBills.Where(x => x.Id == temp).SingleOrDefault();
                    article.NgayGiao = cTBill.NgayGiao;
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