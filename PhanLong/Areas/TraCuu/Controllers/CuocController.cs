using PhanLong.DAO;
using PhanLong.EF;
using System.Web.Mvc;

namespace PhanLong.Areas.TraCuu.Controllers
{
    public class CuocController : BaseController
    {
        // GET: TraCuu/Cuoc
        public ActionResult Index()
        {
            var dao = new TraCuuCuocDao();
            var model = dao.ListAll();
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(TraCuuCuoc traCuuCuoc)
        {
            var dao = new TraCuuCuocDao();
            var model = dao.Search(traCuuCuoc);
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ViewTraCuuCuoc()
        {
            var dao = new TraCuuCuocDao();
            var model = dao.ListAll();
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMMoocDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(DMMooc dMMooc, int[] chkId, string delete = null)
        {
            var item = new DMMoocDao();
            if (delete != null && chkId != null)
            {
                var result = item.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new DMMoocDao();
                    var Check = dao.Check(dMMooc.MaMooc);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã mooc này đã tồn tại! " +
                            "Vui lòng nhập mã mooc khác!", "warning");
                        return RedirectToAction("Create", "DMMooc");
                    }
                    else
                    {
                        long id = dao.Insert(dMMooc);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm mooc thành công !", "success");
                            return RedirectToAction("Create", "DMMooc");
                        }
                        else
                        {
                            SetAlert("Thêm mooc không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMMooc");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMMooc");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMMoocDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMMooc dMMooc, int[] chkId, string delete = null)
        {
            var item = new DMMoocDao();
            if (delete != null && chkId != null)
            {
                var result = item.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new DMMoocDao();
                    var Check1 = dao.Check(dMMooc.MaMooc);
                    var Check2 = dao.GetById(dMMooc.Id);
                    if (Check1.Count > 0 && Check2.MaMooc != dMMooc.MaMooc)
                    {
                        SetAlert("Mã mooc này đã tồn tại! " +
                            "Vui lòng nhập mã mooc khác!", "warning");
                        return RedirectToAction("Update", "DMMooc", new { id = dMMooc.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMMooc);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu xe thành công!", "success");
                            return RedirectToAction("Index", "DMMooc");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu xe không thành công", "warning");
                            return RedirectToAction("Update", "DMMooc");
                        }
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Index");
        }
    }
}