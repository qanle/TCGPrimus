using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCGPrimus.Entities.Models
{

    [Table("activity")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
