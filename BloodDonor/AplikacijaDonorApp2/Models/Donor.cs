using System;
using System.ComponentModel.DataAnnotations;

namespace AplikacijaDonorApp2.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; } // automatski primarni ključ

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(4)]
        public string? Password { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        [MaxLength(5)]
        public string? BloodGroup { get; set; }

        public DateTime LastDonation { get; set; }

        [Required]
        [MaxLength(20)]
        public string? DonorCardId { get; set; } // npr. "DN-****"
    }
}
