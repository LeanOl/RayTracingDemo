namespace Domain
{
    public class Ray
    {
        public Vector Origin { get; set; }
        public Vector Direction { get; set; }

        public Vector PointAt(decimal t)
        {
            Vector resultVector = new Vector
            {
                X = Origin.X + t * Direction.X,
                Y = Origin.Y + t * Direction.Y,
                Z = Origin.Z + t * Direction.Z
            };
            return resultVector;
        }
    }
}