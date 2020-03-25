namespace ConceptMatrix.Controls
{
	using PropertyChanged;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Documents;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using System.Windows.Navigation;
	using System.Windows.Shapes;

	/// <summary>
	/// Interaction logic for NumberBox.xaml
	/// </summary>
	public partial class NumberBox : UserControl, INotifyPropertyChanged
	{
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(double), typeof(NumberBox));

		private string inputString;

		public NumberBox()
		{
			this.InitializeComponent();
			this.Content.DataContext = this;
		}

		public double TickFrequency { get; set; } = 0.5f;
		public double Minimum { get; set; } = 0;
		public double Maximum { get; set; } = 100;

		public string Text
		{
			get
			{
				return inputString;
			}

			set
			{
				this.inputString = value;

				double val = 0;
				if (double.TryParse(value, out val))
				{
					this.Value = val;
					this.ErrorDisplay.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.ErrorDisplay.Visibility = Visibility.Visible;
				}
			}
		}

		public double Value 
		{ 
			get
			{
				return (double)this.GetValue(ValueProperty);
			}

			set
			{
				this.SetValue(ValueProperty, value);
				this.Text = this.Value.ToString("0.###");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnLostFocus(object sender, RoutedEventArgs e)
		{
			this.Text = this.Value.ToString("0.###");
		}

		protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
		{
			e.Handled = true;
			this.Value += e.Delta > 0 ? TickFrequency : -TickFrequency;
			this.Value = Math.Min(this.Value, this.Maximum);
			this.Value = Math.Max(this.Value, this.Minimum);
		}
	}
}
