using EggStore.Domains.Eggs.Entities;
using EggStore.Domains.Packages.Entities;
using EggStore.Domains.TransactionItems.Entities;
using EggStore.Domains.Transactions.Entities;
using EggStore.Domains.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace EggStore.Infrastucture.Shareds.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UsersEntity> UsersEntities { get; set; }
        public DbSet<PackagesEntity> PackagesEntities { get; set; }
        public DbSet<EggsEntity> EggsEntities { get; set; }
        public DbSet<TransactionsEntity> TransactionsEntities { get; set; }
        public DbSet<TransactionItemsEntity> TransactionItemsEntities { get; set; }

    }
}