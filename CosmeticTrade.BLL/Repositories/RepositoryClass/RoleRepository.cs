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
    public class RoleRepository : IRepository<Role>
    {
        DataContext db = DbTool.DbInstance;
        public bool AddOrUpdate(Role entity)
        {

            if (entity == null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.Roles.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(Role entity)
        {
            if (entity == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var role = db.Roles.Find(entity.Id);
                role.IsDeleted = true;
                return this.AddOrUpdate(role);
            }
        }

        public List<Role> SelectAll()
        {
            return db.Roles.Where(i => i.IsDeleted == false).ToList();

        }

        public Role SelectById(int Id)
        {
            return db.Roles.Where(i => i.IsDeleted == false && i.Id == Id).FirstOrDefault();

        }
    }
}
