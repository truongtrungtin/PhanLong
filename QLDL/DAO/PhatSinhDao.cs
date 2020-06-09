using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class PhatSinhDao
    {
        QLDLDBContext db = null;
        public PhatSinhDao()
        {
            db = new QLDLDBContext();
        }

        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.PhatSinhs.Where(x => x.Id == temp).SingleOrDefault();
                    db.PhatSinhs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<PhatSinh> listKH(long id)
        {
            return db.PhatSinhs.Where(x => x.KhachHang == id).ToList();
        }

        public List<PhatSinh> ListAll()
        {
            return db.PhatSinhs.OrderByDescending(x => x.Ngay).ToList();
        }

        public List<PhatSinh> Listtk(PhatSinh phatSinh, string sday, string eday)
        {
            IQueryable<PhatSinh> model = db.PhatSinhs;
            DateTime sdate = (sday != "") ? Convert.ToDateTime(sday).Date : new DateTime();
            DateTime edate = (eday != "") ? Convert.ToDateTime(eday).Date : new DateTime();

            if (phatSinh.Kho != null)
            {
                if (phatSinh.Loai != null)
                {
                    if (phatSinh.Xe != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai  && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Xe != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe  && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.KhachHang != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Xe != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho  && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else
                {
                    model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                }
            }
            else if (phatSinh.Xe != null)
            {
                if (phatSinh.Loai != null)
                {
                    if (phatSinh.Kho != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Xe == phatSinh.Xe && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Kho != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.KhachHang != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Xe == phatSinh.Xe && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Kho != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x =>  x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else
                {
                    model = db.PhatSinhs.Where(x => x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                }
            }
            else if (phatSinh.Loai != null)
            {
                if (phatSinh.Kho != null)
                {
                    if (phatSinh.Xe != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Xe != null)
                {
                    if (phatSinh.Kho != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.KhachHang != null)
                {
                    if (phatSinh.Kho != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Xe != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else
                {
                    model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                }
            }
            else if (phatSinh.KhachHang != null)
            {
                if (phatSinh.Loai != null)
                {
                    if (phatSinh.Xe != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Kho != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Xe != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Kho != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang &&  x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Kho != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Xe != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho &&  x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else
                {
                    model = db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang && ((sday== "" && eday== "") ||(x.Ngay >= sdate && x.Ngay <= edate)));
                }
            }
            else
            {
                model = db.PhatSinhs.Where(x => x.Ngay >= sdate && x.Ngay <= edate);
            }
            return model.OrderBy(x => x.Ngay).ToList();
        }

        public PhatSinh GetById(long? id)
        {
            return db.PhatSinhs.SingleOrDefault(x => x.Id == id);
        }
        public PhatSinh GetByData(PhatSinh phatSinh)
        {
            return db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang || x.Xe == phatSinh.Xe || x.Loai == phatSinh.Xe || x.Kho == phatSinh.Kho).FirstOrDefault();
        }

        public List<PhatSinh> GetLoai(long? id)
        {
            return db.PhatSinhs.Where(x => x.TenTX == id).ToList();
        }
        public long Insert(PhatSinh entity)
        {
            db.PhatSinhs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(PhatSinh phatSinh)
        {
            try
            {
                var item = db.PhatSinhs.Find(phatSinh.Id);
                item.Ngay = phatSinh.Ngay;
                item.Loai = phatSinh.Loai;
                item.KhachHang = phatSinh.KhachHang;
                item.Kho = phatSinh.Kho;
                item.SoCont = phatSinh.SoCont;
                item.SoBill = phatSinh.SoBill;
                item.CangNhan = phatSinh.CangNhan;
                item.CangTra = phatSinh.CangTra;
                item.CuocKH = phatSinh.CuocKH;
                item.CuocTX = phatSinh.CuocTX;
                item.TenTX = phatSinh.TenTX;
                item.Xe = phatSinh.Xe;
                item.HDNang = phatSinh.HDNang;
                item.TienNang = phatSinh.TienNang;
                item.HDHa = phatSinh.HDHa;
                item.TienHa = phatSinh.TienHa;
                item.PhiKH = phatSinh.PhiKH;
                item.TienPhiKH = phatSinh.TienPhiKH;
                item.PhiCT = phatSinh.PhiCT;
                item.TienPhiCT = phatSinh.TienPhiCT;
                item.GhiChu = phatSinh.GhiChu;
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
                var item = db.PhatSinhs.Find(id);
                db.PhatSinhs.Remove(item);
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