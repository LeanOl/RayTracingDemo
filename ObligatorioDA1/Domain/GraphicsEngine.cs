using System;

namespace Domain
{
    public class GraphicsEngine
    {
        private int _resolution = 300;
        private int _samplesPerPixel=50;
        private int _maxDepth=20;

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


        public int SamplesPerPixel
        {
            get=>_samplesPerPixel;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                _samplesPerPixel = value;
            }
        }

        public int MaxDepth
        {
            get=>_maxDepth;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                _maxDepth = value;
            }
        }
    }
}