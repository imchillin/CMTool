using FFXIVTool.Models;
using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView3.xaml
    /// </summary>
    public partial class CharacterDetailsView3 : UserControl
    {
        public class FiltersDetails : BaseModel
        {
            public Address<string> FilterAoB { get; set; }
        }
        private List<ExdCsvReader.Weather> AllowedWeathers;
        private bool isUserInteraction;
        private bool istimeLocked=false;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView3()
        {
            InitializeComponent();
        }
        private void MaxZoomXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (MaxZoom.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), "float", MaxZoom.Value.ToString());
            MaxZoom.ValueChanged -= MaxZoomXD;
        }

        private void MaxZoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (MaxZoom.IsMouseOver || MaxZoom.IsKeyboardFocusWithin)
            {
                MaxZoom.ValueChanged -= MaxZoomXD;
                MaxZoom.ValueChanged += MaxZoomXD;
            }
        }

        private void MinZoomXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Min_Zoom.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), "float", Min_Zoom.Value.ToString());
            Min_Zoom.ValueChanged -= MinZoomXD;
        }

        private void Min_Zoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Min_Zoom.IsMouseOver || Min_Zoom.IsKeyboardFocusWithin)
            {
                Min_Zoom.ValueChanged -= MinZoomXD;
                Min_Zoom.ValueChanged += MinZoomXD;
            }
        }

        private void CurrentZoomxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CurrentZoom.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", CurrentZoom.Value.ToString());
            CurrentZoom.ValueChanged -= CurrentZoomxD;
        }
        private void CurrentZoomxD(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CurrentZoom.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", CZoom2.Value.ToString());
            CZoom2.ValueChanged -= CurrentZoomxD;
        }
        private void CurrentZoom_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CurrentZoom.IsMouseOver || CurrentZoom.IsKeyboardFocusWithin)
            {
                CurrentZoom.ValueChanged -= CurrentZoomxD;
                CurrentZoom.ValueChanged += CurrentZoomxD;
            }
            if (CZoom2.IsMouseOver || CZoom2.IsKeyboardFocusWithin)
            {
                CZoom2.ValueChanged -= CurrentZoomxD;
                CZoom2.ValueChanged += CurrentZoomxD;
            }
        }

        private void CurrentFOVXD(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CurrentFOV.Value.HasValue)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), "float", FOV1S.Value.ToString());
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), "float", FOV1S.Value.ToString());
            }
            CurrentFOV.ValueChanged -= CurrentFOVXA;
        }
        private void CurrentFOVXA(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CurrentFOV.Value.HasValue)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), "float", CurrentFOV.Value.ToString());
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), "float", CurrentFOV.Value.ToString());
            }
            FOV1S.ValueChanged -= CurrentFOVXD;
        }
        private void CurrentFOV_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CurrentFOV.IsMouseOver || CurrentFOV.IsKeyboardFocusWithin)
            {
                CurrentFOV.ValueChanged -= CurrentFOVXA;
                CurrentFOV.ValueChanged += CurrentFOVXA;
            }
            if (FOV1S.IsMouseOver || FOV1S.IsKeyboardFocusWithin)
            {
                FOV1S.ValueChanged -= CurrentFOVXD;
                FOV1S.ValueChanged += CurrentFOVXD;
            }
        }

        private void CamHeightxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CameraHeight2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight2), "float", CameraHeight2.Value.ToString());
            CameraHeight2.ValueChanged -= CamHeightxd;
        }

        private void CameraHeight2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CameraHeight2.IsMouseOver || CameraHeight2.IsKeyboardFocusWithin)
            {
                CameraHeight2.ValueChanged -= CamHeightxd;
                CameraHeight2.ValueChanged += CamHeightxd;
            }
        }

        private void CamYMinxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamYMin.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), "float", CamYMin.Value.ToString());
            CamYMin.ValueChanged -= CamYMinxD;
        }

        private void CamYMin_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamYMin.IsMouseOver || CamYMin.IsKeyboardFocusWithin)
            {
                CamYMin.ValueChanged -= CamYMinxD;
                CamYMin.ValueChanged += CamYMinxD;
            }
        }

        private void CamYMaxxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamYMax.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), "float", CamYMax.Value.ToString());
            CamYMax.ValueChanged -= CamYMaxxD;
        }


        private void CamYMax_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamYMax.IsMouseOver || CamYMax.IsKeyboardFocusWithin)
            {
                CamYMax.ValueChanged -= CamYMaxxD;
                CamYMax.ValueChanged += CamYMaxxD;
            }
        }

        private void FOV2XD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (FOV2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), "float", FOV2.Value.ToString());
            FOV2.ValueChanged -= FOV2XD;
        }
        private void FOV2Ax(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (FOV2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), "float", FOV2.Value.ToString());
            FOV2S.ValueChanged -= FOV2Ax;
        }
        private void FOV2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (FOV2.IsMouseOver || FOV2.IsKeyboardFocusWithin)
            {
                FOV2.ValueChanged -= FOV2XD;
                FOV2.ValueChanged += FOV2XD;
            }
            if (FOV2S.IsMouseOver || FOV2S.IsKeyboardFocusWithin)
            {
                FOV2S.ValueChanged -= FOV2Ax;
                FOV2S.ValueChanged += FOV2Ax;
            }
        }
        private void CamUpDownXd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamUpDown.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), "float", CamUpDown.Value.ToString());
            CamUpDown.ValueChanged -= CamUpDownXd;
        }

        private void CamUpDown_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamUpDown.IsMouseOver || CamUpDown.IsKeyboardFocusWithin)
            {
                CamUpDown.ValueChanged -= CamUpDownXd;
                CamUpDown.ValueChanged += CamUpDownXd;
            }
        }

        private void Weather_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Weather.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), "byte", Weather.Value.ToString());
            Weather.ValueChanged -= Weather_ValueChanged;
        }

        private void Weather_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Weather.IsMouseOver || Weather.IsKeyboardFocusWithin)
            {
                Weather.ValueChanged -= Weather_ValueChanged;
                Weather.ValueChanged += Weather_ValueChanged;
            }
        }
        private void TimeControlUpDown_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {

        }
        private void Timexd_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeControlUpDown.Value = Timexd.Value;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.TimeAddress, Settings.Instance.Character.TimeControl), "int", TimeControlUpDown.Value.ToString());
            Timexd.ValueChanged -= Timexd_ValueChanged_1;
        }
        private void TimeVA(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (TimeControlUpDown.Value.HasValue)
            {
                Timexd.Value = (double)TimeControlUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.TimeAddress, Settings.Instance.Character.TimeControl), "int", TimeControlUpDown.Value.ToString());
            }
            TimeControlUpDown.ValueChanged -= TimeVA;
        }
        private void Timexd_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Timexd.IsMouseOver || Timexd.IsKeyboardFocusWithin)
            {
                Timexd.ValueChanged -= Timexd_ValueChanged_1;
                Timexd.ValueChanged += Timexd_ValueChanged_1;
            }
            if (TimeControlUpDown.IsMouseOver || TimeControlUpDown.IsKeyboardFocusWithin)
            {
                TimeControlUpDown.ValueChanged -= TimeVA;
                TimeControlUpDown.ValueChanged += TimeVA;
            }
        }
        public void WeatherSelector(List<ExdCsvReader.Weather> allowedWeathers, int currentWeather)
        {

            AllowedWeathers = allowedWeathers;
            WeatherBox.Items.Clear();
            for (int i = 0; i < allowedWeathers.Count; i++)
            {
                WeatherBox.Items.Add(allowedWeathers[i].Name);

                if (allowedWeathers[i].Index == currentWeather)
                    WeatherBox.SelectedIndex = i;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int territory = MemoryManager.Instance.MemLib.readInt(MemoryManager.GetAddressString(MemoryManager.Instance.TerritoryAddress, Settings.Instance.Character.Territory));

            if (!CharacterDetailsView._exdProvider.TerritoryTypes.ContainsKey(territory))
            {
                MessageBox.Show("Could not find your current zone. Make sure you are using the latest version.", "Oh no!");
                return;
            }

            if (CharacterDetailsView._exdProvider.TerritoryTypes[territory].WeatherRate == null)
            {
                MessageBox.Show("Setting weather is not supported for your current zone.", "Oh no!");
                return;
            }
            WeatherSelector(CharacterDetailsView._exdProvider.TerritoryTypes[territory].WeatherRate.AllowedWeathers, MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather)));
        }
        public ExdCsvReader.Weather Choice = null;
        private void WeatherBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (isUserInteraction)
            {
                if (WeatherBox.SelectedItem == null) return;

                Choice = AllowedWeathers[WeatherBox.SelectedIndex];
                CharacterDetails.Weather.value = (byte)AllowedWeathers[WeatherBox.SelectedIndex].Index;
                string hexValue = AllowedWeathers[WeatherBox.SelectedIndex].Index.ToString("X");
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), "byte", hexValue);

            }
            isUserInteraction = false;
        }

        private void WeatherBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isUserInteraction = true;
        }

        private void Filters_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Filters.IsKeyboardFocusWithin || Filters.IsMouseOver)
            {
                CharacterDetails.FilterAoB.SpecialActivate = true;
                if (Filters.SelectedIndex == 0)
                {
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterEnable), "byte", "00");
                    CharacterDetails.FilterAoB.value = "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                }
                else
                {
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterEnable), "byte", "40");
                    if (Filters.SelectedIndex == 1)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE 00 00 80 3F 00 00 00 00 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE 00 00 80 3F 00 00 00 00 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 2)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC 4C 3E CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D 66 66 66 3F 9A 99 99 3E 00 00 00 00 CD CC 4C 3E 00 00 00 00 CD CC 4C BE 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC 4C 3E CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D 66 66 66 3F 9A 99 99 3E 00 00 00 00 CD CC 4C 3E 00 00 00 00 CD CC 4C BE 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 3)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 4)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 00 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 5)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 00 00 00 00 CD CC CC 3D CD CC 4C BE 00 00 00 00 CD CC 4C BE 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 00 00 00 00 CD CC CC 3D CD CC 4C BE 00 00 00 00 CD CC 4C BE 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 6)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC 4C 3E 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00 CD CC 4C 3F 9A 99 19 3F CD CC CC 3E CD CC CC 3E 9A 99 19 BF CD CC 4C 3E CD CC CC 3D";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC 4C 3E 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00 CD CC 4C 3F 9A 99 19 3F CD CC CC 3E CD CC CC 3E 9A 99 19 BF CD CC 4C 3E CD CC CC 3D");
                    }
                    if (Filters.SelectedIndex == 7)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC 4C 3E CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E CD CC CC BD 00 00 00 00 CD CC 4C 3F CD CC 4C 3F 00 00 80 3F CD CC CC 3E 00 00 00 00 CD CC 4C 3E 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC 4C 3E CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E CD CC CC BD 00 00 00 00 CD CC 4C 3F CD CC 4C 3F 00 00 80 3F CD CC CC 3E 00 00 00 00 CD CC 4C 3E 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 8)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 00 00 CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00 33 33 33 3F 9A 99 19 3F 00 00 00 3F CD CC CC 3E 9A 99 19 BF CD CC 4C 3E 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 00 CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00 33 33 33 3F 9A 99 19 3F 00 00 00 3F CD CC CC 3E 9A 99 19 BF CD CC 4C 3E 00 00 00 00");

                    }
                    if (Filters.SelectedIndex == 9)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 00 3F 00 00 00 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E 00 00 00 3F 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 3F 00 00 00 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E 00 00 00 3F 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 10)
                    {
                        CharacterDetails.FilterAoB.value = "66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 11)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3E 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E CD CC CC BD CD CC 4C BE";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3E 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E CD CC CC BD CD CC 4C BE");
                    }
                    if (Filters.SelectedIndex == 12)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3E 33 33 33 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE 00 00 80 3F 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3E 33 33 33 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE 00 00 80 3F 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 13)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 00 00 CD CC CC 3E CD CC CC BE 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE CD CC 4C 3E 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 00 CD CC CC 3E CD CC CC BE 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE CD CC 4C 3E 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 14)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 00 00 33 33 B3 3E CD CC CC BE CD CC CC 3E 00 00 00 00 CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE CD CC CC 3E 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 00 33 33 B3 3E CD CC CC BE CD CC CC 3E 00 00 00 00 CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE CD CC CC 3E 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 15)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3D CD CC CC 3E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 9A 99 19 3F 9A 99 19 3F 9A 99 19 3F CD CC CC BD CD CC 4C 3E 00 00 00 00 CD CC 4C BE";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3D CD CC CC 3E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 9A 99 19 3F 9A 99 19 3F 9A 99 19 3F CD CC CC BD CD CC 4C 3E 00 00 00 00 CD CC 4C BE");
                    }
                    if (Filters.SelectedIndex == 16)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3D 9A 99 99 3E 00 00 00 00 CD CC 4C BE 00 00 00 00 CD CC CC BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3D 9A 99 99 3E 00 00 00 00 CD CC 4C BE 00 00 00 00 CD CC CC BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 17)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3D CD CC CC 3E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 33 33 33 3F 33 33 33 3F 33 33 33 3F CD CC 4C BE CD CC 4C 3E CD CC 4C BE CD CC 4C BE";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3D CD CC CC 3E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 33 33 33 3F 33 33 33 3F 33 33 33 3F CD CC 4C BE CD CC 4C 3E CD CC 4C BE CD CC 4C BE");
                    }
                    if (Filters.SelectedIndex == 18)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3D 66 66 66 3F 00 00 00 00 CD CC 4C 3E 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 66 66 66 3F CD CC CC 3D 00 00 00 3F CD CC 4C 3E 00 00 00 00 00 00 00 00 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3D 66 66 66 3F 00 00 00 00 CD CC 4C 3E 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 66 66 66 3F CD CC CC 3D 00 00 00 3F CD CC 4C 3E 00 00 00 00 00 00 00 00 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 19)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D CD CC CC 3D CD CC CC 3E CD CC CC 3D CD CC 4C 3E CD CC 4C BE 00 00 00 00 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D CD CC CC 3D CD CC CC 3E CD CC CC 3D CD CC 4C 3E CD CC 4C BE 00 00 00 00 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 20)
                    {
                        CharacterDetails.FilterAoB.value = "CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D CD CC CC 3D CD CC CC 3E 00 00 80 3F 9A 99 99 3E 00 00 00 00 CD CC 4C BE 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D CD CC CC 3D CD CC CC 3E 00 00 80 3F 9A 99 99 3E 00 00 00 00 CD CC 4C BE 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 21)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00");
                    }
                    if (Filters.SelectedIndex == 22)
                    {
                        CharacterDetails.FilterAoB.value = "9A 99 99 3E 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 33 3F 9A 99 99 3E 00 00 80 3F CD CC 4C BF 00 00 80 BF 00 00 80 3F";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "9A 99 99 3E 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 33 3F 9A 99 99 3E 00 00 80 3F CD CC 4C BF 00 00 80 BF 00 00 80 3F");
                    }
                    if (Filters.SelectedIndex == 23)
                    {
                        CharacterDetails.FilterAoB.value = "00 00 80 3E 00 00 00 3F CD CC CC BE CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), "bytes", "00 00 80 3E 00 00 00 3F CD CC CC BE CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                    }
                    System.Threading.Tasks.Task.Delay(25).Wait();
                    CharacterDetails.FilterAoB.SpecialActivate = false;
                }
            }
        }

        private void SaveButtonX_Click(object sender, RoutedEventArgs e)
        {
            CharacterDetailsViewModel.CurrentlySavingFilter = true;
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                FiltersDetails Save1 = new FiltersDetails(); // CharacterDetails is class with all address
                Save1.FilterAoB = CharacterDetails.FilterAoB;
                string details = JsonConvert.SerializeObject(Save1, Formatting.Indented);
                File.WriteAllText(dig.FileName, details);
                CharacterDetailsViewModel.CurrentlySavingFilter = false;
            }
            else CharacterDetailsViewModel.CurrentlySavingFilter = false;
        }

        private void BrightSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            {
                if (BrightSlider.IsMouseOver || BrightSlider.IsKeyboardFocusWithin)
                {
                    BrightSlider.ValueChanged -= BrightSlider_ValueChange;
                    BrightSlider.ValueChanged += BrightSlider_ValueChange;
                }
                if (BrightUpDown.IsMouseOver || BrightUpDown.IsKeyboardFocusWithin)
                {
                    BrightUpDown.ValueChanged -= Bright_ValueChange;
                    BrightUpDown.ValueChanged += Bright_ValueChange;
                }
            }
        }

        private void Bright_ValueChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BrightUpDown.Value.HasValue)
            {
                CharacterDetails.Brightness.value = (float)BrightUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Brightness), "float", BrightUpDown.Value.ToString());
            }
            BrightUpDown.ValueChanged -= Bright_ValueChange;
        }

        private void BrightSlider_ValueChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BrightUpDown.Value.HasValue)
            {
                CharacterDetails.Brightness.value = (float)BrightSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Brightness), "float", BrightSlider.Value.ToString());
            }
            BrightSlider.ValueChanged -= BrightSlider_ValueChange;
        }

        private void ExpoSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            {
                if (ExpoSlider.IsMouseOver || ExpoSlider.IsKeyboardFocusWithin)
                {
                    ExpoSlider.ValueChanged -= ExpoSliderChange;
                    ExpoSlider.ValueChanged += ExpoSliderChange;
                }
                if (ExpoUpDown.IsMouseOver || ExpoUpDown.IsKeyboardFocusWithin)
                {
                    ExpoUpDown.ValueChanged -= Expo_ValueChange;
                    ExpoUpDown.ValueChanged += Expo_ValueChange;
                }
            }
        }

        private void ExpoSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ExpoUpDown.Value.HasValue)
            {
                CharacterDetails.Exposure.value = (float)ExpoSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Exposure), "float", ExpoSlider.Value.ToString());
            }
            ExpoSlider.ValueChanged -= ExpoSliderChange;
        }

        private void Expo_ValueChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ExpoUpDown.Value.HasValue)
            {
                CharacterDetails.Exposure.value = (float)ExpoUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Exposure), "float", ExpoUpDown.Value.ToString());
            }
            ExpoUpDown.ValueChanged -= Expo_ValueChange;
        }

        private void ContrastSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            {
                if (ContrastSlider.IsMouseOver || ContrastSlider.IsKeyboardFocusWithin)
                {
                    ContrastSlider.ValueChanged -= ContrastSliderChange;
                    ContrastSlider.ValueChanged += ContrastSliderChange;
                }
                if (ContrastUpDown.IsMouseOver || ContrastUpDown.IsKeyboardFocusWithin)
                {
                    ContrastUpDown.ValueChanged -= ContrastUpDownChange;
                    ContrastUpDown.ValueChanged += ContrastUpDownChange;
                }
            }
        }
        private void ContrastSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ContrastUpDown.Value.HasValue)
            {
                CharacterDetails.Contrast.value = (float)ContrastSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Contrast), "float", ContrastSlider.Value.ToString());
            }
            ContrastSlider.ValueChanged -= ContrastSliderChange;
        }

        private void ContrastUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ContrastUpDown.Value.HasValue)
            {
                CharacterDetails.Contrast.value = (float)ContrastUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Contrast), "float", ContrastUpDown.Value.ToString());
            }
            ContrastUpDown.ValueChanged -= ContrastUpDownChange;
        }

        private void GammaSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (GammaSlider.IsMouseOver || GammaSlider.IsKeyboardFocusWithin)
            {
                GammaSlider.ValueChanged -= GammaSliderChange;
                GammaSlider.ValueChanged += GammaSliderChange;
            }
            if (GammaUpDown.IsMouseOver || GammaUpDown.IsKeyboardFocusWithin)
            {
                GammaUpDown.ValueChanged -= GammaUpDownChange;
                GammaUpDown.ValueChanged += GammaUpDownChange;
            }
        }

        private void GammaSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (GammaUpDown.Value.HasValue)
            {
                CharacterDetails.Gamma.value = (float)GammaSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Gamma), "float", GammaSlider.Value.ToString());
            }
            GammaSlider.ValueChanged -= GammaSliderChange;
        }

        private void GammaUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GammaUpDown.Value.HasValue)
            {
                CharacterDetails.Gamma.value = (float)GammaUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Gamma), "float", GammaUpDown.Value.ToString());
            }
            GammaUpDown.ValueChanged -= GammaUpDownChange;
        }

        private void RedSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (RedSlider.IsMouseOver || RedSlider.IsKeyboardFocusWithin)
            {
                RedSlider.ValueChanged -= RedSliderChange;
                RedSlider.ValueChanged += RedSliderChange;
            }
            if (RedUpDown.IsMouseOver || RedUpDown.IsKeyboardFocusWithin)
            {
                RedUpDown.ValueChanged -= RedUpDownChange;
                RedUpDown.ValueChanged += RedUpDownChange;
            }
        }

        private void RedSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (RedUpDown.Value.HasValue)
            {
                CharacterDetails.GRed.value = (float)RedSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.GRed), "float", RedSlider.Value.ToString());
            }
            RedSlider.ValueChanged -= RedSliderChange;
        }

        private void RedUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RedUpDown.Value.HasValue)
            {
                CharacterDetails.GRed.value = (float)RedUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.GRed), "float", RedUpDown.Value.ToString());
            }
            RedUpDown.ValueChanged -= RedUpDownChange;
        }

        private void GreenSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (GreenSlider.IsMouseOver || GreenSlider.IsKeyboardFocusWithin)
            {
                GreenSlider.ValueChanged -= GreenSliderChange;
                GreenSlider.ValueChanged += GreenSliderChange;
            }
            if (GreenUpDown.IsMouseOver || GreenUpDown.IsKeyboardFocusWithin)
            {
                GreenUpDown.ValueChanged -= GreenUpDownChange;
                GreenUpDown.ValueChanged += GreenUpDownChange;
            }
        }

        private void GreenSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (GreenUpDown.Value.HasValue)
            {
                CharacterDetails.GGreens.value = (float)GreenSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.GGreens), "float", GreenSlider.Value.ToString());
            }
            GreenSlider.ValueChanged -= GreenSliderChange;
        }

        private void GreenUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GreenUpDown.Value.HasValue)
            {
                CharacterDetails.GGreens.value = (float)GreenUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.GGreens), "float", GreenUpDown.Value.ToString());
            }
            GreenUpDown.ValueChanged -= GreenUpDownChange;
        }

        private void BlueSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BlueSlider.IsMouseOver || BlueSlider.IsKeyboardFocusWithin)
            {
                BlueSlider.ValueChanged -= BlueSliderChange;
                BlueSlider.ValueChanged += BlueSliderChange;
            }
            if (BlueUpDown.IsMouseOver || BlueUpDown.IsKeyboardFocusWithin)
            {
                BlueUpDown.ValueChanged -= BlueUpDownChange;
                BlueUpDown.ValueChanged += BlueUpDownChange;
            }
        }

        private void BlueSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BlueUpDown.Value.HasValue)
            {
                CharacterDetails.GBlue.value = (float)BlueSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.GBlue), "float", BlueSlider.Value.ToString());
            }
            BlueSlider.ValueChanged -= BlueSliderChange;
        }

        private void BlueUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BlueUpDown.Value.HasValue)
            {
                CharacterDetails.GBlue.value = (float)BlueUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.GBlue), "float", BlueUpDown.Value.ToString());
            }
            BlueUpDown.ValueChanged -= BlueUpDownChange;
        }

        private void HDRSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HDRSlider.IsMouseOver || HDRSlider.IsKeyboardFocusWithin)
            {
                HDRSlider.ValueChanged -= HDRSliderChange;
                HDRSlider.ValueChanged += HDRSliderChange;
            }
            if (HDRUpDown.IsMouseOver || HDRUpDown.IsKeyboardFocusWithin)
            {
                HDRUpDown.ValueChanged -= HDRUpDownChange;
                HDRUpDown.ValueChanged += HDRUpDownChange;
            }
        }

        private void HDRSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (HDRUpDown.Value.HasValue)
            {
                CharacterDetails.HDR.value = (float)HDRSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.HDR), "float", HDRSlider.Value.ToString());
            }
            HDRSlider.ValueChanged -= HDRSliderChange;
        }

        private void HDRUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HDRUpDown.Value.HasValue)
            {
                CharacterDetails.HDR.value = (float)HDRUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.HDR), "float", HDRUpDown.Value.ToString());
            }
            HDRUpDown.ValueChanged -= HDRUpDownChange;
        }

        private void SHDRSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (SHDRSlider.IsMouseOver || SHDRSlider.IsKeyboardFocusWithin)
            {
                SHDRSlider.ValueChanged -= SHDRSliderChange;
                SHDRSlider.ValueChanged += SHDRSliderChange;
            }
            if (SHDRUpDown.IsMouseOver || SHDRUpDown.IsKeyboardFocusWithin)
            {
                SHDRUpDown.ValueChanged -= SHDRUpDownChange;
                SHDRUpDown.ValueChanged += SHDRUpDownChange;
            }
        }

        private void SHDRSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SHDRUpDown.Value.HasValue)
            {
                CharacterDetails.SHDR.value = (float)SHDRSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.SHDR), "float", SHDRSlider.Value.ToString());
            }
            SHDRSlider.ValueChanged -= SHDRSliderChange;
        }

        private void SHDRUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (SHDRUpDown.Value.HasValue)
            {
                CharacterDetails.SHDR.value = (float)SHDRUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.SHDR), "float", SHDRUpDown.Value.ToString());
            }
            SHDRUpDown.ValueChanged -= SHDRUpDownChange;
        }

        private void FilmicSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (FilmicSlider.IsMouseOver || FilmicSlider.IsKeyboardFocusWithin)
            {
                FilmicSlider.ValueChanged -= FilmicSliderChange;
                FilmicSlider.ValueChanged += FilmicSliderChange;
            }
            if (SHDRUpDown.IsMouseOver || FilmicUpDown.IsKeyboardFocusWithin)
            {
                FilmicUpDown.ValueChanged -= FilmicUpDownChange;
                FilmicUpDown.ValueChanged += FilmicUpDownChange;
            }
        }

        private void FilmicSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (FilmicUpDown.Value.HasValue)
            {
                CharacterDetails.Filmic.value = (float)FilmicSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Filmic), "float", FilmicSlider.Value.ToString());
            }
            FilmicSlider.ValueChanged -= FilmicSliderChange;
        }

        private void FilmicUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (FilmicUpDown.Value.HasValue)
            {
                CharacterDetails.Filmic.value = (float)FilmicUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Filmic), "float", FilmicUpDown.Value.ToString());
            }
            FilmicUpDown.ValueChanged -= FilmicUpDownChange;
        }

        private void ColorfulnessSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ColorfulnessSlider.IsMouseOver || ColorfulnessSlider.IsKeyboardFocusWithin)
            {
                ColorfulnessSlider.ValueChanged -= ColorfulnessSliderChange;
                ColorfulnessSlider.ValueChanged += ColorfulnessSliderChange;
            }
            if (ColorfulnessUpDown.IsMouseOver || ColorfulnessUpDown.IsKeyboardFocusWithin)
            {
                ColorfulnessUpDown.ValueChanged -= ColorfulnessUpDownChange;
                ColorfulnessUpDown.ValueChanged += ColorfulnessUpDownChange;
            }
        }

        private void ColorfulnessSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ColorfulnessUpDown.Value.HasValue)
            {
                CharacterDetails.Colorfulness.value = (float)ColorfulnessSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Colorfulness), "float", ColorfulnessSlider.Value.ToString());
            }
            ColorfulnessSlider.ValueChanged -= ColorfulnessSliderChange;
        }

        private void ColorfulnessUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ColorfulnessUpDown.Value.HasValue)
            {
                CharacterDetails.Colorfulness.value = (float)ColorfulnessUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Colorfulness), "float", ColorfulnessUpDown.Value.ToString());
            }
            ColorfulnessUpDown.ValueChanged -= ColorfulnessUpDownChange;
        }

        private void Colorfulness2Slider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Colorfulness2Slider.IsMouseOver || Colorfulness2Slider.IsKeyboardFocusWithin)
            {
                Colorfulness2Slider.ValueChanged -= Colorfulness2SliderChange;
                Colorfulness2Slider.ValueChanged += Colorfulness2SliderChange;
            }
            if (Colorfulness2UpDown.IsMouseOver || Colorfulness2UpDown.IsKeyboardFocusWithin)
            {
                Colorfulness2UpDown.ValueChanged -= Colorfulness2UpDownChange;
                Colorfulness2UpDown.ValueChanged += Colorfulness2UpDownChange;
            }
        }

        private void Colorfulness2SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Colorfulness2UpDown.Value.HasValue)
            {
                CharacterDetails.Colorfulnesss2.value = (float)Colorfulness2Slider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Colorfulnesss2), "float", Colorfulness2Slider.Value.ToString());
            }
            Colorfulness2Slider.ValueChanged -= Colorfulness2SliderChange;
        }

        private void Colorfulness2UpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Colorfulness2UpDown.Value.HasValue)
            {
                CharacterDetails.Colorfulnesss2.value = (float)Colorfulness2UpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Colorfulnesss2), "float", Colorfulness2UpDown.Value.ToString());
            }
            Colorfulness2UpDown.ValueChanged -= Colorfulness2UpDownChange;
        }

        private void Contrast2Slider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            {
                if (Contrast2Slider.IsMouseOver || Contrast2Slider.IsKeyboardFocusWithin)
                {
                    Contrast2Slider.ValueChanged -= Contrast2SliderChange;
                    Contrast2Slider.ValueChanged += Contrast2SliderChange;
                }
                if (Contrast2UpDown.IsMouseOver || Contrast2UpDown.IsKeyboardFocusWithin)
                {
                    Contrast2UpDown.ValueChanged -= Contrast2UpDownChange;
                    Contrast2UpDown.ValueChanged += Contrast2UpDownChange;
                }
            }
        }

        private void Contrast2SliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Contrast2UpDown.Value.HasValue)
            {
                CharacterDetails.Contrast2.value = (float)Contrast2Slider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Contrast2), "float", Contrast2Slider.Value.ToString());
            }
            Contrast2Slider.ValueChanged -= Contrast2SliderChange;
        }

        private void Contrast2UpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Contrast2UpDown.Value.HasValue)
            {
                CharacterDetails.Contrast2.value = (float)Contrast2UpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Contrast2), "float", Contrast2UpDown.Value.ToString());
            }
            Contrast2UpDown.ValueChanged -= Contrast2UpDownChange;
        }

        private void VibranceSlider_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            {
                if (VibranceSlider.IsMouseOver || VibranceSlider.IsKeyboardFocusWithin)
                {
                    VibranceSlider.ValueChanged -= VibranceSliderChange;
                    VibranceSlider.ValueChanged += VibranceSliderChange;
                }
                if (VibranceUpDown.IsMouseOver || VibranceUpDown.IsKeyboardFocusWithin)
                {
                    VibranceUpDown.ValueChanged -= VibranceUpDownChange;
                    VibranceUpDown.ValueChanged += VibranceUpDownChange;
                }
            }
        }

        private void VibranceSliderChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VibranceUpDown.Value.HasValue)
            {
                CharacterDetails.Vibrance.value = (float)VibranceSlider.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Vibrance), "float", VibranceSlider.Value.ToString());
            }
            VibranceSlider.ValueChanged -= VibranceSliderChange;
        }

        private void VibranceUpDownChange(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (VibranceUpDown.Value.HasValue)
            {
                CharacterDetails.Vibrance.value = (float)VibranceUpDown.Value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.Vibrance), "float", VibranceUpDown.Value.ToString());
            }
            VibranceUpDown.ValueChanged -= VibranceUpDownChange;
        }

        private void FreezeAlll_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetailsViewModel.FreezeAll = false;
        }

        private void FreezeAlll_Checked(object sender, RoutedEventArgs e)
        {
            CharacterDetailsViewModel.FreezeAll = true;
        }

        private void EnableEditing_Checked(object sender, RoutedEventArgs e)
        {
            CharacterDetailsViewModel.EnabledEditing = true;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterEnable), "byte", "40");
        }

        private void EnableEditing_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetailsViewModel.EnabledEditing = false;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterEnable), "byte", "00");
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                FiltersDetails load1 = JsonConvert.DeserializeObject<FiltersDetails>(File.ReadAllText(dig.FileName));
                CharacterDetailsViewModel.EnabledEditing = true;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterEnable), "byte", "40");
                CharacterDetails.FilterAoB.value = load1.FilterAoB.value;
                var LoadFilter = MemoryManager.StringToByteArray(load1.FilterAoB.value.Replace(" ", string.Empty));
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, Settings.Instance.Character.FilterAoB), LoadFilter);
            }
        }

        private void DigitCheckInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterDetails.MusicBGM.value = int.Parse(BGMTEXT.Text);
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.MusicOffset, Settings.Instance.Character.Music2), "int", BGMTEXT.Text);
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.MusicOffset, Settings.Instance.Character.Music), "int", BGMTEXT.Text);
        }

        private void SearchBGM_Click(object sender, RoutedEventArgs e)
        {
            WorldFlyout.IsOpen = !WorldFlyout.IsOpen;
        }

        private void RenderButton_Checked(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.CharacterRenderAddress, "bytes", "0x90 0x90 0x90 0x90 0x90");
        }

        private void RenderButton_Unchecked(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.CharacterRenderAddress, "bytes", "0xE9 0xB8 0x00 0x00 0x00");
        }

        private void TimeButton_Click(object sender, RoutedEventArgs e)
        {
            Timexd.Value = 0;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.TimeAddress, Settings.Instance.Character.TimeControl), "int", "0");
        }

        private async void TimeButtonLock_Checked(object sender, RoutedEventArgs e)
        {
            istimeLocked = true;
            while(istimeLocked)
            {
                if (!istimeLocked) break;
                if (TimeControlUpDown.Value == 0) TimeControlUpDown.Value += 86400;
                TimeControlUpDown.Value -= 1;
                if (TimeControlUpDown.Value == int.MinValue) TimeControlUpDown.Value += 86400;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.TimeAddress, Settings.Instance.Character.TimeControl), "int", TimeControlUpDown.Value.ToString());
                await System.Threading.Tasks.Task.Delay(37);
            }
        }

        private void TimeButtonLock_Unchecked(object sender, RoutedEventArgs e)
        {
            istimeLocked = false;
        }

        private void ResetCams_Click(object sender, RoutedEventArgs e)
        {
            CharacterDetails.CameraHeight2.value = 0;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight2), "float", "0");
            CharacterDetails.CameraYAMax.value = -1.48353f;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), "float", CharacterDetails.CameraYAMax.value.ToString());
            CharacterDetails.CameraYAMin.value = 0.78540f;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), "float", CharacterDetails.CameraYAMin.value.ToString());
            CharacterDetails.FOV2.value = 0;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), "float", "0");
            CharacterDetails.Max.value = 20;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), "float", "20");
            CharacterDetails.Min.value = (float)1.50;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), "float", "1.50");
            CharacterDetails.CZoom.value = 20;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), "float", "20");
            CharacterDetails.FOVC.value = 0.78f;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), "float", CharacterDetails.FOVC.value.ToString());
            CharacterDetails.FOVMAX.value = 0.78f;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), "float", CharacterDetails.FOVMAX.value.ToString());
            CharacterDetails.CameraUpDown.value = -0.21952191f;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), "float", CharacterDetails.CameraUpDown.value.ToString());
        }

        private void Renda_Click(object sender, RoutedEventArgs e)
        {
            var Old= System.BitConverter.GetBytes(MemoryManager.Instance.MemLib.read2Byte(MemoryManager.Instance.CharacterRenderAddress2));
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.CharacterRenderAddress2, "bytes", "0x00 0x00");
            System.Threading.Tasks.Task.Delay(50).Wait();
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.CharacterRenderAddress2, Old);
        }
        private void CamAngleVC(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamAngleY.Value.HasValue)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CamAngleY), "float", CamAngleY.Value.ToString());
            }
            CamAngleY.ValueChanged -= CamAngleVC;
        }
        private void CamAngleY_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamAngleY.IsMouseOver || CamAngleY.IsKeyboardFocusWithin)
            {
                CamAngleY.ValueChanged -= CamAngleVC;
                CamAngleY.ValueChanged += CamAngleVC;
            }
        }
        private void CamAngleVC2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamAngleX.Value.HasValue)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CamAngleX), "float", CamAngleX.Value.ToString());
            }
            CamAngleX.ValueChanged -= CamAngleVC2;
        }
        private void CamAngleX_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (CamAngleX.IsMouseOver || CamAngleX.IsKeyboardFocusWithin)
            {
                CamAngleX.ValueChanged -= CamAngleVC2;
                CamAngleX.ValueChanged += CamAngleVC2;
            }
        }

        private void SaveCamAngle_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.CamAngleX = (float)CamAngleX.Value;
            SaveSettings.Default.CamAngleY = (float)CamAngleY.Value;
        }

        private void LoadCamAngle_Click(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CamAngleX), "float", SaveSettings.Default.CamAngleX.ToString());
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CamAngleY), "float", SaveSettings.Default.CamAngleY.ToString());
        }
    }
}