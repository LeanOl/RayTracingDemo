namespace Domain
{
    public class Vector
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

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

        public Vector Subtract(Vector vector2)
        {
            return new Vector()
            {
                X = X - vector2.X,
                Y = Y - vector2.Y,
                Z = Z - vector2.Z
            };  
        }
    }
}