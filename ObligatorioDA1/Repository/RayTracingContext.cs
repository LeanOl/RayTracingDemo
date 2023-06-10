using System.Data.Entity;
using System.Drawing;
using System.Reflection.Emit;
using Domain;

namespace Repository
{
    public class RayTracingContext : DbContext
    {
        public RayTracingContext() : base()
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Figure> Figures { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        
        
    }

}