using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required]
        [Range(0,120)]
        public int Age { get; set; }
    }
}
