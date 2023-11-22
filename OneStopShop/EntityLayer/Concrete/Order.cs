using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
      

        //Basket
        public int BasketId { get; set; }
        public Basket Basket { get; set; }

        //User
        //public ApplicationUser User { get; set; }
      
    }
}
