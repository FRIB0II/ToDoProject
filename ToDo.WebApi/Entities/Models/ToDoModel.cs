using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Entities.Models
{
    public class ToDoModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("DeadLine")]
        public DateTime DeadLine  { get; set; }

        [Column("Category")]
        public string Category { get; set; }
    }
}
