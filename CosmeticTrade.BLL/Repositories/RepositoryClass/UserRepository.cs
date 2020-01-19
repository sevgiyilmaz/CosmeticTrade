using CosmeticTrade.BLL.DbTools;
using CosmeticTrade.BLL.Repositories.Interface;
using CosmeticTrade.DAL.ORM.Context;
using CosmeticTrade.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.BLL.Repositories.RepositoryClass
{
    public class UserRepository : IRepository<User>
    {
        DataContext db = DbTool.DbInstance;
        public bool AddOrUpdate(User entity)
        {
            if (entity == null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.Users.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(User entity)
        {
            if (entity == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var user = db.Users.Find(entity.Id);
                user.IsDeleted = true;
                return this.AddOrUpdate(user);
            }
        }

        public List<User> SelectAll()
        {
            return db.Users.Where(i => i.IsDeleted == false).ToList();
        }

        public User SelectById(int Id)
        {
            return db.Users.Where(i => i.IsDeleted == false && i.Id == Id).FirstOrDefault();
        }

        public string UserCheck(string userName, string password)
        {
            var user = SelectAll().FirstOrDefault(i => i.Username == userName && i.Password == password);
            if (user == null) return null;
            return user.Username;
        }

        public void ActivateUser(string UserName)
        {
            var user = db.Users.Where(i => i.Name == UserName && i.IsLocked && i.IsDeleted == false).FirstOrDefault();
            user.IsDeleted = false;
            AddOrUpdate(user);
        }

        public string[] RolesByUserName(string userName)
        {
            var user = SelectAll().FirstOrDefault(x => x.Username == userName);
            var roles = new string[user.Roles.Count()];
            int i = 0;
            foreach (var role in user.Roles)
            {
                roles[i] = role.Name;
                i++;
            }
            return roles;
        }

        public bool CheckUserName(string userName)
        {
            string wordlower = userName.ToLower();
            if (SelectAll().Any(i => i.Username.ToLower() == wordlower))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEmail(string email)
        {
            if (SelectAll().Any(i=>i.Email==email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
