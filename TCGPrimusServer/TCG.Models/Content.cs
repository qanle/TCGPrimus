using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCG.Models
{
    [Table("content")]
    public class Content
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string Name { get; set; }

        //public int FolderId { get; set; }
        public virtual Folder Folder { get; set; }
        public virtual List<WorkFlow> WorkFlows { get; set; }
    }
}
