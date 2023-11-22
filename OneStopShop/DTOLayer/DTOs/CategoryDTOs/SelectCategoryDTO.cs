using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CategoryDTOs
{
    public class SelectCategoryDTO
    {
        [Required(ErrorMessage = "Please enter the category name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the category description")]
        public string Description { get; set; }
    
    }
}
