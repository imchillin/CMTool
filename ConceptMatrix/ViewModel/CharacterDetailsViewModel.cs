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
                    if (CharacterDetails.Highlights.value >= 80) CharacterDetails.Highlights.SpecialActivate = true;
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

                #region Bone Rotations
                if (CharacterDetails.Root_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Root_X), 16);
                    CharacterDetails.Root_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Root_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Root_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Root_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Root_X.value,
                        CharacterDetails.Root_Y.value,
                        CharacterDetails.Root_Z.value,
                        CharacterDetails.Root_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Root_Toggle = false;
                    CharacterDetails.Root_Rotate = true;
                }

                if (CharacterDetails.Abdomen_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Abdomen_X), 16);
                    CharacterDetails.Abdomen_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Abdomen_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Abdomen_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Abdomen_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Abdomen_X.value,
                        CharacterDetails.Abdomen_Y.value,
                        CharacterDetails.Abdomen_Z.value,
                        CharacterDetails.Abdomen_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Abdomen_Toggle = false;
                    CharacterDetails.Abdomen_Rotate = true;
                }

                if (CharacterDetails.Throw_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Throw_X), 16);
                    CharacterDetails.Throw_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Throw_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Throw_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Throw_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Throw_X.value,
                        CharacterDetails.Throw_Y.value,
                        CharacterDetails.Throw_Z.value,
                        CharacterDetails.Throw_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Throw_Toggle = false;
                    CharacterDetails.Throw_Rotate = true;
                }

                if (CharacterDetails.Waist_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Waist_X), 16);
                    CharacterDetails.Waist_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Waist_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Waist_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Waist_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Waist_X.value,
                        CharacterDetails.Waist_Y.value,
                        CharacterDetails.Waist_Z.value,
                        CharacterDetails.Waist_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Waist_Toggle = false;
                    CharacterDetails.Waist_Rotate = true;
                }

                if (CharacterDetails.SpineA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineA_X), 16);
                    CharacterDetails.SpineA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.SpineA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.SpineA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.SpineA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SpineA_X.value,
                        CharacterDetails.SpineA_Y.value,
                        CharacterDetails.SpineA_Z.value,
                        CharacterDetails.SpineA_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SpineA_Toggle = false;
                    CharacterDetails.SpineA_Rotate = true;
                }

                if (CharacterDetails.LegLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegLeft_X), 16);
                    CharacterDetails.LegLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.LegLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.LegLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.LegLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LegLeft_X.value,
                        CharacterDetails.LegLeft_Y.value,
                        CharacterDetails.LegLeft_Z.value,
                        CharacterDetails.LegLeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LegLeft_Toggle = false;
                    CharacterDetails.LegLeft_Rotate = true;
                }

                if (CharacterDetails.LegRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegRight_X), 16);
                    CharacterDetails.LegRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.LegRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.LegRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.LegRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LegRight_X.value,
                        CharacterDetails.LegRight_Y.value,
                        CharacterDetails.LegRight_Z.value,
                        CharacterDetails.LegRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LegRight_Toggle = false;
                    CharacterDetails.LegRight_Rotate = true;
                }

                if (CharacterDetails.HolsterLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterLeft_X), 16);
                    CharacterDetails.HolsterLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HolsterLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HolsterLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HolsterLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HolsterLeft_X.value,
                        CharacterDetails.HolsterLeft_Y.value,
                        CharacterDetails.HolsterLeft_Z.value,
                        CharacterDetails.HolsterLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HolsterLeft_Toggle = false;
                    CharacterDetails.HolsterLeft_Rotate = true;
                }

                if (CharacterDetails.HolsterRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterRight_X), 16);
                    CharacterDetails.HolsterRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HolsterRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HolsterRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HolsterRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HolsterRight_X.value,
                        CharacterDetails.HolsterRight_Y.value,
                        CharacterDetails.HolsterRight_Z.value,
                        CharacterDetails.HolsterRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HolsterRight_Toggle = false;
                    CharacterDetails.HolsterRight_Rotate = true;
                }

                if (CharacterDetails.SheatheLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheLeft_X), 16);
                    CharacterDetails.SheatheLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.SheatheLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.SheatheLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.SheatheLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SheatheLeft_X.value,
                        CharacterDetails.SheatheLeft_Y.value,
                        CharacterDetails.SheatheLeft_Z.value,
                        CharacterDetails.SheatheLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SheatheLeft_Toggle = false;
                    CharacterDetails.SheatheLeft_Rotate = true;
                }

                if (CharacterDetails.SheatheRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheRight_X), 16);
                    CharacterDetails.SheatheRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.SheatheRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.SheatheRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.SheatheRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SheatheRight_X.value,
                        CharacterDetails.SheatheRight_Y.value,
                        CharacterDetails.SheatheRight_Z.value,
                        CharacterDetails.SheatheRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SheatheRight_Toggle = false;
                    CharacterDetails.SheatheRight_Rotate = true;
                }

                if (CharacterDetails.SpineB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineB_X), 16);
                    CharacterDetails.SpineB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.SpineB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.SpineB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.SpineB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SpineB_X.value,
                        CharacterDetails.SpineB_Y.value,
                        CharacterDetails.SpineB_Z.value,
                        CharacterDetails.SpineB_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SpineB_Toggle = false;
                    CharacterDetails.SpineB_Rotate = true;
                }

                if (CharacterDetails.ClothBackALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackALeft_X), 16);
                    CharacterDetails.ClothBackALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothBackALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothBackALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothBackALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothBackALeft_X.value,
                        CharacterDetails.ClothBackALeft_Y.value,
                        CharacterDetails.ClothBackALeft_Z.value,
                        CharacterDetails.ClothBackALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothBackALeft_Toggle = false;
                    CharacterDetails.ClothBackALeft_Rotate = true;
                }

                if (CharacterDetails.ClothBackARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackARight_X), 16);
                    CharacterDetails.ClothBackARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothBackARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothBackARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothBackARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothBackARight_X.value,
                        CharacterDetails.ClothBackARight_Y.value,
                        CharacterDetails.ClothBackARight_Z.value,
                        CharacterDetails.ClothBackARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothBackARight_Toggle = false;
                    CharacterDetails.ClothBackARight_Rotate = true;
                }

                if (CharacterDetails.ClothFrontALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontALeft_X), 16);
                    CharacterDetails.ClothFrontALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothFrontALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothFrontALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothFrontALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothFrontALeft_X.value,
                        CharacterDetails.ClothFrontALeft_Y.value,
                        CharacterDetails.ClothFrontALeft_Z.value,
                        CharacterDetails.ClothFrontALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothFrontALeft_Toggle = false;
                    CharacterDetails.ClothFrontALeft_Rotate = true;
                }

                if (CharacterDetails.ClothFrontARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontARight_X), 16);
                    CharacterDetails.ClothFrontARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothFrontARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothFrontARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothFrontARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothFrontARight_X.value,
                        CharacterDetails.ClothFrontARight_Y.value,
                        CharacterDetails.ClothFrontARight_Z.value,
                        CharacterDetails.ClothFrontARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothFrontARight_Toggle = false;
                    CharacterDetails.ClothFrontARight_Rotate = true;
                }

                if (CharacterDetails.ClothSideALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideALeft_X), 16);
                    CharacterDetails.ClothSideALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothSideALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothSideALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothSideALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothSideALeft_X.value,
                        CharacterDetails.ClothSideALeft_Y.value,
                        CharacterDetails.ClothSideALeft_Z.value,
                        CharacterDetails.ClothSideALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothSideALeft_Toggle = false;
                    CharacterDetails.ClothSideALeft_Rotate = true;
                }

                if (CharacterDetails.ClothSideARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideARight_X), 16);
                    CharacterDetails.ClothSideARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothSideARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothSideARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothSideARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothSideARight_X.value,
                        CharacterDetails.ClothSideARight_Y.value,
                        CharacterDetails.ClothSideARight_Z.value,
                        CharacterDetails.ClothSideARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothSideARight_Toggle = false;
                    CharacterDetails.ClothSideARight_Rotate = true;
                }

                if (CharacterDetails.KneeLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeLeft_X), 16);
                    CharacterDetails.KneeLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.KneeLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.KneeLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.KneeLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.KneeLeft_X.value,
                        CharacterDetails.KneeLeft_Y.value,
                        CharacterDetails.KneeLeft_Z.value,
                        CharacterDetails.KneeLeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.KneeLeft_Toggle = false;
                    CharacterDetails.KneeLeft_Rotate = true;
                }

                if (CharacterDetails.KneeRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeRight_X), 16);
                    CharacterDetails.KneeRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.KneeRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.KneeRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.KneeRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.KneeRight_X.value,
                        CharacterDetails.KneeRight_Y.value,
                        CharacterDetails.KneeRight_Z.value,
                        CharacterDetails.KneeRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.KneeRight_Toggle = false;
                    CharacterDetails.KneeRight_Rotate = true;
                }

                if (CharacterDetails.BreastLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastLeft_X), 16);
                    CharacterDetails.BreastLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.BreastLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.BreastLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.BreastLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.BreastLeft_X.value,
                        CharacterDetails.BreastLeft_Y.value,
                        CharacterDetails.BreastLeft_Z.value,
                        CharacterDetails.BreastLeft_W.value
                    ).ToEulerAngles();
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.BreastLeft_Toggle = false;
                    CharacterDetails.BreastLeft_Rotate = true;
                }

                if (CharacterDetails.BreastRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastRight_X), 16);
                    CharacterDetails.BreastRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.BreastRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.BreastRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.BreastRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.BreastRight_X.value,
                        CharacterDetails.BreastRight_Y.value,
                        CharacterDetails.BreastRight_Z.value,
                        CharacterDetails.BreastRight_W.value
                    ).ToEulerAngles();
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.BreastRight_Toggle = false;
                    CharacterDetails.BreastRight_Rotate = true;
                }

                if (CharacterDetails.SpineC_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineC_X), 16);
                    CharacterDetails.SpineC_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.SpineC_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.SpineC_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.SpineC_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SpineC_X.value,
                        CharacterDetails.SpineC_Y.value,
                        CharacterDetails.SpineC_Z.value,
                        CharacterDetails.SpineC_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SpineC_Toggle = false;
                    CharacterDetails.SpineC_Rotate = true;
                }

                if (CharacterDetails.ClothBackBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBLeft_X), 16);
                    CharacterDetails.ClothBackBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothBackBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothBackBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothBackBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothBackBLeft_X.value,
                        CharacterDetails.ClothBackBLeft_Y.value,
                        CharacterDetails.ClothBackBLeft_Z.value,
                        CharacterDetails.ClothBackBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothBackBLeft_Toggle = false;
                    CharacterDetails.ClothBackBLeft_Rotate = true;
                }

                if (CharacterDetails.ClothBackBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBRight_X), 16);
                    CharacterDetails.ClothBackBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothBackBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothBackBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothBackBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothBackBRight_X.value,
                        CharacterDetails.ClothBackBRight_Y.value,
                        CharacterDetails.ClothBackBRight_Z.value,
                        CharacterDetails.ClothBackBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothBackBRight_Toggle = false;
                    CharacterDetails.ClothBackBRight_Rotate = true;
                }

                if (CharacterDetails.ClothFrontBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBLeft_X), 16);
                    CharacterDetails.ClothFrontBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothFrontBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothFrontBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothFrontBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothFrontBLeft_X.value,
                        CharacterDetails.ClothFrontBLeft_Y.value,
                        CharacterDetails.ClothFrontBLeft_Z.value,
                        CharacterDetails.ClothFrontBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothFrontBLeft_Toggle = false;
                    CharacterDetails.ClothFrontBLeft_Rotate = true;
                }

                if (CharacterDetails.ClothFrontBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBRight_X), 16);
                    CharacterDetails.ClothFrontBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothFrontBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothFrontBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothFrontBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothFrontBRight_X.value,
                        CharacterDetails.ClothFrontBRight_Y.value,
                        CharacterDetails.ClothFrontBRight_Z.value,
                        CharacterDetails.ClothFrontBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothFrontBRight_Toggle = false;
                    CharacterDetails.ClothFrontBRight_Rotate = true;
                }

                if (CharacterDetails.ClothSideBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBLeft_X), 16);
                    CharacterDetails.ClothSideBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothSideBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothSideBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothSideBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothSideBLeft_X.value,
                        CharacterDetails.ClothSideBLeft_Y.value,
                        CharacterDetails.ClothSideBLeft_Z.value,
                        CharacterDetails.ClothSideBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothSideBLeft_Toggle = false;
                    CharacterDetails.ClothSideBLeft_Rotate = true;
                }

                if (CharacterDetails.ClothSideBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBRight_X), 16);
                    CharacterDetails.ClothSideBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothSideBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothSideBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothSideBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothSideBRight_X.value,
                        CharacterDetails.ClothSideBRight_Y.value,
                        CharacterDetails.ClothSideBRight_Z.value,
                        CharacterDetails.ClothSideBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothSideBRight_Toggle = false;
                    CharacterDetails.ClothSideBRight_Rotate = true;
                }

                if (CharacterDetails.CalfLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfLeft_X), 16);
                    CharacterDetails.CalfLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.CalfLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.CalfLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.CalfLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.CalfLeft_X.value,
                        CharacterDetails.CalfLeft_Y.value,
                        CharacterDetails.CalfLeft_Z.value,
                        CharacterDetails.CalfLeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.CalfLeft_Toggle = false;
                    CharacterDetails.CalfLeft_Rotate = true;
                }

                if (CharacterDetails.CalfRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfRight_X), 16);
                    CharacterDetails.CalfRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.CalfRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.CalfRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.CalfRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.CalfRight_X.value,
                        CharacterDetails.CalfRight_Y.value,
                        CharacterDetails.CalfRight_Z.value,
                        CharacterDetails.CalfRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.CalfRight_Toggle = false;
                    CharacterDetails.CalfRight_Rotate = true;
                }

                if (CharacterDetails.ScabbardLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardLeft_X), 16);
                    CharacterDetails.ScabbardLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ScabbardLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ScabbardLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ScabbardLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ScabbardLeft_X.value,
                        CharacterDetails.ScabbardLeft_Y.value,
                        CharacterDetails.ScabbardLeft_Z.value,
                        CharacterDetails.ScabbardLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ScabbardLeft_Toggle = false;
                    CharacterDetails.ScabbardLeft_Rotate = true;
                }

                if (CharacterDetails.ScabbardRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardRight_X), 16);
                    CharacterDetails.ScabbardRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ScabbardRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ScabbardRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ScabbardRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ScabbardRight_X.value,
                        CharacterDetails.ScabbardRight_Y.value,
                        CharacterDetails.ScabbardRight_Z.value,
                        CharacterDetails.ScabbardRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ScabbardRight_Toggle = false;
                    CharacterDetails.ScabbardRight_Rotate = true;
                }

                if (CharacterDetails.Neck_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Neck_X), 16);
                    CharacterDetails.Neck_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Neck_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Neck_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Neck_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Neck_X.value,
                        CharacterDetails.Neck_Y.value,
                        CharacterDetails.Neck_Z.value,
                        CharacterDetails.Neck_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Neck_Toggle = false;
                    CharacterDetails.Neck_Rotate = true;
                }

                if (CharacterDetails.ClavicleLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleLeft_X), 16);
                    CharacterDetails.ClavicleLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClavicleLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClavicleLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClavicleLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClavicleLeft_X.value,
                        CharacterDetails.ClavicleLeft_Y.value,
                        CharacterDetails.ClavicleLeft_Z.value,
                        CharacterDetails.ClavicleLeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClavicleLeft_Toggle = false;
                    CharacterDetails.ClavicleLeft_Rotate = true;
                }

                if (CharacterDetails.ClavicleRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleRight_X), 16);
                    CharacterDetails.ClavicleRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClavicleRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClavicleRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClavicleRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClavicleRight_X.value,
                        CharacterDetails.ClavicleRight_Y.value,
                        CharacterDetails.ClavicleRight_Z.value,
                        CharacterDetails.ClavicleRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClavicleRight_Toggle = false;
                    CharacterDetails.ClavicleRight_Rotate = true;
                }

                if (CharacterDetails.ClothBackCLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCLeft_X), 16);
                    CharacterDetails.ClothBackCLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothBackCLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothBackCLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothBackCLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothBackCLeft_X.value,
                        CharacterDetails.ClothBackCLeft_Y.value,
                        CharacterDetails.ClothBackCLeft_Z.value,
                        CharacterDetails.ClothBackCLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothBackCLeft_Toggle = false;
                    CharacterDetails.ClothBackCLeft_Rotate = true;
                }

                if (CharacterDetails.ClothBackCRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCRight_X), 16);
                    CharacterDetails.ClothBackCRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothBackCRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothBackCRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothBackCRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothBackCRight_X.value,
                        CharacterDetails.ClothBackCRight_Y.value,
                        CharacterDetails.ClothBackCRight_Z.value,
                        CharacterDetails.ClothBackCRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothBackCRight_Toggle = false;
                    CharacterDetails.ClothBackCRight_Rotate = true;
                }

                if (CharacterDetails.ClothFrontCLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCLeft_X), 16);
                    CharacterDetails.ClothFrontCLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothFrontCLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothFrontCLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothFrontCLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothFrontCLeft_X.value,
                        CharacterDetails.ClothFrontCLeft_Y.value,
                        CharacterDetails.ClothFrontCLeft_Z.value,
                        CharacterDetails.ClothFrontCLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothFrontCLeft_Toggle = false;
                    CharacterDetails.ClothFrontCLeft_Rotate = true;
                }

                if (CharacterDetails.ClothFrontCRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCRight_X), 16);
                    CharacterDetails.ClothFrontCRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothFrontCRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothFrontCRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothFrontCRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothFrontCRight_X.value,
                        CharacterDetails.ClothFrontCRight_Y.value,
                        CharacterDetails.ClothFrontCRight_Z.value,
                        CharacterDetails.ClothFrontCRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothFrontCRight_Toggle = false;
                    CharacterDetails.ClothFrontCRight_Rotate = true;
                }

                if (CharacterDetails.ClothSideCLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCLeft_X), 16);
                    CharacterDetails.ClothSideCLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothSideCLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothSideCLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothSideCLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    CharacterDetails.ClothSideCLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCLeft_X));
                    CharacterDetails.ClothSideCLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCLeft_Y));
                    CharacterDetails.ClothSideCLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCLeft_Z));
                    CharacterDetails.ClothSideCLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothSideCLeft_X.value,
                        CharacterDetails.ClothSideCLeft_Y.value,
                        CharacterDetails.ClothSideCLeft_Z.value,
                        CharacterDetails.ClothSideCLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothSideCLeft_Toggle = false;
                    CharacterDetails.ClothSideCLeft_Rotate = true;
                }

                if (CharacterDetails.ClothSideCRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCRight_X), 16);
                    CharacterDetails.ClothSideCRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ClothSideCRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ClothSideCRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ClothSideCRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClothSideCRight_X.value,
                        CharacterDetails.ClothSideCRight_Y.value,
                        CharacterDetails.ClothSideCRight_Z.value,
                        CharacterDetails.ClothSideCRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClothSideCRight_Toggle = false;
                    CharacterDetails.ClothSideCRight_Rotate = true;
                }

                if (CharacterDetails.PoleynLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynLeft_X), 16);
                    CharacterDetails.PoleynLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.PoleynLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.PoleynLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.PoleynLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PoleynLeft_X.value,
                        CharacterDetails.PoleynLeft_Y.value,
                        CharacterDetails.PoleynLeft_Z.value,
                        CharacterDetails.PoleynLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PoleynLeft_Toggle = false;
                    CharacterDetails.PoleynLeft_Rotate = true;
                }

                if (CharacterDetails.PoleynRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynRight_X), 16);
                    CharacterDetails.PoleynRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.PoleynRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.PoleynRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.PoleynRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PoleynRight_X.value,
                        CharacterDetails.PoleynRight_Y.value,
                        CharacterDetails.PoleynRight_Z.value,
                        CharacterDetails.PoleynRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PoleynRight_Toggle = false;
                    CharacterDetails.PoleynRight_Rotate = true;
                }

                if (CharacterDetails.FootLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootLeft_X), 16);
                    CharacterDetails.FootLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.FootLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.FootLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.FootLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.FootLeft_X.value,
                        CharacterDetails.FootLeft_Y.value,
                        CharacterDetails.FootLeft_Z.value,
                        CharacterDetails.FootLeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.FootLeft_Toggle = false;
                    CharacterDetails.FootLeft_Rotate = true;
                }

                if (CharacterDetails.FootRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootRight_X), 16);
                    CharacterDetails.FootRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.FootRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.FootRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.FootRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.FootRight_X.value,
                        CharacterDetails.FootRight_Y.value,
                        CharacterDetails.FootRight_Z.value,
                        CharacterDetails.FootRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.FootRight_Toggle = false;
                    CharacterDetails.FootRight_Rotate = true;
                }

                if (CharacterDetails.Head_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Head_X), 16);
                    CharacterDetails.Head_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Head_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Head_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Head_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Head_X.value,
                        CharacterDetails.Head_Y.value,
                        CharacterDetails.Head_Z.value,
                        CharacterDetails.Head_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Head_Toggle = false;
                    CharacterDetails.Head_Rotate = true;
                }

                if (CharacterDetails.ArmLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmLeft_X), 16);
                    CharacterDetails.ArmLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ArmLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ArmLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ArmLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ArmLeft_X.value,
                        CharacterDetails.ArmLeft_Y.value,
                        CharacterDetails.ArmLeft_Z.value,
                        CharacterDetails.ArmLeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ArmLeft_Toggle = false;
                    CharacterDetails.ArmLeft_Rotate = true;
                }

                if (CharacterDetails.ArmRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmRight_X), 16);
                    CharacterDetails.ArmRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ArmRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ArmRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ArmRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ArmRight_X.value,
                        CharacterDetails.ArmRight_Y.value,
                        CharacterDetails.ArmRight_Z.value,
                        CharacterDetails.ArmRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ArmRight_Toggle = false;
                    CharacterDetails.ArmRight_Rotate = true;
                }

                if (CharacterDetails.PauldronLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronLeft_X), 16);
                    CharacterDetails.PauldronLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.PauldronLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.PauldronLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.PauldronLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PauldronLeft_X.value,
                        CharacterDetails.PauldronLeft_Y.value,
                        CharacterDetails.PauldronLeft_Z.value,
                        CharacterDetails.PauldronLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PauldronLeft_Toggle = false;
                    CharacterDetails.PauldronLeft_Rotate = true;
                }

                if (CharacterDetails.PauldronRight_Toggle)
                {

                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronRight_X), 16);
                    CharacterDetails.PauldronRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.PauldronRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.PauldronRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.PauldronRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PauldronRight_X.value,
                        CharacterDetails.PauldronRight_Y.value,
                        CharacterDetails.PauldronRight_Z.value,
                        CharacterDetails.PauldronRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PauldronRight_Toggle = false;
                    CharacterDetails.PauldronRight_Rotate = true;
                }

                if (CharacterDetails.Unknown00_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Unknown00_X), 16);
                    CharacterDetails.Unknown00_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Unknown00_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Unknown00_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Unknown00_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Unknown00_X.value,
                        CharacterDetails.Unknown00_Y.value,
                        CharacterDetails.Unknown00_Z.value,
                        CharacterDetails.Unknown00_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Unknown00_Toggle = false;
                    CharacterDetails.Unknown00_Rotate = true;
                }

                if (CharacterDetails.ToesLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesLeft_X), 16);
                    CharacterDetails.ToesLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ToesLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ToesLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ToesLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ToesLeft_X.value,
                        CharacterDetails.ToesLeft_Y.value,
                        CharacterDetails.ToesLeft_Z.value,
                        CharacterDetails.ToesLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ToesLeft_Toggle = false;
                    CharacterDetails.ToesLeft_Rotate = true;
                }

                if (CharacterDetails.ToesRight_Toggle)
                {

                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesRight_X), 16);
                    CharacterDetails.ToesRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ToesRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ToesRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ToesRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ToesRight_X.value,
                        CharacterDetails.ToesRight_Y.value,
                        CharacterDetails.ToesRight_Z.value,
                        CharacterDetails.ToesRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ToesRight_Toggle = false;
                    CharacterDetails.ToesRight_Rotate = true;
                }

                if (CharacterDetails.HairA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairA_X), 16);
                    CharacterDetails.HairA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HairA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HairA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HairA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HairA_X.value,
                        CharacterDetails.HairA_Y.value,
                        CharacterDetails.HairA_Z.value,
                        CharacterDetails.HairA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HairA_Toggle = false;
                    CharacterDetails.HairA_Rotate = true;
                }

                if (CharacterDetails.HairFrontLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontLeft_X), 16);
                    CharacterDetails.HairFrontLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HairFrontLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HairFrontLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HairFrontLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HairFrontLeft_X.value,
                        CharacterDetails.HairFrontLeft_Y.value,
                        CharacterDetails.HairFrontLeft_Z.value,
                        CharacterDetails.HairFrontLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HairFrontLeft_Toggle = false;
                    CharacterDetails.HairFrontLeft_Rotate = true;
                }

                if (CharacterDetails.HairFrontRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontRight_X), 16);
                    CharacterDetails.HairFrontRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HairFrontRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HairFrontRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HairFrontRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HairFrontRight_X.value,
                        CharacterDetails.HairFrontRight_Y.value,
                        CharacterDetails.HairFrontRight_Z.value,
                        CharacterDetails.HairFrontRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HairFrontRight_Toggle = false;
                    CharacterDetails.HairFrontRight_Rotate = true;
                }

                if (CharacterDetails.EarLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarLeft_X), 16);
                    CharacterDetails.EarLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EarLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EarLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EarLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EarLeft_X.value,
                        CharacterDetails.EarLeft_Y.value,
                        CharacterDetails.EarLeft_Z.value,
                        CharacterDetails.EarLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EarLeft_Toggle = false;
                    CharacterDetails.EarLeft_Rotate = true;
                }

                if (CharacterDetails.EarRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarRight_X), 16);
                    CharacterDetails.EarRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EarRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EarRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EarRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EarRight_X.value,
                        CharacterDetails.EarRight_Y.value,
                        CharacterDetails.EarRight_Z.value,
                        CharacterDetails.EarRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EarRight_Toggle = false;
                    CharacterDetails.EarRight_Rotate = true;
                }

                if (CharacterDetails.ForearmLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmLeft_X), 16);
                    CharacterDetails.ForearmLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ForearmLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ForearmLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ForearmLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ForearmLeft_X.value,
                        CharacterDetails.ForearmLeft_Y.value,
                        CharacterDetails.ForearmLeft_Z.value,
                        CharacterDetails.ForearmLeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ForearmLeft_Toggle = false;
                    CharacterDetails.ForearmLeft_Rotate = true;
                }

                if (CharacterDetails.ForearmRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmRight_X), 16);
                    CharacterDetails.ForearmRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ForearmRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ForearmRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ForearmRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ForearmRight_X.value,
                        CharacterDetails.ForearmRight_Y.value,
                        CharacterDetails.ForearmRight_Z.value,
                        CharacterDetails.ForearmRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ForearmRight_Toggle = false;
                    CharacterDetails.ForearmRight_Rotate = true;
                }

                if (CharacterDetails.ShoulderLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderLeft_X), 16);
                    CharacterDetails.ShoulderLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ShoulderLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ShoulderLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ShoulderLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ShoulderLeft_X.value,
                        CharacterDetails.ShoulderLeft_Y.value,
                        CharacterDetails.ShoulderLeft_Z.value,
                        CharacterDetails.ShoulderLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ShoulderLeft_Toggle = false;
                    CharacterDetails.ShoulderLeft_Rotate = true;
                }

                if (CharacterDetails.ShoulderRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderRight_X), 16);
                    CharacterDetails.ShoulderRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ShoulderRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ShoulderRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ShoulderRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ShoulderRight_X.value,
                        CharacterDetails.ShoulderRight_Y.value,
                        CharacterDetails.ShoulderRight_Z.value,
                        CharacterDetails.ShoulderRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ShoulderRight_Toggle = false;
                    CharacterDetails.ShoulderRight_Rotate = true;
                }

                if (CharacterDetails.HairB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairB_X), 16);
                    CharacterDetails.HairB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HairB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HairB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HairB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HairB_X.value,
                        CharacterDetails.HairB_Y.value,
                        CharacterDetails.HairB_Z.value,
                        CharacterDetails.HairB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HairB_Toggle = false;
                    CharacterDetails.HairB_Rotate = true;
                }

                if (CharacterDetails.HandLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandLeft_X), 16);
                    CharacterDetails.HandLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HandLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HandLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HandLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HandLeft_X.value,
                        CharacterDetails.HandLeft_Y.value,
                        CharacterDetails.HandLeft_Z.value,
                        CharacterDetails.HandLeft_W.value
                    ).ToEulerAngles();
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.HandLeft_Toggle = false;
                    CharacterDetails.HandLeft_Rotate = true;
                }

                if (CharacterDetails.HandRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandRight_X), 16);
                    CharacterDetails.HandRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HandRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HandRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HandRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HandRight_X.value,
                        CharacterDetails.HandRight_Y.value,
                        CharacterDetails.HandRight_Z.value,
                        CharacterDetails.HandRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HandRight_Toggle = false;
                    CharacterDetails.HandRight_Rotate = true;
                }

                if (CharacterDetails.ShieldLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldLeft_X), 16);
                    CharacterDetails.ShieldLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ShieldLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ShieldLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ShieldLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ShieldLeft_X.value,
                        CharacterDetails.ShieldLeft_Y.value,
                        CharacterDetails.ShieldLeft_Z.value,
                        CharacterDetails.ShieldLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ShieldLeft_Toggle = false;
                    CharacterDetails.ShieldLeft_Rotate = true;
                }

                if (CharacterDetails.ShieldRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldRight_X), 16);
                    CharacterDetails.ShieldRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ShieldRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ShieldRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ShieldRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ShieldRight_X.value,
                        CharacterDetails.ShieldRight_Y.value,
                        CharacterDetails.ShieldRight_Z.value,
                        CharacterDetails.ShieldRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ShieldRight_Toggle = false;
                    CharacterDetails.ShieldRight_Rotate = true;
                }

                if (CharacterDetails.EarringALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringALeft_X), 16);
                    CharacterDetails.EarringALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EarringALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EarringALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EarringALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EarringALeft_X.value,
                        CharacterDetails.EarringALeft_Y.value,
                        CharacterDetails.EarringALeft_Z.value,
                        CharacterDetails.EarringALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EarringALeft_Toggle = false;
                    CharacterDetails.EarringALeft_Rotate = true;
                }

                if (CharacterDetails.EarringARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringARight_X), 16);
                    CharacterDetails.EarringARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EarringARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EarringARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EarringARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EarringARight_X.value,
                        CharacterDetails.EarringARight_Y.value,
                        CharacterDetails.EarringARight_Z.value,
                        CharacterDetails.EarringARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EarringARight_Toggle = false;
                    CharacterDetails.EarringARight_Rotate = true;
                }

                if (CharacterDetails.ElbowLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowLeft_X), 16);
                    CharacterDetails.ElbowLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ElbowLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ElbowLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ElbowLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ElbowLeft_X.value,
                        CharacterDetails.ElbowLeft_Y.value,
                        CharacterDetails.ElbowLeft_Z.value,
                        CharacterDetails.ElbowLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ElbowLeft_Toggle = false;
                    CharacterDetails.ElbowLeft_Rotate = true;
                }

                if (CharacterDetails.ElbowRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowRight_X), 16);
                    CharacterDetails.ElbowRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ElbowRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ElbowRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ElbowRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ElbowRight_X.value,
                        CharacterDetails.ElbowRight_Y.value,
                        CharacterDetails.ElbowRight_Z.value,
                        CharacterDetails.ElbowRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ElbowRight_Toggle = false;
                    CharacterDetails.ElbowRight_Rotate = true;
                }

                if (CharacterDetails.CouterLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterLeft_X), 16);
                    CharacterDetails.CouterLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.CouterLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.CouterLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.CouterLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.CouterLeft_X.value,
                        CharacterDetails.CouterLeft_Y.value,
                        CharacterDetails.CouterLeft_Z.value,
                        CharacterDetails.CouterLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.CouterLeft_Toggle = false;
                    CharacterDetails.CouterLeft_Rotate = true;
                }

                if (CharacterDetails.CouterRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterRight_X), 16);
                    CharacterDetails.CouterRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.CouterRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.CouterRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.CouterRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.CouterRight_X.value,
                        CharacterDetails.CouterRight_Y.value,
                        CharacterDetails.CouterRight_Z.value,
                        CharacterDetails.CouterRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.CouterRight_Toggle = false;
                    CharacterDetails.CouterRight_Rotate = true;
                }

                if (CharacterDetails.WristLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristLeft_X), 16);
                    CharacterDetails.WristLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.WristLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.WristLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.WristLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.WristLeft_X.value,
                        CharacterDetails.WristLeft_Y.value,
                        CharacterDetails.WristLeft_Z.value,
                        CharacterDetails.WristLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.WristLeft_Toggle = false;
                    CharacterDetails.WristLeft_Rotate = true;
                }

                if (CharacterDetails.WristRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristRight_X), 16);
                    CharacterDetails.WristRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.WristRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.WristRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.WristRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.WristRight_X.value,
                        CharacterDetails.WristRight_Y.value,
                        CharacterDetails.WristRight_Z.value,
                        CharacterDetails.WristRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.WristRight_Toggle = false;
                    CharacterDetails.WristRight_Rotate = true;
                }

                if (CharacterDetails.IndexALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexALeft_X), 16);
                    CharacterDetails.IndexALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.IndexALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.IndexALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.IndexALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.IndexALeft_X.value,
                        CharacterDetails.IndexALeft_Y.value,
                        CharacterDetails.IndexALeft_Z.value,
                        CharacterDetails.IndexALeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.IndexALeft_Toggle = false;
                    CharacterDetails.IndexALeft_Rotate = true;
                }

                if (CharacterDetails.IndexARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexARight_X), 16);
                    CharacterDetails.IndexARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.IndexARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.IndexARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.IndexARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.IndexARight_X.value,
                        CharacterDetails.IndexARight_Y.value,
                        CharacterDetails.IndexARight_Z.value,
                        CharacterDetails.IndexARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.IndexARight_Toggle = false;
                    CharacterDetails.IndexARight_Rotate = true;
                }

                if (CharacterDetails.PinkyALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyALeft_X), 16);
                    CharacterDetails.PinkyALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.PinkyALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.PinkyALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.PinkyALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PinkyALeft_X.value,
                        CharacterDetails.PinkyALeft_Y.value,
                        CharacterDetails.PinkyALeft_Z.value,
                        CharacterDetails.PinkyALeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PinkyALeft_Toggle = false;
                    CharacterDetails.PinkyALeft_Rotate = true;
                }

                if (CharacterDetails.PinkyARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyARight_X), 16);
                    CharacterDetails.PinkyARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.PinkyARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.PinkyARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.PinkyARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PinkyARight_X.value,
                        CharacterDetails.PinkyARight_Y.value,
                        CharacterDetails.PinkyARight_Z.value,
                        CharacterDetails.PinkyARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PinkyARight_Toggle = false;
                    CharacterDetails.PinkyARight_Rotate = true;
                }

                if (CharacterDetails.RingALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingALeft_X), 16);
                    CharacterDetails.RingALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.RingALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.RingALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.RingALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RingALeft_X.value,
                        CharacterDetails.RingALeft_Y.value,
                        CharacterDetails.RingALeft_Z.value,
                        CharacterDetails.RingALeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RingALeft_Toggle = false;
                    CharacterDetails.RingALeft_Rotate = true;
                }

                if (CharacterDetails.RingARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingARight_X), 16);
                    CharacterDetails.RingARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.RingARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.RingARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.RingARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RingARight_X.value,
                        CharacterDetails.RingARight_Y.value,
                        CharacterDetails.RingARight_Z.value,
                        CharacterDetails.RingARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RingARight_Toggle = false;
                    CharacterDetails.RingARight_Rotate = true;
                }

                if (CharacterDetails.MiddleALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleALeft_X), 16);
                    CharacterDetails.MiddleALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.MiddleALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.MiddleALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.MiddleALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.MiddleALeft_X.value,
                        CharacterDetails.MiddleALeft_Y.value,
                        CharacterDetails.MiddleALeft_Z.value,
                        CharacterDetails.MiddleALeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.MiddleALeft_Toggle = false;
                    CharacterDetails.MiddleALeft_Rotate = true;
                }

                if (CharacterDetails.MiddleARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleARight_X), 16);
                    CharacterDetails.MiddleARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.MiddleARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.MiddleARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.MiddleARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.MiddleARight_X.value,
                        CharacterDetails.MiddleARight_Y.value,
                        CharacterDetails.MiddleARight_Z.value,
                        CharacterDetails.MiddleARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.MiddleARight_Toggle = false;
                    CharacterDetails.MiddleARight_Rotate = true;
                }

                if (CharacterDetails.ThumbALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbALeft_X), 16);
                    CharacterDetails.ThumbALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ThumbALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ThumbALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ThumbALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ThumbALeft_X.value,
                        CharacterDetails.ThumbALeft_Y.value,
                        CharacterDetails.ThumbALeft_Z.value,
                        CharacterDetails.ThumbALeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ThumbALeft_Toggle = false;
                    CharacterDetails.ThumbALeft_Rotate = true;
                }

                if (CharacterDetails.ThumbARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbARight_X), 16);
                    CharacterDetails.ThumbARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ThumbARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ThumbARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ThumbARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ThumbARight_X.value,
                        CharacterDetails.ThumbARight_Y.value,
                        CharacterDetails.ThumbARight_Z.value,
                        CharacterDetails.ThumbARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ThumbARight_Toggle = false;
                    CharacterDetails.ThumbARight_Rotate = true;
                }

                if (CharacterDetails.WeaponLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponLeft_X), 16);
                    CharacterDetails.WeaponLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.WeaponLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.WeaponLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.WeaponLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.WeaponLeft_X.value,
                        CharacterDetails.WeaponLeft_Y.value,
                        CharacterDetails.WeaponLeft_Z.value,
                        CharacterDetails.WeaponLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.WeaponLeft_Toggle = false;
                    CharacterDetails.WeaponLeft_Rotate = true;
                }

                if (CharacterDetails.WeaponRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponRight_X), 16);
                    CharacterDetails.WeaponRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.WeaponRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.WeaponRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.WeaponRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.WeaponRight_X.value,
                        CharacterDetails.WeaponRight_Y.value,
                        CharacterDetails.WeaponRight_Z.value,
                        CharacterDetails.WeaponRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.WeaponRight_Toggle = false;
                    CharacterDetails.WeaponRight_Rotate = true;
                }

                if (CharacterDetails.EarringBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBLeft_X), 16);
                    CharacterDetails.EarringBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EarringBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EarringBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EarringBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EarringBLeft_X.value,
                        CharacterDetails.EarringBLeft_Y.value,
                        CharacterDetails.EarringBLeft_Z.value,
                        CharacterDetails.EarringBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EarringBLeft_Toggle = false;
                    CharacterDetails.EarringBLeft_Rotate = true;
                }

                if (CharacterDetails.EarringBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBRight_X), 16);
                    CharacterDetails.EarringBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EarringBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EarringBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EarringBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EarringBRight_X.value,
                        CharacterDetails.EarringBRight_Y.value,
                        CharacterDetails.EarringBRight_Z.value,
                        CharacterDetails.EarringBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EarringBRight_Toggle = false;
                    CharacterDetails.EarringBRight_Rotate = true;
                }

                if (CharacterDetails.IndexBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBLeft_X), 16);
                    CharacterDetails.IndexBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.IndexBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.IndexBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.IndexBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.IndexBLeft_X.value,
                        CharacterDetails.IndexBLeft_Y.value,
                        CharacterDetails.IndexBLeft_Z.value,
                        CharacterDetails.IndexBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.IndexBLeft_Toggle = false;
                    CharacterDetails.IndexBLeft_Rotate = true;
                }

                if (CharacterDetails.IndexBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBRight_X), 16);
                    CharacterDetails.IndexBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.IndexBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.IndexBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.IndexBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.IndexBRight_X.value,
                        CharacterDetails.IndexBRight_Y.value,
                        CharacterDetails.IndexBRight_Z.value,
                        CharacterDetails.IndexBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.IndexBRight_Toggle = false;
                    CharacterDetails.IndexBRight_Rotate = true;
                }

                if (CharacterDetails.PinkyBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBLeft_X), 16);
                    CharacterDetails.PinkyBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.PinkyBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.PinkyBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.PinkyBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PinkyBLeft_X.value,
                        CharacterDetails.PinkyBLeft_Y.value,
                        CharacterDetails.PinkyBLeft_Z.value,
                        CharacterDetails.PinkyBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PinkyBLeft_Toggle = false;
                    CharacterDetails.PinkyBLeft_Rotate = true;
                }

                if (CharacterDetails.PinkyBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBRight_X), 16);
                    CharacterDetails.PinkyBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.PinkyBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.PinkyBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.PinkyBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PinkyBRight_X.value,
                        CharacterDetails.PinkyBRight_Y.value,
                        CharacterDetails.PinkyBRight_Z.value,
                        CharacterDetails.PinkyBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PinkyBRight_Toggle = false;
                    CharacterDetails.PinkyBRight_Rotate = true;
                }

                if (CharacterDetails.RingBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBLeft_X), 16);
                    CharacterDetails.RingBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.RingBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.RingBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.RingBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RingBLeft_X.value,
                        CharacterDetails.RingBLeft_Y.value,
                        CharacterDetails.RingBLeft_Z.value,
                        CharacterDetails.RingBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RingBLeft_Toggle = false;
                    CharacterDetails.RingBLeft_Rotate = true;
                }

                if (CharacterDetails.RingBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBRight_X), 16);
                    CharacterDetails.RingBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.RingBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.RingBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.RingBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RingBRight_X.value,
                        CharacterDetails.RingBRight_Y.value,
                        CharacterDetails.RingBRight_Z.value,
                        CharacterDetails.RingBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RingBRight_Toggle = false;
                    CharacterDetails.RingBRight_Rotate = true;
                }

                if (CharacterDetails.MiddleBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBLeft_X), 16);
                    CharacterDetails.MiddleBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.MiddleBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.MiddleBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.MiddleBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.MiddleBLeft_X.value,
                        CharacterDetails.MiddleBLeft_Y.value,
                        CharacterDetails.MiddleBLeft_Z.value,
                        CharacterDetails.MiddleBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.MiddleBLeft_Toggle = false;
                    CharacterDetails.MiddleBLeft_Rotate = true;
                }

                if (CharacterDetails.MiddleBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBRight_X), 16);
                    CharacterDetails.MiddleBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.MiddleBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.MiddleBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.MiddleBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.MiddleBRight_X.value,
                        CharacterDetails.MiddleBRight_Y.value,
                        CharacterDetails.MiddleBRight_Z.value,
                        CharacterDetails.MiddleBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.MiddleBRight_Toggle = false;
                    CharacterDetails.MiddleBRight_Rotate = true;
                }

                if (CharacterDetails.ThumbBLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBLeft_X), 16);
                    CharacterDetails.ThumbBLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ThumbBLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ThumbBLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ThumbBLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ThumbBLeft_X.value,
                        CharacterDetails.ThumbBLeft_Y.value,
                        CharacterDetails.ThumbBLeft_Z.value,
                        CharacterDetails.ThumbBLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ThumbBLeft_Toggle = false;
                    CharacterDetails.ThumbBLeft_Rotate = true;
                }

                if (CharacterDetails.ThumbBRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBRight_X), 16);
                    CharacterDetails.ThumbBRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ThumbBRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ThumbBRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ThumbBRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ThumbBRight_X.value,
                        CharacterDetails.ThumbBRight_Y.value,
                        CharacterDetails.ThumbBRight_Z.value,
                        CharacterDetails.ThumbBRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ThumbBRight_Toggle = false;
                    CharacterDetails.ThumbBRight_Rotate = true;
                }

                if (CharacterDetails.TailA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailA_X), 16);
                    CharacterDetails.TailA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.TailA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.TailA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.TailA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailA_X.value,
                        CharacterDetails.TailA_Y.value,
                        CharacterDetails.TailA_Z.value,
                        CharacterDetails.TailA_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailA_Toggle = false;
                    CharacterDetails.TailA_Rotate = true;
                }

                if (CharacterDetails.TailB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailB_X), 16);
                    CharacterDetails.TailB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.TailB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.TailB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.TailB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailB_X.value,
                        CharacterDetails.TailB_Y.value,
                        CharacterDetails.TailB_Z.value,
                        CharacterDetails.TailB_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailB_Toggle = false;
                    CharacterDetails.TailB_Rotate = true;
                }

                if (CharacterDetails.TailC_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailC_X), 16);
                    CharacterDetails.TailC_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.TailC_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.TailC_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.TailC_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailC_X.value,
                        CharacterDetails.TailC_Y.value,
                        CharacterDetails.TailC_Z.value,
                        CharacterDetails.TailC_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailC_Toggle = false;
                    CharacterDetails.TailC_Rotate = true;
                }

                if (CharacterDetails.TailD_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailD_X), 16);
                    CharacterDetails.TailD_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.TailD_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.TailD_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.TailD_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailD_X.value,
                        CharacterDetails.TailD_Y.value,
                        CharacterDetails.TailD_Z.value,
                        CharacterDetails.TailD_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailD_Toggle = false;
                    CharacterDetails.TailD_Rotate = true;
                }

                if (CharacterDetails.TailE_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailE_X), 16);
                    CharacterDetails.TailE_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.TailE_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.TailE_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.TailE_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailE_X.value,
                        CharacterDetails.TailE_Y.value,
                        CharacterDetails.TailE_Z.value,
                        CharacterDetails.TailE_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailE_Toggle = false;
                    CharacterDetails.TailE_Rotate = true;
                }

                if (CharacterDetails.RootHead_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.RootHead_X), 16);
                    CharacterDetails.RootHead_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.RootHead_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.RootHead_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.RootHead_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RootHead_X.value,
                        CharacterDetails.RootHead_Y.value,
                        CharacterDetails.RootHead_Z.value,
                        CharacterDetails.RootHead_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RootHead_Toggle = false;
                    CharacterDetails.RootHead_Rotate = true;
                }

                if (CharacterDetails.Jaw_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Jaw_X), 16);
                    CharacterDetails.Jaw_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Jaw_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Jaw_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Jaw_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Jaw_X.value,
                        CharacterDetails.Jaw_Y.value,
                        CharacterDetails.Jaw_Z.value,
                        CharacterDetails.Jaw_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Jaw_Toggle = false;
                    CharacterDetails.Jaw_Rotate = true;
                }

                if (CharacterDetails.EyelidLowerLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerLeft_X), 16);
                    CharacterDetails.EyelidLowerLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EyelidLowerLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EyelidLowerLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EyelidLowerLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyelidLowerLeft_X.value,
                        CharacterDetails.EyelidLowerLeft_Y.value,
                        CharacterDetails.EyelidLowerLeft_Z.value,
                        CharacterDetails.EyelidLowerLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyelidLowerLeft_Toggle = false;
                    CharacterDetails.EyelidLowerLeft_Rotate = true;
                }

                if (CharacterDetails.EyelidLowerRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerRight_X), 16);
                    CharacterDetails.EyelidLowerRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EyelidLowerRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EyelidLowerRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EyelidLowerRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyelidLowerRight_X.value,
                        CharacterDetails.EyelidLowerRight_Y.value,
                        CharacterDetails.EyelidLowerRight_Z.value,
                        CharacterDetails.EyelidLowerRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyelidLowerRight_Toggle = false;
                    CharacterDetails.EyelidLowerRight_Rotate = true;
                }

                if (CharacterDetails.EyeLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeLeft_X), 16);
                    CharacterDetails.EyeLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EyeLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EyeLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EyeLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyeLeft_X.value,
                        CharacterDetails.EyeLeft_Y.value,
                        CharacterDetails.EyeLeft_Z.value,
                        CharacterDetails.EyeLeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyeLeft_Toggle = false;
                    CharacterDetails.EyeLeft_Rotate = true;
                }

                if (CharacterDetails.EyeRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeRight_X), 16);
                    CharacterDetails.EyeRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EyeRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EyeRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EyeRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyeRight_X.value,
                        CharacterDetails.EyeRight_Y.value,
                        CharacterDetails.EyeRight_Z.value,
                        CharacterDetails.EyeRight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyeRight_Toggle = false;
                    CharacterDetails.EyeRight_Rotate = true;
                }

                if (CharacterDetails.Nose_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Nose_X), 16);
                    CharacterDetails.Nose_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Nose_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Nose_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Nose_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Nose_X.value,
                        CharacterDetails.Nose_Y.value,
                        CharacterDetails.Nose_Z.value,
                        CharacterDetails.Nose_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Nose_Toggle = false;
                    CharacterDetails.Nose_Rotate = true;
                }

                if (CharacterDetails.CheekLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekLeft_X), 16);
                    CharacterDetails.CheekLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.CheekLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.CheekLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.CheekLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.CheekLeft_X.value,
                        CharacterDetails.CheekLeft_Y.value,
                        CharacterDetails.CheekLeft_Z.value,
                        CharacterDetails.CheekLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.CheekLeft_Toggle = false;
                    CharacterDetails.CheekLeft_Rotate = true;
                }

                if (CharacterDetails.HrothWhiskersLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersLeft_X), 16);
                    CharacterDetails.HrothWhiskersLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothWhiskersLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothWhiskersLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothWhiskersLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothWhiskersLeft_X.value,
                        CharacterDetails.HrothWhiskersLeft_Y.value,
                        CharacterDetails.HrothWhiskersLeft_Z.value,
                        CharacterDetails.HrothWhiskersLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothWhiskersLeft_Toggle = false;
                    CharacterDetails.HrothWhiskersLeft_Rotate = true;
                }

                if (CharacterDetails.CheekRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekRight_X), 16);
                    CharacterDetails.CheekRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.CheekRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.CheekRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.CheekRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.CheekRight_X.value,
                        CharacterDetails.CheekRight_Y.value,
                        CharacterDetails.CheekRight_Z.value,
                        CharacterDetails.CheekRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.CheekRight_Toggle = false;
                    CharacterDetails.CheekRight_Rotate = true;
                }

                if (CharacterDetails.HrothWhiskersRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersRight_X), 16);
                    CharacterDetails.HrothWhiskersRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothWhiskersRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothWhiskersRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothWhiskersRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothWhiskersRight_X.value,
                        CharacterDetails.HrothWhiskersRight_Y.value,
                        CharacterDetails.HrothWhiskersRight_Z.value,
                        CharacterDetails.HrothWhiskersRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothWhiskersRight_Toggle = false;
                    CharacterDetails.HrothWhiskersRight_Rotate = true;
                }

                if (CharacterDetails.LipsLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsLeft_X), 16);
                    CharacterDetails.LipsLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.LipsLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.LipsLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.LipsLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LipsLeft_X.value,
                        CharacterDetails.LipsLeft_Y.value,
                        CharacterDetails.LipsLeft_Z.value,
                        CharacterDetails.LipsLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LipsLeft_Toggle = false;
                    CharacterDetails.LipsLeft_Rotate = true;
                }

                if (CharacterDetails.HrothEyebrowLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowLeft_X), 16);
                    CharacterDetails.HrothEyebrowLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothEyebrowLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothEyebrowLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothEyebrowLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothEyebrowLeft_X.value,
                        CharacterDetails.HrothEyebrowLeft_Y.value,
                        CharacterDetails.HrothEyebrowLeft_Z.value,
                        CharacterDetails.HrothEyebrowLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothEyebrowLeft_Toggle = false;
                    CharacterDetails.HrothEyebrowLeft_Rotate = true;
                }

                if (CharacterDetails.LipsRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsRight_X), 16);
                    CharacterDetails.LipsRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.LipsRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.LipsRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.LipsRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LipsRight_X.value,
                        CharacterDetails.LipsRight_Y.value,
                        CharacterDetails.LipsRight_Z.value,
                        CharacterDetails.LipsRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LipsRight_Toggle = false;
                    CharacterDetails.LipsRight_Rotate = true;
                }

                if (CharacterDetails.HrothEyebrowRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowRight_X), 16);
                    CharacterDetails.HrothEyebrowRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothEyebrowRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothEyebrowRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothEyebrowRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothEyebrowRight_X.value,
                        CharacterDetails.HrothEyebrowRight_Y.value,
                        CharacterDetails.HrothEyebrowRight_Z.value,
                        CharacterDetails.HrothEyebrowRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothEyebrowRight_Toggle = false;
                    CharacterDetails.HrothEyebrowRight_Rotate = true;
                }

                if (CharacterDetails.EyebrowLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowLeft_X), 16);
                    CharacterDetails.EyebrowLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EyebrowLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EyebrowLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EyebrowLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyebrowLeft_X.value,
                        CharacterDetails.EyebrowLeft_Y.value,
                        CharacterDetails.EyebrowLeft_Z.value,
                        CharacterDetails.EyebrowLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyebrowLeft_Toggle = false;
                    CharacterDetails.EyebrowLeft_Rotate = true;
                }

                if (CharacterDetails.HrothBridge_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBridge_X), 16);
                    CharacterDetails.HrothBridge_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothBridge_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothBridge_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothBridge_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothBridge_X.value,
                        CharacterDetails.HrothBridge_Y.value,
                        CharacterDetails.HrothBridge_Z.value,
                        CharacterDetails.HrothBridge_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothBridge_Toggle = false;
                    CharacterDetails.HrothBridge_Rotate = true;
                }

                if (CharacterDetails.EyebrowRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowRight_X), 16);
                    CharacterDetails.EyebrowRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EyebrowRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EyebrowRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EyebrowRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyebrowRight_X.value,
                        CharacterDetails.EyebrowRight_Y.value,
                        CharacterDetails.EyebrowRight_Z.value,
                        CharacterDetails.EyebrowRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyebrowRight_Toggle = false;
                    CharacterDetails.EyebrowRight_Rotate = true;
                }

                if (CharacterDetails.HrothBrowLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowLeft_X), 16);
                    CharacterDetails.HrothBrowLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothBrowLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothBrowLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothBrowLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothBrowLeft_X.value,
                        CharacterDetails.HrothBrowLeft_Y.value,
                        CharacterDetails.HrothBrowLeft_Z.value,
                        CharacterDetails.HrothBrowLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothBrowLeft_Toggle = false;
                    CharacterDetails.HrothBrowLeft_Rotate = true;
                }

                if (CharacterDetails.Bridge_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.Bridge_X), 16);
                    CharacterDetails.Bridge_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.Bridge_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.Bridge_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.Bridge_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Bridge_X.value,
                        CharacterDetails.Bridge_Y.value,
                        CharacterDetails.Bridge_Z.value,
                        CharacterDetails.Bridge_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Bridge_Toggle = false;
                    CharacterDetails.Bridge_Rotate = true;
                }

                if (CharacterDetails.HrothBrowRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowRight_X), 16);
                    CharacterDetails.HrothBrowRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothBrowRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothBrowRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothBrowRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothBrowRight_X.value,
                        CharacterDetails.HrothBrowRight_Y.value,
                        CharacterDetails.HrothBrowRight_Z.value,
                        CharacterDetails.HrothBrowRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothBrowRight_Toggle = false;
                    CharacterDetails.HrothBrowRight_Rotate = true;
                }

                if (CharacterDetails.BrowLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowLeft_X), 16);
                    CharacterDetails.BrowLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.BrowLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.BrowLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.BrowLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.BrowLeft_X.value,
                        CharacterDetails.BrowLeft_Y.value,
                        CharacterDetails.BrowLeft_Z.value,
                        CharacterDetails.BrowLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.BrowLeft_Toggle = false;
                    CharacterDetails.BrowLeft_Rotate = true;
                }

                if (CharacterDetails.HrothJawUpper_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothJawUpper_X), 16);
                    CharacterDetails.HrothJawUpper_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothJawUpper_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothJawUpper_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothJawUpper_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothJawUpper_X.value,
                        CharacterDetails.HrothJawUpper_Y.value,
                        CharacterDetails.HrothJawUpper_Z.value,
                        CharacterDetails.HrothJawUpper_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothJawUpper_Toggle = false;
                    CharacterDetails.HrothJawUpper_Rotate = true;
                }

                if (CharacterDetails.BrowRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowRight_X), 16);
                    CharacterDetails.BrowRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.BrowRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.BrowRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.BrowRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.BrowRight_X.value,
                        CharacterDetails.BrowRight_Y.value,
                        CharacterDetails.BrowRight_Z.value,
                        CharacterDetails.BrowRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.BrowRight_Toggle = false;
                    CharacterDetails.BrowRight_Rotate = true;
                }

                if (CharacterDetails.HrothLipUpper_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpper_X), 16);
                    CharacterDetails.HrothLipUpper_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothLipUpper_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothLipUpper_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothLipUpper_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothLipUpper_X.value,
                        CharacterDetails.HrothLipUpper_Y.value,
                        CharacterDetails.HrothLipUpper_Z.value,
                        CharacterDetails.HrothLipUpper_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothLipUpper_Toggle = false;
                    CharacterDetails.HrothLipUpper_Rotate = true;
                }

                if (CharacterDetails.LipUpperA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperA_X), 16);
                    CharacterDetails.LipUpperA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.LipUpperA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.LipUpperA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.LipUpperA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LipUpperA_X.value,
                        CharacterDetails.LipUpperA_Y.value,
                        CharacterDetails.LipUpperA_Z.value,
                        CharacterDetails.LipUpperA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LipUpperA_Toggle = false;
                    CharacterDetails.LipUpperA_Rotate = true;
                }

                if (CharacterDetails.HrothEyelidUpperLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_X), 16);
                    CharacterDetails.HrothEyelidUpperLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothEyelidUpperLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothEyelidUpperLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothEyelidUpperLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothEyelidUpperLeft_X.value,
                        CharacterDetails.HrothEyelidUpperLeft_Y.value,
                        CharacterDetails.HrothEyelidUpperLeft_Z.value,
                        CharacterDetails.HrothEyelidUpperLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothEyelidUpperLeft_Toggle = false;
                    CharacterDetails.HrothEyelidUpperLeft_Rotate = true;
                }

                if (CharacterDetails.EyelidUpperLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperLeft_X), 16);
                    CharacterDetails.EyelidUpperLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EyelidUpperLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EyelidUpperLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EyelidUpperLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyelidUpperLeft_X.value,
                        CharacterDetails.EyelidUpperLeft_Y.value,
                        CharacterDetails.EyelidUpperLeft_Z.value,
                        CharacterDetails.EyelidUpperLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyelidUpperLeft_Toggle = false;
                    CharacterDetails.EyelidUpperLeft_Rotate = true;
                }

                if (CharacterDetails.HrothEyelidUpperRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_X), 16);
                    CharacterDetails.HrothEyelidUpperRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothEyelidUpperRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothEyelidUpperRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothEyelidUpperRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothEyelidUpperRight_X.value,
                        CharacterDetails.HrothEyelidUpperRight_Y.value,
                        CharacterDetails.HrothEyelidUpperRight_Z.value,
                        CharacterDetails.HrothEyelidUpperRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothEyelidUpperRight_Toggle = false;
                    CharacterDetails.HrothEyelidUpperRight_Rotate = true;
                }

                if (CharacterDetails.EyelidUpperRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperRight_X), 16);
                    CharacterDetails.EyelidUpperRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.EyelidUpperRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.EyelidUpperRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.EyelidUpperRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyelidUpperRight_X.value,
                        CharacterDetails.EyelidUpperRight_Y.value,
                        CharacterDetails.EyelidUpperRight_Z.value,
                        CharacterDetails.EyelidUpperRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyelidUpperRight_Toggle = false;
                    CharacterDetails.EyelidUpperRight_Rotate = true;
                }

                if (CharacterDetails.HrothLipsLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsLeft_X), 16);
                    CharacterDetails.HrothLipsLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothLipsLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothLipsLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothLipsLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothLipsLeft_X.value,
                        CharacterDetails.HrothLipsLeft_Y.value,
                        CharacterDetails.HrothLipsLeft_Z.value,
                        CharacterDetails.HrothLipsLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothLipsLeft_Toggle = false;
                    CharacterDetails.HrothLipsLeft_Rotate = true;
                }

                if (CharacterDetails.LipLowerA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerA_X), 16);
                    CharacterDetails.LipLowerA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.LipLowerA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.LipLowerA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.LipLowerA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LipLowerA_X.value,
                        CharacterDetails.LipLowerA_Y.value,
                        CharacterDetails.LipLowerA_Z.value,
                        CharacterDetails.LipLowerA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LipLowerA_Toggle = false;
                    CharacterDetails.LipLowerA_Rotate = true;
                }

                if (CharacterDetails.HrothLipsRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsRight_X), 16);
                    CharacterDetails.HrothLipsRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothLipsRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothLipsRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothLipsRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothLipsRight_X.value,
                        CharacterDetails.HrothLipsRight_Y.value,
                        CharacterDetails.HrothLipsRight_Z.value,
                        CharacterDetails.HrothLipsRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothLipsRight_Toggle = false;
                    CharacterDetails.HrothLipsRight_Rotate = true;
                }

                if (CharacterDetails.VieraEar01ALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ALeft_X), 16);
                    CharacterDetails.VieraEar01ALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar01ALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar01ALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar01ALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar01ALeft_X.value,
                        CharacterDetails.VieraEar01ALeft_Y.value,
                        CharacterDetails.VieraEar01ALeft_Z.value,
                        CharacterDetails.VieraEar01ALeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar01ALeft_Toggle = false;
                    CharacterDetails.VieraEar01ALeft_Rotate = true;
                }

                if (CharacterDetails.LipUpperB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperB_X), 16);
                    CharacterDetails.LipUpperB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.LipUpperB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.LipUpperB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.LipUpperB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LipUpperB_X.value,
                        CharacterDetails.LipUpperB_Y.value,
                        CharacterDetails.LipUpperB_Z.value,
                        CharacterDetails.LipUpperB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LipUpperB_Toggle = false;
                    CharacterDetails.LipUpperB_Rotate = true;
                }

                if (CharacterDetails.HrothLipUpperLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperLeft_X), 16);
                    CharacterDetails.HrothLipUpperLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothLipUpperLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothLipUpperLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothLipUpperLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothLipUpperLeft_X.value,
                        CharacterDetails.HrothLipUpperLeft_Y.value,
                        CharacterDetails.HrothLipUpperLeft_Z.value,
                        CharacterDetails.HrothLipUpperLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothLipUpperLeft_Toggle = false;
                    CharacterDetails.HrothLipUpperLeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar01ARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ARight_X), 16);
                    CharacterDetails.VieraEar01ARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar01ARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar01ARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar01ARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar01ARight_X.value,
                        CharacterDetails.VieraEar01ARight_Y.value,
                        CharacterDetails.VieraEar01ARight_Z.value,
                        CharacterDetails.VieraEar01ARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar01ARight_Toggle = false;
                    CharacterDetails.VieraEar01ARight_Rotate = true;
                }

                if (CharacterDetails.LipLowerB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerB_X), 16);
                    CharacterDetails.LipLowerB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.LipLowerB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.LipLowerB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.LipLowerB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LipLowerB_X.value,
                        CharacterDetails.LipLowerB_Y.value,
                        CharacterDetails.LipLowerB_Z.value,
                        CharacterDetails.LipLowerB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LipLowerB_Toggle = false;
                    CharacterDetails.LipLowerB_Rotate = true;
                }

                if (CharacterDetails.HrothLipUpperRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperRight_X), 16);
                    CharacterDetails.HrothLipUpperRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothLipUpperRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothLipUpperRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothLipUpperRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothLipUpperRight_X.value,
                        CharacterDetails.HrothLipUpperRight_Y.value,
                        CharacterDetails.HrothLipUpperRight_Z.value,
                        CharacterDetails.HrothLipUpperRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothLipUpperRight_Toggle = false;
                    CharacterDetails.HrothLipUpperRight_Rotate = true;
                }

                if (CharacterDetails.VieraEar02ALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ALeft_X), 16);
                    CharacterDetails.VieraEar02ALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar02ALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar02ALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar02ALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar02ALeft_X.value,
                        CharacterDetails.VieraEar02ALeft_Y.value,
                        CharacterDetails.VieraEar02ALeft_Z.value,
                        CharacterDetails.VieraEar02ALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar02ALeft_Toggle = false;
                    CharacterDetails.VieraEar02ALeft_Rotate = true;
                }

                if (CharacterDetails.HrothLipLower_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipLower_X), 16);
                    CharacterDetails.HrothLipLower_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.HrothLipLower_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.HrothLipLower_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.HrothLipLower_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HrothLipLower_X.value,
                        CharacterDetails.HrothLipLower_Y.value,
                        CharacterDetails.HrothLipLower_Z.value,
                        CharacterDetails.HrothLipLower_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HrothLipLower_Toggle = false;
                    CharacterDetails.HrothLipLower_Rotate = true;
                }

                if (CharacterDetails.VieraEar02ARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ARight_X), 16);
                    CharacterDetails.VieraEar02ARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar02ARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar02ARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar02ARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar02ARight_X.value,
                        CharacterDetails.VieraEar02ARight_Y.value,
                        CharacterDetails.VieraEar02ARight_Z.value,
                        CharacterDetails.VieraEar02ARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar02ARight_Toggle = false;
                    CharacterDetails.VieraEar02ARight_Rotate = true;
                }

                if (CharacterDetails.VieraEar03ALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ALeft_X), 16);
                    CharacterDetails.VieraEar03ALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar03ALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar03ALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar03ALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar03ALeft_X.value,
                        CharacterDetails.VieraEar03ALeft_Y.value,
                        CharacterDetails.VieraEar03ALeft_Z.value,
                        CharacterDetails.VieraEar03ALeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar03ALeft_Toggle = false;
                    CharacterDetails.VieraEar03ALeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar03ARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ARight_X), 16);
                    CharacterDetails.VieraEar03ARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar03ARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar03ARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar03ARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar03ARight_X.value,
                        CharacterDetails.VieraEar03ARight_Y.value,
                        CharacterDetails.VieraEar03ARight_Z.value,
                        CharacterDetails.VieraEar03ARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar03ARight_Toggle = false;
                    CharacterDetails.VieraEar03ARight_Rotate = true;
                }

                if (CharacterDetails.VieraEar04ALeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ALeft_X), 16);
                    CharacterDetails.VieraEar04ALeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar04ALeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar04ALeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar04ALeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar04ALeft_X.value,
                        CharacterDetails.VieraEar04ALeft_Y.value,
                        CharacterDetails.VieraEar04ALeft_Z.value,
                        CharacterDetails.VieraEar04ALeft_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar04ALeft_Toggle = false;
                    CharacterDetails.VieraEar04ALeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar04ARight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ARight_X), 16);
                    CharacterDetails.VieraEar04ARight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar04ARight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar04ARight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar04ARight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar04ARight_X.value,
                        CharacterDetails.VieraEar04ARight_Y.value,
                        CharacterDetails.VieraEar04ARight_Z.value,
                        CharacterDetails.VieraEar04ARight_W.value
                    ).ToEulerAngles();
                    MainViewModel.ViewTime5.newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar04ARight_Toggle = false;
                    CharacterDetails.VieraEar04ARight_Rotate = true;
                }

                if (CharacterDetails.VieraLipLowerA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerA_X), 16);
                    CharacterDetails.VieraLipLowerA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraLipLowerA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraLipLowerA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraLipLowerA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraLipLowerA_X.value,
                        CharacterDetails.VieraLipLowerA_Y.value,
                        CharacterDetails.VieraLipLowerA_Z.value,
                        CharacterDetails.VieraLipLowerA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraLipLowerA_Toggle = false;
                    CharacterDetails.VieraLipLowerA_Rotate = true;
                }

                if (CharacterDetails.VieraLipUpperB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipUpperB_X), 16);
                    CharacterDetails.VieraLipUpperB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraLipUpperB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraLipUpperB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraLipUpperB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraLipUpperB_X.value,
                        CharacterDetails.VieraLipUpperB_Y.value,
                        CharacterDetails.VieraLipUpperB_Z.value,
                        CharacterDetails.VieraLipUpperB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraLipUpperB_Toggle = false;
                    CharacterDetails.VieraLipUpperB_Rotate = true;
                }

                if (CharacterDetails.VieraEar01BLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BLeft_X), 16);
                    CharacterDetails.VieraEar01BLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar01BLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar01BLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar01BLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar01BLeft_X.value,
                        CharacterDetails.VieraEar01BLeft_Y.value,
                        CharacterDetails.VieraEar01BLeft_Z.value,
                        CharacterDetails.VieraEar01BLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar01BLeft_Toggle = false;
                    CharacterDetails.VieraEar01BLeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar01BRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BRight_X), 16);
                    CharacterDetails.VieraEar01BRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar01BRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar01BRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar01BRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar01BRight_X.value,
                        CharacterDetails.VieraEar01BRight_Y.value,
                        CharacterDetails.VieraEar01BRight_Z.value,
                        CharacterDetails.VieraEar01BRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar01BRight_Toggle = false;
                    CharacterDetails.VieraEar01BRight_Rotate = true;
                }

                if (CharacterDetails.VieraEar02BLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BLeft_X), 16);
                    CharacterDetails.VieraEar02BLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar02BLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar02BLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar02BLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar02BLeft_X.value,
                        CharacterDetails.VieraEar02BLeft_Y.value,
                        CharacterDetails.VieraEar02BLeft_Z.value,
                        CharacterDetails.VieraEar02BLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar02BLeft_Toggle = false;
                    CharacterDetails.VieraEar02BLeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar02BRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BRight_X), 16);
                    CharacterDetails.VieraEar02BRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar02BRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar02BRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar02BRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar02BRight_X.value,
                        CharacterDetails.VieraEar02BRight_Y.value,
                        CharacterDetails.VieraEar02BRight_Z.value,
                        CharacterDetails.VieraEar02BRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar02BRight_Toggle = false;
                    CharacterDetails.VieraEar02BRight_Rotate = true;
                }

                if (CharacterDetails.VieraEar03BLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BLeft_X), 16);
                    CharacterDetails.VieraEar03BLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar03BLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar03BLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar03BLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar03BLeft_X.value,
                        CharacterDetails.VieraEar03BLeft_Y.value,
                        CharacterDetails.VieraEar03BLeft_Z.value,
                        CharacterDetails.VieraEar03BLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar03BLeft_Toggle = false;
                    CharacterDetails.VieraEar03BLeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar03BRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BRight_X), 16);
                    CharacterDetails.VieraEar03BRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar03BRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar03BRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar03BRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar03BRight_X.value,
                        CharacterDetails.VieraEar03BRight_Y.value,
                        CharacterDetails.VieraEar03BRight_Z.value,
                        CharacterDetails.VieraEar03BRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar03BRight_Toggle = false;
                    CharacterDetails.VieraEar03BRight_Rotate = true;
                }

                if (CharacterDetails.VieraEar04BLeft_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BLeft_X), 16);
                    CharacterDetails.VieraEar04BLeft_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar04BLeft_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar04BLeft_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar04BLeft_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar04BLeft_X.value,
                        CharacterDetails.VieraEar04BLeft_Y.value,
                        CharacterDetails.VieraEar04BLeft_Z.value,
                        CharacterDetails.VieraEar04BLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar04BLeft_Toggle = false;
                    CharacterDetails.VieraEar04BLeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar04BRight_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BRight_X), 16);
                    CharacterDetails.VieraEar04BRight_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraEar04BRight_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraEar04BRight_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraEar04BRight_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar04BRight_X.value,
                        CharacterDetails.VieraEar04BRight_Y.value,
                        CharacterDetails.VieraEar04BRight_Z.value,
                        CharacterDetails.VieraEar04BRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar04BRight_Toggle = false;
                    CharacterDetails.VieraEar04BRight_Rotate = true;
                }

                if (CharacterDetails.VieraLipLowerB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerB_X), 16);
                    CharacterDetails.VieraLipLowerB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.VieraLipLowerB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.VieraLipLowerB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.VieraLipLowerB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraLipLowerB_X.value,
                        CharacterDetails.VieraLipLowerB_Y.value,
                        CharacterDetails.VieraLipLowerB_Z.value,
                        CharacterDetails.VieraLipLowerB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraLipLowerB_Toggle = false;
                    CharacterDetails.VieraLipLowerB_Rotate = true;
                }

                if (CharacterDetails.ExRootHair_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootHair_X), 16);
                    CharacterDetails.ExRootHair_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExRootHair_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExRootHair_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExRootHair_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExRootHair_X.value,
                        CharacterDetails.ExRootHair_Y.value,
                        CharacterDetails.ExRootHair_Z.value,
                        CharacterDetails.ExRootHair_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExRootHair_Toggle = false;
                    CharacterDetails.ExRootHair_Rotate = true;
                }

                if (CharacterDetails.ExHairA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairA_X), 16);
                    CharacterDetails.ExHairA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairA_X.value,
                        CharacterDetails.ExHairA_Y.value,
                        CharacterDetails.ExHairA_Z.value,
                        CharacterDetails.ExHairA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairA_Toggle = false;
                    CharacterDetails.ExHairA_Rotate = true;
                }

                if (CharacterDetails.ExHairB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairB_X), 16);
                    CharacterDetails.ExHairB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairB_X.value,
                        CharacterDetails.ExHairB_Y.value,
                        CharacterDetails.ExHairB_Z.value,
                        CharacterDetails.ExHairB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairB_Toggle = false;
                    CharacterDetails.ExHairB_Rotate = true;
                }

                if (CharacterDetails.ExHairC_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairC_X), 16);
                    CharacterDetails.ExHairC_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairC_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairC_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairC_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairC_X.value,
                        CharacterDetails.ExHairC_Y.value,
                        CharacterDetails.ExHairC_Z.value,
                        CharacterDetails.ExHairC_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairC_Toggle = false;
                    CharacterDetails.ExHairC_Rotate = true;
                }

                if (CharacterDetails.ExHairD_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairD_X), 16);
                    CharacterDetails.ExHairD_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairD_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairD_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairD_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairD_X.value,
                        CharacterDetails.ExHairD_Y.value,
                        CharacterDetails.ExHairD_Z.value,
                        CharacterDetails.ExHairD_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairD_Toggle = false;
                    CharacterDetails.ExHairD_Rotate = true;
                }

                if (CharacterDetails.ExHairE_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairE_X), 16);
                    CharacterDetails.ExHairE_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairE_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairE_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairE_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairE_X.value,
                        CharacterDetails.ExHairE_Y.value,
                        CharacterDetails.ExHairE_Z.value,
                        CharacterDetails.ExHairE_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairE_Toggle = false;
                    CharacterDetails.ExHairE_Rotate = true;
                }

                if (CharacterDetails.ExHairF_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairF_X), 16);
                    CharacterDetails.ExHairF_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairF_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairF_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairF_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairF_X.value,
                        CharacterDetails.ExHairF_Y.value,
                        CharacterDetails.ExHairF_Z.value,
                        CharacterDetails.ExHairF_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairF_Toggle = false;
                    CharacterDetails.ExHairF_Rotate = true;
                }

                if (CharacterDetails.ExHairG_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairG_X), 16);
                    CharacterDetails.ExHairG_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairG_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairG_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairG_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairG_X.value,
                        CharacterDetails.ExHairG_Y.value,
                        CharacterDetails.ExHairG_Z.value,
                        CharacterDetails.ExHairG_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairG_Toggle = false;
                    CharacterDetails.ExHairG_Rotate = true;
                }

                if (CharacterDetails.ExHairH_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairH_X), 16);
                    CharacterDetails.ExHairH_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairH_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairH_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairH_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairH_X.value,
                        CharacterDetails.ExHairH_Y.value,
                        CharacterDetails.ExHairH_Z.value,
                        CharacterDetails.ExHairH_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairH_Toggle = false;
                    CharacterDetails.ExHairH_Rotate = true;
                }

                if (CharacterDetails.ExHairI_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairI_X), 16);
                    CharacterDetails.ExHairI_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairI_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairI_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairI_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairI_X.value,
                        CharacterDetails.ExHairI_Y.value,
                        CharacterDetails.ExHairI_Z.value,
                        CharacterDetails.ExHairI_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairI_Toggle = false;
                    CharacterDetails.ExHairI_Rotate = true;
                }

                if (CharacterDetails.ExHairJ_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairJ_X), 16);
                    CharacterDetails.ExHairJ_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairJ_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairJ_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairJ_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairJ_X.value,
                        CharacterDetails.ExHairJ_Y.value,
                        CharacterDetails.ExHairJ_Z.value,
                        CharacterDetails.ExHairJ_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairJ_Toggle = false;
                    CharacterDetails.ExHairJ_Rotate = true;
                }

                if (CharacterDetails.ExHairK_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairK_X), 16);
                    CharacterDetails.ExHairK_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairK_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairK_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairK_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairK_X.value,
                        CharacterDetails.ExHairK_Y.value,
                        CharacterDetails.ExHairK_Z.value,
                        CharacterDetails.ExHairK_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairK_Toggle = false;
                    CharacterDetails.ExHairK_Rotate = true;
                }

                if (CharacterDetails.ExHairL_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairL_X), 16);
                    CharacterDetails.ExHairL_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExHairL_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExHairL_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExHairL_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExHairL_X.value,
                        CharacterDetails.ExHairL_Y.value,
                        CharacterDetails.ExHairL_Z.value,
                        CharacterDetails.ExHairL_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExHairL_Toggle = false;
                    CharacterDetails.ExHairL_Rotate = true;
                }

                if (CharacterDetails.ExRootMet_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootMet_X), 16);
                    CharacterDetails.ExRootMet_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExRootMet_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExRootMet_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExRootMet_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExRootMet_X.value,
                        CharacterDetails.ExRootMet_Y.value,
                        CharacterDetails.ExRootMet_Z.value,
                        CharacterDetails.ExRootMet_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExRootMet_Toggle = false;
                    CharacterDetails.ExRootMet_Rotate = true;
                }

                if (CharacterDetails.ExMetA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetA_X), 16);
                    CharacterDetails.ExMetA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetA_X.value,
                        CharacterDetails.ExMetA_Y.value,
                        CharacterDetails.ExMetA_Z.value,
                        CharacterDetails.ExMetA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetA_Toggle = false;
                    CharacterDetails.ExMetA_Rotate = true;
                }

                if (CharacterDetails.ExMetB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetB_X), 16);
                    CharacterDetails.ExMetB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetB_X.value,
                        CharacterDetails.ExMetB_Y.value,
                        CharacterDetails.ExMetB_Z.value,
                        CharacterDetails.ExMetB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetB_Toggle = false;
                    CharacterDetails.ExMetB_Rotate = true;
                }

                if (CharacterDetails.ExMetC_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetC_X), 16);
                    CharacterDetails.ExMetC_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetC_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetC_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetC_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetC_X.value,
                        CharacterDetails.ExMetC_Y.value,
                        CharacterDetails.ExMetC_Z.value,
                        CharacterDetails.ExMetC_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetC_Toggle = false;
                    CharacterDetails.ExMetC_Rotate = true;
                }

                if (CharacterDetails.ExMetD_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetD_X), 16);
                    CharacterDetails.ExMetD_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetD_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetD_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetD_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetD_X.value,
                        CharacterDetails.ExMetD_Y.value,
                        CharacterDetails.ExMetD_Z.value,
                        CharacterDetails.ExMetD_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetD_Toggle = false;
                    CharacterDetails.ExMetD_Rotate = true;
                }

                if (CharacterDetails.ExMetE_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetE_X), 16);
                    CharacterDetails.ExMetE_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetE_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetE_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetE_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetE_X.value,
                        CharacterDetails.ExMetE_Y.value,
                        CharacterDetails.ExMetE_Z.value,
                        CharacterDetails.ExMetE_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetE_Toggle = false;
                    CharacterDetails.ExMetE_Rotate = true;
                }

                if (CharacterDetails.ExMetF_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetF_X), 16);
                    CharacterDetails.ExMetF_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetF_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetF_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetF_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetF_X.value,
                        CharacterDetails.ExMetF_Y.value,
                        CharacterDetails.ExMetF_Z.value,
                        CharacterDetails.ExMetF_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetF_Toggle = false;
                    CharacterDetails.ExMetF_Rotate = true;
                }

                if (CharacterDetails.ExMetG_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetG_X), 16);
                    CharacterDetails.ExMetG_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetG_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetG_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetG_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetG_X.value,
                        CharacterDetails.ExMetG_Y.value,
                        CharacterDetails.ExMetG_Z.value,
                        CharacterDetails.ExMetG_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetG_Toggle = false;
                    CharacterDetails.ExMetG_Rotate = true;
                }

                if (CharacterDetails.ExMetH_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetH_X), 16);
                    CharacterDetails.ExMetH_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetH_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetH_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetH_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetH_X.value,
                        CharacterDetails.ExMetH_Y.value,
                        CharacterDetails.ExMetH_Z.value,
                        CharacterDetails.ExMetH_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetH_Toggle = false;
                    CharacterDetails.ExMetH_Rotate = true;
                }

                if (CharacterDetails.ExMetI_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetI_X), 16);
                    CharacterDetails.ExMetI_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetI_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetI_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetI_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetI_X.value,
                        CharacterDetails.ExMetI_Y.value,
                        CharacterDetails.ExMetI_Z.value,
                        CharacterDetails.ExMetI_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetI_Toggle = false;
                    CharacterDetails.ExMetI_Rotate = true;
                }

                if (CharacterDetails.ExMetJ_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetJ_X), 16);
                    CharacterDetails.ExMetJ_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetJ_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetJ_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetJ_W.value = BitConverter.ToSingle(bytearray, 12);

                    CharacterDetails.ExMetJ_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetJ_X));
                    CharacterDetails.ExMetJ_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetJ_Y));
                    CharacterDetails.ExMetJ_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetJ_Z));
                    CharacterDetails.ExMetJ_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetJ_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetJ_X.value,
                        CharacterDetails.ExMetJ_Y.value,
                        CharacterDetails.ExMetJ_Z.value,
                        CharacterDetails.ExMetJ_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetJ_Toggle = false;
                    CharacterDetails.ExMetJ_Rotate = true;
                }

                if (CharacterDetails.ExMetK_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetK_X), 16);
                    CharacterDetails.ExMetK_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetK_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetK_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetK_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetK_X.value,
                        CharacterDetails.ExMetK_Y.value,
                        CharacterDetails.ExMetK_Z.value,
                        CharacterDetails.ExMetK_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetK_Toggle = false;
                    CharacterDetails.ExMetK_Rotate = true;
                }

                if (CharacterDetails.ExMetL_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetL_X), 16);
                    CharacterDetails.ExMetL_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetL_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetL_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetL_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetL_X.value,
                        CharacterDetails.ExMetL_Y.value,
                        CharacterDetails.ExMetL_Z.value,
                        CharacterDetails.ExMetL_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetL_Toggle = false;
                    CharacterDetails.ExMetL_Rotate = true;
                }

                if (CharacterDetails.ExMetM_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetM_X), 16);
                    CharacterDetails.ExMetM_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetM_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetM_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetM_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetM_X.value,
                        CharacterDetails.ExMetM_Y.value,
                        CharacterDetails.ExMetM_Z.value,
                        CharacterDetails.ExMetM_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetM_Toggle = false;
                    CharacterDetails.ExMetM_Rotate = true;
                }

                if (CharacterDetails.ExMetN_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetN_X), 16);
                    CharacterDetails.ExMetN_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetN_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetN_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetN_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetN_X.value,
                        CharacterDetails.ExMetN_Y.value,
                        CharacterDetails.ExMetN_Z.value,
                        CharacterDetails.ExMetN_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetN_Toggle = false;
                    CharacterDetails.ExMetN_Rotate = true;
                }

                if (CharacterDetails.ExMetO_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetO_X), 16);
                    CharacterDetails.ExMetO_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetO_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetO_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetO_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetO_X.value,
                        CharacterDetails.ExMetO_Y.value,
                        CharacterDetails.ExMetO_Z.value,
                        CharacterDetails.ExMetO_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetO_Toggle = false;
                    CharacterDetails.ExMetO_Rotate = true;
                }

                if (CharacterDetails.ExMetP_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetP_X), 16);
                    CharacterDetails.ExMetP_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetP_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetP_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetP_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetP_X.value,
                        CharacterDetails.ExMetP_Y.value,
                        CharacterDetails.ExMetP_Z.value,
                        CharacterDetails.ExMetP_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetP_Toggle = false;
                    CharacterDetails.ExMetP_Rotate = true;
                }

                if (CharacterDetails.ExMetQ_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetQ_X), 16);
                    CharacterDetails.ExMetQ_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetQ_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetQ_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetQ_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetQ_X.value,
                        CharacterDetails.ExMetQ_Y.value,
                        CharacterDetails.ExMetQ_Z.value,
                        CharacterDetails.ExMetQ_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetQ_Toggle = false;
                    CharacterDetails.ExMetQ_Rotate = true;
                }

                if (CharacterDetails.ExMetR_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetR_X), 16);
                    CharacterDetails.ExMetR_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExMetR_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExMetR_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExMetR_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExMetR_X.value,
                        CharacterDetails.ExMetR_Y.value,
                        CharacterDetails.ExMetR_Z.value,
                        CharacterDetails.ExMetR_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExMetR_Toggle = false;
                    CharacterDetails.ExMetR_Rotate = true;
                }

                if (CharacterDetails.ExRootTop_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootTop_X), 16);
                    CharacterDetails.ExRootTop_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExRootTop_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExRootTop_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExRootTop_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExRootTop_X.value,
                        CharacterDetails.ExRootTop_Y.value,
                        CharacterDetails.ExRootTop_Z.value,
                        CharacterDetails.ExRootTop_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExRootTop_Toggle = false;
                    CharacterDetails.ExRootTop_Rotate = true;
                }

                if (CharacterDetails.ExTopA_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopA_X), 16);
                    CharacterDetails.ExTopA_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopA_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopA_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopA_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopA_X.value,
                        CharacterDetails.ExTopA_Y.value,
                        CharacterDetails.ExTopA_Z.value,
                        CharacterDetails.ExTopA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopA_Toggle = false;
                    CharacterDetails.ExTopA_Rotate = true;
                }

                if (CharacterDetails.ExTopB_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopB_X), 16);
                    CharacterDetails.ExTopB_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopB_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopB_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopB_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopB_X.value,
                        CharacterDetails.ExTopB_Y.value,
                        CharacterDetails.ExTopB_Z.value,
                        CharacterDetails.ExTopB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopB_Toggle = false;
                    CharacterDetails.ExTopB_Rotate = true;
                }

                if (CharacterDetails.ExTopC_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopC_X), 16);
                    CharacterDetails.ExTopC_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopC_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopC_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopC_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopC_X.value,
                        CharacterDetails.ExTopC_Y.value,
                        CharacterDetails.ExTopC_Z.value,
                        CharacterDetails.ExTopC_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopC_Toggle = false;
                    CharacterDetails.ExTopC_Rotate = true;
                }

                if (CharacterDetails.ExTopD_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopD_X), 16);
                    CharacterDetails.ExTopD_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopD_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopD_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopD_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopD_X.value,
                        CharacterDetails.ExTopD_Y.value,
                        CharacterDetails.ExTopD_Z.value,
                        CharacterDetails.ExTopD_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopD_Toggle = false;
                    CharacterDetails.ExTopD_Rotate = true;
                }

                if (CharacterDetails.ExTopE_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopE_X), 16);
                    CharacterDetails.ExTopE_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopE_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopE_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopE_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopE_X.value,
                        CharacterDetails.ExTopE_Y.value,
                        CharacterDetails.ExTopE_Z.value,
                        CharacterDetails.ExTopE_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopE_Toggle = false;
                    CharacterDetails.ExTopE_Rotate = true;
                }

                if (CharacterDetails.ExTopF_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopF_X), 16);
                    CharacterDetails.ExTopF_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopF_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopF_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopF_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopF_X.value,
                        CharacterDetails.ExTopF_Y.value,
                        CharacterDetails.ExTopF_Z.value,
                        CharacterDetails.ExTopF_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopF_Toggle = false;
                    CharacterDetails.ExTopF_Rotate = true;
                }

                if (CharacterDetails.ExTopG_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopG_X), 16);
                    CharacterDetails.ExTopG_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopG_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopG_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopG_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopG_X.value,
                        CharacterDetails.ExTopG_Y.value,
                        CharacterDetails.ExTopG_Z.value,
                        CharacterDetails.ExTopG_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopG_Toggle = false;
                    CharacterDetails.ExTopG_Rotate = true;
                }

                if (CharacterDetails.ExTopH_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopH_X), 16);
                    CharacterDetails.ExTopH_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopH_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopH_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopH_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopH_X.value,
                        CharacterDetails.ExTopH_Y.value,
                        CharacterDetails.ExTopH_Z.value,
                        CharacterDetails.ExTopH_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopH_Toggle = false;
                    CharacterDetails.ExTopH_Rotate = true;
                }

                if (CharacterDetails.ExTopI_Toggle)
                {
                    byte[] bytearray = m.readBytes(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopI_X), 16);
                    CharacterDetails.ExTopI_X.value = BitConverter.ToSingle(bytearray, 0);
                    CharacterDetails.ExTopI_Y.value = BitConverter.ToSingle(bytearray, 4);
                    CharacterDetails.ExTopI_Z.value = BitConverter.ToSingle(bytearray, 8);
                    CharacterDetails.ExTopI_W.value = BitConverter.ToSingle(bytearray, 12);

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ExTopI_X.value,
                        CharacterDetails.ExTopI_Y.value,
                        CharacterDetails.ExTopI_Z.value,
                        CharacterDetails.ExTopI_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ExTopI_Toggle = false;
                    CharacterDetails.ExTopI_Rotate = true;
                }
                #endregion
                #region Cube Updates
                if (CharacterDetails.Root_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Root_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Root_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Root_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Root_W.value;
                }
                if (CharacterDetails.Abdomen_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Abdomen_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Abdomen_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Abdomen_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Abdomen_W.value;
                }
                if (CharacterDetails.Throw_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Throw_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Throw_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Throw_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Throw_W.value;
                }
                if (CharacterDetails.Waist_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Waist_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Waist_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Waist_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Waist_W.value;
                }
                if (CharacterDetails.SpineA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.SpineA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.SpineA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.SpineA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.SpineA_W.value;
                }
                if (CharacterDetails.LegLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.LegLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.LegLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.LegLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.LegLeft_W.value;
                }
                if (CharacterDetails.LegRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.LegRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.LegRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.LegRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.LegRight_W.value;
                }
                if (CharacterDetails.HolsterLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HolsterLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HolsterLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HolsterLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HolsterLeft_W.value;
                }
                if (CharacterDetails.HolsterRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HolsterRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HolsterRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HolsterRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HolsterRight_W.value;
                }
                if (CharacterDetails.SheatheLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.SheatheLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.SheatheLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.SheatheLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.SheatheLeft_W.value;
                }
                if (CharacterDetails.SheatheRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.SheatheRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.SheatheRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.SheatheRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.SheatheRight_W.value;
                }
                if (CharacterDetails.SpineB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.SpineB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.SpineB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.SpineB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.SpineB_W.value;
                }
                if (CharacterDetails.ClothBackALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothBackALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothBackALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothBackALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothBackALeft_W.value;
                }
                if (CharacterDetails.ClothBackARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothBackARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothBackARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothBackARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothBackARight_W.value;
                }
                if (CharacterDetails.ClothFrontALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothFrontALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothFrontALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothFrontALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothFrontALeft_W.value;
                }
                if (CharacterDetails.ClothFrontARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothFrontARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothFrontARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothFrontARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothFrontARight_W.value;
                }
                if (CharacterDetails.ClothSideALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothSideALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothSideALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothSideALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothSideALeft_W.value;
                }
                if (CharacterDetails.ClothSideARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothSideARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothSideARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothSideARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothSideARight_W.value;
                }
                if (CharacterDetails.KneeLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.KneeLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.KneeLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.KneeLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.KneeLeft_W.value;
                }
                if (CharacterDetails.KneeRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.KneeRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.KneeRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.KneeRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.KneeRight_W.value;
                }
                if (CharacterDetails.BreastLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.BreastLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.BreastLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.BreastLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.BreastLeft_W.value;
                }
                if (CharacterDetails.BreastRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.BreastRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.BreastRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.BreastRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.BreastRight_W.value;
                }
                if (CharacterDetails.SpineC_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.SpineC_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.SpineC_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.SpineC_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.SpineC_W.value;
                }
                if (CharacterDetails.ClothBackBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothBackBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothBackBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothBackBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothBackBLeft_W.value;
                }
                if (CharacterDetails.ClothBackBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothBackBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothBackBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothBackBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothBackBRight_W.value;
                }
                if (CharacterDetails.ClothFrontBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothFrontBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothFrontBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothFrontBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothFrontBLeft_W.value;
                }
                if (CharacterDetails.ClothFrontBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothFrontBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothFrontBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothFrontBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothFrontBRight_W.value;
                }
                if (CharacterDetails.ClothSideBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothSideBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothSideBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothSideBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothSideBLeft_W.value;
                }
                if (CharacterDetails.ClothSideBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothSideBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothSideBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothSideBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothSideBRight_W.value;
                }
                if (CharacterDetails.CalfLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.CalfLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.CalfLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.CalfLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.CalfLeft_W.value;
                }
                if (CharacterDetails.CalfRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.CalfRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.CalfRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.CalfRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.CalfRight_W.value;
                }
                if (CharacterDetails.ScabbardLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ScabbardLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ScabbardLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ScabbardLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ScabbardLeft_W.value;
                }
                if (CharacterDetails.ScabbardRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ScabbardRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ScabbardRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ScabbardRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ScabbardRight_W.value;
                }
                if (CharacterDetails.Neck_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Neck_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Neck_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Neck_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Neck_W.value;
                }
                if (CharacterDetails.ClavicleLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClavicleLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClavicleLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClavicleLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClavicleLeft_W.value;
                }
                if (CharacterDetails.ClavicleRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClavicleRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClavicleRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClavicleRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClavicleRight_W.value;
                }
                if (CharacterDetails.ClothBackCLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothBackCLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothBackCLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothBackCLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothBackCLeft_W.value;
                }
                if (CharacterDetails.ClothBackCRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothBackCRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothBackCRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothBackCRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothBackCRight_W.value;
                }
                if (CharacterDetails.ClothFrontCLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothFrontCLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothFrontCLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothFrontCLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothFrontCLeft_W.value;
                }
                if (CharacterDetails.ClothFrontCRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothFrontCRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothFrontCRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothFrontCRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothFrontCRight_W.value;
                }
                if (CharacterDetails.ClothSideCLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothSideCLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothSideCLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothSideCLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothSideCLeft_W.value;
                }
                if (CharacterDetails.ClothSideCRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ClothSideCRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ClothSideCRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ClothSideCRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ClothSideCRight_W.value;
                }
                if (CharacterDetails.PoleynLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.PoleynLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.PoleynLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.PoleynLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.PoleynLeft_W.value;
                }
                if (CharacterDetails.PoleynRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.PoleynRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.PoleynRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.PoleynRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.PoleynRight_W.value;
                }
                if (CharacterDetails.FootLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.FootLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.FootLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.FootLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.FootLeft_W.value;
                }
                if (CharacterDetails.FootRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.FootRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.FootRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.FootRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.FootRight_W.value;
                }
                if (CharacterDetails.Head_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Head_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Head_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Head_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Head_W.value;
                }
                if (CharacterDetails.ArmLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ArmLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ArmLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ArmLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ArmLeft_W.value;
                }
                if (CharacterDetails.ArmRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ArmRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ArmRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ArmRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ArmRight_W.value;
                }
                if (CharacterDetails.PauldronLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.PauldronLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.PauldronLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.PauldronLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.PauldronLeft_W.value;
                }
                if (CharacterDetails.PauldronRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.PauldronRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.PauldronRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.PauldronRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.PauldronRight_W.value;
                }
                if (CharacterDetails.Unknown00_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Unknown00_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Unknown00_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Unknown00_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Unknown00_W.value;
                }
                if (CharacterDetails.ToesLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ToesLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ToesLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ToesLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ToesLeft_W.value;
                }
                if (CharacterDetails.ToesRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ToesRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ToesRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ToesRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ToesRight_W.value;
                }
                if (CharacterDetails.HairA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HairA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HairA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HairA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HairA_W.value;
                }
                if (CharacterDetails.HairFrontLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HairFrontLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HairFrontLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HairFrontLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HairFrontLeft_W.value;
                }
                if (CharacterDetails.HairFrontRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HairFrontRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HairFrontRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HairFrontRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HairFrontRight_W.value;
                }
                if (CharacterDetails.EarLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EarLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EarLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EarLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EarLeft_W.value;
                }
                if (CharacterDetails.EarRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EarRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EarRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EarRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EarRight_W.value;
                }
                if (CharacterDetails.ForearmLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ForearmLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ForearmLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ForearmLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ForearmLeft_W.value;
                }
                if (CharacterDetails.ForearmRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ForearmRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ForearmRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ForearmRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ForearmRight_W.value;
                }
                if (CharacterDetails.ShoulderLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ShoulderLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ShoulderLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ShoulderLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ShoulderLeft_W.value;
                }
                if (CharacterDetails.ShoulderRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ShoulderRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ShoulderRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ShoulderRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ShoulderRight_W.value;
                }
                if (CharacterDetails.HairB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HairB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HairB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HairB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HairB_W.value;
                }
                if (CharacterDetails.HandLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HandLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HandLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HandLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HandLeft_W.value;
                }
                if (CharacterDetails.HandRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HandRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HandRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HandRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HandRight_W.value;
                }
                if (CharacterDetails.ShieldLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ShieldLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ShieldLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ShieldLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ShieldLeft_W.value;
                }
                if (CharacterDetails.ShieldRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ShieldRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ShieldRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ShieldRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ShieldRight_W.value;
                }
                if (CharacterDetails.EarringALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EarringALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EarringALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EarringALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EarringALeft_W.value;
                }
                if (CharacterDetails.EarringARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EarringARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EarringARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EarringARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EarringARight_W.value;
                }
                if (CharacterDetails.ElbowLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ElbowLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ElbowLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ElbowLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ElbowLeft_W.value;
                }
                if (CharacterDetails.ElbowRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ElbowRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ElbowRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ElbowRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ElbowRight_W.value;
                }
                if (CharacterDetails.CouterLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.CouterLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.CouterLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.CouterLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.CouterLeft_W.value;
                }
                if (CharacterDetails.CouterRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.CouterRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.CouterRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.CouterRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.CouterRight_W.value;
                }
                if (CharacterDetails.WristLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.WristLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.WristLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.WristLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.WristLeft_W.value;
                }
                if (CharacterDetails.WristRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.WristRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.WristRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.WristRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.WristRight_W.value;
                }
                if (CharacterDetails.IndexALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.IndexALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.IndexALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.IndexALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.IndexALeft_W.value;
                }
                if (CharacterDetails.IndexARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.IndexARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.IndexARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.IndexARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.IndexARight_W.value;
                }
                if (CharacterDetails.PinkyALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.PinkyALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.PinkyALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.PinkyALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.PinkyALeft_W.value;
                }
                if (CharacterDetails.PinkyARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.PinkyARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.PinkyARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.PinkyARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.PinkyARight_W.value;
                }
                if (CharacterDetails.RingALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.RingALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.RingALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.RingALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.RingALeft_W.value;
                }
                if (CharacterDetails.RingARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.RingARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.RingARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.RingARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.RingARight_W.value;
                }
                if (CharacterDetails.MiddleALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.MiddleALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.MiddleALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.MiddleALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.MiddleALeft_W.value;
                }
                if (CharacterDetails.MiddleARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.MiddleARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.MiddleARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.MiddleARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.MiddleARight_W.value;
                }
                if (CharacterDetails.ThumbALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ThumbALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ThumbALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ThumbALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ThumbALeft_W.value;
                }
                if (CharacterDetails.ThumbARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ThumbARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ThumbARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ThumbARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ThumbARight_W.value;
                }
                if (CharacterDetails.WeaponLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.WeaponLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.WeaponLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.WeaponLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.WeaponLeft_W.value;
                }
                if (CharacterDetails.WeaponRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.WeaponRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.WeaponRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.WeaponRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.WeaponRight_W.value;
                }
                if (CharacterDetails.EarringBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EarringBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EarringBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EarringBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EarringBLeft_W.value;
                }
                if (CharacterDetails.EarringBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EarringBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EarringBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EarringBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EarringBRight_W.value;
                }
                if (CharacterDetails.IndexBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.IndexBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.IndexBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.IndexBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.IndexBLeft_W.value;
                }
                if (CharacterDetails.IndexBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.IndexBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.IndexBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.IndexBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.IndexBRight_W.value;
                }
                if (CharacterDetails.PinkyBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.PinkyBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.PinkyBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.PinkyBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.PinkyBLeft_W.value;
                }
                if (CharacterDetails.PinkyBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.PinkyBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.PinkyBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.PinkyBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.PinkyBRight_W.value;
                }
                if (CharacterDetails.RingBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.RingBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.RingBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.RingBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.RingBLeft_W.value;
                }
                if (CharacterDetails.RingBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.RingBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.RingBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.RingBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.RingBRight_W.value;
                }
                if (CharacterDetails.MiddleBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.MiddleBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.MiddleBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.MiddleBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.MiddleBLeft_W.value;
                }
                if (CharacterDetails.MiddleBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.MiddleBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.MiddleBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.MiddleBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.MiddleBRight_W.value;
                }
                if (CharacterDetails.ThumbBLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ThumbBLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ThumbBLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ThumbBLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ThumbBLeft_W.value;
                }
                if (CharacterDetails.ThumbBRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ThumbBRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ThumbBRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ThumbBRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ThumbBRight_W.value;
                }
                if (CharacterDetails.TailA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.TailA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.TailA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.TailA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.TailA_W.value;
                }
                if (CharacterDetails.TailB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.TailB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.TailB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.TailB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.TailB_W.value;
                }
                if (CharacterDetails.TailC_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.TailC_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.TailC_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.TailC_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.TailC_W.value;
                }
                if (CharacterDetails.TailD_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.TailD_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.TailD_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.TailD_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.TailD_W.value;
                }
                if (CharacterDetails.TailE_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.TailE_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.TailE_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.TailE_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.TailE_W.value;
                }
                if (CharacterDetails.RootHead_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.RootHead_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.RootHead_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.RootHead_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.RootHead_W.value;
                }
                if (CharacterDetails.Jaw_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Jaw_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Jaw_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Jaw_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Jaw_W.value;
                }
                if (CharacterDetails.EyelidLowerLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EyelidLowerLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EyelidLowerLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EyelidLowerLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EyelidLowerLeft_W.value;
                }
                if (CharacterDetails.EyelidLowerRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EyelidLowerRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EyelidLowerRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EyelidLowerRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EyelidLowerRight_W.value;
                }
                if (CharacterDetails.EyeLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EyeLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EyeLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EyeLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EyeLeft_W.value;
                }
                if (CharacterDetails.EyeRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EyeRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EyeRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EyeRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EyeRight_W.value;
                }
                if (CharacterDetails.Nose_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Nose_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Nose_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Nose_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Nose_W.value;
                }
                if (CharacterDetails.CheekLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.CheekLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.CheekLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.CheekLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.CheekLeft_W.value;
                }
                if (CharacterDetails.HrothWhiskersLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothWhiskersLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothWhiskersLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothWhiskersLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothWhiskersLeft_W.value;
                }
                if (CharacterDetails.CheekRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.CheekRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.CheekRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.CheekRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.CheekRight_W.value;
                }
                if (CharacterDetails.HrothWhiskersRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothWhiskersRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothWhiskersRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothWhiskersRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothWhiskersRight_W.value;
                }
                if (CharacterDetails.LipsLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.LipsLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.LipsLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.LipsLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.LipsLeft_W.value;
                }
                if (CharacterDetails.HrothEyebrowLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothEyebrowLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothEyebrowLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothEyebrowLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothEyebrowLeft_W.value;
                }
                if (CharacterDetails.LipsRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.LipsRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.LipsRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.LipsRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.LipsRight_W.value;
                }
                if (CharacterDetails.HrothEyebrowRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothEyebrowRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothEyebrowRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothEyebrowRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothEyebrowRight_W.value;
                }
                if (CharacterDetails.EyebrowLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EyebrowLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EyebrowLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EyebrowLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EyebrowLeft_W.value;
                }
                if (CharacterDetails.HrothBridge_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothBridge_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothBridge_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothBridge_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothBridge_W.value;
                }
                if (CharacterDetails.EyebrowRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EyebrowRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EyebrowRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EyebrowRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EyebrowRight_W.value;
                }
                if (CharacterDetails.HrothBrowLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothBrowLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothBrowLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothBrowLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothBrowLeft_W.value;
                }
                if (CharacterDetails.Bridge_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.Bridge_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.Bridge_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.Bridge_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.Bridge_W.value;
                }
                if (CharacterDetails.HrothBrowRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothBrowRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothBrowRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothBrowRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothBrowRight_W.value;
                }
                if (CharacterDetails.BrowLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.BrowLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.BrowLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.BrowLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.BrowLeft_W.value;
                }
                if (CharacterDetails.HrothJawUpper_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothJawUpper_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothJawUpper_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothJawUpper_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothJawUpper_W.value;
                }
                if (CharacterDetails.BrowRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.BrowRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.BrowRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.BrowRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.BrowRight_W.value;
                }
                if (CharacterDetails.HrothLipUpper_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothLipUpper_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothLipUpper_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothLipUpper_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothLipUpper_W.value;
                }
                if (CharacterDetails.LipUpperA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.LipUpperA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.LipUpperA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.LipUpperA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.LipUpperA_W.value;
                }
                if (CharacterDetails.HrothEyelidUpperLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothEyelidUpperLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothEyelidUpperLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothEyelidUpperLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothEyelidUpperLeft_W.value;
                }
                if (CharacterDetails.EyelidUpperLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EyelidUpperLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EyelidUpperLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EyelidUpperLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EyelidUpperLeft_W.value;
                }
                if (CharacterDetails.HrothEyelidUpperRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothEyelidUpperRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothEyelidUpperRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothEyelidUpperRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothEyelidUpperRight_W.value;
                }
                if (CharacterDetails.EyelidUpperRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.EyelidUpperRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.EyelidUpperRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.EyelidUpperRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.EyelidUpperRight_W.value;
                }
                if (CharacterDetails.HrothLipsLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothLipsLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothLipsLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothLipsLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothLipsLeft_W.value;
                }
                if (CharacterDetails.LipLowerA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.LipLowerA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.LipLowerA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.LipLowerA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.LipLowerA_W.value;
                }
                if (CharacterDetails.HrothLipsRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothLipsRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothLipsRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothLipsRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothLipsRight_W.value;
                }
                if (CharacterDetails.VieraEar01ALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar01ALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar01ALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar01ALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar01ALeft_W.value;
                }
                if (CharacterDetails.LipUpperB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.LipUpperB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.LipUpperB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.LipUpperB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.LipUpperB_W.value;
                }
                if (CharacterDetails.HrothLipUpperLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothLipUpperLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothLipUpperLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothLipUpperLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothLipUpperLeft_W.value;
                }
                if (CharacterDetails.VieraEar01ARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar01ARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar01ARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar01ARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar01ARight_W.value;
                }
                if (CharacterDetails.LipLowerB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.LipLowerB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.LipLowerB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.LipLowerB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.LipLowerB_W.value;
                }
                if (CharacterDetails.HrothLipUpperRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothLipUpperRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothLipUpperRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothLipUpperRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothLipUpperRight_W.value;
                }
                if (CharacterDetails.VieraEar02ALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar02ALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar02ALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar02ALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar02ALeft_W.value;
                }
                if (CharacterDetails.HrothLipLower_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.HrothLipLower_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.HrothLipLower_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.HrothLipLower_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.HrothLipLower_W.value;
                }
                if (CharacterDetails.VieraEar02ARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar02ARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar02ARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar02ARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar02ARight_W.value;
                }
                if (CharacterDetails.VieraEar03ALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar03ALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar03ALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar03ALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar03ALeft_W.value;
                }
                if (CharacterDetails.VieraEar03ARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar03ARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar03ARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar03ARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar03ARight_W.value;
                }
                if (CharacterDetails.VieraEar04ALeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar04ALeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar04ALeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar04ALeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar04ALeft_W.value;
                }
                if (CharacterDetails.VieraEar04ARight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar04ARight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar04ARight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar04ARight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar04ARight_W.value;
                }
                if (CharacterDetails.VieraLipLowerA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraLipLowerA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraLipLowerA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraLipLowerA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraLipLowerA_W.value;
                }
                if (CharacterDetails.VieraLipUpperB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraLipUpperB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraLipUpperB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraLipUpperB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraLipUpperB_W.value;
                }
                if (CharacterDetails.VieraEar01BLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar01BLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar01BLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar01BLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar01BLeft_W.value;
                }
                if (CharacterDetails.VieraEar01BRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar01BRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar01BRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar01BRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar01BRight_W.value;
                }
                if (CharacterDetails.VieraEar02BLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar02BLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar02BLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar02BLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar02BLeft_W.value;
                }
                if (CharacterDetails.VieraEar02BRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar02BRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar02BRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar02BRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar02BRight_W.value;
                }
                if (CharacterDetails.VieraEar03BLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar03BLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar03BLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar03BLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar03BLeft_W.value;
                }
                if (CharacterDetails.VieraEar03BRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar03BRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar03BRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar03BRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar03BRight_W.value;
                }
                if (CharacterDetails.VieraEar04BLeft_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar04BLeft_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar04BLeft_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar04BLeft_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar04BLeft_W.value;
                }
                if (CharacterDetails.VieraEar04BRight_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraEar04BRight_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraEar04BRight_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraEar04BRight_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraEar04BRight_W.value;
                }
                if (CharacterDetails.VieraLipLowerB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.VieraLipLowerB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.VieraLipLowerB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.VieraLipLowerB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.VieraLipLowerB_W.value;
                }
                if (CharacterDetails.ExRootHair_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExRootHair_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExRootHair_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExRootHair_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExRootHair_W.value;
                }
                if (CharacterDetails.ExHairA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairA_W.value;
                }
                if (CharacterDetails.ExHairB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairB_W.value;
                }
                if (CharacterDetails.ExHairC_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairC_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairC_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairC_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairC_W.value;
                }
                if (CharacterDetails.ExHairD_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairD_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairD_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairD_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairD_W.value;
                }
                if (CharacterDetails.ExHairE_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairE_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairE_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairE_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairE_W.value;
                }
                if (CharacterDetails.ExHairF_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairF_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairF_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairF_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairF_W.value;
                }
                if (CharacterDetails.ExHairG_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairG_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairG_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairG_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairG_W.value;
                }
                if (CharacterDetails.ExHairH_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairH_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairH_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairH_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairH_W.value;
                }
                if (CharacterDetails.ExHairI_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairI_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairI_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairI_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairI_W.value;
                }
                if (CharacterDetails.ExHairJ_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairJ_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairJ_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairJ_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairJ_W.value;
                }
                if (CharacterDetails.ExHairK_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairK_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairK_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairK_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairK_W.value;
                }
                if (CharacterDetails.ExHairL_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExHairL_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExHairL_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExHairL_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExHairL_W.value;
                }
                if (CharacterDetails.ExRootMet_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExRootMet_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExRootMet_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExRootMet_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExRootMet_W.value;
                }
                if (CharacterDetails.ExMetA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetA_W.value;
                }
                if (CharacterDetails.ExMetB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetB_W.value;
                }
                if (CharacterDetails.ExMetC_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetC_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetC_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetC_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetC_W.value;
                }
                if (CharacterDetails.ExMetD_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetD_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetD_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetD_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetD_W.value;
                }
                if (CharacterDetails.ExMetE_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetE_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetE_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetE_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetE_W.value;
                }
                if (CharacterDetails.ExMetF_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetF_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetF_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetF_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetF_W.value;
                }
                if (CharacterDetails.ExMetG_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetG_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetG_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetG_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetG_W.value;
                }
                if (CharacterDetails.ExMetH_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetH_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetH_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetH_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetH_W.value;
                }
                if (CharacterDetails.ExMetI_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetI_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetI_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetI_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetI_W.value;
                }
                if (CharacterDetails.ExMetJ_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetJ_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetJ_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetJ_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetJ_W.value;
                }
                if (CharacterDetails.ExMetK_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetK_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetK_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetK_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetK_W.value;
                }
                if (CharacterDetails.ExMetL_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetL_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetL_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetL_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetL_W.value;
                }
                if (CharacterDetails.ExMetM_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetM_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetM_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetM_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetM_W.value;
                }
                if (CharacterDetails.ExMetN_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetN_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetN_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetN_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetN_W.value;
                }
                if (CharacterDetails.ExMetO_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetO_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetO_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetO_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetO_W.value;
                }
                if (CharacterDetails.ExMetP_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetP_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetP_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetP_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetP_W.value;
                }
                if (CharacterDetails.ExMetQ_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetQ_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetQ_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetQ_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetQ_W.value;
                }
                if (CharacterDetails.ExMetR_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExMetR_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExMetR_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExMetR_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExMetR_W.value;
                }
                if (CharacterDetails.ExRootTop_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExRootTop_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExRootTop_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExRootTop_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExRootTop_W.value;
                }
                if (CharacterDetails.ExTopA_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopA_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopA_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopA_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopA_W.value;
                }
                if (CharacterDetails.ExTopB_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopB_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopB_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopB_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopB_W.value;
                }
                if (CharacterDetails.ExTopC_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopC_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopC_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopC_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopC_W.value;
                }
                if (CharacterDetails.ExTopD_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopD_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopD_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopD_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopD_W.value;
                }
                if (CharacterDetails.ExTopE_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopE_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopE_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopE_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopE_W.value;
                }
                if (CharacterDetails.ExTopF_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopF_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopF_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopF_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopF_W.value;
                }
                if (CharacterDetails.ExTopG_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopG_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopG_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopG_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopG_W.value;
                }
                if (CharacterDetails.ExTopH_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopH_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopH_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopH_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopH_W.value;
                }
                if (CharacterDetails.ExTopI_Rotate == true)
                {
                    CharacterDetails.CubeBone_X.value = CharacterDetails.ExTopI_X.value;
                    CharacterDetails.CubeBone_Y.value = CharacterDetails.ExTopI_Y.value;
                    CharacterDetails.CubeBone_Z.value = CharacterDetails.ExTopI_Z.value;
                    CharacterDetails.CubeBone_W.value = CharacterDetails.ExTopI_W.value;
                }
                #endregion

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

                if (!CharacterDetails.EmoteSpeed1.freeze) CharacterDetails.EmoteSpeed1.value = (float)m.readFloat((GAS(baseAddr, c.EmoteSpeed1)));

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