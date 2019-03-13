using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using VocaPower.Persistence;

namespace VocaPower.Application.Tests
{
    public class DatabaseFixture : IDisposable
    {
        readonly AppDbContext _context;

        public DatabaseFixture()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection)
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureCreated();
        }

        public AppDbContext Context => _context;


        public void Dispose()
        {
            _context?.Database?.CloseConnection();
        }
    }
}