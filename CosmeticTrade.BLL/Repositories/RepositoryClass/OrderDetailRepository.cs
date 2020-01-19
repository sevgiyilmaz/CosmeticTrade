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
    public class OrderDetailRepository : IRepository<OrderDetail>
    {
        DataContext db = DbTool.DbInstance;
        public bool AddOrUpdate(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.OrderDetails.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var orderDetail = db.OrderDetails.Find(entity.Id);
                orderDetail.IsDeleted = true;
                return this.AddOrUpdate(orderDetail);
            }
        }

        public List<OrderDetail> SelectAll()
        {
            return db.OrderDetails.Where(i => i.IsDeleted == false).ToList();
        }

        public OrderDetail SelectById(int Id)
        {
            return db.OrderDetails.Where(i => i.IsDeleted == false && i.Id == Id).FirstOrDefault();
        }
    }
}
