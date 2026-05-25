using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Shared.DTOs.PiggyBank
{
    public class CreatePiggyBank
    {
        [Required]
        public string Name { get; set; }
    }
}
