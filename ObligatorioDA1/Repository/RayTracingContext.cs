using System.Data.Entity;
using Domain;

namespace Repository
{
    public class RayTracingContext : DbContext
    {
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Figure> Figures { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        
        
    }

}