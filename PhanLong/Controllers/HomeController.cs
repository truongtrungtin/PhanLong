using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddTodoList()
        {
            return PartialView("AddTodoList");
        }

        [HttpPost]
        public ActionResult AddTodoList(TodoList todoList, HttpPostedFileBase FileUpload)
        {
            if (FileUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(FileUpload.FileName);
                string extension = Path.GetExtension(FileUpload.FileName);
                fileName += extension;
                string Url = "/File/Todolist/" + todoList.Ngay.ToString("dd-MM-yyyy") + "/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/File/Todolist/" + todoList.Ngay.ToString("dd-MM-yyyy")), fileName);
                if (!Directory.Exists(Server.MapPath("~/File/Todolist/" + todoList.Ngay.ToString("dd-MM-yyyy"))))
                {
                    Directory.CreateDirectory(Server.MapPath("~/File/Todolist/" + todoList.Ngay.ToString("dd-MM-yyyy")));
                }
                FileUpload.SaveAs(fileName);
                todoList.FileUpload = Url;
            }
            if (new ToDolistDao().Insert(todoList))
            {
                SetAlert("Thêm kế hoạch thành công!", "success");
            }
            else
            {
                SetAlert("Thêm kế hoạch không thành công!", "warning");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public PartialViewResult EditTodoList(long id)
        {
            var model = new ToDolistDao().GetById(id);
            ViewBag.ngay = model.Ngay;
            return PartialView("EditTodoList", model);
        }

        [HttpPost]
        public ActionResult EditTodoList(TodoList todoList, HttpPostedFileBase FileUpload)
        {
            if (FileUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(FileUpload.FileName);
                string extension = Path.GetExtension(FileUpload.FileName);
                fileName += extension;
                string Url = "/File/Todolist/" + todoList.Ngay.ToString("dd-MM-yyyy") + "/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/File/Todolist/" + todoList.Ngay.ToString("dd-MM-yyyy")), fileName);
                if (!Directory.Exists(Server.MapPath("~/File/Todolist/" + todoList.Ngay.ToString("dd-MM-yyyy"))))
                {
                    Directory.CreateDirectory(Server.MapPath("~/File/Todolist/" + todoList.Ngay.ToString("dd-MM-yyyy")));
                }
                FileUpload.SaveAs(fileName);
                todoList.FileUpload = Url;
            }
            if (new ToDolistDao().Update(todoList))
            {
                SetAlert("Chỉnh sửa kế hoạch thành công!", "success");
            }
            else
            {
                SetAlert("Chỉnh sửa kế hoạch không thành công!", "warning");
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            if (new ToDolistDao().Delete(id))
            {
                SetAlert("Xoá thành công!", "success");
            }
            else
            {
                SetAlert("Xoá không thành công", "warning");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var result = new ToDolistDao().ChangeStatus(id,session.UserName);
            return Json(new
            {
                status = result
            });
        }

        [HttpPost]
        public JsonResult ChangeSettings(long id)
        {
            var result = new ToDolistDao().ChangeSetting(id);
            return Json(new
            {
                VAT = result
            });
        }

    }
}