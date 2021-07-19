using Microsoft.EntityFrameworkCore;
using BlazorRVAPI.Models.Checklist;
using BlazorRVAPI.Models.Inventory;
using BlazorRVAPI.Models.Expense;

namespace BlazorRVAPI.Data
{
    public class BlazorRvApiContext : DbContext
    {
        public BlazorRvApiContext(DbContextOptions opt) : base(opt)
        {

        }

        // set up the map down to the db
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Expense> Expenses { get; set; }


        // override modelbuilder so EntityFramework uses expliclty these insturcutions
        // for understanding how the tables are related
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Checklist>()
                .HasMany(c => c.ChecklistItems)
                .WithOne(c => c.Checklist!)
                .HasForeignKey(c => c.ChecklistId);

            modelBuilder
                .Entity<ChecklistItem>()
                .HasOne(p => p.Checklist)
                .WithMany(p => p.ChecklistItems)
                .HasForeignKey(p => p.ChecklistId);
        }
    }
}