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
    public class CommentaryRepository : IRepository<Commentary>
    {
        DataContext db = DbTool.DbInstance;
        public bool AddOrUpdate(Commentary entity)
        {
            if (entity == null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.Commentaries.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(Commentary entity)
        {
            if (entity == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var commentary = db.Commentaries.Find(entity.Id);
                commentary.IsDeleted = true;
                return this.AddOrUpdate(commentary);
            }
        }

        public List<Commentary> SelectAll()
        {
            return db.Commentaries.Where(i => i.IsDeleted == false).ToList();
        }

        public Commentary SelectById(int Id)
        {
            return db.Commentaries.Where(i => i.IsDeleted == false && i.Id == Id).FirstOrDefault();
        }
    }
}
