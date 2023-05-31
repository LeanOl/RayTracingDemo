namespace Domain
{
    public class Metallic:Material
    {
        public decimal Roughness { get; set; }
        public override Ray Scatter(HitRecord hitRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}