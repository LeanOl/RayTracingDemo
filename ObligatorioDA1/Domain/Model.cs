using System.Drawing;

namespace Domain
{
    public class Model
    {
        public Client Proprietary { get; set; }
        public string Name { get; set; }
        public Figure Figure { get; set; }
        public Material Material { get; set; }
        public Image Preview { get; set; }
    }
}