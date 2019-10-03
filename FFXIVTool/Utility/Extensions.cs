using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace FFXIVTool.Utility
{
	public static class Extensions
	{
		private static double Deg2Rad = (Math.PI * 2) / 360;
		private static double Rad2Deg = 360 / (Math.PI * 2);

		/// <summary>
		/// Convert into a Quaternion assuming the Vector3D represents euler angles.
		/// </summary>
		/// <param name="self"></param>
		/// <returns>Quaternion from Euler angles.</returns>
		public static Quaternion ToQuaternion(this Vector3D self)
		{
			var yaw = self.Y * Deg2Rad;
			var pitch = self.X * Deg2Rad;
			var roll = self.Z * Deg2Rad;

			var c1 = Math.Cos(yaw / 2);
			var s1 = Math.Sin(yaw / 2);
			var c2 = Math.Cos(pitch / 2);
			var s2 = Math.Sin(pitch / 2);
			var c3 = Math.Cos(roll / 2);
			var s3 = Math.Sin(roll / 2);

			var c1c2 = c1 * c2;
			var s1s2 = s1 * s2;

			return new Quaternion(
				c1c2 * s3 + s1s2 * c3,
				s1 * c2 * c3 + c1 * s2 * s3,
				c1 * s2 * c3 - s1 * c2 * s3,
				c1c2 * c3 - s1s2 * s3
			);
		}

		private static double NormalizeAngle(double angle)
		{
			while (angle > 360)
				angle -= 360;
			while (angle < 0)
				angle += 360;
			return angle;
		}

		private static Vector3D NormalizeAngles(Vector3D angles)
		{
			angles.X = NormalizeAngle(angles.X);
			angles.Y = NormalizeAngle(angles.Y);
			angles.Z = NormalizeAngle(angles.Z);
			return angles;
		}

		/// <summary>
		/// Converts quaternion to euler angles.
		/// </summary>
		/// <param name="q1">Quaternion to convert.</param>
		/// <returns>Vector3D as euler angles.</returns>
		public static Vector3D ToEulerAngles(this Quaternion q1)
		{
			var v = new Vector3D();

			var test = q1.X * q1.Y + q1.Z * q1.W;

			if (test > 0.4995f)
			{
				v.Y = 2f * Math.Atan2(q1.X, q1.Y);
				v.X = Math.PI / 2;
				v.Z = 0;
				return NormalizeAngles(v * Rad2Deg);
			}

			if (test < -0.4995f)
			{
				v.Y = -2f * Math.Atan2(q1.X, q1.W);
				v.X = -Math.PI / 2;
				v.Z = 0;
				return NormalizeAngles(v * Rad2Deg);
			}

			var sqx = q1.X * q1.X;
			var sqy = q1.Y * q1.Y;
			var sqz = q1.Z * q1.Z;

			v.Y = Math.Atan2(2 * q1.Y * q1.W - 2 * q1.X * q1.Z, 1 - 2 * sqy - 2 * sqz);
			v.X = Math.Asin(2 * test);
			v.Z = Math.Atan2(2 * q1.X * q1.W - 2 * q1.Y * q1.Z, 1 - 2 * sqx - 2 * sqz);

			return NormalizeAngles(v * Rad2Deg);
		}
	}
}
