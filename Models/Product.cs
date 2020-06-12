using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easy.Commerce.WebApi.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public string Code { get; set; }

        [Column("ProductName")]
        public string Name { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
