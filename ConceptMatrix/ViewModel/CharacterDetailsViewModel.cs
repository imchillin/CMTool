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
using System.Windows.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Globalization;

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
        public static string GposeAddr;
        public static CharacterDetailsView Viewtime;

        private readonly Mem m = MemoryManager.Instance.MemLib;
        private CharacterOffsets c = Settings.Instance.Character;
        private string GAS(params string[] args) => MemoryManager.GetAddressString(args);
        public RefreshEntitiesCommand RefreshEntitiesCommand { get; }
		public CharacterDetailsViewModel(Mediator mediator) : base(mediator)
        {
            try
            {
                model = new CharacterDetails();
                model.PropertyChanged += Model_PropertyChanged;
                RefreshEntitiesCommand = new RefreshEntitiesCommand(this);

                // Fetch the offsets needed for the mediator to fucking work before we call refresh.
                FetchOffsets();

                // refresh the list initially
                Refresh();
                mediator.Work += Work;

                mediator.EntitySelection += (offset) => eOffset = offset;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        /// <summary>
        /// This is the most dumb god damn shit I've ever seen in my whole life go fuck yourself.
        /// </summary>
        public void FetchOffsets()
        {
            var m = MemoryManager.Instance.MemLib;
            var start = m.theProc.MainModule.BaseAddress.ToInt64();
            var end = start + m.theProc.MainModule.ModuleMemorySize;

            // Shorthand function even though I could just make the entire function in this scope I decided not to.
            string GSAFS(string signature, int skip, int adjust = 0, bool baseOffset = false)
			{
                var addr = m.AoBScan(start, end, signature).FirstOrDefault();
                if (addr == 0)
                    return "0";
                    //throw new Exception("Invalid address found!");

                var a = GetStaticAddressFromSig(m, addr, skip, baseOffset);
                return (a + adjust).ToString("X");
			}

            string ScanText(string signature) => m.AoBScan(start, end, signature).FirstOrDefault().ToString("X");

            // Getting static addresses from assembly.
            MemoryManager.Instance.BaseAddress = GSAFS("88 91 ?? ?? ?? ?? 48 8D 3D ?? ?? ?? ??", 9, -8);
            MemoryManager.Instance.CameraAddress = GSAFS("48 8D 35 ?? ?? ?? ?? 48 8B 09", 4, 0, true);
            MemoryManager.Instance.TerritoryAddress = GSAFS("8B 1D ?? ?? ?? ?? 0F 45 D8 39 1D", 2);
            MemoryManager.Instance.TimeAddress = GSAFS("48 8B 15 ?? ?? ?? ?? 4C 8B 82 18 16 00 00", 3);

            MemoryManager.Instance.TargetAddress = GSAFS("48 8B 05 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? FF 50 ?? 48 85 DB", 3, 0x100);
            MemoryManager.Instance.GposeAddress = GSAFS("48 8B 05 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? FF 50 18 48 85 DB", 3, 0xC0);
            MemoryManager.Instance.GposeEntityOffset = GSAFS("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8E", 3, 0x14A0);
            MemoryManager.Instance.GposeCheckAddress = GSAFS("48 8B 15 ?? ?? ?? ?? 48 89 6C 24", 3);
            MemoryManager.Instance.GposeCheck2Address = GSAFS("8D 48 FF 48 8D 05 ?? ?? ?? ?? 8B 0C 88 48 8B 02 83 F9 04 49 8B CA", 6);
            MemoryManager.Instance.GposeFilters = GSAFS("4C 8B 05 ?? ?? ?? ?? 41 8B 80 ?? ?? ?? ?? C1 E8 02", 3);
            MemoryManager.Instance.WeatherAddress = GSAFS("49 8B 9D ?? ?? ?? ?? 48 8D 0D", 10, 8);

            // Skeleton posing addresses.
            MemoryManager.Instance.SkeletonAddress = ScanText("41 0F 29 5C 12 10");
            MemoryManager.Instance.SkeletonAddress2 = ScanText("43 0F 29 5C 18 10");
            MemoryManager.Instance.SkeletonAddress3 = ScanText("0F 29 5E 10 49 8B 73 28");
            MemoryManager.Instance.SkeletonAddress4 = ScanText("41 0F 29 44 12 20");
            MemoryManager.Instance.SkeletonAddress5 = ScanText("41 0F 29 24 12");
            MemoryManager.Instance.SkeletonAddress6 = ScanText("43 0F 29 44 18 20");
            MemoryManager.Instance.SkeletonAddress7 = ScanText("43 0f 29 24 18");

            // Physics.
            var physics = m.AoBScan(start, end, "0F 29 48 10 41 0F 28 44 24 20 0F 29 40 20 48 8B 46").FirstOrDefault();
            MemoryManager.Instance.PhysicsAddress = physics.ToString("X");
            MemoryManager.Instance.PhysicsAddress2 = (physics - 0x9).ToString("X");
            MemoryManager.Instance.PhysicsAddress3 = (physics + 0xA).ToString("X");

            // Render limit.
            var render = m.AoBScan(start, end, "E9 B8 00 00 00 F3 0F 10").FirstOrDefault();
            MemoryManager.Instance.CharacterRenderAddress = render.ToString("X");
            MemoryManager.Instance.CharacterRenderAddress2 = (render - 0xA).ToString("X");

            // Cheap hook. (temp?)
            MemoryManager.Instance.TimeStopAsm = m.AoBScan(start, end, "48 89 ?? 08 16 00 00 48 69").FirstOrDefault();
            MemoryManager.Instance.TimeAsm = m.readBytes(MemoryManager.Instance.TimeStopAsm.ToString("X"), 7);

            // Cheap ass emote hack.
            MemoryManager.Instance.EmoteHack = ScanText("66 89 8B D0 00 00 00 48 8B 43 60 48 85 C0");
        }

        // This is SUPER janky but I don't want to spend time implementing something better right now.
        // This function assumes you know what you're doing and is not going to sanity check anything.
        private long GetStaticAddressFromSig(Mem m, long address, int skip, bool baseOffset = false)
		{
            var read = m.readBytes(new UIntPtr((ulong)address), 8 + skip);
            var offset = BitConverter.ToInt32(read, skip);
            if (baseOffset)
                return m.theProc.MainModule.BaseAddress.ToInt64() + offset;
            return address + skip + offset + 4;
		}

        /// <summary>
        /// Model property changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //shitty but oh well
            if (e.PropertyName == "SelectedIndex")
            {
                if (!CharacterDetails.GposeMode && !CharacterDetails.TargetModeActive)

                {
                    if (CharacterDetails.SelectedIndex != -1)
                    {
                        var Value = MainViewModel.MainTime.ActorCMB.Items[CharacterDetails.SelectedIndex] as ActorTable;
                        mediator.SendEntitySelection(((Value.ActorID + 1) * 8).ToString("X"));
                    }
                    else mediator.SendEntitySelection(((CharacterDetails.SelectedIndex + 1) * 8).ToString("X"));
                }
                else mediator.SendEntitySelection(((CharacterDetails.SelectedIndex + 1) * 8).ToString("X"));
            }
        }
        public void Refresh()
        {
            // clear the entity list
            CharacterDetails.Names.Clear();

            // Switch base address if we're in gpose or not.
            var addrBase = CharacterDetails.GposeMode ? MemoryManager.Instance.GposeEntityOffset : MemoryManager.Instance.BaseAddress;
            var count = CharacterDetails.GposeMode ? m.readLong(MemoryManager.Instance.GposeEntityOffset) : 424;

            // Loop over the amount of entities based on mode via count.
            for (var i = 0; i < count; i++)
            {
                // Get the address base for the current iterating item.
                var currentBase = MemoryManager.Add(addrBase, ((i + 1) * 8).ToString("X"));

                // Read the object id.
                var objectID = m.readByte(GAS(currentBase, "0x8C"));
                // Ignore objects of a certain ID.
                if (objectID == 0 || objectID == 4 || objectID == 5 || objectID == 6 || objectID == 7 || objectID == 8 || objectID == 11 || objectID == 12 || objectID == 13)
                    continue;

                // Get the address for the name.
                var name = m.readString(GAS(currentBase, c.Name));
                // Read the yalms distance.
                var yalms = m.read2Byte(GAS(currentBase, "0x92"));
                // Substring the name to trim off excess characters (not sure if this is needed?)
                if (name.IndexOf('\0') != -1)
                    name = name.Substring(0, name.IndexOf('\0'));

                // Get the actor address from the pointer.
                var address = m.readLong(currentBase);

                // Add name to the list.
                CharacterDetails.Names.Add(new ActorTable { Name = name, ActorID = i, Yalm = yalms, Address = new IntPtr(address) });
            }

            // Sort the names list by yalms.
            CharacterDetails.Names = CharacterDetails.Names.OrderBy(a => a.Yalm).ToList();

            // set the enable state
            CharacterDetails.IsEnabled = true;
            // set the index if its under 0
            if (CharacterDetails.SelectedIndex < 0)
                CharacterDetails.SelectedIndex = 0;
        }
        private void Work()
        {
            try
            {
                CharacterDetails.Territory = m.readInt(MemoryManager.Instance.TerritoryAddress);
                CharacterDetails.TerritoryName = Extensions.TerritoryName(CharacterDetails.Territory);
                if (CharacterDetails.GposeMode)
                {
                    if (CharacterDetails.TargetModeActive)
                        baseAddr = MemoryManager.Add(MemoryManager.Instance.GposeAddress, eOffset);
                    else
                    {
                        baseAddr = MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, eOffset);
                        GposeAddr = MemoryManager.Add(MemoryManager.Instance.GposeEntityOffset, eOffset);
                    }
                }
                else
                {
                    baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset);
                    GposeAddr = string.Empty;
                }
                if (CharacterDetails.TargetModeActive)
                {
                    if (!CharacterDetails.GposeMode) baseAddr = MemoryManager.Instance.TargetAddress;
                    else baseAddr = MemoryManager.Instance.GposeAddress;
                }
                var nameAddr = GAS(baseAddr, c.Name);
                var fcnameAddr = GAS(baseAddr, c.FCTag);
                var entityType = (byte)m.readByte(GAS(baseAddr, c.EntityType));
                var entitySubType = (byte)m.readByte(GAS(baseAddr, c.EntitySub));
                CharacterDetails.EntitySub.value = entitySubType;
                if(entitySubType == 5)
                {
                    Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        MainViewModel.characterView.MonsterCheck.IsChecked = false;
                        MainViewModel.characterView.MonsterCheck.IsEnabled = false;
                        MainViewModel.characterView.MonsterNum.IsEnabled = false;
                        MainViewModel.actorPropView.EntityBox.IsEnabled = false;
                        MainViewModel.actorPropView.EntityCheck.IsChecked = false;
                        MainViewModel.actorPropView.EntityCheck.IsEnabled = false;
                    });
                }
                else
                {
                    if (Application.Current == null)
                        return;

                    Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        MainViewModel.characterView.MonsterCheck.IsEnabled = true;
                        MainViewModel.characterView.MonsterNum.IsEnabled = true;
                        MainViewModel.actorPropView.EntityBox.IsEnabled = true;
                        MainViewModel.actorPropView.EntityCheck.IsEnabled = true;
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
                    if (entityType == 1)
                        CharacterDetails.FCTag.value = fcname;
                    if (entityType != 1)
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
                        CharacterDetails.FilterAoB.value = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(MemoryManager.Instance.GposeFilters, c.Brightness), 60));
                    }
                    else
                    {
                        byte[] FIlterBytes = m.readBytes(GAS(MemoryManager.Instance.GposeFilters, c.Brightness), 60);
                        CharacterDetails.FilterAoB.value = MemoryManager.ByteArrayToStringU(FIlterBytes);
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
                }
                #endregion

                if (!CheckingGPose)
                {
                    if (m.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.GposeCheckAddress)) == 0 &&
                        m.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.GposeCheck2Address)) == 1)
                    {
                        if (InGpose)
                        {
                            CharacterDetails.GposeMode = false;
                            InGpose = false;

                            Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                            {
                                MainViewModel.posing2View.PoseMatrixSetting.IsEnabled = false;
                                MainViewModel.posing2View.EditModeButton.IsChecked = false;
                                PoseMatrixView.PosingMatrix.PoseMatrixSetting.IsEnabled = false;
                                PoseMatrixView.PosingMatrix.EditModeButton.IsChecked = false;
                                MainViewModel.posing2View.LoadCMP.IsEnabled = false;
                                MainViewModel.posing2View.AdvLoadCMP.IsEnabled = false;
                                PoseMatrixView.PosingMatrix.LoadCMP.IsEnabled = false;
                                PoseMatrixView.PosingMatrix.AdvLoadCMP.IsEnabled = false;

                                // MainViewModel.characterView.EnableAnim.IsChecked = false;

                                MainViewModel.posingView.PoseMatrixSetting.IsEnabled = false;
                                MainViewModel.posingView.EditModeButton.IsChecked = false;
                                PosingOldView.PosingMatrix.PoseMatrixSetting.IsEnabled = false;
                                PosingOldView.PosingMatrix.EditModeButton.IsChecked = false;
                                MainViewModel.posingView.LoadCMP.IsEnabled = false;
                                MainViewModel.posingView.AdvLoadCMP.IsEnabled = false;
                                PosingOldView.PosingMatrix.LoadCMP.IsEnabled = false;
                                PosingOldView.PosingMatrix.AdvLoadCMP.IsEnabled = false;
                            });
                        }
                    }
                    else if (m.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.GposeCheckAddress)) == 1 &&
                             m.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.GposeCheck2Address)) == 4)
                    {
                    if (!InGpose)
                    {
                        CharacterDetails.SelectedIndex = 0;

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
                        string GASD(params string[] args) => MemoryManager.GetAddressString(MemoryManager.Add(MemoryManager.Instance.BaseAddress, "8"), args);
                        var EntityType = m.get64bitCode(GASD(c.EntityType));
                        m.writeBytes(EntityType, 2);
                        Task.Delay(1500).Wait();
                        m.writeBytes(EntityType, 1);
                        Task.Delay(50).Wait();
                        m.writeMemory(GAS(MemoryManager.Instance.GposeAddress, c.EntityType), "byte", "0x01");

                        CharacterDetails.GposeMode = true;
                        InGpose = true;

                        Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                        {
                            MainViewModel.posing2View.PoseMatrixSetting.IsEnabled = true;
                            PoseMatrixView.PosingMatrix.PoseMatrixSetting.IsEnabled = true;
                            MainViewModel.posing2View.LoadCMP.IsEnabled = true;
                            MainViewModel.posing2View.AdvLoadCMP.IsEnabled = true;
                            PoseMatrixView.PosingMatrix.LoadCMP.IsEnabled = true;
                            PoseMatrixView.PosingMatrix.AdvLoadCMP.IsEnabled = true;

                            // MainViewModel.characterView.EnableAnim.IsChecked = false;

                            MainViewModel.posingView.PoseMatrixSetting.IsEnabled = true;
                            PosingOldView.PosingMatrix.PoseMatrixSetting.IsEnabled = true;
                            MainViewModel.posingView.LoadCMP.IsEnabled = true;
                            MainViewModel.posingView.AdvLoadCMP.IsEnabled = true;
                            PosingOldView.PosingMatrix.LoadCMP.IsEnabled = true;
                            PosingOldView.PosingMatrix.AdvLoadCMP.IsEnabled = true;
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
                if (!CharacterDetails.Skintone.freeze) CharacterDetails.Skintone.value = CharacterBytes[8];
                if (!CharacterDetails.RightEye.freeze) CharacterDetails.RightEye.value = CharacterBytes[9];
                if (!CharacterDetails.HairTone.freeze) CharacterDetails.HairTone.value = CharacterBytes[10];
                if (!CharacterDetails.HighlightTone.freeze)
                {
                    CharacterDetails.Highlights.value = CharacterBytes[7];
                    if (CharacterBytes[7] >= 80) CharacterDetails.Highlights.SpecialActivate = true;
                    else CharacterDetails.Highlights.SpecialActivate = false;
                    CharacterDetails.HighlightTone.value = CharacterBytes[11];
                }
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
                        if (PosingOldView.PosingMatrix.EditModeButton.IsChecked == true)
                        {
                            PosingOldView.PosingMatrix.EnableTertiary();
                            if (PoseMatrixViewModel.PoseVM.PointerPath != null) PosingOldView.PosingMatrix.GetPointers(PoseMatrixViewModel.PoseVM.TheButton);
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

                if (!CharacterDetails.ModelType.freeze) CharacterDetails.ModelType.value = m.read2Byte(GAS(baseAddr, c.ModelType));

                if (!CharacterDetails.DataPath.freeze) CharacterDetails.DataPath.value = m.read2Byte(GAS(baseAddr, c.DataPath));

                if (!CharacterDetails.NPCName.freeze) CharacterDetails.NPCName.value = m.read2Byte(GAS(baseAddr, c.NPCName));

                if (!CharacterDetails.NPCModel.freeze) CharacterDetails.NPCModel.value = m.read2Byte(GAS(baseAddr, c.NPCModel));


                CharacterDetails.EmoteIsPlayerFrozen.value = (byte)m.readByte(GAS(baseAddr, c.EmoteIsPlayerFrozen));

                if (CharacterDetails.EmoteIsPlayerFrozen.value == 0) { Viewtime.FrozenPlayaLabel.Dispatcher.Invoke(new Action(() => { Viewtime.FrozenPlayaLabel.Content = MiscStrings.TargetActorIs2; Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.Red; })); }
                else if (CharacterDetails.EmoteIsPlayerFrozen.value == 1) { Viewtime.FrozenPlayaLabel.Dispatcher.Invoke(new Action(() => { Viewtime.FrozenPlayaLabel.Content = MiscStrings.TargetActorIs3; Viewtime.FrozenPlayaLabel.Foreground = System.Windows.Media.Brushes.Green; })); }

                if (!CharacterDetails.Emote.freeze) CharacterDetails.Emote.value = m.read2Byte((GAS(baseAddr, c.Emote)));

                if (!CharacterDetails.EntityType.freeze) CharacterDetails.EntityType.value = (byte)m.readByte(GAS(baseAddr, c.EntityType));

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

                if (!CharacterDetails.LimbalG.freeze) CharacterDetails.LimbalG.value = m.readFloat(GAS(baseAddr, c.LimbalG));

                if (!CharacterDetails.LimbalB.freeze) CharacterDetails.LimbalB.value = m.readFloat(GAS(baseAddr, c.LimbalB));

                if (!CharacterDetails.LimbalR.freeze) CharacterDetails.LimbalR.value = m.readFloat(GAS(baseAddr, c.LimbalR));

                if (!CharacterDetails.ScaleX.freeze) CharacterDetails.ScaleX.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Scale.X));

                if (!CharacterDetails.ScaleY.freeze) CharacterDetails.ScaleY.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Scale.Y));

                if (!CharacterDetails.ScaleZ.freeze) CharacterDetails.ScaleZ.value = m.readFloat(GAS(baseAddr, c.Body.Base, c.Body.Scale.Z));

                if (!CharacterDetails.LipsB.freeze) CharacterDetails.LipsB.value = m.readFloat(GAS(baseAddr, c.LipsB));

                if (!CharacterDetails.LipsG.freeze) CharacterDetails.LipsG.value = m.readFloat(GAS(baseAddr, c.LipsG));

                if (!CharacterDetails.LipsR.freeze) CharacterDetails.LipsR.value = m.readFloat(GAS(baseAddr, c.LipsR));

                if (!CharacterDetails.LipsBrightness.freeze) CharacterDetails.LipsBrightness.value = m.readFloat(GAS(baseAddr, c.LipsBrightness));

                if (!CharacterDetails.RightEyeBlue.freeze) CharacterDetails.RightEyeBlue.value = m.readFloat(GAS(baseAddr, c.RightEyeBlue));
                if (!CharacterDetails.RightEyeGreen.freeze) CharacterDetails.RightEyeGreen.value = m.readFloat(GAS(baseAddr, c.RightEyeGreen));

                if (!CharacterDetails.RightEyeRed.freeze) CharacterDetails.RightEyeRed.value = m.readFloat(GAS(baseAddr, c.RightEyeRed));
                if (!CharacterDetails.LeftEyeBlue.freeze) CharacterDetails.LeftEyeBlue.value = m.readFloat(GAS(baseAddr, c.LeftEyeBlue));

                if (!CharacterDetails.LeftEyeGreen.freeze) CharacterDetails.LeftEyeGreen.value = m.readFloat(GAS(baseAddr, c.LeftEyeGreen));

                if (!CharacterDetails.LeftEyeRed.freeze) CharacterDetails.LeftEyeRed.value = m.readFloat(GAS(baseAddr, c.LeftEyeRed));

                if (!CharacterDetails.HighlightBluePigment.freeze) CharacterDetails.HighlightBluePigment.value = m.readFloat(GAS(baseAddr, c.HighlightBluePigment));

                if (!CharacterDetails.HighlightGreenPigment.freeze) CharacterDetails.HighlightGreenPigment.value = m.readFloat(GAS(baseAddr, c.HighlightGreenPigment));

                if (!CharacterDetails.HighlightRedPigment.freeze) CharacterDetails.HighlightRedPigment.value = m.readFloat(GAS(baseAddr, c.HighlightRedPigment));

                if (!CharacterDetails.HairGlowBlue.freeze) CharacterDetails.HairGlowBlue.value = m.readFloat(GAS(baseAddr, c.HairGlowBlue));

                if (!CharacterDetails.HairGlowGreen.freeze) CharacterDetails.HairGlowGreen.value = m.readFloat(GAS(baseAddr, c.HairGlowGreen));

                if (!CharacterDetails.HairGlowRed.freeze) CharacterDetails.HairGlowRed.value = m.readFloat(GAS(baseAddr, c.HairGlowRed));

                if (!CharacterDetails.HairBluePigment.freeze) CharacterDetails.HairBluePigment.value = m.readFloat(GAS(baseAddr, c.HairBluePigment));

                if (!CharacterDetails.HairGreenPigment.freeze) CharacterDetails.HairGreenPigment.value = m.readFloat(GAS(baseAddr, c.HairGreenPigment));

                if (!CharacterDetails.HairRedPigment.freeze) CharacterDetails.HairRedPigment.value = m.readFloat(GAS(baseAddr, c.HairRedPigment));

                if (!CharacterDetails.SkinBlueGloss.freeze) CharacterDetails.SkinBlueGloss.value = m.readFloat(GAS(baseAddr, c.SkinBlueGloss));

                if (!CharacterDetails.SkinGreenGloss.freeze) CharacterDetails.SkinGreenGloss.value = m.readFloat(GAS(baseAddr, c.SkinGreenGloss));

                if (!CharacterDetails.SkinRedGloss.freeze) CharacterDetails.SkinRedGloss.value = m.readFloat(GAS(baseAddr, c.SkinRedGloss));

                if (!CharacterDetails.SkinBluePigment.freeze) CharacterDetails.SkinBluePigment.value = m.readFloat(GAS(baseAddr, c.SkinBluePigment));

                if (!CharacterDetails.SkinGreenPigment.freeze) CharacterDetails.SkinGreenPigment.value = m.readFloat(GAS(baseAddr, c.SkinGreenPigment));

                if (!CharacterDetails.SkinRedPigment.freeze) CharacterDetails.SkinRedPigment.value = m.readFloat(GAS(baseAddr, c.SkinRedPigment));

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

                if (!CharacterDetails.StatusEffect.freeze) CharacterDetails.StatusEffect.value = m.read2Byte(GAS(baseAddr, c.StatusEffect));
                if (!CharacterDetails.Weather.freeze) CharacterDetails.Weather.value = (byte)m.readByte(GAS(MemoryManager.Instance.WeatherAddress, c.Weather));
                if (!CharacterDetails.ForceWeather.freeze) CharacterDetails.ForceWeather.value = (ushort)m.read2Byte(GAS(MemoryManager.Instance.GposeFilters, c.ForceWeather));
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
				//MessageBox.Show(ex.Message + "\n" + ex.StackTrace, App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
				mediator.Work -= Work;
                //mediator.Work += Work;
            }
        }
    }
}