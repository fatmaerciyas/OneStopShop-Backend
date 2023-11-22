using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class UnitOfWork : IUnitOfWork
    {
        Context context = new Context();
      
        public CartManager cartManager { get; }
        public CategoryManager categoryManager { get; }
        public CommentManager commentManager { get; }
        public DiscountManager discountManager { get; }
        public MessageManager messageManager { get; }
        public NotificationManager notificationManager { get; }
        public OrderManager orderManager { get; }
        public ProductManager productManager { get; }
        public BasketManager basketManager { get; }

        //public UserManager userManager { get; }

        public UnitOfWork()
        {
            cartManager = new CartManager(new EfCartDal(context));
           categoryManager = new CategoryManager(new EfCategoryDal(context));
            discountManager = new DiscountManager(new EfDiscountDal(context));
            messageManager = new MessageManager(new EfMessageDal(context));
            notificationManager = new NotificationManager(new EfNotificationDal(context));
            orderManager = new OrderManager(new EfOrderDal(context));
            productManager = new ProductManager(new EfProductDal(context));
            basketManager = new BasketManager(new EfBasketDal(context));
          //  userManager = new UserManager(new EfUserDal(context));
        
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
