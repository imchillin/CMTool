using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.IO;
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

		// Experimental secret feature to move the GPose View with the character.
		// This lets you "walk around" the area with an actor.
		//
		// For best results freeze the following:
		//   - Character XYZ
		//   - Character rotation
		//   - GPose View XYZ
		//   - Cam Pan X (optional but it looks better)
		//
		// Quirks are:
		//   - Move too far from the initial gpose position will cull actors from the
		//     gpose entity list. This will cause linked actors to get lost. You can
		//     move the current GPose target actor with no limitations.
		//
		//   - When actors cull from the gpose entity list, you can't switch between
		//     them in-game with tab etc.
		//
		//   - Visual jitter in the actor's motion sometimes.
		public bool LinkedGposeView = false;

        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
		public CharacterDetailsView()
		{
			InitializeComponent();
            if (SaveSettings.Default.HasBackground == false) ActorBG.Opacity = 0;
            MainViewModel.ViewTime = this;
			CharacterDetailsViewModel.Viewtime = this;
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

		// I'm scared of the above being wrong sometimes (the GUI controls don't always match the real rotation).
		// Using this one based on the raw values until convinced it's safe.
		private Vector3D GetCurrenRotation() =>  new Quaternion(CharacterDetails.Rotation.value,
											                    CharacterDetails.Rotation2.value,
											                    CharacterDetails.Rotation3.value,
											                    CharacterDetails.Rotation4.value).ToEulerAngles();

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

			lock (CharacterDetails.Rotation)
			{
				CharacterDetails.Rotation.value = (float)quat.X;
				CharacterDetails.Rotation2.value = (float)quat.Y;
				CharacterDetails.Rotation3.value = (float)quat.Z;
				CharacterDetails.Rotation4.value = (float)quat.W;
			}
            // Remove listeners for value changed.	
            RotationUpDown.ValueChanged -= RotV;
            RotationUpDown2.ValueChanged -= RotV;
            RotationUpDown3.ValueChanged -= RotV;
        }
        private void RotV2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

			lock (CharacterDetails.Rotation)
			{
				CharacterDetails.Rotation.value = (float)quat.X;
				CharacterDetails.Rotation2.value = (float)quat.Y;
				CharacterDetails.Rotation3.value = (float)quat.Z;
				CharacterDetails.Rotation4.value = (float)quat.W;
			}
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

		bool ShiftHeld() => Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
		bool CtrlHeld() => Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
		bool AltHeld() => Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt);

		private void LinkPosition_Checked(object sender, RoutedEventArgs e)
		{
			bool secret_feature = ShiftHeld() && CtrlHeld() && AltHeld();

			lock (CharacterDetails.LinkedActors)
			{
				CharacterDetails.LinkedActors.RemoveAll(x => x.Name == CharacterDetails.Name.value);

				var linked = new LinkedActorInfo()
				{
					Name = CharacterDetails.Name.value,

					DataOffset = MemoryManager.Instance.MemLib.readUInt(CharacterDetailsViewModel.baseAddr).ToString("X"),

					X = CharacterDetails.X.value,
					Y = CharacterDetails.Y.value,
					Z = CharacterDetails.Z.value,

					Rotation1 = CharacterDetails.Rotation.value,
					Rotation2 = CharacterDetails.Rotation2.value,
					Rotation3 = CharacterDetails.Rotation3.value,
					Rotation4 = CharacterDetails.Rotation4.value,
				};

				CharacterDetails.LinkedActors.Add(linked);
			}

			if (secret_feature)
			{
				LinkedGposeView = true;

				// TBD: There's some kind of (thread?) race that messes things up sometimes if these aren't frozen
				xyzcheck = true;
				CharacterDetails.X.freeze = true;
				CharacterDetails.Y.freeze = true;
				CharacterDetails.Z.freeze = true;
				CharacterDetails.CamX.freeze = true;
				CharacterDetails.CamY.freeze = true;
				CharacterDetails.CamZ.freeze = true;
				CharacterDetails.CamAngleX.freeze = true;
			}
		}
		private void LinkPosition_Unchecked(object sender, RoutedEventArgs e)
		{
			lock (CharacterDetails.LinkedActors)
			{
				CharacterDetails.LinkedActors.RemoveAll(x => x.Name == CharacterDetails.Name.value);
			}

			LinkedGposeView = false;
		}

		private void LinkGposeView_Checked(object sender, RoutedEventArgs e)
		{
			LinkedGposeView = true;
		}
		private void LinkGposeView_Unchecked(object sender, RoutedEventArgs e)
		{
			LinkedGposeView = false;
		}

		private void HighlightCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            HighlightCheckbox.IsChecked = true;
        }
        private void HighlightCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            HighlightCheckbox.IsChecked = false;
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
				if (EmoteBox.Value <= 7756) CharacterDetails.Emote.value = (int)EmoteBox.Value;
			EmoteBox.ValueChanged -= Emotexd;
		}

		private void Setto0_Click(object sender, RoutedEventArgs e)
		{
			CharacterDetails.EmoteSpeed1.value = 0;
			CharacterDetails.EmoteSpeed2.value = 0;
		}

        #endregion

        #region Camera

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

		/*
        private void FaceCamX_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (FaceCamX.IsMouseOver || FaceCamX.IsKeyboardFocusWithin)
            {
                FaceCamX.ValueChanged -= FaceCamX_;
                FaceCamX.ValueChanged += FaceCamX_;
            }
        }

        private void FaceCamX_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (FaceCamX.Value.HasValue)
                if (FaceCamX.IsMouseOver || FaceCamX.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.FaceCamX), "float", FaceCamX.Value.ToString());
            FaceCamX.ValueChanged -= FaceCamX_;
        }

        private void FaceCamY_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (FaceCamY.IsMouseOver || FaceCamY.IsKeyboardFocusWithin)
            {
                FaceCamY.ValueChanged -= FaceCamY_;
                FaceCamY.ValueChanged += FaceCamY_;
            }
        }

        private void FaceCamY_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (FaceCamY.Value.HasValue)
                if (FaceCamY.IsMouseOver || FaceCamY.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.FaceCamY), "float", FaceCamY.Value.ToString());
            FaceCamY.ValueChanged -= FaceCamY_;
        }

        private void FaceCamZ_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (FaceCamZ.IsMouseOver || FaceCamZ.IsKeyboardFocusWithin)
            {
                FaceCamZ.ValueChanged -= FaceCamZ_;
                FaceCamZ.ValueChanged += FaceCamZ_;
            }
        }

        private void FaceCamZ_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (FaceCamZ.Value.HasValue)
                if (FaceCamZ.IsMouseOver || FaceCamZ.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.FaceCamZ), "float", FaceCamZ.Value.ToString());
            FaceCamZ.ValueChanged -= FaceCamZ_;
        }
		*/

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
				//System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace + frame + line, App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);

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

		double GetCameraAngleXAsDegrees()
		{
			double degrees = (float)(CharacterDetails.CamAngleX.value * 180 / Math.PI);
			return (degrees + 720) % 360;
		}

		private void PosSettingsSave_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.CurrentlySaving = true;

			var dlg = new SaveFileDialog
			{
				InitialDirectory = SaveSettings.Default.ProfileDirectory,
				Filter = "Concept Matrix Location File (*.cml)|*.cml"
			};

			if (dlg.ShowDialog() == true)
			{
				var euler_rot = GetCurrenRotation();
				var cam_angle = GetCameraAngleXAsDegrees();

				var settings = new SaveSettings.LocationSettings
				{
					X = CharacterDetails.X.value,
					Y = CharacterDetails.Y.value,
					Z = CharacterDetails.Z.value,

					OffsetFromViewX = CharacterDetails.CamX.value - CharacterDetails.X.value,
					OffsetFromViewY = CharacterDetails.CamY.value - CharacterDetails.Y.value,
					OffsetFromViewZ = CharacterDetails.CamZ.value - CharacterDetails.Z.value,

					OffsetFromCamX = (float)(cam_angle - euler_rot.Y),

					Rotation1 = CharacterDetails.Rotation.value,
					Rotation2 = CharacterDetails.Rotation2.value,
					Rotation3 = CharacterDetails.Rotation3.value,
					Rotation4 = CharacterDetails.Rotation4.value
				};

				string data = JsonConvert.SerializeObject(settings, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

				File.WriteAllText(dlg.FileName, data);
			}

			MainWindow.CurrentlySaving = false;
		}

		private void PosSettingsLoad_Click(object sender, RoutedEventArgs e)
		{
			bool use_rot_offsets = AltHeld();
			bool use_offsets = use_rot_offsets || CtrlHeld();

			var dlg = new OpenFileDialog
			{
				InitialDirectory = SaveSettings.Default.ProfileDirectory,
				Filter = "Concept Matrix Location File (*.cml)|*.cml|Concept Matrix Gpose View File (*.cmg)|*.cmg",
				DefaultExt = ".cml"
			};

			if (dlg.ShowDialog() == true)
			{
				var settings = JsonConvert.DeserializeObject<SaveSettings.LocationSettings>(File.ReadAllText(dlg.FileName));

				xyzcheck = true;
				CharacterDetails.X.freeze = true;
				CharacterDetails.Y.freeze = true;
				CharacterDetails.Z.freeze = true;

				if (use_offsets)
				{
					CharacterDetails.X.value = CharacterDetails.CamX.value - settings.OffsetFromViewX;
					CharacterDetails.Y.value = CharacterDetails.CamY.value - settings.OffsetFromViewY;
					CharacterDetails.Z.value = CharacterDetails.CamZ.value - settings.OffsetFromViewZ;
				}
				else
				{
					CharacterDetails.X.value = settings.X;
					CharacterDetails.Y.value = settings.Y;
					CharacterDetails.Z.value = settings.Z;
				}

				if (!float.IsNaN(settings.Rotation1) &&
					!float.IsNaN(settings.Rotation2) &&
					!float.IsNaN(settings.Rotation3) &&
					!float.IsNaN(settings.Rotation4))
				{
					numbcheck = true;
					CharacterDetails.RotateFreeze = true;

					var euler = new Quaternion(settings.Rotation1,
											   settings.Rotation2,
											   settings.Rotation3,
											   settings.Rotation4).ToEulerAngles();

					if (use_rot_offsets)
					{
						var cam_angle = GetCameraAngleXAsDegrees();
						var cam_rot_diff_degrees = cam_angle - euler.Y - settings.OffsetFromCamX;

						// Adjust the characters own rotation
						euler.Y += (float)cam_rot_diff_degrees;
						euler.Y = (euler.Y + 720) % 360;

						// Adjust the character's rotation relative to the camera to match
						// This keeps multiple loaded actors also relative to each other as you'd expect
						var axis_angle = new AxisAngleRotation3D(new Vector3D(0, 3, 0), cam_rot_diff_degrees);

						var transform = new RotateTransform3D(axis_angle, CharacterDetails.CamX.value, CharacterDetails.Y.value, CharacterDetails.CamZ.value);

						var rotated_point = transform.Transform(new Point3D(CharacterDetails.X.value, CharacterDetails.Y.value, CharacterDetails.Z.value));

						CharacterDetails.X.value = (float) rotated_point.X;
						CharacterDetails.Y.value = (float) rotated_point.Y;
						CharacterDetails.Z.value = (float) rotated_point.Z;
					}

					lock (CharacterDetails.Rotation)
					{
						CharacterDetails.RotateX = (float)euler.X;
						CharacterDetails.RotateY = (float)euler.Y;
						CharacterDetails.RotateZ = (float)euler.Z;

						// Using this on purpose since it derives from the values we just set
						var quat = GetEulerAngles().ToQuaternion();
						CharacterDetails.Rotation.value = (float)quat.X;
						CharacterDetails.Rotation2.value = (float)quat.Y;
						CharacterDetails.Rotation3.value = (float)quat.Z;
						CharacterDetails.Rotation4.value = (float)quat.W;
					}
				}
			}
		}

		private void GposeViewSettingsSave_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.CurrentlySaving = true;

			var dlg = new SaveFileDialog
			{
				InitialDirectory = SaveSettings.Default.ProfileDirectory,
				Filter = "Concept Matrix Gpose View File (*.cmg)|*.cmg"
			};

			if (dlg.ShowDialog() == true)
			{
				var settings = new SaveSettings.LocationSettings
				{

					X = CharacterDetails.CamX.value,
					Y = CharacterDetails.CamY.value,
					Z = CharacterDetails.CamZ.value,

					OffsetFromViewX = CharacterDetails.CamX.value - CharacterDetails.X.value,
					OffsetFromViewY = CharacterDetails.CamY.value - CharacterDetails.Y.value,
					OffsetFromViewZ = CharacterDetails.CamZ.value - CharacterDetails.Z.value,

					TargetRotation = (float)GetCurrenRotation().Y,
					TargetRotationName = CharacterDetails.Name.value,
					TargetRotationRace = CharacterDetails.Race.value,
					TargetRotationClan = CharacterDetails.Clan.value,

					OffsetX = CharacterDetails.CamViewX.value,
					OffsetY = CharacterDetails.CamViewY.value,
					OffsetZ = CharacterDetails.CamViewZ.value
				};

				string data = JsonConvert.SerializeObject(settings, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

				File.WriteAllText(dlg.FileName, data);
			}

			MainWindow.CurrentlySaving = false;
		}

		private void GposeViewSettingsLoad_Click(object sender, RoutedEventArgs e)
		{
			bool use_rot_offsets = AltHeld();
			bool use_offsets = use_rot_offsets || CtrlHeld();

			var dlg = new OpenFileDialog
			{
				InitialDirectory = SaveSettings.Default.ProfileDirectory,
				Filter = "Concept Matrix Gpose View File (*.cmg)|*.cmg|Concept Matrix Location File (*.cml)|*.cml",
				DefaultExt = ".cmg"
			};

			if (dlg.ShowDialog() == true)
			{
				var settings = JsonConvert.DeserializeObject<SaveSettings.LocationSettings>(File.ReadAllText(dlg.FileName));

				// Make sure user didn't exit gpose while loading
				if (!GposeViewSettingsLoad.IsEnabled) return;

				CharacterDetails.CamX.freeze = true;
				CharacterDetails.CamY.freeze = true;
				CharacterDetails.CamZ.freeze = true;

				if (use_offsets)
				{
					CharacterDetails.CamX.value = CharacterDetails.X.value + settings.OffsetFromViewX;
					CharacterDetails.CamY.value = CharacterDetails.Y.value + settings.OffsetFromViewY;
					CharacterDetails.CamZ.value = CharacterDetails.Z.value + settings.OffsetFromViewZ;

					if (use_rot_offsets)
					{
						var rot_diff = GetCurrenRotation().Y - settings.TargetRotation;

						var axis_angle = new AxisAngleRotation3D(new Vector3D(0, 3, 0), rot_diff);

						var transform = new RotateTransform3D(axis_angle, CharacterDetails.X.value, CharacterDetails.CamY.value, CharacterDetails.Z.value);

						var rotated_point = transform.Transform(new Point3D(CharacterDetails.CamX.value, CharacterDetails.CamY.value, CharacterDetails.CamZ.value));

						CharacterDetails.CamX.value = (float)rotated_point.X;
						CharacterDetails.CamY.value = (float)rotated_point.Y;
						CharacterDetails.CamZ.value = (float)rotated_point.Z;
					}
				}
				else
				{
					CharacterDetails.CamX.value = settings.X;
					CharacterDetails.CamY.value = settings.Y;
					CharacterDetails.CamZ.value = settings.Z;
				}

				if (!float.IsNaN(settings.OffsetX) &&
					!float.IsNaN(settings.OffsetY) &&
					!float.IsNaN(settings.OffsetZ))
				{
					CharacterDetails.CamViewX.freeze = true;
					CharacterDetails.CamViewY.freeze = true;
					CharacterDetails.CamViewZ.freeze = true;

					CharacterDetails.CamViewX.value = settings.OffsetX;
					CharacterDetails.CamViewY.value = settings.OffsetY;
					CharacterDetails.CamViewZ.value = settings.OffsetZ;
				}
			}
		}
	}
}