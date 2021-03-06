﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCGPrimus.Entities.Models
{
    [Table("workflow")]
    public class WorkFlow
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FolderId { get; set; }
        public int ContentId { get; set; }

        public int ActivityId { get; set; }
        public string ActivitySettings { get; set; }

    }
}
