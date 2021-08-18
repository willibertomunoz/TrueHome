using System;

namespace Bussiness.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DisabledAt { get; set; }

        public string Status { get; set; }

        public DataAccess.Models.Property ToPO()
        {
            return new DataAccess.Models.Property()
            {
                Id = Id,
                Status = Bussiness.Enum.Status.Vigente.ToString(),
                DisabledAt = DisabledAt,
                UpdatedAt = UpdatedAt,
                CreatedAt = DateTime.Now,
                Description = Description,
                Address = Address
            };
        }
    }
}
