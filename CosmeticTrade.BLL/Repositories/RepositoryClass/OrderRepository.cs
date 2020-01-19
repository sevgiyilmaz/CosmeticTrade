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
    public class OrderRepository : IRepository<Order>
    {
        DataContext db = DbTool.DbInstance;
        public bool AddOrUpdate(Order entity)
        {
            if (entity == null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.Orders.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(Order entity)
        {
            if (entity == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var order = db.Orders.Find(entity.Id);
                order.IsDeleted = true;
                return this.AddOrUpdate(order);
            }
        }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var order = db.Orders.Find(id);
                if (order == null) throw new Exception("Deleted value is empty.Please,try again...");
                order.IsDeleted = true;
                return this.AddOrUpdate(order);
            }
        }

        public List<Order> SelectAll()
        {
            return db.Orders.Where(i => i.IsDeleted == false).ToList();
        }

        public Order SelectById(int Id)
        {
            return db.Orders.Where(i => i.IsDeleted == false && i.Id == Id).FirstOrDefault();
        }
    }
}
