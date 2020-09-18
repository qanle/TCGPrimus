
using System.Collections.Generic;
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


        public virtual List<Content> Contents { get; set; }
        public virtual List<WorkflowItem> WorkflowItems { get; set; }
    }
}
