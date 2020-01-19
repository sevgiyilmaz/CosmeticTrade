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
   public class ImageRepository : IRepository<Image>
    {
        DataContext db=DbTool.DbInstance;
        public bool AddOrUpdate(Image entity)
        {
            if (entity == null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.Images.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(Image entity)
        {
            if (entity == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var image = db.Images.Find(entity.Id);
                image.IsDeleted = true;
                return this.AddOrUpdate(image);
            }
        }

        public List<Image> SelectAll()
        {
            return db.Images.Where(i => i.IsDeleted == false).ToList();
        }

        public Image SelectById(int Id)
        {
            return db.Images.Where(i => i.IsDeleted == false && i.Id == Id).FirstOrDefault();
        }
    }
}
