using PhanLong.DAO;
using PhanLong.EF;
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
        public ActionResult AddTodoList(TodoList todoList)
        {
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
        public ActionResult EditTodoList(TodoList todoList)
        {
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
            var result = new ToDolistDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}