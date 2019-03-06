using Microsoft.EntityFrameworkCore;
using VocaPower.Domain.LookUp;

namespace VocaPower.Application.Interface
{
    public interface IDatabaseService
    {
        DbSet<LookUpHistory> LookUpHistories { get; set; }

        int SaveChanges();
    }
}