using System;

namespace Domain
{
    public class Camera
    {
        private Vector _cornerLowerLeft;
        private Vector _horizontal;
        private Vector _vertical;
        private Vector _lookFrom = new Vector { X = 0, Y = 2, Z = 0 };
        private Vector _lookAt = new Vector { X = 0, Y = 2, Z = 5 };
        private int _fieldOfView = 30;

        public Vector LookFrom {
            get => _lookFrom;
            set
            { _lookFrom = value; 
                CalculateValues();
            }
        }

        public Vector LookAt
        {
            get => _lookAt;
            set
            {
                _lookAt = value;
                CalculateValues();
            }
        }
        public int FieldOfView { 
            get => _fieldOfView;
            set
            {
                _fieldOfView = value;
                CalculateValues();
            }
        }
        public Vector Up { get; } = new Vector { X = 0, Y = 1, Z = 0 };
        public double AspectRatio { get;} = 3d / 2d;

        public Camera(Vector lookAt,Vector lookFrom,Vector up,int fieldOfView,double aspectRatio)
        {
            LookAt = lookAt;
            LookFrom = lookFrom;
            Up = up;
            FieldOfView = fieldOfView;
            AspectRatio = aspectRatio;
            CalculateValues();
        }
        public Camera()
        {
            CalculateValues();
        }

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