using PhanLong.DAO;
using PhanLong.EF;
using System.Linq;
using System.Web.Mvc;

namespace PhanLong.Areas.NhapLieu.Controllers
{
    public class PhatSinhBillController : BaseController
    {
        // GET: NhapLieu/PhatSinhBill
        public ActionResult Index()
        {
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, int? Bill = null, int? KhachHang = null, string ToDate = null, string FromDate = null, string chitiet = null, string update = null, string delete = null)
        {
            var dao = new DMBillDao();

            if (delete != null && chkId != null)
            {

                var result = dao.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            else if (update != null && chkId.Length == 1)
            {
                return RedirectToAction("Update", "DMBill", new {area = "DanhMuc" , id = chkId[0]});
            }
            else if (chitiet != null && chkId.Length == 1)
            {
                return RedirectToAction("CTBill", "PhatSinhBill", new { id = chkId[0] });
            }
            var model = dao.ListAll(Bill, KhachHang, ToDate, FromDate);
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(CTBill cTBill, int[] chkId, string themngayguibai = null, string themngaygiao = null, string gui = null, string giao = null, string update = null, string delete = null)
        {
            var bill = new DMBillDao().GetById(cTBill.Bill);
            var dao = new PhatSinhBillDao();
            var model = dao.ListCheck(chkId);
            ViewBag.IdBill = bill.Id;
            ViewBag.Bill = bill.MaBill;
            if (themngayguibai != null)
            {

                ViewBag.Ngay = "Thêm ngày gửi bãi";
                return View(model);
            }
            else if (themngaygiao != null)
            {
                ViewBag.Ngay = "Thêm ngày giao";
                return View(model);
            }
            else if (delete != null && chkId != null)
            {
                var result = new CTBillDao().checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                    return RedirectToAction("CTBill", "PhatSinhBill", new { id = cTBill.Bill });

                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                    return RedirectToAction("CTBill", "PhatSinhBill", new { id = cTBill.Bill });
                }
            }
            else if (update != null && chkId.Count() == 1)
            {
                return RedirectToAction("UpdateCTBill", "DMBill", new { CTBill = chkId[0], id = cTBill.Bill, area = "DanhMuc" });
            }
            else
            {
                var resutl = dao.checkbox(cTBill, chkId, gui, giao);
                if (gui != null)
                {
                    if (resutl)
                    {
                        SetAlert("Thêm ngày gửi thành công", "success");
                    }
                    else
                    {
                        SetAlert("Thêm ngày gửi không thành công", "warning");
                    }
                }
                else
                {
                    if (resutl)
                    {
                        SetAlert("Thêm ngày giao thành công", "success");
                    }
                    else
                    {
                        SetAlert("Thêm ngày giao không thành công", "warning");
                    }
                }
                return RedirectToAction("CTBill", "PhatSinhBill", new { id = cTBill.Bill });
            }
        }

        public PartialViewResult Filter()
        {
            return PartialView();
        }

        public ActionResult CTBill(long id)
        {
            var dao = new CTBillDao();
            ViewBag.MaBill = new DMBillDao().GetById(id).MaBill;
            ViewBag.IdBill = new DMBillDao().GetById(id).Id;
            var model = dao.ListAll(id);
            return View(model);
        }
    }
}