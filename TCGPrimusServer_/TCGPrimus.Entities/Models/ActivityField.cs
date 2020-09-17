using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCGPrimus.Entities.Models
{
    [Table("activityfield")]
    public class ActivityField
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string DataType { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public bool Required { get; set; }
        public int ActivityId { get; set; }
    }
}
