using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanLong.EF;
using System.Configuration;
using PhanLong.Common;

namespace PhanLong.DAO
{
    public class UserDao
    {

        PhanLongDBContext db = null;
        public UserDao()
        {
            db = new PhanLongDBContext();
        }


        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.Users.Where(x => x.Id == temp).SingleOrDefault();
                    db.Users.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.Username == entity.Username);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
            else
            {
                return user.Id;
            }

        }
        public bool Update(User entity, string[] selectroles)
        {
            try
            {
                var user = db.Users.Find(entity.Id);
                user.Name = entity.Name;
                if (selectroles.Length > 0)
                {
                    var remove = db.Credentials.Where(x => x.UserId == user.Id).ToList();
                    foreach (var item in remove)
                    {
                        db.Credentials.Remove(item);
                    }
                    db.SaveChanges();

                    for (int i = 0; i < selectroles.Length; i++)
                    {
                        string temp = selectroles[i];
                        Credential article = new Credential();
                        article.RoleId = temp;
                        article.UserId = user.Id;
                        db.Credentials.Add(article);
                    }
                    db.SaveChanges();
                }
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }

        public List<User> ListAllPaging()
        {
            var model = db.Users;
            return model.OrderByDescending(x => x.CreatedDate).ToList();
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }
        public User ViewDetail(long id)
        {
            return db.Users.Find(id);
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.Username == userName);
            var data = (from a in db.Credentials
                        join b in db.Users on a.UserId equals b.Id
                        join c in db.Roles on a.RoleId equals c.Id
                        select new
                        {
                            RoleID = a.RoleId,
                            UserID = a.UserId
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleId = x.RoleID,
                            UserId = x.UserID
                        });
            return data.Select(x => x.RoleId).ToList();

        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.BOSS_GROUP || result.GroupID == CommonConstants.MEMBER_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.Username == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}