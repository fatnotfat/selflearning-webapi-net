using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("Category")]
    public class Category
    {

        [Key]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set;}
    }
}
