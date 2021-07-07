using OpenTK.Mathematics;

namespace raytracer
{
	class Sphere : Intersectable
	{
		public Vector3 center, color;
		public float radius;

		public Sphere(Vector3 center, Vector3 color, float radius)
		{
			this.center = center;
			this.color = color;
			this.radius = radius;
		}

		public float Intersects(Ray ray)
		{
			var q = ray.position - this.center;
			float c = Vector3.Dot(q, q) - this.radius * this.radius;
			float b = 2 * Vector3.Dot(q, ray.direction);
			float a = Vector3.Dot(ray.direction, ray.direction);
			float d = b * b - 4 * a * c;
			if (d < 0)
			{
				return -1;
			}
			if (d == 0)
			{
				return -b / (2 * a * c);
			}
			else
			{
				float x1 = (-b + System.MathF.Sqrt(d)) / (2 * a);
				float x2 = (-b - System.MathF.Sqrt(d)) / (2 * a);
				if (x1 < x2 && x1 > 0)
				{
					return x1;
				}
				else
				{
					return x2;
				}
			}
		}

	}
}