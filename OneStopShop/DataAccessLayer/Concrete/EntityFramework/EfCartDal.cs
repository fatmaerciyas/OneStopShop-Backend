using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        public EfCartDal(Context context) : base(context)
        {
        }

        public List<Cart> GetCartProductRelationship()
        {
            using (var c = new Context())
            {
                return c.Carts.Include(x => x.Product).ToList();
            }
        }
    }
}
