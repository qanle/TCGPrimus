using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCG.Models
{
    [Table("workflow")]
    public class WorkFlow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        //[Required]
        //public int FolderId { get; set; }
        //[Required]
        //public int ContentId { get; set; }
        //[Required]
        //public int ActivityId { get; set; }
        /// <summary>
        /// Data of Activity Fields setup
        /// </summary>
        public string ActivitySettings { get; set; }

        public virtual Folder Folder { get; set; }
        public virtual Content Content { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
