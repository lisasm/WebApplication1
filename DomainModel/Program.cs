using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Program
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
