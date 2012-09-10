using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Data.Entities;

namespace CalorieCounter.Data
{
    internal class Context : DbContext
    {
        public Context() : base("name=CalorieCounterContext")
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<DailyTarget> DailyTargets { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserWeight> UserWeights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var foodItemEntity = modelBuilder.Entity<FoodItem>();
            foodItemEntity.Property(fi => fi.Name).HasMaxLength(50).IsRequired();
            foodItemEntity.Property(fi => fi.ServingSize).HasMaxLength(100).IsRequired();

            var logEntryFoodItemEntity = modelBuilder.Entity<LogEntryFoodItem>();
            logEntryFoodItemEntity.Property(lefi => lefi.Serving).HasPrecision(3, 1);

            var mealTypeEntity = modelBuilder.Entity<MealType>();
            mealTypeEntity.Property(mt => mt.Name).HasMaxLength(50).IsRequired();

            var userEntity = modelBuilder.Entity<User>();
            userEntity.Property(u => u.Username).HasMaxLength(20).IsRequired();
            userEntity.Property(u => u.Name).HasMaxLength(50).IsRequired();
            userEntity.Property(u => u.Email).HasMaxLength(255).IsRequired();

            var userWeight = modelBuilder.Entity<UserWeight>();
            userWeight.Property(uw => uw.Weight).HasPrecision(4, 1);
        }
    }
}
