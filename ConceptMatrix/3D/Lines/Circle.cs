namespace ConceptMatrix.ThreeD.Lines
{
	using System;
	using System.Windows.Media.Media3D;

	public class Circle : Line
	{
		private double radius;

		public Circle()
		{
			this.Generate();
		}

		public double Radius
		{
			get
			{
				return radius;
			}
			set
			{
				radius = value;
				this.Generate();
			}
		}

		public void Generate()
		{
			this.Points.Clear();
			const int numberOfPointsInCircle = 100;

			double angleStep = MathUtils.DegreesToRadians(360.0f / (numberOfPointsInCircle - 1));
			for (int i = 0; i < numberOfPointsInCircle; i++)
			{
				this.Points.Add(new Point3D(Math.Cos(angleStep * i) * this.Radius, 0.0, Math.Sin(angleStep * i) * this.Radius));
				this.Points.Add(new Point3D(Math.Cos(angleStep * (i + 1)) * this.Radius, 0.0, Math.Sin(angleStep * (i + 1)) * this.Radius));
			}
		}
	}
}
