using System;
using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Data.Entities
{
    public class PiggyBank : EntityBase
    {
        public PiggyBank() { }

        public PiggyBank(string name)
            : base()
        {
            Name = name;
        }

        [Required]
        public string Name { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public void Delete()
        {
            DeletedDate = DateTime.UtcNow;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
