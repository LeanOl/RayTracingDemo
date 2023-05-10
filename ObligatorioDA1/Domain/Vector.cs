using System;

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

        public Vector Multiply(decimal multiplicand)
        {
            Vector resultVector = new Vector
            {
                X = X * multiplicand,
                Y = Y * multiplicand,
                Z = Z * multiplicand
            };
            return resultVector;
        }

        public Vector Divide(decimal divisor)
        {
            Vector resultVector = new Vector
            {
                X = X / divisor,
                Y = Y / divisor,
                Z = Z / divisor
            };
            return resultVector;
        }


        public void AddTo(Vector addedVector)
        {
            X += addedVector.X;
            Y += addedVector.Y;
            Z += addedVector.Z;
        }

        public decimal SquaredLength()
        {
            return X * X + Y * Y + Z * Z;
        }

        public decimal Length()
        {
            return (decimal)System.Math.Sqrt((double)SquaredLength());
        }

        public Vector Unit()
        {
            return Length() != 0 ? Divide(Length()) : new Vector{ X = 0, Y = 0, Z = 0 };
        }

        public decimal DotProduct(Vector vector2)
        {
            return X * vector2.X + Y * vector2.Y + Z * vector2.Z;
        }

        public Vector CrossProduct(Vector vector2)
        {
            decimal x = Y * vector2.Z - Z * vector2.Y;
            decimal y = Z * vector2.X - X * vector2.Z;
            decimal z = X * vector2.Y - Y * vector2.X;
            return new Vector
            {
                X = x,
                Y = y,
                Z = z
            };
        }

        public static Vector RandomInUnitSphere()
        {
            Random randomGenerator= new Random();
            Vector randomVector;
            do
            {
                Vector tempVector = new Vector
                {
                    X = (decimal)randomGenerator.NextDouble(),
                    Y = (decimal)randomGenerator.NextDouble(),
                    Z = (decimal)randomGenerator.NextDouble()

                };
                randomVector = tempVector.Multiply(2).Subtract(new Vector { X = 1, Y = 1, Z = 1 });
            } while (randomVector.SquaredLength() >= 1);
            

            return randomVector;
        }
    }
}