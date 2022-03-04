using DataLayer.DBModels.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer.DBModels.Companies;
using System.Data.SqlClient;

namespace DataLayer.DBModels.DBContexts
{
    public class ContextDB : DbContext
    {
        private readonly User _currentUser = null!;

        public ContextDB()
        {

        }
        public ContextDB(DbContextOptions<DbContext> options, User currentUser)
           : base(options)
        {
            _currentUser = currentUser;
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Company> Comapnies { get; set; } = null!;
        // public DbSet<Loan> Loan { get; set; } = null!;
        // public DbSet<LoanTransaction> LoanTransactions { get; set; } = null!;

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries().ToList();

            foreach (var entrie in entries)
            {
                var entity = ((CoreModel)entrie.Entity);

                if (entity.CreateBy == 0)
                {
                    entity.Status = true;
                    entity.CreateBy = _currentUser.Id;
                    entity.CreatedAt = DateTime.Now;
                }
                else
                {
                    entity.UpdatedBy = _currentUser.Id;
                    entity.CreatedAt = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connection = "Server=localhost;Database=OriontekDB;User Id=sa;Password=reallyStrongPwd123@;";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            SetPrecision(modelBuilder);

            modelBuilder.Entity<Client>().HasQueryFilter(e => e.Status == true && e.CompanyId==_currentUser.CompanyId);
            modelBuilder.Entity<ClientAddress>().HasQueryFilter(e => e.Status == true);

           modelBuilder
            .Entity<ClientAddress>()
            .HasOne(e => e.Client)
            .WithMany(e => e.Addresses)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>().Navigation(x => x.Addresses).AutoInclude();

        }


        public static void SetPrecision(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
        }
    }
}
