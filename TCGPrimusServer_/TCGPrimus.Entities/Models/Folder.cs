
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCGPrimus.Entities.Models
{
    [Table("folder")]
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int ParentId { get; set; }

    }
}
