using System;

namespace Domain
{
    public abstract class Camera
    {
        protected Vector _cornerLowerLeft;
        protected Vector _horizontal;
        protected Vector _vertical;

        public Guid CameraId { get; set; }
        private Vector _lookFrom = new Vector { X = 0, Y = 2, Z = 0 };
        public Vector LookFrom
        {
            get => _lookFrom;
            set
            {
                _lookFrom = value;
                CalculateValues();
            }
        }

        private Vector _lookAt = new Vector { X = 0, Y = 2, Z = 5 };
        public Vector LookAt
        {
            get => _lookAt;
            set
            {
                _lookAt = value;
                CalculateValues();
            }
        }

        private int _fieldOfView = 30;
        public int FieldOfView
        {
            get => _fieldOfView;
            set
            {
                _fieldOfView = value;
                CalculateValues();
            }
        }

        private double _aspectRatio = 3d / 2d;
        public double AspectRatio
        {
            get => _aspectRatio;
            set
            {
                _aspectRatio = value;
                CalculateValues();
            }
        }

        private double _aperture = 0.5;
        public double Aperture
        {
            get => _aperture;
            set
            {
                _aperture = value;
                CalculateValues();
            }
        }
        

        public Vector Up { get; } = new Vector { X = 0, Y = 1, Z = 0 };

        protected abstract void CalculateValues();

        public abstract Ray GetRay(decimal u, decimal v);

    }
}