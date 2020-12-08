using PhanLong.Common;
using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public long Insert(User entity, string[] selectroles)
        {

            entity.Status = true;
            entity.CreatedDate = DateTime.Now;
            entity.Avatar = "/Images/Avatar/default.jpg";
            db.Users.Add(entity);
            db.SaveChanges();
            if (selectroles != null)
            {

                for (int i = 0; i < selectroles.Length; i++)
                {
                    string temp = selectroles[i];
                    Credential article = new Credential();
                    article.RoleId = temp;
                    article.UserId = entity.Id;
                    db.Credentials.Add(article);
                }
                db.SaveChanges();
            }
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

        public bool UpdatePassword(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.Id);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.ModifiedBy = user.Name;
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

        public bool UpdateAvatar(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.Id);
                user.Avatar = entity.Avatar;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }

        public bool UpdateProfile(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.Id);
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Telephone = entity.Telephone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }


        public bool Update(User entity, string[] selectroles)
        {
            try
            {
                var user = db.Users.Find(entity.Id);
                user.Name = entity.Name;

                var remove = db.Credentials.Where(x => x.UserId == user.Id).ToList();
                foreach (var item in remove)
                {
                    db.Credentials.Remove(item);
                }
                db.SaveChanges();

                if (selectroles != null)
                {

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
                user.Telephone = entity.Telephone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                user.GroupID = entity.GroupID;
                user.Status = entity.Status;
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
                        where b.Id == user.Id
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
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {

                if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.BOSS_GROUP)
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
        public bool Delete(long id)
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

        public bool CheckPassword(long id, string passWord)
        {
            return db.Users.Count(x => x.Id == id && x.Password == passWord) > 0;
        }

        public User GetByEmail(string email)
        {
            return db.Users.SingleOrDefault(x => x.Email == email);
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
    }
}