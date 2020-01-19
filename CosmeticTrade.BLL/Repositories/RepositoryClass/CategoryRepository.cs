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
    public class CategoryRepository : IRepository<Category>
    {
        DataContext db = DbTool.DbInstance;
        public bool AddOrUpdate(Category entity)
        {
            if (entity==null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.Categories.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }        

        public bool Delete(Category entity)
        {
            if (entity==null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var category = db.Categories.Find(entity.Id);
                category.IsDeleted = true;
                return this.AddOrUpdate(category);
            }
        }

        public List<Category> SelectAll()
        {
            return db.Categories.Where(i => i.IsDeleted == false).ToList();
        }

        public Category SelectById(int Id)
        {
            return db.Categories.Where(i => i.IsDeleted == false && i.Id == Id).FirstOrDefault();
        }
    
        public Category SelectByName(string name)
        {
            return db.Categories.Where(i => i.Name == name && i.IsDeleted == false).FirstOrDefault();
        }
    }
}
