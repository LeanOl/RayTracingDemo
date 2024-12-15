using System;
using Domain.Utilities;

namespace Domain.GraphicsEngine
{
    public class DefocusCamera : Camera
    {
        private double _lensRadius;
        private double _focalDistance;
        private Vector _vectorU;
        private Vector _vectorV;
        public Random Random { get; set; } = RandomGenerator.RandomInstance;


        public DefocusCamera()
        {
            CalculateValues();
        }
        protected override void CalculateValues()
        {
            _focalDistance = LookFrom.Subtract(LookAt).Length();
            _lensRadius = Aperture / 2;
            double theta = FieldOfView * Math.PI / 180;
            double heightHalf = Math.Tan((double)theta / 2);
            double widthHalf = AspectRatio * heightHalf;
            Vector vectorW = LookFrom.Subtract(LookAt).Unit();
            Vector vectorU = Up.CrossProduct(vectorW).Unit();
            Vector vectorV = vectorW.CrossProduct(vectorU);
            _cornerLowerLeft = LookFrom.Subtract(vectorU.Multiply(widthHalf * _focalDistance))
                .Subtract(vectorV.Multiply(heightHalf * _focalDistance))
                .Subtract(vectorW.Multiply(_focalDistance));
            _horizontal = vectorU.Multiply(2 * widthHalf * _focalDistance);
            _vertical = vectorV.Multiply(2 * heightHalf * _focalDistance);
            _vectorU = vectorU;
            _vectorV = vectorV;
            
        }

        public override Ray GetRay(double u, double v)
        {
            
            Vector randomVector = Vector.RandomInUnitSphere(Random).Multiply(_lensRadius);
            Vector offset = _vectorU.Multiply(randomVector.X).Add(_vectorV.Multiply(randomVector.Y));
            Vector horizontalPosition = _horizontal.Multiply(u);
            Vector verticalPosition = _vertical.Multiply(v);

            return new Ray
            {
                Origin = LookFrom.Add(offset),
                Direction = _cornerLowerLeft.Add(horizontalPosition.Add(verticalPosition)).Subtract(LookFrom).Subtract(offset)
            };
        }
    }
}