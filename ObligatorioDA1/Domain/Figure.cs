using System;

namespace Domain
{
    public abstract class Figure
    {
        public Client Propietary { get; set; }
        public string Name { get; set; }

        public abstract HitRecord Hit(Ray aRay, decimal tMin, decimal tMax, Vector center);
    }
}