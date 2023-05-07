using System;

namespace Domain
{
    public class GraphicsEngine
    {
        private int _resolution = 300;
        private int _samplesPerPixel;
        private int _maxDepth;

        public int Resolution
        {
            get => _resolution;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                _resolution = value;
            }
        }
    

        public int SamplesPerPixel { get; set; } = 50;
        public int MaxDepth { get; set; } = 20;
    }
}