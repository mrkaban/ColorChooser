using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ColorChooser
{
	public static class OwnColorTranslator
	{
		public static String ToHtml(Color color)
		{
			return String.Format("{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
		}

		public static Color FromHtml(String color)
		{
			if (color.StartsWith("#"))
				color = color.Remove(0, 1);

			var components = new int[3];
			if (color.Length == 6)
			{
				components[0] = Convert.ToInt32(color.Substring(0, 2), 16);
				components[1] = Convert.ToInt32(color.Substring(2, 2), 16);
				components[2] = Convert.ToInt32(color.Substring(4, 2), 16);
			}
			else if (color.Length == 3)
			{
				components[0] = Convert.ToInt32(color.Substring(0, 1), 16);
				components[1] = Convert.ToInt32(color.Substring(1, 1), 16);
				components[2] = Convert.ToInt32(color.Substring(2, 1), 16);
			}

			return Color.FromArgb(components[0], components[1], components[2]);
		}
	}
}
