using Microsoft.EntityFrameworkCore;
using TraversalAPI.DAL.Entities;

namespace TraversalAPI.DataAccessLayer.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = (localdb)\\MSSQLLocalDB;initial catalog=TraversalAPIDB;integrated security=true;");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
