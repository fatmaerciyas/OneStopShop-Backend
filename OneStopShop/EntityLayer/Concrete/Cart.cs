using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Cart
    {


        [Key]
        public int CartId { get; set; }
        public int Quantity { get; set; }
     
        //User
       // public ApplicationUser User{ get; set; }


        //Product
        public int ProductId { get; set; }
        public Product Product{ get; set; }

        //Basket
        public int? BasketId { get; set; }
        public Basket Basket { get; set; }


    }
}
