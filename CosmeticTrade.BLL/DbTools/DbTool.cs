using CosmeticTrade.DAL.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.BLL.DbTools
{
    class DbTool
    {
        private static DataContext _dbInstance;
        public static DataContext DbInstance
        {
            get
            {
                if(_dbInstance == null)
                {
                    _dbInstance = new DataContext();
                }
                return _dbInstance;
            }
        }
    }
}
