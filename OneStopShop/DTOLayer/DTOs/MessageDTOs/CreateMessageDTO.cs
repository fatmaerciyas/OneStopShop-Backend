using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MessageDTOs
{
    public class CreateMessageDTO
    {
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
     
    }
}
