using System.Data.Entity;
using System.Drawing;
using System.Reflection.Emit;
using Domain;

namespace Repository
{
    public class RayTracingContext : DbContext
    {
        public RayTracingContext() :base()
        {

        }
        public DbSet<Client> Clients { get; set; }



    }

}