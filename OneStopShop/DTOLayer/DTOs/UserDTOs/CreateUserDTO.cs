using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }

        public int IsDelete { get; set; } = 0;// it is not hard delete it's soft delete
    }
}
