using System;

namespace Domain.GraphicsEngine
{
    public class NoDefocusCamera : Camera
    {

        public NoDefocusCamera()
        {
            CalculateValues();
        }
        protected override void CalculateValues()
        {
            decimal theta = FieldOfView * (decimal)Math.PI / 180;
            decimal heightHalf = (decimal)Math.Tan((double)theta / 2);
            decimal widthHalf = (decimal)AspectRatio * heightHalf;
            Vector vectorW = LookFrom.Subtract(LookAt).Unit();
            Vector vectorU = Up.CrossProduct(vectorW).Unit();
            Vector vectorV = vectorW.CrossProduct(vectorU);
            _cornerLowerLeft = LookFrom.Subtract(vectorU.Multiply(widthHalf)).Subtract(vectorV.Multiply(heightHalf))
                .Subtract(vectorW);
            _horizontal = vectorU.Multiply(2 * widthHalf);
            _vertical = vectorV.Multiply(2 * heightHalf);
        }

        public override Ray GetRay(decimal u, decimal v)
        {
            
            Vector horizontalPosition = _horizontal.Multiply(u);
            Vector verticalPosition = _vertical.Multiply(v);

            return new Ray
            {
                Origin = LookFrom,
                Direction = _cornerLowerLeft.Add((horizontalPosition).Add(verticalPosition)).Subtract(LookFrom)

            };
        }
    }
}