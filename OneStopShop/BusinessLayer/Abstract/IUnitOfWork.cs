using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        BasketManager basketManager { get; }
        CartManager cartManager { get; }
        CategoryManager categoryManager { get; }
        CommentManager commentManager { get; }
        DiscountManager discountManager { get; }
        MessageManager messageManager { get; }
        NotificationManager notificationManager { get; }
        OrderManager orderManager { get; }
        ProductManager productManager { get; }
        //UserManager userManager { get; }

        int Complete();
        void Dispose();
    }
}
