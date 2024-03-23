using System.ComponentModel.DataAnnotations;

namespace OrderGenius.Dtos
{
    public class CustomerDto
    {

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string? Street { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(50)]
        public string? State { get; set; }
        [StringLength(5)]
        public string? ZipCode { get; set; }
        [StringLength(20)]
        public string? Email { get; set; }
        [StringLength(11)]
        public string? Phone { get; set; }
    }
}
