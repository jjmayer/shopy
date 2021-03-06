﻿using Shopy.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.DataAccess
{
    public class ShopyContext : DbContext
    {
        static ShopyContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public ShopyContext() : base("Data Source=JAKOB-PC-WIN7\\SQLEXPRESS;Initial Catalog=Shopy;Integrated Security=False;User ID=Shopy;Password=Shopy")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ShopingList> ShopingLists { get; set; }
        public virtual DbSet<ShopingItem> ShopingItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ShopingList>()
                .HasOptional(x => x.PriorShopingList)
                    .WithOptionalPrincipal(x => x.ChildShoppingList)
                    .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return this.SaveChanges(generateId: true);
        }

        public int SaveChanges(bool generateId = true)
        {
            UpdateChangeTimes(generateId);
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            UpdateChangeTimes();
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            UpdateChangeTimes();
            return base.SaveChangesAsync(cancellationToken);
        }

        public void UpdateChangeTimes(bool generateId=true)
        {
            var modifiedEntries = from entry in ChangeTracker.Entries()
                                  where entry.Entity is Entity.Entity
                                     && (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                                  select entry;

            foreach (var entry in modifiedEntries)
            {
                Entity.Entity entity = entry.Entity as Entity.Entity;
                if (entity != null)
                {
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        if(generateId)
                            entity.Id = Guid.NewGuid().ToString().Replace("-", "");
                        entity.CreatedAt = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    }

                    entity.UpdatedAt = now;
                }
            }
        }
    }
}
