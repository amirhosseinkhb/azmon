using AzmonNew.Domain.Entities.Commons;

namespace AzmonNew.Domain.Entities.Questions
{
    public class QuestionOption : BaseEntity
    {
        public string text { get; set; }
        public bool isTrue { get; set; }
        public virtual Question Question { get; set; }

    }
}
