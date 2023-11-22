using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CartItemDTOs
{
    public class CartItemDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }

        public string Brand { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

    }
}
