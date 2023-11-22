using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CartDTOs
{
    public class UpdateCartDTO
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }

    }
}
