using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCG.Models
{
    [Table("activityfield")]
    public class ActivityField
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Label { get; set; }
        [StringLength(50)]
        public string DataType { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        [Column(TypeName = "bit")]
        public bool Required { get; set; }
        //public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
