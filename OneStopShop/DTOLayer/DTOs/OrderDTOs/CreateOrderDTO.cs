using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {



        //Product
        public int CartId { get; set; }



        //User
        public string UserId { get; set; }
    }
}
