using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConceptMatrix
{
	// This file is used a a means of converting the generated types from Lumina to ones with properties. 
	// I could just fork the project and do it from there, but I've opted against it for now.

	public class CMStain
	{
		public uint Id { get; set; }
		public SolidColorBrush Color { get; set; }
		public string Name { get; set; }

		public override string ToString() => this.Name;
	}

	public class CMWeather
	{
		public byte Id { get; set; }
		public string Name { get; set; }

		public ImageSource Icon { get; set; }

		public override string ToString() => this.Name;
	}

	public class CMStatus
	{
		public uint Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ImageSource Icon { get; set; }
	}
}
