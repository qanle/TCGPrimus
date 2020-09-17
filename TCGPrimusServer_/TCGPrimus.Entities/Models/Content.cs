using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCGPrimus.Entities.Models
{
    [Table("content")]
    public class Content
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int FolderId { get; set; }
    }
}
