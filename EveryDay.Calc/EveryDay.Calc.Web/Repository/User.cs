using EveryDay.Calc.Webcalc.EntitiF;
using EveryDay.Calc.Webcalc.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EveryDay.Calc.Web.Repository
{
    [Table("User")]
    public class User 
    {
        
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FIO { get; set; }

        public UserStatus Status { get; set; }
    }

    public enum UserStatus
    {
        Blocked = 2,
        Active = 1,
        Dead = 0
    }

    public class UserRepository : IUserRepository
    {

        public bool Check(string login, string password)
        {
                User userCheck = null;
                using (CalcContext db = new CalcContext())
                {
                    userCheck = db.User.FirstOrDefault(u => u.Login == login && u.Password == password);
                    if (userCheck != null)
                    {
                        return true;
                    }
                    return false;
                }
        }

        public void Create(User obj)
        {
            using (CalcContext db = new CalcContext())
            {
                db.User.Add(obj);
            }
        }

        public User Read(long Id)
        {
            using (CalcContext db = new CalcContext())
            {
                User user = db.User.FirstOrDefault(u => u.Id == Id);
                    return user;
            }
        }

        public void Update(User obj)
        {
            using (CalcContext db = new CalcContext())
            {
                User user = db.User.FirstOrDefault(u => u.Id == obj.Id);
                if (user != null)
                {
                    user.Login = obj.Login;
                    user.Password = obj.Password;
                    user.FIO = obj.FIO;
                    user.Status = obj.Status;
                }
            }
        }

        public void Delete(long Id)
        {
            using (CalcContext db = new CalcContext())
            {
                User user = db.User.FirstOrDefault(u => u.Id == Id);
                if (user != null)
                {
                    user.Status = 0;
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (CalcContext db = new CalcContext())
            {
                return db.User.ToList();
            }
        }
    }
}