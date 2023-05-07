using System;

namespace Domain
{
    public class Camera
    {

        private decimal _theta;
        private decimal _heightHalf;
        private decimal _widthHalf;
        private Vector _vectorW;
        private Vector _vectorU;
        private Vector _vectorV;
        private Vector _cornerLowerLeft;
        private Vector _horizontal;
        private Vector _vertical;

        public Vector LookFrom { get; set; }
        public Vector LookAt { get; set; }
        public Vector Up { get; set; }
        public int FieldOfView { get; set; }
        public int AspectRatio { get; set; }

        public Camera()
        {
            
        }

        public Ray GetRay(int u, int v)
        {
            _theta = FieldOfView * (decimal)Math.PI / 180;
            _heightHalf = (decimal)Math.Tan((double)_theta / 2);
            _widthHalf = AspectRatio * _heightHalf;
            _vectorW = LookFrom.Subtract(LookAt).Unit();
            _vectorU = Up.CrossProduct(_vectorW).Unit();
            _vectorV = _vectorW.CrossProduct(_vectorU);
            _cornerLowerLeft = LookFrom.Subtract(_vectorU.Multiply(_widthHalf)).Subtract(_vectorV.Multiply(_heightHalf)).Subtract(_vectorW);
            _horizontal = _vectorU.Multiply(2 * _widthHalf);
            _vertical = _vectorV.Multiply(2 * _heightHalf);

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