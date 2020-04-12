using ConceptMatrix.Commands;
using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using System;
using System.ComponentModel;
using System.Threading;
using ConceptMatrix.Resx;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;
using ConceptMatrix.Views;

namespace ConceptMatrix.ViewModel
{
    public class CharacterDetailsViewModel : BaseViewModel
    {
        public CharacterDetails CharacterDetails { get => (CharacterDetails)model; set => model = value; }

		public static string eOffset = "8";
        public static bool FreezeAll = false;
        public static bool EnabledEditing = false;
        public static bool CurrentlySavingFilter = false;
        public static bool CheckingGPose = false;
        public bool InGpose = false;
        public int WritingCheck = 0;
        public static UIntPtr OldMemoryLocation;
        public static string baseAddr;
        public static Views.CharacterDetailsView Viewtime;

        private readonly Mem m = MemoryManager.Instance.MemLib;
        private CharacterOffsets c = Settings.Instance.Character;
        private string GAS(params string[] args) => MemoryManager.GetAddressString(args);

		public RefreshEntitiesCommand RefreshEntitiesCommand { get; }
		public CharacterDetailsViewModel(Mediator mediator) : base(mediator)
        {
            model = new CharacterDetails();
            model.PropertyChanged += Model_PropertyChanged;
            RefreshEntitiesCommand = new RefreshEntitiesCommand(this);
            // refresh the list initially
            Refresh();
            mediator.Work += Work;

            mediator.EntitySelection += (offset) => eOffset = offset;
        }
        /// <summary>
        /// Model property changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedIndex")
                mediator.SendEntitySelection(((CharacterDetails.SelectedIndex + 1) * 8).ToString("X"));
        }
        public void Refresh()
        {
            try
            {
                // clear the entity list
                CharacterDetails.Names.Clear();
                // loop over entity list size
                float x1 = 0;
                float y1 = 0;
                float z1 = 0;
                if (CharacterDetails.GposeMode && CharacterDetails.TargetModeActive)
                {
                    for (var i = 0; i < m.readLong(MemoryManager.Instance.GposeEntityOffset); i++)
                    {
                        int Test = 0;
                        var addr = GAS(MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, ((i + 1) * 8).ToString("X")), c.Name);
                        var x2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.GposeAddress, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.X));
                        var y2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.GposeAddress, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.Y));
                        var z2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.GposeAddress, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.Z));
                        if (i == 0)
                        {
                            x1 = x2;
                            y1 = y2;
                            z1 = z2;
                        }
                        else
                        {
                            Test = (int)Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2)));
                        }
                        var name = m.readString(addr);
                        if (name.IndexOf('\0') != -1)
                            name = name.Substring(0, name.IndexOf('\0'));
                        if (i != 0) name += $" ({Test})";
                        CharacterDetails.Names.Add(name);
                    }
                }
                else if (CharacterDetails.GposeMode && !CharacterDetails.TargetModeActive)
                {
                    for (var i = 0; i < m.readLong(MemoryManager.Instance.GposeEntityOffset); i++)
                    {
                        int Test = 0;
                        var addr = GAS(MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, ((i + 1) * 8).ToString("X")), c.Name);
                        var x2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.X));
                        var y2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.Y));
                        var z2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.Z));
                        if (i == 0)
                        {
                            x1 = x2;
                            y1 = y2;
                            z1 = z2;
                        }
                        else
                        {
                            Test = (int)Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2)));
                        }
                        var name = m.readString(addr);
                        if (name.IndexOf('\0') != -1)
                            name = name.Substring(0, name.IndexOf('\0'));
                        if (i != 0) name += $" ({Test})";
                        CharacterDetails.Names.Add(name);
                    }
                }
                else
                {
                    for (var i = 0; i < m.readLong(MemoryManager.Instance.BaseAddress); i++)
                    {
                        int Test = 0;
                        var addr = GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, ((i + 1) * 8).ToString("X")), c.Name);
                        var x2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.X));
                        var y2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.Y));
                        var z2 = m.readFloat(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, ((i + 1) * 8).ToString("X")), c.Body.Base, c.Body.Position.Z));
                        if (i == 0)
                        {
                            x1 = x2;
                            y1 = y2;
                            z1 = z2;
                        }
                        else
                        {
                            Test = (int)Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2)));
                        }
                        var name = m.readString(addr);
                        if (name.IndexOf('\0') != -1)
                            name = name.Substring(0, name.IndexOf('\0'));
                        if (i != 0) name += $" ({Test})";
                        CharacterDetails.Names.Add(name);
                    }
                }
                // set the enable state
                CharacterDetails.IsEnabled = true;
                // set the index if its under 0
                if (CharacterDetails.SelectedIndex < 0)
                    CharacterDetails.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
        private void Work()
        {
            try
            {
                CharacterDetails.Territoryxd.value = m.readInt(GAS(MemoryManager.Instance.TerritoryAddress, c.Territory));
                CharacterDetails.TerritoryName = Extensions.TerritoryName(CharacterDetails.Territoryxd.value);
                if (CharacterDetails.GposeMode)
                {
                    if (CharacterDetails.TargetModeActive)
                        baseAddr = MemoryManager.Add(MemoryManager.Instance.GposeAddress, eOffset);
                    else baseAddr = MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, eOffset);
                }
                else baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset);

                if (CharacterDetails.TargetModeActive)
                {
                    if (!CharacterDetails.GposeMode) baseAddr = MemoryManager.Instance.TargetAddress;
                    else baseAddr = MemoryManager.Instance.GposeAddress;
                }
                var nameAddr = GAS(baseAddr, c.Name);
                var fcnameAddr = GAS(baseAddr, c.FCTag);
                var xdad = (byte)m.readByte(GAS(baseAddr, c.EntityType));
                var SubType = (byte)m.readByte(GAS(baseAddr, c.EntitySub));
                CharacterDetails.EntitySub.value = SubType;
                if(SubType==5)
                {
                    Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        MainViewModel.ViewTime.MonsterCheck.IsChecked = false;
                        MainViewModel.ViewTime.MonsterCheck.IsEnabled = false;
                        MainViewModel.ViewTime.MonsterNum.IsEnabled = false;
                        MainViewModel.ViewTime4.EntityBox.IsEnabled = false;
                        MainViewModel.ViewTime4.EntityCheck.IsChecked = false;
                        MainViewModel.ViewTime4.EntityCheck.IsEnabled = false;
                    });
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        MainViewModel.ViewTime.MonsterCheck.IsEnabled = true;
                        MainViewModel.ViewTime.MonsterNum.IsEnabled = true;
                        MainViewModel.ViewTime4.EntityBox.IsEnabled = true;
                        MainViewModel.ViewTime4.EntityCheck.IsEnabled = true;
                    });
                }
                if (!CharacterDetails.Name.freeze)
                {
                    var name = m.readString(nameAddr);
                    if (name.IndexOf('\0') != -1)
                        name = name.Substring(0, name.IndexOf('\0'));
                    CharacterDetails.Name.value = name;
                }
                if (!CharacterDetails.FCTag.freeze)
                {
                    var fcname = m.readString(fcnameAddr);
                    if (fcname.IndexOf('\0') != -1)
                        fcname = fcname.Substring(0, fcname.IndexOf('\0'));
                    if (xdad == 1)
                        CharacterDetails.FCTag.value = fcname;
                    if (xdad != 1)
                        CharacterDetails.FCTag.value = string.Empty;
                }
                if (!CurrentlySavingFilter)
                {
                    CharacterDetails.FilterAoB.value = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(MemoryManager.Instance.GposeFilters, c.FilterAoB), 60));
                    if (EnabledEditing)
                    {
                        m.writeMemory(GAS(MemoryManager.Instance.GposeFilters, c.FilterEnable), "byte", "40");
                        WritingCheck = 0;
                    }
                    else if (WritingCheck <= 3)
                    {
                        WritingCheck++;
                        if (CharacterDetails.FilterAoB.Selected == 0) m.writeMemory(GAS(MemoryManager.Instance.GposeFilters, c.FilterEnable), "byte", "00");
                    }
                    #region Gpose Filters
                    if (FreezeAll && !CharacterDetails.FilterAoB.SpecialActivate)
                    {
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.HDR), CharacterDetails.HDR.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Brightness), CharacterDetails.Brightness.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Contrast), CharacterDetails.Contrast.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Exposure), CharacterDetails.Exposure.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Filmic), CharacterDetails.Filmic.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.SHDR), CharacterDetails.SHDR.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Colorfulness), CharacterDetails.Colorfulness.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Contrast2), CharacterDetails.Contrast2.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Colorfulnesss2), CharacterDetails.Colorfulnesss2.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Vibrance), CharacterDetails.Vibrance.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.Gamma), CharacterDetails.Gamma.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.GBlue), CharacterDetails.GBlue.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.GGreens), CharacterDetails.GGreens.GetBytes());
                        m.writeBytes(GAS(MemoryManager.Instance.GposeFilters, c.GRed), CharacterDetails.GRed.GetBytes());
                    }
                    else
                    {
                        byte[] FIlterBytes = m.readBytes(GAS(MemoryManager.Instance.GposeFilters, c.Brightness), 60);
                        CharacterDetails.Brightness.value = BitConverter.ToSingle(FIlterBytes, 0);
                        CharacterDetails.Exposure.value = BitConverter.ToSingle(FIlterBytes, 4);
                        CharacterDetails.Filmic.value = BitConverter.ToSingle(FIlterBytes, 8);
                        CharacterDetails.SHDR.value = BitConverter.ToSingle(FIlterBytes, 12);
                        CharacterDetails.Colorfulness.value = BitConverter.ToSingle(FIlterBytes, 20);
                        CharacterDetails.Contrast.value = BitConverter.ToSingle(FIlterBytes, 24);
                        CharacterDetails.Contrast2.value = BitConverter.ToSingle(FIlterBytes, 28);
                        CharacterDetails.GRed.value = BitConverter.ToSingle(FIlterBytes, 32);
                        CharacterDetails.GGreens.value = BitConverter.ToSingle(FIlterBytes, 36);
                        CharacterDetails.GBlue.value = BitConverter.ToSingle(FIlterBytes, 40);
                        CharacterDetails.Gamma.value = BitConverter.ToSingle(FIlterBytes, 44);
                        CharacterDetails.Vibrance.value = BitConverter.ToSingle(FIlterBytes, 48);
                        CharacterDetails.Colorfulnesss2.value = BitConverter.ToSingle(FIlterBytes, 52);
                        CharacterDetails.HDR.value = BitConverter.ToSingle(FIlterBytes, 56);
                    }
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 0;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE 00 00 80 3F 00 00 00 00 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 1;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC 4C 3E CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D 66 66 66 3F 9A 99 99 3E 00 00 00 00 CD CC 4C 3E 00 00 00 00 CD CC 4C BE 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 2;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 3;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 4;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 00 00 00 00 CD CC CC 3D CD CC 4C BE 00 00 00 00 CD CC 4C BE 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 5;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC 4C 3E 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00 CD CC 4C 3F 9A 99 19 3F CD CC CC 3E CD CC CC 3E 9A 99 19 BF CD CC 4C 3E CD CC CC 3D"))
                        CharacterDetails.FilterAoB.Selected = 6;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC 4C 3E CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E CD CC CC BD 00 00 00 00 CD CC 4C 3F CD CC 4C 3F 00 00 80 3F CD CC CC 3E 00 00 00 00 CD CC 4C 3E 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 7;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 00 CD CC 4C 3F 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00 33 33 33 3F 9A 99 19 3F 00 00 00 3F CD CC CC 3E 9A 99 19 BF CD CC 4C 3E 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 8;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 3F 00 00 00 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E 00 00 00 3F 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 9;
                    if (CharacterDetails.FilterAoB.value.Contains("66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 10;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3E 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C 3E CD CC CC BD CD CC 4C BE"))
                        CharacterDetails.FilterAoB.Selected = 11;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3E 33 33 33 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE 00 00 80 3F 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 12;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 00 CD CC CC 3E CD CC CC BE 9A 99 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE CD CC 4C 3E 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 13;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 00 33 33 B3 3E CD CC CC BE CD CC CC 3E 00 00 00 00 CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 99 BE CD CC CC 3E 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 14;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3D CD CC CC 3E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 9A 99 19 3F 9A 99 19 3F 9A 99 19 3F CD CC CC BD CD CC 4C 3E 00 00 00 00 CD CC 4C BE"))
                        CharacterDetails.FilterAoB.Selected = 15;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3D 9A 99 99 3E 00 00 00 00 CD CC 4C BE 00 00 00 00 CD CC CC BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 16;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3D CD CC CC 3E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 CD CC CC 3D 9A 99 99 BE 33 33 33 3F 33 33 33 3F 33 33 33 3F CD CC 4C BE CD CC 4C 3E CD CC 4C BE CD CC 4C BE"))
                        CharacterDetails.FilterAoB.Selected = 17;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3D 66 66 66 3F 00 00 00 00 CD CC 4C 3E 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 66 66 66 3F CD CC CC 3D 00 00 00 3F CD CC 4C 3E 00 00 00 00 00 00 00 00 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 18;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D CD CC CC 3D CD CC CC 3E CD CC CC 3D CD CC 4C 3E CD CC 4C BE 00 00 00 00 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 19;
                    if (CharacterDetails.FilterAoB.value.Contains("CD CC CC 3D 66 66 66 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 CD CC CC 3D CD CC CC 3D CD CC CC 3E 00 00 80 3F 9A 99 99 3E 00 00 00 00 CD CC 4C BE 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 20;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 CD CC 4C BE CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 9A 99 19 3F 00 00 00 00 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 21;
                    if (CharacterDetails.FilterAoB.value.Contains("9A 99 99 3E 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 33 3F 9A 99 99 3E 00 00 80 3F CD CC 4C BF 00 00 80 BF 00 00 80 3F"))
                        CharacterDetails.FilterAoB.Selected = 22;
                    if (CharacterDetails.FilterAoB.value.Contains("00 00 80 3E 00 00 00 3F CD CC CC BE CD CC 4C BE 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00"))
                        CharacterDetails.FilterAoB.Selected = 23;
                }
                #endregion

                if (!CheckingGPose)
                {
                    if (m.readByte(GAS(MemoryManager.Instance.GposeCheckAddress)) == 0)
                    {
                        if (InGpose)
                        {
                            CharacterDetails.GposeMode = false;
                            InGpose = false;

                            Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                            {
                                MainViewModel.ViewTime5.PoseMatrixSetting.IsEnabled = false;
                                MainViewModel.ViewTime5.EditModeButton.IsChecked = false;
                                PoseMatrixView.PosingMatrix.PoseMatrixSetting.IsEnabled = false;
                                PoseMatrixView.PosingMatrix.EditModeButton.IsChecked = false;
                                MainViewModel.ViewTime5.LoadCMP.IsEnabled = false;
                                MainViewModel.ViewTime5.AdvLoadCMP.IsEnabled = false;
                                PoseMatrixView.PosingMatrix.LoadCMP.IsEnabled = false;
                                PoseMatrixView.PosingMatrix.AdvLoadCMP.IsEnabled = false;
                            });
                        }
                    }
                    else if (m.readByte(GAS(MemoryManager.Instance.GposeCheckAddress)) == 1 && m.readByte(GAS(MemoryManager.Instance.GposeCheck2Address)) == 4)
                    {
                        if (!InGpose)
                        {
                            CharacterDetails.SelectedIndex = 0;
                            CharacterDetails.GposeMode = true;

                            #region Equipment Fix

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Job)) <= 0)
                            {
                                CharacterDetails.Job.value = 0;
                                CharacterDetails.WeaponBase.value = 0;
                                CharacterDetails.WeaponV.value = 0;
                                CharacterDetails.WeaponDye.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Job), "bytes", "2D 01 1F 00 01 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Offhand)) <= 0)
                            {
                                CharacterDetails.Offhand.value = 0;
                                CharacterDetails.OffhandBase.value = 0;
                                CharacterDetails.OffhandV.value = 0;
                                CharacterDetails.OffhandDye.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Offhand), "bytes", "00 00 00 00 00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.HeadPiece)) <= 0)
                            {
                                CharacterDetails.HeadPiece.value = 0;
                                CharacterDetails.HeadV.value = 0;
                                CharacterDetails.HeadDye.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.HeadPiece), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Chest)) <= 0)
                            {
                                CharacterDetails.Chest.value = 0;
                                CharacterDetails.ChestV.value = 0;
                                CharacterDetails.ChestDye.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Chest), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Arms)) <= 0)
                            {
                                CharacterDetails.Arms.value = 0;
                                CharacterDetails.ArmsV.value = 0;
                                CharacterDetails.ArmsDye.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Arms), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Legs)) <= 0)
                            {
                                CharacterDetails.Legs.value = 0;
                                CharacterDetails.LegsV.value = 0;
                                CharacterDetails.LegsDye.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Legs), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Feet)) <= 0)
                            {
                                CharacterDetails.Feet.value = 0;
                                CharacterDetails.FeetVa.value = 0;
                                CharacterDetails.FeetDye.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Feet), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Neck)) <= 0)
                            {
                                CharacterDetails.Neck.value = 0;
                                CharacterDetails.NeckVa.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Neck), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Wrist)) <= 0)
                            {
                                CharacterDetails.Wrist.value = 0;
                                CharacterDetails.WristVa.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Wrist), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Ear)) <= 0)
                            {
                                CharacterDetails.Ear.value = 0;
                                CharacterDetails.EarVa.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Ear), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.RFinger)) <= 0)
                            {
                                CharacterDetails.RFinger.value = 0;
                                CharacterDetails.RFingerVa.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.RFinger), "bytes", "00 00 00 00");
                            }

                            if (m.read2Byte(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.LFinger)) <= 0)
                            {
                                CharacterDetails.LFinger.value = 0;
                                CharacterDetails.LFingerVa.value = 0;
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.LFinger), "bytes", "00 00 00 00");
                            }
                            #endregion

                            m.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.EntityType), "byte", "0x02");
                            Task.Delay(1500).Wait();
                            m.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.EntityType), "byte", "0x01");
                            Task.Delay(50).Wait();
                            m.writeMemory(GAS(MemoryManager.Instance.GposeAddress, c.EntityType), "byte", "0x01");
                            InGpose = true;

                            Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                            {
                                MainViewModel.MainTime.ActorDataUnfreeze();
                                MainViewModel.ViewTime5.PoseMatrixSetting.IsEnabled = true;
                                PoseMatrixView.PosingMatrix.PoseMatrixSetting.IsEnabled = true;
                                MainViewModel.ViewTime5.LoadCMP.IsEnabled = true;
                                MainViewModel.ViewTime5.AdvLoadCMP.IsEnabled = true;
                                PoseMatrixView.PosingMatrix.LoadCMP.IsEnabled = true;
                                PoseMatrixView.PosingMatrix.AdvLoadCMP.IsEnabled = true;
                            });
                        }
                    }
                }
                byte[] CharacterBytes = m.readBytes(GAS(baseAddr, c.Race), 26);
                
                #region Actor AoB
                if (!CharacterDetails.Race.freeze) CharacterDetails.Race.value = CharacterBytes[0];
                if (!CharacterDetails.Gender.freeze) CharacterDetails.Gender.value = CharacterBytes[1];
                if (!CharacterDetails.BodyType.freeze) CharacterDetails.BodyType.value = CharacterBytes[2];
                if (!CharacterDetails.RHeight.freeze) CharacterDetails.RHeight.value = CharacterBytes[3];
                if (!CharacterDetails.Clan.freeze) CharacterDetails.Clan.value = CharacterBytes[4];
                if (!CharacterDetails.Head.freeze) CharacterDetails.Head.value = CharacterBytes[5];
                if (!CharacterDetails.Hair.freeze) CharacterDetails.Hair.value = CharacterBytes[6];
                if (!CharacterDetails.Highlights.freeze)
                {
                    CharacterDetails.Highlights.value = CharacterBytes[7];
                    if (CharacterBytes[7] >= 80) CharacterDetails.Highlights.SpecialActivate = true;
                    else CharacterDetails.Highlights.SpecialActivate = false;
                }
                if (!CharacterDetails.Skintone.freeze) CharacterDetails.Skintone.value = CharacterBytes[8];
                if (!CharacterDetails.RightEye.freeze) CharacterDetails.RightEye.value = CharacterBytes[9];
                if (!CharacterDetails.HairTone.freeze) CharacterDetails.HairTone.value = CharacterBytes[10];
                if (!CharacterDetails.HighlightTone.freeze) CharacterDetails.HighlightTone.value = CharacterBytes[11];
                if (!CharacterDetails.FacialFeatures.freeze) CharacterDetails.FacialFeatures.value = CharacterBytes[12];
                if (!CharacterDetails.LimbalEyes.freeze) CharacterDetails.LimbalEyes.value = CharacterBytes[13];
                if (!CharacterDetails.EyeBrowType.freeze) CharacterDetails.EyeBrowType.value = CharacterBytes[14];
                if (!CharacterDetails.LeftEye.freeze) CharacterDetails.LeftEye.value = CharacterBytes[15];
                if (!CharacterDetails.Eye.freeze) CharacterDetails.Eye.value = CharacterBytes[16];
                if (!CharacterDetails.Nose.freeze) CharacterDetails.Nose.value = CharacterBytes[17];
                if (!CharacterDetails.Jaw.freeze) CharacterDetails.Jaw.value = CharacterBytes[18];
                if (!CharacterDetails.Lips.freeze) CharacterDetails.Lips.value = CharacterBytes[19];
                if (!CharacterDetails.LipsTone.freeze) CharacterDetails.LipsTone.value = CharacterBytes[20];
                if (!CharacterDetails.TailorMuscle.freeze) CharacterDetails.TailorMuscle.value = CharacterBytes[21];
                if (!CharacterDetails.TailType.freeze) CharacterDetails.TailType.value = CharacterBytes[22];
                if (!CharacterDetails.RBust.freeze) CharacterDetails.RBust.value = CharacterBytes[23];
                if (!CharacterDetails.FacePaint.freeze) CharacterDetails.FacePaint.value = CharacterBytes[24];
                if (!CharacterDetails.FacePaintColor.freeze) CharacterDetails.FacePaintColor.value = CharacterBytes[25];
                #endregion
                if (!CharacterDetails.TestArray.freeze) CharacterDetails.TestArray.value = MemoryManager.ByteArrayToString(CharacterBytes);

                #region Mainhand & OffHand
                byte[] MainHandBytes = m.readBytes(GAS(baseAddr, c.Job), 7);
                if (!CharacterDetails.Job.freeze && !CharacterDetails.Job.Activated)
                {
                    CharacterDetails.Job.value = MainHandBytes[0] + MainHandBytes[1] * 256;
                    CharacterDetails.WeaponBase.value = MainHandBytes[2] + MainHandBytes[3] * 256;
                    CharacterDetails.WeaponV.value = MainHandBytes[4];
                    CharacterDetails.WeaponDye.value = MainHandBytes[6];
                }

                byte[] OffhandBytes = m.readBytes(GAS(baseAddr, c.Offhand), 7);
                if (!CharacterDetails.Offhand.freeze && !CharacterDetails.Offhand.Activated)
                {
                    CharacterDetails.Offhand.value = OffhandBytes[0] + OffhandBytes[1] * 256;
                    CharacterDetails.OffhandBase.value = OffhandBytes[2] + OffhandBytes[3] * 256;
                    CharacterDetails.OffhandV.value = OffhandBytes[4];
                    CharacterDetails.OffhandDye.value = OffhandBytes[6];
                }
                #endregion
                byte[] EquipmentArray = m.readBytes(GAS(baseAddr, c.HeadPiece), 39);
                #region Equipment Array - Non Mainhand+Offhand
                if (!CharacterDetails.HeadPiece.freeze && !CharacterDetails.HeadPiece.Activated)
                {
                    CharacterDetails.HeadPiece.value = (EquipmentArray[0] + EquipmentArray[1] * 256);
                    CharacterDetails.HeadV.value = EquipmentArray[2];
                    CharacterDetails.HeadDye.value = EquipmentArray[3];
                }
                if (!CharacterDetails.Chest.freeze && !CharacterDetails.Chest.Activated)
                {
                    CharacterDetails.Chest.value = (EquipmentArray[4] + EquipmentArray[5] * 256);
                    CharacterDetails.ChestV.value = EquipmentArray[6];
                    CharacterDetails.ChestDye.value = EquipmentArray[7];
                }
                if (!CharacterDetails.Arms.freeze && !CharacterDetails.Arms.Activated)
                {
                    CharacterDetails.Arms.value = (EquipmentArray[8] + EquipmentArray[9] * 256);
                    CharacterDetails.ArmsV.value = EquipmentArray[10];
                    CharacterDetails.ArmsDye.value = EquipmentArray[11];
                }
                if (!CharacterDetails.Legs.freeze && !CharacterDetails.Legs.Activated)
                {
                    CharacterDetails.Legs.value = (EquipmentArray[12] + EquipmentArray[13] * 256);
                    CharacterDetails.LegsV.value = EquipmentArray[14];
                    CharacterDetails.LegsDye.value = EquipmentArray[15];
                }
                if (!CharacterDetails.Feet.freeze && !CharacterDetails.Feet.Activated)
                {
                    CharacterDetails.Feet.value = (EquipmentArray[16] + EquipmentArray[17] * 256);
                    CharacterDetails.FeetVa.value = EquipmentArray[18];
                    CharacterDetails.FeetDye.value = EquipmentArray[19];
                }
                if (!CharacterDetails.Ear.freeze && !CharacterDetails.Ear.Activated)
                {
                    CharacterDetails.Ear.value = (EquipmentArray[20] + EquipmentArray[21] * 256);
                    CharacterDetails.EarVa.value = EquipmentArray[22];
                }
                if (!CharacterDetails.Neck.freeze && !CharacterDetails.Neck.Activated)
                {
                    CharacterDetails.Neck.value = (EquipmentArray[24] + EquipmentArray[25] * 256);
                    CharacterDetails.NeckVa.value = EquipmentArray[26];
                }
                if (!CharacterDetails.Wrist.freeze && !CharacterDetails.Wrist.Activated)
                {
                    CharacterDetails.Wrist.value = (EquipmentArray[28] + EquipmentArray[29] * 256);
                    CharacterDetails.WristVa.value = EquipmentArray[30];
                }
                if (!CharacterDetails.RFinger.freeze && !CharacterDetails.RFinger.Activated)
                {
                    CharacterDetails.RFinger.value = (EquipmentArray[32] + EquipmentArray[33] * 256);
                    CharacterDetails.RFingerVa.value = EquipmentArray[34];
                }
                if (!CharacterDetails.LFinger.freeze && !CharacterDetails.LFinger.Activated)
                {
                    CharacterDetails.LFinger.value = (EquipmentArray[36] + EquipmentArray[37] * 256);
                    CharacterDetails.LFingerVa.value = EquipmentArray[38];
                }
                #endregion
                if (!CharacterDetails.TestArray2.freeze) CharacterDetails.TestArray2.value = MemoryManager.ByteArrayToString(EquipmentArray);

                var ActorIdentfication = m.get64bitCode(GAS(baseAddr, c.ActorID));
                if (ActorIdentfication != OldMemoryLocation)
                {
                    OldMemoryLocation = ActorIdentfication;
                    //do check here if Editmode is enabled then read new bone values.
                    Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        if (PoseMatrixView.PosingMatrix.EditModeButton.IsChecked == true)
                        {
                            PoseMatrixView.PosingMatrix.EnableTertiary();
                            if (PoseMatrixViewModel.PoseVM.PointerPath != null) PoseMatrixView.PosingMatrix.GetPointers(PoseMatrixViewModel.PoseVM.TheButton);
                        }
                    });
                }

                if (!CharacterDetails.Voices.freeze) CharacterDetails.Voices.value = (byte)m.readByte(GAS(baseAddr, c.Voices));

                if (!CharacterDetails.Height.freeze) CharacterDetails.Height.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Height));

                if (!CharacterDetails.Title.freeze) CharacterDetails.Title.value = (int)m.read2Byte((GAS(baseAddr, c.Title)));

                if (!CharacterDetails.JobIco.freeze) CharacterDetails.JobIco.value = (byte)m.readByte(GAS(baseAddr, c.JobIco));

                #region Bust Scale
                byte[] BustScaleArray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bust.Base, c.Body.Bust.X), 12);

                if (!CharacterDetails.BustX.freeze) CharacterDetails.BustX.value = BitConverter.ToSingle(BustScaleArray, 0);

                if (!CharacterDetails.BustY.freeze) CharacterDetails.BustY.value = BitConverter.ToSingle(BustScaleArray, 4);

                if (!CharacterDetails.BustZ.freeze) CharacterDetails.BustZ.value = BitConverter.ToSingle(BustScaleArray, 8);
                #endregion

                #region Actor Position XYZ
                byte[] PositionArray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Position.X), 12);
                if (!CharacterDetails.X.freeze) CharacterDetails.X.value = BitConverter.ToSingle(PositionArray, 0);

                if (!CharacterDetails.Y.freeze) CharacterDetails.Y.value = BitConverter.ToSingle(PositionArray, 4);

                if (!CharacterDetails.Z.freeze) CharacterDetails.Z.value = BitConverter.ToSingle(PositionArray, 8);
                #endregion

                // Reading rotation values.
                #region Actor Rotation
                if (!CharacterDetails.RotateFreeze)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Position.Rotation), 16);
                    CharacterDetails.Rotation.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Rotation2.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Rotation3.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Rotation4.value = BitConverter.ToSingle(bytearray, 12);

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Rotation.value,
                        CharacterDetails.Rotation2.value,
                        CharacterDetails.Rotation3.value,
                        CharacterDetails.Rotation4.value
                    ).ToEulerAngles();

                    CharacterDetails.RotateX = (float)euler.X;
                    CharacterDetails.RotateY = (float)euler.Y;
                    CharacterDetails.RotateZ = (float)euler.Z;
                }
                #endregion

                lock (CharacterDetails.LinkedActors)
                {
                    CharacterDetails.IsLinked = CharacterDetails.LinkedActors.Exists(x => x.Name == CharacterDetails.Name.value);
                }
                if (!CharacterDetails.TailSize.freeze) CharacterDetails.TailSize.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.TailSize));

                if (!CharacterDetails.MuscleTone.freeze) CharacterDetails.MuscleTone.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.MuscleTone));

                if (!CharacterDetails.Transparency.freeze) CharacterDetails.Transparency.value = m.readFloat(GAS(baseAddr, c.Transparency));

                if (!CharacterDetails.ModelType.freeze) CharacterDetails.ModelType.value = (int)m.read2Byte((GAS(baseAddr, c.ModelType)));

                if (!CharacterDetails.DataPath.freeze) CharacterDetails.DataPath.value = (short)m.read2Byte((GAS(baseAddr, c.DataPath)));

                if (!CharacterDetails.NPCName.freeze) CharacterDetails.NPCName.value = (short)m.read2Byte((GAS(baseAddr, c.NPCName)));

                if (!CharacterDetails.NPCModel.freeze) CharacterDetails.NPCModel.value = (short)m.read2Byte((GAS(baseAddr, c.NPCModel)));

                CharacterDetails.AltCheckPlayerFrozen.value = (float)m.readFloat((GAS(baseAddr, c.AltCheckPlayerFrozen)));

                CharacterDetails.EmoteIsPlayerFrozen.value = (byte)m.readByte((GAS(baseAddr, c.EmoteIsPlayerFrozen)));

                if (CharacterDetails.AltCheckPlayerFrozen.value == 0) { Viewtime.FrozenPlayaLabel.Dispatcher.Invoke(new Action(() => { Viewtime.FrozenPlayaLabel.Content = MiscStrings.TargetActorIs; if (SaveSettings.Default.Theme == "Dark") Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.White; else Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.Black; })); }
                else if (CharacterDetails.EmoteIsPlayerFrozen.value == 0 && CharacterDetails.AltCheckPlayerFrozen.value == 1) { Viewtime.FrozenPlayaLabel.Dispatcher.Invoke(new Action(() => { Viewtime.FrozenPlayaLabel.Content = MiscStrings.TargetActorIs2; Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.Red; })); }
                else if (CharacterDetails.EmoteIsPlayerFrozen.value == 1 && CharacterDetails.AltCheckPlayerFrozen.value == 1) { Viewtime.FrozenPlayaLabel.Dispatcher.Invoke(new Action(() => { Viewtime.FrozenPlayaLabel.Content = MiscStrings.TargetActorIs3; Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.Green; })); }

                if (!CharacterDetails.Emote.freeze) CharacterDetails.Emote.value = (int)m.read2Byte((GAS(baseAddr, c.Emote)));

                if (!CharacterDetails.EntityType.freeze) CharacterDetails.EntityType.value = (byte)m.readByte(GAS(baseAddr, c.EntityType));

                if (!CharacterDetails.EmoteOld.freeze) CharacterDetails.EmoteOld.value = (int)m.read2Byte((GAS(baseAddr, c.EmoteOld)));

                if (!CharacterDetails.EmoteSpeed1.freeze) CharacterDetails.EmoteSpeed1.value = (float)m.readFloat((GAS(MemoryManager.Instance.GposeAddress, c.EmoteSpeed1)));

                if (!CharacterDetails.WeaponRed.freeze) CharacterDetails.WeaponRed.value = m.readFloat(GAS(baseAddr, c.WeaponRed));

                if (!CharacterDetails.WeaponGreen.freeze) CharacterDetails.WeaponGreen.value = m.readFloat(GAS(baseAddr, c.WeaponGreen));

                if (!CharacterDetails.WeaponBlue.freeze) CharacterDetails.WeaponBlue.value = m.readFloat(GAS(baseAddr, c.WeaponBlue));

                if (!CharacterDetails.WeaponZ.freeze) CharacterDetails.WeaponZ.value = m.readFloat(GAS(baseAddr, c.WeaponZ));

                if (!CharacterDetails.WeaponY.freeze) CharacterDetails.WeaponY.value = m.readFloat(GAS(baseAddr, c.WeaponY));

                if (!CharacterDetails.WeaponX.freeze) CharacterDetails.WeaponX.value = m.readFloat(GAS(baseAddr, c.WeaponX));

                if (!CharacterDetails.OffhandZ.freeze) CharacterDetails.OffhandZ.value = m.readFloat(GAS(baseAddr, c.OffhandZ));

                if (!CharacterDetails.OffhandY.freeze) CharacterDetails.OffhandY.value = m.readFloat(GAS(baseAddr, c.OffhandY));

                if (!CharacterDetails.OffhandX.freeze) CharacterDetails.OffhandX.value = m.readFloat(GAS(baseAddr, c.OffhandX));

                if (!CharacterDetails.OffhandBlue.freeze) CharacterDetails.OffhandBlue.value = m.readFloat(GAS(baseAddr, c.OffhandBlue));

                if (!CharacterDetails.OffhandGreen.freeze) CharacterDetails.OffhandGreen.value = m.readFloat(GAS(baseAddr, c.OffhandGreen));

                if (!CharacterDetails.OffhandRed.freeze) CharacterDetails.OffhandRed.value = m.readFloat(GAS(baseAddr, c.OffhandRed));

                if (!CharacterDetails.LimbalG.freeze) CharacterDetails.LimbalG.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LimbalG));

                if (!CharacterDetails.LimbalB.freeze) CharacterDetails.LimbalB.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LimbalB));

                if (!CharacterDetails.LimbalR.freeze) CharacterDetails.LimbalR.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LimbalR));

                if (!CharacterDetails.ScaleX.freeze) CharacterDetails.ScaleX.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.Body.Base, c.Body.Scale.X));

                if (!CharacterDetails.ScaleY.freeze) CharacterDetails.ScaleY.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.Body.Base, c.Body.Scale.Y));

                if (!CharacterDetails.ScaleZ.freeze) CharacterDetails.ScaleZ.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.Body.Base, c.Body.Scale.Z));

                if (!CharacterDetails.LipsB.freeze) CharacterDetails.LipsB.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LipsB));

                if (!CharacterDetails.LipsG.freeze) CharacterDetails.LipsG.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LipsG));

                if (!CharacterDetails.LipsR.freeze) CharacterDetails.LipsR.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LipsR));

                if (!CharacterDetails.LipsBrightness.freeze) CharacterDetails.LipsBrightness.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LipsBrightness));

                if (!CharacterDetails.RightEyeBlue.freeze) CharacterDetails.RightEyeBlue.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.RightEyeBlue));
                if (!CharacterDetails.RightEyeGreen.freeze) CharacterDetails.RightEyeGreen.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.RightEyeGreen));

                if (!CharacterDetails.RightEyeRed.freeze) CharacterDetails.RightEyeRed.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.RightEyeRed));
                if (!CharacterDetails.LeftEyeBlue.freeze) CharacterDetails.LeftEyeBlue.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LeftEyeBlue));

                if (!CharacterDetails.LeftEyeGreen.freeze) CharacterDetails.LeftEyeGreen.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LeftEyeGreen));

                if (!CharacterDetails.LeftEyeRed.freeze) CharacterDetails.LeftEyeRed.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.LeftEyeRed));

                if (!CharacterDetails.HighlightBluePigment.freeze) CharacterDetails.HighlightBluePigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HighlightBluePigment));

                if (!CharacterDetails.HighlightGreenPigment.freeze) CharacterDetails.HighlightGreenPigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HighlightGreenPigment));

                if (!CharacterDetails.HighlightRedPigment.freeze) CharacterDetails.HighlightRedPigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HighlightRedPigment));

                if (!CharacterDetails.HairGlowBlue.freeze) CharacterDetails.HairGlowBlue.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HairGlowBlue));

                if (!CharacterDetails.HairGlowGreen.freeze) CharacterDetails.HairGlowGreen.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HairGlowGreen));

                if (!CharacterDetails.HairGlowRed.freeze) CharacterDetails.HairGlowRed.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HairGlowRed));

                if (!CharacterDetails.HairBluePigment.freeze) CharacterDetails.HairBluePigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HairBluePigment));

                if (!CharacterDetails.HairGreenPigment.freeze) CharacterDetails.HairGreenPigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HairGreenPigment));

                if (!CharacterDetails.HairRedPigment.freeze) CharacterDetails.HairRedPigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.HairRedPigment));

                if (!CharacterDetails.SkinBlueGloss.freeze) CharacterDetails.SkinBlueGloss.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.SkinBlueGloss));

                if (!CharacterDetails.SkinGreenGloss.freeze) CharacterDetails.SkinGreenGloss.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.SkinGreenGloss));

                if (!CharacterDetails.SkinRedGloss.freeze) CharacterDetails.SkinRedGloss.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.SkinRedGloss));

                if (!CharacterDetails.SkinBluePigment.freeze) CharacterDetails.SkinBluePigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.SkinBluePigment));

                if (!CharacterDetails.SkinGreenPigment.freeze) CharacterDetails.SkinGreenPigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.SkinGreenPigment));

                if (!CharacterDetails.SkinRedPigment.freeze) CharacterDetails.SkinRedPigment.value = m.readFloat(GAS(CharacterDetailsViewModel.baseAddr, c.SkinRedPigment));

                if (!CharacterDetails.CameraHeight2.freeze) CharacterDetails.CameraHeight2.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CameraHeight2));

                if (!CharacterDetails.CameraYAMin.freeze) CharacterDetails.CameraYAMin.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CameraYAMin));

                if (!CharacterDetails.CameraYAMax.freeze) CharacterDetails.CameraYAMax.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CameraYAMax));

                if (!CharacterDetails.FOV2.freeze) CharacterDetails.FOV2.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.FOV2));

                if (!CharacterDetails.CameraUpDown.freeze) CharacterDetails.CameraUpDown.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CameraUpDown));

                if (!CharacterDetails.FOVC.freeze)
                {
                    CharacterDetails.FOVMAX.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.FOVMAX));
                    CharacterDetails.FOVC.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.FOVC));
                }
                if (!CharacterDetails.CZoom.freeze) CharacterDetails.CZoom.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CZoom));

                if (!CharacterDetails.Min.freeze) CharacterDetails.Min.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.Min));

                if (!CharacterDetails.Max.freeze) CharacterDetails.Max.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.Max));

                if (!CharacterDetails.CamAngleX.freeze) CharacterDetails.CamAngleX.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CamAngleX));

                if (!CharacterDetails.CamAngleY.freeze) CharacterDetails.CamAngleY.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CamAngleY));

                if (!CharacterDetails.CamPanX.freeze) CharacterDetails.CamPanX.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CamPanX));

                if (!CharacterDetails.CamPanY.freeze) CharacterDetails.CamPanY.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CamPanY));

                if (!CharacterDetails.CamZ.freeze && CharacterDetails.GposeMode)
                {
                    CharacterDetails.CamZ.value = m.readFloat(GAS(MemoryManager.Instance.GposeAddress, c.CamZ));
                }
                else if (!CharacterDetails.CamZ.freeze && !CharacterDetails.GposeMode) CharacterDetails.CamZ.value = 0;

                if (!CharacterDetails.CamY.freeze && CharacterDetails.GposeMode)
                {
                    CharacterDetails.CamY.value = m.readFloat(GAS(MemoryManager.Instance.GposeAddress, c.CamY));
                }
                else if (!CharacterDetails.CamY.freeze && !CharacterDetails.GposeMode) CharacterDetails.CamY.value = 0;

                if (!CharacterDetails.CamX.freeze && CharacterDetails.GposeMode)
                {
                    CharacterDetails.CamX.value = m.readFloat(GAS(MemoryManager.Instance.GposeAddress, c.CamX));
                }
                else if (!CharacterDetails.CamX.freeze && !CharacterDetails.GposeMode) CharacterDetails.CamX.value = 0;

                if (!CharacterDetails.FaceCamZ.freeze && CharacterDetails.GposeMode)
                {
                    CharacterDetails.FaceCamZ.value = m.readFloat(GAS(MemoryManager.Instance.GposeAddress, c.FaceCamZ));
                }
                else if (!CharacterDetails.FaceCamZ.freeze && !CharacterDetails.GposeMode) CharacterDetails.FaceCamZ.value = 0;

                if (!CharacterDetails.FaceCamY.freeze && CharacterDetails.GposeMode)
                {
                    CharacterDetails.FaceCamY.value = m.readFloat(GAS(MemoryManager.Instance.GposeAddress, c.FaceCamY));
                }
                else if (!CharacterDetails.FaceCamY.freeze && !CharacterDetails.GposeMode) CharacterDetails.FaceCamY.value = 0;

                if (!CharacterDetails.FaceCamX.freeze && CharacterDetails.GposeMode)
                {
                    CharacterDetails.FaceCamX.value = m.readFloat(GAS(MemoryManager.Instance.GposeAddress, c.FaceCamX));
                }
                else if (!CharacterDetails.FaceCamX.freeze && !CharacterDetails.GposeMode) CharacterDetails.FaceCamX.value = 0;

                if (!CharacterDetails.CamViewZ.freeze) CharacterDetails.CamViewZ.value = m.readFloat(GAS(baseAddr, c.CamViewZ));

                if (!CharacterDetails.CamViewY.freeze) CharacterDetails.CamViewY.value = m.readFloat(GAS(baseAddr, c.CamViewY));

                if (!CharacterDetails.CamViewX.freeze) CharacterDetails.CamViewX.value = m.readFloat(GAS(baseAddr, c.CamViewX));

                if (!CharacterDetails.StatusEffect.freeze) CharacterDetails.StatusEffect.value = (int)m.read2Byte(GAS(baseAddr, c.StatusEffect));
                if (!CharacterDetails.Weather.freeze) CharacterDetails.Weather.value = (byte)m.readByte(GAS(MemoryManager.Instance.WeatherAddress, c.Weather));
                if (!CharacterDetails.ForceWeather.freeze) CharacterDetails.ForceWeather.value = (ushort)m.read2Byte(GAS(MemoryManager.Instance.GposeFilters, c.ForceWeather));
                CharacterDetails.TimeControl.value = (int)m.readInt(GAS(MemoryManager.Instance.TimeAddress, c.TimeControl));
                if (!CharacterDetails.HeadPiece.Activated) CharacterDetails.HeadSlot.value = CharacterDetails.HeadPiece.value + "," + CharacterDetails.HeadV.value + "," + CharacterDetails.HeadDye.value;
                if (!CharacterDetails.Chest.Activated) CharacterDetails.BodySlot.value = CharacterDetails.Chest.value + "," + CharacterDetails.ChestV.value + "," + CharacterDetails.ChestDye.value;
                if (!CharacterDetails.Arms.Activated) CharacterDetails.ArmSlot.value = CharacterDetails.Arms.value + "," + CharacterDetails.ArmsV.value + "," + CharacterDetails.ArmsDye.value;
                if (!CharacterDetails.Legs.Activated) CharacterDetails.LegSlot.value = CharacterDetails.Legs.value + "," + CharacterDetails.LegsV.value + "," + CharacterDetails.LegsDye.value;
                if (!CharacterDetails.Feet.Activated) CharacterDetails.FeetSlot.value = CharacterDetails.Feet.value + "," + CharacterDetails.FeetVa.value + "," + CharacterDetails.FeetDye.value;
                if (!CharacterDetails.Job.Activated) CharacterDetails.WeaponSlot.value = CharacterDetails.Job.value + "," + CharacterDetails.WeaponBase.value + "," + CharacterDetails.WeaponV.value + "," + CharacterDetails.WeaponDye.value;
                if (!CharacterDetails.Offhand.Activated) CharacterDetails.OffhandSlot.value = CharacterDetails.Offhand.value + "," + CharacterDetails.OffhandBase.value + "," + CharacterDetails.OffhandV.value + "," + CharacterDetails.OffhandDye.value;
                if (!CharacterDetails.Ear.Activated) CharacterDetails.EarSlot.value = CharacterDetails.Ear.value + "," + CharacterDetails.EarVa.value + ",0";
                if (!CharacterDetails.Neck.Activated) CharacterDetails.NeckSlot.value = CharacterDetails.Neck.value + "," + CharacterDetails.NeckVa.value + ",0";
                if (!CharacterDetails.Wrist.Activated) CharacterDetails.WristSlot.value = CharacterDetails.Wrist.value + "," + CharacterDetails.WristVa.value + ",0";
                if (!CharacterDetails.LFinger.Activated) CharacterDetails.LFingerSlot.value = CharacterDetails.LFinger.value + "," + CharacterDetails.LFingerVa.value + ",0";
                if (!CharacterDetails.RFinger.Activated) CharacterDetails.RFingerSlot.value = CharacterDetails.RFinger.value + "," + CharacterDetails.RFingerVa.value + ",0";
            }
            catch (Exception ex)
            {
				//System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace, App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
				mediator.Work -= Work;
            }
        }
    }
}