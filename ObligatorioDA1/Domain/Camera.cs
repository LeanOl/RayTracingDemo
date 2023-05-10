using System;
using System.ComponentModel;
using System.Linq;

namespace Domain
{
    public class Camera
    {
        private Vector _cornerLowerLeft;
        private Vector _horizontal;
        private Vector _vertical;

        public Vector LookFrom { get; set; }
        public Vector LookAt { get; set; }
        public Vector Up { get; set; }
        public int FieldOfView { get; set; }
        public double AspectRatio { get; set; }

        public Camera(Vector lookAt,Vector lookFrom,Vector up,int fieldOfView,double aspectRatio)
        {
            LookAt = lookAt;
            LookFrom = lookFrom;
            Up = up;
            FieldOfView = fieldOfView;
            AspectRatio = aspectRatio;
            decimal theta = FieldOfView * (decimal)Math.PI / 180;
            decimal heightHalf = (decimal)Math.Tan((double)theta / 2);
            decimal widthHalf = (decimal)AspectRatio * heightHalf;
            Vector vectorW = LookFrom.Subtract(LookAt).Unit();
            Vector vectorU = Up.CrossProduct(vectorW).Unit();
            Vector vectorV = vectorW.CrossProduct(vectorU);
            _cornerLowerLeft = LookFrom.Subtract(vectorU.Multiply(widthHalf)).Subtract(vectorV.Multiply(heightHalf)).Subtract(vectorW);
            _horizontal = vectorU.Multiply(2 * widthHalf);
            _vertical = vectorV.Multiply(2 * heightHalf);
        }
        public Camera(Vector lookAt,Vector lookFrom,int fieldOfView)
        {
            LookAt = lookAt;
            LookFrom = lookFrom;
            Up = new Vector { X = 0, Y = 1, Z = 0 };
            FieldOfView = fieldOfView;
            AspectRatio = 3d / 2d;
            decimal theta = FieldOfView * (decimal)Math.PI / 180;
            decimal heightHalf = (decimal)Math.Tan((double)theta / 2);
            decimal widthHalf = (decimal)AspectRatio * heightHalf;
            Vector vectorW = LookFrom.Subtract(LookAt).Unit();
            Vector vectorU = Up.CrossProduct(vectorW).Unit();
            Vector vectorV = vectorW.CrossProduct(vectorU);
            _cornerLowerLeft = LookFrom.Subtract(vectorU.Multiply(widthHalf)).Subtract(vectorV.Multiply(heightHalf)).Subtract(vectorW);
            _horizontal = vectorU.Multiply(2 * widthHalf);
            _vertical = vectorV.Multiply(2 * heightHalf);
        }
        public Camera()
        {
            LookAt = new Vector{X=0,Y=2,Z=5};
            LookFrom = new Vector{X=0,Y=2,Z=0};
            Up = new Vector{X=0,Y=1,Z=0};
            FieldOfView = 30;
            AspectRatio = 3d/2d;
            decimal theta = FieldOfView * (decimal)Math.PI / 180;
            decimal heightHalf = (decimal)Math.Tan((double)theta / 2);
            decimal widthHalf = (decimal)AspectRatio * heightHalf;
            Vector vectorW = LookFrom.Subtract(LookAt).Unit();
            Vector vectorU = Up.CrossProduct(vectorW).Unit();
            Vector vectorV = vectorW.CrossProduct(vectorU);
            _cornerLowerLeft = LookFrom.Subtract(vectorU.Multiply(widthHalf)).Subtract(vectorV.Multiply(heightHalf)).Subtract(vectorW);
            _horizontal = vectorU.Multiply(2 * widthHalf);
            _vertical = vectorV.Multiply(2 * heightHalf);
        }

        public Ray GetRay(decimal u, decimal v)
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