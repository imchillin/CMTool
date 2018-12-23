using FFXIVTool.Models;
using FFXIVTool.ViewModel;
using System.ComponentModel;
using System.Threading;

namespace FFXIVTool.Utility
{
    public class ThreadWriting
    {
        public BackgroundWorker worker;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public ThreadWriting()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                while (true)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    var xdad = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType));
                    if (CharacterDetails.BodyType.freeze && !CharacterDetails.BodyType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.BodyType), CharacterDetails.BodyType.GetBytes());
                    if (CharacterDetails.Race.freeze && !CharacterDetails.Race.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), CharacterDetails.Race.GetBytes());
                    if (CharacterDetails.Clan.freeze && !CharacterDetails.Clan.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), CharacterDetails.Clan.GetBytes());
                    if (CharacterDetails.Gender.freeze && !CharacterDetails.Gender.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), CharacterDetails.Gender.GetBytes());
                    if (CharacterDetails.Head.freeze && !CharacterDetails.Head.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), CharacterDetails.Head.GetBytes());
                    if (CharacterDetails.Hair.freeze && !CharacterDetails.Hair.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), CharacterDetails.Hair.GetBytes());
                    if (CharacterDetails.TailType.freeze && !CharacterDetails.TailType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), CharacterDetails.TailType.GetBytes());
                    if (CharacterDetails.HairTone.freeze && !CharacterDetails.HairTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), CharacterDetails.HairTone.GetBytes());
                    if (CharacterDetails.HighlightTone.freeze && !CharacterDetails.HighlightTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
                    if (CharacterDetails.Highlights.freeze && !CharacterDetails.Highlights.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), CharacterDetails.Highlights.GetBytes());
                        if (CharacterDetails.Highlights.value >= 80) CharacterDetails.Highlights.SpecialActivate = true;
                        else CharacterDetails.Highlights.SpecialActivate = false;
                    }
                    if (CharacterDetails.Voices.freeze && !CharacterDetails.Voices.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Voices), CharacterDetails.Voices.GetBytes());
                    if (CharacterDetails.Skintone.freeze && !CharacterDetails.Skintone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), CharacterDetails.Skintone.GetBytes());
                    if (CharacterDetails.Lips.freeze && !CharacterDetails.Lips.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), CharacterDetails.Lips.GetBytes());
                    if (CharacterDetails.LipsTone.freeze && !CharacterDetails.LipsTone.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
                    if (CharacterDetails.Nose.freeze && !CharacterDetails.Nose.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), CharacterDetails.Nose.GetBytes());
                    if (CharacterDetails.FacePaintColor.freeze && !CharacterDetails.FacePaintColor.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                    if (CharacterDetails.FacePaint.freeze && !CharacterDetails.FacePaint.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
                    if (CharacterDetails.LeftEye.freeze && !CharacterDetails.LeftEye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
                    if (CharacterDetails.RightEye.freeze && !CharacterDetails.RightEye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
                    if (CharacterDetails.LimbalEyes.freeze && !CharacterDetails.LimbalEyes.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalEyes), CharacterDetails.LimbalEyes.GetBytes());
                    if (CharacterDetails.Eye.freeze && !CharacterDetails.Eye.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), CharacterDetails.Eye.GetBytes());
                    if (CharacterDetails.EyeBrowType.freeze && !CharacterDetails.EyeBrowType.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), CharacterDetails.EyeBrowType.GetBytes());
                    if (CharacterDetails.FacialFeatures.freeze && !CharacterDetails.FacialFeatures.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
                    if (CharacterDetails.RHeight.freeze && !CharacterDetails.RHeight.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), CharacterDetails.RHeight.GetBytes());
                    if (CharacterDetails.Height.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), CharacterDetails.Height.GetBytes());
                    if (CharacterDetails.RBust.freeze && !CharacterDetails.RBust.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), CharacterDetails.RBust.GetBytes());
                    if (CharacterDetails.Jaw.freeze && !CharacterDetails.Jaw.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), CharacterDetails.Jaw.GetBytes());
                    if (CharacterDetails.TailorMuscle.freeze && !CharacterDetails.TailorMuscle.Activated) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), CharacterDetails.TailorMuscle.GetBytes());
                    if (CharacterDetails.FreezeFacial.Activated) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.FreezeFacial), "float", "0");
                    if (CharacterDetails.Name.freeze)
                    {
                        CharacterDetails.Name.value = CharacterDetails.Name.value.Replace("\0", string.Empty);
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Name), "string", CharacterDetails.Name.value + "\0\0\0\0");
                    }
                    if (CharacterDetails.BustZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), CharacterDetails.BustZ.GetBytes());
                    if (CharacterDetails.BustY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), CharacterDetails.BustY.GetBytes());
                    if (CharacterDetails.BustX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), CharacterDetails.BustX.GetBytes());
                    if (CharacterDetails.Rotation4.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4), CharacterDetails.Rotation4.GetBytes());
                    if (CharacterDetails.Rotation3.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3), CharacterDetails.Rotation3.GetBytes());
                    if (CharacterDetails.Rotation2.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2), CharacterDetails.Rotation2.GetBytes());
                    if (CharacterDetails.Rotation.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation), CharacterDetails.Rotation.GetBytes());
                    if (CharacterDetails.Z.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), CharacterDetails.Z.GetBytes());
                    if (CharacterDetails.Y.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), CharacterDetails.Y.GetBytes());
                    if (CharacterDetails.X.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), CharacterDetails.X.GetBytes());
                    if (CharacterDetails.MuscleTone.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), CharacterDetails.MuscleTone.GetBytes());
                    if (CharacterDetails.TailSize.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), CharacterDetails.TailSize.GetBytes());
                    if (CharacterDetails.Transparency.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Transparency), CharacterDetails.Transparency.GetBytes());
                    if (xdad != 2 && CharacterDetails.ModelType.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ModelType), CharacterDetails.ModelType.GetBytes());
                    if (CharacterDetails.CamX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), CharacterDetails.CamX.GetBytes());
                    if (CharacterDetails.CamY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), CharacterDetails.CamY.GetBytes());
                    if (CharacterDetails.CamZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), CharacterDetails.CamZ.GetBytes());
                    if (CharacterDetails.CameraUpDown.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), CharacterDetails.CameraUpDown.GetBytes());
                    if (CharacterDetails.FOV2.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), CharacterDetails.FOV2.GetBytes());
                    if (CharacterDetails.CameraYAMax.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), CharacterDetails.CameraYAMax.GetBytes());
                    if (CharacterDetails.CameraYAMin.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), CharacterDetails.CameraYAMin.GetBytes());
                    if (CharacterDetails.CameraHeight2.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight2), CharacterDetails.CameraHeight2.GetBytes());
                    if (CharacterDetails.CameraHeight.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight), CharacterDetails.CameraHeight.GetBytes());
                    if (CharacterDetails.CamX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), CharacterDetails.CamX.GetBytes());
                    if (CharacterDetails.CamY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), CharacterDetails.CamY.GetBytes());
                    if (CharacterDetails.CamZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), CharacterDetails.CamZ.GetBytes());
                    if (CharacterDetails.Weather.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather), CharacterDetails.Weather.GetBytes());
                    if (CharacterDetails.SkinRedPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), CharacterDetails.SkinRedPigment.GetBytes());
                    if (CharacterDetails.SkinGreenPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), CharacterDetails.SkinGreenPigment.GetBytes());
                    if (CharacterDetails.SkinBluePigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), CharacterDetails.SkinBluePigment.GetBytes());
                    if (CharacterDetails.SkinRedGloss.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), CharacterDetails.SkinRedGloss.GetBytes());
                    if (CharacterDetails.SkinGreenGloss.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), CharacterDetails.SkinGreenGloss.GetBytes());
                    if (CharacterDetails.SkinBlueGloss.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), CharacterDetails.SkinBlueGloss.GetBytes());
                    if (CharacterDetails.HairRedPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), CharacterDetails.HairRedPigment.GetBytes());
                    if (CharacterDetails.HairGreenPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), CharacterDetails.HairGreenPigment.GetBytes());
                    if (CharacterDetails.HairBluePigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), CharacterDetails.HairBluePigment.GetBytes());
                    if (CharacterDetails.HairGlowRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), CharacterDetails.HairGlowRed.GetBytes());
                    if (CharacterDetails.HairGlowGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), CharacterDetails.HairGlowGreen.GetBytes());
                    if (CharacterDetails.HairGlowBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), CharacterDetails.HairGlowBlue.GetBytes());
                    if (CharacterDetails.HighlightRedPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), CharacterDetails.HighlightRedPigment.GetBytes());
                    if (CharacterDetails.HighlightGreenPigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), CharacterDetails.HighlightGreenPigment.GetBytes());
                    if (CharacterDetails.HighlightBluePigment.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), CharacterDetails.HighlightBluePigment.GetBytes());
                    if (CharacterDetails.LeftEyeRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), CharacterDetails.LeftEyeRed.GetBytes());
                    if (CharacterDetails.LeftEyeGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), CharacterDetails.LeftEyeGreen.GetBytes());
                    if (CharacterDetails.LeftEyeBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), CharacterDetails.LeftEyeBlue.GetBytes());
                    if (CharacterDetails.RightEyeRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), CharacterDetails.RightEyeRed.GetBytes());
                    if (CharacterDetails.RightEyeGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), CharacterDetails.RightEyeGreen.GetBytes());
                    if (CharacterDetails.RightEyeBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), CharacterDetails.RightEyeBlue.GetBytes());
                    if (CharacterDetails.LipsBrightness.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), CharacterDetails.LipsBrightness.GetBytes());
                    if (CharacterDetails.LipsR.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), CharacterDetails.LipsR.GetBytes());
                    if (CharacterDetails.LipsG.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), CharacterDetails.LipsG.GetBytes());
                    if (CharacterDetails.LipsB.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), CharacterDetails.LipsB.GetBytes());
                    if (CharacterDetails.ScaleZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Z), CharacterDetails.ScaleZ.GetBytes());
                    if (CharacterDetails.ScaleY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Y), CharacterDetails.ScaleY.GetBytes());
                    if (CharacterDetails.ScaleX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.X), CharacterDetails.ScaleX.GetBytes());
                    if (CharacterDetails.LimbalR.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), CharacterDetails.LimbalR.GetBytes());
                    if (CharacterDetails.LimbalB.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), CharacterDetails.LimbalB.GetBytes());
                    if (CharacterDetails.LimbalG.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), CharacterDetails.LimbalG.GetBytes());
                    if (CharacterDetails.Wetness.Activated) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Wetness), "float", "1");
                    if (CharacterDetails.SWetness.Activated) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.SWetness), "float", "5");
                    if (CharacterDetails.OffhandRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), CharacterDetails.OffhandRed.GetBytes());
                    if (CharacterDetails.OffhandGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), CharacterDetails.OffhandGreen.GetBytes());
                    if (CharacterDetails.OffhandBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), CharacterDetails.OffhandBlue.GetBytes());
                    if (CharacterDetails.OffhandX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), CharacterDetails.OffhandX.GetBytes());
                    if (CharacterDetails.OffhandY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), CharacterDetails.OffhandY.GetBytes());
                    if (CharacterDetails.OffhandZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), CharacterDetails.OffhandZ.GetBytes());
                    if (CharacterDetails.WeaponX.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), CharacterDetails.WeaponX.GetBytes());
                    if (CharacterDetails.WeaponY.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), CharacterDetails.WeaponY.GetBytes());
                    if (CharacterDetails.WeaponZ.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), CharacterDetails.WeaponZ.GetBytes());
                    if (CharacterDetails.WeaponBlue.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), CharacterDetails.WeaponBlue.GetBytes());
                    if (CharacterDetails.WeaponGreen.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), CharacterDetails.WeaponGreen.GetBytes());
                    if (CharacterDetails.WeaponRed.freeze) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), CharacterDetails.WeaponRed.GetBytes());
                    if (CharacterDetails.FOVMAX.freeze)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX), CharacterDetails.FOVMAX.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC), CharacterDetails.FOVC.GetBytes());
                    }
                    if (CharacterDetails.Max.freeze && CharacterDetailsViewModel.NotAllowed == false) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max), CharacterDetails.Max.GetBytes());
                    if (CharacterDetails.Min.freeze && CharacterDetailsViewModel.NotAllowed == false) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min), CharacterDetails.Min.GetBytes());
                    if (CharacterDetails.CZoom.freeze && CharacterDetailsViewModel.NotAllowed == false) MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom), CharacterDetails.CZoom.GetBytes());

                    if (CharacterDetails.Job.freeze && !CharacterDetails.Job.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), CharacterDetails.Job.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase), CharacterDetails.WeaponBase.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV), CharacterDetails.WeaponV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye), CharacterDetails.WeaponDye.GetBytes());
                    }
                    if (CharacterDetails.Offhand.freeze && !CharacterDetails.Offhand.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), CharacterDetails.Offhand.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBase), CharacterDetails.OffhandBase.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), CharacterDetails.OffhandV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandDye), CharacterDetails.OffhandDye.GetBytes());
                    }
                    if (CharacterDetails.HeadPiece.freeze && !CharacterDetails.HeadPiece.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), CharacterDetails.HeadPiece.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV), CharacterDetails.HeadV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye), CharacterDetails.HeadDye.GetBytes());
                    }
                    if (CharacterDetails.Chest.freeze && !CharacterDetails.Chest.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), CharacterDetails.Chest.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV), CharacterDetails.ChestV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye), CharacterDetails.ChestDye.GetBytes());
                    }
                    if (CharacterDetails.Arms.freeze && !CharacterDetails.Arms.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), CharacterDetails.Arms.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV), CharacterDetails.ArmsV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye), CharacterDetails.ArmsDye.GetBytes());
                    }
                    if (CharacterDetails.Legs.freeze && !CharacterDetails.Legs.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), CharacterDetails.Legs.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV), CharacterDetails.LegsV.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye), CharacterDetails.LegsDye.GetBytes());
                    }
                    if (CharacterDetails.Feet.freeze && !CharacterDetails.Feet.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), CharacterDetails.Feet.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa), CharacterDetails.FeetVa.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye), CharacterDetails.FeetDye.GetBytes());
                    }
                    if (CharacterDetails.LFinger.freeze && !CharacterDetails.LFinger.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), CharacterDetails.LFinger.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa), CharacterDetails.LFingerVa.GetBytes());
                    }
                    if (CharacterDetails.RFinger.freeze && !CharacterDetails.RFinger.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), CharacterDetails.RFinger.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa), CharacterDetails.RFingerVa.GetBytes());
                    }
                    if (CharacterDetails.Wrist.freeze && !CharacterDetails.Wrist.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), CharacterDetails.Wrist.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa), CharacterDetails.WristVa.GetBytes());
                    }
                    if (CharacterDetails.Neck.freeze && !CharacterDetails.Neck.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), CharacterDetails.Neck.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa), CharacterDetails.NeckVa.GetBytes());
                    }
                    if (CharacterDetails.Ear.freeze && !CharacterDetails.Ear.Activated)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), CharacterDetails.Ear.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa), CharacterDetails.EarVa.GetBytes());
                    }
                    if (CharacterDetails.EmoteSpeed1.freeze)
                    {
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed1), CharacterDetails.EmoteSpeed1.GetBytes());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.EmoteSpeed2), CharacterDetails.EmoteSpeed1.GetBytes());
                    }
                    if (CharacterDetails.Emote.freeze)
                    {
                        if (CharacterDetails.Emote.value > 7121) CharacterDetails.Emote.value = 7121;
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.EmoteAddress, Settings.Instance.Character.Emote), CharacterDetails.Emote.GetBytes());
                    }
                    if (CharacterDetails.EmoteX.freeze)
                    {
                        if (CharacterDetails.EmoteX.value > 7121) CharacterDetails.EmoteX.value = 7121;
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Emote), CharacterDetails.EmoteX.GetBytes());
                    }
                    Thread.Sleep(9);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Oh no! - Screencap this and send to Johto!");
                worker.CancelAsync();
            }
        }
    }
}
