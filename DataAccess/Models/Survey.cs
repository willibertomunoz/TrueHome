using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }

        [Column(TypeName = "json")]
        public string JSON { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
