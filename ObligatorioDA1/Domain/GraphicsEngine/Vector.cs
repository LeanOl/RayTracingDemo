using System;

namespace Domain.GraphicsEngine
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

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

        public Vector Multiply(double multiplicand)
        {
            Vector resultVector = new Vector
            {
                X = X * multiplicand,
                Y = Y * multiplicand,
                Z = Z * multiplicand
            };
            return resultVector;
        }

        public Vector Divide(double divisor)
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

        public double SquaredLength()
        {
            return X * X + Y * Y + Z * Z;
        }

        public double Length()
        {
            return System.Math.Sqrt(SquaredLength());
        }

        public Vector Unit()
        {
            return Length() != 0 ? Divide(Length()) : new Vector{ X = 0, Y = 0, Z = 0 };
        }

        public double DotProduct(Vector vector2)
        {
            return X * vector2.X + Y * vector2.Y + Z * vector2.Z;
        }

        public Vector CrossProduct(Vector vector2)
        {
            double x = Y * vector2.Z - Z * vector2.Y;
            double y = Z * vector2.X - X * vector2.Z;
            double z = X * vector2.Y - Y * vector2.X;
            return new Vector
            {
                X = x,
                Y = y,
                Z = z
            };
        }

        public static Vector RandomInUnitSphere(Random randomGenerator)
        {
            
            Vector randomVector;
            do
            {
                Vector tempVector = new Vector
                {
                    X = randomGenerator.NextDouble(),
                    Y = randomGenerator.NextDouble(),
                    Z = randomGenerator.NextDouble()
                };
                randomVector = tempVector.Multiply(2).Subtract(new Vector { X = 1, Y = 1, Z = 1 });
            } while (randomVector.SquaredLength() >= 1);


            return randomVector;
        }

        private void Negate()
        {
            X = X * (-1);
            Y = Y * (-1);
            Z = Z * (-1);

        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}