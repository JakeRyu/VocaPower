using Microsoft.EntityFrameworkCore;
using VocaPower.Domain.Entity;

namespace VocaPower.Application.Interface
{
    public interface IDatabaseService
    {
        DbSet<LookUpHistory> LookUpHistories { get; set; }

        int SaveChanges();
    }
}