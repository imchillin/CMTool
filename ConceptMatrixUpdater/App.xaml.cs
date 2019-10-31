using System.Windows;

namespace ConceptMatrixUpdater
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// Application startup event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			// Create MainWindow.
			var window = new MainWindow();

			// Loop over the arguments.
			foreach (var arg in e.Args)
			{
				// Used in the tool, avoids the "Up to date" message.
				if (arg.Contains("--checkUpdate"))
					window.AlertUpToDate = false;
				// Force an update even if the tool is up to date.
				if (arg.Contains("--forceUpdate"))
					window.ForceCheckUpdate = true;
			}

#if DEBUG
			// Force check update while in debug.
			window.ForceCheckUpdate = true;
#endif

			// Display the MainWindow.
			window.Show();

			// Initialize the update process.
			window.Initialize();
		}
	}
}
