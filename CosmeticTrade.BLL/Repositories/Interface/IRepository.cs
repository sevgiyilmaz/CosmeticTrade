using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.BLL.Repositories.Interface
{
    public interface IRepository<T>where T:class
    {
        /// <summary>
        /// Used for adding and updating.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool AddOrUpdate(T entity);

        /// <summary>
        /// Used for delete.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);      
        
        /// <summary>
        /// Lists IsDeleted=false.
        /// </summary>
        /// <returns></returns>
        List<T> SelectAll();

        /// <summary>
        /// Search by Id and lists undeleted.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T SelectById(int Id);  

        
    }
}
