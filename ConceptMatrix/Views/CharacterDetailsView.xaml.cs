using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace ConceptMatrix.Views
{
	/// <summary>
	/// Interaction logic for CharacterDetailsView.xaml
	/// </summary>
	public partial class CharacterDetailsView : UserControl
	{
		public static CmpReader _colorMap = new CmpReader(Properties.Resources.human);
		public static ExdCsvReader _exdProvider = new ExdCsvReader();
		public static bool xyzcheck = false;
		public static bool numbcheck = false;
        public bool AltRotate;
        public bool AdvancedMove;

        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
		public CharacterDetailsView()
		{
			InitializeComponent();
			_exdProvider.MonsterList();
            MainViewModel.ViewTime = this;
			ExdCsvReader.MonsterX = _exdProvider.Monsters.Values.ToArray();
			CharacterDetailsViewModel.Viewtime = this;
			DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(40) };
			timer.Tick += delegate
			{
				foreach (ExdCsvReader.Monster xD in ExdCsvReader.MonsterX)
				{
					if (xD.Real == true)
					{
						SpecialControl.ModelBox.Items.Add(new ExdCsvReader.Monster
						{
							Index = Convert.ToInt32(xD.Index),
							Name = xD.Name.ToString()
						});
					}
				}
				timer.IsEnabled = false;
			};
			timer.Start();
            if(SaveSettings.Default.RotationSliders == true)
            {
                RotSliderButton.IsChecked = true;
                RotationUpDown.Visibility = Visibility.Hidden;
                RotationUpDown.IsEnabled = false;
                RotationUpDown2.Visibility = Visibility.Hidden;
                RotationUpDown2.IsEnabled = false;
                RotationUpDown3.Visibility = Visibility.Hidden;
                RotationUpDown3.IsEnabled = false;

                RotationSlider.Visibility = Visibility.Visible;
                RotationSlider.IsEnabled = true;
                RotationSlider2.Visibility = Visibility.Visible;
                RotationSlider2.IsEnabled = true;
                RotationSlider3.Visibility = Visibility.Visible;
                RotationSlider3.IsEnabled = true;
            }
            else if (SaveSettings.Default.RotationSliders == false)
            {
                RotationUpDown.Visibility = Visibility.Visible;
                RotationUpDown.IsEnabled = true;
                RotationUpDown2.Visibility = Visibility.Visible;
                RotationUpDown2.IsEnabled = true;
                RotationUpDown3.Visibility = Visibility.Visible;
                RotationUpDown3.IsEnabled = true;

                RotationSlider.Visibility = Visibility.Hidden;
                RotationSlider.IsEnabled = false;
                RotationSlider2.Visibility = Visibility.Hidden;
                RotationSlider2.IsEnabled = false;
                RotationSlider3.Visibility = Visibility.Hidden;
                RotationSlider3.IsEnabled = false;
            }
            if (SaveSettings.Default.AdvancedMove == true)
            {
                PosRelButton.IsChecked = true;
            }
            if (SaveSettings.Default.AltRotate == true)
            {
                RotRelButton.IsChecked = true;
            }

        }

		#region Height

		private void Height2x_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (Height2x.Value.HasValue)
				if (Height2x.Value > 0) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", Height2x.Value.ToString());
			Height2x.ValueChanged -= Height2x_ValueChanged;
		}
		private void Height2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (Height2x.Value.HasValue)
				if (Height2x.Value > 0) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", Height2x.Value.ToString());
			HeightSlider.ValueChanged -= Height2_ValueChanged;
		}
		private void Height2x_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
		{
			if (Height2x.IsMouseOver || Height2x.IsKeyboardFocusWithin)
			{
				Height2x.ValueChanged -= Height2x_ValueChanged;
				Height2x.ValueChanged += Height2x_ValueChanged;
			}
			if (HeightSlider.IsKeyboardFocusWithin || HeightSlider.IsMouseOver)
			{
				HeightSlider.ValueChanged -= Height2_ValueChanged;
				HeightSlider.ValueChanged += Height2_ValueChanged;
			}
		}

		#endregion

		private void DigitCheckInput(object sender, TextCompositionEventArgs e)
		{
			if (!char.IsDigit(e.Text, e.Text.Length - 1))
				e.Handled = true;
		}

		private void NameBox_KeyUp(object sender, KeyEventArgs e)
		{
            if (e.Key != Key.Enter) return;
            e.Handled = true;
			CharacterDetails.Name.value = NameBox.Text.Replace("\0", string.Empty);
			MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Name), "string", NameBox.Text + "\0\0\0\0");
		}

		#region Bust

		private void BustXUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			if (BustXSlider.IsKeyboardFocusWithin || BustXSlider.IsMouseOver)
			{
				BustXSlider.ValueChanged -= BustX2a;
				BustXSlider.ValueChanged += BustX2a;
			}
			if (BustXUpDown.IsMouseOver || BustXUpDown.IsKeyboardFocusWithin)
			{
				BustXUpDown.ValueChanged -= BustX2s;
				BustXUpDown.ValueChanged += BustX2s;
			}
		}
		private void BustX2s(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (BustXUpDown.Value > 0)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustXUpDown.Value.ToString());
			BustXUpDown.ValueChanged -= BustX2s;
		}
		private void BustX2a(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (BustXUpDown.Value > 0)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustXSlider.Value.ToString());
			BustXSlider.ValueChanged -= BustX2a;
		}

		private void BustYUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			if (BustYSlider.IsKeyboardFocusWithin || BustYSlider.IsMouseOver)
			{
				BustYSlider.ValueChanged -= BustY1;
				BustYSlider.ValueChanged += BustY1;
			}
			if (BustYUpDown.IsKeyboardFocusWithin || BustYUpDown.IsMouseOver)
			{
				BustYUpDown.ValueChanged -= BustY2_;
				BustYUpDown.ValueChanged += BustY2_;
			}
		}
		private void BustY2_(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (BustYUpDown.Value > 0)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustYUpDown.Value.ToString());
			BustYUpDown.ValueChanged -= BustY2_;
		}
		private void BustY1(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (BustYUpDown.Value > 0)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustYSlider.Value.ToString());
			BustYSlider.ValueChanged -= BustY1;
		}

		private void BustZUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			if (BustZUpDown.IsKeyboardFocusWithin || BustZUpDown.IsMouseOver)
			{
				BustZUpDown.ValueChanged -= BustZ2_;
				BustZUpDown.ValueChanged += BustZ2_;
			}
			if (BustZSlider.IsKeyboardFocusWithin || BustZSlider.IsMouseOver)
			{
				BustZSlider.ValueChanged -= BustZ1;
				BustZSlider.ValueChanged += BustZ1;
			}
		}
		private void BustZ2_(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (BustZUpDown.Value > 0)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZUpDown.Value.ToString());
			BustZUpDown.ValueChanged -= BustZ2_;
		}
		private void BustZ1(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (BustZUpDown.Value > 0)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZSlider.Value.ToString());
			BustZSlider.ValueChanged -= BustZ1;
		}

        #endregion

        #region Rotation

        /// <summary>	
		/// Gets the euler angles from the UI elements.	
		/// </summary>	
		/// <returns>Vector3D representing euler angles.</returns>	
		private Vector3D GetEulerAngles() => new Vector3D(CharacterDetails.RotateX, CharacterDetails.RotateY, CharacterDetails.RotateZ);

        private void RotationUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
        {

            if (RotationSlider.IsKeyboardFocusWithin || RotationSlider.IsMouseOver)
            {
                RotationSlider.ValueChanged -= RotV2;
                RotationSlider.ValueChanged += RotV2;
            }

            if (RotationUpDown.IsKeyboardFocusWithin || RotationUpDown.IsMouseOver)
            {
                RotationUpDown.ValueChanged -= RotV;
                RotationUpDown.ValueChanged += RotV;
            }
        }
        private void RotationUpDown2_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (RotationSlider2.IsKeyboardFocusWithin || RotationSlider2.IsMouseOver)
            {
                RotationSlider2.ValueChanged -= RotV2;
                RotationSlider2.ValueChanged += RotV2;
            }

            if (RotationUpDown2.IsKeyboardFocusWithin || RotationUpDown2.IsMouseOver)
            {
                RotationUpDown2.ValueChanged -= RotV;
                RotationUpDown2.ValueChanged += RotV;
            }
        }
        private void RotationUpDown3_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (RotationSlider3.IsKeyboardFocusWithin || RotationSlider3.IsMouseOver)
            {
                RotationSlider3.ValueChanged -= RotV2;
                RotationSlider3.ValueChanged += RotV2;
            }

            if (RotationUpDown3.IsKeyboardFocusWithin || RotationUpDown3.IsMouseOver)
            {
                RotationUpDown3.ValueChanged -= RotV;
                RotationUpDown3.ValueChanged += RotV;
            }
        }
        private void RotV(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.Rotation.value = (float)quat.X;
            CharacterDetails.Rotation2.value = (float)quat.Y;
            CharacterDetails.Rotation3.value = (float)quat.Z;
            CharacterDetails.Rotation4.value = (float)quat.W;
            // Remove listeners for value changed.	
            RotationUpDown.ValueChanged -= RotV;
            RotationUpDown2.ValueChanged -= RotV;
            RotationUpDown3.ValueChanged -= RotV;
        }
        private void RotV2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.Rotation.value = (float)quat.X;
            CharacterDetails.Rotation2.value = (float)quat.Y;
            CharacterDetails.Rotation3.value = (float)quat.Z;
            CharacterDetails.Rotation4.value = (float)quat.W;
            // Remove listeners for value changed.	
            RotationSlider.ValueChanged -= RotV2;
            RotationSlider2.ValueChanged -= RotV2;
            RotationSlider3.ValueChanged -= RotV2;
            //  Console.WriteLine(CharacterDetails.RotateY);	
        }


        private void RotSliderButton_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.RotationSliders = true;
            RotationUpDown.Visibility = Visibility.Hidden;
            RotationUpDown.IsEnabled = false;
            RotationUpDown2.Visibility = Visibility.Hidden;
            RotationUpDown2.IsEnabled = false;
            RotationUpDown3.Visibility = Visibility.Hidden;
            RotationUpDown3.IsEnabled = false;

            RotationSlider.Visibility = Visibility.Visible;
            RotationSlider.IsEnabled = true;
            RotationSlider2.Visibility = Visibility.Visible;
            RotationSlider2.IsEnabled = true;
            RotationSlider3.Visibility = Visibility.Visible;
            RotationSlider3.IsEnabled = true;
        }
        private void RotSliderButton_Unchecked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.RotationSliders = false;
            RotationUpDown.Visibility = Visibility.Visible;
            RotationUpDown.IsEnabled = true;
            RotationUpDown2.Visibility = Visibility.Visible;
            RotationUpDown2.IsEnabled = true;
            RotationUpDown3.Visibility = Visibility.Visible;
            RotationUpDown3.IsEnabled = true;

            RotationSlider.Visibility = Visibility.Hidden;
            RotationSlider.IsEnabled = false;
            RotationSlider2.Visibility = Visibility.Hidden;
            RotationSlider2.IsEnabled = false;
            RotationSlider3.Visibility = Visibility.Hidden;
            RotationSlider3.IsEnabled = false;
        }

        private void RotRelButton_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.AltRotate = true;
            AltRotate = true;
        }
        private void RotRelButton_Unchecked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.AltRotate = false;
            AltRotate = false;
        }

        private void Freeze1234_Click(object sender, RoutedEventArgs e)
		{
			numbcheck = !numbcheck;
			CharacterDetails.RotateFreeze = numbcheck;
		}

		#endregion

		#region Position

		private void PosX_SourceUpdated(object sender, DataTransferEventArgs e) => Pos_SourceUpdated(PosX, XPosUpdate);
		private void PosY_SourceUpdated(object sender, DataTransferEventArgs e) => Pos_SourceUpdated(PosY, YPosUpdate);
		private void PosZ_SourceUpdated(object sender, DataTransferEventArgs e) => Pos_SourceUpdated(PosZ, ZPosUpdate);

		/// <summary>
		/// This thing exists because of the way this broken ass system works, the flag is purely to not trigger multiple source update loops.
		/// </summary>
		private bool PosAdvancedWorking = false;

		private void Pos_SourceUpdated(MahApps.Metro.Controls.NumericUpDown control, RoutedPropertyChangedEventHandler<double?> handler)
		{
			if (AdvancedMove && control.Name != PosY.Name)
			{
				// Ensure not in an existing event.
				if (!PosAdvancedWorking)
				{
					control.ValueChanged -= AdvancedPosUpdate;
					control.ValueChanged += AdvancedPosUpdate;
				}
			}
			else if (control.IsKeyboardFocusWithin || control.IsMouseOver)
			{
				control.ValueChanged -= handler;
				control.ValueChanged += handler;
			}
		}

		private const double Deg2Rad = (Math.PI * 2) / 360;

		private void AdvancedPosUpdate(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			// Get the control from sender.
			var control = (sender as MahApps.Metro.Controls.NumericUpDown);

			// Remove the event handler (?)
			control.ValueChanged -= AdvancedPosUpdate;

			// Flag that we're working to avoid updates later.
			PosAdvancedWorking = true;

			// Instantiate x and z floats for the vector.
			var x = 0.0;
			var z = 0.0;

			double oldX = 0;
			double oldZ = 0;

			// Set the appropriate axis based on which control this is.
			if (control.Name == PosX.Name)
			{
				z = (double)(e.NewValue - e.OldValue);
				oldX = e.OldValue ?? 0;
				oldZ = PosZ.Value ?? 0;
			}
			else
			{
				x = (double)(e.NewValue - e.OldValue);
				oldX = PosX.Value ?? 0;
				oldZ = e.OldValue ?? 0;
			}

            // Get the angle of the position.
            var degrees = GetEulerAngles().Y;

            // Get the cos and sin of radians.
            var ca = Math.Cos(degrees * Deg2Rad);
			var sa = Math.Sin(degrees * Deg2Rad);

			// Calculate the new vector.
			var newX = x * sa - z * ca;
			var newZ = x * ca + z * sa;

			// Update the values in the text field (yeah I know this is dumb but this whole thing is dumb so i'm gonna leave it like this I should honestly use the databinding but I never know how any of this stuff works because the codebase is all over the place and there's like 5 possible files where something might get read or written to memory and I give up)
			PosX.Value = oldX + newX;
			PosZ.Value = oldZ + newZ;

			MemoryManager.Instance.MemLib.writeMemory(
				MemoryManager.GetAddressString(
					CharacterDetailsViewModel.baseAddr, 
					Settings.Instance.Character.Body.Base, 
					Settings.Instance.Character.Body.Position.X
				),
				"float", 
				PosX.Value.ToString()
			);

			MemoryManager.Instance.MemLib.writeMemory(
				MemoryManager.GetAddressString(
					CharacterDetailsViewModel.baseAddr,
					Settings.Instance.Character.Body.Base,
					Settings.Instance.Character.Body.Position.Z
				),
				"float",
				PosZ.Value.ToString()
			);

			// Work is done, future events can trigger now.
			PosAdvancedWorking = false;
		}

		private void XPosUpdate(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (PosX.Value.HasValue)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), "float", PosX.Value.ToString());
			PosX.ValueChanged -= XPosUpdate;
		}

		private void YPosUpdate(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (PosY.Value.HasValue)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), "float", PosY.Value.ToString());
			PosY.ValueChanged -= YPosUpdate;
		}

		private void ZPosUpdate(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (PosZ.Value.HasValue)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), "float", PosZ.Value.ToString());
			PosZ.ValueChanged -= ZPosUpdate;
		}

		private void FreezeXYZ_Click(object sender, RoutedEventArgs e)
		{
			xyzcheck = !xyzcheck;
			CharacterDetails.X.freeze = xyzcheck;
			CharacterDetails.Y.freeze = xyzcheck;
			CharacterDetails.Z.freeze = xyzcheck;
		}

        private void PosRelButton_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.AdvancedMove = true;
            AdvancedMove = true;
        }
        private void PosRelButton_Unchecked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.AdvancedMove = false;
            AdvancedMove = false;
        }

        #endregion

        #region Tail

        private void TailSz(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (TailSize.Value.HasValue)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", TailSize.Value.ToString());
			TailSize.ValueChanged -= TailSz;
		}

		private void TailSize_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
		{
			if (TailSize.IsMouseOver || TailSize.IsKeyboardFocusWithin)
			{
				TailSize.ValueChanged -= TailSz;
				TailSize.ValueChanged += TailSz;
			}
		}

		#endregion

		#region Muscle

		private void MuscleT(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (Muscletone.Value.HasValue)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", Muscletone.Value.ToString());
			Muscletone.ValueChanged -= MuscleT;
		}

		private void Muscletone_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
		{
			if (Muscletone.IsMouseOver || Muscletone.IsKeyboardFocusWithin)
			{
				Muscletone.ValueChanged -= MuscleT;
				Muscletone.ValueChanged += MuscleT;
			}
		}

		#endregion

		#region Transparency

		private void Transparency_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			if (Transparency.IsMouseOver || Transparency.IsKeyboardFocusWithin)
			{
				Transparency.ValueChanged -= Transps;
				Transparency.ValueChanged += Transps;
			}
		}
		private void Transps(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (Transparency.Value.HasValue)
				MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Transparency), "float", Transparency.Value.ToString());
			Transparency.ValueChanged -= Transps;
		}

        #endregion

        #region Emote

        private void EmoteSearch_Click(object sender, RoutedEventArgs e)
		{
			if (EmoteFlyouts.IsOpen)
			{
				if (EmoteFlyouts.AnimBox.SelectedIndex != 0)
				{
					EmoteFlyouts.AnimBox.SelectedIndex = 0;
				}
				else EmoteFlyouts.IsOpen = !EmoteFlyouts.IsOpen;
			}
			else
			{
				EmoteFlyouts.IsOpen = !EmoteFlyouts.IsOpen;
				EmoteFlyouts.AnimBox.SelectedIndex = 0;
			}
		}

		private void EmoteOldSearch_Click(object sender, RoutedEventArgs e)
		{
			if (EmoteFlyouts.IsOpen)
			{
				if (EmoteFlyouts.AnimBox.SelectedIndex != 1)
				{
					EmoteFlyouts.AnimBox.SelectedIndex = 1;
				}
				else EmoteFlyouts.IsOpen = !EmoteFlyouts.IsOpen;
			}
			else
			{
				EmoteFlyouts.IsOpen = !EmoteFlyouts.IsOpen;
				EmoteFlyouts.AnimBox.SelectedIndex = 1;
			}
		}

		private void EmoteBox_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			if (EmoteBox.IsMouseOver || EmoteBox.IsKeyboardFocusWithin)
			{
				EmoteBox.ValueChanged -= Emotexd;
				EmoteBox.ValueChanged += Emotexd;
			}
		}
		private void Emotexd(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (EmoteBox.Value.HasValue)
				if (EmoteBox.Value <= 7736) CharacterDetails.Emote.value = (int)EmoteBox.Value;
			EmoteBox.ValueChanged -= Emotexd;
		}

		private void Setto0_Click(object sender, RoutedEventArgs e)
		{
			CharacterDetails.EmoteSpeed1.value = 0;
			CharacterDetails.EmoteSpeed2.value = 0;
		}

        #endregion

        #region Camera
        private void CamViewX_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CamViewX.IsMouseOver || CamViewX.IsKeyboardFocusWithin)
            {
                CamViewX.ValueChanged -= CamViewX_;
                CamViewX.ValueChanged += CamViewX_;
            }
        }
        private void CamViewX_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamViewX.Value.HasValue)
                if (CamViewX.IsMouseOver || CamViewX.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.CamViewX), "float", CamViewX.Value.ToString());
            CamViewX.ValueChanged -= CamViewX_;
        }

        private void CamViewY_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CamViewY.IsMouseOver || CamViewY.IsKeyboardFocusWithin)
            {
                CamViewY.ValueChanged -= CamViewY_;
                CamViewY.ValueChanged += CamViewY_;
            }
        }
        private void CamViewY_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamViewY.Value.HasValue)
                if (CamViewY.IsMouseOver || CamViewY.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.CamViewY), "float", CamViewY.Value.ToString());
            CamViewY.ValueChanged -= CamViewY_;
        }

        private void CamViewZ_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CamViewZ.IsMouseOver || CamViewZ.IsKeyboardFocusWithin)
            {
                CamViewZ.ValueChanged -= CamViewZ_;
                CamViewZ.ValueChanged += CamViewZ_;
            }
        }
        private void CamViewZ_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamViewZ.Value.HasValue)
                if (CamViewZ.IsMouseOver || CamViewZ.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.CamViewZ), "float", CamViewZ.Value.ToString());
            CamViewZ.ValueChanged -= CamViewZ_;
        }
        private void CamX_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			if (CamX.IsMouseOver || CamX.IsKeyboardFocusWithin)
			{
				CamX.ValueChanged -= CamX_;
				CamX.ValueChanged += CamX_;
			}
		}

		private void CamX_(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (CamX.Value.HasValue)
				if (CamX.IsMouseOver || CamX.IsKeyboardFocusWithin)
					MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), "float", CamX.Value.ToString());
			CamX.ValueChanged -= CamX_;
		}

		private void CamY_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			if (CamY.IsMouseOver || CamY.IsKeyboardFocusWithin)
			{
				CamY.ValueChanged -= CamY_;
				CamY.ValueChanged += CamY_;
			}
		}

		private void CamY_(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (CamY.Value.HasValue)
				if (CamY.IsMouseOver || CamY.IsKeyboardFocusWithin)
					MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), "float", CamY.Value.ToString());
			CamY.ValueChanged -= CamY_;
		}

		private void CamZ_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			if (CamZ.IsMouseOver || CamZ.IsKeyboardFocusWithin)
			{
				CamZ.ValueChanged -= CamZ_;
				CamZ.ValueChanged += CamZ_;
			}
		}

		private void CamZ_(object sender, RoutedPropertyChangedEventArgs<double?> e)
		{
			if (CamZ.Value.HasValue)
				if (CamZ.IsMouseOver || CamZ.IsKeyboardFocusWithin)
					MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), "float", CamZ.Value.ToString());
			CamZ.ValueChanged -= CamZ_;
		}

		#endregion

		private void SkinSearch_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 0)
				{
					SpecialControl.ColorTab.IsSelected = true;
					SpecialControl.CharaMakeColorSelector(_colorMap, SpecialControl.GetSkin(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
					SpecialControl.ClanBox.SelectedIndex = 0;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ColorTab.IsSelected = true;
				SpecialControl.CharaMakeColorSelector(_colorMap, SpecialControl.GetSkin(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
				SpecialControl.ClanBox.SelectedIndex = 0;
			}
		}

		#region Hair

		private void HairSelectButton_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 1)
				{
					SpecialControl.ColorTab.IsSelected = true;
					SpecialControl.CharaMakeColorSelector(_colorMap, SpecialControl.GetHair(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
					SpecialControl.ClanBox.SelectedIndex = 1;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ColorTab.IsSelected = true;
				SpecialControl.CharaMakeColorSelector(_colorMap, SpecialControl.GetHair(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
				SpecialControl.ClanBox.SelectedIndex = 1;
			}
		}

		private void HighlightcolorSearch_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 2)
				{
					SpecialControl.ColorTab.IsSelected = true;
					SpecialControl.CharaMakeColorSelector(_colorMap, 256, 192);
					SpecialControl.ClanBox.SelectedIndex = 2;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ColorTab.IsSelected = true;
				SpecialControl.CharaMakeColorSelector(_colorMap, 256, 192);
				SpecialControl.ClanBox.SelectedIndex = 2;
			}
		}

		private void HairSelectButton_Click_1(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.HairTab.IsSelected)
				{
					SpecialControl.HairTab.IsSelected = true;
					SpecialControl.CharaMakeFeatureSelector(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.HairTab.IsSelected = true;
				SpecialControl.CharaMakeFeatureSelector(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
			}
		}

		private void HighLightButton_Checked(object sender, RoutedEventArgs e)
		{
			CharacterDetails.Highlights.value = 128;
			MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), "byte", "80");
		}

		private void HighLightButton_Unchecked(object sender, RoutedEventArgs e)
		{
			CharacterDetails.Highlights.value = 0;
			MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), "byte", "0");
		}

		#endregion

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 3)
				{
					SpecialControl.ColorTab.IsSelected = true;
					SpecialControl.CharaMakeColorSelectorLips(_colorMap, 512, 96);
					SpecialControl.ClanBox.SelectedIndex = 3;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ColorTab.IsSelected = true;
				SpecialControl.CharaMakeColorSelectorLips(_colorMap, 512, 96);
				SpecialControl.ClanBox.SelectedIndex = 3;
			}
		}

		#region Eye

		private void RightEyeSearch_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 4)
				{
					SpecialControl.ColorTab.IsSelected = true;
					SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
					SpecialControl.ClanBox.SelectedIndex = 4;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ColorTab.IsSelected = true;
				SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
				SpecialControl.ClanBox.SelectedIndex = 4;
			}
		}

		private void LeftEyeSearch_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 5)
				{
					SpecialControl.ColorTab.IsSelected = true;
					SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
					SpecialControl.ClanBox.SelectedIndex = 5;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ColorTab.IsSelected = true;
				SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
				SpecialControl.ClanBox.SelectedIndex = 5;
			}
		}

		private void LimbalEyeSearch_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 7)
				{
					SpecialControl.ColorTab.IsSelected = true;
					SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
					SpecialControl.ClanBox.SelectedIndex = 7;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ColorTab.IsSelected = true;
				SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
				SpecialControl.ClanBox.SelectedIndex = 7;
			}
		}

		#endregion

		#region Face

		private void FacePaint_Color_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 6)
				{
					SpecialControl.ColorTab.IsSelected = true;
					SpecialControl.CharaMakeColorSelectorLips(_colorMap, 512, 96);
					SpecialControl.ClanBox.SelectedIndex = 6;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ColorTab.IsSelected = true;
				SpecialControl.CharaMakeColorSelectorLips(_colorMap, 512, 96);
				SpecialControl.ClanBox.SelectedIndex = 6;
			}
		}
		private void FaceSelectButton_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.PaintTab.IsSelected)
				{
					SpecialControl.PaintTab.IsSelected = true;
					SpecialControl.CheckIncluded.IsChecked = false;
					SpecialControl.CharaMakeFeatureSelector2(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.PaintTab.IsSelected = true;
				SpecialControl.CheckIncluded.IsChecked = false;
				SpecialControl.CharaMakeFeatureSelector2(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
			}
		}

		private void FacialFeature_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.FacialTab.IsSelected)
				{
					SpecialControl.FacialTab.IsSelected = true;
					SpecialControl.CharaMakeFeatureSelector3(CharacterDetails.Head.value, CharacterDetails.Race.value, CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.FacialTab.IsSelected = true;
				SpecialControl.CharaMakeFeatureSelector3(CharacterDetails.Head.value, CharacterDetails.Race.value, CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
			}
		}

		#endregion

		private void ModelTypeButton_Click(object sender, RoutedEventArgs e)
		{
			if (SpecialControl.IsOpen)
			{
				if (!SpecialControl.ModelType.IsSelected)
				{
					SpecialControl.ModelType.IsSelected = true;
				}
				else SpecialControl.IsOpen = !SpecialControl.IsOpen;
			}
			else
			{
				SpecialControl.IsOpen = !SpecialControl.IsOpen;
				SpecialControl.ModelType.IsSelected = true;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			try
			{

				Random rnd = new Random();
				CharacterDetails.Race.value = (byte)rnd.Next(1, 7);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), CharacterDetails.Race.GetBytes());
				if (CharacterDetails.Race.value == 1) CharacterDetails.Clan.value = (byte)rnd.Next(1, 3);
				else if (CharacterDetails.Race.value == 2) CharacterDetails.Clan.value = (byte)rnd.Next(3, 5);
				else if (CharacterDetails.Race.value == 3) CharacterDetails.Clan.value = (byte)rnd.Next(5, 7);
				else if (CharacterDetails.Race.value == 4) CharacterDetails.Clan.value = (byte)rnd.Next(7, 9);
				else if (CharacterDetails.Race.value == 5) CharacterDetails.Clan.value = (byte)rnd.Next(9, 11);
				else if (CharacterDetails.Race.value == 6) CharacterDetails.Clan.value = (byte)rnd.Next(11, 13);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), CharacterDetails.Clan.GetBytes());
				CharacterDetails.Gender.value = (byte)rnd.Next(0, 2);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), CharacterDetails.Gender.GetBytes());
				SpecialControl.HairRandomPick(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
				if (CharacterDetails.Race.value == 1 && CharacterDetails.Clan.value == 1 && CharacterDetails.Gender.value == 0) CharacterDetails.Head.value = (byte)rnd.Next(0, 8);
				else if (CharacterDetails.Race.value == 1 && CharacterDetails.Clan.value == 1 && CharacterDetails.Gender.value == 1) CharacterDetails.Head.value = (byte)rnd.Next(0, 6);
				else CharacterDetails.Head.value = (byte)rnd.Next(0, 5);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), CharacterDetails.Head.GetBytes());
				CharacterDetails.HairTone.value = (byte)rnd.Next(0, 193);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), CharacterDetails.HairTone.GetBytes());
				if (rnd.Next(2) == 1)
				{
					CharacterDetails.Highlights.value = 128;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), CharacterDetails.Highlights.GetBytes());
					CharacterDetails.HighlightTone.value = (byte)rnd.Next(0, 193);
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
				}
				else
				{
					CharacterDetails.Highlights.value = 0;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), CharacterDetails.Highlights.GetBytes());
					CharacterDetails.HighlightTone.value = 0;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
				}
				CharacterDetails.RHeight.value = (byte)rnd.Next(0, 101);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), CharacterDetails.RHeight.GetBytes());
				CharacterDetails.RBust.value = (byte)rnd.Next(0, 101);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), CharacterDetails.RBust.GetBytes());
				CharacterDetails.Eye.value = (byte)rnd.Next(0, 6);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), CharacterDetails.Eye.GetBytes());
				CharacterDetails.EyeBrowType.value = (byte)rnd.Next(0, 5);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), CharacterDetails.EyeBrowType.GetBytes());
				if (rnd.Next(100) < 15) //Checks if there should be Odd Eyes.
				{
					CharacterDetails.RightEye.value = (byte)rnd.Next(0, 193);
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
					CharacterDetails.LeftEye.value = (byte)rnd.Next(0, 193);
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
				}
				else
				{
					CharacterDetails.RightEye.value = (byte)rnd.Next(0, 193);
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
					CharacterDetails.LeftEye.value = CharacterDetails.RightEye.value;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
				}
				CharacterDetails.Nose.value = (byte)rnd.Next(0, 6);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), CharacterDetails.Nose.GetBytes());
				if (rnd.Next(100) < 25) // 25% chance Lip coloring may happen?
				{
					CharacterDetails.Lips.value = (byte)rnd.Next(128, 134);
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), CharacterDetails.Lips.GetBytes());
					if (rnd.Next(2) == 1) // 50% chance it'll be dark lips?
					{
						CharacterDetails.LipsTone.value = (byte)rnd.Next(0, 96);
						MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
					}
					else
					{
						CharacterDetails.LipsTone.value = (byte)rnd.Next(128, 224);
						MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
					}
				}
				else
				{
					CharacterDetails.Lips.value = (byte)rnd.Next(0, 6);
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), CharacterDetails.Lips.GetBytes());
					CharacterDetails.LipsTone.value = 0;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
				}
				CharacterDetails.Jaw.value = (byte)rnd.Next(0, 6);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), CharacterDetails.Jaw.GetBytes());
				if (rnd.Next(100) < 25) //25% having facial feature?
				{
					CharacterDetails.FacialFeatures.value = (byte)rnd.Next(0, 256);
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
					if (CharacterDetails.Race.value == 6)
					{
						CharacterDetails.LimbalEyes.value = (byte)rnd.Next(0, 192);
						MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalEyes), CharacterDetails.LimbalEyes.GetBytes());
					}
				}
				else
				{
					CharacterDetails.FacialFeatures.value = 0;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
					CharacterDetails.LimbalEyes.value = 0;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalEyes), CharacterDetails.LimbalEyes.GetBytes());
				}
				if (rnd.Next(100) < 25)
				{
					if (rnd.Next(2) == 1) //50% Chance of being reversed
					{
						CharacterDetails.FacePaint.value = (byte)rnd.Next(128, 157);
						MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
					}
					else
					{
						CharacterDetails.FacePaint.value = (byte)rnd.Next(0, 29);
						MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
					}
					if (rnd.Next(2) == 1) // 50% chance it'll be dark Paint?
					{
						CharacterDetails.FacePaintColor.value = (byte)rnd.Next(0, 96);
						MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
					}
					else
					{
						CharacterDetails.FacePaintColor.value = (byte)rnd.Next(128, 224);
						MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
					}
				}
				else
				{
					CharacterDetails.FacePaint.value = 0;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
					CharacterDetails.FacePaintColor.value = 0;
					MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
				}
				if (CharacterDetails.Race.value == 4) CharacterDetails.TailType.value = (byte)rnd.Next(0, 9);
				else if (CharacterDetails.Race.value == 3 || CharacterDetails.Race.value == 2 || CharacterDetails.Race.value == 6) CharacterDetails.TailType.value = (byte)rnd.Next(0, 4);
				else CharacterDetails.TailType.value = 0;
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), CharacterDetails.TailType.GetBytes());
				CharacterDetails.TailorMuscle.value = (byte)rnd.Next(0, 101);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), CharacterDetails.TailorMuscle.GetBytes());
				CharacterDetails.Skintone.value = (byte)rnd.Next(0, 192);
				MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), CharacterDetails.Skintone.GetBytes());
			}
			catch (System.Exception ex)
			{
				// Get stack trace for the exception with source file information
				var st = new System.Diagnostics.StackTrace(ex, true);
				// Get the top stack frame
				var frame = st.GetFrame(0);
				// Get the line number from the stack frame
				var line = frame.GetFileLineNumber();
				System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace + frame + line, "Oh no!");

			}
		}

        private void DataPathBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var m = MemoryManager.Instance.MemLib;
            var c = Settings.Instance.Character;

            string GAS(params string[] args) => MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, args);

            if (DataPathBox.IsKeyboardFocusWithin || DataPathBox.IsMouseOver)
            {
                if (DataPathBox.SelectedIndex >= 0)
                {
                    CharacterDetails.DataPath.value = short.Parse(((ComboBoxItem)DataPathBox.SelectedItem).Tag.ToString());
                    m.writeMemory(GAS(c.DataPath), "int", ((ComboBoxItem)DataPathBox.SelectedItem).Tag.ToString());
                    if (CharacterDetails.Clan.value == 1 || CharacterDetails.Clan.value == 3 || CharacterDetails.Clan.value == 5 || CharacterDetails.Clan.value == 7 || CharacterDetails.Clan.value == 9 || CharacterDetails.Clan.value == 11 || CharacterDetails.Clan.value == 13 || CharacterDetails.Clan.value == 15)
                    {
                        if (CharacterDetails.DataPath.value == 301)
                        {
                            m.writeMemory(GAS(c.DataHead), "byte", "0x65");
                        }
                        else if (CharacterDetails.DataPath.value == 401)
                        {
                            m.writeMemory(GAS(c.DataHead), "byte", "0x65");
                        }
                        else m.writeMemory(GAS(c.DataHead), "byte", "0x01");
                    }
                    else
                    {
                        if (CharacterDetails.Clan.value == 2 || CharacterDetails.Clan.value == 4 || CharacterDetails.Clan.value == 6 || CharacterDetails.Clan.value == 8 || CharacterDetails.Clan.value == 10)
                        {
                            if (CharacterDetails.DataPath.value == 101)
                            {
                                m.writeMemory(GAS(c.DataHead), "byte", "0x01");
                            }
                            else if (CharacterDetails.DataPath.value == 201)
                            {
                                m.writeMemory(GAS(c.DataHead), "byte", "0x01");
                            }
                            else m.writeMemory(GAS(c.DataHead), "byte", "0x65");
                        }
                        else
                        {
                            if (CharacterDetails.DataPath.value == 101)
                            {
                                m.writeMemory(GAS(c.DataHead), "byte", "0x65");
                            }
                            else if (CharacterDetails.DataPath.value == 201)
                            {
                                m.writeMemory(GAS(c.DataHead), "byte", "0x65");
                            }
                            if (CharacterDetails.DataPath.value == 301)
                            {
                                m.writeMemory(GAS(c.DataHead), "byte", "0xC9");
                            }
                            else if (CharacterDetails.DataPath.value == 401)
                            {
                                m.writeMemory(GAS(c.DataHead), "byte", "0xC9");
                            }
                            else m.writeMemory(GAS(c.DataHead), "byte", "0x65");
                        }
                    }
                }
            }
        }
	}
}