using System.Drawing;

namespace Domain
{
    public class Material
    {
        public Client Owner { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}