namespace Domain
{
    public class Ray
    {
        public Vector Origin { get; set; }
        public Vector Direction { get; set; }

        public Vector PointAt(decimal i)
        {
           
            return Origin.Add(Direction.Multiply(i));
        }
    }
}