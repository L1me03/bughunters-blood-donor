using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacijaDonorApp2.Models
{
    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DonorId { get; set; } // samo ID — nema navigacije

        public DateTime DonationDate { get; set; }

        public string Location { get; set; }

        public string? Notes { get; set; }

        public string Hospital { get; set; }
    }
}
