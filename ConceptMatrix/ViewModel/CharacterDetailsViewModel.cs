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
                    else if (m.readByte(GAS(MemoryManager.Instance.GposeCheckAddress)) == 1)
                    {
                        if (!InGpose)
                        {
                            m.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.EntityType), "byte", "0x02");
                            Task.Delay(1500).Wait();
                            m.writeMemory(GAS(MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset), c.EntityType), "byte", "0x01");
                            CharacterDetails.GposeMode = true;
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

                #region Skeletal Rotations
                if (CharacterDetails.HeadCheck)
                {
                    CharacterDetails.HeadX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.HeadX));
                    CharacterDetails.HeadY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.HeadY));
                    CharacterDetails.HeadZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.HeadZ));
                    CharacterDetails.HeadW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.HeadW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.HeadX.value,
                        CharacterDetails.HeadY.value,
                        CharacterDetails.HeadZ.value,
                        CharacterDetails.HeadW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.HeadCheck = false;
                    CharacterDetails.HeadRotate = true;
                }

                if (CharacterDetails.NoseCheck)
                {
                    CharacterDetails.NoseX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NoseX));
                    CharacterDetails.NoseY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NoseY));
                    CharacterDetails.NoseZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NoseZ));
                    CharacterDetails.NoseW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NoseW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.NoseX.value,
                        CharacterDetails.NoseY.value,
                        CharacterDetails.NoseZ.value,
                        CharacterDetails.NoseW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.NoseCheck = false;
                    CharacterDetails.NoseRotate = true;
                }

                if (CharacterDetails.NostrilsCheck)
                {
                    CharacterDetails.NostrilsX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NostrilsX));
                    CharacterDetails.NostrilsY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NostrilsY));
                    CharacterDetails.NostrilsZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NostrilsZ));
                    CharacterDetails.NostrilsW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NostrilsW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.NostrilsX.value,
                        CharacterDetails.NostrilsY.value,
                        CharacterDetails.NostrilsZ.value,
                        CharacterDetails.NostrilsW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.NostrilsCheck = false;
                    CharacterDetails.NostrilsRotate = true;
                }

                if (CharacterDetails.ChinCheck)
                {
                    CharacterDetails.ChinX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ChinX));
                    CharacterDetails.ChinY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ChinY));
                    CharacterDetails.ChinZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ChinZ));
                    CharacterDetails.ChinW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ChinW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ChinX.value,
                        CharacterDetails.ChinY.value,
                        CharacterDetails.ChinZ.value,
                        CharacterDetails.ChinW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ChinCheck = false;
                    CharacterDetails.ChinRotate = true;
                }

                if (CharacterDetails.LOutEyebrowCheck)
                {
                    CharacterDetails.LOutEyebrowX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LOutEyebrowX));
                    CharacterDetails.LOutEyebrowY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LOutEyebrowY));
                    CharacterDetails.LOutEyebrowZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LOutEyebrowZ));
                    CharacterDetails.LOutEyebrowW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LOutEyebrowW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LOutEyebrowX.value,
                        CharacterDetails.LOutEyebrowY.value,
                        CharacterDetails.LOutEyebrowZ.value,
                        CharacterDetails.LOutEyebrowW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LOutEyebrowCheck = false;
                    CharacterDetails.LOutEyebrowRotate = true;
                }

                if (CharacterDetails.ROutEyebrowCheck)
                {
                    CharacterDetails.ROutEyebrowX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ROutEyebrowX));
                    CharacterDetails.ROutEyebrowY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ROutEyebrowY));
                    CharacterDetails.ROutEyebrowZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ROutEyebrowZ));
                    CharacterDetails.ROutEyebrowW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ROutEyebrowW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.ROutEyebrowX.value,
                        CharacterDetails.ROutEyebrowY.value,
                        CharacterDetails.ROutEyebrowZ.value,
                        CharacterDetails.ROutEyebrowW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.ROutEyebrowCheck = false;
                    CharacterDetails.ROutEyebrowRotate = true;
                }

                if (CharacterDetails.LInEyebrowCheck)
                {
                    CharacterDetails.LInEyebrowX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LInEyebrowX));
                    CharacterDetails.LInEyebrowY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LInEyebrowY));
                    CharacterDetails.LInEyebrowZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LInEyebrowZ));
                    CharacterDetails.LInEyebrowW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LInEyebrowW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LInEyebrowX.value,
                        CharacterDetails.LInEyebrowY.value,
                        CharacterDetails.LInEyebrowZ.value,
                        CharacterDetails.LInEyebrowW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LInEyebrowCheck = false;
                    CharacterDetails.LInEyebrowRotate = true;
                }

                if (CharacterDetails.RInEyebrowCheck)
                {
                    CharacterDetails.RInEyebrowX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RInEyebrowX));
                    CharacterDetails.RInEyebrowY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RInEyebrowY));
                    CharacterDetails.RInEyebrowZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RInEyebrowZ));
                    CharacterDetails.RInEyebrowW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RInEyebrowW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RInEyebrowX.value,
                        CharacterDetails.RInEyebrowY.value,
                        CharacterDetails.RInEyebrowZ.value,
                        CharacterDetails.RInEyebrowW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RInEyebrowCheck = false;
                    CharacterDetails.RInEyebrowRotate = true;
                }

                if (CharacterDetails.LEyeCheck)
                {
                    CharacterDetails.LEyeX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyeX));
                    CharacterDetails.LEyeY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyeY));
                    CharacterDetails.LEyeZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyeZ));
                    CharacterDetails.LEyeW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyeW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LEyeX.value,
                        CharacterDetails.LEyeY.value,
                        CharacterDetails.LEyeZ.value,
                        CharacterDetails.LEyeW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LEyeCheck = false;
                    CharacterDetails.LEyeRotate = true;
                }

                if (CharacterDetails.REyeCheck)
                {
                    CharacterDetails.REyeX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyeX));
                    CharacterDetails.REyeY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyeY));
                    CharacterDetails.REyeZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyeZ));
                    CharacterDetails.REyeW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyeW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.REyeX.value,
                        CharacterDetails.REyeY.value,
                        CharacterDetails.REyeZ.value,
                        CharacterDetails.REyeW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.REyeCheck = false;
                    CharacterDetails.REyeRotate = true;
                }

                if (CharacterDetails.LEyelidCheck)
                {
                    CharacterDetails.LEyelidX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyelidX));
                    CharacterDetails.LEyelidY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyelidY));
                    CharacterDetails.LEyelidZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyelidZ));
                    CharacterDetails.LEyelidW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyelidW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LEyelidX.value,
                        CharacterDetails.LEyelidY.value,
                        CharacterDetails.LEyelidZ.value,
                        CharacterDetails.LEyelidW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LEyelidCheck = false;
                    CharacterDetails.LEyelidRotate = true;
                }

                if (CharacterDetails.REyelidCheck)
                {
                    CharacterDetails.REyelidX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyelidX));
                    CharacterDetails.REyelidY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyelidY));
                    CharacterDetails.REyelidZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyelidZ));
                    CharacterDetails.REyelidW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyelidW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.REyelidX.value,
                        CharacterDetails.REyelidY.value,
                        CharacterDetails.REyelidZ.value,
                        CharacterDetails.REyelidW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.REyelidCheck = false;
                    CharacterDetails.REyelidRotate = true;
                }

                if (CharacterDetails.LLowEyelidCheck)
                {
                    CharacterDetails.LLowEyelidX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowEyelidX));
                    CharacterDetails.LLowEyelidY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowEyelidY));
                    CharacterDetails.LLowEyelidZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowEyelidZ));
                    CharacterDetails.LLowEyelidW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowEyelidW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LLowEyelidX.value,
                        CharacterDetails.LLowEyelidY.value,
                        CharacterDetails.LLowEyelidZ.value,
                        CharacterDetails.LLowEyelidW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LLowEyelidCheck = false;
                    CharacterDetails.LLowEyelidRotate = true;
                }

                if (CharacterDetails.RLowEyelidCheck)
                {
                    CharacterDetails.RLowEyelidX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowEyelidX));
                    CharacterDetails.RLowEyelidY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowEyelidY));
                    CharacterDetails.RLowEyelidZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowEyelidZ));
                    CharacterDetails.RLowEyelidW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowEyelidW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RLowEyelidX.value,
                        CharacterDetails.RLowEyelidY.value,
                        CharacterDetails.RLowEyelidZ.value,
                        CharacterDetails.RLowEyelidW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RLowEyelidCheck = false;
                    CharacterDetails.RLowEyelidRotate = true;
                }

                if (CharacterDetails.LEarCheck)
                {
                    CharacterDetails.LEarX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarX));
                    CharacterDetails.LEarY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarY));
                    CharacterDetails.LEarZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarZ));
                    CharacterDetails.LEarW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LEarX.value,
                        CharacterDetails.LEarY.value,
                        CharacterDetails.LEarZ.value,
                        CharacterDetails.LEarW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LEarCheck = false;
                    CharacterDetails.LEarRotate = true;
                }

                if (CharacterDetails.REarCheck)
                {
                    CharacterDetails.REarX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarX));
                    CharacterDetails.REarY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarY));
                    CharacterDetails.REarZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarZ));
                    CharacterDetails.REarW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.REarX.value,
                        CharacterDetails.REarY.value,
                        CharacterDetails.REarZ.value,
                        CharacterDetails.REarW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.REarCheck = false;
                    CharacterDetails.REarRotate = true;
                }

                if (CharacterDetails.LCheekCheck)
                {
                    CharacterDetails.LCheekX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCheekX));
                    CharacterDetails.LCheekY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCheekY));
                    CharacterDetails.LCheekZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCheekZ));
                    CharacterDetails.LCheekW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCheekW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LCheekX.value,
                        CharacterDetails.LCheekY.value,
                        CharacterDetails.LCheekZ.value,
                        CharacterDetails.LCheekW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LCheekCheck = false;
                    CharacterDetails.LCheekRotate = true;
                }

                if (CharacterDetails.RCheekCheck)
                {
                    CharacterDetails.RCheekX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCheekX));
                    CharacterDetails.RCheekY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCheekY));
                    CharacterDetails.RCheekZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCheekZ));
                    CharacterDetails.RCheekW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCheekW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RCheekX.value,
                        CharacterDetails.RCheekY.value,
                        CharacterDetails.RCheekZ.value,
                        CharacterDetails.RCheekW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RCheekCheck = false;
                    CharacterDetails.RCheekRotate = true;
                }

                if (CharacterDetails.LMouthCheck)
                {
                    CharacterDetails.LMouthX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMouthX));
                    CharacterDetails.LMouthY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMouthY));
                    CharacterDetails.LMouthZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMouthZ));
                    CharacterDetails.LMouthW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMouthW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LMouthX.value,
                        CharacterDetails.LMouthY.value,
                        CharacterDetails.LMouthZ.value,
                        CharacterDetails.LMouthW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LMouthCheck = false;
                    CharacterDetails.LMouthRotate = true;
                }

                if (CharacterDetails.RMouthCheck)
                {
                    CharacterDetails.RMouthX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMouthX));
                    CharacterDetails.RMouthY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMouthY));
                    CharacterDetails.RMouthZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMouthZ));
                    CharacterDetails.RMouthW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMouthW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RMouthX.value,
                        CharacterDetails.RMouthY.value,
                        CharacterDetails.RMouthZ.value,
                        CharacterDetails.RMouthW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RMouthCheck = false;
                    CharacterDetails.RMouthRotate = true;
                }

                if (CharacterDetails.LUpLipCheck)
                {
                    CharacterDetails.LUpLipX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LUpLipX));
                    CharacterDetails.LUpLipY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LUpLipY));
                    CharacterDetails.LUpLipZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LUpLipZ));
                    CharacterDetails.LUpLipW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LUpLipW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LUpLipX.value,
                        CharacterDetails.LUpLipY.value,
                        CharacterDetails.LUpLipZ.value,
                        CharacterDetails.LUpLipW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LUpLipCheck = false;
                    CharacterDetails.LUpLipRotate = true;
                }

                if (CharacterDetails.RUpLipCheck)
                {
                    CharacterDetails.RUpLipX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RUpLipX));
                    CharacterDetails.RUpLipY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RUpLipY));
                    CharacterDetails.RUpLipZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RUpLipZ));
                    CharacterDetails.RUpLipW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RUpLipW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RUpLipX.value,
                        CharacterDetails.RUpLipY.value,
                        CharacterDetails.RUpLipZ.value,
                        CharacterDetails.RUpLipW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RUpLipCheck = false;
                    CharacterDetails.RUpLipRotate = true;
                }

                if (CharacterDetails.LLowLipCheck)
                {
                    CharacterDetails.LLowLipX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowLipX));
                    CharacterDetails.LLowLipY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowLipY));
                    CharacterDetails.LLowLipZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowLipZ));
                    CharacterDetails.LLowLipW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowLipW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LLowLipX.value,
                        CharacterDetails.LLowLipY.value,
                        CharacterDetails.LLowLipZ.value,
                        CharacterDetails.LLowLipW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LLowLipCheck = false;
                    CharacterDetails.LLowLipRotate = true;
                }

                if (CharacterDetails.RLowLipCheck)
                {
                    CharacterDetails.RLowLipX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowLipX));
                    CharacterDetails.RLowLipY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowLipY));
                    CharacterDetails.RLowLipZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowLipZ));
                    CharacterDetails.RLowLipW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowLipW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RLowLipX.value,
                        CharacterDetails.RLowLipY.value,
                        CharacterDetails.RLowLipZ.value,
                        CharacterDetails.RLowLipW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RLowLipCheck = false;
                    CharacterDetails.RLowLipRotate = true;
                }

                if (CharacterDetails.NeckCheck)
                {
                    CharacterDetails.NeckX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NeckX));
                    CharacterDetails.NeckY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NeckY));
                    CharacterDetails.NeckZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NeckZ));
                    CharacterDetails.NeckW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NeckW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.NeckX.value,
                        CharacterDetails.NeckY.value,
                        CharacterDetails.NeckZ.value,
                        CharacterDetails.NeckW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.NeckCheck = false;
                    CharacterDetails.NeckRotate = true;
                }

                if (CharacterDetails.SternumCheck)
                {
                    CharacterDetails.SternumX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.SternumX));
                    CharacterDetails.SternumY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.SternumY));
                    CharacterDetails.SternumZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.SternumZ));
                    CharacterDetails.SternumW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.SternumW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.SternumX.value,
                        CharacterDetails.SternumY.value,
                        CharacterDetails.SternumZ.value,
                        CharacterDetails.SternumW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.SternumCheck = false;
                    CharacterDetails.SternumRotate = true;
                }

                if (CharacterDetails.TorsoCheck)
                {
                    CharacterDetails.TorsoX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TorsoX));
                    CharacterDetails.TorsoY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TorsoY));
                    CharacterDetails.TorsoZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TorsoZ));
                    CharacterDetails.TorsoW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TorsoW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TorsoX.value,
                        CharacterDetails.TorsoY.value,
                        CharacterDetails.TorsoZ.value,
                        CharacterDetails.TorsoW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TorsoCheck = false;
                    CharacterDetails.TorsoRotate = true;
                }

                if (CharacterDetails.WaistCheck)
                {
                    CharacterDetails.WaistX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.WaistX));
                    CharacterDetails.WaistY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.WaistY));
                    CharacterDetails.WaistZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.WaistZ));
                    CharacterDetails.WaistW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.WaistW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.WaistX.value,
                        CharacterDetails.WaistY.value,
                        CharacterDetails.WaistZ.value,
                        CharacterDetails.WaistW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.WaistCheck = false;
                    CharacterDetails.WaistRotate = true;
                }

                if (CharacterDetails.LShoulderCheck)
                {
                    CharacterDetails.LShoulderX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LShoulderX));
                    CharacterDetails.LShoulderY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LShoulderY));
                    CharacterDetails.LShoulderZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LShoulderZ));
                    CharacterDetails.LShoulderW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LShoulderW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LShoulderX.value,
                        CharacterDetails.LShoulderY.value,
                        CharacterDetails.LShoulderZ.value,
                        CharacterDetails.LShoulderW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LShoulderCheck = false;
                    CharacterDetails.LShoulderRotate = true;
                }

                if (CharacterDetails.RShoulderCheck)
                {
                    CharacterDetails.RShoulderX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RShoulderX));
                    CharacterDetails.RShoulderY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RShoulderY));
                    CharacterDetails.RShoulderZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RShoulderZ));
                    CharacterDetails.RShoulderW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RShoulderW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RShoulderX.value,
                        CharacterDetails.RShoulderY.value,
                        CharacterDetails.RShoulderZ.value,
                        CharacterDetails.RShoulderW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RShoulderCheck = false;
                    CharacterDetails.RShoulderRotate = true;
                }

                if (CharacterDetails.LClavicleCheck)
                {
                    CharacterDetails.LClavicleX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LClavicleX));
                    CharacterDetails.LClavicleY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LClavicleY));
                    CharacterDetails.LClavicleZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LClavicleZ));
                    CharacterDetails.LClavicleW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LClavicleW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LClavicleX.value,
                        CharacterDetails.LClavicleY.value,
                        CharacterDetails.LClavicleZ.value,
                        CharacterDetails.LClavicleW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LClavicleCheck = false;
                    CharacterDetails.LClavicleRotate = true;
                }

                if (CharacterDetails.RClavicleCheck)
                {
                    CharacterDetails.RClavicleX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RClavicleX));
                    CharacterDetails.RClavicleY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RClavicleY));
                    CharacterDetails.RClavicleZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RClavicleZ));
                    CharacterDetails.RClavicleW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RClavicleW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RClavicleX.value,
                        CharacterDetails.RClavicleY.value,
                        CharacterDetails.RClavicleZ.value,
                        CharacterDetails.RClavicleW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RClavicleCheck = false;
                    CharacterDetails.RClavicleRotate = true;
                }

                if (CharacterDetails.LBreastCheck)
                {
                    CharacterDetails.LBreastX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LBreastX));
                    CharacterDetails.LBreastY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LBreastY));
                    CharacterDetails.LBreastZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LBreastZ));
                    CharacterDetails.LBreastW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LBreastW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LBreastX.value,
                        CharacterDetails.LBreastY.value,
                        CharacterDetails.LBreastZ.value,
                        CharacterDetails.LBreastW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LBreastCheck = false;
                    CharacterDetails.LBreastRotate = true;
                }

                if (CharacterDetails.RBreastCheck)
                {
                    CharacterDetails.RBreastX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RBreastX));
                    CharacterDetails.RBreastY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RBreastY));
                    CharacterDetails.RBreastZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RBreastZ));
                    CharacterDetails.RBreastW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RBreastW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RBreastX.value,
                        CharacterDetails.RBreastY.value,
                        CharacterDetails.RBreastZ.value,
                        CharacterDetails.RBreastW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RBreastCheck = false;
                    CharacterDetails.RBreastRotate = true;
                }

                if (CharacterDetails.LArmCheck)
                {
                    CharacterDetails.LArmX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LArmX));
                    CharacterDetails.LArmY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LArmY));
                    CharacterDetails.LArmZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LArmZ));
                    CharacterDetails.LArmW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LArmW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LArmX.value,
                        CharacterDetails.LArmY.value,
                        CharacterDetails.LArmZ.value,
                        CharacterDetails.LArmW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LArmCheck = false;
                    CharacterDetails.LArmRotate = true;
                }

                if (CharacterDetails.RArmCheck)
                {
                    CharacterDetails.RArmX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RArmX));
                    CharacterDetails.RArmY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RArmY));
                    CharacterDetails.RArmZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RArmZ));
                    CharacterDetails.RArmW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RArmW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RArmX.value,
                        CharacterDetails.RArmY.value,
                        CharacterDetails.RArmZ.value,
                        CharacterDetails.RArmW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RArmCheck = false;
                    CharacterDetails.RArmRotate = true;
                }

                if (CharacterDetails.LElbowCheck)
                {
                    CharacterDetails.LElbowX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LElbowX));
                    CharacterDetails.LElbowY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LElbowY));
                    CharacterDetails.LElbowZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LElbowZ));
                    CharacterDetails.LElbowW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LElbowW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LElbowX.value,
                        CharacterDetails.LElbowY.value,
                        CharacterDetails.LElbowZ.value,
                        CharacterDetails.LElbowW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LElbowCheck = false;
                    CharacterDetails.LElbowRotate = true;
                }

                if (CharacterDetails.RElbowCheck)
                {
                    CharacterDetails.RElbowX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RElbowX));
                    CharacterDetails.RElbowY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RElbowY));
                    CharacterDetails.RElbowZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RElbowZ));
                    CharacterDetails.RElbowW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RElbowW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RElbowX.value,
                        CharacterDetails.RElbowY.value,
                        CharacterDetails.RElbowZ.value,
                        CharacterDetails.RElbowW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RElbowCheck = false;
                    CharacterDetails.RElbowRotate = true;
                }

                if (CharacterDetails.LForearmCheck)
                {
                    CharacterDetails.LForearmX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LForearmX));
                    CharacterDetails.LForearmY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LForearmY));
                    CharacterDetails.LForearmZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LForearmZ));
                    CharacterDetails.LForearmW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LForearmW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LForearmX.value,
                        CharacterDetails.LForearmY.value,
                        CharacterDetails.LForearmZ.value,
                        CharacterDetails.LForearmW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LForearmCheck = false;
                    CharacterDetails.LForearmRotate = true;
                }

                if (CharacterDetails.RForearmCheck)
                {
                    CharacterDetails.RForearmX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RForearmX));
                    CharacterDetails.RForearmY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RForearmY));
                    CharacterDetails.RForearmZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RForearmZ));
                    CharacterDetails.RForearmW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RForearmW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RForearmX.value,
                        CharacterDetails.RForearmY.value,
                        CharacterDetails.RForearmZ.value,
                        CharacterDetails.RForearmW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RForearmCheck = false;
                    CharacterDetails.RForearmRotate = true;
                }

                if (CharacterDetails.LWristCheck)
                {
                    CharacterDetails.LWristX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LWristX));
                    CharacterDetails.LWristY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LWristY));
                    CharacterDetails.LWristZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LWristZ));
                    CharacterDetails.LWristW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LWristW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LWristX.value,
                        CharacterDetails.LWristY.value,
                        CharacterDetails.LWristZ.value,
                        CharacterDetails.LWristW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LWristCheck = false;
                    CharacterDetails.LWristRotate = true;
                }

                if (CharacterDetails.RWristCheck)
                {
                    CharacterDetails.RWristX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RWristX));
                    CharacterDetails.RWristY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RWristY));
                    CharacterDetails.RWristZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RWristZ));
                    CharacterDetails.RWristW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RWristW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RWristX.value,
                        CharacterDetails.RWristY.value,
                        CharacterDetails.RWristZ.value,
                        CharacterDetails.RWristW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RWristCheck = false;
                    CharacterDetails.RWristRotate = true;
                }

                if (CharacterDetails.LHandCheck)
                {
                    CharacterDetails.LHandX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LHandX));
                    CharacterDetails.LHandY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LHandY));
                    CharacterDetails.LHandZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LHandZ));
                    CharacterDetails.LHandW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LHandW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LHandX.value,
                        CharacterDetails.LHandY.value,
                        CharacterDetails.LHandZ.value,
                        CharacterDetails.LHandW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LHandCheck = false;
                    CharacterDetails.LHandRotate = true;
                }

                if (CharacterDetails.RHandCheck)
                {
                    CharacterDetails.RHandX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RHandX));
                    CharacterDetails.RHandY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RHandY));
                    CharacterDetails.RHandZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RHandZ));
                    CharacterDetails.RHandW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RHandW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RHandX.value,
                        CharacterDetails.RHandY.value,
                        CharacterDetails.RHandZ.value,
                        CharacterDetails.RHandW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RHandCheck = false;
                    CharacterDetails.RHandRotate = true;
                }

                if (CharacterDetails.LThumbCheck)
                {
                    CharacterDetails.LThumbX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumbX));
                    CharacterDetails.LThumbY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumbY));
                    CharacterDetails.LThumbZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumbZ));
                    CharacterDetails.LThumbW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumbW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LThumbX.value,
                        CharacterDetails.LThumbY.value,
                        CharacterDetails.LThumbZ.value,
                        CharacterDetails.LThumbW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LThumbCheck = false;
                    CharacterDetails.LThumbRotate = true;
                }

                if (CharacterDetails.RThumbCheck)
                {
                    CharacterDetails.RThumbX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumbX));
                    CharacterDetails.RThumbY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumbY));
                    CharacterDetails.RThumbZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumbZ));
                    CharacterDetails.RThumbW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumbW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RThumbX.value,
                        CharacterDetails.RThumbY.value,
                        CharacterDetails.RThumbZ.value,
                        CharacterDetails.RThumbW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RThumbCheck = false;
                    CharacterDetails.RThumbRotate = true;
                }

                if (CharacterDetails.LThumb2Check)
                {
                    CharacterDetails.LThumb2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumb2X));
                    CharacterDetails.LThumb2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumb2Y));
                    CharacterDetails.LThumb2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumb2Z));
                    CharacterDetails.LThumb2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumb2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LThumb2X.value,
                        CharacterDetails.LThumb2Y.value,
                        CharacterDetails.LThumb2Z.value,
                        CharacterDetails.LThumb2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LThumb2Check = false;
                    CharacterDetails.LThumb2Rotate = true;
                }

                if (CharacterDetails.RThumb2Check)
                {
                    CharacterDetails.RThumb2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumb2X));
                    CharacterDetails.RThumb2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumb2Y));
                    CharacterDetails.RThumb2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumb2Z));
                    CharacterDetails.RThumb2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumb2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RThumb2X.value,
                        CharacterDetails.RThumb2Y.value,
                        CharacterDetails.RThumb2Z.value,
                        CharacterDetails.RThumb2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RThumb2Check = false;
                    CharacterDetails.RThumb2Rotate = true;
                }

                if (CharacterDetails.LIndexCheck)
                {
                    CharacterDetails.LIndexX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndexX));
                    CharacterDetails.LIndexY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndexY));
                    CharacterDetails.LIndexZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndexZ));
                    CharacterDetails.LIndexW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndexW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LIndexX.value,
                        CharacterDetails.LIndexY.value,
                        CharacterDetails.LIndexZ.value,
                        CharacterDetails.LIndexW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LIndexCheck = false;
                    CharacterDetails.LIndexRotate = true;
                }

                if (CharacterDetails.RIndexCheck)
                {
                    CharacterDetails.RIndexX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndexX));
                    CharacterDetails.RIndexY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndexY));
                    CharacterDetails.RIndexZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndexZ));
                    CharacterDetails.RIndexW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndexW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RIndexX.value,
                        CharacterDetails.RIndexY.value,
                        CharacterDetails.RIndexZ.value,
                        CharacterDetails.RIndexW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RIndexCheck = false;
                    CharacterDetails.RIndexRotate = true;
                }

                if (CharacterDetails.LIndex2Check)
                {
                    CharacterDetails.LIndex2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndex2X));
                    CharacterDetails.LIndex2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndex2Y));
                    CharacterDetails.LIndex2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndex2Z));
                    CharacterDetails.LIndex2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndex2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LIndex2X.value,
                        CharacterDetails.LIndex2Y.value,
                        CharacterDetails.LIndex2Z.value,
                        CharacterDetails.LIndex2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LIndex2Check = false;
                    CharacterDetails.LIndex2Rotate = true;
                }

                if (CharacterDetails.RIndex2Check)
                {
                    CharacterDetails.RIndex2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndex2X));
                    CharacterDetails.RIndex2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndex2Y));
                    CharacterDetails.RIndex2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndex2Z));
                    CharacterDetails.RIndex2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndex2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RIndex2X.value,
                        CharacterDetails.RIndex2Y.value,
                        CharacterDetails.RIndex2Z.value,
                        CharacterDetails.RIndex2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RIndex2Check = false;
                    CharacterDetails.RIndex2Rotate = true;
                }

                if (CharacterDetails.LMiddleCheck)
                {
                    CharacterDetails.LMiddleX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddleX));
                    CharacterDetails.LMiddleY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddleY));
                    CharacterDetails.LMiddleZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddleZ));
                    CharacterDetails.LMiddleW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddleW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LMiddleX.value,
                        CharacterDetails.LMiddleY.value,
                        CharacterDetails.LMiddleZ.value,
                        CharacterDetails.LMiddleW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LMiddleCheck = false;
                    CharacterDetails.LMiddleRotate = true;
                }

                if (CharacterDetails.RMiddleCheck)
                {
                    CharacterDetails.RMiddleX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddleX));
                    CharacterDetails.RMiddleY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddleY));
                    CharacterDetails.RMiddleZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddleZ));
                    CharacterDetails.RMiddleW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddleW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RMiddleX.value,
                        CharacterDetails.RMiddleY.value,
                        CharacterDetails.RMiddleZ.value,
                        CharacterDetails.RMiddleW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RMiddleCheck = false;
                    CharacterDetails.RMiddleRotate = true;
                }

                if (CharacterDetails.LMiddle2Check)
                {
                    CharacterDetails.LMiddle2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddle2X));
                    CharacterDetails.LMiddle2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddle2Y));
                    CharacterDetails.LMiddle2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddle2Z));
                    CharacterDetails.LMiddle2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddle2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LMiddle2X.value,
                        CharacterDetails.LMiddle2Y.value,
                        CharacterDetails.LMiddle2Z.value,
                        CharacterDetails.LMiddle2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LMiddle2Check = false;
                    CharacterDetails.LMiddle2Rotate = true;
                }

                if (CharacterDetails.RMiddle2Check)
                {
                    CharacterDetails.RMiddle2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddle2X));
                    CharacterDetails.RMiddle2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddle2Y));
                    CharacterDetails.RMiddle2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddle2Z));
                    CharacterDetails.RMiddle2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddle2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RMiddle2X.value,
                        CharacterDetails.RMiddle2Y.value,
                        CharacterDetails.RMiddle2Z.value,
                        CharacterDetails.RMiddle2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RMiddle2Check = false;
                    CharacterDetails.RMiddle2Rotate = true;
                }

                if (CharacterDetails.LRingCheck)
                {
                    CharacterDetails.LRingX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRingX));
                    CharacterDetails.LRingY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRingY));
                    CharacterDetails.LRingZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRingZ));
                    CharacterDetails.LRingW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRingW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LRingX.value,
                        CharacterDetails.LRingY.value,
                        CharacterDetails.LRingZ.value,
                        CharacterDetails.LRingW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LRingCheck = false;
                    CharacterDetails.LRingRotate = true;
                }

                if (CharacterDetails.RRingCheck)
                {
                    CharacterDetails.RRingX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRingX));
                    CharacterDetails.RRingY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRingY));
                    CharacterDetails.RRingZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRingZ));
                    CharacterDetails.RRingW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRingW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RRingX.value,
                        CharacterDetails.RRingY.value,
                        CharacterDetails.RRingZ.value,
                        CharacterDetails.RRingW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RRingCheck = false;
                    CharacterDetails.RRingRotate = true;
                }

                if (CharacterDetails.LRing2Check)
                {
                    CharacterDetails.LRing2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRing2X));
                    CharacterDetails.LRing2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRing2Y));
                    CharacterDetails.LRing2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRing2Z));
                    CharacterDetails.LRing2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRing2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LRing2X.value,
                        CharacterDetails.LRing2Y.value,
                        CharacterDetails.LRing2Z.value,
                        CharacterDetails.LRing2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LRing2Check = false;
                    CharacterDetails.LRing2Rotate = true;
                }

                if (CharacterDetails.RRing2Check)
                {
                    CharacterDetails.RRing2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRing2X));
                    CharacterDetails.RRing2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRing2Y));
                    CharacterDetails.RRing2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRing2Z));
                    CharacterDetails.RRing2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRing2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RRing2X.value,
                        CharacterDetails.RRing2Y.value,
                        CharacterDetails.RRing2Z.value,
                        CharacterDetails.RRing2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RRing2Check = false;
                    CharacterDetails.RRing2Rotate = true;
                }

                if (CharacterDetails.LPinkyCheck)
                {
                    CharacterDetails.LPinkyX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinkyX));
                    CharacterDetails.LPinkyY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinkyY));
                    CharacterDetails.LPinkyZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinkyZ));
                    CharacterDetails.LPinkyW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinkyW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LPinkyX.value,
                        CharacterDetails.LPinkyY.value,
                        CharacterDetails.LPinkyZ.value,
                        CharacterDetails.LPinkyW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LPinkyCheck = false;
                    CharacterDetails.LPinkyRotate = true;
                }

                if (CharacterDetails.RPinkyCheck)
                {
                    CharacterDetails.RPinkyX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinkyX));
                    CharacterDetails.RPinkyY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinkyY));
                    CharacterDetails.RPinkyZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinkyZ));
                    CharacterDetails.RPinkyW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinkyW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RPinkyX.value,
                        CharacterDetails.RPinkyY.value,
                        CharacterDetails.RPinkyZ.value,
                        CharacterDetails.RPinkyW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RPinkyCheck = false;
                    CharacterDetails.RPinkyRotate = true;
                }

                if (CharacterDetails.LPinky2Check)
                {
                    CharacterDetails.LPinky2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinky2X));
                    CharacterDetails.LPinky2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinky2Y));
                    CharacterDetails.LPinky2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinky2Z));
                    CharacterDetails.LPinky2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinky2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LPinky2X.value,
                        CharacterDetails.LPinky2Y.value,
                        CharacterDetails.LPinky2Z.value,
                        CharacterDetails.LPinky2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LPinky2Check = false;
                    CharacterDetails.LPinky2Rotate = true;
                }

                if (CharacterDetails.RPinky2Check)
                {
                    CharacterDetails.RPinky2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinky2X));
                    CharacterDetails.RPinky2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinky2Y));
                    CharacterDetails.RPinky2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinky2Z));
                    CharacterDetails.RPinky2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinky2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RPinky2X.value,
                        CharacterDetails.RPinky2Y.value,
                        CharacterDetails.RPinky2Z.value,
                        CharacterDetails.RPinky2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RPinky2Check = false;
                    CharacterDetails.RPinky2Rotate = true;
                }

                if (CharacterDetails.PelvisCheck)
                {
                    CharacterDetails.PelvisX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.PelvisX));
                    CharacterDetails.PelvisY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.PelvisY));
                    CharacterDetails.PelvisZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.PelvisZ));
                    CharacterDetails.PelvisW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.PelvisW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.PelvisX.value,
                        CharacterDetails.PelvisY.value,
                        CharacterDetails.PelvisZ.value,
                        CharacterDetails.PelvisW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.PelvisCheck = false;
                    CharacterDetails.PelvisRotate = true;
                }

                if (CharacterDetails.TailCheck)
                {
                    CharacterDetails.TailX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TailX));
                    CharacterDetails.TailY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TailY));
                    CharacterDetails.TailZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TailZ));
                    CharacterDetails.TailW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TailW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.TailX.value,
                        CharacterDetails.TailY.value,
                        CharacterDetails.TailZ.value,
                        CharacterDetails.TailW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.TailCheck = false;
                    CharacterDetails.TailRotate = true;
                }

                if (CharacterDetails.Tail2Check)
                {
                    CharacterDetails.Tail2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail2X));
                    CharacterDetails.Tail2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail2Y));
                    CharacterDetails.Tail2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail2Z));
                    CharacterDetails.Tail2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Tail2X.value,
                        CharacterDetails.Tail2Y.value,
                        CharacterDetails.Tail2Z.value,
                        CharacterDetails.Tail2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Tail2Check = false;
                    CharacterDetails.Tail2Rotate = true;
                }

                if (CharacterDetails.Tail3Check)
                {
                    CharacterDetails.Tail3X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail3X));
                    CharacterDetails.Tail3Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail3Y));
                    CharacterDetails.Tail3Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail3Z));
                    CharacterDetails.Tail3W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail3W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Tail3X.value,
                        CharacterDetails.Tail3Y.value,
                        CharacterDetails.Tail3Z.value,
                        CharacterDetails.Tail3W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Tail3Check = false;
                    CharacterDetails.Tail3Rotate = true;
                }

                if (CharacterDetails.Tail4Check)
                {
                    CharacterDetails.Tail4X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail4X));
                    CharacterDetails.Tail4Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail4Y));
                    CharacterDetails.Tail4Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail4Z));
                    CharacterDetails.Tail4W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail4W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Tail4X.value,
                        CharacterDetails.Tail4Y.value,
                        CharacterDetails.Tail4Z.value,
                        CharacterDetails.Tail4W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Tail4Check = false;
                    CharacterDetails.Tail4Rotate = true;
                }

                if (CharacterDetails.Tail5Check)
                {
                    CharacterDetails.Tail5X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail5X));
                    CharacterDetails.Tail5Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail5Y));
                    CharacterDetails.Tail5Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail5Z));
                    CharacterDetails.Tail5W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail5W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.Tail5X.value,
                        CharacterDetails.Tail5Y.value,
                        CharacterDetails.Tail5Z.value,
                        CharacterDetails.Tail5W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.Tail5Check = false;
                    CharacterDetails.Tail5Rotate = true;
                }

                if (CharacterDetails.LThighCheck)
                {
                    CharacterDetails.LThighX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThighX));
                    CharacterDetails.LThighY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThighY));
                    CharacterDetails.LThighZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThighZ));
                    CharacterDetails.LThighW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThighW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LThighX.value,
                        CharacterDetails.LThighY.value,
                        CharacterDetails.LThighZ.value,
                        CharacterDetails.LThighW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LThighCheck = false;
                    CharacterDetails.LThighRotate = true;
                }

                if (CharacterDetails.RThighCheck)
                {
                    CharacterDetails.RThighX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThighX));
                    CharacterDetails.RThighY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThighY));
                    CharacterDetails.RThighZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThighZ));
                    CharacterDetails.RThighW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThighW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RThighX.value,
                        CharacterDetails.RThighY.value,
                        CharacterDetails.RThighZ.value,
                        CharacterDetails.RThighW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RThighCheck = false;
                    CharacterDetails.RThighRotate = true;
                }

                if (CharacterDetails.LKneeCheck)
                {
                    CharacterDetails.LKneeX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LKneeX));
                    CharacterDetails.LKneeY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LKneeY));
                    CharacterDetails.LKneeZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LKneeZ));
                    CharacterDetails.LKneeW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LKneeW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LKneeX.value,
                        CharacterDetails.LKneeY.value,
                        CharacterDetails.LKneeZ.value,
                        CharacterDetails.LKneeW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LKneeCheck = false;
                    CharacterDetails.LKneeRotate = true;
                }

                if (CharacterDetails.RKneeCheck)
                {
                    CharacterDetails.RKneeX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RKneeX));
                    CharacterDetails.RKneeY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RKneeY));
                    CharacterDetails.RKneeZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RKneeZ));
                    CharacterDetails.RKneeW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RKneeW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RKneeX.value,
                        CharacterDetails.RKneeY.value,
                        CharacterDetails.RKneeZ.value,
                        CharacterDetails.RKneeW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RKneeCheck = false;
                    CharacterDetails.RKneeRotate = true;
                }

                if (CharacterDetails.LCalfCheck)
                {
                    CharacterDetails.LCalfX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCalfX));
                    CharacterDetails.LCalfY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCalfY));
                    CharacterDetails.LCalfZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCalfZ));
                    CharacterDetails.LCalfW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCalfW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LCalfX.value,
                        CharacterDetails.LCalfY.value,
                        CharacterDetails.LCalfZ.value,
                        CharacterDetails.LCalfW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LCalfCheck = false;
                    CharacterDetails.LCalfRotate = true;
                }

                if (CharacterDetails.RCalfCheck)
                {
                    CharacterDetails.RCalfX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCalfX));
                    CharacterDetails.RCalfY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCalfY));
                    CharacterDetails.RCalfZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCalfZ));
                    CharacterDetails.RCalfW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCalfW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RCalfX.value,
                        CharacterDetails.RCalfY.value,
                        CharacterDetails.RCalfZ.value,
                        CharacterDetails.RCalfW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RCalfCheck = false;
                    CharacterDetails.RCalfRotate = true;
                }

                if (CharacterDetails.LFootCheck)
                {
                    CharacterDetails.LFootX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LFootX));
                    CharacterDetails.LFootY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LFootY));
                    CharacterDetails.LFootZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LFootZ));
                    CharacterDetails.LFootW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LFootW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LFootX.value,
                        CharacterDetails.LFootY.value,
                        CharacterDetails.LFootZ.value,
                        CharacterDetails.LFootW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LFootCheck = false;
                    CharacterDetails.LFootRotate = true;
                }

                if (CharacterDetails.RFootCheck)
                {
                    CharacterDetails.RFootX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RFootX));
                    CharacterDetails.RFootY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RFootY));
                    CharacterDetails.RFootZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RFootZ));
                    CharacterDetails.RFootW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RFootW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RFootX.value,
                        CharacterDetails.RFootY.value,
                        CharacterDetails.RFootZ.value,
                        CharacterDetails.RFootW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RFootCheck = false;
                    CharacterDetails.RFootRotate = true;
                }

                if (CharacterDetails.LToesCheck)
                {
                    CharacterDetails.LToesX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LToesX));
                    CharacterDetails.LToesY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LToesY));
                    CharacterDetails.LToesZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LToesZ));
                    CharacterDetails.LToesW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LToesW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LToesX.value,
                        CharacterDetails.LToesY.value,
                        CharacterDetails.LToesZ.value,
                        CharacterDetails.LToesW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LToesCheck = false;
                    CharacterDetails.LToesRotate = true;
                }

                if (CharacterDetails.RToesCheck)
                {
                    CharacterDetails.RToesX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RToesX));
                    CharacterDetails.RToesY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RToesY));
                    CharacterDetails.RToesZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RToesZ));
                    CharacterDetails.RToesW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RToesW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RToesX.value,
                        CharacterDetails.RToesY.value,
                        CharacterDetails.RToesZ.value,
                        CharacterDetails.RToesW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RToesCheck = false;
                    CharacterDetails.RToesRotate = true;
                }

                if (CharacterDetails.LVEarCheck)
                {
                    CharacterDetails.LVEarX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEarX));
                    CharacterDetails.LVEarY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEarY));
                    CharacterDetails.LVEarZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEarZ));
                    CharacterDetails.LVEarW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEarW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LVEarX.value,
                        CharacterDetails.LVEarY.value,
                        CharacterDetails.LVEarZ.value,
                        CharacterDetails.LVEarW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LVEarCheck = false;
                    CharacterDetails.LVEarRotate = true;
                }

                if (CharacterDetails.RVEarCheck)
                {
                    CharacterDetails.RVEarX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEarX));
                    CharacterDetails.RVEarY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEarY));
                    CharacterDetails.RVEarZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEarZ));
                    CharacterDetails.RVEarW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEarW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVEarX.value,
                        CharacterDetails.RVEarY.value,
                        CharacterDetails.RVEarZ.value,
                        CharacterDetails.RVEarW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVEarCheck = false;
                    CharacterDetails.RVEarRotate = true;
                }

                if (CharacterDetails.LVEar2Check)
                {
                    CharacterDetails.LVEar2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar2X));
                    CharacterDetails.LVEar2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar2Y));
                    CharacterDetails.LVEar2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar2Z));
                    CharacterDetails.LVEar2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LVEar2X.value,
                        CharacterDetails.LVEar2Y.value,
                        CharacterDetails.LVEar2Z.value,
                        CharacterDetails.LVEar2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LVEar2Check = false;
                    CharacterDetails.LVEar2Rotate = true;
                }

                if (CharacterDetails.RVEar2Check)
                {
                    CharacterDetails.RVEar2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar2X));
                    CharacterDetails.RVEar2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar2Y));
                    CharacterDetails.RVEar2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar2Z));
                    CharacterDetails.RVEar2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVEar2X.value,
                        CharacterDetails.RVEar2Y.value,
                        CharacterDetails.RVEar2Z.value,
                        CharacterDetails.RVEar2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVEar2Check = false;
                    CharacterDetails.RVEar2Rotate = true;
                }

                if (CharacterDetails.LVEar3Check)
                {
                    CharacterDetails.LVEar3X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar3X));
                    CharacterDetails.LVEar3Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar3Y));
                    CharacterDetails.LVEar3Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar3Z));
                    CharacterDetails.LVEar3W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar3W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LVEar3X.value,
                        CharacterDetails.LVEar3Y.value,
                        CharacterDetails.LVEar3Z.value,
                        CharacterDetails.LVEar3W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LVEar3Check = false;
                    CharacterDetails.LVEar3Rotate = true;
                }

                if (CharacterDetails.RVEar3Check)
                {
                    CharacterDetails.RVEar3X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar3X));
                    CharacterDetails.RVEar3Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar3Y));
                    CharacterDetails.RVEar3Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar3Z));
                    CharacterDetails.RVEar3W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar3W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVEar3X.value,
                        CharacterDetails.RVEar3Y.value,
                        CharacterDetails.RVEar3Z.value,
                        CharacterDetails.RVEar3W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVEar3Check = false;
                    CharacterDetails.RVEar3Rotate = true;
                }

                if (CharacterDetails.LVEar4Check)
                {
                    CharacterDetails.LVEar4X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar4X));
                    CharacterDetails.LVEar4Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar4Y));
                    CharacterDetails.LVEar4Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar4Z));
                    CharacterDetails.LVEar4W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar4W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LVEar4X.value,
                        CharacterDetails.LVEar4Y.value,
                        CharacterDetails.LVEar4Z.value,
                        CharacterDetails.LVEar4W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LVEar4Check = false;
                    CharacterDetails.LVEar4Rotate = true;
                }

                if (CharacterDetails.RVEar4Check)
                {
                    CharacterDetails.RVEar4X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar4X));
                    CharacterDetails.RVEar4Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar4Y));
                    CharacterDetails.RVEar4Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar4Z));
                    CharacterDetails.RVEar4W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar4W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVEar4X.value,
                        CharacterDetails.RVEar4Y.value,
                        CharacterDetails.RVEar4Z.value,
                        CharacterDetails.RVEar4W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVEar4Check = false;
                    CharacterDetails.RVEar4Rotate = true;
                }

                if (CharacterDetails.DebugCheck)
                {
                    CharacterDetails.DebugX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.DebugX));
                    CharacterDetails.DebugY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.DebugY));
                    CharacterDetails.DebugZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.DebugZ));
                    CharacterDetails.DebugW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.DebugW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.DebugX.value,
                        CharacterDetails.DebugY.value,
                        CharacterDetails.DebugZ.value,
                        CharacterDetails.DebugW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.DebugCheck = false;
                    CharacterDetails.DebugRotate = true;
                }

                if (CharacterDetails.LEarringCheck)
                {
                    CharacterDetails.LEarringX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarringX));
                    CharacterDetails.LEarringY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarringY));
                    CharacterDetails.LEarringZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarringZ));
                    CharacterDetails.LEarringW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarringW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LEarringX.value,
                        CharacterDetails.LEarringY.value,
                        CharacterDetails.LEarringZ.value,
                        CharacterDetails.LEarringW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LEarringCheck = false;
                    CharacterDetails.LEarringRotate = true;
                }

                if (CharacterDetails.REarringCheck)
                {
                    CharacterDetails.REarringX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarringX));
                    CharacterDetails.REarringY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarringY));
                    CharacterDetails.REarringZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarringZ));
                    CharacterDetails.REarringW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarringW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.REarringX.value,
                        CharacterDetails.REarringY.value,
                        CharacterDetails.REarringZ.value,
                        CharacterDetails.REarringW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.REarringCheck = false;
                    CharacterDetails.REarringRotate = true;
                }

                if (CharacterDetails.LEarring2Check)
                {
                    CharacterDetails.LEarring2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarring2X));
                    CharacterDetails.LEarring2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarring2Y));
                    CharacterDetails.LEarring2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarring2Z));
                    CharacterDetails.LEarring2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarring2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LEarring2X.value,
                        CharacterDetails.LEarring2Y.value,
                        CharacterDetails.LEarring2Z.value,
                        CharacterDetails.LEarring2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LEarring2Check = false;
                    CharacterDetails.LEarring2Rotate = true;
                }

                if (CharacterDetails.REarring2Check)
                {
                    CharacterDetails.REarring2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarring2X));
                    CharacterDetails.REarring2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarring2Y));
                    CharacterDetails.REarring2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarring2Z));
                    CharacterDetails.REarring2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarring2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.REarring2X.value,
                        CharacterDetails.REarring2Y.value,
                        CharacterDetails.REarring2Z.value,
                        CharacterDetails.REarring2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.REarring2Check = false;
                    CharacterDetails.REarring2Rotate = true;
                }

                if (CharacterDetails.LVLowLipCheck)
                {
                    CharacterDetails.LVLowLipX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowLipX));
                    CharacterDetails.LVLowLipY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowLipY));
                    CharacterDetails.LVLowLipZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowLipZ));
                    CharacterDetails.LVLowLipW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowLipW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LVLowLipX.value,
                        CharacterDetails.LVLowLipY.value,
                        CharacterDetails.LVLowLipZ.value,
                        CharacterDetails.LVLowLipW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LVLowLipCheck = false;
                    CharacterDetails.LVLowLipRotate = true;
                }

                if (CharacterDetails.RVUpLipCheck)
                {
                    CharacterDetails.RVUpLipX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVUpLipX));
                    CharacterDetails.RVUpLipY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVUpLipY));
                    CharacterDetails.RVUpLipZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVUpLipZ));
                    CharacterDetails.RVUpLipW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVUpLipW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVUpLipX.value,
                        CharacterDetails.RVUpLipY.value,
                        CharacterDetails.RVUpLipZ.value,
                        CharacterDetails.RVUpLipW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVUpLipCheck = false;
                    CharacterDetails.RVUpLipRotate = true;
                }

                if (CharacterDetails.RVLowLipCheck)
                {
                    CharacterDetails.RVLowLipX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowLipX));
                    CharacterDetails.RVLowLipY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowLipY));
                    CharacterDetails.RVLowLipZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowLipZ));
                    CharacterDetails.RVLowLipW.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowLipW));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVLowLipX.value,
                        CharacterDetails.RVLowLipY.value,
                        CharacterDetails.RVLowLipZ.value,
                        CharacterDetails.RVLowLipW.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVLowLipCheck = false;
                    CharacterDetails.RVLowLipRotate = true;
                }

                if (CharacterDetails.RVLowEar2Check)
                {
                    CharacterDetails.RVLowEar2X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar2X));
                    CharacterDetails.RVLowEar2Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar2Y));
                    CharacterDetails.RVLowEar2Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar2Z));
                    CharacterDetails.RVLowEar2W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar2W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVLowEar2X.value,
                        CharacterDetails.RVLowEar2Y.value,
                        CharacterDetails.RVLowEar2Z.value,
                        CharacterDetails.RVLowEar2W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVLowEar2Check = false;
                    CharacterDetails.RVLowEar2Rotate = true;
                }

                if (CharacterDetails.LVLowEar3Check)
                {
                    CharacterDetails.LVLowEar3X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar3X));
                    CharacterDetails.LVLowEar3Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar3Y));
                    CharacterDetails.LVLowEar3Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar3Z));
                    CharacterDetails.LVLowEar3W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar3W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LVLowEar3X.value,
                        CharacterDetails.LVLowEar3Y.value,
                        CharacterDetails.LVLowEar3Z.value,
                        CharacterDetails.LVLowEar3W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LVLowEar3Check = false;
                    CharacterDetails.LVLowEar3Rotate = true;
                }

                if (CharacterDetails.RVLowEar3Check)
                {
                    CharacterDetails.RVLowEar3X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar3X));
                    CharacterDetails.RVLowEar3Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar3Y));
                    CharacterDetails.RVLowEar3Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar3Z));
                    CharacterDetails.RVLowEar3W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar3W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVLowEar3X.value,
                        CharacterDetails.RVLowEar3Y.value,
                        CharacterDetails.RVLowEar3Z.value,
                        CharacterDetails.RVLowEar3W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVLowEar3Check = false;
                    CharacterDetails.RVLowEar3Rotate = true;
                }

                if (CharacterDetails.LVLowEar4Check)
                {
                    CharacterDetails.LVLowEar4X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar4X));
                    CharacterDetails.LVLowEar4Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar4Y));
                    CharacterDetails.LVLowEar4Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar4Z));
                    CharacterDetails.LVLowEar4W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar4W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.LVLowEar4X.value,
                        CharacterDetails.LVLowEar4Y.value,
                        CharacterDetails.LVLowEar4Z.value,
                        CharacterDetails.LVLowEar4W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.LVLowEar4Check = false;
                    CharacterDetails.LVLowEar4Rotate = true;
                }

                if (CharacterDetails.RVLowEar4Check)
                {
                    CharacterDetails.RVLowEar4X.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar4X));
                    CharacterDetails.RVLowEar4Y.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar4Y));
                    CharacterDetails.RVLowEar4Z.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar4Z));
                    CharacterDetails.RVLowEar4W.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar4W));

                    // Create euler angles from the quaternion.
                    var euler = new System.Windows.Media.Media3D.Quaternion(
                        CharacterDetails.RVLowEar4X.value,
                        CharacterDetails.RVLowEar4Y.value,
                        CharacterDetails.RVLowEar4Z.value,
                        CharacterDetails.RVLowEar4W.value
                    ).ToEulerAngles();

                    CharacterDetails.BoneX = (float)euler.X;
                    CharacterDetails.BoneY = (float)euler.Y;
                    CharacterDetails.BoneZ = (float)euler.Z;

                    CharacterDetails.RVLowEar4Check = false;
                    CharacterDetails.RVLowEar4Rotate = true;
                }
                #endregion

                #region Saving Skeletal Rotations
                if (CharacterDetails.SaveHeadBones)
                {
                    MainViewModel.ViewTime5.HeadXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.HeadX));
                    MainViewModel.ViewTime5.HeadYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.HeadY));
                    MainViewModel.ViewTime5.HeadZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.HeadZ));
                    MainViewModel.ViewTime5.HeadWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.HeadW));

                    MainViewModel.ViewTime5.NoseXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NoseX));
                    MainViewModel.ViewTime5.NoseYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NoseY));
                    MainViewModel.ViewTime5.NoseZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NoseZ));
                    MainViewModel.ViewTime5.NoseWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NoseW));

                    MainViewModel.ViewTime5.NostrilsXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NostrilsX));
                    MainViewModel.ViewTime5.NostrilsYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NostrilsY));
                    MainViewModel.ViewTime5.NostrilsZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NostrilsZ));
                    MainViewModel.ViewTime5.NostrilsWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NostrilsW));

                    MainViewModel.ViewTime5.ChinXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ChinX));
                    MainViewModel.ViewTime5.ChinYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ChinY));
                    MainViewModel.ViewTime5.ChinZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ChinZ));
                    MainViewModel.ViewTime5.ChinWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ChinW));

                    MainViewModel.ViewTime5.LOutEyebrowXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LOutEyebrowX));
                    MainViewModel.ViewTime5.LOutEyebrowYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LOutEyebrowY));
                    MainViewModel.ViewTime5.LOutEyebrowZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LOutEyebrowZ));
                    MainViewModel.ViewTime5.LOutEyebrowWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LOutEyebrowW));

                    MainViewModel.ViewTime5.ROutEyebrowXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ROutEyebrowX));
                    MainViewModel.ViewTime5.ROutEyebrowYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ROutEyebrowY));
                    MainViewModel.ViewTime5.ROutEyebrowZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ROutEyebrowZ));
                    MainViewModel.ViewTime5.ROutEyebrowWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.ROutEyebrowW));

                    MainViewModel.ViewTime5.LInEyebrowXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LInEyebrowX));
                    MainViewModel.ViewTime5.LInEyebrowYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LInEyebrowY));
                    MainViewModel.ViewTime5.LInEyebrowZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LInEyebrowZ));
                    MainViewModel.ViewTime5.LInEyebrowWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LInEyebrowW));

                    MainViewModel.ViewTime5.RInEyebrowXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RInEyebrowX));
                    MainViewModel.ViewTime5.RInEyebrowYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RInEyebrowY));
                    MainViewModel.ViewTime5.RInEyebrowZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RInEyebrowZ));
                    MainViewModel.ViewTime5.RInEyebrowWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RInEyebrowW));

                    MainViewModel.ViewTime5.LEyeXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyeX));
                    MainViewModel.ViewTime5.LEyeYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyeY));
                    MainViewModel.ViewTime5.LEyeZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyeZ));
                    MainViewModel.ViewTime5.LEyeWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyeW));

                    MainViewModel.ViewTime5.REyeXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyeX));
                    MainViewModel.ViewTime5.REyeYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyeY));
                    MainViewModel.ViewTime5.REyeZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyeZ));
                    MainViewModel.ViewTime5.REyeWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyeW));

                    MainViewModel.ViewTime5.LEyelidXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyelidX));
                    MainViewModel.ViewTime5.LEyelidYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyelidY));
                    MainViewModel.ViewTime5.LEyelidZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyelidZ));
                    MainViewModel.ViewTime5.LEyelidWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEyelidW));

                    MainViewModel.ViewTime5.REyelidXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyelidX));
                    MainViewModel.ViewTime5.REyelidYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyelidY));
                    MainViewModel.ViewTime5.REyelidZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyelidZ));
                    MainViewModel.ViewTime5.REyelidWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REyelidW));

                    MainViewModel.ViewTime5.LLowEyelidXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowEyelidX));
                    MainViewModel.ViewTime5.LLowEyelidYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowEyelidY));
                    MainViewModel.ViewTime5.LLowEyelidZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowEyelidZ));
                    MainViewModel.ViewTime5.LLowEyelidWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowEyelidW));

                    MainViewModel.ViewTime5.RLowEyelidXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowEyelidX));
                    MainViewModel.ViewTime5.RLowEyelidYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowEyelidY));
                    MainViewModel.ViewTime5.RLowEyelidZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowEyelidZ));
                    MainViewModel.ViewTime5.RLowEyelidWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowEyelidW));

                    MainViewModel.ViewTime5.LEarXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarX));
                    MainViewModel.ViewTime5.LEarYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarY));
                    MainViewModel.ViewTime5.LEarZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarZ));
                    MainViewModel.ViewTime5.LEarWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LEarW));

                    MainViewModel.ViewTime5.REarXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarX));
                    MainViewModel.ViewTime5.REarYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarY));
                    MainViewModel.ViewTime5.REarZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarZ));
                    MainViewModel.ViewTime5.REarWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.REarW));

                    MainViewModel.ViewTime5.LCheekXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCheekX));
                    MainViewModel.ViewTime5.LCheekYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCheekY));
                    MainViewModel.ViewTime5.LCheekZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCheekZ));
                    MainViewModel.ViewTime5.LCheekWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCheekW));

                    MainViewModel.ViewTime5.RCheekXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCheekX));
                    MainViewModel.ViewTime5.RCheekYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCheekY));
                    MainViewModel.ViewTime5.RCheekZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCheekZ));
                    MainViewModel.ViewTime5.RCheekWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCheekW));

                    MainViewModel.ViewTime5.LMouthXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMouthX));
                    MainViewModel.ViewTime5.LMouthYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMouthY));
                    MainViewModel.ViewTime5.LMouthZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMouthZ));
                    MainViewModel.ViewTime5.LMouthWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMouthW));

                    MainViewModel.ViewTime5.RMouthXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMouthX));
                    MainViewModel.ViewTime5.RMouthYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMouthY));
                    MainViewModel.ViewTime5.RMouthZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMouthZ));
                    MainViewModel.ViewTime5.RMouthWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMouthW));

                    MainViewModel.ViewTime5.LUpLipXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LUpLipX));
                    MainViewModel.ViewTime5.LUpLipYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LUpLipY));
                    MainViewModel.ViewTime5.LUpLipZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LUpLipZ));
                    MainViewModel.ViewTime5.LUpLipWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LUpLipW));

                    MainViewModel.ViewTime5.RUpLipXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RUpLipX));
                    MainViewModel.ViewTime5.RUpLipYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RUpLipY));
                    MainViewModel.ViewTime5.RUpLipZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RUpLipZ));
                    MainViewModel.ViewTime5.RUpLipWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RUpLipW));

                    MainViewModel.ViewTime5.LLowLipXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowLipX));
                    MainViewModel.ViewTime5.LLowLipYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowLipY));
                    MainViewModel.ViewTime5.LLowLipZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowLipZ));
                    MainViewModel.ViewTime5.LLowLipWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LLowLipW));

                    MainViewModel.ViewTime5.RLowLipXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowLipX));
                    MainViewModel.ViewTime5.RLowLipYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowLipY));
                    MainViewModel.ViewTime5.RLowLipZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowLipZ));
                    MainViewModel.ViewTime5.RLowLipWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RLowLipW));

                    MainViewModel.ViewTime5.NeckXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NeckX));
                    MainViewModel.ViewTime5.NeckYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NeckY));
                    MainViewModel.ViewTime5.NeckZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NeckZ));
                    MainViewModel.ViewTime5.NeckWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.NeckW));

                    MainViewModel.ViewTime5.LVEarXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEarX));
                    MainViewModel.ViewTime5.LVEarYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEarY));
                    MainViewModel.ViewTime5.LVEarZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEarZ));
                    MainViewModel.ViewTime5.LVEarWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEarW));

                    MainViewModel.ViewTime5.RVEarXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEarX));
                    MainViewModel.ViewTime5.RVEarYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEarY));
                    MainViewModel.ViewTime5.RVEarZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEarZ));
                    MainViewModel.ViewTime5.RVEarWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEarW));

                    MainViewModel.ViewTime5.LVEar2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar2X));
                    MainViewModel.ViewTime5.LVEar2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar2Y));
                    MainViewModel.ViewTime5.LVEar2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar2Z));
                    MainViewModel.ViewTime5.LVEar2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar2W));

                    MainViewModel.ViewTime5.RVEar2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar2X));
                    MainViewModel.ViewTime5.RVEar2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar2Y));
                    MainViewModel.ViewTime5.RVEar2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar2Z));
                    MainViewModel.ViewTime5.RVEar2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar2W));

                    MainViewModel.ViewTime5.LVEar3XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar3X));
                    MainViewModel.ViewTime5.LVEar3YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar3Y));
                    MainViewModel.ViewTime5.LVEar3ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar3Z));
                    MainViewModel.ViewTime5.LVEar3WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar3W));

                    MainViewModel.ViewTime5.RVEar3XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar3X));
                    MainViewModel.ViewTime5.RVEar3YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar3Y));
                    MainViewModel.ViewTime5.RVEar3ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar3Z));
                    MainViewModel.ViewTime5.RVEar3WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar3W));

                    MainViewModel.ViewTime5.LVEar4XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar4X));
                    MainViewModel.ViewTime5.LVEar4YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar4Y));
                    MainViewModel.ViewTime5.LVEar4ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar4Z));
                    MainViewModel.ViewTime5.LVEar4WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVEar4W));

                    MainViewModel.ViewTime5.RVEar4XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar4X));
                    MainViewModel.ViewTime5.RVEar4YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar4Y));
                    MainViewModel.ViewTime5.RVEar4ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar4Z));
                    MainViewModel.ViewTime5.RVEar4WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVEar4W));

                    MainViewModel.ViewTime5.LVLowLipXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowLipX));
                    MainViewModel.ViewTime5.LVLowLipYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowLipY));
                    MainViewModel.ViewTime5.LVLowLipZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowLipZ));
                    MainViewModel.ViewTime5.LVLowLipWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowLipW));

                    MainViewModel.ViewTime5.RVUpLipXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVUpLipX));
                    MainViewModel.ViewTime5.RVUpLipYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVUpLipY));
                    MainViewModel.ViewTime5.RVUpLipZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVUpLipZ));
                    MainViewModel.ViewTime5.RVUpLipWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVUpLipW));

                    MainViewModel.ViewTime5.RVLowLipXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowLipX));
                    MainViewModel.ViewTime5.RVLowLipYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowLipY));
                    MainViewModel.ViewTime5.RVLowLipZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowLipZ));
                    MainViewModel.ViewTime5.RVLowLipWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowLipW));

                    MainViewModel.ViewTime5.RVLowEar2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar2X));
                    MainViewModel.ViewTime5.RVLowEar2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar2Y));
                    MainViewModel.ViewTime5.RVLowEar2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar2Z));
                    MainViewModel.ViewTime5.RVLowEar2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar2W));

                    MainViewModel.ViewTime5.LVLowEar3XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar3X));
                    MainViewModel.ViewTime5.LVLowEar3YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar3Y));
                    MainViewModel.ViewTime5.LVLowEar3ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar3Z));
                    MainViewModel.ViewTime5.LVLowEar3WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar3W));

                    MainViewModel.ViewTime5.RVLowEar3XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar3X));
                    MainViewModel.ViewTime5.RVLowEar3YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar3Y));
                    MainViewModel.ViewTime5.RVLowEar3ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar3Z));
                    MainViewModel.ViewTime5.RVLowEar3WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar3W));

                    MainViewModel.ViewTime5.LVLowEar4XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar4X));
                    MainViewModel.ViewTime5.LVLowEar4YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar4Y));
                    MainViewModel.ViewTime5.LVLowEar4ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar4Z));
                    MainViewModel.ViewTime5.LVLowEar4WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LVLowEar4W));

                    MainViewModel.ViewTime5.RVLowEar4XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar4X));
                    MainViewModel.ViewTime5.RVLowEar4YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar4Y));
                    MainViewModel.ViewTime5.RVLowEar4ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar4Z));
                    MainViewModel.ViewTime5.RVLowEar4WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RVLowEar4W));



                    CharacterDetails.SaveHeadBones = false;
                }

                if (CharacterDetails.SaveTorsoBones)
                {
                    MainViewModel.ViewTime5.SternumXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.SternumX));
                    MainViewModel.ViewTime5.SternumYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.SternumY));
                    MainViewModel.ViewTime5.SternumZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.SternumZ));
                    MainViewModel.ViewTime5.SternumWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.SternumW));

                    MainViewModel.ViewTime5.TorsoXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TorsoX));
                    MainViewModel.ViewTime5.TorsoYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TorsoY));
                    MainViewModel.ViewTime5.TorsoZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TorsoZ));
                    MainViewModel.ViewTime5.TorsoWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TorsoW));

                    MainViewModel.ViewTime5.WaistXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.WaistX));
                    MainViewModel.ViewTime5.WaistYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.WaistY));
                    MainViewModel.ViewTime5.WaistZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.WaistZ));
                    MainViewModel.ViewTime5.WaistWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.WaistW));

                    MainViewModel.ViewTime5.LBreastXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LBreastX));
                    MainViewModel.ViewTime5.LBreastYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LBreastY));
                    MainViewModel.ViewTime5.LBreastZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LBreastZ));
                    MainViewModel.ViewTime5.LBreastWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LBreastW));

                    MainViewModel.ViewTime5.RBreastXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RBreastX));
                    MainViewModel.ViewTime5.RBreastYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RBreastY));
                    MainViewModel.ViewTime5.RBreastZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RBreastZ));
                    MainViewModel.ViewTime5.RBreastWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RBreastW));

                    MainViewModel.ViewTime5.PelvisXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.PelvisX));
                    MainViewModel.ViewTime5.PelvisYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.PelvisY));
                    MainViewModel.ViewTime5.PelvisZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.PelvisZ));
                    MainViewModel.ViewTime5.PelvisWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.PelvisW));

                    MainViewModel.ViewTime5.TailXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TailX));
                    MainViewModel.ViewTime5.TailYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TailY));
                    MainViewModel.ViewTime5.TailZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TailZ));
                    MainViewModel.ViewTime5.TailWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.TailW));

                    MainViewModel.ViewTime5.Tail2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail2X));
                    MainViewModel.ViewTime5.Tail2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail2Y));
                    MainViewModel.ViewTime5.Tail2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail2Z));
                    MainViewModel.ViewTime5.Tail2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail2W));

                    MainViewModel.ViewTime5.Tail3XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail3X));
                    MainViewModel.ViewTime5.Tail3YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail3Y));
                    MainViewModel.ViewTime5.Tail3ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail3Z));
                    MainViewModel.ViewTime5.Tail3WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail3W));

                    MainViewModel.ViewTime5.Tail4XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail4X));
                    MainViewModel.ViewTime5.Tail4YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail4Y));
                    MainViewModel.ViewTime5.Tail4ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail4Z));
                    MainViewModel.ViewTime5.Tail4WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail4W));

                    MainViewModel.ViewTime5.Tail5XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail5X));
                    MainViewModel.ViewTime5.Tail5YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail5Y));
                    MainViewModel.ViewTime5.Tail5ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail5Z));
                    MainViewModel.ViewTime5.Tail5WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.Tail5W));

                    CharacterDetails.SaveTorsoBones = false;
                }

                if (CharacterDetails.SaveLeftArmBones)
                {
                    MainViewModel.ViewTime5.LShoulderXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LShoulderX));
                    MainViewModel.ViewTime5.LShoulderYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LShoulderY));
                    MainViewModel.ViewTime5.LShoulderZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LShoulderZ));
                    MainViewModel.ViewTime5.LShoulderWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LShoulderW));

                    MainViewModel.ViewTime5.LClavicleXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LClavicleX));
                    MainViewModel.ViewTime5.LClavicleYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LClavicleY));
                    MainViewModel.ViewTime5.LClavicleZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LClavicleZ));
                    MainViewModel.ViewTime5.LClavicleWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LClavicleW));

                    MainViewModel.ViewTime5.LArmXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LArmX));
                    MainViewModel.ViewTime5.LArmYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LArmY));
                    MainViewModel.ViewTime5.LArmZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LArmZ));
                    MainViewModel.ViewTime5.LArmWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LArmW));

                    MainViewModel.ViewTime5.LElbowXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LElbowX));
                    MainViewModel.ViewTime5.LElbowYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LElbowY));
                    MainViewModel.ViewTime5.LElbowZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LElbowZ));
                    MainViewModel.ViewTime5.LElbowWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LElbowW));

                    MainViewModel.ViewTime5.LForearmXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LForearmX));
                    MainViewModel.ViewTime5.LForearmYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LForearmY));
                    MainViewModel.ViewTime5.LForearmZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LForearmZ));
                    MainViewModel.ViewTime5.LForearmWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LForearmW));

                    MainViewModel.ViewTime5.LWristXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LWristX));
                    MainViewModel.ViewTime5.LWristYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LWristY));
                    MainViewModel.ViewTime5.LWristZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LWristZ));
                    MainViewModel.ViewTime5.LWristWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LWristW));

                    MainViewModel.ViewTime5.LHandXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LHandX));
                    MainViewModel.ViewTime5.LHandYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LHandY));
                    MainViewModel.ViewTime5.LHandZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LHandZ));
                    MainViewModel.ViewTime5.LHandWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LHandW));

                    MainViewModel.ViewTime5.LThumbXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumbX));
                    MainViewModel.ViewTime5.LThumbYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumbY));
                    MainViewModel.ViewTime5.LThumbZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumbZ));
                    MainViewModel.ViewTime5.LThumbWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumbW));

                    MainViewModel.ViewTime5.LThumb2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumb2X));
                    MainViewModel.ViewTime5.LThumb2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumb2Y));
                    MainViewModel.ViewTime5.LThumb2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumb2Z));
                    MainViewModel.ViewTime5.LThumb2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThumb2W));

                    MainViewModel.ViewTime5.LIndexXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndexX));
                    MainViewModel.ViewTime5.LIndexYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndexY));
                    MainViewModel.ViewTime5.LIndexZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndexZ));
                    MainViewModel.ViewTime5.LIndexWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndexW));

                    MainViewModel.ViewTime5.LIndex2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndex2X));
                    MainViewModel.ViewTime5.LIndex2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndex2Y));
                    MainViewModel.ViewTime5.LIndex2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndex2Z));
                    MainViewModel.ViewTime5.LIndex2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LIndex2W));

                    MainViewModel.ViewTime5.LMiddleXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddleX));
                    MainViewModel.ViewTime5.LMiddleYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddleY));
                    MainViewModel.ViewTime5.LMiddleZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddleZ));
                    MainViewModel.ViewTime5.LMiddleWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddleW));

                    MainViewModel.ViewTime5.LMiddle2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddle2X));
                    MainViewModel.ViewTime5.LMiddle2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddle2Y));
                    MainViewModel.ViewTime5.LMiddle2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddle2Z));
                    MainViewModel.ViewTime5.LMiddle2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LMiddle2W));

                    MainViewModel.ViewTime5.LRingXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRingX));
                    MainViewModel.ViewTime5.LRingYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRingY));
                    MainViewModel.ViewTime5.LRingZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRingZ));
                    MainViewModel.ViewTime5.LRingWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRingW));

                    MainViewModel.ViewTime5.LRing2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRing2X));
                    MainViewModel.ViewTime5.LRing2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRing2Y));
                    MainViewModel.ViewTime5.LRing2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRing2Z));
                    MainViewModel.ViewTime5.LRing2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LRing2W));

                    MainViewModel.ViewTime5.LPinkyXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinkyX));
                    MainViewModel.ViewTime5.LPinkyYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinkyY));
                    MainViewModel.ViewTime5.LPinkyZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinkyZ));
                    MainViewModel.ViewTime5.LPinkyWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinkyW));

                    MainViewModel.ViewTime5.LPinky2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinky2X));
                    MainViewModel.ViewTime5.LPinky2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinky2Y));
                    MainViewModel.ViewTime5.LPinky2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinky2Z));
                    MainViewModel.ViewTime5.LPinky2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LPinky2W));

                    CharacterDetails.SaveLeftArmBones = false;
                }

                if (CharacterDetails.SaveRightArmBones)
                {
                    MainViewModel.ViewTime5.RShoulderXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RShoulderX));
                    MainViewModel.ViewTime5.RShoulderYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RShoulderY));
                    MainViewModel.ViewTime5.RShoulderZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RShoulderZ));
                    MainViewModel.ViewTime5.RShoulderWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RShoulderW));

                    MainViewModel.ViewTime5.RClavicleXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RClavicleX));
                    MainViewModel.ViewTime5.RClavicleYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RClavicleY));
                    MainViewModel.ViewTime5.RClavicleZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RClavicleZ));
                    MainViewModel.ViewTime5.RClavicleWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RClavicleW));

                    MainViewModel.ViewTime5.RArmXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RArmX));
                    MainViewModel.ViewTime5.RArmYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RArmY));
                    MainViewModel.ViewTime5.RArmZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RArmZ));
                    MainViewModel.ViewTime5.RArmWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RArmW));

                    MainViewModel.ViewTime5.RElbowXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RElbowX));
                    MainViewModel.ViewTime5.RElbowYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RElbowY));
                    MainViewModel.ViewTime5.RElbowZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RElbowZ));
                    MainViewModel.ViewTime5.RElbowWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RElbowW));

                    MainViewModel.ViewTime5.RForearmXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RForearmX));
                    MainViewModel.ViewTime5.RForearmYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RForearmY));
                    MainViewModel.ViewTime5.RForearmZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RForearmZ));
                    MainViewModel.ViewTime5.RForearmWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RForearmW));

                    MainViewModel.ViewTime5.RWristXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RWristX));
                    MainViewModel.ViewTime5.RWristYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RWristY));
                    MainViewModel.ViewTime5.RWristZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RWristZ));
                    MainViewModel.ViewTime5.RWristWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RWristW));

                    MainViewModel.ViewTime5.RHandXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RHandX));
                    MainViewModel.ViewTime5.RHandYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RHandY));
                    MainViewModel.ViewTime5.RHandZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RHandZ));
                    MainViewModel.ViewTime5.RHandWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RHandW));

                    MainViewModel.ViewTime5.RThumbXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumbX));
                    MainViewModel.ViewTime5.RThumbYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumbY));
                    MainViewModel.ViewTime5.RThumbZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumbZ));
                    MainViewModel.ViewTime5.RThumbWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumbW));

                    MainViewModel.ViewTime5.RThumb2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumb2X));
                    MainViewModel.ViewTime5.RThumb2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumb2Y));
                    MainViewModel.ViewTime5.RThumb2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumb2Z));
                    MainViewModel.ViewTime5.RThumb2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThumb2W));

                    MainViewModel.ViewTime5.RIndexXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndexX));
                    MainViewModel.ViewTime5.RIndexYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndexY));
                    MainViewModel.ViewTime5.RIndexZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndexZ));
                    MainViewModel.ViewTime5.RIndexWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndexW));

                    MainViewModel.ViewTime5.RIndex2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndex2X));
                    MainViewModel.ViewTime5.RIndex2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndex2Y));
                    MainViewModel.ViewTime5.RIndex2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndex2Z));
                    MainViewModel.ViewTime5.RIndex2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RIndex2W));

                    MainViewModel.ViewTime5.RMiddleXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddleX));
                    MainViewModel.ViewTime5.RMiddleYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddleY));
                    MainViewModel.ViewTime5.RMiddleZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddleZ));
                    MainViewModel.ViewTime5.RMiddleWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddleW));

                    MainViewModel.ViewTime5.RMiddle2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddle2X));
                    MainViewModel.ViewTime5.RMiddle2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddle2Y));
                    MainViewModel.ViewTime5.RMiddle2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddle2Z));
                    MainViewModel.ViewTime5.RMiddle2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RMiddle2W));

                    MainViewModel.ViewTime5.RRingXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRingX));
                    MainViewModel.ViewTime5.RRingYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRingY));
                    MainViewModel.ViewTime5.RRingZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRingZ));
                    MainViewModel.ViewTime5.RRingWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRingW));

                    MainViewModel.ViewTime5.RRing2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRing2X));
                    MainViewModel.ViewTime5.RRing2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRing2Y));
                    MainViewModel.ViewTime5.RRing2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRing2Z));
                    MainViewModel.ViewTime5.RRing2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RRing2W));

                    MainViewModel.ViewTime5.RPinkyXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinkyX));
                    MainViewModel.ViewTime5.RPinkyYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinkyY));
                    MainViewModel.ViewTime5.RPinkyZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinkyZ));
                    MainViewModel.ViewTime5.RPinkyWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinkyW));

                    MainViewModel.ViewTime5.RPinky2XSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinky2X));
                    MainViewModel.ViewTime5.RPinky2YSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinky2Y));
                    MainViewModel.ViewTime5.RPinky2ZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinky2Z));
                    MainViewModel.ViewTime5.RPinky2WSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RPinky2W));

                    CharacterDetails.SaveRightArmBones = false;
                }

                if (CharacterDetails.SaveLeftLegBones)
                {
                    MainViewModel.ViewTime5.LThighXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThighX));
                    MainViewModel.ViewTime5.LThighYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThighY));
                    MainViewModel.ViewTime5.LThighZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThighZ));
                    MainViewModel.ViewTime5.LThighWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LThighW));

                    MainViewModel.ViewTime5.LKneeXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LKneeX));
                    MainViewModel.ViewTime5.LKneeYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LKneeY));
                    MainViewModel.ViewTime5.LKneeZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LKneeZ));
                    MainViewModel.ViewTime5.LKneeWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LKneeW));

                    MainViewModel.ViewTime5.LCalfXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCalfX));
                    MainViewModel.ViewTime5.LCalfYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCalfY));
                    MainViewModel.ViewTime5.LCalfZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCalfZ));
                    MainViewModel.ViewTime5.LCalfWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LCalfW));

                    MainViewModel.ViewTime5.LFootXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LFootX));
                    MainViewModel.ViewTime5.LFootYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LFootY));
                    MainViewModel.ViewTime5.LFootZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LFootZ));
                    MainViewModel.ViewTime5.LFootWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LFootW));

                    MainViewModel.ViewTime5.LToesXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LToesX));
                    MainViewModel.ViewTime5.LToesYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LToesY));
                    MainViewModel.ViewTime5.LToesZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LToesZ));
                    MainViewModel.ViewTime5.LToesWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.LToesW));

                    CharacterDetails.SaveLeftLegBones = false;
                }

                if (CharacterDetails.SaveRightLegBones)
                {
                    MainViewModel.ViewTime5.RThighXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThighX));
                    MainViewModel.ViewTime5.RThighYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThighY));
                    MainViewModel.ViewTime5.RThighZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThighZ));
                    MainViewModel.ViewTime5.RThighWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RThighW));

                    MainViewModel.ViewTime5.RKneeXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RKneeX));
                    MainViewModel.ViewTime5.RKneeYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RKneeY));
                    MainViewModel.ViewTime5.RKneeZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RKneeZ));
                    MainViewModel.ViewTime5.RKneeWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RKneeW));

                    MainViewModel.ViewTime5.RCalfXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCalfX));
                    MainViewModel.ViewTime5.RCalfYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCalfY));
                    MainViewModel.ViewTime5.RCalfZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCalfZ));
                    MainViewModel.ViewTime5.RCalfWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RCalfW));

                    MainViewModel.ViewTime5.RFootXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RFootX));
                    MainViewModel.ViewTime5.RFootYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RFootY));
                    MainViewModel.ViewTime5.RFootZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RFootZ));
                    MainViewModel.ViewTime5.RFootWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RFootW));

                    MainViewModel.ViewTime5.RToesXSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RToesX));
                    MainViewModel.ViewTime5.RToesYSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RToesY));
                    MainViewModel.ViewTime5.RToesZSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RToesZ));
                    MainViewModel.ViewTime5.RToesWSav = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Position.RToesW));

                    CharacterDetails.SaveRightLegBones = false;
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