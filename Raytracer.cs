using OpenTK.Mathematics;
using System;

namespace raytracer
{
	class RayTracer
	{
		Surface surface;
		Game window;

		public RayTracer(Surface surface, Game window)
		{
			this.surface = surface;
			this.window = window;
		}

		public void Render()
		{
			Camera camera = new Camera(new Vector3(0, 1, 0), new Vector3(1, 0, 0), (float)(Math.PI / 3), surface.width / (float)surface.height);

			for (int x = 0; x < surface.width; x++)
			{
				for (int y = 0; y < surface.height; y++)
				{
					Ray ray = camera.GetCameraRay((x + 0.5f) / surface.width, (y + 0.5f) / surface.height);
					if (ray.direction.Y < 0)
					{
						float distance = ray.position.Y / -ray.direction.Y;
						Vector3 point = ray.position + distance * ray.direction;
						float color = (float)Math.Sin(point.Z * 3);
						surface.SetPixel(x, y, color, color, color);
						// if ((int)point.Z % 2 == 0)
						// 	surface.SetPixel(x, y, 0.0f, 0f, 0f);
						// else
						// 	surface.SetPixel(x, y, 1.0f, 1f, 1f);
					}
					else
						surface.SetPixel(x, y, 1.0f, 0f, 0f);
				}
			}
		}

	}
}