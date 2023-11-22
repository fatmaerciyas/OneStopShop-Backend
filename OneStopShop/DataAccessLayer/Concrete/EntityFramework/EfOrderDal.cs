using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(Context context) : base(context)
        {
        }

       

        public List<Order> GetOrderRelationships()
        {
            using (var c = new Context())
            {
                return c.Orders.Include(x => x.Basket)
                    .ToList();

                //.Include(x => x.User)
            }
        }
    }
}
