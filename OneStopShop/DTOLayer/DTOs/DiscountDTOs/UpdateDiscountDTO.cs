using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.DiscountDTOs
{
    public class UpdateDiscountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Discount_percent { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
    }
}
