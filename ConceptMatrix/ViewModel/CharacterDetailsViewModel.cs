using ConceptMatrix.Commands;
using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

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
                        CharacterDetails.HDR.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.HDR));
                        CharacterDetails.Brightness.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Brightness));
                        CharacterDetails.Contrast.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Contrast));
                        CharacterDetails.Exposure.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Exposure));
                        CharacterDetails.Filmic.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Filmic));
                        CharacterDetails.SHDR.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.SHDR));
                        CharacterDetails.Colorfulness.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Colorfulness));
                        CharacterDetails.Contrast2.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Contrast2));
                        CharacterDetails.Colorfulnesss2.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Colorfulnesss2));
                        CharacterDetails.Vibrance.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Vibrance));
                        CharacterDetails.Gamma.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.Gamma));
                        CharacterDetails.GBlue.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.GBlue));
                        CharacterDetails.GGreens.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.GGreens));
                        CharacterDetails.GRed.value = m.readFloat(GAS(MemoryManager.Instance.GposeFilters, c.GRed));
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
                                MemoryManager.Instance.MemLib.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.Job), "bytes", "00 00 00 00 00 00 00 00");
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

                if (!CharacterDetails.Voices.freeze) CharacterDetails.Voices.value = (byte)m.readByte(GAS(baseAddr, c.Voices));

                if (!CharacterDetails.Height.freeze) CharacterDetails.Height.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Height));

                if (!CharacterDetails.Title.freeze) CharacterDetails.Title.value = (int)m.read2Byte((GAS(baseAddr, c.Title)));

                if (!CharacterDetails.JobIco.freeze) CharacterDetails.JobIco.value = (byte)m.readByte(GAS(baseAddr, c.JobIco));

                if (!CharacterDetails.Race.freeze) CharacterDetails.Race.value = (byte)m.readByte(GAS(baseAddr, c.Race));

                if (!CharacterDetails.Clan.freeze) CharacterDetails.Clan.value = (byte)m.readByte(GAS(baseAddr, c.Clan));

                if (!CharacterDetails.Gender.freeze) CharacterDetails.Gender.value = (byte)m.readByte(GAS(baseAddr, c.Gender));

                if (!CharacterDetails.Head.freeze) CharacterDetails.Head.value = (byte)m.readByte(GAS(baseAddr, c.Head));

                if (!CharacterDetails.Hair.freeze) CharacterDetails.Hair.value = (byte)m.readByte(GAS(baseAddr, c.Hair));

                if (!CharacterDetails.TailType.freeze) CharacterDetails.TailType.value = (byte)m.readByte(GAS(baseAddr, c.TailType));

                if (!CharacterDetails.HairTone.freeze) CharacterDetails.HairTone.value = (byte)m.readByte(GAS(baseAddr, c.HairTone));

                if (!CharacterDetails.Highlights.freeze)
                {
                    CharacterDetails.Highlights.value = (byte)m.readByte(GAS(baseAddr, c.Highlights));
                    if (CharacterDetails.Highlights.value >= 80) CharacterDetails.Highlights.SpecialActivate = true;
                    else CharacterDetails.Highlights.SpecialActivate = false;
                }

                if (!CharacterDetails.HighlightTone.freeze) CharacterDetails.HighlightTone.value = (byte)m.readByte(GAS(baseAddr, c.HighlightTone));

                if (!CharacterDetails.Skintone.freeze) CharacterDetails.Skintone.value = (byte)m.readByte(GAS(baseAddr, c.Skintone));

                if (!CharacterDetails.Lips.freeze) CharacterDetails.Lips.value = (byte)m.readByte(GAS(baseAddr, c.Lips));

                if (!CharacterDetails.LipsTone.freeze) CharacterDetails.LipsTone.value = (byte)m.readByte(GAS(baseAddr, c.LipsTone));

                if (!CharacterDetails.Nose.freeze) CharacterDetails.Nose.value = (byte)m.readByte(GAS(baseAddr, c.Nose));

                if (!CharacterDetails.TailorMuscle.freeze) CharacterDetails.TailorMuscle.value = (byte)m.readByte(GAS(baseAddr, c.TailorMuscle));

                if (!CharacterDetails.FacePaintColor.freeze) CharacterDetails.FacePaintColor.value = (byte)m.readByte(GAS(baseAddr, c.FacePaintColor));

                if (!CharacterDetails.FacePaint.freeze) CharacterDetails.FacePaint.value = (byte)m.readByte(GAS(baseAddr, c.FacePaint));

                if (!CharacterDetails.LeftEye.freeze) CharacterDetails.LeftEye.value = (byte)m.readByte(GAS(baseAddr, c.LeftEye));

                if (!CharacterDetails.RightEye.freeze) CharacterDetails.RightEye.value = (byte)m.readByte(GAS(baseAddr, c.RightEye));

                if (!CharacterDetails.LimbalEyes.freeze) CharacterDetails.LimbalEyes.value = (byte)m.readByte(GAS(baseAddr, c.LimbalEyes));

                if (!CharacterDetails.Eye.freeze) CharacterDetails.Eye.value = (byte)m.readByte(GAS(baseAddr, c.Eye));

                if (!CharacterDetails.EyeBrowType.freeze) CharacterDetails.EyeBrowType.value = (byte)m.readByte(GAS(baseAddr, c.EyeBrowType));

                if (!CharacterDetails.FacialFeatures.freeze) CharacterDetails.FacialFeatures.value = (byte)m.readByte(GAS(baseAddr, c.FacialFeatures));

                if (!CharacterDetails.Jaw.freeze) CharacterDetails.Jaw.value = (byte)m.readByte(GAS(baseAddr, c.Jaw));

                if (!CharacterDetails.RHeight.freeze) CharacterDetails.RHeight.value = (byte)m.readByte(GAS(baseAddr, c.RHeight));

                if (!CharacterDetails.RBust.freeze) CharacterDetails.RBust.value = (byte)m.readByte(GAS(baseAddr, c.RBust));

                if (!CharacterDetails.BodyType.freeze) CharacterDetails.BodyType.value = (byte)m.read2Byte(GAS(baseAddr, c.BodyType));

                if (!CharacterDetails.TestArray.freeze) CharacterDetails.TestArray.value = MemoryManager.ByteArrayToString(m.readBytes(GAS(baseAddr, c.Race), 26));

                if (!CharacterDetails.TestArray2.freeze) CharacterDetails.TestArray2.value = MemoryManager.ByteArrayToString(m.readBytes(GAS(baseAddr, c.HeadPiece), 39));

                if (!CharacterDetails.BustX.freeze) CharacterDetails.BustX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bust.Base, c.Body.Bust.X));

                if (!CharacterDetails.BustY.freeze) CharacterDetails.BustY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bust.Base, c.Body.Bust.Y));

                if (!CharacterDetails.BustZ.freeze) CharacterDetails.BustZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bust.Base, c.Body.Bust.Z));

                // Reading rotation values.
                if (!CharacterDetails.RotateFreeze && !CharacterDetails.BoneEditMode)
                {
                    CharacterDetails.Rotation.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Rotation));
                    CharacterDetails.Rotation2.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Rotation2));
                    CharacterDetails.Rotation3.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Rotation3));
                    CharacterDetails.Rotation4.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Rotation4));

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

                #region Bone Rotations
                if (CharacterDetails.Root_Toggle)
                {
                    CharacterDetails.Root_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Root_X));
                    CharacterDetails.Root_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Root_Y));
                    CharacterDetails.Root_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Root_Z));
                    CharacterDetails.Root_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Root_W));

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
                    CharacterDetails.Abdomen_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Abdomen_X));
                    CharacterDetails.Abdomen_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Abdomen_Y));
                    CharacterDetails.Abdomen_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Abdomen_Z));
                    CharacterDetails.Abdomen_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Abdomen_W));

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
                    CharacterDetails.Throw_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Throw_X));
                    CharacterDetails.Throw_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Throw_Y));
                    CharacterDetails.Throw_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Throw_Z));
                    CharacterDetails.Throw_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Throw_W));

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
                    CharacterDetails.Waist_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Waist_X));
                    CharacterDetails.Waist_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Waist_Y));
                    CharacterDetails.Waist_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Waist_Z));
                    CharacterDetails.Waist_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Waist_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Waist_X.value,
                        CharacterDetails.Waist_Y.value,
                        CharacterDetails.Waist_Z.value,
                        CharacterDetails.Waist_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Waist_Toggle = false;
                    CharacterDetails.Waist_Rotate = true;
                }

                if (CharacterDetails.SpineA_Toggle)
                {
                    CharacterDetails.SpineA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineA_X));
                    CharacterDetails.SpineA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineA_Y));
                    CharacterDetails.SpineA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineA_Z));
                    CharacterDetails.SpineA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineA_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SpineA_X.value,
                        CharacterDetails.SpineA_Y.value,
                        CharacterDetails.SpineA_Z.value,
                        CharacterDetails.SpineA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SpineA_Toggle = false;
                    CharacterDetails.SpineA_Rotate = true;
                }

                if (CharacterDetails.LegLeft_Toggle)
                {
                    CharacterDetails.LegLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegLeft_X));
                    CharacterDetails.LegLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegLeft_Y));
                    CharacterDetails.LegLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegLeft_Z));
                    CharacterDetails.LegLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LegLeft_X.value,
                        CharacterDetails.LegLeft_Y.value,
                        CharacterDetails.LegLeft_Z.value,
                        CharacterDetails.LegLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LegLeft_Toggle = false;
                    CharacterDetails.LegLeft_Rotate = true;
                }

                if (CharacterDetails.LegRight_Toggle)
                {
                    CharacterDetails.LegRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegRight_X));
                    CharacterDetails.LegRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegRight_Y));
                    CharacterDetails.LegRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegRight_Z));
                    CharacterDetails.LegRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LegRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LegRight_X.value,
                        CharacterDetails.LegRight_Y.value,
                        CharacterDetails.LegRight_Z.value,
                        CharacterDetails.LegRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LegRight_Toggle = false;
                    CharacterDetails.LegRight_Rotate = true;
                }

                if (CharacterDetails.HolsterLeft_Toggle)
                {
                    CharacterDetails.HolsterLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterLeft_X));
                    CharacterDetails.HolsterLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterLeft_Y));
                    CharacterDetails.HolsterLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterLeft_Z));
                    CharacterDetails.HolsterLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterLeft_W));

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
                    CharacterDetails.HolsterRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterRight_X));
                    CharacterDetails.HolsterRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterRight_Y));
                    CharacterDetails.HolsterRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterRight_Z));
                    CharacterDetails.HolsterRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HolsterRight_W));

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
                    CharacterDetails.SheatheLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheLeft_X));
                    CharacterDetails.SheatheLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheLeft_Y));
                    CharacterDetails.SheatheLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheLeft_Z));
                    CharacterDetails.SheatheLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheLeft_W));

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
                    CharacterDetails.SheatheRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheRight_X));
                    CharacterDetails.SheatheRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheRight_Y));
                    CharacterDetails.SheatheRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheRight_Z));
                    CharacterDetails.SheatheRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SheatheRight_W));

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
                    CharacterDetails.SpineB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineB_X));
                    CharacterDetails.SpineB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineB_Y));
                    CharacterDetails.SpineB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineB_Z));
                    CharacterDetails.SpineB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineB_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SpineB_X.value,
                        CharacterDetails.SpineB_Y.value,
                        CharacterDetails.SpineB_Z.value,
                        CharacterDetails.SpineB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SpineB_Toggle = false;
                    CharacterDetails.SpineB_Rotate = true;
                }

                if (CharacterDetails.ClothBackALeft_Toggle)
                {
                    CharacterDetails.ClothBackALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackALeft_X));
                    CharacterDetails.ClothBackALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackALeft_Y));
                    CharacterDetails.ClothBackALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackALeft_Z));
                    CharacterDetails.ClothBackALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackALeft_W));

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
                    CharacterDetails.ClothBackARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackARight_X));
                    CharacterDetails.ClothBackARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackARight_Y));
                    CharacterDetails.ClothBackARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackARight_Z));
                    CharacterDetails.ClothBackARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackARight_W));

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
                    CharacterDetails.ClothFrontALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontALeft_X));
                    CharacterDetails.ClothFrontALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontALeft_Y));
                    CharacterDetails.ClothFrontALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontALeft_Z));
                    CharacterDetails.ClothFrontALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontALeft_W));

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
                    CharacterDetails.ClothFrontARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontARight_X));
                    CharacterDetails.ClothFrontARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontARight_Y));
                    CharacterDetails.ClothFrontARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontARight_Z));
                    CharacterDetails.ClothFrontARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontARight_W));

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
                    CharacterDetails.ClothSideALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideALeft_X));
                    CharacterDetails.ClothSideALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideALeft_Y));
                    CharacterDetails.ClothSideALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideALeft_Z));
                    CharacterDetails.ClothSideALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideALeft_W));

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
                    CharacterDetails.ClothSideARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideARight_X));
                    CharacterDetails.ClothSideARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideARight_Y));
                    CharacterDetails.ClothSideARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideARight_Z));
                    CharacterDetails.ClothSideARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideARight_W));

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
                    CharacterDetails.KneeLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeLeft_X));
                    CharacterDetails.KneeLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeLeft_Y));
                    CharacterDetails.KneeLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeLeft_Z));
                    CharacterDetails.KneeLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.KneeLeft_X.value,
                        CharacterDetails.KneeLeft_Y.value,
                        CharacterDetails.KneeLeft_Z.value,
                        CharacterDetails.KneeLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.KneeLeft_Toggle = false;
                    CharacterDetails.KneeLeft_Rotate = true;
                }

                if (CharacterDetails.KneeRight_Toggle)
                {
                    CharacterDetails.KneeRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeRight_X));
                    CharacterDetails.KneeRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeRight_Y));
                    CharacterDetails.KneeRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeRight_Z));
                    CharacterDetails.KneeRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.KneeRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.KneeRight_X.value,
                        CharacterDetails.KneeRight_Y.value,
                        CharacterDetails.KneeRight_Z.value,
                        CharacterDetails.KneeRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.KneeRight_Toggle = false;
                    CharacterDetails.KneeRight_Rotate = true;
                }

                if (CharacterDetails.BreastLeft_Toggle)
                {
                    CharacterDetails.BreastLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastLeft_X));
                    CharacterDetails.BreastLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastLeft_Y));
                    CharacterDetails.BreastLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastLeft_Z));
                    CharacterDetails.BreastLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastLeft_W));

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
                    CharacterDetails.BreastRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastRight_X));
                    CharacterDetails.BreastRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastRight_Y));
                    CharacterDetails.BreastRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastRight_Z));
                    CharacterDetails.BreastRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BreastRight_W));

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
                    CharacterDetails.SpineC_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineC_X));
                    CharacterDetails.SpineC_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineC_Y));
                    CharacterDetails.SpineC_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineC_Z));
                    CharacterDetails.SpineC_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.SpineC_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SpineC_X.value,
                        CharacterDetails.SpineC_Y.value,
                        CharacterDetails.SpineC_Z.value,
                        CharacterDetails.SpineC_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SpineC_Toggle = false;
                    CharacterDetails.SpineC_Rotate = true;
                }

                if (CharacterDetails.ClothBackBLeft_Toggle)
                {
                    CharacterDetails.ClothBackBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBLeft_X));
                    CharacterDetails.ClothBackBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBLeft_Y));
                    CharacterDetails.ClothBackBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBLeft_Z));
                    CharacterDetails.ClothBackBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBLeft_W));

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
                    CharacterDetails.ClothBackBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBRight_X));
                    CharacterDetails.ClothBackBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBRight_Y));
                    CharacterDetails.ClothBackBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBRight_Z));
                    CharacterDetails.ClothBackBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackBRight_W));

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
                    CharacterDetails.ClothFrontBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBLeft_X));
                    CharacterDetails.ClothFrontBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBLeft_Y));
                    CharacterDetails.ClothFrontBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBLeft_Z));
                    CharacterDetails.ClothFrontBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBLeft_W));

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
                    CharacterDetails.ClothFrontBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBRight_X));
                    CharacterDetails.ClothFrontBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBRight_Y));
                    CharacterDetails.ClothFrontBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBRight_Z));
                    CharacterDetails.ClothFrontBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontBRight_W));

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
                    CharacterDetails.ClothSideBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBLeft_X));
                    CharacterDetails.ClothSideBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBLeft_Y));
                    CharacterDetails.ClothSideBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBLeft_Z));
                    CharacterDetails.ClothSideBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBLeft_W));

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
                    CharacterDetails.ClothSideBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBRight_X));
                    CharacterDetails.ClothSideBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBRight_Y));
                    CharacterDetails.ClothSideBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBRight_Z));
                    CharacterDetails.ClothSideBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideBRight_W));

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
                    CharacterDetails.CalfLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfLeft_X));
                    CharacterDetails.CalfLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfLeft_Y));
                    CharacterDetails.CalfLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfLeft_Z));
                    CharacterDetails.CalfLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.CalfLeft_X.value,
                        CharacterDetails.CalfLeft_Y.value,
                        CharacterDetails.CalfLeft_Z.value,
                        CharacterDetails.CalfLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.CalfLeft_Toggle = false;
                    CharacterDetails.CalfLeft_Rotate = true;
                }

                if (CharacterDetails.CalfRight_Toggle)
                {
                    CharacterDetails.CalfRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfRight_X));
                    CharacterDetails.CalfRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfRight_Y));
                    CharacterDetails.CalfRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfRight_Z));
                    CharacterDetails.CalfRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CalfRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.CalfRight_X.value,
                        CharacterDetails.CalfRight_Y.value,
                        CharacterDetails.CalfRight_Z.value,
                        CharacterDetails.CalfRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.CalfRight_Toggle = false;
                    CharacterDetails.CalfRight_Rotate = true;
                }

                if (CharacterDetails.ScabbardLeft_Toggle)
                {
                    CharacterDetails.ScabbardLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardLeft_X));
                    CharacterDetails.ScabbardLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardLeft_Y));
                    CharacterDetails.ScabbardLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardLeft_Z));
                    CharacterDetails.ScabbardLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardLeft_W));

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
                    CharacterDetails.ScabbardRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardRight_X));
                    CharacterDetails.ScabbardRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardRight_Y));
                    CharacterDetails.ScabbardRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardRight_Z));
                    CharacterDetails.ScabbardRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ScabbardRight_W));

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
                    CharacterDetails.Neck_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Neck_X));
                    CharacterDetails.Neck_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Neck_Y));
                    CharacterDetails.Neck_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Neck_Z));
                    CharacterDetails.Neck_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Neck_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Neck_X.value,
                        CharacterDetails.Neck_Y.value,
                        CharacterDetails.Neck_Z.value,
                        CharacterDetails.Neck_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Neck_Toggle = false;
                    CharacterDetails.Neck_Rotate = true;
                }

                if (CharacterDetails.ClavicleLeft_Toggle)
                {
                    CharacterDetails.ClavicleLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleLeft_X));
                    CharacterDetails.ClavicleLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleLeft_Y));
                    CharacterDetails.ClavicleLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleLeft_Z));
                    CharacterDetails.ClavicleLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClavicleLeft_X.value,
                        CharacterDetails.ClavicleLeft_Y.value,
                        CharacterDetails.ClavicleLeft_Z.value,
                        CharacterDetails.ClavicleLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClavicleLeft_Toggle = false;
                    CharacterDetails.ClavicleLeft_Rotate = true;
                }

                if (CharacterDetails.ClavicleRight_Toggle)
                {
                    CharacterDetails.ClavicleRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleRight_X));
                    CharacterDetails.ClavicleRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleRight_Y));
                    CharacterDetails.ClavicleRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleRight_Z));
                    CharacterDetails.ClavicleRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClavicleRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ClavicleRight_X.value,
                        CharacterDetails.ClavicleRight_Y.value,
                        CharacterDetails.ClavicleRight_Z.value,
                        CharacterDetails.ClavicleRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ClavicleRight_Toggle = false;
                    CharacterDetails.ClavicleRight_Rotate = true;
                }

                if (CharacterDetails.ClothBackCLeft_Toggle)
                {
                    CharacterDetails.ClothBackCLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCLeft_X));
                    CharacterDetails.ClothBackCLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCLeft_Y));
                    CharacterDetails.ClothBackCLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCLeft_Z));
                    CharacterDetails.ClothBackCLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCLeft_W));

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
                    CharacterDetails.ClothBackCRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCRight_X));
                    CharacterDetails.ClothBackCRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCRight_Y));
                    CharacterDetails.ClothBackCRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCRight_Z));
                    CharacterDetails.ClothBackCRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothBackCRight_W));

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
                    CharacterDetails.ClothFrontCLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCLeft_X));
                    CharacterDetails.ClothFrontCLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCLeft_Y));
                    CharacterDetails.ClothFrontCLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCLeft_Z));
                    CharacterDetails.ClothFrontCLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCLeft_W));

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
                    CharacterDetails.ClothFrontCRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCRight_X));
                    CharacterDetails.ClothFrontCRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCRight_Y));
                    CharacterDetails.ClothFrontCRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCRight_Z));
                    CharacterDetails.ClothFrontCRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothFrontCRight_W));

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
                    CharacterDetails.ClothSideCRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCRight_X));
                    CharacterDetails.ClothSideCRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCRight_Y));
                    CharacterDetails.ClothSideCRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCRight_Z));
                    CharacterDetails.ClothSideCRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ClothSideCRight_W));

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
                    CharacterDetails.PoleynLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynLeft_X));
                    CharacterDetails.PoleynLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynLeft_Y));
                    CharacterDetails.PoleynLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynLeft_Z));
                    CharacterDetails.PoleynLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynLeft_W));

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
                    CharacterDetails.PoleynRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynRight_X));
                    CharacterDetails.PoleynRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynRight_Y));
                    CharacterDetails.PoleynRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynRight_Z));
                    CharacterDetails.PoleynRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PoleynRight_W));

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
                    CharacterDetails.FootLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootLeft_X));
                    CharacterDetails.FootLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootLeft_Y));
                    CharacterDetails.FootLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootLeft_Z));
                    CharacterDetails.FootLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.FootLeft_X.value,
                        CharacterDetails.FootLeft_Y.value,
                        CharacterDetails.FootLeft_Z.value,
                        CharacterDetails.FootLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.FootLeft_Toggle = false;
                    CharacterDetails.FootLeft_Rotate = true;
                }

                if (CharacterDetails.FootRight_Toggle)
                {
                    CharacterDetails.FootRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootRight_X));
                    CharacterDetails.FootRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootRight_Y));
                    CharacterDetails.FootRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootRight_Z));
                    CharacterDetails.FootRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.FootRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.FootRight_X.value,
                        CharacterDetails.FootRight_Y.value,
                        CharacterDetails.FootRight_Z.value,
                        CharacterDetails.FootRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.FootRight_Toggle = false;
                    CharacterDetails.FootRight_Rotate = true;
                }

                if (CharacterDetails.Head_Toggle)
                {
                    CharacterDetails.Head_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Head_X));
                    CharacterDetails.Head_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Head_Y));
                    CharacterDetails.Head_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Head_Z));
                    CharacterDetails.Head_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Head_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Head_X.value,
                        CharacterDetails.Head_Y.value,
                        CharacterDetails.Head_Z.value,
                        CharacterDetails.Head_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Head_Toggle = false;
                    CharacterDetails.Head_Rotate = true;
                }

                if (CharacterDetails.ArmLeft_Toggle)
                {
                    CharacterDetails.ArmLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmLeft_X));
                    CharacterDetails.ArmLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmLeft_Y));
                    CharacterDetails.ArmLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmLeft_Z));
                    CharacterDetails.ArmLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ArmLeft_X.value,
                        CharacterDetails.ArmLeft_Y.value,
                        CharacterDetails.ArmLeft_Z.value,
                        CharacterDetails.ArmLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ArmLeft_Toggle = false;
                    CharacterDetails.ArmLeft_Rotate = true;
                }

                if (CharacterDetails.ArmRight_Toggle)
                {
                    CharacterDetails.ArmRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmRight_X));
                    CharacterDetails.ArmRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmRight_Y));
                    CharacterDetails.ArmRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmRight_Z));
                    CharacterDetails.ArmRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ArmRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ArmRight_X.value,
                        CharacterDetails.ArmRight_Y.value,
                        CharacterDetails.ArmRight_Z.value,
                        CharacterDetails.ArmRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ArmRight_Toggle = false;
                    CharacterDetails.ArmRight_Rotate = true;
                }

                if (CharacterDetails.PauldronLeft_Toggle)
                {
                    CharacterDetails.PauldronLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronLeft_X));
                    CharacterDetails.PauldronLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronLeft_Y));
                    CharacterDetails.PauldronLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronLeft_Z));
                    CharacterDetails.PauldronLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronLeft_W));

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
                    CharacterDetails.PauldronRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronRight_X));
                    CharacterDetails.PauldronRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronRight_Y));
                    CharacterDetails.PauldronRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronRight_Z));
                    CharacterDetails.PauldronRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PauldronRight_W));

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
                    CharacterDetails.Unknown00_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Unknown00_X));
                    CharacterDetails.Unknown00_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Unknown00_Y));
                    CharacterDetails.Unknown00_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Unknown00_Z));
                    CharacterDetails.Unknown00_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Unknown00_W));

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
                    CharacterDetails.ToesLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesLeft_X));
                    CharacterDetails.ToesLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesLeft_Y));
                    CharacterDetails.ToesLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesLeft_Z));
                    CharacterDetails.ToesLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesLeft_W));

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
                    CharacterDetails.ToesRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesRight_X));
                    CharacterDetails.ToesRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesRight_Y));
                    CharacterDetails.ToesRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesRight_Z));
                    CharacterDetails.ToesRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ToesRight_W));

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
                    CharacterDetails.HairA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairA_X));
                    CharacterDetails.HairA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairA_Y));
                    CharacterDetails.HairA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairA_Z));
                    CharacterDetails.HairA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairA_W));

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
                    CharacterDetails.HairFrontLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontLeft_X));
                    CharacterDetails.HairFrontLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontLeft_Y));
                    CharacterDetails.HairFrontLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontLeft_Z));
                    CharacterDetails.HairFrontLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontLeft_W));

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
                    CharacterDetails.HairFrontRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontRight_X));
                    CharacterDetails.HairFrontRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontRight_Y));
                    CharacterDetails.HairFrontRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontRight_Z));
                    CharacterDetails.HairFrontRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairFrontRight_W));

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
                    CharacterDetails.EarLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarLeft_X));
                    CharacterDetails.EarLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarLeft_Y));
                    CharacterDetails.EarLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarLeft_Z));
                    CharacterDetails.EarLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarLeft_W));

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
                    CharacterDetails.EarRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarRight_X));
                    CharacterDetails.EarRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarRight_Y));
                    CharacterDetails.EarRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarRight_Z));
                    CharacterDetails.EarRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarRight_W));

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
                    CharacterDetails.ForearmLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmLeft_X));
                    CharacterDetails.ForearmLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmLeft_Y));
                    CharacterDetails.ForearmLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmLeft_Z));
                    CharacterDetails.ForearmLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ForearmLeft_X.value,
                        CharacterDetails.ForearmLeft_Y.value,
                        CharacterDetails.ForearmLeft_Z.value,
                        CharacterDetails.ForearmLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ForearmLeft_Toggle = false;
                    CharacterDetails.ForearmLeft_Rotate = true;
                }

                if (CharacterDetails.ForearmRight_Toggle)
                {
                    CharacterDetails.ForearmRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmRight_X));
                    CharacterDetails.ForearmRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmRight_Y));
                    CharacterDetails.ForearmRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmRight_Z));
                    CharacterDetails.ForearmRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ForearmRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ForearmRight_X.value,
                        CharacterDetails.ForearmRight_Y.value,
                        CharacterDetails.ForearmRight_Z.value,
                        CharacterDetails.ForearmRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ForearmRight_Toggle = false;
                    CharacterDetails.ForearmRight_Rotate = true;
                }

                if (CharacterDetails.ShoulderLeft_Toggle)
                {
                    CharacterDetails.ShoulderLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderLeft_X));
                    CharacterDetails.ShoulderLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderLeft_Y));
                    CharacterDetails.ShoulderLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderLeft_Z));
                    CharacterDetails.ShoulderLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderLeft_W));

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
                    CharacterDetails.ShoulderRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderRight_X));
                    CharacterDetails.ShoulderRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderRight_Y));
                    CharacterDetails.ShoulderRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderRight_Z));
                    CharacterDetails.ShoulderRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShoulderRight_W));

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
                    CharacterDetails.HairB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairB_X));
                    CharacterDetails.HairB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairB_Y));
                    CharacterDetails.HairB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairB_Z));
                    CharacterDetails.HairB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HairB_W));

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
                    CharacterDetails.HandLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandLeft_X));
                    CharacterDetails.HandLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandLeft_Y));
                    CharacterDetails.HandLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandLeft_Z));
                    CharacterDetails.HandLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HandLeft_X.value,
                        CharacterDetails.HandLeft_Y.value,
                        CharacterDetails.HandLeft_Z.value,
                        CharacterDetails.HandLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HandLeft_Toggle = false;
                    CharacterDetails.HandLeft_Rotate = true;
                }

                if (CharacterDetails.HandRight_Toggle)
                {
                    CharacterDetails.HandRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandRight_X));
                    CharacterDetails.HandRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandRight_Y));
                    CharacterDetails.HandRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandRight_Z));
                    CharacterDetails.HandRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HandRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HandRight_X.value,
                        CharacterDetails.HandRight_Y.value,
                        CharacterDetails.HandRight_Z.value,
                        CharacterDetails.HandRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HandRight_Toggle = false;
                    CharacterDetails.HandRight_Rotate = true;
                }

                if (CharacterDetails.ShieldLeft_Toggle)
                {
                    CharacterDetails.ShieldLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldLeft_X));
                    CharacterDetails.ShieldLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldLeft_Y));
                    CharacterDetails.ShieldLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldLeft_Z));
                    CharacterDetails.ShieldLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldLeft_W));

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
                    CharacterDetails.ShieldRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldRight_X));
                    CharacterDetails.ShieldRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldRight_Y));
                    CharacterDetails.ShieldRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldRight_Z));
                    CharacterDetails.ShieldRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ShieldRight_W));

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
                    CharacterDetails.EarringALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringALeft_X));
                    CharacterDetails.EarringALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringALeft_Y));
                    CharacterDetails.EarringALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringALeft_Z));
                    CharacterDetails.EarringALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringALeft_W));

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
                    CharacterDetails.EarringARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringARight_X));
                    CharacterDetails.EarringARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringARight_Y));
                    CharacterDetails.EarringARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringARight_Z));
                    CharacterDetails.EarringARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringARight_W));

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
                    CharacterDetails.ElbowLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowLeft_X));
                    CharacterDetails.ElbowLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowLeft_Y));
                    CharacterDetails.ElbowLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowLeft_Z));
                    CharacterDetails.ElbowLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowLeft_W));

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
                    CharacterDetails.ElbowRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowRight_X));
                    CharacterDetails.ElbowRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowRight_Y));
                    CharacterDetails.ElbowRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowRight_Z));
                    CharacterDetails.ElbowRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ElbowRight_W));

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
                    CharacterDetails.CouterLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterLeft_X));
                    CharacterDetails.CouterLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterLeft_Y));
                    CharacterDetails.CouterLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterLeft_Z));
                    CharacterDetails.CouterLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterLeft_W));

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
                    CharacterDetails.CouterRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterRight_X));
                    CharacterDetails.CouterRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterRight_Y));
                    CharacterDetails.CouterRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterRight_Z));
                    CharacterDetails.CouterRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CouterRight_W));

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
                    CharacterDetails.WristLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristLeft_X));
                    CharacterDetails.WristLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristLeft_Y));
                    CharacterDetails.WristLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristLeft_Z));
                    CharacterDetails.WristLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristLeft_W));

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
                    CharacterDetails.WristRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristRight_X));
                    CharacterDetails.WristRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristRight_Y));
                    CharacterDetails.WristRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristRight_Z));
                    CharacterDetails.WristRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WristRight_W));

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
                    CharacterDetails.IndexALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexALeft_X));
                    CharacterDetails.IndexALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexALeft_Y));
                    CharacterDetails.IndexALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexALeft_Z));
                    CharacterDetails.IndexALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexALeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.IndexALeft_X.value,
                        CharacterDetails.IndexALeft_Y.value,
                        CharacterDetails.IndexALeft_Z.value,
                        CharacterDetails.IndexALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.IndexALeft_Toggle = false;
                    CharacterDetails.IndexALeft_Rotate = true;
                }

                if (CharacterDetails.IndexARight_Toggle)
                {
                    CharacterDetails.IndexARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexARight_X));
                    CharacterDetails.IndexARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexARight_Y));
                    CharacterDetails.IndexARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexARight_Z));
                    CharacterDetails.IndexARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.IndexARight_X.value,
                        CharacterDetails.IndexARight_Y.value,
                        CharacterDetails.IndexARight_Z.value,
                        CharacterDetails.IndexARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.IndexARight_Toggle = false;
                    CharacterDetails.IndexARight_Rotate = true;
                }

                if (CharacterDetails.PinkyALeft_Toggle)
                {
                    CharacterDetails.PinkyALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyALeft_X));
                    CharacterDetails.PinkyALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyALeft_Y));
                    CharacterDetails.PinkyALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyALeft_Z));
                    CharacterDetails.PinkyALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyALeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PinkyALeft_X.value,
                        CharacterDetails.PinkyALeft_Y.value,
                        CharacterDetails.PinkyALeft_Z.value,
                        CharacterDetails.PinkyALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PinkyALeft_Toggle = false;
                    CharacterDetails.PinkyALeft_Rotate = true;
                }

                if (CharacterDetails.PinkyARight_Toggle)
                {
                    CharacterDetails.PinkyARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyARight_X));
                    CharacterDetails.PinkyARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyARight_Y));
                    CharacterDetails.PinkyARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyARight_Z));
                    CharacterDetails.PinkyARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PinkyARight_X.value,
                        CharacterDetails.PinkyARight_Y.value,
                        CharacterDetails.PinkyARight_Z.value,
                        CharacterDetails.PinkyARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PinkyARight_Toggle = false;
                    CharacterDetails.PinkyARight_Rotate = true;
                }

                if (CharacterDetails.RingALeft_Toggle)
                {
                    CharacterDetails.RingALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingALeft_X));
                    CharacterDetails.RingALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingALeft_Y));
                    CharacterDetails.RingALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingALeft_Z));
                    CharacterDetails.RingALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingALeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RingALeft_X.value,
                        CharacterDetails.RingALeft_Y.value,
                        CharacterDetails.RingALeft_Z.value,
                        CharacterDetails.RingALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RingALeft_Toggle = false;
                    CharacterDetails.RingALeft_Rotate = true;
                }

                if (CharacterDetails.RingARight_Toggle)
                {
                    CharacterDetails.RingARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingARight_X));
                    CharacterDetails.RingARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingARight_Y));
                    CharacterDetails.RingARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingARight_Z));
                    CharacterDetails.RingARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RingARight_X.value,
                        CharacterDetails.RingARight_Y.value,
                        CharacterDetails.RingARight_Z.value,
                        CharacterDetails.RingARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RingARight_Toggle = false;
                    CharacterDetails.RingARight_Rotate = true;
                }

                if (CharacterDetails.MiddleALeft_Toggle)
                {
                    CharacterDetails.MiddleALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleALeft_X));
                    CharacterDetails.MiddleALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleALeft_Y));
                    CharacterDetails.MiddleALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleALeft_Z));
                    CharacterDetails.MiddleALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleALeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.MiddleALeft_X.value,
                        CharacterDetails.MiddleALeft_Y.value,
                        CharacterDetails.MiddleALeft_Z.value,
                        CharacterDetails.MiddleALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.MiddleALeft_Toggle = false;
                    CharacterDetails.MiddleALeft_Rotate = true;
                }

                if (CharacterDetails.MiddleARight_Toggle)
                {
                    CharacterDetails.MiddleARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleARight_X));
                    CharacterDetails.MiddleARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleARight_Y));
                    CharacterDetails.MiddleARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleARight_Z));
                    CharacterDetails.MiddleARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.MiddleARight_X.value,
                        CharacterDetails.MiddleARight_Y.value,
                        CharacterDetails.MiddleARight_Z.value,
                        CharacterDetails.MiddleARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.MiddleARight_Toggle = false;
                    CharacterDetails.MiddleARight_Rotate = true;
                }

                if (CharacterDetails.ThumbALeft_Toggle)
                {
                    CharacterDetails.ThumbALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbALeft_X));
                    CharacterDetails.ThumbALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbALeft_Y));
                    CharacterDetails.ThumbALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbALeft_Z));
                    CharacterDetails.ThumbALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbALeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ThumbALeft_X.value,
                        CharacterDetails.ThumbALeft_Y.value,
                        CharacterDetails.ThumbALeft_Z.value,
                        CharacterDetails.ThumbALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ThumbALeft_Toggle = false;
                    CharacterDetails.ThumbALeft_Rotate = true;
                }

                if (CharacterDetails.ThumbARight_Toggle)
                {
                    CharacterDetails.ThumbARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbARight_X));
                    CharacterDetails.ThumbARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbARight_Y));
                    CharacterDetails.ThumbARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbARight_Z));
                    CharacterDetails.ThumbARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ThumbARight_X.value,
                        CharacterDetails.ThumbARight_Y.value,
                        CharacterDetails.ThumbARight_Z.value,
                        CharacterDetails.ThumbARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ThumbARight_Toggle = false;
                    CharacterDetails.ThumbARight_Rotate = true;
                }

                if (CharacterDetails.WeaponLeft_Toggle)
                {
                    CharacterDetails.WeaponLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponLeft_X));
                    CharacterDetails.WeaponLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponLeft_Y));
                    CharacterDetails.WeaponLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponLeft_Z));
                    CharacterDetails.WeaponLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponLeft_W));

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
                    CharacterDetails.WeaponRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponRight_X));
                    CharacterDetails.WeaponRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponRight_Y));
                    CharacterDetails.WeaponRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponRight_Z));
                    CharacterDetails.WeaponRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.WeaponRight_W));

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
                    CharacterDetails.EarringBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBLeft_X));
                    CharacterDetails.EarringBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBLeft_Y));
                    CharacterDetails.EarringBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBLeft_Z));
                    CharacterDetails.EarringBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBLeft_W));

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
                    CharacterDetails.EarringBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBRight_X));
                    CharacterDetails.EarringBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBRight_Y));
                    CharacterDetails.EarringBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBRight_Z));
                    CharacterDetails.EarringBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EarringBRight_W));

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
                    CharacterDetails.IndexBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBLeft_X));
                    CharacterDetails.IndexBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBLeft_Y));
                    CharacterDetails.IndexBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBLeft_Z));
                    CharacterDetails.IndexBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBLeft_W));

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
                    CharacterDetails.IndexBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBRight_X));
                    CharacterDetails.IndexBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBRight_Y));
                    CharacterDetails.IndexBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBRight_Z));
                    CharacterDetails.IndexBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.IndexBRight_W));

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
                    CharacterDetails.PinkyBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBLeft_X));
                    CharacterDetails.PinkyBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBLeft_Y));
                    CharacterDetails.PinkyBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBLeft_Z));
                    CharacterDetails.PinkyBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBLeft_W));

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
                    CharacterDetails.PinkyBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBRight_X));
                    CharacterDetails.PinkyBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBRight_Y));
                    CharacterDetails.PinkyBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBRight_Z));
                    CharacterDetails.PinkyBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.PinkyBRight_W));

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
                    CharacterDetails.RingBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBLeft_X));
                    CharacterDetails.RingBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBLeft_Y));
                    CharacterDetails.RingBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBLeft_Z));
                    CharacterDetails.RingBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBLeft_W));

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
                    CharacterDetails.RingBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBRight_X));
                    CharacterDetails.RingBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBRight_Y));
                    CharacterDetails.RingBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBRight_Z));
                    CharacterDetails.RingBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RingBRight_W));

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
                    CharacterDetails.MiddleBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBLeft_X));
                    CharacterDetails.MiddleBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBLeft_Y));
                    CharacterDetails.MiddleBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBLeft_Z));
                    CharacterDetails.MiddleBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBLeft_W));

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
                    CharacterDetails.MiddleBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBRight_X));
                    CharacterDetails.MiddleBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBRight_Y));
                    CharacterDetails.MiddleBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBRight_Z));
                    CharacterDetails.MiddleBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.MiddleBRight_W));

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
                    CharacterDetails.ThumbBLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBLeft_X));
                    CharacterDetails.ThumbBLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBLeft_Y));
                    CharacterDetails.ThumbBLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBLeft_Z));
                    CharacterDetails.ThumbBLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBLeft_W));

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
                    CharacterDetails.ThumbBRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBRight_X));
                    CharacterDetails.ThumbBRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBRight_Y));
                    CharacterDetails.ThumbBRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBRight_Z));
                    CharacterDetails.ThumbBRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ThumbBRight_W));

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
                    CharacterDetails.TailA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailA_X));
                    CharacterDetails.TailA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailA_Y));
                    CharacterDetails.TailA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailA_Z));
                    CharacterDetails.TailA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailA_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailA_X.value,
                        CharacterDetails.TailA_Y.value,
                        CharacterDetails.TailA_Z.value,
                        CharacterDetails.TailA_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailA_Toggle = false;
                    CharacterDetails.TailA_Rotate = true;
                }

                if (CharacterDetails.TailB_Toggle)
                {
                    CharacterDetails.TailB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailB_X));
                    CharacterDetails.TailB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailB_Y));
                    CharacterDetails.TailB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailB_Z));
                    CharacterDetails.TailB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailB_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailB_X.value,
                        CharacterDetails.TailB_Y.value,
                        CharacterDetails.TailB_Z.value,
                        CharacterDetails.TailB_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailB_Toggle = false;
                    CharacterDetails.TailB_Rotate = true;
                }

                if (CharacterDetails.TailC_Toggle)
                {
                    CharacterDetails.TailC_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailC_X));
                    CharacterDetails.TailC_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailC_Y));
                    CharacterDetails.TailC_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailC_Z));
                    CharacterDetails.TailC_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailC_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailC_X.value,
                        CharacterDetails.TailC_Y.value,
                        CharacterDetails.TailC_Z.value,
                        CharacterDetails.TailC_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailC_Toggle = false;
                    CharacterDetails.TailC_Rotate = true;
                }

                if (CharacterDetails.TailD_Toggle)
                {
                    CharacterDetails.TailD_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailD_X));
                    CharacterDetails.TailD_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailD_Y));
                    CharacterDetails.TailD_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailD_Z));
                    CharacterDetails.TailD_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailD_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailD_X.value,
                        CharacterDetails.TailD_Y.value,
                        CharacterDetails.TailD_Z.value,
                        CharacterDetails.TailD_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailD_Toggle = false;
                    CharacterDetails.TailD_Rotate = true;
                }

                if (CharacterDetails.TailE_Toggle)
                {
                    CharacterDetails.TailE_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailE_X));
                    CharacterDetails.TailE_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailE_Y));
                    CharacterDetails.TailE_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailE_Z));
                    CharacterDetails.TailE_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.TailE_W));

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
                    CharacterDetails.RootHead_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RootHead_X));
                    CharacterDetails.RootHead_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RootHead_Y));
                    CharacterDetails.RootHead_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RootHead_Z));
                    CharacterDetails.RootHead_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.RootHead_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RootHead_X.value,
                        CharacterDetails.RootHead_Y.value,
                        CharacterDetails.RootHead_Z.value,
                        CharacterDetails.RootHead_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RootHead_Toggle = false;
                    CharacterDetails.RootHead_Rotate = true;
                }

                if (CharacterDetails.Jaw_Toggle)
                {
                    CharacterDetails.Jaw_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Jaw_X));
                    CharacterDetails.Jaw_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Jaw_Y));
                    CharacterDetails.Jaw_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Jaw_Z));
                    CharacterDetails.Jaw_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Jaw_W));

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
                    CharacterDetails.EyelidLowerLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerLeft_X));
                    CharacterDetails.EyelidLowerLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerLeft_Y));
                    CharacterDetails.EyelidLowerLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerLeft_Z));
                    CharacterDetails.EyelidLowerLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerLeft_W));

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
                    CharacterDetails.EyelidLowerRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerRight_X));
                    CharacterDetails.EyelidLowerRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerRight_Y));
                    CharacterDetails.EyelidLowerRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerRight_Z));
                    CharacterDetails.EyelidLowerRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidLowerRight_W));

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
                    CharacterDetails.EyeLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeLeft_X));
                    CharacterDetails.EyeLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeLeft_Y));
                    CharacterDetails.EyeLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeLeft_Z));
                    CharacterDetails.EyeLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeLeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyeLeft_X.value,
                        CharacterDetails.EyeLeft_Y.value,
                        CharacterDetails.EyeLeft_Z.value,
                        CharacterDetails.EyeLeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyeLeft_Toggle = false;
                    CharacterDetails.EyeLeft_Rotate = true;
                }

                if (CharacterDetails.EyeRight_Toggle)
                {
                    CharacterDetails.EyeRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeRight_X));
                    CharacterDetails.EyeRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeRight_Y));
                    CharacterDetails.EyeRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeRight_Z));
                    CharacterDetails.EyeRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyeRight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.EyeRight_X.value,
                        CharacterDetails.EyeRight_Y.value,
                        CharacterDetails.EyeRight_Z.value,
                        CharacterDetails.EyeRight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.EyeRight_Toggle = false;
                    CharacterDetails.EyeRight_Rotate = true;
                }

                if (CharacterDetails.Nose_Toggle)
                {
                    CharacterDetails.Nose_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Nose_X));
                    CharacterDetails.Nose_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Nose_Y));
                    CharacterDetails.Nose_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Nose_Z));
                    CharacterDetails.Nose_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Nose_W));

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
                    CharacterDetails.CheekLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekLeft_X));
                    CharacterDetails.CheekLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekLeft_Y));
                    CharacterDetails.CheekLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekLeft_Z));
                    CharacterDetails.CheekLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekLeft_W));

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
                    CharacterDetails.HrothWhiskersLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersLeft_X));
                    CharacterDetails.HrothWhiskersLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersLeft_Y));
                    CharacterDetails.HrothWhiskersLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersLeft_Z));
                    CharacterDetails.HrothWhiskersLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersLeft_W));

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
                    CharacterDetails.CheekRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekRight_X));
                    CharacterDetails.CheekRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekRight_Y));
                    CharacterDetails.CheekRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekRight_Z));
                    CharacterDetails.CheekRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.CheekRight_W));

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
                    CharacterDetails.HrothWhiskersRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersRight_X));
                    CharacterDetails.HrothWhiskersRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersRight_Y));
                    CharacterDetails.HrothWhiskersRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersRight_Z));
                    CharacterDetails.HrothWhiskersRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothWhiskersRight_W));

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
                    CharacterDetails.LipsLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsLeft_X));
                    CharacterDetails.LipsLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsLeft_Y));
                    CharacterDetails.LipsLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsLeft_Z));
                    CharacterDetails.LipsLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsLeft_W));

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
                    CharacterDetails.HrothEyebrowLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowLeft_X));
                    CharacterDetails.HrothEyebrowLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowLeft_Y));
                    CharacterDetails.HrothEyebrowLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowLeft_Z));
                    CharacterDetails.HrothEyebrowLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowLeft_W));

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
                    CharacterDetails.LipsRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsRight_X));
                    CharacterDetails.LipsRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsRight_Y));
                    CharacterDetails.LipsRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsRight_Z));
                    CharacterDetails.LipsRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipsRight_W));

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
                    CharacterDetails.HrothEyebrowRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowRight_X));
                    CharacterDetails.HrothEyebrowRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowRight_Y));
                    CharacterDetails.HrothEyebrowRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowRight_Z));
                    CharacterDetails.HrothEyebrowRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyebrowRight_W));

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
                    CharacterDetails.EyebrowLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowLeft_X));
                    CharacterDetails.EyebrowLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowLeft_Y));
                    CharacterDetails.EyebrowLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowLeft_Z));
                    CharacterDetails.EyebrowLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowLeft_W));

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
                    CharacterDetails.HrothBridge_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBridge_X));
                    CharacterDetails.HrothBridge_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBridge_Y));
                    CharacterDetails.HrothBridge_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBridge_Z));
                    CharacterDetails.HrothBridge_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBridge_W));

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
                    CharacterDetails.EyebrowRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowRight_X));
                    CharacterDetails.EyebrowRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowRight_Y));
                    CharacterDetails.EyebrowRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowRight_Z));
                    CharacterDetails.EyebrowRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyebrowRight_W));

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
                    CharacterDetails.HrothBrowLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowLeft_X));
                    CharacterDetails.HrothBrowLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowLeft_Y));
                    CharacterDetails.HrothBrowLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowLeft_Z));
                    CharacterDetails.HrothBrowLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowLeft_W));

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
                    CharacterDetails.Bridge_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Bridge_X));
                    CharacterDetails.Bridge_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Bridge_Y));
                    CharacterDetails.Bridge_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Bridge_Z));
                    CharacterDetails.Bridge_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.Bridge_W));

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
                    CharacterDetails.HrothBrowRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowRight_X));
                    CharacterDetails.HrothBrowRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowRight_Y));
                    CharacterDetails.HrothBrowRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowRight_Z));
                    CharacterDetails.HrothBrowRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothBrowRight_W));

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
                    CharacterDetails.BrowLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowLeft_X));
                    CharacterDetails.BrowLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowLeft_Y));
                    CharacterDetails.BrowLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowLeft_Z));
                    CharacterDetails.BrowLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowLeft_W));

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
                    CharacterDetails.HrothJawUpper_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothJawUpper_X));
                    CharacterDetails.HrothJawUpper_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothJawUpper_Y));
                    CharacterDetails.HrothJawUpper_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothJawUpper_Z));
                    CharacterDetails.HrothJawUpper_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothJawUpper_W));

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
                    CharacterDetails.BrowRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowRight_X));
                    CharacterDetails.BrowRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowRight_Y));
                    CharacterDetails.BrowRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowRight_Z));
                    CharacterDetails.BrowRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.BrowRight_W));

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
                    CharacterDetails.HrothLipUpper_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpper_X));
                    CharacterDetails.HrothLipUpper_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpper_Y));
                    CharacterDetails.HrothLipUpper_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpper_Z));
                    CharacterDetails.HrothLipUpper_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpper_W));

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
                    CharacterDetails.LipUpperA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperA_X));
                    CharacterDetails.LipUpperA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperA_Y));
                    CharacterDetails.LipUpperA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperA_Z));
                    CharacterDetails.LipUpperA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperA_W));

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
                    CharacterDetails.HrothEyelidUpperLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_X));
                    CharacterDetails.HrothEyelidUpperLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_Y));
                    CharacterDetails.HrothEyelidUpperLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_Z));
                    CharacterDetails.HrothEyelidUpperLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_W));

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
                    CharacterDetails.EyelidUpperLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperLeft_X));
                    CharacterDetails.EyelidUpperLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperLeft_Y));
                    CharacterDetails.EyelidUpperLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperLeft_Z));
                    CharacterDetails.EyelidUpperLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperLeft_W));

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
                    CharacterDetails.HrothEyelidUpperRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_X));
                    CharacterDetails.HrothEyelidUpperRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_Y));
                    CharacterDetails.HrothEyelidUpperRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_Z));
                    CharacterDetails.HrothEyelidUpperRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_W));

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
                    CharacterDetails.EyelidUpperRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperRight_X));
                    CharacterDetails.EyelidUpperRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperRight_Y));
                    CharacterDetails.EyelidUpperRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperRight_Z));
                    CharacterDetails.EyelidUpperRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.EyelidUpperRight_W));

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
                    CharacterDetails.HrothLipsLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsLeft_X));
                    CharacterDetails.HrothLipsLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsLeft_Y));
                    CharacterDetails.HrothLipsLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsLeft_Z));
                    CharacterDetails.HrothLipsLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsLeft_W));

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
                    CharacterDetails.LipLowerA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerA_X));
                    CharacterDetails.LipLowerA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerA_Y));
                    CharacterDetails.LipLowerA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerA_Z));
                    CharacterDetails.LipLowerA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerA_W));

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
                    CharacterDetails.HrothLipsRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsRight_X));
                    CharacterDetails.HrothLipsRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsRight_Y));
                    CharacterDetails.HrothLipsRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsRight_Z));
                    CharacterDetails.HrothLipsRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipsRight_W));

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
                    CharacterDetails.VieraEar01ALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ALeft_X));
                    CharacterDetails.VieraEar01ALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ALeft_Y));
                    CharacterDetails.VieraEar01ALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ALeft_Z));
                    CharacterDetails.VieraEar01ALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ALeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar01ALeft_X.value,
                        CharacterDetails.VieraEar01ALeft_Y.value,
                        CharacterDetails.VieraEar01ALeft_Z.value,
                        CharacterDetails.VieraEar01ALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar01ALeft_Toggle = false;
                    CharacterDetails.VieraEar01ALeft_Rotate = true;
                }

                if (CharacterDetails.LipUpperB_Toggle)
                {
                    CharacterDetails.LipUpperB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperB_X));
                    CharacterDetails.LipUpperB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperB_Y));
                    CharacterDetails.LipUpperB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperB_Z));
                    CharacterDetails.LipUpperB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipUpperB_W));

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
                    CharacterDetails.HrothLipUpperLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperLeft_X));
                    CharacterDetails.HrothLipUpperLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperLeft_Y));
                    CharacterDetails.HrothLipUpperLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperLeft_Z));
                    CharacterDetails.HrothLipUpperLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperLeft_W));

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
                    CharacterDetails.VieraEar01ARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ARight_X));
                    CharacterDetails.VieraEar01ARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ARight_Y));
                    CharacterDetails.VieraEar01ARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ARight_Z));
                    CharacterDetails.VieraEar01ARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01ARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar01ARight_X.value,
                        CharacterDetails.VieraEar01ARight_Y.value,
                        CharacterDetails.VieraEar01ARight_Z.value,
                        CharacterDetails.VieraEar01ARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar01ARight_Toggle = false;
                    CharacterDetails.VieraEar01ARight_Rotate = true;
                }

                if (CharacterDetails.LipLowerB_Toggle)
                {
                    CharacterDetails.LipLowerB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerB_X));
                    CharacterDetails.LipLowerB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerB_Y));
                    CharacterDetails.LipLowerB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerB_Z));
                    CharacterDetails.LipLowerB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.LipLowerB_W));

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
                    CharacterDetails.HrothLipUpperRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperRight_X));
                    CharacterDetails.HrothLipUpperRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperRight_Y));
                    CharacterDetails.HrothLipUpperRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperRight_Z));
                    CharacterDetails.HrothLipUpperRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipUpperRight_W));

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
                    CharacterDetails.VieraEar02ALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ALeft_X));
                    CharacterDetails.VieraEar02ALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ALeft_Y));
                    CharacterDetails.VieraEar02ALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ALeft_Z));
                    CharacterDetails.VieraEar02ALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ALeft_W));

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
                    CharacterDetails.HrothLipLower_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipLower_X));
                    CharacterDetails.HrothLipLower_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipLower_Y));
                    CharacterDetails.HrothLipLower_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipLower_Z));
                    CharacterDetails.HrothLipLower_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.HrothLipLower_W));

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
                    CharacterDetails.VieraEar02ARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ARight_X));
                    CharacterDetails.VieraEar02ARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ARight_Y));
                    CharacterDetails.VieraEar02ARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ARight_Z));
                    CharacterDetails.VieraEar02ARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02ARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar02ARight_X.value,
                        CharacterDetails.VieraEar02ARight_Y.value,
                        CharacterDetails.VieraEar02ARight_Z.value,
                        CharacterDetails.VieraEar02ARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar02ARight_Toggle = false;
                    CharacterDetails.VieraEar02ARight_Rotate = true;
                }

                if (CharacterDetails.VieraEar03ALeft_Toggle)
                {
                    CharacterDetails.VieraEar03ALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ALeft_X));
                    CharacterDetails.VieraEar03ALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ALeft_Y));
                    CharacterDetails.VieraEar03ALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ALeft_Z));
                    CharacterDetails.VieraEar03ALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ALeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar03ALeft_X.value,
                        CharacterDetails.VieraEar03ALeft_Y.value,
                        CharacterDetails.VieraEar03ALeft_Z.value,
                        CharacterDetails.VieraEar03ALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar03ALeft_Toggle = false;
                    CharacterDetails.VieraEar03ALeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar03ARight_Toggle)
                {
                    CharacterDetails.VieraEar03ARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ARight_X));
                    CharacterDetails.VieraEar03ARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ARight_Y));
                    CharacterDetails.VieraEar03ARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ARight_Z));
                    CharacterDetails.VieraEar03ARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03ARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar03ARight_X.value,
                        CharacterDetails.VieraEar03ARight_Y.value,
                        CharacterDetails.VieraEar03ARight_Z.value,
                        CharacterDetails.VieraEar03ARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar03ARight_Toggle = false;
                    CharacterDetails.VieraEar03ARight_Rotate = true;
                }

                if (CharacterDetails.VieraEar04ALeft_Toggle)
                {
                    CharacterDetails.VieraEar04ALeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ALeft_X));
                    CharacterDetails.VieraEar04ALeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ALeft_Y));
                    CharacterDetails.VieraEar04ALeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ALeft_Z));
                    CharacterDetails.VieraEar04ALeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ALeft_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar04ALeft_X.value,
                        CharacterDetails.VieraEar04ALeft_Y.value,
                        CharacterDetails.VieraEar04ALeft_Z.value,
                        CharacterDetails.VieraEar04ALeft_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar04ALeft_Toggle = false;
                    CharacterDetails.VieraEar04ALeft_Rotate = true;
                }

                if (CharacterDetails.VieraEar04ARight_Toggle)
                {
                    CharacterDetails.VieraEar04ARight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ARight_X));
                    CharacterDetails.VieraEar04ARight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ARight_Y));
                    CharacterDetails.VieraEar04ARight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ARight_Z));
                    CharacterDetails.VieraEar04ARight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04ARight_W));

                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.VieraEar04ARight_X.value,
                        CharacterDetails.VieraEar04ARight_Y.value,
                        CharacterDetails.VieraEar04ARight_Z.value,
                        CharacterDetails.VieraEar04ARight_W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.VieraEar04ARight_Toggle = false;
                    CharacterDetails.VieraEar04ARight_Rotate = true;
                }

                if (CharacterDetails.VieraLipLowerA_Toggle)
                {
                    CharacterDetails.VieraLipLowerA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerA_X));
                    CharacterDetails.VieraLipLowerA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerA_Y));
                    CharacterDetails.VieraLipLowerA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerA_Z));
                    CharacterDetails.VieraLipLowerA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerA_W));

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
                    CharacterDetails.VieraLipUpperB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipUpperB_X));
                    CharacterDetails.VieraLipUpperB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipUpperB_Y));
                    CharacterDetails.VieraLipUpperB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipUpperB_Z));
                    CharacterDetails.VieraLipUpperB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipUpperB_W));

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
                    CharacterDetails.VieraEar01BLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BLeft_X));
                    CharacterDetails.VieraEar01BLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BLeft_Y));
                    CharacterDetails.VieraEar01BLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BLeft_Z));
                    CharacterDetails.VieraEar01BLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BLeft_W));

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
                    CharacterDetails.VieraEar01BRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BRight_X));
                    CharacterDetails.VieraEar01BRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BRight_Y));
                    CharacterDetails.VieraEar01BRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BRight_Z));
                    CharacterDetails.VieraEar01BRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar01BRight_W));

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
                    CharacterDetails.VieraEar02BLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BLeft_X));
                    CharacterDetails.VieraEar02BLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BLeft_Y));
                    CharacterDetails.VieraEar02BLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BLeft_Z));
                    CharacterDetails.VieraEar02BLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BLeft_W));

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
                    CharacterDetails.VieraEar02BRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BRight_X));
                    CharacterDetails.VieraEar02BRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BRight_Y));
                    CharacterDetails.VieraEar02BRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BRight_Z));
                    CharacterDetails.VieraEar02BRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar02BRight_W));

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
                    CharacterDetails.VieraEar03BLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BLeft_X));
                    CharacterDetails.VieraEar03BLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BLeft_Y));
                    CharacterDetails.VieraEar03BLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BLeft_Z));
                    CharacterDetails.VieraEar03BLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BLeft_W));

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
                    CharacterDetails.VieraEar03BRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BRight_X));
                    CharacterDetails.VieraEar03BRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BRight_Y));
                    CharacterDetails.VieraEar03BRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BRight_Z));
                    CharacterDetails.VieraEar03BRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar03BRight_W));

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
                    CharacterDetails.VieraEar04BLeft_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BLeft_X));
                    CharacterDetails.VieraEar04BLeft_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BLeft_Y));
                    CharacterDetails.VieraEar04BLeft_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BLeft_Z));
                    CharacterDetails.VieraEar04BLeft_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BLeft_W));

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
                    CharacterDetails.VieraEar04BRight_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BRight_X));
                    CharacterDetails.VieraEar04BRight_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BRight_Y));
                    CharacterDetails.VieraEar04BRight_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BRight_Z));
                    CharacterDetails.VieraEar04BRight_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraEar04BRight_W));

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
                    CharacterDetails.VieraLipLowerB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerB_X));
                    CharacterDetails.VieraLipLowerB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerB_Y));
                    CharacterDetails.VieraLipLowerB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerB_Z));
                    CharacterDetails.VieraLipLowerB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.VieraLipLowerB_W));

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
                    CharacterDetails.ExRootHair_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootHair_X));
                    CharacterDetails.ExRootHair_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootHair_Y));
                    CharacterDetails.ExRootHair_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootHair_Z));
                    CharacterDetails.ExRootHair_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootHair_W));

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
                    CharacterDetails.ExHairA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairA_X));
                    CharacterDetails.ExHairA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairA_Y));
                    CharacterDetails.ExHairA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairA_Z));
                    CharacterDetails.ExHairA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairA_W));

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
                    CharacterDetails.ExHairB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairB_X));
                    CharacterDetails.ExHairB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairB_Y));
                    CharacterDetails.ExHairB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairB_Z));
                    CharacterDetails.ExHairB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairB_W));

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
                    CharacterDetails.ExHairC_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairC_X));
                    CharacterDetails.ExHairC_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairC_Y));
                    CharacterDetails.ExHairC_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairC_Z));
                    CharacterDetails.ExHairC_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairC_W));

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
                    CharacterDetails.ExHairD_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairD_X));
                    CharacterDetails.ExHairD_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairD_Y));
                    CharacterDetails.ExHairD_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairD_Z));
                    CharacterDetails.ExHairD_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairD_W));

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
                    CharacterDetails.ExHairE_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairE_X));
                    CharacterDetails.ExHairE_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairE_Y));
                    CharacterDetails.ExHairE_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairE_Z));
                    CharacterDetails.ExHairE_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairE_W));

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
                    CharacterDetails.ExHairF_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairF_X));
                    CharacterDetails.ExHairF_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairF_Y));
                    CharacterDetails.ExHairF_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairF_Z));
                    CharacterDetails.ExHairF_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairF_W));

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
                    CharacterDetails.ExHairG_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairG_X));
                    CharacterDetails.ExHairG_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairG_Y));
                    CharacterDetails.ExHairG_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairG_Z));
                    CharacterDetails.ExHairG_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairG_W));

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
                    CharacterDetails.ExHairH_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairH_X));
                    CharacterDetails.ExHairH_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairH_Y));
                    CharacterDetails.ExHairH_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairH_Z));
                    CharacterDetails.ExHairH_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairH_W));

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
                    CharacterDetails.ExHairI_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairI_X));
                    CharacterDetails.ExHairI_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairI_Y));
                    CharacterDetails.ExHairI_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairI_Z));
                    CharacterDetails.ExHairI_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairI_W));

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
                    CharacterDetails.ExHairJ_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairJ_X));
                    CharacterDetails.ExHairJ_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairJ_Y));
                    CharacterDetails.ExHairJ_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairJ_Z));
                    CharacterDetails.ExHairJ_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairJ_W));

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
                    CharacterDetails.ExHairK_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairK_X));
                    CharacterDetails.ExHairK_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairK_Y));
                    CharacterDetails.ExHairK_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairK_Z));
                    CharacterDetails.ExHairK_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairK_W));

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
                    CharacterDetails.ExHairL_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairL_X));
                    CharacterDetails.ExHairL_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairL_Y));
                    CharacterDetails.ExHairL_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairL_Z));
                    CharacterDetails.ExHairL_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExHairL_W));

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
                    CharacterDetails.ExRootMet_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootMet_X));
                    CharacterDetails.ExRootMet_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootMet_Y));
                    CharacterDetails.ExRootMet_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootMet_Z));
                    CharacterDetails.ExRootMet_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootMet_W));

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
                    CharacterDetails.ExMetA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetA_X));
                    CharacterDetails.ExMetA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetA_Y));
                    CharacterDetails.ExMetA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetA_Z));
                    CharacterDetails.ExMetA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetA_W));

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
                    CharacterDetails.ExMetB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetB_X));
                    CharacterDetails.ExMetB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetB_Y));
                    CharacterDetails.ExMetB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetB_Z));
                    CharacterDetails.ExMetB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetB_W));

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
                    CharacterDetails.ExMetC_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetC_X));
                    CharacterDetails.ExMetC_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetC_Y));
                    CharacterDetails.ExMetC_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetC_Z));
                    CharacterDetails.ExMetC_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetC_W));

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
                    CharacterDetails.ExMetD_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetD_X));
                    CharacterDetails.ExMetD_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetD_Y));
                    CharacterDetails.ExMetD_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetD_Z));
                    CharacterDetails.ExMetD_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetD_W));

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
                    CharacterDetails.ExMetE_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetE_X));
                    CharacterDetails.ExMetE_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetE_Y));
                    CharacterDetails.ExMetE_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetE_Z));
                    CharacterDetails.ExMetE_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetE_W));

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
                    CharacterDetails.ExMetF_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetF_X));
                    CharacterDetails.ExMetF_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetF_Y));
                    CharacterDetails.ExMetF_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetF_Z));
                    CharacterDetails.ExMetF_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetF_W));

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
                    CharacterDetails.ExMetG_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetG_X));
                    CharacterDetails.ExMetG_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetG_Y));
                    CharacterDetails.ExMetG_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetG_Z));
                    CharacterDetails.ExMetG_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetG_W));

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
                    CharacterDetails.ExMetH_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetH_X));
                    CharacterDetails.ExMetH_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetH_Y));
                    CharacterDetails.ExMetH_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetH_Z));
                    CharacterDetails.ExMetH_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetH_W));

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
                    CharacterDetails.ExMetI_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetI_X));
                    CharacterDetails.ExMetI_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetI_Y));
                    CharacterDetails.ExMetI_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetI_Z));
                    CharacterDetails.ExMetI_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetI_W));

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
                    CharacterDetails.ExMetK_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetK_X));
                    CharacterDetails.ExMetK_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetK_Y));
                    CharacterDetails.ExMetK_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetK_Z));
                    CharacterDetails.ExMetK_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetK_W));

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
                    CharacterDetails.ExMetL_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetL_X));
                    CharacterDetails.ExMetL_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetL_Y));
                    CharacterDetails.ExMetL_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetL_Z));
                    CharacterDetails.ExMetL_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetL_W));

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
                    CharacterDetails.ExMetM_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetM_X));
                    CharacterDetails.ExMetM_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetM_Y));
                    CharacterDetails.ExMetM_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetM_Z));
                    CharacterDetails.ExMetM_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetM_W));

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
                    CharacterDetails.ExMetN_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetN_X));
                    CharacterDetails.ExMetN_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetN_Y));
                    CharacterDetails.ExMetN_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetN_Z));
                    CharacterDetails.ExMetN_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetN_W));

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
                    CharacterDetails.ExMetO_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetO_X));
                    CharacterDetails.ExMetO_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetO_Y));
                    CharacterDetails.ExMetO_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetO_Z));
                    CharacterDetails.ExMetO_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetO_W));

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
                    CharacterDetails.ExMetP_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetP_X));
                    CharacterDetails.ExMetP_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetP_Y));
                    CharacterDetails.ExMetP_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetP_Z));
                    CharacterDetails.ExMetP_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetP_W));

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
                    CharacterDetails.ExMetQ_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetQ_X));
                    CharacterDetails.ExMetQ_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetQ_Y));
                    CharacterDetails.ExMetQ_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetQ_Z));
                    CharacterDetails.ExMetQ_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetQ_W));

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
                    CharacterDetails.ExMetR_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetR_X));
                    CharacterDetails.ExMetR_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetR_Y));
                    CharacterDetails.ExMetR_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetR_Z));
                    CharacterDetails.ExMetR_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExMetR_W));

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
                    CharacterDetails.ExRootTop_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootTop_X));
                    CharacterDetails.ExRootTop_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootTop_Y));
                    CharacterDetails.ExRootTop_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootTop_Z));
                    CharacterDetails.ExRootTop_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExRootTop_W));

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
                    CharacterDetails.ExTopA_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopA_X));
                    CharacterDetails.ExTopA_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopA_Y));
                    CharacterDetails.ExTopA_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopA_Z));
                    CharacterDetails.ExTopA_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopA_W));

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
                    CharacterDetails.ExTopB_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopB_X));
                    CharacterDetails.ExTopB_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopB_Y));
                    CharacterDetails.ExTopB_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopB_Z));
                    CharacterDetails.ExTopB_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopB_W));

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
                    CharacterDetails.ExTopC_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopC_X));
                    CharacterDetails.ExTopC_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopC_Y));
                    CharacterDetails.ExTopC_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopC_Z));
                    CharacterDetails.ExTopC_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopC_W));

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
                    CharacterDetails.ExTopD_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopD_X));
                    CharacterDetails.ExTopD_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopD_Y));
                    CharacterDetails.ExTopD_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopD_Z));
                    CharacterDetails.ExTopD_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopD_W));

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
                    CharacterDetails.ExTopE_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopE_X));
                    CharacterDetails.ExTopE_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopE_Y));
                    CharacterDetails.ExTopE_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopE_Z));
                    CharacterDetails.ExTopE_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopE_W));

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
                    CharacterDetails.ExTopF_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopF_X));
                    CharacterDetails.ExTopF_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopF_Y));
                    CharacterDetails.ExTopF_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopF_Z));
                    CharacterDetails.ExTopF_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopF_W));

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
                    CharacterDetails.ExTopG_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopG_X));
                    CharacterDetails.ExTopG_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopG_Y));
                    CharacterDetails.ExTopG_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopG_Z));
                    CharacterDetails.ExTopG_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopG_W));

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
                    CharacterDetails.ExTopH_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopH_X));
                    CharacterDetails.ExTopH_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopH_Y));
                    CharacterDetails.ExTopH_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopH_Z));
                    CharacterDetails.ExTopH_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopH_W));

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
                    CharacterDetails.ExTopI_X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopI_X));
                    CharacterDetails.ExTopI_Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopI_Y));
                    CharacterDetails.ExTopI_Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopI_Z));
                    CharacterDetails.ExTopI_W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Bones.ExTopI_W));

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

                if (!CharacterDetails.X.freeze) CharacterDetails.X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.X));

                if (!CharacterDetails.Y.freeze) CharacterDetails.Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Y));

                if (!CharacterDetails.Z.freeze) CharacterDetails.Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Z));

                if (!CharacterDetails.TailSize.freeze) CharacterDetails.TailSize.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.TailSize));

                if (!CharacterDetails.MuscleTone.freeze) CharacterDetails.MuscleTone.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.MuscleTone));

                if (!CharacterDetails.Transparency.freeze) CharacterDetails.Transparency.value = m.readFloat(GAS(baseAddr, c.Transparency));

                if (!CharacterDetails.ModelType.freeze) CharacterDetails.ModelType.value = (int)m.read2Byte((GAS(baseAddr, c.ModelType)));

                if (!CharacterDetails.DataPath.freeze) CharacterDetails.DataPath.value = (short)m.read2Byte((GAS(baseAddr, c.DataPath)));

                if (!CharacterDetails.NPCName.freeze) CharacterDetails.NPCName.value = (short)m.read2Byte((GAS(baseAddr, c.NPCName)));

                if (!CharacterDetails.NPCModel.freeze) CharacterDetails.NPCModel.value = (short)m.read2Byte((GAS(baseAddr, c.NPCModel)));

                CharacterDetails.AltCheckPlayerFrozen.value = (float)m.readFloat((GAS(baseAddr, c.AltCheckPlayerFrozen)));

                CharacterDetails.EmoteIsPlayerFrozen.value = (byte)m.readByte((GAS(baseAddr, c.EmoteIsPlayerFrozen)));

                if (CharacterDetails.AltCheckPlayerFrozen.value == 0) { Viewtime.FrozenPlayaLabel.Dispatcher.Invoke(new Action(() => { Viewtime.FrozenPlayaLabel.Content = "Currently not Targeting a Valid Actor!"; if (SaveSettings.Default.Theme == "Dark") Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.White; else Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.Black; })); }
                else if (CharacterDetails.EmoteIsPlayerFrozen.value == 0 && CharacterDetails.AltCheckPlayerFrozen.value == 1) { Viewtime.FrozenPlayaLabel.Dispatcher.Invoke(new Action(() => { Viewtime.FrozenPlayaLabel.Content = "Targeted Actor is Frozen!"; Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.Red; })); }
                else if (CharacterDetails.EmoteIsPlayerFrozen.value == 1 && CharacterDetails.AltCheckPlayerFrozen.value == 1) { Viewtime.FrozenPlayaLabel.Dispatcher.Invoke(new Action(() => { Viewtime.FrozenPlayaLabel.Content = "Targeted Actor is Animating!"; Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.Green; })); }

                if (!CharacterDetails.Emote.freeze) CharacterDetails.Emote.value = (int)m.read2Byte((GAS(baseAddr, c.Emote)));

                if (!CharacterDetails.EntityType.freeze) CharacterDetails.EntityType.value = (byte)m.readByte(GAS(baseAddr, c.EntityType));

                if (!CharacterDetails.EmoteOld.freeze) CharacterDetails.EmoteOld.value = (int)m.read2Byte((GAS(baseAddr, c.EmoteOld)));

                if (!CharacterDetails.EmoteSpeed1.freeze) CharacterDetails.EmoteSpeed1.value = (float)m.readFloat((GAS(baseAddr, c.EmoteSpeed1)));

                if (!CharacterDetails.Job.freeze && !CharacterDetails.Job.Activated)
                {
                    CharacterDetails.Job.value = (int)m.read2Byte(GAS(baseAddr, c.Job));
                    CharacterDetails.WeaponBase.value = (int)m.read2Byte(GAS(baseAddr, c.WeaponBase));
                    CharacterDetails.WeaponV.value = (byte)m.readByte(GAS(baseAddr, c.WeaponV));
                    CharacterDetails.WeaponDye.value = (byte)m.readByte(GAS(baseAddr, c.WeaponDye));
                }
                if (!CharacterDetails.Offhand.freeze && !CharacterDetails.Offhand.Activated)
                {
                    CharacterDetails.Offhand.value = (int)m.read2Byte(GAS(baseAddr, c.Offhand));
                    CharacterDetails.OffhandBase.value = (int)m.read2Byte(GAS(baseAddr, c.OffhandBase));
                    CharacterDetails.OffhandV.value = (byte)m.readByte(GAS(baseAddr, c.OffhandV));
                    CharacterDetails.OffhandDye.value = (byte)m.readByte(GAS(baseAddr, c.OffhandDye));
                }
                if (!CharacterDetails.HeadPiece.freeze && !CharacterDetails.HeadPiece.Activated)
                {
                    CharacterDetails.HeadPiece.value = (int)m.read2Byte(GAS(baseAddr, c.HeadPiece));
                    CharacterDetails.HeadV.value = (byte)m.readByte(GAS(baseAddr, c.HeadV));
                    CharacterDetails.HeadDye.value = (byte)m.readByte(GAS(baseAddr, c.HeadDye));
                }
                if (!CharacterDetails.Chest.freeze && !CharacterDetails.Chest.Activated)
                {
                    CharacterDetails.Chest.value = (int)m.read2Byte(GAS(baseAddr, c.Chest));
                    CharacterDetails.ChestV.value = (byte)m.readByte(GAS(baseAddr, c.ChestV));
                    CharacterDetails.ChestDye.value = (byte)m.readByte(GAS(baseAddr, c.ChestDye));
                }
                if (!CharacterDetails.Arms.freeze && !CharacterDetails.Arms.Activated)
                {
                    CharacterDetails.Arms.value = (int)m.read2Byte(GAS(baseAddr, c.Arms));
                    CharacterDetails.ArmsV.value = (byte)m.readByte(GAS(baseAddr, c.ArmsV));
                    CharacterDetails.ArmsDye.value = (byte)m.readByte(GAS(baseAddr, c.ArmsDye));
                }
                if (!CharacterDetails.Legs.freeze && !CharacterDetails.Legs.Activated)
                {
                    CharacterDetails.Legs.value = (int)m.read2Byte(GAS(baseAddr, c.Legs));
                    CharacterDetails.LegsV.value = (byte)m.readByte(GAS(baseAddr, c.LegsV));
                    CharacterDetails.LegsDye.value = (byte)m.readByte(GAS(baseAddr, c.LegsDye));
                }
                if (!CharacterDetails.Feet.freeze && !CharacterDetails.Feet.Activated)
                {
                    CharacterDetails.Feet.value = (int)m.read2Byte(GAS(baseAddr, c.Feet));
                    CharacterDetails.FeetVa.value = (byte)m.readByte(GAS(baseAddr, c.FeetVa));
                    CharacterDetails.FeetDye.value = (byte)m.readByte(GAS(baseAddr, c.FeetDye));
                }

                if (!CharacterDetails.LFinger.freeze && !CharacterDetails.LFinger.Activated)
                {
                    CharacterDetails.LFinger.value = (int)m.read2Byte(GAS(baseAddr, c.LFinger));
                    CharacterDetails.LFingerVa.value = (byte)m.readByte(GAS(baseAddr, c.LFingerVa));
                }
                if (!CharacterDetails.RFinger.freeze && !CharacterDetails.RFinger.Activated)
                {
                    CharacterDetails.RFinger.value = (int)m.read2Byte(GAS(baseAddr, c.RFinger));
                    CharacterDetails.RFingerVa.value = (byte)m.readByte(GAS(baseAddr, c.RFingerVa));
                }
                if (!CharacterDetails.Wrist.freeze && !CharacterDetails.Wrist.Activated)
                {
                    CharacterDetails.Wrist.value = (int)m.read2Byte(GAS(baseAddr, c.Wrist));
                    CharacterDetails.WristVa.value = (byte)m.readByte(GAS(baseAddr, c.WristVa));
                }
                if (!CharacterDetails.Neck.freeze && !CharacterDetails.Neck.Activated)
                {
                    CharacterDetails.Neck.value = (int)m.read2Byte(GAS(baseAddr, c.Neck));
                    CharacterDetails.NeckVa.value = (byte)m.readByte(GAS(baseAddr, c.NeckVa));
                }
                if (!CharacterDetails.Ear.freeze && !CharacterDetails.Ear.Activated)
                {
                    CharacterDetails.Ear.value = (int)m.read2Byte(GAS(baseAddr, c.Ear));
                    CharacterDetails.EarVa.value = (byte)m.readByte(GAS(baseAddr, c.EarVa));
                }
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

                if (!CharacterDetails.FOVMAX.freeze)
                {
                    CharacterDetails.FOVMAX.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.FOVMAX));
                    CharacterDetails.FOVC.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.FOVC));
                }

                if (!CharacterDetails.CZoom.freeze) CharacterDetails.CZoom.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CZoom));

                if (!CharacterDetails.Min.freeze) CharacterDetails.Min.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.Min));

                if (!CharacterDetails.Max.freeze) CharacterDetails.Max.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.Max));

                if (!CharacterDetails.CamAngleX.freeze) CharacterDetails.CamAngleX.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CamAngleX));

                if (!CharacterDetails.CamAngleY.freeze) CharacterDetails.CamAngleY.value = m.readFloat(GAS(MemoryManager.Instance.CameraAddress, c.CamAngleY));

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

                if (!CharacterDetails.StatusEffect.freeze) CharacterDetails.StatusEffect.value = (short)m.read2Byte(GAS(baseAddr, c.StatusEffect));
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
            catch (Exception)
            {
				//System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace, App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
				mediator.Work -= Work;
            }
        }
    }
}