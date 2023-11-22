using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Discount_percent { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }

        //Product
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
