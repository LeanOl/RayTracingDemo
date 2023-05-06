namespace Domain
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector Add(Vector vectorToAdd)
        {
            Vector resultVector = new Vector()
            {
                X = X + vectorToAdd.X,
                Y = Y + vectorToAdd.Y,
                Z = Z + vectorToAdd.Z
            };
            return resultVector;
        }
    }
}