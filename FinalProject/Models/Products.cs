using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string SizeS { get; set; }
        public string SizeM { get; set; }
        public string SizeL { get; set; }
        public string SizeXL { get; set; }
        public string SizeXXL { get; set; }
        [Range(1,int.MaxValue)]
        [Required]
        public double Price { get; set; }
        public string Image { get; set; }
        [Display(Name = "Brand Type")]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brands Brands { get; set; }
    }
}
