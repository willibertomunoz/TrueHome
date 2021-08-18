using System;

namespace Bussiness.Models
{
    public class Survey
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }
        public string JSON { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
