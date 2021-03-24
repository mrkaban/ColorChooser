using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace ColorChooser
{
	public partial class MainForm : Form
	{
		readonly Timer _getColor;
		private bool _txtHexFullBlocked;
		private bool _txtHexShortBlocked;

		public MainForm()
		{
			InitializeComponent();
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			_getColor = new Timer { Interval = 10 };
			_getColor.Tick += GetColorTick;
		}

		private Brush Contrast(Color value)
		{
			var c = value;
			var l = 0.2126 * c.R + 0.7152 * c.G + 0.0722 * c.B;
			if (l < 0.5)
			{
				return Brushes.White;
			}
			return Brushes.Black;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			if (TaskbarManager.IsPlatformSupported)
			{
				var thumbnail = new TabbedThumbnail(this.Handle, this);
				thumbnail.TabbedThumbnailBitmapRequested += (sender, args) => {
					var bmp = new Bitmap(100, 100);
					using (Graphics gfx = Graphics.FromImage(bmp))
					{
						gfx.FillRectangle(new SolidBrush(BackColor), 0, 0, 100, 100);
						gfx.DrawString(String.Format("#{0}", OwnColorTranslator.ToHtml(BackColor)), new Font(FontFamily.GenericMonospace, 10), Contrast(BackColor), 15, 55);
						gfx.DrawString("R", new Font(FontFamily.GenericMonospace, 7), Contrast(BackColor), 12, 70);
						gfx.DrawString("G", new Font(FontFamily.GenericMonospace, 7), Contrast(BackColor), 45, 70);
						gfx.DrawString("B", new Font(FontFamily.GenericMonospace, 7), Contrast(BackColor), 77, 70);
						gfx.DrawString(String.Format("{0:000} {1:000} {2:000}", BackColor.R, BackColor.G, BackColor.B), new Font(FontFamily.GenericMonospace, 10), Contrast(BackColor), 2, 80);
					}
					thumbnail.SetImage(bmp);
				};
				thumbnail.TabbedThumbnailMaximized += (sender, args) => Invoke(new Action(() => WindowState = FormWindowState.Maximized));
				thumbnail.TabbedThumbnailMinimized += (sender, args) => Invoke(new Action(() => WindowState = FormWindowState.Minimized));
				thumbnail.TabbedThumbnailActivated += (sender, args) => Invoke(new Action(BringToFront));
				thumbnail.TabbedThumbnailClosed += (sender, args) => Invoke(new Action(Close));
				TaskbarManager.Instance.TabbedThumbnail.AddThumbnailPreview(thumbnail);
			}
			TranslateColor();
		}

		private void TranslateColor()
		{
			string htmlColor = OwnColorTranslator.ToHtml(BackColor);
			if(!_txtHexFullBlocked)
				txtHexFull.Text = String.Format("#{0}", htmlColor);
			if(!_txtHexShortBlocked)
				txtHexShort.Text = htmlColor;
			txtRgbShort.Text = String.Format("{0},{1},{2}", this.BackColor.R, this.BackColor.G, this.BackColor.B);
			txtRgbFull.Text = String.Format("rgb({0},{1},{2})", this.BackColor.R, this.BackColor.G, this.BackColor.B);
			if (TaskbarManager.IsPlatformSupported)
			{
				var bmp = new Bitmap(100, 100);
				Graphics.FromImage(bmp).FillRectangle(new SolidBrush(BackColor), 0, 0, 100, 100);
				TaskbarManager.Instance.SetOverlayIcon(Icon.FromHandle(bmp.GetHicon()), txtHexShort.Text);
				TaskbarManager.Instance.TabbedThumbnail.InvalidateThumbnails();
			}
		}

		private void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			TopMost = chkAlmostTop.Checked;
		}

		private void Button1Click(object sender, EventArgs e)
		{
			OpenColorChooserDialog();
		}

		private void OpenColorChooserDialog()
		{
			var colorDialog = new ColorDialog {Color = this.BackColor, FullOpen = true};
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				BackColor = colorDialog.Color;
				TranslateColor();
			}
		}

		void GetColorTick(object sender, EventArgs e)
		{
			try
			{
				int mouseX = MousePosition.X;
				int mouseY = MousePosition.Y;
				Screen screen = Screen.FromRectangle(new Rectangle(MousePosition.X, MousePosition.Y, 1, 1));
				Bitmap deskBitmap = GetScreenshot(screen);
				int x = screen.Primary ? mouseX : mouseX - screen.Bounds.X;
				int y = screen.Primary ? mouseY : mouseY - screen.Bounds.Y;
				Color myColor = deskBitmap.GetPixel(x, y);
				BackColor = myColor;
				TranslateColor();
				GC.Collect();
			}
			finally { }
		}

		private void Button2MouseDown(object sender, MouseEventArgs e)
		{
			_getColor.Start();
			var cv = new CursorConverter();
			var cursor = (Cursor)cv.ConvertFrom(Properties.Resources.Pipette);
			this.Cursor = cursor;
		}

		private void Button2MouseUp(object sender, MouseEventArgs e)
		{
			_getColor.Stop();
			this.Cursor = Cursors.Default;
		}

		private void TextBox3DoubleClick(object sender, EventArgs e)
		{
			OpenRgbForm();
		}

		private void TextBox2TextChanged(object sender, EventArgs e)
		{
			if (txtHexShort.Text.Length == 6)
			{
				this.BackColor = OwnColorTranslator.FromHtml("#" + txtHexShort.Text);
				TranslateColor();
			}
			else if (txtHexShort.Text.Length == 3)
			{
				this.BackColor = OwnColorTranslator.FromHtml("#" + txtHexShort.Text);
				_txtHexShortBlocked = true;
				TranslateColor();
			}
		}

		private void TextBox1TextChanged(object sender, EventArgs e)
		{
			if (txtHexFull.Text.Length == 7)
			{
				this.BackColor = OwnColorTranslator.FromHtml(txtHexFull.Text);
				TranslateColor();
			}
			else if (txtHexFull.Text.Length == 4)
			{
				this.BackColor = OwnColorTranslator.FromHtml(txtHexFull.Text);
				_txtHexFullBlocked = true;
				TranslateColor();
			}
		}

		private Bitmap GetScreenshot(Screen screen)
		{
			var bmp = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, PixelFormat.Format32bppArgb);
			Graphics gfxScreenshot = Graphics.FromImage(bmp);
			gfxScreenshot.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, new Size(screen.Bounds.Width, screen.Bounds.Height));
			gfxScreenshot.Save();
			return bmp;
		}

		private void BtnRgbFormClick(object sender, EventArgs e)
		{
			OpenRgbForm();
		}

		private void OpenRgbForm()
		{
			try
			{
				var form = new RgbForm();
				Color color = OwnColorTranslator.FromHtml(txtHexFull.Text);
				form.ChoosenColor = color;
				form.BackColor = color;
				if (form.ShowDialog() == DialogResult.OK)
				{
					this.BackColor = form.ChoosenColor;
					TranslateColor();
				}
			}
			finally { }
		}

		private void TxtHexShortLeave(object sender, EventArgs e)
		{
			_txtHexShortBlocked = false;
		}

		private void TxtHexFullLeave(object sender, EventArgs e)
		{
			_txtHexFullBlocked = false;
		}

		private void TxtHexFullKeyPress(object sender, KeyPressEventArgs e)
		{
			var keys = new int[] { 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '\b', '#' };
			if (!keys.Contains(e.KeyChar))
				e.Handled = true;
		}

		private void btnInvert_Click(object sender, EventArgs e)
		{
			BackColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
			TranslateColor();
		}
	}
}
