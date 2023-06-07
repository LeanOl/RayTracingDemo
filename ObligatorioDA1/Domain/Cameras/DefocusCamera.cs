using System;

namespace Domain
{
    public class DefocusCamera : Camera
    {
        private decimal _lensRadius;
        private decimal _focalDistance;
        private Vector _vectorU;
        private Vector _vectorV;
        public Random RandomGenerator { get; set; } = new Random();

        private void CalculateValues()
        {
            _focalDistance = LookFrom.Subtract(LookAt).Length();
            _lensRadius = (decimal)Aperture / 2;
            decimal theta = FieldOfView * (decimal)Math.PI / 180;
            decimal heightHalf = (decimal)Math.Tan((double)theta / 2);
            decimal widthHalf = (decimal)AspectRatio * heightHalf;
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

        public override Ray GetRay(decimal u, decimal v)
        {
            CalculateValues();
            Vector randomVector = Vector.RandomInUnitSphere(RandomGenerator).Multiply(_lensRadius);
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