using OpenTK.Mathematics;
using System;

namespace raytracer
{
	class Camera
	{
		Vector3 position;
		Vector3 up;
		Vector3 right;
		Vector3 forward;
		float fieldOfView;
		float aspectRatio;
		float height;
		float width;
		Vector3 topLeft;

		public Camera(Vector3 position, Vector3 forward, float fieldOfView, float aspectRatio)
		{
			Vector3 up = new Vector3(0, 1, 0);

			if (up.Normalized() == forward.Normalized())
				up = new Vector3(1, 0, 0);

			this.right = Vector3.Cross(forward, up).Normalized();
			this.forward = forward.Normalized();
			this.up = Vector3.Cross(right, forward);
			this.position = position;
			this.fieldOfView = fieldOfView;
			this.aspectRatio = aspectRatio;
			this.height = (float)Math.Atan(((double)fieldOfView) / 2) * 2;
			this.width = aspectRatio * height;
			this.topLeft = position + forward + (up * (height / 2)) - (right * (width / 2));
		}

		public Ray GetCameraRay(float x, float y)
		{
			Vector3 planePos = topLeft + (right * Math.Clamp(x, 0, 1) * width) - (up * Math.Clamp(y, 0, 1) * height);
			return new Ray(position, (planePos - position).Normalized());
		}
	}
}