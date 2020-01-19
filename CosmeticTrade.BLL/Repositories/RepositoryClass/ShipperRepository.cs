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
    public class ShipperRepository : IRepository<Shipper>
    {
        DataContext db = DbTool.DbInstance;
        public bool AddOrUpdate(Shipper entity)
        {
            if (entity == null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.Shippers.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(Shipper entity)
        {
            if (entity == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var shipper = db.Shippers.Find(entity.Id);
                shipper.IsDeleted = true;
                return this.AddOrUpdate(shipper);
            }
        }

        public List<Shipper> SelectAll()
        {
            return db.Shippers.Where(i => i.IsDeleted == false).ToList();
        }

        public Shipper SelectById(int Id)
        {
            return db.Shippers.Where(i => i.IsDeleted == false && i.Id == Id).FirstOrDefault();
        }
    }
}
