using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ColorChooser.Properties;

namespace ColorChooser
{
	static class Program
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				if (!File.Exists("Microsoft.WindowsAPICodePack.dll"))
					File.WriteAllBytes("Microsoft.WindowsAPICodePack.dll", Resources.Microsoft_WindowsAPICodePack);
				if (!File.Exists("Microsoft.WindowsAPICodePack.Shell.dll"))
					File.WriteAllBytes("Microsoft.WindowsAPICodePack.Shell.dll", Resources.Microsoft_WindowsAPICodePack_Shell);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при распаковке необходимых модулей. Пожалуйста, проверьте разрешения каталога!\n" + ex, "Ошибка при распаковке", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
