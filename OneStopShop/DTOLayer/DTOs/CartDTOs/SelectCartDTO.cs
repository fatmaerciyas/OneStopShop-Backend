using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CartDTOs
{
    public class SelectCartDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        //navigation properties
        public int ProductId { get; set; }
        public string Name { get; set; }
      
        public string Description { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
       
        public string Brand { get; set; } 
       

        //Category
        public int CategoryId { get; set; }

    }
}
