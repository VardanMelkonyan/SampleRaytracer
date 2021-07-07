namespace raytracer
{
    class Intersection
    {
        public Intersectable intersectable;
        public float t;
        public Intersection(float t, Intersectable intersectable)
        {
            this.t = t;
            this.intersectable = intersectable;
        }
    }
}