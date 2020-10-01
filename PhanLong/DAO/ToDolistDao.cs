using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanLong.DAO
{
    public class ToDolistDao
    {
        PhanLongDBContext db = null;
        public ToDolistDao()
        {
            db = new PhanLongDBContext();
        }

        public List<TodoList> List()
        {
            IQueryable<TodoList> model = db.TodoLists.Where(x => (x.Ngay - DateTime.Now).TotalDays >= 0);
            return model.OrderBy(x => x.Ngay).ToList();
        }
        public TodoList GetById(long id)
        {
            return db.TodoLists.SingleOrDefault(x => x.Id == id);
        }

        public bool Insert(TodoList entity)
        {
            try
            {
                entity.IsActive = true;
                var i = db.TodoLists.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                return false;
            }

        }

        public bool Update(TodoList toDolist)
        {
            try
            {
                var item = db.TodoLists.Find(toDolist.Id);
                item.Ngay = toDolist.Ngay;
                item.Mota = toDolist.Mota;
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
                var user = db.TodoLists.Find(id);
                db.TodoLists.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool? ChangeStatus(long id)
        {
            var user = db.TodoLists.Find(id);
            user.IsActive = !user.IsActive;
            db.SaveChanges();
            return user.IsActive;
        }
    }
}