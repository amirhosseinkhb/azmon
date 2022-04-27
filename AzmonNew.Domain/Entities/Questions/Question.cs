using AzmonNew.Domain.Entities.Commons;
using System.Collections.Generic;

namespace AzmonNew.Domain.Entities.Questions
{
    public class Question : BaseEntity
    {

        public string QuestionText { get; set; }
        public virtual Category Category { get; set; }
        public int level { get; set; }
        public virtual ICollection<QuestionOption> Options { get; set; }
        public virtual ICollection<QuestionImage> QuestionImages { get; set; }

    }
}
