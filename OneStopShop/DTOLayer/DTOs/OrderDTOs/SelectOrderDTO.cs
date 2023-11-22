using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.OrderDTOs
{
    public class SelectOrderDTO
    {
        public int OrderId { get; set; }



        //Product
        public int CartId { get; set; }


        //User
        public int UserId { get; set; }
    }
}
