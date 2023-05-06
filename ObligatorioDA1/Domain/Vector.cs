namespace Domain
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector Add(Vector vector2)
        {
            return new Vector()
            {
                X = X + vector2.X,
                Y = Y + vector2.Y,
                Z = Z + vector2.Z
            };
        }
    }
}