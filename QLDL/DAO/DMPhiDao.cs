﻿using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMPhiDao
    {
        QLDLContext db = null;
        public DMPhiDao()
        {
            db = new QLDLContext();
        }
        public List<DMPhi> ListAll()
        {
            return db.DMPhis.OrderBy(x => x.Id).ToList();
        }

        public List<DMPhi> Check(string MaPhi)
        {
            return db.DMPhis.Where(x => x.MaPhi == MaPhi).ToList();

        }
        public DMPhi GetById(long id)
        {
            return db.DMPhis.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMPhi entity)
        {
            db.DMPhis.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMPhi dMPhi)
        {
            try
            {
                var item = db.DMPhis.Find(dMPhi.Id);
                item.MaPhi = dMPhi.MaPhi;
                item.TenPhi = dMPhi.TenPhi;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var item = db.DMPhis.Find(id);
                db.DMPhis.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}