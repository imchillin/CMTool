using ConceptMatrix.Models;
using ConceptMatrix.ViewModel;
using System;
using System.ComponentModel;
using System.Threading;

namespace ConceptMatrix.Utility
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
					var m = MemoryManager.Instance.MemLib;
					var c = Settings.Instance.Character;

					string GAS(params string[] args) => MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, args);
                    string GASG(params string[] args) => MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, args);

                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    var xdad = (byte)m.readByte(GAS(c.EntityType));
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
    }
}
