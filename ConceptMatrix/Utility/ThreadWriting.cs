using ConceptMatrix.Models;
using ConceptMatrix.ViewModel;
using System;
using System.ComponentModel;
using System.Threading;

namespace ConceptMatrix.Utility
{
    public class ThreadWriting
    {
        private readonly Mem m = MemoryManager.Instance.MemLib;
        private CharacterOffsets c = Settings.Instance.Character;
        private string GAS(params string[] args) => MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, args);
        private string GASG(params string[] args) => MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, args);

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
                    var xdad = (byte)m.readByte(GAS(c.EntityType));

                    #region Skeletal Rotations
                    HeadBones();
                    UpperBodyBones();
                    FingerBones();
                    LowerBodyBones();
                    MiscBones();
                    #endregion

                    if (CharacterDetails.BodyType.freeze && !CharacterDetails.BodyType.Activated) m.writeBytes(GAS(c.BodyType), CharacterDetails.BodyType.GetBytes());
                    if (CharacterDetails.Title.freeze && !CharacterDetails.Title.Activated) m.writeBytes(GAS(c.Title), CharacterDetails.Title.GetBytes());
                    if (CharacterDetails.JobIco.freeze && !CharacterDetails.JobIco.Activated) m.writeBytes(GAS(c.JobIco), CharacterDetails.JobIco.GetBytes());
                    if (CharacterDetails.Race.freeze && !CharacterDetails.Race.Activated) m.writeBytes(GAS(c.Race), CharacterDetails.Race.GetBytes());
                    if (CharacterDetails.Clan.freeze && !CharacterDetails.Clan.Activated) m.writeBytes(GAS(c.Clan), CharacterDetails.Clan.GetBytes());
                    if (CharacterDetails.Gender.freeze && !CharacterDetails.Gender.Activated) m.writeBytes(GAS(c.Gender), CharacterDetails.Gender.GetBytes());
                    if (CharacterDetails.Head.freeze && !CharacterDetails.Head.Activated) m.writeBytes(GAS(c.Head), CharacterDetails.Head.GetBytes());
                    if (CharacterDetails.Hair.freeze && !CharacterDetails.Hair.Activated) m.writeBytes(GAS(c.Hair), CharacterDetails.Hair.GetBytes());
                    if (CharacterDetails.TailType.freeze && !CharacterDetails.TailType.Activated) m.writeBytes(GAS(c.TailType), CharacterDetails.TailType.GetBytes());
                    if (CharacterDetails.HairTone.freeze && !CharacterDetails.HairTone.Activated) m.writeBytes(GAS(c.HairTone), CharacterDetails.HairTone.GetBytes());
                    if (CharacterDetails.HighlightTone.freeze && !CharacterDetails.HighlightTone.Activated) m.writeBytes(GAS(c.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
                    if (CharacterDetails.Highlights.freeze && !CharacterDetails.Highlights.Activated)
                    {
                        m.writeBytes(GAS(c.Highlights), CharacterDetails.Highlights.GetBytes());
                        if (CharacterDetails.Highlights.value >= 80) CharacterDetails.Highlights.SpecialActivate = true;
                        else CharacterDetails.Highlights.SpecialActivate = false;
                    }
                    if (CharacterDetails.EntityType.freeze && !CharacterDetails.EntityType.Activated) m.writeBytes(GAS(c.EntityType), CharacterDetails.EntityType.GetBytes());
                    if (CharacterDetails.Voices.freeze && !CharacterDetails.Voices.Activated) m.writeBytes(GAS(c.Voices), CharacterDetails.Voices.GetBytes());
                    if (CharacterDetails.Skintone.freeze && !CharacterDetails.Skintone.Activated) m.writeBytes(GAS(c.Skintone), CharacterDetails.Skintone.GetBytes());
                    if (CharacterDetails.Lips.freeze && !CharacterDetails.Lips.Activated) m.writeBytes(GAS(c.Lips), CharacterDetails.Lips.GetBytes());
                    if (CharacterDetails.LipsTone.freeze && !CharacterDetails.LipsTone.Activated) m.writeBytes(GAS(c.LipsTone), CharacterDetails.LipsTone.GetBytes());
                    if (CharacterDetails.Nose.freeze && !CharacterDetails.Nose.Activated) m.writeBytes(GAS(c.Nose), CharacterDetails.Nose.GetBytes());
                    if (CharacterDetails.FacePaintColor.freeze && !CharacterDetails.FacePaintColor.Activated) m.writeBytes(GAS(c.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                    if (CharacterDetails.FacePaint.freeze && !CharacterDetails.FacePaint.Activated) m.writeBytes(GAS(c.FacePaint), CharacterDetails.FacePaint.GetBytes());
                    if (CharacterDetails.LeftEye.freeze && !CharacterDetails.LeftEye.Activated) m.writeBytes(GAS(c.LeftEye), CharacterDetails.LeftEye.GetBytes());
                    if (CharacterDetails.RightEye.freeze && !CharacterDetails.RightEye.Activated) m.writeBytes(GAS(c.RightEye), CharacterDetails.RightEye.GetBytes());
                    if (CharacterDetails.LimbalEyes.freeze && !CharacterDetails.LimbalEyes.Activated) m.writeBytes(GAS(c.LimbalEyes), CharacterDetails.LimbalEyes.GetBytes());
                    if (CharacterDetails.Eye.freeze && !CharacterDetails.Eye.Activated) m.writeBytes(GAS(c.Eye), CharacterDetails.Eye.GetBytes());
                    if (CharacterDetails.EyeBrowType.freeze && !CharacterDetails.EyeBrowType.Activated) m.writeBytes(GAS(c.EyeBrowType), CharacterDetails.EyeBrowType.GetBytes());
                    if (CharacterDetails.FacialFeatures.freeze && !CharacterDetails.FacialFeatures.Activated) m.writeBytes(GAS(c.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
                    if (CharacterDetails.RHeight.freeze && !CharacterDetails.RHeight.Activated) m.writeBytes(GAS(c.RHeight), CharacterDetails.RHeight.GetBytes());
                    if (CharacterDetails.Height.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Height), CharacterDetails.Height.GetBytes());
                    if (CharacterDetails.RBust.freeze && !CharacterDetails.RBust.Activated) m.writeBytes(GAS(c.RBust), CharacterDetails.RBust.GetBytes());
                    if (CharacterDetails.Jaw.freeze && !CharacterDetails.Jaw.Activated) m.writeBytes(GAS(c.Jaw), CharacterDetails.Jaw.GetBytes());
                    if (CharacterDetails.TailorMuscle.freeze && !CharacterDetails.TailorMuscle.Activated) m.writeBytes(GAS(c.TailorMuscle), CharacterDetails.TailorMuscle.GetBytes());
                    if (CharacterDetails.FreezeFacial.Activated) m.writeMemory(GAS(c.FreezeFacial), "float", "0");
                    if (CharacterDetails.DataPath.freeze && !CharacterDetails.DataPath.Activated)
                    {
                        m.writeBytes(GAS(c.DataPath), CharacterDetails.DataPath.GetBytes());
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

                    if (CharacterDetails.NPCName.freeze && !CharacterDetails.NPCName.Activated) m.writeBytes(GAS(c.NPCName), CharacterDetails.NPCName.GetBytes());
                    if (CharacterDetails.NPCModel.freeze && !CharacterDetails.NPCModel.Activated) m.writeBytes(GAS(c.NPCModel), CharacterDetails.NPCModel.GetBytes());
                    if (CharacterDetails.Name.freeze)
                    {
                        CharacterDetails.Name.value = CharacterDetails.Name.value.Replace("\0", string.Empty);
                        m.writeMemory(GAS(c.Name), "string", CharacterDetails.Name.value + "\0\0\0\0");
                    }
                    if (CharacterDetails.FCTag.freeze)
                    {
                        CharacterDetails.FCTag.value = CharacterDetails.FCTag.value.Replace("\0", string.Empty);
                        if (xdad == 1)
                            m.writeMemory(GAS(c.FCTag), "string", CharacterDetails.FCTag.value + "\0\0\0\0");
                    }
                    if (CharacterDetails.BustZ.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Bust.Base, c.Body.Bust.Z), CharacterDetails.BustZ.GetBytes());
                    if (CharacterDetails.BustY.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Bust.Base, c.Body.Bust.Y), CharacterDetails.BustY.GetBytes());
                    if (CharacterDetails.BustX.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Bust.Base, c.Body.Bust.X), CharacterDetails.BustX.GetBytes());

                    if (CharacterDetails.RotateFreeze)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Position.Rotation), CharacterDetails.Rotation.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Position.Rotation2), CharacterDetails.Rotation2.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Position.Rotation3), CharacterDetails.Rotation3.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Position.Rotation4), CharacterDetails.Rotation4.GetBytes());
                    }

                    if (CharacterDetails.Z.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Position.Z), CharacterDetails.Z.GetBytes());
                    if (CharacterDetails.Y.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Position.Y), CharacterDetails.Y.GetBytes());
                    if (CharacterDetails.X.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Position.X), CharacterDetails.X.GetBytes());
                    if (CharacterDetails.MuscleTone.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.MuscleTone), CharacterDetails.MuscleTone.GetBytes());
                    if (CharacterDetails.TailSize.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.TailSize), CharacterDetails.TailSize.GetBytes());
                    if (CharacterDetails.Transparency.freeze) m.writeBytes(GAS(c.Transparency), CharacterDetails.Transparency.GetBytes());
                    if (CharacterDetails.ModelType.freeze) m.writeBytes(GAS(c.ModelType), CharacterDetails.ModelType.GetBytes());

                    if (CharacterDetails.CamX.freeze) m.writeBytes(GASG(MemoryManager.Instance.GposeAddress, c.CamX), CharacterDetails.CamX.GetBytes());
                    if (CharacterDetails.CamY.freeze) m.writeBytes(GASG(MemoryManager.Instance.GposeAddress, c.CamY), CharacterDetails.CamY.GetBytes());
                    if (CharacterDetails.CamZ.freeze) m.writeBytes(GASG(MemoryManager.Instance.GposeAddress, c.CamZ), CharacterDetails.CamZ.GetBytes());

                    if (CharacterDetails.CamViewX.freeze) m.writeBytes(GAS(c.CamViewX), CharacterDetails.CamViewX.GetBytes());
                    if (CharacterDetails.CamViewY.freeze) m.writeBytes(GAS(c.CamViewY), CharacterDetails.CamViewY.GetBytes());
                    if (CharacterDetails.CamViewZ.freeze) m.writeBytes(GAS(c.CamViewZ), CharacterDetails.CamViewZ.GetBytes());

                    if (CharacterDetails.StatusEffect.freeze) m.writeBytes(GASG(c.StatusEffect), CharacterDetails.StatusEffect.GetBytes());
                    if (CharacterDetails.CameraUpDown.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.CameraUpDown), CharacterDetails.CameraUpDown.GetBytes());
                    if (CharacterDetails.FOV2.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.FOV2), CharacterDetails.FOV2.GetBytes());
                    if (CharacterDetails.CameraYAMax.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.CameraYAMax), CharacterDetails.CameraYAMax.GetBytes());
                    if (CharacterDetails.CameraYAMin.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.CameraYAMin), CharacterDetails.CameraYAMin.GetBytes());
                    if (CharacterDetails.CameraHeight2.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.CameraHeight2), CharacterDetails.CameraHeight2.GetBytes());
                    if (CharacterDetails.Weather.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, c.Weather), CharacterDetails.Weather.GetBytes());
                    if (CharacterDetails.ForceWeather.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.GposeFilters, c.ForceWeather), CharacterDetails.ForceWeather.GetBytes());
                    if (CharacterDetails.SkinRedPigment.freeze) m.writeBytes(GAS(c.SkinRedPigment), CharacterDetails.SkinRedPigment.GetBytes());
                    if (CharacterDetails.SkinGreenPigment.freeze) m.writeBytes(GAS(c.SkinGreenPigment), CharacterDetails.SkinGreenPigment.GetBytes());
                    if (CharacterDetails.SkinBluePigment.freeze) m.writeBytes(GAS(c.SkinBluePigment), CharacterDetails.SkinBluePigment.GetBytes());
                    if (CharacterDetails.SkinRedGloss.freeze) m.writeBytes(GAS(c.SkinRedGloss), CharacterDetails.SkinRedGloss.GetBytes());
                    if (CharacterDetails.SkinGreenGloss.freeze) m.writeBytes(GAS(c.SkinGreenGloss), CharacterDetails.SkinGreenGloss.GetBytes());
                    if (CharacterDetails.SkinBlueGloss.freeze) m.writeBytes(GAS(c.SkinBlueGloss), CharacterDetails.SkinBlueGloss.GetBytes());
                    if (CharacterDetails.HairRedPigment.freeze) m.writeBytes(GAS(c.HairRedPigment), CharacterDetails.HairRedPigment.GetBytes());
                    if (CharacterDetails.HairGreenPigment.freeze) m.writeBytes(GAS(c.HairGreenPigment), CharacterDetails.HairGreenPigment.GetBytes());
                    if (CharacterDetails.HairBluePigment.freeze) m.writeBytes(GAS(c.HairBluePigment), CharacterDetails.HairBluePigment.GetBytes());
                    if (CharacterDetails.HairGlowRed.freeze) m.writeBytes(GAS(c.HairGlowRed), CharacterDetails.HairGlowRed.GetBytes());
                    if (CharacterDetails.HairGlowGreen.freeze) m.writeBytes(GAS(c.HairGlowGreen), CharacterDetails.HairGlowGreen.GetBytes());
                    if (CharacterDetails.HairGlowBlue.freeze) m.writeBytes(GAS(c.HairGlowBlue), CharacterDetails.HairGlowBlue.GetBytes());
                    if (CharacterDetails.HighlightRedPigment.freeze) m.writeBytes(GAS(c.HighlightRedPigment), CharacterDetails.HighlightRedPigment.GetBytes());
                    if (CharacterDetails.HighlightGreenPigment.freeze) m.writeBytes(GAS(c.HighlightGreenPigment), CharacterDetails.HighlightGreenPigment.GetBytes());
                    if (CharacterDetails.HighlightBluePigment.freeze) m.writeBytes(GAS(c.HighlightBluePigment), CharacterDetails.HighlightBluePigment.GetBytes());
                    if (CharacterDetails.LeftEyeRed.freeze) m.writeBytes(GAS(c.LeftEyeRed), CharacterDetails.LeftEyeRed.GetBytes());
                    if (CharacterDetails.LeftEyeGreen.freeze) m.writeBytes(GAS(c.LeftEyeGreen), CharacterDetails.LeftEyeGreen.GetBytes());
                    if (CharacterDetails.LeftEyeBlue.freeze) m.writeBytes(GAS(c.LeftEyeBlue), CharacterDetails.LeftEyeBlue.GetBytes());
                    if (CharacterDetails.RightEyeRed.freeze) m.writeBytes(GAS(c.RightEyeRed), CharacterDetails.RightEyeRed.GetBytes());
                    if (CharacterDetails.RightEyeGreen.freeze) m.writeBytes(GAS(c.RightEyeGreen), CharacterDetails.RightEyeGreen.GetBytes());
                    if (CharacterDetails.RightEyeBlue.freeze) m.writeBytes(GAS(c.RightEyeBlue), CharacterDetails.RightEyeBlue.GetBytes());
                    if (CharacterDetails.LipsBrightness.freeze) m.writeBytes(GAS(c.LipsBrightness), CharacterDetails.LipsBrightness.GetBytes());
                    if (CharacterDetails.LipsR.freeze) m.writeBytes(GAS(c.LipsR), CharacterDetails.LipsR.GetBytes());
                    if (CharacterDetails.LipsG.freeze) m.writeBytes(GAS(c.LipsG), CharacterDetails.LipsG.GetBytes());
                    if (CharacterDetails.LipsB.freeze) m.writeBytes(GAS(c.LipsB), CharacterDetails.LipsB.GetBytes());
                    if (CharacterDetails.ScaleZ.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Scale.Z), CharacterDetails.ScaleZ.GetBytes());
                    if (CharacterDetails.ScaleY.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Scale.Y), CharacterDetails.ScaleY.GetBytes());
                    if (CharacterDetails.ScaleX.freeze) m.writeBytes(GAS(c.Body.Base, c.Body.Scale.X), CharacterDetails.ScaleX.GetBytes());
                    if (CharacterDetails.LimbalR.freeze) m.writeBytes(GAS(c.LimbalR), CharacterDetails.LimbalR.GetBytes());
                    if (CharacterDetails.LimbalB.freeze) m.writeBytes(GAS(c.LimbalB), CharacterDetails.LimbalB.GetBytes());
                    if (CharacterDetails.LimbalG.freeze) m.writeBytes(GAS(c.LimbalG), CharacterDetails.LimbalG.GetBytes());
                    if (CharacterDetails.Wetness.Activated) m.writeMemory(GAS(c.Body.Base, c.Body.Wetness), "float", "1");
                    if (CharacterDetails.SWetness.Activated) m.writeMemory(GAS(c.Body.Base, c.Body.SWetness), "float", "5");
                    if (CharacterDetails.OffhandRed.freeze) m.writeBytes(GAS(c.OffhandRed), CharacterDetails.OffhandRed.GetBytes());
                    if (CharacterDetails.OffhandGreen.freeze) m.writeBytes(GAS(c.OffhandGreen), CharacterDetails.OffhandGreen.GetBytes());
                    if (CharacterDetails.OffhandBlue.freeze) m.writeBytes(GAS(c.OffhandBlue), CharacterDetails.OffhandBlue.GetBytes());
                    if (CharacterDetails.OffhandX.freeze) m.writeBytes(GAS(c.OffhandX), CharacterDetails.OffhandX.GetBytes());
                    if (CharacterDetails.OffhandY.freeze) m.writeBytes(GAS(c.OffhandY), CharacterDetails.OffhandY.GetBytes());
                    if (CharacterDetails.OffhandZ.freeze) m.writeBytes(GAS(c.OffhandZ), CharacterDetails.OffhandZ.GetBytes());
                    if (CharacterDetails.WeaponX.freeze) m.writeBytes(GAS(c.WeaponX), CharacterDetails.WeaponX.GetBytes());
                    if (CharacterDetails.WeaponY.freeze) m.writeBytes(GAS(c.WeaponY), CharacterDetails.WeaponY.GetBytes());
                    if (CharacterDetails.WeaponZ.freeze) m.writeBytes(GAS(c.WeaponZ), CharacterDetails.WeaponZ.GetBytes());
                    if (CharacterDetails.WeaponBlue.freeze) m.writeBytes(GAS(c.WeaponBlue), CharacterDetails.WeaponBlue.GetBytes());
                    if (CharacterDetails.WeaponGreen.freeze) m.writeBytes(GAS(c.WeaponGreen), CharacterDetails.WeaponGreen.GetBytes());
                    if (CharacterDetails.WeaponRed.freeze) m.writeBytes(GAS(c.WeaponRed), CharacterDetails.WeaponRed.GetBytes());
                    if (CharacterDetails.FOVMAX.freeze)
                    {
                        m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.FOVMAX), CharacterDetails.FOVMAX.GetBytes());
                        m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.FOVC), CharacterDetails.FOVC.GetBytes());
                    }
                    if (CharacterDetails.Max.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.Max), CharacterDetails.Max.GetBytes());
                    if (CharacterDetails.Min.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.Min), CharacterDetails.Min.GetBytes());
                    if (CharacterDetails.CZoom.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.CZoom), CharacterDetails.CZoom.GetBytes());
                    if (CharacterDetails.CamAngleX.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.CamAngleX), CharacterDetails.CamAngleX.GetBytes());
                    if (CharacterDetails.CamAngleY.freeze) m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, c.CamAngleY), CharacterDetails.CamAngleY.GetBytes());

                    if (CharacterDetails.Job.freeze && !CharacterDetails.Job.Activated)
                    {
                        m.writeBytes(GAS(c.Job), CharacterDetails.Job.GetBytes());
                        m.writeBytes(GAS(c.WeaponBase), CharacterDetails.WeaponBase.GetBytes());
                        m.writeBytes(GAS(c.WeaponV), CharacterDetails.WeaponV.GetBytes());
                        m.writeBytes(GAS(c.WeaponDye), CharacterDetails.WeaponDye.GetBytes());
                    }
                    if (CharacterDetails.Offhand.freeze && !CharacterDetails.Offhand.Activated)
                    {
                        m.writeBytes(GAS(c.Offhand), CharacterDetails.Offhand.GetBytes());
                        m.writeBytes(GAS(c.OffhandBase), CharacterDetails.OffhandBase.GetBytes());
                        m.writeBytes(GAS(c.OffhandV), CharacterDetails.OffhandV.GetBytes());
                        m.writeBytes(GAS(c.OffhandDye), CharacterDetails.OffhandDye.GetBytes());
                    }
                    if (CharacterDetails.HeadPiece.freeze && !CharacterDetails.HeadPiece.Activated)
                    {
                        m.writeBytes(GAS(c.HeadPiece), CharacterDetails.HeadPiece.GetBytes());
                        m.writeBytes(GAS(c.HeadV), CharacterDetails.HeadV.GetBytes());
                        m.writeBytes(GAS(c.HeadDye), CharacterDetails.HeadDye.GetBytes());
                    }
                    if (CharacterDetails.Chest.freeze && !CharacterDetails.Chest.Activated)
                    {
                        m.writeBytes(GAS(c.Chest), CharacterDetails.Chest.GetBytes());
                        m.writeBytes(GAS(c.ChestV), CharacterDetails.ChestV.GetBytes());
                        m.writeBytes(GAS(c.ChestDye), CharacterDetails.ChestDye.GetBytes());
                    }
                    if (CharacterDetails.Arms.freeze && !CharacterDetails.Arms.Activated)
                    {
                        m.writeBytes(GAS(c.Arms), CharacterDetails.Arms.GetBytes());
                        m.writeBytes(GAS(c.ArmsV), CharacterDetails.ArmsV.GetBytes());
                        m.writeBytes(GAS(c.ArmsDye), CharacterDetails.ArmsDye.GetBytes());
                    }
                    if (CharacterDetails.Legs.freeze && !CharacterDetails.Legs.Activated)
                    {
                        m.writeBytes(GAS(c.Legs), CharacterDetails.Legs.GetBytes());
                        m.writeBytes(GAS(c.LegsV), CharacterDetails.LegsV.GetBytes());
                        m.writeBytes(GAS(c.LegsDye), CharacterDetails.LegsDye.GetBytes());
                    }
                    if (CharacterDetails.Feet.freeze && !CharacterDetails.Feet.Activated)
                    {
                        m.writeBytes(GAS(c.Feet), CharacterDetails.Feet.GetBytes());
                        m.writeBytes(GAS(c.FeetVa), CharacterDetails.FeetVa.GetBytes());
                        m.writeBytes(GAS(c.FeetDye), CharacterDetails.FeetDye.GetBytes());
                    }
                    if (CharacterDetails.LFinger.freeze && !CharacterDetails.LFinger.Activated)
                    {
                        m.writeBytes(GAS(c.LFinger), CharacterDetails.LFinger.GetBytes());
                        m.writeBytes(GAS(c.LFingerVa), CharacterDetails.LFingerVa.GetBytes());
                    }
                    if (CharacterDetails.RFinger.freeze && !CharacterDetails.RFinger.Activated)
                    {
                        m.writeBytes(GAS(c.RFinger), CharacterDetails.RFinger.GetBytes());
                        m.writeBytes(GAS(c.RFingerVa), CharacterDetails.RFingerVa.GetBytes());
                    }
                    if (CharacterDetails.Wrist.freeze && !CharacterDetails.Wrist.Activated)
                    {
                        m.writeBytes(GAS(c.Wrist), CharacterDetails.Wrist.GetBytes());
                        m.writeBytes(GAS(c.WristVa), CharacterDetails.WristVa.GetBytes());
                    }
                    if (CharacterDetails.Neck.freeze && !CharacterDetails.Neck.Activated)
                    {
                        m.writeBytes(GAS(c.Neck), CharacterDetails.Neck.GetBytes());
                        m.writeBytes(GAS(c.NeckVa), CharacterDetails.NeckVa.GetBytes());
                    }
                    if (CharacterDetails.Ear.freeze && !CharacterDetails.Ear.Activated)
                    {
                        m.writeBytes(GAS(c.Ear), CharacterDetails.Ear.GetBytes());
                        m.writeBytes(GAS(c.EarVa), CharacterDetails.EarVa.GetBytes());
                    }
                    if (CharacterDetails.MusicBGM.freeze)
                    {
                        m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.MusicOffset, c.Music2), CharacterDetails.MusicBGM.GetBytes());
                        m.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.MusicOffset, c.Music), CharacterDetails.MusicBGM.GetBytes());
                    }
                    if (CharacterDetails.EmoteSpeed1.freeze)
                    {
                        m.writeBytes(GAS(c.EmoteSpeed1), CharacterDetails.EmoteSpeed1.GetBytes());
                        m.writeBytes(GAS(c.EmoteSpeed2), CharacterDetails.EmoteSpeed1.GetBytes());
                    }
                    if (CharacterDetails.Emote.freeze)
                    {
                        if (CharacterDetails.Emote.value > 7736) CharacterDetails.Emote.value = 7736;
                        m.writeBytes(GAS(c.Emote), CharacterDetails.Emote.GetBytes());
                    }
                    if (CharacterDetails.EmoteOld.freeze)
                    {
                        if (CharacterDetails.EmoteOld.value > 7736) CharacterDetails.EmoteOld.value = 7736;
                        m.writeBytes(GAS(c.EmoteOld), CharacterDetails.EmoteOld.GetBytes());
                    }
                    Thread.Sleep(9);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Oh no!");
                worker.CancelAsync();
            }
        }
        private void HeadBones()
        {
            if (CharacterDetails.HeadRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.HeadX), CharacterDetails.HeadX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.HeadY), CharacterDetails.HeadY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.HeadZ), CharacterDetails.HeadZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.HeadW), CharacterDetails.HeadW.GetBytes());
            }

            if (CharacterDetails.NoseRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NoseX), CharacterDetails.NoseX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NoseY), CharacterDetails.NoseY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NoseZ), CharacterDetails.NoseZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NoseW), CharacterDetails.NoseW.GetBytes());
            }

            if (CharacterDetails.NostrilsRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NostrilsX), CharacterDetails.NostrilsX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NostrilsY), CharacterDetails.NostrilsY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NostrilsZ), CharacterDetails.NostrilsZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NostrilsW), CharacterDetails.NostrilsW.GetBytes());
            }

            if (CharacterDetails.ChinRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.ChinX), CharacterDetails.ChinX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.ChinY), CharacterDetails.ChinY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.ChinZ), CharacterDetails.ChinZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.ChinW), CharacterDetails.ChinW.GetBytes());
            }

            if (CharacterDetails.LOutEyebrowRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LOutEyebrowX), CharacterDetails.LOutEyebrowX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LOutEyebrowY), CharacterDetails.LOutEyebrowY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LOutEyebrowZ), CharacterDetails.LOutEyebrowZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LOutEyebrowW), CharacterDetails.LOutEyebrowW.GetBytes());
            }

            if (CharacterDetails.ROutEyebrowRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.ROutEyebrowX), CharacterDetails.ROutEyebrowX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.ROutEyebrowY), CharacterDetails.ROutEyebrowY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.ROutEyebrowZ), CharacterDetails.ROutEyebrowZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.ROutEyebrowW), CharacterDetails.ROutEyebrowW.GetBytes());
            }

            if (CharacterDetails.LInEyebrowRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LInEyebrowX), CharacterDetails.LInEyebrowX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LInEyebrowY), CharacterDetails.LInEyebrowY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LInEyebrowZ), CharacterDetails.LInEyebrowZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LInEyebrowW), CharacterDetails.LInEyebrowW.GetBytes());
            }

            if (CharacterDetails.RInEyebrowRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RInEyebrowX), CharacterDetails.RInEyebrowX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RInEyebrowY), CharacterDetails.RInEyebrowY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RInEyebrowZ), CharacterDetails.RInEyebrowZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RInEyebrowW), CharacterDetails.RInEyebrowW.GetBytes());
            }

            if (CharacterDetails.LEyeRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEyeX), CharacterDetails.LEyeX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEyeY), CharacterDetails.LEyeY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEyeZ), CharacterDetails.LEyeZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEyeW), CharacterDetails.LEyeW.GetBytes());
            }

            if (CharacterDetails.REyeRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REyeX), CharacterDetails.REyeX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REyeY), CharacterDetails.REyeY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REyeZ), CharacterDetails.REyeZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REyeW), CharacterDetails.REyeW.GetBytes());
            }

            if (CharacterDetails.LEyelidRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEyelidX), CharacterDetails.LEyelidX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEyelidY), CharacterDetails.LEyelidY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEyelidZ), CharacterDetails.LEyelidZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEyelidW), CharacterDetails.LEyelidW.GetBytes());
            }

            if (CharacterDetails.REyelidRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REyelidX), CharacterDetails.REyelidX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REyelidY), CharacterDetails.REyelidY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REyelidZ), CharacterDetails.REyelidZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REyelidW), CharacterDetails.REyelidW.GetBytes());
            }

            if (CharacterDetails.LLowEyelidRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LLowEyelidX), CharacterDetails.LLowEyelidX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LLowEyelidY), CharacterDetails.LLowEyelidY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LLowEyelidZ), CharacterDetails.LLowEyelidZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LLowEyelidW), CharacterDetails.LLowEyelidW.GetBytes());
            }

            if (CharacterDetails.RLowEyelidRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RLowEyelidX), CharacterDetails.RLowEyelidX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RLowEyelidY), CharacterDetails.RLowEyelidY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RLowEyelidZ), CharacterDetails.RLowEyelidZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RLowEyelidW), CharacterDetails.RLowEyelidW.GetBytes());
            }

            if (CharacterDetails.LEarRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarX), CharacterDetails.LEarX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarY), CharacterDetails.LEarY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarZ), CharacterDetails.LEarZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarW), CharacterDetails.LEarW.GetBytes());
            }

            if (CharacterDetails.REarRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarX), CharacterDetails.REarX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarY), CharacterDetails.REarY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarZ), CharacterDetails.REarZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarW), CharacterDetails.REarW.GetBytes());
            }

            if (CharacterDetails.LCheekRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LCheekX), CharacterDetails.LCheekX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LCheekY), CharacterDetails.LCheekY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LCheekZ), CharacterDetails.LCheekZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LCheekW), CharacterDetails.LCheekW.GetBytes());
            }

            if (CharacterDetails.RCheekRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RCheekX), CharacterDetails.RCheekX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RCheekY), CharacterDetails.RCheekY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RCheekZ), CharacterDetails.RCheekZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RCheekW), CharacterDetails.RCheekW.GetBytes());
            }

            if (CharacterDetails.LMouthRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMouthX), CharacterDetails.LMouthX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMouthY), CharacterDetails.LMouthY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMouthZ), CharacterDetails.LMouthZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMouthW), CharacterDetails.LMouthW.GetBytes());
            }

            if (CharacterDetails.RMouthRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMouthX), CharacterDetails.RMouthX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMouthY), CharacterDetails.RMouthY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMouthZ), CharacterDetails.RMouthZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMouthW), CharacterDetails.RMouthW.GetBytes());
            }

            if (CharacterDetails.LUpLipRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LUpLipX), CharacterDetails.LUpLipX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LUpLipY), CharacterDetails.LUpLipY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LUpLipZ), CharacterDetails.LUpLipZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LUpLipW), CharacterDetails.LUpLipW.GetBytes());
            }

            if (CharacterDetails.RUpLipRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RUpLipX), CharacterDetails.RUpLipX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RUpLipY), CharacterDetails.RUpLipY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RUpLipZ), CharacterDetails.RUpLipZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RUpLipW), CharacterDetails.RUpLipW.GetBytes());
            }

            if (CharacterDetails.LLowLipRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LLowLipX), CharacterDetails.LLowLipX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LLowLipY), CharacterDetails.LLowLipY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LLowLipZ), CharacterDetails.LLowLipZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LLowLipW), CharacterDetails.LLowLipW.GetBytes());
            }

            if (CharacterDetails.RLowLipRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RLowLipX), CharacterDetails.RLowLipX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RLowLipY), CharacterDetails.RLowLipY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RLowLipZ), CharacterDetails.RLowLipZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RLowLipW), CharacterDetails.RLowLipW.GetBytes());
            }

        }
        private void UpperBodyBones()
        {
            if (CharacterDetails.NeckRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NeckX), CharacterDetails.NeckX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NeckY), CharacterDetails.NeckY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NeckZ), CharacterDetails.NeckZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.NeckW), CharacterDetails.NeckW.GetBytes());
            }

            if (CharacterDetails.SternumRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.SternumX), CharacterDetails.SternumX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.SternumY), CharacterDetails.SternumY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.SternumZ), CharacterDetails.SternumZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.SternumW), CharacterDetails.SternumW.GetBytes());
            }

            if (CharacterDetails.TorsoRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.TorsoX), CharacterDetails.TorsoX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.TorsoY), CharacterDetails.TorsoY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.TorsoZ), CharacterDetails.TorsoZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.TorsoW), CharacterDetails.TorsoW.GetBytes());
            }

            if (CharacterDetails.WaistRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.WaistX), CharacterDetails.WaistX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.WaistY), CharacterDetails.WaistY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.WaistZ), CharacterDetails.WaistZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.WaistW), CharacterDetails.WaistW.GetBytes());
            }

            if (CharacterDetails.LShoulderRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LShoulderX), CharacterDetails.LShoulderX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LShoulderY), CharacterDetails.LShoulderY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LShoulderZ), CharacterDetails.LShoulderZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LShoulderW), CharacterDetails.LShoulderW.GetBytes());
            }

            if (CharacterDetails.RShoulderRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RShoulderX), CharacterDetails.RShoulderX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RShoulderY), CharacterDetails.RShoulderY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RShoulderZ), CharacterDetails.RShoulderZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RShoulderW), CharacterDetails.RShoulderW.GetBytes());
            }

            if (CharacterDetails.LClavicleRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LClavicleX), CharacterDetails.LClavicleX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LClavicleY), CharacterDetails.LClavicleY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LClavicleZ), CharacterDetails.LClavicleZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LClavicleW), CharacterDetails.LClavicleW.GetBytes());
            }

            if (CharacterDetails.RClavicleRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RClavicleX), CharacterDetails.RClavicleX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RClavicleY), CharacterDetails.RClavicleY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RClavicleZ), CharacterDetails.RClavicleZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RClavicleW), CharacterDetails.RClavicleW.GetBytes());
            }

            if (CharacterDetails.LBreastRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LBreastX), CharacterDetails.LBreastX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LBreastY), CharacterDetails.LBreastY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LBreastZ), CharacterDetails.LBreastZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LBreastW), CharacterDetails.LBreastW.GetBytes());
            }

            if (CharacterDetails.RBreastRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RBreastX), CharacterDetails.RBreastX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RBreastY), CharacterDetails.RBreastY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RBreastZ), CharacterDetails.RBreastZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RBreastW), CharacterDetails.RBreastW.GetBytes());
            }

            if (CharacterDetails.LArmRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LArmX), CharacterDetails.LArmX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LArmY), CharacterDetails.LArmY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LArmZ), CharacterDetails.LArmZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LArmW), CharacterDetails.LArmW.GetBytes());
            }

            if (CharacterDetails.RArmRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RArmX), CharacterDetails.RArmX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RArmY), CharacterDetails.RArmY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RArmZ), CharacterDetails.RArmZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RArmW), CharacterDetails.RArmW.GetBytes());
            }

            if (CharacterDetails.LElbowRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LElbowX), CharacterDetails.LElbowX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LElbowY), CharacterDetails.LElbowY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LElbowZ), CharacterDetails.LElbowZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LElbowW), CharacterDetails.LElbowW.GetBytes());
            }

            if (CharacterDetails.RElbowRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RElbowX), CharacterDetails.RElbowX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RElbowY), CharacterDetails.RElbowY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RElbowZ), CharacterDetails.RElbowZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RElbowW), CharacterDetails.RElbowW.GetBytes());
            }

            if (CharacterDetails.LForearmRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LForearmX), CharacterDetails.LForearmX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LForearmY), CharacterDetails.LForearmY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LForearmZ), CharacterDetails.LForearmZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LForearmW), CharacterDetails.LForearmW.GetBytes());
            }

            if (CharacterDetails.RForearmRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RForearmX), CharacterDetails.RForearmX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RForearmY), CharacterDetails.RForearmY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RForearmZ), CharacterDetails.RForearmZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RForearmW), CharacterDetails.RForearmW.GetBytes());
            }

            if (CharacterDetails.LWristRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LWristX), CharacterDetails.LWristX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LWristY), CharacterDetails.LWristY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LWristZ), CharacterDetails.LWristZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LWristW), CharacterDetails.LWristW.GetBytes());
            }

            if (CharacterDetails.RWristRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RWristX), CharacterDetails.RWristX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RWristY), CharacterDetails.RWristY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RWristZ), CharacterDetails.RWristZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RWristW), CharacterDetails.RWristW.GetBytes());
            }

            if (CharacterDetails.LHandRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LHandX), CharacterDetails.LHandX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LHandY), CharacterDetails.LHandY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LHandZ), CharacterDetails.LHandZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LHandW), CharacterDetails.LHandW.GetBytes());
            }

            if (CharacterDetails.RHandRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RHandX), CharacterDetails.RHandX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RHandY), CharacterDetails.RHandY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RHandZ), CharacterDetails.RHandZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RHandW), CharacterDetails.RHandW.GetBytes());
            }

        }
        private void FingerBones()
        {
            if (CharacterDetails.LThumbRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThumbX), CharacterDetails.LThumbX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThumbY), CharacterDetails.LThumbY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThumbZ), CharacterDetails.LThumbZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThumbW), CharacterDetails.LThumbW.GetBytes());
            }

            if (CharacterDetails.RThumbRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThumbX), CharacterDetails.RThumbX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThumbY), CharacterDetails.RThumbY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThumbZ), CharacterDetails.RThumbZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThumbW), CharacterDetails.RThumbW.GetBytes());
            }

            if (CharacterDetails.LThumb2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThumb2X), CharacterDetails.LThumb2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThumb2Y), CharacterDetails.LThumb2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThumb2Z), CharacterDetails.LThumb2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThumb2W), CharacterDetails.LThumb2W.GetBytes());
            }

            if (CharacterDetails.RThumb2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThumb2X), CharacterDetails.RThumb2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThumb2Y), CharacterDetails.RThumb2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThumb2Z), CharacterDetails.RThumb2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThumb2W), CharacterDetails.RThumb2W.GetBytes());
            }

            if (CharacterDetails.LIndexRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LIndexX), CharacterDetails.LIndexX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LIndexY), CharacterDetails.LIndexY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LIndexZ), CharacterDetails.LIndexZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LIndexW), CharacterDetails.LIndexW.GetBytes());
            }

            if (CharacterDetails.RIndexRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RIndexX), CharacterDetails.RIndexX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RIndexY), CharacterDetails.RIndexY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RIndexZ), CharacterDetails.RIndexZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RIndexW), CharacterDetails.RIndexW.GetBytes());
            }

            if (CharacterDetails.LIndex2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LIndex2X), CharacterDetails.LIndex2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LIndex2Y), CharacterDetails.LIndex2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LIndex2Z), CharacterDetails.LIndex2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LIndex2W), CharacterDetails.LIndex2W.GetBytes());
            }

            if (CharacterDetails.RIndex2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RIndex2X), CharacterDetails.RIndex2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RIndex2Y), CharacterDetails.RIndex2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RIndex2Z), CharacterDetails.RIndex2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RIndex2W), CharacterDetails.RIndex2W.GetBytes());
            }

            if (CharacterDetails.LMiddleRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMiddleX), CharacterDetails.LMiddleX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMiddleY), CharacterDetails.LMiddleY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMiddleZ), CharacterDetails.LMiddleZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMiddleW), CharacterDetails.LMiddleW.GetBytes());
            }

            if (CharacterDetails.RMiddleRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMiddleX), CharacterDetails.RMiddleX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMiddleY), CharacterDetails.RMiddleY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMiddleZ), CharacterDetails.RMiddleZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMiddleW), CharacterDetails.RMiddleW.GetBytes());
            }

            if (CharacterDetails.LMiddle2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMiddle2X), CharacterDetails.LMiddle2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMiddle2Y), CharacterDetails.LMiddle2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMiddle2Z), CharacterDetails.LMiddle2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LMiddle2W), CharacterDetails.LMiddle2W.GetBytes());
            }

            if (CharacterDetails.RMiddle2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMiddle2X), CharacterDetails.RMiddle2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMiddle2Y), CharacterDetails.RMiddle2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMiddle2Z), CharacterDetails.RMiddle2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RMiddle2W), CharacterDetails.RMiddle2W.GetBytes());
            }

            if (CharacterDetails.LRingRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LRingX), CharacterDetails.LRingX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LRingY), CharacterDetails.LRingY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LRingZ), CharacterDetails.LRingZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LRingW), CharacterDetails.LRingW.GetBytes());
            }

            if (CharacterDetails.RRingRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RRingX), CharacterDetails.RRingX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RRingY), CharacterDetails.RRingY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RRingZ), CharacterDetails.RRingZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RRingW), CharacterDetails.RRingW.GetBytes());
            }

            if (CharacterDetails.LRing2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LRing2X), CharacterDetails.LRing2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LRing2Y), CharacterDetails.LRing2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LRing2Z), CharacterDetails.LRing2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LRing2W), CharacterDetails.LRing2W.GetBytes());
            }

            if (CharacterDetails.RRing2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RRing2X), CharacterDetails.RRing2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RRing2Y), CharacterDetails.RRing2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RRing2Z), CharacterDetails.RRing2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RRing2W), CharacterDetails.RRing2W.GetBytes());
            }

            if (CharacterDetails.LPinkyRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LPinkyX), CharacterDetails.LPinkyX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LPinkyY), CharacterDetails.LPinkyY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LPinkyZ), CharacterDetails.LPinkyZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LPinkyW), CharacterDetails.LPinkyW.GetBytes());
            }

            if (CharacterDetails.RPinkyRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RPinkyX), CharacterDetails.RPinkyX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RPinkyY), CharacterDetails.RPinkyY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RPinkyZ), CharacterDetails.RPinkyZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RPinkyW), CharacterDetails.RPinkyW.GetBytes());
            }

            if (CharacterDetails.LPinky2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LPinky2X), CharacterDetails.LPinky2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LPinky2Y), CharacterDetails.LPinky2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LPinky2Z), CharacterDetails.LPinky2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LPinky2W), CharacterDetails.LPinky2W.GetBytes());
            }

            if (CharacterDetails.RPinky2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RPinky2X), CharacterDetails.RPinky2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RPinky2Y), CharacterDetails.RPinky2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RPinky2Z), CharacterDetails.RPinky2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RPinky2W), CharacterDetails.RPinky2W.GetBytes());
            }

        }
        private void LowerBodyBones()
        {
            if (CharacterDetails.PelvisRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.PelvisX), CharacterDetails.PelvisX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.PelvisY), CharacterDetails.PelvisY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.PelvisZ), CharacterDetails.PelvisZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.PelvisW), CharacterDetails.PelvisW.GetBytes());
            }

            if (CharacterDetails.TailRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.TailX), CharacterDetails.TailX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.TailY), CharacterDetails.TailY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.TailZ), CharacterDetails.TailZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.TailW), CharacterDetails.TailW.GetBytes());
            }

            if (CharacterDetails.Tail2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail2X), CharacterDetails.Tail2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail2Y), CharacterDetails.Tail2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail2Z), CharacterDetails.Tail2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail2W), CharacterDetails.Tail2W.GetBytes());
            }

            if (CharacterDetails.Tail3Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail3X), CharacterDetails.Tail3X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail3Y), CharacterDetails.Tail3Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail3Z), CharacterDetails.Tail3Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail3W), CharacterDetails.Tail3W.GetBytes());
            }

            if (CharacterDetails.Tail4Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail4X), CharacterDetails.Tail4X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail4Y), CharacterDetails.Tail4Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail4Z), CharacterDetails.Tail4Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.Tail4W), CharacterDetails.Tail4W.GetBytes());
            }

            if (CharacterDetails.LThighRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThighX), CharacterDetails.LThighX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThighY), CharacterDetails.LThighY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThighZ), CharacterDetails.LThighZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LThighW), CharacterDetails.LThighW.GetBytes());
            }

            if (CharacterDetails.RThighRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThighX), CharacterDetails.RThighX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThighY), CharacterDetails.RThighY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThighZ), CharacterDetails.RThighZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RThighW), CharacterDetails.RThighW.GetBytes());
            }

            if (CharacterDetails.LKneeRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LKneeX), CharacterDetails.LKneeX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LKneeY), CharacterDetails.LKneeY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LKneeZ), CharacterDetails.LKneeZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LKneeW), CharacterDetails.LKneeW.GetBytes());
            }

            if (CharacterDetails.RKneeRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RKneeX), CharacterDetails.RKneeX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RKneeY), CharacterDetails.RKneeY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RKneeZ), CharacterDetails.RKneeZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RKneeW), CharacterDetails.RKneeW.GetBytes());
            }

            if (CharacterDetails.LCalfRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LCalfX), CharacterDetails.LCalfX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LCalfY), CharacterDetails.LCalfY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LCalfZ), CharacterDetails.LCalfZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LCalfW), CharacterDetails.LCalfW.GetBytes());
            }

            if (CharacterDetails.RCalfRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RCalfX), CharacterDetails.RCalfX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RCalfY), CharacterDetails.RCalfY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RCalfZ), CharacterDetails.RCalfZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RCalfW), CharacterDetails.RCalfW.GetBytes());
            }

            if (CharacterDetails.LFootRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LFootX), CharacterDetails.LFootX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LFootY), CharacterDetails.LFootY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LFootZ), CharacterDetails.LFootZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LFootW), CharacterDetails.LFootW.GetBytes());
            }

            if (CharacterDetails.RFootRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RFootX), CharacterDetails.RFootX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RFootY), CharacterDetails.RFootY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RFootZ), CharacterDetails.RFootZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RFootW), CharacterDetails.RFootW.GetBytes());
            }

            if (CharacterDetails.LToesRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LToesX), CharacterDetails.LToesX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LToesY), CharacterDetails.LToesY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LToesZ), CharacterDetails.LToesZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LToesW), CharacterDetails.LToesW.GetBytes());
            }

            if (CharacterDetails.RToesRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RToesX), CharacterDetails.RToesX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RToesY), CharacterDetails.RToesY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RToesZ), CharacterDetails.RToesZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.RToesW), CharacterDetails.RToesW.GetBytes());
            }
        }
        private void MiscBones()
        {
            if (CharacterDetails.DebugRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.DebugX), CharacterDetails.DebugX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.DebugY), CharacterDetails.DebugY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.DebugZ), CharacterDetails.DebugZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.DebugW), CharacterDetails.DebugW.GetBytes());
            }

            if (CharacterDetails.LEarringRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarringX), CharacterDetails.LEarringX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarringY), CharacterDetails.LEarringY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarringZ), CharacterDetails.LEarringZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarringW), CharacterDetails.LEarringW.GetBytes());
            }

            if (CharacterDetails.REarringRotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarringX), CharacterDetails.REarringX.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarringY), CharacterDetails.REarringY.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarringZ), CharacterDetails.REarringZ.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarringW), CharacterDetails.REarringW.GetBytes());
            }

            if (CharacterDetails.LEarring2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarring2X), CharacterDetails.LEarring2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarring2Y), CharacterDetails.LEarring2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarring2Z), CharacterDetails.LEarring2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.LEarring2W), CharacterDetails.LEarring2W.GetBytes());
            }

            if (CharacterDetails.REarring2Rotate)
            {
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarring2X), CharacterDetails.REarring2X.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarring2Y), CharacterDetails.REarring2Y.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarring2Z), CharacterDetails.REarring2Z.GetBytes());
                m.writeBytes(GAS(c.Body.Base, c.Body.Position.REarring2W), CharacterDetails.REarring2W.GetBytes());
            }
        }
    }
}
