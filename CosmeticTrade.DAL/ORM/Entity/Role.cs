using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class Role : BaseEntity
    {
        public Role()
        {
            this.User = new HashSet<User>();
        }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }

    }
}
