using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCG.Models
{
    [Table("workflow")]
    public class Workflow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string ActivitySettings { get; set; }

        public virtual Folder Folder { get; set; }
        public virtual Content Content { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
