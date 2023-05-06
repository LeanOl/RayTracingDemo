namespace Domain
{
    public class Vector
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

        public Vector Add(Vector vectorToAdd)
        {
            Vector resultVector = new Vector
            {
                X = X + vectorToAdd.X,
                Y = Y + vectorToAdd.Y,
                Z = Z + vectorToAdd.Z
            };
            return resultVector;
        }

        public Vector Subtract(Vector vectorToSubtract)
        {
            Vector resultVector = new Vector
            {
                X = X - vectorToSubtract.X,
                Y = Y - vectorToSubtract.Y,
                Z = Z - vectorToSubtract.Z
            };
            return resultVector;
        }

        public Vector Multiply(decimal i)
        {
            Vector resultVector = new Vector
            {
                X = X * i,
                Y = Y * i,
                Z = Z * i
            };
            return resultVector;
        }
    }
}