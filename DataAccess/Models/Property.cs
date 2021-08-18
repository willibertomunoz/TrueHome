using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DisabledAt { get; set; }

        public string Status { get; set; }
    }
}
