using AzmonNew.Domain.Entities.Commons;
using System.Collections.Generic;

namespace AzmonNew.Domain.Entities.Questions
{
    public class QuestionPacks : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int QuestionCount { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}