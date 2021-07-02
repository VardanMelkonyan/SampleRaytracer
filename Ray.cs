using OpenTK.Mathematics;

namespace raytracer
{
	class Ray
	{
		public Vector3 position;
		public Vector3 direction;

		public Ray(Vector3 position, Vector3 direction)
		{
			this.position = position;
			this.direction = direction;
		}

		Vector3 ray(int t)
		{
			return position + (direction * t);
		}
	}
}