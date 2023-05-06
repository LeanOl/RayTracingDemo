namespace Domain
{
    public class Camera
    {
        public Vector LookFrom { get; set; }
        public Vector LookAt { get; set; }
        public Vector Up { get; set; }
        public int FieldOfView { get; set; }
        public int AspectRatio { get; set; }
    }
}