using Microsoft.EntityFrameworkCore;
using OASample.Data;
using OASample.Data.Entity;
using OASample.Repo.Mapping;
using System;

namespace OASample.Repo
{
    public class ApplicationContext : DbContext
    {
        private EntityMappingFactory entityMappingFactory;

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        public ApplicationContext(EntityMappingFactory entityMappingFactory, DbContextOptions<ApplicationContext> options) : base(options)
        {
            this.entityMappingFactory = entityMappingFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configure fluent api
            this.entityMappingFactory.CreateMappingFactory<User>().ConfigureModel(modelBuilder.Entity<User>());
            this.entityMappingFactory.CreateMappingFactory<UserProfile>().ConfigureModel(modelBuilder.Entity<UserProfile>());            
        }
    }
}
