using System;
using System.ComponentModel.DataAnnotations;
using AplikacijaDonorApp2.Models;

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
        public string? Phone { get; set; }

        [Required]
        [MinLength(4)]
        public string? Password { get; set; }

        [MaxLength(50)]
        public string? Location { get; set; }

        [MaxLength(5)]
        public string? BloodGroup { get; set; }

        public DateTime LastDonation { get; set; }

        [Required]
        [MaxLength(20)]
        public string? DonorCardId { get; set; } 
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int TotalDonations { get; set; } = 0;

    }
}
