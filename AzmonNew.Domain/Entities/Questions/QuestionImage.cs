using AzmonNew.Domain.Entities.Commons;

namespace AzmonNew.Domain.Entities.Questions
{
    public class QuestionImage : BaseEntity
    {
        public Question Question;
        public string Src { get; set; }

    }
}
