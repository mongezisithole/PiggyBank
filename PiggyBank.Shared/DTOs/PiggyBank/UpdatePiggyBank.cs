using System;
using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Shared.DTOs.PiggyBank
{
    public class UpdatePiggyBank
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
