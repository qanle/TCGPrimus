using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCG.Models
{
    [Table("account")]
    public class Account
    {
        [Key]
        [Column("AccountId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string AccountType { get; set; }

        [Required(ErrorMessage = "Owner Id is required")]
        public Guid OwnerId { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
