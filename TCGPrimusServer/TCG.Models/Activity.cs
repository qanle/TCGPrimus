using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCG.Models
{

    [Table("activity")]
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public virtual List<ActivityField> ActivityFields { get; set; }
        public virtual List<WorkFlow> WorkFlows { get; set; }
    }
}
