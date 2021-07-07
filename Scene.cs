using System.Collections.Generic;
using OpenTK.Mathematics;

namespace raytracer
{
    class Scene
    {
        List<Intersectable> objects = new List<Intersectable>();
        public Scene()
        {
            objects.Add(new Sphere(new Vector3(5, 1, 0), new Vector3(0, 1, 0), 0.3f));
            objects.Add(new Sphere(new Vector3(3, 1, 2), new Vector3(0, 1, 1), 0.3f));
            objects.Add(new Sphere(new Vector3(4, 1, -2), new Vector3(1, 1, 0), 0.2f));
            objects.Add(new Sphere(new Vector3(4, 0.2f, 1), new Vector3(1, 0.5f, 0), 0.5f));
            objects.Add(new Plane(0, new Vector3(1, 1, 1)));
        }

        public Intersection FindClosestIntersection(Ray r)
        {
            Intersection closest_intersection = null;
            foreach (Intersectable s in objects)
            {
                float t = s.Intersects(r);
                if (t <= 0) continue;
                if (closest_intersection == null)
                {
                    closest_intersection = new Intersection(t, s);
                }
                else if (t < closest_intersection.t)
                {
                    closest_intersection.t = t;
                    closest_intersection.intersectable = s;
                }
            }
            return closest_intersection;
        }
    }
}