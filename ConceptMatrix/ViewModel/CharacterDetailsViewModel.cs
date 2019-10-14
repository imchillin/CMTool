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
				// get the array size
				if (CharacterDetails.GposeMode || CharacterDetails.TargetModeActive) CharacterDetails.Size = m.readLong(MemoryManager.Instance.GposeAddress);
                if (CharacterDetails.GposeMode || !CharacterDetails.TargetModeActive) CharacterDetails.Size = m.readLong(MemoryManager.Instance.GposeEntityOffset);
                if (!CharacterDetails.GposeMode) CharacterDetails.Size = m.readLong(MemoryManager.Instance.BaseAddress);

				// clear the entity list
				CharacterDetails.Names.Clear();
				// loop over entity list size
				float x1 = 0;
				float y1 = 0;
				float z1 = 0;
				if (!CharacterDetails.GposeMode)
				{
					for (var i = 0; i < CharacterDetails.Size; i++)
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
				if (CharacterDetails.GposeMode || CharacterDetails.TargetModeActive)
                {
					for (var i = 0; i < CharacterDetails.Size; i++)
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
                if (CharacterDetails.GposeMode || !CharacterDetails.TargetModeActive)
                {
                    for (var i = 0; i < CharacterDetails.Size; i++)
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
				if (CharacterDetails.GposeMode || CharacterDetails.TargetModeActive) baseAddr = MemoryManager.Add(MemoryManager.Instance.GposeAddress, eOffset);
                if (CharacterDetails.GposeMode || !CharacterDetails.TargetModeActive) baseAddr = MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, eOffset);
                if (!CharacterDetails.GposeMode) baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset);

				if (CharacterDetails.TargetModeActive)
				{
                    if (!CharacterDetails.GposeMode) baseAddr = MemoryManager.Instance.TargetAddress;
                    if (CharacterDetails.GposeMode) baseAddr = MemoryManager.Instance.GposeAddress;
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
				if (!CharacterDetails.RotateFreeze)
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
	}
}