using System;
using System.Runtime.Serialization;

namespace Bussiness.Models
{
    [DataContract]
    [Serializable]
    public class Activity
    {
        [DataMember]
        public int Id { get; set; }

        public int PropertyId { get; set; }

        [DataMember]
        public DateTime Schedule { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Condicion { get; set; }
        [DataMember]
        public string SurveyLink { get; set; }

        public DataAccess.Models.Activity ToPO()
        {
            return new DataAccess.Models.Activity()
            {
                Id = Id,
                PropertyId = PropertyId,
                Schedule = Schedule,
                Title = Title,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt,
                Status = Status
            };
        }
    }
}
