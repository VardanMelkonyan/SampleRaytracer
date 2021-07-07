namespace raytracer
{
    interface Intersectable
    {
        float Intersects(Ray ray);
    }
}