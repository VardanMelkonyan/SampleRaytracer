using OpenTK.Mathematics;
using System;

namespace raytracer
{
	class RayTracer
	{
		Surface surface;
		Game window;
		Scene scene = new Scene();
		public RayTracer(Surface surface, Game window)
		{
			this.surface = surface;
			this.window = window;
		}

		public void Render()
		{
			Camera camera = new Camera(new Vector3(0, 1, 0), new Vector3(1, 0, 0), (float)(Math.PI / 4), surface.width / (float)surface.height);
			// Vector3 to_light_direction = new Vector3(-1, 1, 0).Normalized();
			Vector3 light_position = new Vector3(4, 3, 0);
			Vector3 light_color = new Vector3(1, 1, 1) * 5;
			Random rnd = new Random();
			int rays = 4;
			Vector3[] colors = new Vector3[16];
			for (int x = 0; x < surface.width; x++)
			{
				for (int y = 0; y < surface.height; y++)
				{
					for (int r_ray = 0; r_ray < rays; r_ray++)
					{
						Ray r = camera.GetCameraRay((x + (float)rnd.NextDouble()) / surface.width, (y + (float)rnd.NextDouble()) / surface.height);
						Intersection intersection = scene.FindClosestIntersection(r);
						if (intersection != null)
						{
							Vector3 intersection_point = r.position + r.direction * intersection.t;
							Vector3 color = Vector3.Zero;
							Vector3 normal = Vector3.UnitY;
							Vector3 to_light = (light_position - intersection_point).Normalized();
							bool hasShadow = false;
							float intensity = 1 / ((light_position - intersection_point).Length * (light_position - intersection_point).Length);
							Ray light_ray = new Ray(intersection_point, to_light);
							Intersection shadow_intersection = scene.FindClosestIntersection(light_ray);
							if (shadow_intersection != null && shadow_intersection.t > 0)
							{
								hasShadow = true;
							}
							if (intersection.intersectable is Sphere)
							{
								Sphere sphere = intersection.intersectable as Sphere;
								normal = (intersection_point - sphere.center).Normalized();
								color = sphere.color;
							}
							else if (intersection.intersectable is Plane)
							{
								normal = Vector3.UnitY;
								color = (intersection.intersectable as Plane).color;

							}
							float lambert = System.Math.Clamp(Vector3.Dot(to_light, normal), 0f, 1f);
							colors[r_ray] = color * lambert * light_color * intensity * (hasShadow ? 0 : 1);
						}
						Vector3 c = new Vector3();
						for (int i = 0; i < rays; i++)
							c += colors[i];
						c /= rays;
						surface.SetPixel(x, y, c.X, c.Y, c.Z);
					}
				}
			}
		}

	}
}