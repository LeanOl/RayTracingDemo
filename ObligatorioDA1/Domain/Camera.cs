using System;

namespace Domain
{
    public class Camera
    {
        private Vector _cornerLowerLeft;
        private Vector _horizontal;
        private Vector _vertical;
  

        public Vector LookFrom { get; set; } = new Vector { X = 0, Y = 2, Z = 0 };
        public Vector LookAt { get; set; } = new Vector { X = 0, Y = 2, Z = 5 };
        public int FieldOfView { get; set; } = 30;
        public Vector Up { get; } = new Vector { X = 0, Y = 1, Z = 0 };
        public double AspectRatio { get; set; } = 3d / 2d;

        public double Aperture { get; set; } = 0.5;

        private void CalculateValues()
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

        public Ray GetRay(decimal u, decimal v)
        {
            CalculateValues();
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