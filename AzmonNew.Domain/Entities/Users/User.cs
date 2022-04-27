using AzmonNew.Domain.Entities.Commons;
using AzmonNew.Domain.Entities.Questions;
using System.Collections.Generic;

namespace AzmonNew.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long NationalCode { get; set; }
        public virtual ICollection<QuestionPacks> Packs { get; set; }
    }
}
