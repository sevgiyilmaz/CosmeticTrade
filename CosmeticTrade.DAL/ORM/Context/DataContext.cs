using CosmeticTrade.DAL.ORM.Entity;
using CosmeticTrade.DAL.ORM.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Context
{
    public class DataContext : DbContext
    {

        public DataContext() : base("server=.;database=CTdatabase;uid=sa;pwd=123;")
        {
            Database.SetInitializer(new DataInitializer());
        }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<User> Users { get; set; }    
    }
}
