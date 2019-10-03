using Ionic.Zip;
using MahApps.Metro.Controls;
using Markdig;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace SSToolUpdater
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public string UpdateString { get; set; }
		public string HTML { get; set; }
		private readonly JObject json;
		public string ApplicationPath;
		private readonly string temp = Path.Combine(Path.GetTempPath(), "SSTool");
		public int ProgressValue { get; set; }
		private BackgroundWorker bw;

		public MainWindow()
		{
			InitializeComponent();

			DataContext = this;

			// Initialize variable for the current PP version.
			bool forceCheckUpdate = false;

			// Get the current version of the application.
			var result = Version.TryParse(FileVersionInfo.GetVersionInfo(Path.Combine(Environment.CurrentDirectory, "FFXIVTool.exe")).FileVersion, out Version CurrentVersion);
			if (!result)
			{
				MessageBox.Show(
					"There was an error when trying to read the current version of SSTool, you will be prompted to download the latest version.",
					"SSTool Updater",
					MessageBoxButton.OK,
					MessageBoxImage.Error
				);
				// Force to check the update.
				forceCheckUpdate = true;
			}

			// Create request for Github REST API for the latest release of Paisley Park.
			if (WebRequest.Create("https://api.github.com/repos/imchillin/SSTool/releases/latest") is HttpWebRequest request)
			{
				request.Method = "GET";
				request.UserAgent = "SSTool";
				request.ServicePoint.Expect100Continue = false;

				try
				{
					using (var r = new StreamReader(request.GetResponse().GetResponseStream()))
					{
						// Get the JSON as a JObject to get the properties dynamically.
						json = JsonConvert.DeserializeObject<JObject>(r.ReadToEnd());
						// Get tag name and remove the v in front.
						var tag_name = json["tag_name"].Value<string>();
						// Form release version from this string.
						var releaseVersion = new Version(tag_name);
						// Check if the release is newer.
						if (releaseVersion > CurrentVersion || forceCheckUpdate)
						{
							// Create HTML out of the markdown in body.
							var html = Markdown.ToHtml(json["body"].Value<string>());
							// Set the update string
							UpdateString = $"SSTool {releaseVersion.VersionString()} is now available, you have {CurrentVersion.VersionString()}. Would you like to download it now?";
							// Set HTML in the window.
							HTML = "<style>body{font-family:-apple-system,BlinkMacSystemFont,Segoe UI,Helvetica,Arial,sans-serif,Apple Color Emoji,Segoe UI Emoji,Segoe UI Symbol;margin:10px 20px;padding:0;font-size:12px;}ul{margin:0;padding:0;list-style-position:inside;}</style>" + html;
						}
						else
						{
							// MessageBox.Show("You're up to date!", "SSTool Updater", MessageBoxButton.OK, MessageBoxImage.Information);
							Close();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					var response = MessageBox.Show(
						"Failed to fetch the latest version! Would you like to visit the page manually to check for the latest release manually?",
						"Paisley Park Updater",
						MessageBoxButton.YesNo,
						MessageBoxImage.Error
					);
					if (response == MessageBoxResult.Yes)
					{
						// Visit the latest releases page on GitHub to download the latest Paisley Park.
						Process.Start("https://github.com/imchillin/SSTool/releases/latest");
					}
				}
			}
		}

		/// <summary>
		/// Ensure the temp path exists.
		/// </summary>
		private void ValidateTempPath()
		{
			// Create temp diretory if it doesn't exist.
			if (!Directory.Exists(temp))
				Directory.CreateDirectory(temp);
		}

		/// <summary>
		/// When clicking the install button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInstallClick(object sender, RoutedEventArgs e)
		{
			Dispatcher.BeginInvoke(new Action(() =>
			{
				// Use web client to download the update.
				using (var wc = new WebClient())
				{
					// Ensure the temp path exists.
					ValidateTempPath();

					// Temporary Paisley Park zip path.
					var tPPZip = Path.Combine(temp, "SSTool.zip");

					// Delete existing zip file.
					if (File.Exists(tPPZip))
						File.Delete(tPPZip);

					// Download the file. 
					wc.DownloadFileAsync(new Uri(json["assets"][0]["browser_download_url"].Value<string>()), tPPZip);

					// When the download changes.
					wc.DownloadProgressChanged += UpdateDownloadProgressChanged;
					wc.DownloadFileCompleted += DownloadFileCompleted;
				}
			}), System.Windows.Threading.DispatcherPriority.ContextIdle);
		}

		private void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			// Temporary Paisley Park zip path.
			var tPPZip = Path.Combine(temp, "SSTool.zip");

			// Create a background worker.
			bw = new BackgroundWorker() { WorkerReportsProgress = true };

			// Reset the download progress.
			DownloadProgress.Value = 0;
			// Add the work loop.
			bw.DoWork += UnzipWorker;
			// Add the progress changed listener.
			bw.ProgressChanged += (s, _e) => Dispatcher.Invoke(() => DownloadProgress.Value = _e.ProgressPercentage);

			try
			{
				// Close Paisley Park if it's running.
				var pp = Process.GetProcessesByName("FFXIVTool")[0];
				// Close the mainwindow shutting down the process.
				pp.CloseMainWindow();
				// Try to wait for it to shut down gracefully.
				if (!pp.WaitForExit(10000))
				{
					// Kill the process.
					pp.Kill();
				}
			}
			catch (Exception) { }

			// Temporary name.
			var tempName = ".SSTU.old";

			// Rename the updater file to allow for overwrite.
			if (File.Exists(Path.Combine(Environment.CurrentDirectory, tempName)))
				File.Delete(Path.Combine(Environment.CurrentDirectory, tempName));
			File.Move(Path.Combine(Environment.CurrentDirectory, "SSToolUpdater.exe"), Path.Combine(Environment.CurrentDirectory, tempName));

			// Run the worker.
			bw.RunWorkerAsync(tPPZip);

			bw.RunWorkerCompleted += (_, __) =>
			{
				// Start the tool.
				Process.Start(Path.Combine(Environment.CurrentDirectory, "FFXIVTool.exe"));

				// Dispose of the worker.
				bw.Dispose();

				// Shutdown the application we're done here.
				Close();
			};
		}

		private void UnzipWorker(object sender, DoWorkEventArgs e)
		{
			// Unzip and overwrite all files.
			using (var zip = ZipFile.Read(e.Argument as string))
			{
				for (var i = 0; i < zip.Count; i++)
				{
					zip[i].Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
					bw.ReportProgress((i + 1) / zip.Count * 100);
				}
			}
		}

		/// <summary>
		/// Progress from webclient updates.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			DownloadProgress.Value = e.ProgressPercentage;
		}

		/// <summary>
		/// Clicking the no button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNoClick(object sender, RoutedEventArgs e)
		{
			// Close the updater.
			Application.Current.Shutdown();
		}
	}
}
