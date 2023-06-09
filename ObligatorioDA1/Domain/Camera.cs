using System;

namespace Domain
{
    public abstract class Camera
    {
        protected Vector _cornerLowerLeft;
        protected Vector _horizontal;
        protected Vector _vertical;
  

        public Vector LookFrom { get; set; } = new Vector { X = 0, Y = 2, Z = 0 };
        public Vector LookAt { get; set; } = new Vector { X = 0, Y = 2, Z = 5 };
        public int FieldOfView { get; set; } = 30;
        public Vector Up { get; } = new Vector { X = 0, Y = 1, Z = 0 };
        public double AspectRatio { get; set; } = 3d / 2d;
        public double Aperture { get; set; } = 0.5;
        public abstract Ray GetRay(decimal u, decimal v);

    }
}