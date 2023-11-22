using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        public string userName { get; set; }


        //Cart
        ICollection<Cart> Carts { get; set; }

        //Order
        ICollection<Order> Order { get; set; }

    }
}
