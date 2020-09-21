using PhanLong.EF;
using PhanLong.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhanLong.DAO
{
    public class CongNoDao
    {

        PhanLongDBContext db = null;
        public CongNoDao()
        {
            db = new PhanLongDBContext();
        }

        public List<CongNoModel> ListAll(CongNoModel congNoModel)
        {
            var data = from nv in db.DMKhachHangs
                       join ps in db.PhatSinhs on nv.Id equals ps.KhachHang
                       select new CongNoModel()
                       {
                           Ngay = ps.Ngay,
                           KhachHang = nv.MaKH,
                           Cont = ps.SoCont,
                           Cuoc = ps.CuocKH,
                           ChiHo = ps.TienHa + ps.TienNang + ps.TienPhiKH,
                       };
            var model = data;
            if (congNoModel.KhachHang != null)
            {
                model = model.Where(x => x.KhachHang == congNoModel.KhachHang);
            }
            return model.OrderBy(x => x.KhachHang).ToList();
        }

        public DMKhachHang GetByMa(string MaKH)
        {
            return db.DMKhachHangs.SingleOrDefault(x => x.MaKH == MaKH);
        }
    }
}