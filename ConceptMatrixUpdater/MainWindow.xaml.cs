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
using System.Windows;

namespace ConceptMatrixUpdater
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow, INotifyPropertyChanged
	{
		// Constants for the tool to make it easier to update and swap out.
		private const string ToolBin = "ConceptMatrix";
		private const string ToolName = "Concept Matrix";
		private const string UpdaterName = "Concept Matrix Updater";
		private const string UpdaterBin = "ConceptMatrixUpdater";
		private const string GithubRepo = "imchillin/CMTool";
		private const string ZipName = "CMTool.zip";

		// Properties for the UI.
		public string StatusLabel { get; set; }
		public string HTML { get; set; }
		public int ProgressValue { get; set; }

		private JObject json;
		private readonly string temp = Path.Combine(Path.GetTempPath(), ToolBin);
		public bool AlertUpToDate = true;
		public bool ForceCheckUpdate = false;

		public event PropertyChangedEventHandler PropertyChanged;

		public MainWindow()
		{
			InitializeComponent();

			// Set the security protocol, mainly for Windows 7 users.
			ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);

			// Set data context to this.
			DataContext = this;
		}

		public void Initialize()
		{
			// Get the current version of the application.
			var result = Version.TryParse(FileVersionInfo.GetVersionInfo(Path.Combine(Environment.CurrentDirectory, $"{ToolBin}.exe")).FileVersion, out Version CurrentVersion);
			if (!result)
			{
				MessageBox.Show(
					$"There was an error when trying to read the current version of {ToolName}, you will be prompted to download the latest version.",
					UpdaterName,
					MessageBoxButton.OK,
					MessageBoxImage.Error
				);
				// Force to check the update.
				ForceCheckUpdate = true;
			}

			// Create request for Github REST API for the latest release of tool.
			if (WebRequest.Create($"https://api.github.com/repos/{GithubRepo}/releases/latest") is HttpWebRequest request)
			{
				request.Method = "GET";
				request.UserAgent = ToolName;
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
						if (releaseVersion > CurrentVersion || ForceCheckUpdate)
						{
							// Create HTML out of the markdown in body.
							var html = Markdown.ToHtml(json["body"].Value<string>());
							// Set the update string
							StatusLabel = $"{ToolName} {releaseVersion.VersionString()} is now available, you have {CurrentVersion.VersionString()}. Would you like to download it now?";
							// Set HTML in the window.
							HTML = "<style>body{font-family:-apple-system,BlinkMacSystemFont,Segoe UI,Helvetica,Arial,sans-serif,Apple Color Emoji,Segoe UI Emoji;margin:8px 10px;padding:0;font-size:12px;}ul{margin:0;padding:0;list-style-position:inside;}</style>" + html;
						}
						else
						{
							// Alerts that you're up to date.
							if (AlertUpToDate)
								MessageBox.Show("You're up to date!", UpdaterName, MessageBoxButton.OK, MessageBoxImage.Information);

							Close();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					var response = MessageBox.Show(
						"Failed to fetch the latest version! Would you like to visit the page manually to check for the latest release manually?",
						UpdaterName,
						MessageBoxButton.YesNo,
						MessageBoxImage.Error
					);
					if (response == MessageBoxResult.Yes)
					{
						// Visit the latest releases page on GitHub to download the latest version.
						Process.Start($"https://github.com/{GithubRepo}/releases/latest");

						// Close the updater.
						Close();
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

					// Temporary zip path.
					var tZip = Path.Combine(temp, ZipName);

					// Delete existing zip file.
					if (File.Exists(tZip))
						File.Delete(tZip);

					// Download the file. 
					wc.DownloadFileAsync(new Uri(json["assets"][0]["browser_download_url"].Value<string>()), tZip);

					// When the download changes.
					wc.DownloadProgressChanged += UpdateDownloadProgressChanged;
					wc.DownloadFileCompleted += DownloadFileCompleted;
				}
			}),
			System.Windows.Threading.DispatcherPriority.ContextIdle);
		}

		/// <summary>
		/// Download of the zip file is completed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			// Set status label to inform the download is complete.
			StatusLabel = "Download complete! Unzipping files...";

			// Temporary zip path.
			var tZip = Path.Combine(temp, ZipName);

			// Create a background worker.
#pragma warning disable IDE0067 // Dispose objects before losing scope
			var bw = new BackgroundWorker() { WorkerReportsProgress = true };
#pragma warning restore IDE0067 // Dispose objects before losing scope

			// Reset the download progress.
			DownloadProgress.Value = 0;
			// Add the work loop.
			bw.DoWork += UnzipWorker;
			// Add the progress changed listener.
			bw.ProgressChanged += (s, _e) => Dispatcher.Invoke(() => DownloadProgress.Value = _e.ProgressPercentage);

			try
			{
				// Get any tools open.
				var procs = Process.GetProcessesByName(ToolBin);
				// Iterate over each.
				foreach (var p in procs)
				{
					// Kill it with fire and wait for it to close.
					p.Kill();
					p.WaitForExit(5000);
				}
			}
			catch (Exception) { }

			// Temporary name.
			var tempName = "DELETE";

			// Delete existing old updaters from temp folder.
			if (File.Exists(Path.Combine(temp, tempName)))
				File.Delete(Path.Combine(temp, tempName));

			// Move the updater (this executable) into the temp folder.
			File.Move(Path.Combine(Environment.CurrentDirectory, $"{UpdaterBin}.exe"), Path.Combine(temp, tempName));

			// Run the worker.
			bw.RunWorkerAsync(tZip);

			// Worker is completed.
			bw.RunWorkerCompleted += (_, __) =>
			{
				// Update label for the unzip completion and tool startup.
				StatusLabel = $"Unzip complete! Starting {ToolName}";

				// Start the tool.
				Process.Start(Path.Combine(Environment.CurrentDirectory, $"{ToolBin}.exe"));
				// Shutdown the application, we're done here.
				Close();
			};
		}

		/// <summary>
		/// Background worker for unzipping files.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UnzipWorker(object sender, DoWorkEventArgs e)
		{
			// Unzip and overwrite all files.
			using (var zip = ZipFile.Read(e.Argument as string))
			{
				for (var i = 0; i < zip.Count; i++)
				{
					// Extract the zip into the current directory.
					zip[i].Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
					// Report progress of the unzip.
					(sender as BackgroundWorker).ReportProgress((i + 1) / zip.Count * 100);
				}
			}
		}

		/// <summary>
		/// Progress from webclient updates.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) => DownloadProgress.Value = e.ProgressPercentage;

		/// <summary>
		/// Clicking the no button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNoClick(object sender, RoutedEventArgs e) => Close();
	}
}
