using AzmonNew.Domain.Entities.Questions;
using AzmonNew.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AzmonNew.Application.Interface.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<Question> Questions { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<QuestionImage> QuestionImages { get; set; }
        DbSet<QuestionOption> QuestionOptions { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<QuestionPacks> QuestionPacks { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangeAsync(bool acceptAllChangesOnSuccessl, CancellationToken cancellation = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationtoken = new CancellationToken());
    }
}
