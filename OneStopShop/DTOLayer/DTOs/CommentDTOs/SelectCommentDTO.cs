using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CommentDTOs
{
    public class SelectCommentDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        //User
        public int UserId { get; set; }

        //Product
        public int ProductId { get; set; }
    }
}
