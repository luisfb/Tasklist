using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Tasklist.Infra
{
    public class EntityFrameworkContext : DbContext
    {
        private IDbContextTransaction _transaction;

        public EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityFrameworkContext).GetTypeInfo().Assembly);
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
