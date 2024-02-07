
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MessageBox.Models;


namespace MessageBox.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public DbSet<TopicModel> Topics { get; set; }
    public DbSet<MessageModel> Messages { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
  }
}
