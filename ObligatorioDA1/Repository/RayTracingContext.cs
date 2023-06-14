using System.Data.Entity;
using Domain;
using Domain.GraphicsEngine;

namespace Repository
{
    public class RayTracingContext : DbContext
    {
        public RayTracingContext() : base()
        {
            
        }

        public static RayTracingContext Instance { get; }= new RayTracingContext();
        public DbSet<Client> Clients { get; set; }
        public DbSet<Figure> Figures { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        
        
    }

}