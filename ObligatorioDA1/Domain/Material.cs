using System.Drawing;

namespace Domain
{
    public abstract class Material
    {
        public Client Owner { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}