using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCG.Models
{
    [Table("folder")]
    public class Folder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string Name { get; set; }

        //public int FolderId { get; set; }
        [Required]
        public virtual Workflow Workflow { get; set; }
        public virtual List<WorkflowItem> WorkFlows { get; set; }
    }
}
