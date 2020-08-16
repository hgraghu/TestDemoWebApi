using System;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
