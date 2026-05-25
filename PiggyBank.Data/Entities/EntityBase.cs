using System;
using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Data.Entities
{
    //A base class was added to prevent duplicate code
    public class EntityBase
    {
        public EntityBase()
        {
            CreatedDate = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }

        // A Guid as a key was used for security perpuses
        // Because unlike integers it is difficult to guess a guid
        [Key]
        public Guid Id { get; protected set; }

        public DateTime CreatedDate { get; protected set; }
    }
}
