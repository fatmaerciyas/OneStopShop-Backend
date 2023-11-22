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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(Context context) : base(context)
        {
        }
        public Basket GetBasketByUserName(string username)
        {
            using (var c = new Context())
            {
                List<Basket> basketList = c.Baskets.Where(x => x.userName == username).ToList();
                return basketList.FirstOrDefault();

                //.Include(x => x.User)
            }
        }
    }
}
