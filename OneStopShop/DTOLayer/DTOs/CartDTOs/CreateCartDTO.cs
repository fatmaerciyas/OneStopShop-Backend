using DTOLayer.DTOs.CartItemDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CartDTOs
{
    public class CreateCartDTO
    {
      
        public int Id { get; set; }
        public int Quantity { get; set; }

     
        public int ProductId { get; set; }
    }
}
