using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public DateTime Created_at { get; set; }
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        public string Brand { get; set; } = "";
        public int Quantity { get; set; } = 1;

        //Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

      

        //Cart
        //public int? CartId { get; set; } = null;
        //public Cart? Cart { get; set; } = null;


        ////Cart
        //public ICollection<ProductCart> ProductCarts { get; set; }
        ////Category
        //public ICollection<ProductCategory> ProductCategories { get; set; }

        ////Comment
        //public ICollection<Comment> Comments { get; set; }

    }
}
