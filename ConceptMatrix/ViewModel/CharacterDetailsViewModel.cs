using ConceptMatrix.Commands;
using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using System;
using System.ComponentModel;

namespace ConceptMatrix.ViewModel
{
    public class CharacterDetailsViewModel : BaseViewModel
    {
        public CharacterDetails CharacterDetails { get => (CharacterDetails)model; set => model = value; }
        private RefreshEntitiesCommand refreshEntitiesCommand;
        public static string eOffset = "8";
        public static bool FreezeAll = false;
        public static bool EnabledEditing = false;
        public static bool CurrentlySavingFilter = false;
        public int WritingCheck = 0;
        public static string baseAddr;
        public static Views.CharacterDetailsView Viewtime;

        private readonly Mem m = MemoryManager.Instance.MemLib;
        private CharacterOffsets c = Settings.Instance.Character;
        private string GAS(params string[] args) => MemoryManager.GetAddressString(args);

        public RefreshEntitiesCommand RefreshEntitiesCommand
        {
            get => refreshEntitiesCommand;
        }
        public CharacterDetailsViewModel(Mediator mediator) : base(mediator)
        {
            model = new CharacterDetails();
            model.PropertyChanged += Model_PropertyChanged;
            refreshEntitiesCommand = new RefreshEntitiesCommand(this);
            // refresh the list initially
            this.Refresh();
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
                if (!CharacterDetails.RotateFreeze && !CharacterDetails.BoneFreeze)
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

                if (CharacterDetails.BoneFreeze)
                {
                    HeadBoneWork();
                    BodyBoneWork();
                    ArmBoneWork();
                    FingerBoneWork();
                    LegBoneWork();
                }

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
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Oh no!");
                mediator.Work -= Work;
            }
        }
        private void HeadBoneWork()
        {
            if (MainViewModel.ViewTime5.HeadCheck)
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
            }

            if (MainViewModel.ViewTime5.NoseCheck)
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
            }

            if (MainViewModel.ViewTime5.NostrilsCheck)
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
            }

            if (MainViewModel.ViewTime5.ChinCheck)
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
            }

            if (MainViewModel.ViewTime5.LOutEyebrowCheck)
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
            }

            if (MainViewModel.ViewTime5.ROutEyebrowCheck)
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
            }

            if (MainViewModel.ViewTime5.LInEyebrowCheck)
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
            }

            if (MainViewModel.ViewTime5.RInEyebrowCheck)
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
            }

            if (MainViewModel.ViewTime5.LEyeCheck)
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
            }

            if (MainViewModel.ViewTime5.REyeCheck)
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
            }

            if (MainViewModel.ViewTime5.LEyelidCheck)
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
            }

            if (MainViewModel.ViewTime5.REyelidCheck)
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
            }

            if (MainViewModel.ViewTime5.LLowEyelidCheck)
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
            }

            if (MainViewModel.ViewTime5.RLowEyelidCheck)
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
            }

            if (MainViewModel.ViewTime5.LEarCheck)
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
            }

            if (MainViewModel.ViewTime5.REarCheck)
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
            }

            if (MainViewModel.ViewTime5.LCheekCheck)
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
            }

            if (MainViewModel.ViewTime5.RCheekCheck)
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
            }

            if (MainViewModel.ViewTime5.LMouthCheck)
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
            }

            if (MainViewModel.ViewTime5.RMouthCheck)
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
            }

            if (MainViewModel.ViewTime5.LUpLipCheck)
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
            }

            if (MainViewModel.ViewTime5.RUpLipCheck)
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
            }

            if (MainViewModel.ViewTime5.LLowLipCheck)
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
            }

            if (MainViewModel.ViewTime5.RLowLipCheck)
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
            }
        }

        private void BodyBoneWork()
        {
            if (MainViewModel.ViewTime5.NeckCheck)
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
            }

            if (MainViewModel.ViewTime5.SternumCheck)
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
            }

            if (MainViewModel.ViewTime5.TorsoCheck)
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
            }

            if (MainViewModel.ViewTime5.WaistCheck)
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
            }

            if (MainViewModel.ViewTime5.LShoulderCheck)
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
            }

            if (MainViewModel.ViewTime5.RShoulderCheck)
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
            }

            if (MainViewModel.ViewTime5.LClavicleCheck)
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
            }

            if (MainViewModel.ViewTime5.RClavicleCheck)
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
            }

            if (MainViewModel.ViewTime5.LBreastCheck)
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
            }

            if (MainViewModel.ViewTime5.RBreastCheck)
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
            }
        }

        private void ArmBoneWork()
        {
            if (MainViewModel.ViewTime5.LArmCheck)
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
            }

            if (MainViewModel.ViewTime5.RArmCheck)
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
            }

            if (MainViewModel.ViewTime5.LElbowCheck)
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
            }

            if (MainViewModel.ViewTime5.RElbowCheck)
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
            }

            if (MainViewModel.ViewTime5.LForearmCheck)
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
            }

            if (MainViewModel.ViewTime5.RForearmCheck)
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
            }

            if (MainViewModel.ViewTime5.LWristCheck)
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
            }

            if (MainViewModel.ViewTime5.RWristCheck)
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
            }

            if (MainViewModel.ViewTime5.LHandCheck)
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
            }

            if (MainViewModel.ViewTime5.RHandCheck)
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
            }
        }

        private void FingerBoneWork()
        {
            if (MainViewModel.ViewTime5.LThumbCheck)
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
            }

            if (MainViewModel.ViewTime5.RThumbCheck)
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
            }

            if (MainViewModel.ViewTime5.LThumb2Check)
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
            }

            if (MainViewModel.ViewTime5.RThumb2Check)
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
            }

            if (MainViewModel.ViewTime5.LIndexCheck)
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
            }

            if (MainViewModel.ViewTime5.RIndexCheck)
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
            }

            if (MainViewModel.ViewTime5.LIndex2Check)
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
            }

            if (MainViewModel.ViewTime5.RIndex2Check)
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
            }

            if (MainViewModel.ViewTime5.LMiddleCheck)
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
            }

            if (MainViewModel.ViewTime5.RMiddleCheck)
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
            }

            if (MainViewModel.ViewTime5.LMiddle2Check)
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
            }

            if (MainViewModel.ViewTime5.RMiddle2Check)
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
            }

            if (MainViewModel.ViewTime5.LRingCheck)
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
            }

            if (MainViewModel.ViewTime5.RRingCheck)
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
            }

            if (MainViewModel.ViewTime5.LRing2Check)
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
            }

            if (MainViewModel.ViewTime5.RRing2Check)
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
            }

            if (MainViewModel.ViewTime5.LPinkyCheck)
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
            }

            if (MainViewModel.ViewTime5.RPinkyCheck)
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
            }

            if (MainViewModel.ViewTime5.LPinky2Check)
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
            }

            if (MainViewModel.ViewTime5.RPinky2Check)
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
            }
        }

        private void LegBoneWork()
        {
            if (MainViewModel.ViewTime5.PelvisCheck)
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
            }

            if (MainViewModel.ViewTime5.TailCheck)
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
            }

            if (MainViewModel.ViewTime5.LThighCheck)
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
            }

            if (MainViewModel.ViewTime5.RThighCheck)
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
            }

            if (MainViewModel.ViewTime5.LKneeCheck)
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
            }

            if (MainViewModel.ViewTime5.RKneeCheck)
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
            }

            if (MainViewModel.ViewTime5.LCalfCheck)
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
            }

            if (MainViewModel.ViewTime5.RCalfCheck)
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
            }

            if (MainViewModel.ViewTime5.LFootCheck)
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
            }

            if (MainViewModel.ViewTime5.RFootCheck)
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
            }

            if (MainViewModel.ViewTime5.LToesCheck)
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
            }

            if (MainViewModel.ViewTime5.RToesCheck)
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
            }
        }
    }
}