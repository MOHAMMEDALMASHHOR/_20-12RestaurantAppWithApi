using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Dbcontexts;
public class RepositoryDbContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasMany(c=>c.Items)
        .WithOne(i=>i.Categories)
        .HasForeignKey(i=>i.CategoryId)
        .IsRequired();
        //We Can do this as well:
        /* modelBuilder.Entity<Items>()
        .HasOne(i=>i.Categories)
        .WithMany(c=>c.Items)
        .HasForeignKey(i=>i.CategoryId).IsRequired(); */
        modelBuilder.Entity<User>().HasData(
            new User(){
                Id=1,//it can't be zero!!!
                Username="Mohamemd",
                Email="mmalshhor@gmail.com",
                Password="12345"
            }
        );
        modelBuilder.Entity<Category>().HasData(
            new Category(){
                Id=1,
                Name="Soups",
                 /* Items= new List<Items>(){//you can ethir add it or not!!!
                    new Items(){
                        Id=1
                    } 
                } */
            }
        );
    }
}