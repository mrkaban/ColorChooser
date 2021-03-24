using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorChooser
{
	public partial class RgbForm : Form
	{
		public Color ChoosenColor;

		public RgbForm()
		{
			InitializeComponent();
		}

		private bool TranslateColor()
		{
			if (txtR.Text.Length != 0 && txtG.Text.Length != 0 && txtB.Text.Length != 0)
			{
				byte r = 0, g = 0, b = 0;
				bool rightInput = byte.TryParse(txtR.Text, out r) && byte.TryParse(txtG.Text, out g) &&
								  byte.TryParse(txtB.Text, out b);
				if (!rightInput)
					MessageBox.Show("Please corrent your input.");
				else
				{
					this.BackColor = Color.FromArgb(r, g, b);
					this.ChoosenColor = Color.FromArgb(r, g, b);
				}
			}
			return true;
		}

		private void TextBox1TextChanged(object sender, EventArgs e)
		{
			TranslateColor();
		}

		private void Button2Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.Close();
		}

		private void Button1Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void RgbFormShown(object sender, EventArgs e)
		{
			this.txtR.Text = this.BackColor.R.ToString(CultureInfo.InvariantCulture);
			this.txtG.Text = this.BackColor.G.ToString(CultureInfo.InvariantCulture);
			this.txtB.Text = this.BackColor.B.ToString(CultureInfo.InvariantCulture);
			TranslateColor();
		}

		private void RgbFormKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
		}

		private void TextBox1KeyUp(object sender, KeyEventArgs e)
		{
			//if (txtR.Text.Length != 0 && txtG.Text.Length != 0 && txtB.Text.Length != 0 && e.KeyCode == Keys.Enter)
			//{
			//    this.DialogResult = System.Windows.Forms.DialogResult.OK;
			//    this.Close();
			//}
		}
	}
}
