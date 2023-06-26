using MiniProject.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace MiniProject.DAL.Contexts
{
    public class MiniProjectContext : DbContext
    {
        public MiniProjectContext(DbContextOptions<MiniProjectContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons{ get; set; }
        public DbSet<SocialAccounts> SocialAccounts{ get; set; }
        public DbSet<SocialSkills> SocialSkills{ get; set; }
    }
}
