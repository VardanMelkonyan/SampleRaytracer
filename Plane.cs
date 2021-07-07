using OpenTK.Mathematics;

namespace raytracer
{
	class Plane : Intersectable
	{
		public float y;
		public Vector3 color;
		public Plane(float y, Vector3 color)
		{
			this.y = y;
			this.color = color;
		}

		public float Intersects(Ray ray)
		{
			if (ray.position.Y > y && ray.direction.Y > 0)
			{
				return -1;
			}
			if (ray.position.Y < y && ray.direction.Y < 0)
			{
				return -1;
			}
			return System.MathF.Abs(ray.position.Y / ray.direction.Y);
		}
	}
}