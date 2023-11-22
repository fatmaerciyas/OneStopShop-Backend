using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.OrderDTOs
{
    public class UpdateOrderDTO
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public int IsDelete { get; set; } = 0;// it is not hard delete it's soft delete

        //Product
        public int ProductId { get; set; }

        //User
        public int UserId { get; set; }
    }
}
