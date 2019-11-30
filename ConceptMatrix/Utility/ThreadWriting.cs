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

                    #region Bone Rotation
                    if (CharacterDetails.Root_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Root_X), CharacterDetails.Root_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Root_Y), CharacterDetails.Root_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Root_Z), CharacterDetails.Root_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Root_W), CharacterDetails.Root_W.GetBytes());
                    }

                    if (CharacterDetails.Abdomen_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Abdomen_X), CharacterDetails.Abdomen_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Abdomen_Y), CharacterDetails.Abdomen_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Abdomen_Z), CharacterDetails.Abdomen_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Abdomen_W), CharacterDetails.Abdomen_W.GetBytes());
                    }

                    if (CharacterDetails.Throw_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Throw_X), CharacterDetails.Throw_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Throw_Y), CharacterDetails.Throw_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Throw_Z), CharacterDetails.Throw_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Throw_W), CharacterDetails.Throw_W.GetBytes());
                    }

                    if (CharacterDetails.Waist_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Waist_X), CharacterDetails.Waist_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Waist_Y), CharacterDetails.Waist_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Waist_Z), CharacterDetails.Waist_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Waist_W), CharacterDetails.Waist_W.GetBytes());
                    }

                    if (CharacterDetails.SpineA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineA_X), CharacterDetails.SpineA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineA_Y), CharacterDetails.SpineA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineA_Z), CharacterDetails.SpineA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineA_W), CharacterDetails.SpineA_W.GetBytes());
                    }

                    if (CharacterDetails.LegLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegLeft_X), CharacterDetails.LegLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegLeft_Y), CharacterDetails.LegLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegLeft_Z), CharacterDetails.LegLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegLeft_W), CharacterDetails.LegLeft_W.GetBytes());
                    }

                    if (CharacterDetails.LegRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegRight_X), CharacterDetails.LegRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegRight_Y), CharacterDetails.LegRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegRight_Z), CharacterDetails.LegRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegRight_W), CharacterDetails.LegRight_W.GetBytes());
                    }

                    if (CharacterDetails.HolsterLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterLeft_X), CharacterDetails.HolsterLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterLeft_Y), CharacterDetails.HolsterLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterLeft_Z), CharacterDetails.HolsterLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterLeft_W), CharacterDetails.HolsterLeft_W.GetBytes());
                    }

                    if (CharacterDetails.HolsterRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterRight_X), CharacterDetails.HolsterRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterRight_Y), CharacterDetails.HolsterRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterRight_Z), CharacterDetails.HolsterRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterRight_W), CharacterDetails.HolsterRight_W.GetBytes());
                    }

                    if (CharacterDetails.SheatheLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheLeft_X), CharacterDetails.SheatheLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheLeft_Y), CharacterDetails.SheatheLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheLeft_Z), CharacterDetails.SheatheLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheLeft_W), CharacterDetails.SheatheLeft_W.GetBytes());
                    }

                    if (CharacterDetails.SheatheRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheRight_X), CharacterDetails.SheatheRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheRight_Y), CharacterDetails.SheatheRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheRight_Z), CharacterDetails.SheatheRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheRight_W), CharacterDetails.SheatheRight_W.GetBytes());
                    }

                    if (CharacterDetails.SpineB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineB_X), CharacterDetails.SpineB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineB_Y), CharacterDetails.SpineB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineB_Z), CharacterDetails.SpineB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineB_W), CharacterDetails.SpineB_W.GetBytes());
                    }

                    if (CharacterDetails.ClothBackALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackALeft_X), CharacterDetails.ClothBackALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackALeft_Y), CharacterDetails.ClothBackALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackALeft_Z), CharacterDetails.ClothBackALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackALeft_W), CharacterDetails.ClothBackALeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothBackARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackARight_X), CharacterDetails.ClothBackARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackARight_Y), CharacterDetails.ClothBackARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackARight_Z), CharacterDetails.ClothBackARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackARight_W), CharacterDetails.ClothBackARight_W.GetBytes());
                    }

                    if (CharacterDetails.ClothFrontALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontALeft_X), CharacterDetails.ClothFrontALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontALeft_Y), CharacterDetails.ClothFrontALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontALeft_Z), CharacterDetails.ClothFrontALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontALeft_W), CharacterDetails.ClothFrontALeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothFrontARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontARight_X), CharacterDetails.ClothFrontARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontARight_Y), CharacterDetails.ClothFrontARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontARight_Z), CharacterDetails.ClothFrontARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontARight_W), CharacterDetails.ClothFrontARight_W.GetBytes());
                    }

                    if (CharacterDetails.ClothSideALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideALeft_X), CharacterDetails.ClothSideALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideALeft_Y), CharacterDetails.ClothSideALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideALeft_Z), CharacterDetails.ClothSideALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideALeft_W), CharacterDetails.ClothSideALeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothSideARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideARight_X), CharacterDetails.ClothSideARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideARight_Y), CharacterDetails.ClothSideARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideARight_Z), CharacterDetails.ClothSideARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideARight_W), CharacterDetails.ClothSideARight_W.GetBytes());
                    }

                    if (CharacterDetails.KneeLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeLeft_X), CharacterDetails.KneeLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeLeft_Y), CharacterDetails.KneeLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeLeft_Z), CharacterDetails.KneeLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeLeft_W), CharacterDetails.KneeLeft_W.GetBytes());
                    }

                    if (CharacterDetails.KneeRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeRight_X), CharacterDetails.KneeRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeRight_Y), CharacterDetails.KneeRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeRight_Z), CharacterDetails.KneeRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeRight_W), CharacterDetails.KneeRight_W.GetBytes());
                    }

                    if (CharacterDetails.BreastLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastLeft_X), CharacterDetails.BreastLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastLeft_Y), CharacterDetails.BreastLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastLeft_Z), CharacterDetails.BreastLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastLeft_W), CharacterDetails.BreastLeft_W.GetBytes());
                    }

                    if (CharacterDetails.BreastRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastRight_X), CharacterDetails.BreastRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastRight_Y), CharacterDetails.BreastRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastRight_Z), CharacterDetails.BreastRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastRight_W), CharacterDetails.BreastRight_W.GetBytes());
                    }

                    if (CharacterDetails.SpineC_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineC_X), CharacterDetails.SpineC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineC_Y), CharacterDetails.SpineC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineC_Z), CharacterDetails.SpineC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineC_W), CharacterDetails.SpineC_W.GetBytes());
                    }

                    if (CharacterDetails.ClothBackBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBLeft_X), CharacterDetails.ClothBackBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBLeft_Y), CharacterDetails.ClothBackBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBLeft_Z), CharacterDetails.ClothBackBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBLeft_W), CharacterDetails.ClothBackBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothBackBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBRight_X), CharacterDetails.ClothBackBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBRight_Y), CharacterDetails.ClothBackBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBRight_Z), CharacterDetails.ClothBackBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBRight_W), CharacterDetails.ClothBackBRight_W.GetBytes());
                    }

                    if (CharacterDetails.ClothFrontBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBLeft_X), CharacterDetails.ClothFrontBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBLeft_Y), CharacterDetails.ClothFrontBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBLeft_Z), CharacterDetails.ClothFrontBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBLeft_W), CharacterDetails.ClothFrontBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothFrontBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBRight_X), CharacterDetails.ClothFrontBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBRight_Y), CharacterDetails.ClothFrontBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBRight_Z), CharacterDetails.ClothFrontBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBRight_W), CharacterDetails.ClothFrontBRight_W.GetBytes());
                    }

                    if (CharacterDetails.ClothSideBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBLeft_X), CharacterDetails.ClothSideBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBLeft_Y), CharacterDetails.ClothSideBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBLeft_Z), CharacterDetails.ClothSideBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBLeft_W), CharacterDetails.ClothSideBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothSideBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBRight_X), CharacterDetails.ClothSideBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBRight_Y), CharacterDetails.ClothSideBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBRight_Z), CharacterDetails.ClothSideBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBRight_W), CharacterDetails.ClothSideBRight_W.GetBytes());
                    }

                    if (CharacterDetails.CalfLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfLeft_X), CharacterDetails.CalfLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfLeft_Y), CharacterDetails.CalfLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfLeft_Z), CharacterDetails.CalfLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfLeft_W), CharacterDetails.CalfLeft_W.GetBytes());
                    }

                    if (CharacterDetails.CalfRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfRight_X), CharacterDetails.CalfRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfRight_Y), CharacterDetails.CalfRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfRight_Z), CharacterDetails.CalfRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfRight_W), CharacterDetails.CalfRight_W.GetBytes());
                    }

                    if (CharacterDetails.ScabbardLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardLeft_X), CharacterDetails.ScabbardLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardLeft_Y), CharacterDetails.ScabbardLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardLeft_Z), CharacterDetails.ScabbardLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardLeft_W), CharacterDetails.ScabbardLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ScabbardRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardRight_X), CharacterDetails.ScabbardRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardRight_Y), CharacterDetails.ScabbardRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardRight_Z), CharacterDetails.ScabbardRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardRight_W), CharacterDetails.ScabbardRight_W.GetBytes());
                    }

                    if (CharacterDetails.Neck_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Neck_X), CharacterDetails.Neck_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Neck_Y), CharacterDetails.Neck_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Neck_Z), CharacterDetails.Neck_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Neck_W), CharacterDetails.Neck_W.GetBytes());
                    }

                    if (CharacterDetails.ClavicleLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleLeft_X), CharacterDetails.ClavicleLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleLeft_Y), CharacterDetails.ClavicleLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleLeft_Z), CharacterDetails.ClavicleLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleLeft_W), CharacterDetails.ClavicleLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClavicleRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleRight_X), CharacterDetails.ClavicleRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleRight_Y), CharacterDetails.ClavicleRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleRight_Z), CharacterDetails.ClavicleRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleRight_W), CharacterDetails.ClavicleRight_W.GetBytes());
                    }

                    if (CharacterDetails.ClothBackCLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCLeft_X), CharacterDetails.ClothBackCLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCLeft_Y), CharacterDetails.ClothBackCLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCLeft_Z), CharacterDetails.ClothBackCLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCLeft_W), CharacterDetails.ClothBackCLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothBackCRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCRight_X), CharacterDetails.ClothBackCRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCRight_Y), CharacterDetails.ClothBackCRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCRight_Z), CharacterDetails.ClothBackCRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCRight_W), CharacterDetails.ClothBackCRight_W.GetBytes());
                    }

                    if (CharacterDetails.ClothFrontCLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCLeft_X), CharacterDetails.ClothFrontCLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCLeft_Y), CharacterDetails.ClothFrontCLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCLeft_Z), CharacterDetails.ClothFrontCLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCLeft_W), CharacterDetails.ClothFrontCLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothFrontCRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCRight_X), CharacterDetails.ClothFrontCRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCRight_Y), CharacterDetails.ClothFrontCRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCRight_Z), CharacterDetails.ClothFrontCRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCRight_W), CharacterDetails.ClothFrontCRight_W.GetBytes());
                    }

                    if (CharacterDetails.ClothSideCLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCLeft_X), CharacterDetails.ClothSideCLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCLeft_Y), CharacterDetails.ClothSideCLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCLeft_Z), CharacterDetails.ClothSideCLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCLeft_W), CharacterDetails.ClothSideCLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ClothSideCRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCRight_X), CharacterDetails.ClothSideCRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCRight_Y), CharacterDetails.ClothSideCRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCRight_Z), CharacterDetails.ClothSideCRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCRight_W), CharacterDetails.ClothSideCRight_W.GetBytes());
                    }

                    if (CharacterDetails.PoleynLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynLeft_X), CharacterDetails.PoleynLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynLeft_Y), CharacterDetails.PoleynLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynLeft_Z), CharacterDetails.PoleynLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynLeft_W), CharacterDetails.PoleynLeft_W.GetBytes());
                    }

                    if (CharacterDetails.PoleynRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynRight_X), CharacterDetails.PoleynRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynRight_Y), CharacterDetails.PoleynRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynRight_Z), CharacterDetails.PoleynRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynRight_W), CharacterDetails.PoleynRight_W.GetBytes());
                    }

                    if (CharacterDetails.FootLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootLeft_X), CharacterDetails.FootLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootLeft_Y), CharacterDetails.FootLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootLeft_Z), CharacterDetails.FootLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootLeft_W), CharacterDetails.FootLeft_W.GetBytes());
                    }

                    if (CharacterDetails.FootRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootRight_X), CharacterDetails.FootRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootRight_Y), CharacterDetails.FootRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootRight_Z), CharacterDetails.FootRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootRight_W), CharacterDetails.FootRight_W.GetBytes());
                    }

                    if (CharacterDetails.Head_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Head_X), CharacterDetails.Head_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Head_Y), CharacterDetails.Head_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Head_Z), CharacterDetails.Head_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Head_W), CharacterDetails.Head_W.GetBytes());
                    }

                    if (CharacterDetails.ArmLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmLeft_X), CharacterDetails.ArmLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmLeft_Y), CharacterDetails.ArmLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmLeft_Z), CharacterDetails.ArmLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmLeft_W), CharacterDetails.ArmLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ArmRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmRight_X), CharacterDetails.ArmRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmRight_Y), CharacterDetails.ArmRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmRight_Z), CharacterDetails.ArmRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmRight_W), CharacterDetails.ArmRight_W.GetBytes());
                    }

                    if (CharacterDetails.PauldronLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronLeft_X), CharacterDetails.PauldronLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronLeft_Y), CharacterDetails.PauldronLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronLeft_Z), CharacterDetails.PauldronLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronLeft_W), CharacterDetails.PauldronLeft_W.GetBytes());
                    }

                    if (CharacterDetails.PauldronRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronRight_X), CharacterDetails.PauldronRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronRight_Y), CharacterDetails.PauldronRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronRight_Z), CharacterDetails.PauldronRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronRight_W), CharacterDetails.PauldronRight_W.GetBytes());
                    }

                    if (CharacterDetails.Unknown00_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Unknown00_X), CharacterDetails.Unknown00_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Unknown00_Y), CharacterDetails.Unknown00_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Unknown00_Z), CharacterDetails.Unknown00_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Unknown00_W), CharacterDetails.Unknown00_W.GetBytes());
                    }

                    if (CharacterDetails.ToesLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesLeft_X), CharacterDetails.ToesLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesLeft_Y), CharacterDetails.ToesLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesLeft_Z), CharacterDetails.ToesLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesLeft_W), CharacterDetails.ToesLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ToesRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesRight_X), CharacterDetails.ToesRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesRight_Y), CharacterDetails.ToesRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesRight_Z), CharacterDetails.ToesRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesRight_W), CharacterDetails.ToesRight_W.GetBytes());
                    }

                    if (CharacterDetails.HairA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairA_X), CharacterDetails.HairA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairA_Y), CharacterDetails.HairA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairA_Z), CharacterDetails.HairA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairA_W), CharacterDetails.HairA_W.GetBytes());
                    }

                    if (CharacterDetails.HairFrontLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontLeft_X), CharacterDetails.HairFrontLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontLeft_Y), CharacterDetails.HairFrontLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontLeft_Z), CharacterDetails.HairFrontLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontLeft_W), CharacterDetails.HairFrontLeft_W.GetBytes());
                    }

                    if (CharacterDetails.HairFrontRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontRight_X), CharacterDetails.HairFrontRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontRight_Y), CharacterDetails.HairFrontRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontRight_Z), CharacterDetails.HairFrontRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontRight_W), CharacterDetails.HairFrontRight_W.GetBytes());
                    }

                    if (CharacterDetails.EarLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarLeft_X), CharacterDetails.EarLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarLeft_Y), CharacterDetails.EarLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarLeft_Z), CharacterDetails.EarLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarLeft_W), CharacterDetails.EarLeft_W.GetBytes());
                    }

                    if (CharacterDetails.EarRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarRight_X), CharacterDetails.EarRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarRight_Y), CharacterDetails.EarRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarRight_Z), CharacterDetails.EarRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarRight_W), CharacterDetails.EarRight_W.GetBytes());
                    }

                    if (CharacterDetails.ForearmLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmLeft_X), CharacterDetails.ForearmLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmLeft_Y), CharacterDetails.ForearmLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmLeft_Z), CharacterDetails.ForearmLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmLeft_W), CharacterDetails.ForearmLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ForearmRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmRight_X), CharacterDetails.ForearmRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmRight_Y), CharacterDetails.ForearmRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmRight_Z), CharacterDetails.ForearmRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmRight_W), CharacterDetails.ForearmRight_W.GetBytes());
                    }

                    if (CharacterDetails.ShoulderLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderLeft_X), CharacterDetails.ShoulderLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderLeft_Y), CharacterDetails.ShoulderLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderLeft_Z), CharacterDetails.ShoulderLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderLeft_W), CharacterDetails.ShoulderLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ShoulderRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderRight_X), CharacterDetails.ShoulderRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderRight_Y), CharacterDetails.ShoulderRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderRight_Z), CharacterDetails.ShoulderRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderRight_W), CharacterDetails.ShoulderRight_W.GetBytes());
                    }

                    if (CharacterDetails.HairB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairB_X), CharacterDetails.HairB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairB_Y), CharacterDetails.HairB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairB_Z), CharacterDetails.HairB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairB_W), CharacterDetails.HairB_W.GetBytes());
                    }

                    if (CharacterDetails.HandLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandLeft_X), CharacterDetails.HandLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandLeft_Y), CharacterDetails.HandLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandLeft_Z), CharacterDetails.HandLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandLeft_W), CharacterDetails.HandLeft_W.GetBytes());
                    }

                    if (CharacterDetails.HandRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandRight_X), CharacterDetails.HandRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandRight_Y), CharacterDetails.HandRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandRight_Z), CharacterDetails.HandRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandRight_W), CharacterDetails.HandRight_W.GetBytes());
                    }

                    if (CharacterDetails.ShieldLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldLeft_X), CharacterDetails.ShieldLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldLeft_Y), CharacterDetails.ShieldLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldLeft_Z), CharacterDetails.ShieldLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldLeft_W), CharacterDetails.ShieldLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ShieldRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldRight_X), CharacterDetails.ShieldRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldRight_Y), CharacterDetails.ShieldRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldRight_Z), CharacterDetails.ShieldRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldRight_W), CharacterDetails.ShieldRight_W.GetBytes());
                    }

                    if (CharacterDetails.EarringALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringALeft_X), CharacterDetails.EarringALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringALeft_Y), CharacterDetails.EarringALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringALeft_Z), CharacterDetails.EarringALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringALeft_W), CharacterDetails.EarringALeft_W.GetBytes());
                    }

                    if (CharacterDetails.EarringARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringARight_X), CharacterDetails.EarringARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringARight_Y), CharacterDetails.EarringARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringARight_Z), CharacterDetails.EarringARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringARight_W), CharacterDetails.EarringARight_W.GetBytes());
                    }

                    if (CharacterDetails.ElbowLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowLeft_X), CharacterDetails.ElbowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowLeft_Y), CharacterDetails.ElbowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowLeft_Z), CharacterDetails.ElbowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowLeft_W), CharacterDetails.ElbowLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ElbowRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowRight_X), CharacterDetails.ElbowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowRight_Y), CharacterDetails.ElbowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowRight_Z), CharacterDetails.ElbowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowRight_W), CharacterDetails.ElbowRight_W.GetBytes());
                    }

                    if (CharacterDetails.CouterLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterLeft_X), CharacterDetails.CouterLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterLeft_Y), CharacterDetails.CouterLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterLeft_Z), CharacterDetails.CouterLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterLeft_W), CharacterDetails.CouterLeft_W.GetBytes());
                    }

                    if (CharacterDetails.CouterRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterRight_X), CharacterDetails.CouterRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterRight_Y), CharacterDetails.CouterRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterRight_Z), CharacterDetails.CouterRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterRight_W), CharacterDetails.CouterRight_W.GetBytes());
                    }

                    if (CharacterDetails.WristLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristLeft_X), CharacterDetails.WristLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristLeft_Y), CharacterDetails.WristLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristLeft_Z), CharacterDetails.WristLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristLeft_W), CharacterDetails.WristLeft_W.GetBytes());
                    }

                    if (CharacterDetails.WristRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristRight_X), CharacterDetails.WristRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristRight_Y), CharacterDetails.WristRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristRight_Z), CharacterDetails.WristRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristRight_W), CharacterDetails.WristRight_W.GetBytes());
                    }

                    if (CharacterDetails.IndexALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexALeft_X), CharacterDetails.IndexALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexALeft_Y), CharacterDetails.IndexALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexALeft_Z), CharacterDetails.IndexALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexALeft_W), CharacterDetails.IndexALeft_W.GetBytes());
                    }

                    if (CharacterDetails.IndexARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexARight_X), CharacterDetails.IndexARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexARight_Y), CharacterDetails.IndexARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexARight_Z), CharacterDetails.IndexARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexARight_W), CharacterDetails.IndexARight_W.GetBytes());
                    }

                    if (CharacterDetails.PinkyALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyALeft_X), CharacterDetails.PinkyALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyALeft_Y), CharacterDetails.PinkyALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyALeft_Z), CharacterDetails.PinkyALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyALeft_W), CharacterDetails.PinkyALeft_W.GetBytes());
                    }

                    if (CharacterDetails.PinkyARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyARight_X), CharacterDetails.PinkyARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyARight_Y), CharacterDetails.PinkyARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyARight_Z), CharacterDetails.PinkyARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyARight_W), CharacterDetails.PinkyARight_W.GetBytes());
                    }

                    if (CharacterDetails.RingALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingALeft_X), CharacterDetails.RingALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingALeft_Y), CharacterDetails.RingALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingALeft_Z), CharacterDetails.RingALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingALeft_W), CharacterDetails.RingALeft_W.GetBytes());
                    }

                    if (CharacterDetails.RingARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingARight_X), CharacterDetails.RingARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingARight_Y), CharacterDetails.RingARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingARight_Z), CharacterDetails.RingARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingARight_W), CharacterDetails.RingARight_W.GetBytes());
                    }

                    if (CharacterDetails.MiddleALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleALeft_X), CharacterDetails.MiddleALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleALeft_Y), CharacterDetails.MiddleALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleALeft_Z), CharacterDetails.MiddleALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleALeft_W), CharacterDetails.MiddleALeft_W.GetBytes());
                    }

                    if (CharacterDetails.MiddleARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleARight_X), CharacterDetails.MiddleARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleARight_Y), CharacterDetails.MiddleARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleARight_Z), CharacterDetails.MiddleARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleARight_W), CharacterDetails.MiddleARight_W.GetBytes());
                    }

                    if (CharacterDetails.ThumbALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbALeft_X), CharacterDetails.ThumbALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbALeft_Y), CharacterDetails.ThumbALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbALeft_Z), CharacterDetails.ThumbALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbALeft_W), CharacterDetails.ThumbALeft_W.GetBytes());
                    }

                    if (CharacterDetails.ThumbARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbARight_X), CharacterDetails.ThumbARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbARight_Y), CharacterDetails.ThumbARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbARight_Z), CharacterDetails.ThumbARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbARight_W), CharacterDetails.ThumbARight_W.GetBytes());
                    }

                    if (CharacterDetails.WeaponLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponLeft_X), CharacterDetails.WeaponLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponLeft_Y), CharacterDetails.WeaponLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponLeft_Z), CharacterDetails.WeaponLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponLeft_W), CharacterDetails.WeaponLeft_W.GetBytes());
                    }

                    if (CharacterDetails.WeaponRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponRight_X), CharacterDetails.WeaponRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponRight_Y), CharacterDetails.WeaponRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponRight_Z), CharacterDetails.WeaponRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponRight_W), CharacterDetails.WeaponRight_W.GetBytes());
                    }

                    if (CharacterDetails.EarringBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBLeft_X), CharacterDetails.EarringBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBLeft_Y), CharacterDetails.EarringBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBLeft_Z), CharacterDetails.EarringBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBLeft_W), CharacterDetails.EarringBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.EarringBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBRight_X), CharacterDetails.EarringBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBRight_Y), CharacterDetails.EarringBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBRight_Z), CharacterDetails.EarringBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBRight_W), CharacterDetails.EarringBRight_W.GetBytes());
                    }

                    if (CharacterDetails.IndexBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBLeft_X), CharacterDetails.IndexBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBLeft_Y), CharacterDetails.IndexBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBLeft_Z), CharacterDetails.IndexBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBLeft_W), CharacterDetails.IndexBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.IndexBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBRight_X), CharacterDetails.IndexBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBRight_Y), CharacterDetails.IndexBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBRight_Z), CharacterDetails.IndexBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBRight_W), CharacterDetails.IndexBRight_W.GetBytes());
                    }

                    if (CharacterDetails.PinkyBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBLeft_X), CharacterDetails.PinkyBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBLeft_Y), CharacterDetails.PinkyBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBLeft_Z), CharacterDetails.PinkyBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBLeft_W), CharacterDetails.PinkyBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.PinkyBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBRight_X), CharacterDetails.PinkyBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBRight_Y), CharacterDetails.PinkyBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBRight_Z), CharacterDetails.PinkyBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBRight_W), CharacterDetails.PinkyBRight_W.GetBytes());
                    }

                    if (CharacterDetails.RingBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBLeft_X), CharacterDetails.RingBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBLeft_Y), CharacterDetails.RingBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBLeft_Z), CharacterDetails.RingBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBLeft_W), CharacterDetails.RingBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.RingBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBRight_X), CharacterDetails.RingBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBRight_Y), CharacterDetails.RingBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBRight_Z), CharacterDetails.RingBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBRight_W), CharacterDetails.RingBRight_W.GetBytes());
                    }

                    if (CharacterDetails.MiddleBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBLeft_X), CharacterDetails.MiddleBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBLeft_Y), CharacterDetails.MiddleBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBLeft_Z), CharacterDetails.MiddleBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBLeft_W), CharacterDetails.MiddleBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.MiddleBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBRight_X), CharacterDetails.MiddleBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBRight_Y), CharacterDetails.MiddleBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBRight_Z), CharacterDetails.MiddleBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBRight_W), CharacterDetails.MiddleBRight_W.GetBytes());
                    }

                    if (CharacterDetails.ThumbBLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBLeft_X), CharacterDetails.ThumbBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBLeft_Y), CharacterDetails.ThumbBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBLeft_Z), CharacterDetails.ThumbBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBLeft_W), CharacterDetails.ThumbBLeft_W.GetBytes());
                    }

                    if (CharacterDetails.ThumbBRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBRight_X), CharacterDetails.ThumbBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBRight_Y), CharacterDetails.ThumbBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBRight_Z), CharacterDetails.ThumbBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBRight_W), CharacterDetails.ThumbBRight_W.GetBytes());
                    }

                    if (CharacterDetails.TailA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailA_X), CharacterDetails.TailA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailA_Y), CharacterDetails.TailA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailA_Z), CharacterDetails.TailA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailA_W), CharacterDetails.TailA_W.GetBytes());
                    }

                    if (CharacterDetails.TailB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailB_X), CharacterDetails.TailB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailB_Y), CharacterDetails.TailB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailB_Z), CharacterDetails.TailB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailB_W), CharacterDetails.TailB_W.GetBytes());
                    }

                    if (CharacterDetails.TailC_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailC_X), CharacterDetails.TailC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailC_Y), CharacterDetails.TailC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailC_Z), CharacterDetails.TailC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailC_W), CharacterDetails.TailC_W.GetBytes());
                    }

                    if (CharacterDetails.TailD_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailD_X), CharacterDetails.TailD_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailD_Y), CharacterDetails.TailD_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailD_Z), CharacterDetails.TailD_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailD_W), CharacterDetails.TailD_W.GetBytes());
                    }

                    if (CharacterDetails.TailE_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailE_X), CharacterDetails.TailE_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailE_Y), CharacterDetails.TailE_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailE_Z), CharacterDetails.TailE_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailE_W), CharacterDetails.TailE_W.GetBytes());
                    }

                    if (CharacterDetails.RootHead_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RootHead_X), CharacterDetails.RootHead_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RootHead_Y), CharacterDetails.RootHead_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RootHead_Z), CharacterDetails.RootHead_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RootHead_W), CharacterDetails.RootHead_W.GetBytes());
                    }

                    if (CharacterDetails.Jaw_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Jaw_X), CharacterDetails.Jaw_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Jaw_Y), CharacterDetails.Jaw_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Jaw_Z), CharacterDetails.Jaw_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Jaw_W), CharacterDetails.Jaw_W.GetBytes());
                    }

                    if (CharacterDetails.EyelidLowerLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerLeft_X), CharacterDetails.EyelidLowerLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerLeft_Y), CharacterDetails.EyelidLowerLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerLeft_Z), CharacterDetails.EyelidLowerLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerLeft_W), CharacterDetails.EyelidLowerLeft_W.GetBytes());
                    }

                    if (CharacterDetails.EyelidLowerRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerRight_X), CharacterDetails.EyelidLowerRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerRight_Y), CharacterDetails.EyelidLowerRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerRight_Z), CharacterDetails.EyelidLowerRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerRight_W), CharacterDetails.EyelidLowerRight_W.GetBytes());
                    }

                    if (CharacterDetails.EyeLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeLeft_X), CharacterDetails.EyeLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeLeft_Y), CharacterDetails.EyeLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeLeft_Z), CharacterDetails.EyeLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeLeft_W), CharacterDetails.EyeLeft_W.GetBytes());
                    }

                    if (CharacterDetails.EyeRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeRight_X), CharacterDetails.EyeRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeRight_Y), CharacterDetails.EyeRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeRight_Z), CharacterDetails.EyeRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeRight_W), CharacterDetails.EyeRight_W.GetBytes());
                    }

                    if (CharacterDetails.Nose_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Nose_X), CharacterDetails.Nose_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Nose_Y), CharacterDetails.Nose_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Nose_Z), CharacterDetails.Nose_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Nose_W), CharacterDetails.Nose_W.GetBytes());
                    }

                    if (CharacterDetails.CheekLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekLeft_X), CharacterDetails.CheekLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekLeft_Y), CharacterDetails.CheekLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekLeft_Z), CharacterDetails.CheekLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekLeft_W), CharacterDetails.CheekLeft_W.GetBytes());
                    }

                    if (CharacterDetails.HrothWhiskersLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersLeft_X), CharacterDetails.HrothWhiskersLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersLeft_Y), CharacterDetails.HrothWhiskersLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersLeft_Z), CharacterDetails.HrothWhiskersLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersLeft_W), CharacterDetails.HrothWhiskersLeft_W.GetBytes());
                    }

                    if (CharacterDetails.CheekRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekRight_X), CharacterDetails.CheekRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekRight_Y), CharacterDetails.CheekRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekRight_Z), CharacterDetails.CheekRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekRight_W), CharacterDetails.CheekRight_W.GetBytes());
                    }

                    if (CharacterDetails.HrothWhiskersRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersRight_X), CharacterDetails.HrothWhiskersRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersRight_Y), CharacterDetails.HrothWhiskersRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersRight_Z), CharacterDetails.HrothWhiskersRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersRight_W), CharacterDetails.HrothWhiskersRight_W.GetBytes());
                    }

                    if (CharacterDetails.LipsLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsLeft_X), CharacterDetails.LipsLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsLeft_Y), CharacterDetails.LipsLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsLeft_Z), CharacterDetails.LipsLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsLeft_W), CharacterDetails.LipsLeft_W.GetBytes());
                    }

                    if (CharacterDetails.HrothEyebrowLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowLeft_X), CharacterDetails.HrothEyebrowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowLeft_Y), CharacterDetails.HrothEyebrowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowLeft_Z), CharacterDetails.HrothEyebrowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowLeft_W), CharacterDetails.HrothEyebrowLeft_W.GetBytes());
                    }

                    if (CharacterDetails.LipsRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsRight_X), CharacterDetails.LipsRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsRight_Y), CharacterDetails.LipsRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsRight_Z), CharacterDetails.LipsRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsRight_W), CharacterDetails.LipsRight_W.GetBytes());
                    }

                    if (CharacterDetails.HrothEyebrowRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowRight_X), CharacterDetails.HrothEyebrowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowRight_Y), CharacterDetails.HrothEyebrowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowRight_Z), CharacterDetails.HrothEyebrowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowRight_W), CharacterDetails.HrothEyebrowRight_W.GetBytes());
                    }

                    if (CharacterDetails.EyebrowLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowLeft_X), CharacterDetails.EyebrowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowLeft_Y), CharacterDetails.EyebrowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowLeft_Z), CharacterDetails.EyebrowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowLeft_W), CharacterDetails.EyebrowLeft_W.GetBytes());
                    }

                    if (CharacterDetails.HrothBridge_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBridge_X), CharacterDetails.HrothBridge_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBridge_Y), CharacterDetails.HrothBridge_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBridge_Z), CharacterDetails.HrothBridge_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBridge_W), CharacterDetails.HrothBridge_W.GetBytes());
                    }

                    if (CharacterDetails.EyebrowRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowRight_X), CharacterDetails.EyebrowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowRight_Y), CharacterDetails.EyebrowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowRight_Z), CharacterDetails.EyebrowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowRight_W), CharacterDetails.EyebrowRight_W.GetBytes());
                    }

                    if (CharacterDetails.HrothBrowLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowLeft_X), CharacterDetails.HrothBrowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowLeft_Y), CharacterDetails.HrothBrowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowLeft_Z), CharacterDetails.HrothBrowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowLeft_W), CharacterDetails.HrothBrowLeft_W.GetBytes());
                    }

                    if (CharacterDetails.Bridge_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Bridge_X), CharacterDetails.Bridge_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Bridge_Y), CharacterDetails.Bridge_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Bridge_Z), CharacterDetails.Bridge_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Bridge_W), CharacterDetails.Bridge_W.GetBytes());
                    }

                    if (CharacterDetails.HrothBrowRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowRight_X), CharacterDetails.HrothBrowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowRight_Y), CharacterDetails.HrothBrowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowRight_Z), CharacterDetails.HrothBrowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowRight_W), CharacterDetails.HrothBrowRight_W.GetBytes());
                    }

                    if (CharacterDetails.BrowLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowLeft_X), CharacterDetails.BrowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowLeft_Y), CharacterDetails.BrowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowLeft_Z), CharacterDetails.BrowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowLeft_W), CharacterDetails.BrowLeft_W.GetBytes());
                    }

                    if (CharacterDetails.HrothJawUpper_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothJawUpper_X), CharacterDetails.HrothJawUpper_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothJawUpper_Y), CharacterDetails.HrothJawUpper_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothJawUpper_Z), CharacterDetails.HrothJawUpper_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothJawUpper_W), CharacterDetails.HrothJawUpper_W.GetBytes());
                    }

                    if (CharacterDetails.BrowRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowRight_X), CharacterDetails.BrowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowRight_Y), CharacterDetails.BrowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowRight_Z), CharacterDetails.BrowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowRight_W), CharacterDetails.BrowRight_W.GetBytes());
                    }

                    if (CharacterDetails.HrothLipUpper_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpper_X), CharacterDetails.HrothLipUpper_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpper_Y), CharacterDetails.HrothLipUpper_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpper_Z), CharacterDetails.HrothLipUpper_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpper_W), CharacterDetails.HrothLipUpper_W.GetBytes());
                    }

                    if (CharacterDetails.LipUpperA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperA_X), CharacterDetails.LipUpperA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperA_Y), CharacterDetails.LipUpperA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperA_Z), CharacterDetails.LipUpperA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperA_W), CharacterDetails.LipUpperA_W.GetBytes());
                    }

                    if (CharacterDetails.HrothEyelidUpperLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_X), CharacterDetails.HrothEyelidUpperLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_Y), CharacterDetails.HrothEyelidUpperLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_Z), CharacterDetails.HrothEyelidUpperLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_W), CharacterDetails.HrothEyelidUpperLeft_W.GetBytes());
                    }

                    if (CharacterDetails.EyelidUpperLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperLeft_X), CharacterDetails.EyelidUpperLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperLeft_Y), CharacterDetails.EyelidUpperLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperLeft_Z), CharacterDetails.EyelidUpperLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperLeft_W), CharacterDetails.EyelidUpperLeft_W.GetBytes());
                    }

                    if (CharacterDetails.HrothEyelidUpperRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_X), CharacterDetails.HrothEyelidUpperRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_Y), CharacterDetails.HrothEyelidUpperRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_Z), CharacterDetails.HrothEyelidUpperRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_W), CharacterDetails.HrothEyelidUpperRight_W.GetBytes());
                    }

                    if (CharacterDetails.EyelidUpperRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperRight_X), CharacterDetails.EyelidUpperRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperRight_Y), CharacterDetails.EyelidUpperRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperRight_Z), CharacterDetails.EyelidUpperRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperRight_W), CharacterDetails.EyelidUpperRight_W.GetBytes());
                    }

                    if (CharacterDetails.HrothLipsLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsLeft_X), CharacterDetails.HrothLipsLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsLeft_Y), CharacterDetails.HrothLipsLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsLeft_Z), CharacterDetails.HrothLipsLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsLeft_W), CharacterDetails.HrothLipsLeft_W.GetBytes());
                    }

                    if (CharacterDetails.LipLowerA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerA_X), CharacterDetails.LipLowerA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerA_Y), CharacterDetails.LipLowerA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerA_Z), CharacterDetails.LipLowerA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerA_W), CharacterDetails.LipLowerA_W.GetBytes());
                    }

                    if (CharacterDetails.HrothLipsRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsRight_X), CharacterDetails.HrothLipsRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsRight_Y), CharacterDetails.HrothLipsRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsRight_Z), CharacterDetails.HrothLipsRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsRight_W), CharacterDetails.HrothLipsRight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar01ALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ALeft_X), CharacterDetails.VieraEar01ALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ALeft_Y), CharacterDetails.VieraEar01ALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ALeft_Z), CharacterDetails.VieraEar01ALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ALeft_W), CharacterDetails.VieraEar01ALeft_W.GetBytes());
                    }

                    if (CharacterDetails.LipUpperB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperB_X), CharacterDetails.LipUpperB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperB_Y), CharacterDetails.LipUpperB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperB_Z), CharacterDetails.LipUpperB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperB_W), CharacterDetails.LipUpperB_W.GetBytes());
                    }

                    if (CharacterDetails.HrothLipUpperLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperLeft_X), CharacterDetails.HrothLipUpperLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperLeft_Y), CharacterDetails.HrothLipUpperLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperLeft_Z), CharacterDetails.HrothLipUpperLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperLeft_W), CharacterDetails.HrothLipUpperLeft_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar01ARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ARight_X), CharacterDetails.VieraEar01ARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ARight_Y), CharacterDetails.VieraEar01ARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ARight_Z), CharacterDetails.VieraEar01ARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ARight_W), CharacterDetails.VieraEar01ARight_W.GetBytes());
                    }

                    if (CharacterDetails.LipLowerB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerB_X), CharacterDetails.LipLowerB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerB_Y), CharacterDetails.LipLowerB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerB_Z), CharacterDetails.LipLowerB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerB_W), CharacterDetails.LipLowerB_W.GetBytes());
                    }

                    if (CharacterDetails.HrothLipUpperRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperRight_X), CharacterDetails.HrothLipUpperRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperRight_Y), CharacterDetails.HrothLipUpperRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperRight_Z), CharacterDetails.HrothLipUpperRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperRight_W), CharacterDetails.HrothLipUpperRight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar02ALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ALeft_X), CharacterDetails.VieraEar02ALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ALeft_Y), CharacterDetails.VieraEar02ALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ALeft_Z), CharacterDetails.VieraEar02ALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ALeft_W), CharacterDetails.VieraEar02ALeft_W.GetBytes());
                    }

                    if (CharacterDetails.HrothLipLower_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipLower_X), CharacterDetails.HrothLipLower_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipLower_Y), CharacterDetails.HrothLipLower_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipLower_Z), CharacterDetails.HrothLipLower_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipLower_W), CharacterDetails.HrothLipLower_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar02ARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ARight_X), CharacterDetails.VieraEar02ARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ARight_Y), CharacterDetails.VieraEar02ARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ARight_Z), CharacterDetails.VieraEar02ARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ARight_W), CharacterDetails.VieraEar02ARight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar03ALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ALeft_X), CharacterDetails.VieraEar03ALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ALeft_Y), CharacterDetails.VieraEar03ALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ALeft_Z), CharacterDetails.VieraEar03ALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ALeft_W), CharacterDetails.VieraEar03ALeft_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar03ARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ARight_X), CharacterDetails.VieraEar03ARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ARight_Y), CharacterDetails.VieraEar03ARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ARight_Z), CharacterDetails.VieraEar03ARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ARight_W), CharacterDetails.VieraEar03ARight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar04ALeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ALeft_X), CharacterDetails.VieraEar04ALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ALeft_Y), CharacterDetails.VieraEar04ALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ALeft_Z), CharacterDetails.VieraEar04ALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ALeft_W), CharacterDetails.VieraEar04ALeft_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar04ARight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ARight_X), CharacterDetails.VieraEar04ARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ARight_Y), CharacterDetails.VieraEar04ARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ARight_Z), CharacterDetails.VieraEar04ARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ARight_W), CharacterDetails.VieraEar04ARight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraLipLowerA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerA_X), CharacterDetails.VieraLipLowerA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerA_Y), CharacterDetails.VieraLipLowerA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerA_Z), CharacterDetails.VieraLipLowerA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerA_W), CharacterDetails.VieraLipLowerA_W.GetBytes());
                    }

                    if (CharacterDetails.VieraLipUpperB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipUpperB_X), CharacterDetails.VieraLipUpperB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipUpperB_Y), CharacterDetails.VieraLipUpperB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipUpperB_Z), CharacterDetails.VieraLipUpperB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipUpperB_W), CharacterDetails.VieraLipUpperB_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar01BLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BLeft_X), CharacterDetails.VieraEar01BLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BLeft_Y), CharacterDetails.VieraEar01BLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BLeft_Z), CharacterDetails.VieraEar01BLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BLeft_W), CharacterDetails.VieraEar01BLeft_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar01BRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BRight_X), CharacterDetails.VieraEar01BRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BRight_Y), CharacterDetails.VieraEar01BRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BRight_Z), CharacterDetails.VieraEar01BRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BRight_W), CharacterDetails.VieraEar01BRight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar02BLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BLeft_X), CharacterDetails.VieraEar02BLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BLeft_Y), CharacterDetails.VieraEar02BLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BLeft_Z), CharacterDetails.VieraEar02BLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BLeft_W), CharacterDetails.VieraEar02BLeft_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar02BRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BRight_X), CharacterDetails.VieraEar02BRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BRight_Y), CharacterDetails.VieraEar02BRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BRight_Z), CharacterDetails.VieraEar02BRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BRight_W), CharacterDetails.VieraEar02BRight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar03BLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BLeft_X), CharacterDetails.VieraEar03BLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BLeft_Y), CharacterDetails.VieraEar03BLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BLeft_Z), CharacterDetails.VieraEar03BLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BLeft_W), CharacterDetails.VieraEar03BLeft_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar03BRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BRight_X), CharacterDetails.VieraEar03BRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BRight_Y), CharacterDetails.VieraEar03BRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BRight_Z), CharacterDetails.VieraEar03BRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BRight_W), CharacterDetails.VieraEar03BRight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar04BLeft_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BLeft_X), CharacterDetails.VieraEar04BLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BLeft_Y), CharacterDetails.VieraEar04BLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BLeft_Z), CharacterDetails.VieraEar04BLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BLeft_W), CharacterDetails.VieraEar04BLeft_W.GetBytes());
                    }

                    if (CharacterDetails.VieraEar04BRight_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BRight_X), CharacterDetails.VieraEar04BRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BRight_Y), CharacterDetails.VieraEar04BRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BRight_Z), CharacterDetails.VieraEar04BRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BRight_W), CharacterDetails.VieraEar04BRight_W.GetBytes());
                    }

                    if (CharacterDetails.VieraLipLowerB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerB_X), CharacterDetails.VieraLipLowerB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerB_Y), CharacterDetails.VieraLipLowerB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerB_Z), CharacterDetails.VieraLipLowerB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerB_W), CharacterDetails.VieraLipLowerB_W.GetBytes());
                    }

                    if (CharacterDetails.ExRootHair_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootHair_X), CharacterDetails.ExRootHair_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootHair_Y), CharacterDetails.ExRootHair_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootHair_Z), CharacterDetails.ExRootHair_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootHair_W), CharacterDetails.ExRootHair_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairA_X), CharacterDetails.ExHairA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairA_Y), CharacterDetails.ExHairA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairA_Z), CharacterDetails.ExHairA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairA_W), CharacterDetails.ExHairA_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairB_X), CharacterDetails.ExHairB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairB_Y), CharacterDetails.ExHairB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairB_Z), CharacterDetails.ExHairB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairB_W), CharacterDetails.ExHairB_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairC_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairC_X), CharacterDetails.ExHairC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairC_Y), CharacterDetails.ExHairC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairC_Z), CharacterDetails.ExHairC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairC_W), CharacterDetails.ExHairC_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairD_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairD_X), CharacterDetails.ExHairD_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairD_Y), CharacterDetails.ExHairD_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairD_Z), CharacterDetails.ExHairD_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairD_W), CharacterDetails.ExHairD_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairE_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairE_X), CharacterDetails.ExHairE_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairE_Y), CharacterDetails.ExHairE_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairE_Z), CharacterDetails.ExHairE_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairE_W), CharacterDetails.ExHairE_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairF_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairF_X), CharacterDetails.ExHairF_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairF_Y), CharacterDetails.ExHairF_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairF_Z), CharacterDetails.ExHairF_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairF_W), CharacterDetails.ExHairF_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairG_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairG_X), CharacterDetails.ExHairG_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairG_Y), CharacterDetails.ExHairG_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairG_Z), CharacterDetails.ExHairG_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairG_W), CharacterDetails.ExHairG_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairH_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairH_X), CharacterDetails.ExHairH_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairH_Y), CharacterDetails.ExHairH_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairH_Z), CharacterDetails.ExHairH_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairH_W), CharacterDetails.ExHairH_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairI_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairI_X), CharacterDetails.ExHairI_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairI_Y), CharacterDetails.ExHairI_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairI_Z), CharacterDetails.ExHairI_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairI_W), CharacterDetails.ExHairI_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairJ_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairJ_X), CharacterDetails.ExHairJ_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairJ_Y), CharacterDetails.ExHairJ_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairJ_Z), CharacterDetails.ExHairJ_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairJ_W), CharacterDetails.ExHairJ_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairK_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairK_X), CharacterDetails.ExHairK_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairK_Y), CharacterDetails.ExHairK_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairK_Z), CharacterDetails.ExHairK_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairK_W), CharacterDetails.ExHairK_W.GetBytes());
                    }

                    if (CharacterDetails.ExHairL_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairL_X), CharacterDetails.ExHairL_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairL_Y), CharacterDetails.ExHairL_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairL_Z), CharacterDetails.ExHairL_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairL_W), CharacterDetails.ExHairL_W.GetBytes());
                    }

                    if (CharacterDetails.ExRootMet_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootMet_X), CharacterDetails.ExRootMet_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootMet_Y), CharacterDetails.ExRootMet_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootMet_Z), CharacterDetails.ExRootMet_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootMet_W), CharacterDetails.ExRootMet_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetA_X), CharacterDetails.ExMetA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetA_Y), CharacterDetails.ExMetA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetA_Z), CharacterDetails.ExMetA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetA_W), CharacterDetails.ExMetA_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetB_X), CharacterDetails.ExMetB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetB_Y), CharacterDetails.ExMetB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetB_Z), CharacterDetails.ExMetB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetB_W), CharacterDetails.ExMetB_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetC_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetC_X), CharacterDetails.ExMetC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetC_Y), CharacterDetails.ExMetC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetC_Z), CharacterDetails.ExMetC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetC_W), CharacterDetails.ExMetC_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetD_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetD_X), CharacterDetails.ExMetD_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetD_Y), CharacterDetails.ExMetD_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetD_Z), CharacterDetails.ExMetD_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetD_W), CharacterDetails.ExMetD_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetE_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetE_X), CharacterDetails.ExMetE_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetE_Y), CharacterDetails.ExMetE_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetE_Z), CharacterDetails.ExMetE_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetE_W), CharacterDetails.ExMetE_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetF_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetF_X), CharacterDetails.ExMetF_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetF_Y), CharacterDetails.ExMetF_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetF_Z), CharacterDetails.ExMetF_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetF_W), CharacterDetails.ExMetF_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetG_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetG_X), CharacterDetails.ExMetG_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetG_Y), CharacterDetails.ExMetG_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetG_Z), CharacterDetails.ExMetG_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetG_W), CharacterDetails.ExMetG_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetH_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetH_X), CharacterDetails.ExMetH_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetH_Y), CharacterDetails.ExMetH_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetH_Z), CharacterDetails.ExMetH_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetH_W), CharacterDetails.ExMetH_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetI_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetI_X), CharacterDetails.ExMetI_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetI_Y), CharacterDetails.ExMetI_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetI_Z), CharacterDetails.ExMetI_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetI_W), CharacterDetails.ExMetI_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetJ_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetJ_X), CharacterDetails.ExMetJ_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetJ_Y), CharacterDetails.ExMetJ_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetJ_Z), CharacterDetails.ExMetJ_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetJ_W), CharacterDetails.ExMetJ_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetK_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetK_X), CharacterDetails.ExMetK_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetK_Y), CharacterDetails.ExMetK_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetK_Z), CharacterDetails.ExMetK_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetK_W), CharacterDetails.ExMetK_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetL_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetL_X), CharacterDetails.ExMetL_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetL_Y), CharacterDetails.ExMetL_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetL_Z), CharacterDetails.ExMetL_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetL_W), CharacterDetails.ExMetL_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetM_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetM_X), CharacterDetails.ExMetM_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetM_Y), CharacterDetails.ExMetM_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetM_Z), CharacterDetails.ExMetM_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetM_W), CharacterDetails.ExMetM_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetN_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetN_X), CharacterDetails.ExMetN_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetN_Y), CharacterDetails.ExMetN_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetN_Z), CharacterDetails.ExMetN_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetN_W), CharacterDetails.ExMetN_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetO_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetO_X), CharacterDetails.ExMetO_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetO_Y), CharacterDetails.ExMetO_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetO_Z), CharacterDetails.ExMetO_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetO_W), CharacterDetails.ExMetO_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetP_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetP_X), CharacterDetails.ExMetP_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetP_Y), CharacterDetails.ExMetP_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetP_Z), CharacterDetails.ExMetP_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetP_W), CharacterDetails.ExMetP_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetQ_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetQ_X), CharacterDetails.ExMetQ_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetQ_Y), CharacterDetails.ExMetQ_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetQ_Z), CharacterDetails.ExMetQ_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetQ_W), CharacterDetails.ExMetQ_W.GetBytes());
                    }

                    if (CharacterDetails.ExMetR_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetR_X), CharacterDetails.ExMetR_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetR_Y), CharacterDetails.ExMetR_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetR_Z), CharacterDetails.ExMetR_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetR_W), CharacterDetails.ExMetR_W.GetBytes());
                    }

                    if (CharacterDetails.ExRootTop_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootTop_X), CharacterDetails.ExRootTop_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootTop_Y), CharacterDetails.ExRootTop_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootTop_Z), CharacterDetails.ExRootTop_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExRootTop_W), CharacterDetails.ExRootTop_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopA_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopA_X), CharacterDetails.ExTopA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopA_Y), CharacterDetails.ExTopA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopA_Z), CharacterDetails.ExTopA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopA_W), CharacterDetails.ExTopA_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopB_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopB_X), CharacterDetails.ExTopB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopB_Y), CharacterDetails.ExTopB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopB_Z), CharacterDetails.ExTopB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopB_W), CharacterDetails.ExTopB_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopC_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopC_X), CharacterDetails.ExTopC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopC_Y), CharacterDetails.ExTopC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopC_Z), CharacterDetails.ExTopC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopC_W), CharacterDetails.ExTopC_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopD_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopD_X), CharacterDetails.ExTopD_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopD_Y), CharacterDetails.ExTopD_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopD_Z), CharacterDetails.ExTopD_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopD_W), CharacterDetails.ExTopD_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopE_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopE_X), CharacterDetails.ExTopE_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopE_Y), CharacterDetails.ExTopE_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopE_Z), CharacterDetails.ExTopE_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopE_W), CharacterDetails.ExTopE_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopF_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopF_X), CharacterDetails.ExTopF_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopF_Y), CharacterDetails.ExTopF_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopF_Z), CharacterDetails.ExTopF_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopF_W), CharacterDetails.ExTopF_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopG_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopG_X), CharacterDetails.ExTopG_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopG_Y), CharacterDetails.ExTopG_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopG_Z), CharacterDetails.ExTopG_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopG_W), CharacterDetails.ExTopG_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopH_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopH_X), CharacterDetails.ExTopH_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopH_Y), CharacterDetails.ExTopH_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopH_Z), CharacterDetails.ExTopH_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopH_W), CharacterDetails.ExTopH_W.GetBytes());
                    }

                    if (CharacterDetails.ExTopI_Rotate)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopI_X), CharacterDetails.ExTopI_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopI_Y), CharacterDetails.ExTopI_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopI_Z), CharacterDetails.ExTopI_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopI_W), CharacterDetails.ExTopI_W.GetBytes());
                    }
                    #endregion
                    #region Bone Savestate Writing

                    if (CharacterDetails.WriteHead == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Head_X), CharacterDetails.Head_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Head_Y), CharacterDetails.Head_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Head_Z), CharacterDetails.Head_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Head_W), CharacterDetails.Head_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarLeft_X), CharacterDetails.EarLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarLeft_Y), CharacterDetails.EarLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarLeft_Z), CharacterDetails.EarLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarLeft_W), CharacterDetails.EarLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarRight_X), CharacterDetails.EarRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarRight_Y), CharacterDetails.EarRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarRight_Z), CharacterDetails.EarRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarRight_W), CharacterDetails.EarRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Jaw_X), CharacterDetails.Jaw_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Jaw_Y), CharacterDetails.Jaw_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Jaw_Z), CharacterDetails.Jaw_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Jaw_W), CharacterDetails.Jaw_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerLeft_X), CharacterDetails.EyelidLowerLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerLeft_Y), CharacterDetails.EyelidLowerLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerLeft_Z), CharacterDetails.EyelidLowerLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerLeft_W), CharacterDetails.EyelidLowerLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerRight_X), CharacterDetails.EyelidLowerRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerRight_Y), CharacterDetails.EyelidLowerRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerRight_Z), CharacterDetails.EyelidLowerRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidLowerRight_W), CharacterDetails.EyelidLowerRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeLeft_X), CharacterDetails.EyeLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeLeft_Y), CharacterDetails.EyeLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeLeft_Z), CharacterDetails.EyeLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeLeft_W), CharacterDetails.EyeLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeRight_X), CharacterDetails.EyeRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeRight_Y), CharacterDetails.EyeRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeRight_Z), CharacterDetails.EyeRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyeRight_W), CharacterDetails.EyeRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Nose_X), CharacterDetails.Nose_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Nose_Y), CharacterDetails.Nose_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Nose_Z), CharacterDetails.Nose_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Nose_W), CharacterDetails.Nose_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekLeft_X), CharacterDetails.CheekLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekLeft_Y), CharacterDetails.CheekLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekLeft_Z), CharacterDetails.CheekLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekLeft_W), CharacterDetails.CheekLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersLeft_X), CharacterDetails.HrothWhiskersLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersLeft_Y), CharacterDetails.HrothWhiskersLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersLeft_Z), CharacterDetails.HrothWhiskersLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersLeft_W), CharacterDetails.HrothWhiskersLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekRight_X), CharacterDetails.CheekRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekRight_Y), CharacterDetails.CheekRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekRight_Z), CharacterDetails.CheekRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CheekRight_W), CharacterDetails.CheekRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersRight_X), CharacterDetails.HrothWhiskersRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersRight_Y), CharacterDetails.HrothWhiskersRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersRight_Z), CharacterDetails.HrothWhiskersRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothWhiskersRight_W), CharacterDetails.HrothWhiskersRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsLeft_X), CharacterDetails.LipsLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsLeft_Y), CharacterDetails.LipsLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsLeft_Z), CharacterDetails.LipsLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsLeft_W), CharacterDetails.LipsLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowLeft_X), CharacterDetails.HrothEyebrowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowLeft_Y), CharacterDetails.HrothEyebrowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowLeft_Z), CharacterDetails.HrothEyebrowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowLeft_W), CharacterDetails.HrothEyebrowLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsRight_X), CharacterDetails.LipsRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsRight_Y), CharacterDetails.LipsRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsRight_Z), CharacterDetails.LipsRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipsRight_W), CharacterDetails.LipsRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowRight_X), CharacterDetails.HrothEyebrowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowRight_Y), CharacterDetails.HrothEyebrowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowRight_Z), CharacterDetails.HrothEyebrowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyebrowRight_W), CharacterDetails.HrothEyebrowRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowLeft_X), CharacterDetails.EyebrowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowLeft_Y), CharacterDetails.EyebrowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowLeft_Z), CharacterDetails.EyebrowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowLeft_W), CharacterDetails.EyebrowLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBridge_X), CharacterDetails.HrothBridge_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBridge_Y), CharacterDetails.HrothBridge_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBridge_Z), CharacterDetails.HrothBridge_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBridge_W), CharacterDetails.HrothBridge_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowRight_X), CharacterDetails.EyebrowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowRight_Y), CharacterDetails.EyebrowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowRight_Z), CharacterDetails.EyebrowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyebrowRight_W), CharacterDetails.EyebrowRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowLeft_X), CharacterDetails.HrothBrowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowLeft_Y), CharacterDetails.HrothBrowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowLeft_Z), CharacterDetails.HrothBrowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowLeft_W), CharacterDetails.HrothBrowLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Bridge_X), CharacterDetails.Bridge_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Bridge_Y), CharacterDetails.Bridge_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Bridge_Z), CharacterDetails.Bridge_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Bridge_W), CharacterDetails.Bridge_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowRight_X), CharacterDetails.HrothBrowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowRight_Y), CharacterDetails.HrothBrowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowRight_Z), CharacterDetails.HrothBrowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothBrowRight_W), CharacterDetails.HrothBrowRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowLeft_X), CharacterDetails.BrowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowLeft_Y), CharacterDetails.BrowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowLeft_Z), CharacterDetails.BrowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowLeft_W), CharacterDetails.BrowLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothJawUpper_X), CharacterDetails.HrothJawUpper_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothJawUpper_Y), CharacterDetails.HrothJawUpper_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothJawUpper_Z), CharacterDetails.HrothJawUpper_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothJawUpper_W), CharacterDetails.HrothJawUpper_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowRight_X), CharacterDetails.BrowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowRight_Y), CharacterDetails.BrowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowRight_Z), CharacterDetails.BrowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BrowRight_W), CharacterDetails.BrowRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpper_X), CharacterDetails.HrothLipUpper_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpper_Y), CharacterDetails.HrothLipUpper_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpper_Z), CharacterDetails.HrothLipUpper_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpper_W), CharacterDetails.HrothLipUpper_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperA_X), CharacterDetails.LipUpperA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperA_Y), CharacterDetails.LipUpperA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperA_Z), CharacterDetails.LipUpperA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperA_W), CharacterDetails.LipUpperA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_X), CharacterDetails.HrothEyelidUpperLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_Y), CharacterDetails.HrothEyelidUpperLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_Z), CharacterDetails.HrothEyelidUpperLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperLeft_W), CharacterDetails.HrothEyelidUpperLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperLeft_X), CharacterDetails.EyelidUpperLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperLeft_Y), CharacterDetails.EyelidUpperLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperLeft_Z), CharacterDetails.EyelidUpperLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperLeft_W), CharacterDetails.EyelidUpperLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_X), CharacterDetails.HrothEyelidUpperRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_Y), CharacterDetails.HrothEyelidUpperRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_Z), CharacterDetails.HrothEyelidUpperRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothEyelidUpperRight_W), CharacterDetails.HrothEyelidUpperRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperRight_X), CharacterDetails.EyelidUpperRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperRight_Y), CharacterDetails.EyelidUpperRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperRight_Z), CharacterDetails.EyelidUpperRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EyelidUpperRight_W), CharacterDetails.EyelidUpperRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsLeft_X), CharacterDetails.HrothLipsLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsLeft_Y), CharacterDetails.HrothLipsLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsLeft_Z), CharacterDetails.HrothLipsLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsLeft_W), CharacterDetails.HrothLipsLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerA_X), CharacterDetails.LipLowerA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerA_Y), CharacterDetails.LipLowerA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerA_Z), CharacterDetails.LipLowerA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerA_W), CharacterDetails.LipLowerA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsRight_X), CharacterDetails.HrothLipsRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsRight_Y), CharacterDetails.HrothLipsRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsRight_Z), CharacterDetails.HrothLipsRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipsRight_W), CharacterDetails.HrothLipsRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ALeft_X), CharacterDetails.VieraEar01ALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ALeft_Y), CharacterDetails.VieraEar01ALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ALeft_Z), CharacterDetails.VieraEar01ALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ALeft_W), CharacterDetails.VieraEar01ALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperB_X), CharacterDetails.LipUpperB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperB_Y), CharacterDetails.LipUpperB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperB_Z), CharacterDetails.LipUpperB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipUpperB_W), CharacterDetails.LipUpperB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperLeft_X), CharacterDetails.HrothLipUpperLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperLeft_Y), CharacterDetails.HrothLipUpperLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperLeft_Z), CharacterDetails.HrothLipUpperLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperLeft_W), CharacterDetails.HrothLipUpperLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ARight_X), CharacterDetails.VieraEar01ARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ARight_Y), CharacterDetails.VieraEar01ARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ARight_Z), CharacterDetails.VieraEar01ARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01ARight_W), CharacterDetails.VieraEar01ARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerB_X), CharacterDetails.LipLowerB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerB_Y), CharacterDetails.LipLowerB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerB_Z), CharacterDetails.LipLowerB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LipLowerB_W), CharacterDetails.LipLowerB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperRight_X), CharacterDetails.HrothLipUpperRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperRight_Y), CharacterDetails.HrothLipUpperRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperRight_Z), CharacterDetails.HrothLipUpperRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipUpperRight_W), CharacterDetails.HrothLipUpperRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ALeft_X), CharacterDetails.VieraEar02ALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ALeft_Y), CharacterDetails.VieraEar02ALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ALeft_Z), CharacterDetails.VieraEar02ALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ALeft_W), CharacterDetails.VieraEar02ALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipLower_X), CharacterDetails.HrothLipLower_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipLower_Y), CharacterDetails.HrothLipLower_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipLower_Z), CharacterDetails.HrothLipLower_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HrothLipLower_W), CharacterDetails.HrothLipLower_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ARight_X), CharacterDetails.VieraEar02ARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ARight_Y), CharacterDetails.VieraEar02ARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ARight_Z), CharacterDetails.VieraEar02ARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02ARight_W), CharacterDetails.VieraEar02ARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ALeft_X), CharacterDetails.VieraEar03ALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ALeft_Y), CharacterDetails.VieraEar03ALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ALeft_Z), CharacterDetails.VieraEar03ALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ALeft_W), CharacterDetails.VieraEar03ALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ARight_X), CharacterDetails.VieraEar03ARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ARight_Y), CharacterDetails.VieraEar03ARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ARight_Z), CharacterDetails.VieraEar03ARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03ARight_W), CharacterDetails.VieraEar03ARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ALeft_X), CharacterDetails.VieraEar04ALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ALeft_Y), CharacterDetails.VieraEar04ALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ALeft_Z), CharacterDetails.VieraEar04ALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ALeft_W), CharacterDetails.VieraEar04ALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ARight_X), CharacterDetails.VieraEar04ARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ARight_Y), CharacterDetails.VieraEar04ARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ARight_Z), CharacterDetails.VieraEar04ARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04ARight_W), CharacterDetails.VieraEar04ARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerA_X), CharacterDetails.VieraLipLowerA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerA_Y), CharacterDetails.VieraLipLowerA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerA_Z), CharacterDetails.VieraLipLowerA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerA_W), CharacterDetails.VieraLipLowerA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipUpperB_X), CharacterDetails.VieraLipUpperB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipUpperB_Y), CharacterDetails.VieraLipUpperB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipUpperB_Z), CharacterDetails.VieraLipUpperB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipUpperB_W), CharacterDetails.VieraLipUpperB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BLeft_X), CharacterDetails.VieraEar01BLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BLeft_Y), CharacterDetails.VieraEar01BLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BLeft_Z), CharacterDetails.VieraEar01BLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BLeft_W), CharacterDetails.VieraEar01BLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BRight_X), CharacterDetails.VieraEar01BRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BRight_Y), CharacterDetails.VieraEar01BRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BRight_Z), CharacterDetails.VieraEar01BRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar01BRight_W), CharacterDetails.VieraEar01BRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BLeft_X), CharacterDetails.VieraEar02BLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BLeft_Y), CharacterDetails.VieraEar02BLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BLeft_Z), CharacterDetails.VieraEar02BLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BLeft_W), CharacterDetails.VieraEar02BLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BRight_X), CharacterDetails.VieraEar02BRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BRight_Y), CharacterDetails.VieraEar02BRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BRight_Z), CharacterDetails.VieraEar02BRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar02BRight_W), CharacterDetails.VieraEar02BRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BLeft_X), CharacterDetails.VieraEar03BLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BLeft_Y), CharacterDetails.VieraEar03BLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BLeft_Z), CharacterDetails.VieraEar03BLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BLeft_W), CharacterDetails.VieraEar03BLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BRight_X), CharacterDetails.VieraEar03BRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BRight_Y), CharacterDetails.VieraEar03BRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BRight_Z), CharacterDetails.VieraEar03BRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar03BRight_W), CharacterDetails.VieraEar03BRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BLeft_X), CharacterDetails.VieraEar04BLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BLeft_Y), CharacterDetails.VieraEar04BLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BLeft_Z), CharacterDetails.VieraEar04BLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BLeft_W), CharacterDetails.VieraEar04BLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BRight_X), CharacterDetails.VieraEar04BRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BRight_Y), CharacterDetails.VieraEar04BRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BRight_Z), CharacterDetails.VieraEar04BRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraEar04BRight_W), CharacterDetails.VieraEar04BRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerB_X), CharacterDetails.VieraLipLowerB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerB_Y), CharacterDetails.VieraLipLowerB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerB_Z), CharacterDetails.VieraLipLowerB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.VieraLipLowerB_W), CharacterDetails.VieraLipLowerB_W.GetBytes());
                        CharacterDetails.WriteHead = false;
                    }
                    if (CharacterDetails.WriteHair == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairA_X), CharacterDetails.HairA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairA_Y), CharacterDetails.HairA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairA_Z), CharacterDetails.HairA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairA_W), CharacterDetails.HairA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontLeft_X), CharacterDetails.HairFrontLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontLeft_Y), CharacterDetails.HairFrontLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontLeft_Z), CharacterDetails.HairFrontLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontLeft_W), CharacterDetails.HairFrontLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontRight_X), CharacterDetails.HairFrontRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontRight_Y), CharacterDetails.HairFrontRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontRight_Z), CharacterDetails.HairFrontRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairFrontRight_W), CharacterDetails.HairFrontRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairB_X), CharacterDetails.HairB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairB_Y), CharacterDetails.HairB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairB_Z), CharacterDetails.HairB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HairB_W), CharacterDetails.HairB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairA_X), CharacterDetails.ExHairA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairA_Y), CharacterDetails.ExHairA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairA_Z), CharacterDetails.ExHairA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairA_W), CharacterDetails.ExHairA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairB_X), CharacterDetails.ExHairB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairB_Y), CharacterDetails.ExHairB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairB_Z), CharacterDetails.ExHairB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairB_W), CharacterDetails.ExHairB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairC_X), CharacterDetails.ExHairC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairC_Y), CharacterDetails.ExHairC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairC_Z), CharacterDetails.ExHairC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairC_W), CharacterDetails.ExHairC_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairD_X), CharacterDetails.ExHairD_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairD_Y), CharacterDetails.ExHairD_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairD_Z), CharacterDetails.ExHairD_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairD_W), CharacterDetails.ExHairD_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairE_X), CharacterDetails.ExHairE_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairE_Y), CharacterDetails.ExHairE_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairE_Z), CharacterDetails.ExHairE_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairE_W), CharacterDetails.ExHairE_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairF_X), CharacterDetails.ExHairF_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairF_Y), CharacterDetails.ExHairF_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairF_Z), CharacterDetails.ExHairF_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairF_W), CharacterDetails.ExHairF_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairG_X), CharacterDetails.ExHairG_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairG_Y), CharacterDetails.ExHairG_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairG_Z), CharacterDetails.ExHairG_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairG_W), CharacterDetails.ExHairG_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairH_X), CharacterDetails.ExHairH_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairH_Y), CharacterDetails.ExHairH_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairH_Z), CharacterDetails.ExHairH_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairH_W), CharacterDetails.ExHairH_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairI_X), CharacterDetails.ExHairI_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairI_Y), CharacterDetails.ExHairI_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairI_Z), CharacterDetails.ExHairI_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairI_W), CharacterDetails.ExHairI_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairJ_X), CharacterDetails.ExHairJ_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairJ_Y), CharacterDetails.ExHairJ_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairJ_Z), CharacterDetails.ExHairJ_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairJ_W), CharacterDetails.ExHairJ_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairK_X), CharacterDetails.ExHairK_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairK_Y), CharacterDetails.ExHairK_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairK_Z), CharacterDetails.ExHairK_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairK_W), CharacterDetails.ExHairK_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairL_X), CharacterDetails.ExHairL_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairL_Y), CharacterDetails.ExHairL_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairL_Z), CharacterDetails.ExHairL_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExHairL_W), CharacterDetails.ExHairL_W.GetBytes());
                        CharacterDetails.WriteHair = false;
                    }
                    if (CharacterDetails.WriteEarrings == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringALeft_X), CharacterDetails.EarringALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringALeft_Y), CharacterDetails.EarringALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringALeft_Z), CharacterDetails.EarringALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringALeft_W), CharacterDetails.EarringALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringARight_X), CharacterDetails.EarringARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringARight_Y), CharacterDetails.EarringARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringARight_Z), CharacterDetails.EarringARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringARight_W), CharacterDetails.EarringARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBLeft_X), CharacterDetails.EarringBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBLeft_Y), CharacterDetails.EarringBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBLeft_Z), CharacterDetails.EarringBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBLeft_W), CharacterDetails.EarringBLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBRight_X), CharacterDetails.EarringBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBRight_Y), CharacterDetails.EarringBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBRight_Z), CharacterDetails.EarringBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.EarringBRight_W), CharacterDetails.EarringBRight_W.GetBytes());
                        CharacterDetails.WriteEarrings = false;
                    }
                    if (CharacterDetails.WriteBody == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineA_X), CharacterDetails.SpineA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineA_Y), CharacterDetails.SpineA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineA_Z), CharacterDetails.SpineA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineA_W), CharacterDetails.SpineA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineB_X), CharacterDetails.SpineB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineB_Y), CharacterDetails.SpineB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineB_Z), CharacterDetails.SpineB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineB_W), CharacterDetails.SpineB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastLeft_X), CharacterDetails.BreastLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastLeft_Y), CharacterDetails.BreastLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastLeft_Z), CharacterDetails.BreastLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastLeft_W), CharacterDetails.BreastLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastRight_X), CharacterDetails.BreastRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastRight_Y), CharacterDetails.BreastRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastRight_Z), CharacterDetails.BreastRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.BreastRight_W), CharacterDetails.BreastRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineC_X), CharacterDetails.SpineC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineC_Y), CharacterDetails.SpineC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineC_Z), CharacterDetails.SpineC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SpineC_W), CharacterDetails.SpineC_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardLeft_X), CharacterDetails.ScabbardLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardLeft_Y), CharacterDetails.ScabbardLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardLeft_Z), CharacterDetails.ScabbardLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardLeft_W), CharacterDetails.ScabbardLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardRight_X), CharacterDetails.ScabbardRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardRight_Y), CharacterDetails.ScabbardRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardRight_Z), CharacterDetails.ScabbardRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ScabbardRight_W), CharacterDetails.ScabbardRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Neck_X), CharacterDetails.Neck_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Neck_Y), CharacterDetails.Neck_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Neck_Z), CharacterDetails.Neck_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Neck_W), CharacterDetails.Neck_W.GetBytes());
                        CharacterDetails.WriteBody = false;
                    }
                    if (CharacterDetails.WriteLeftArm == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleLeft_X), CharacterDetails.ClavicleLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleLeft_Y), CharacterDetails.ClavicleLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleLeft_Z), CharacterDetails.ClavicleLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleLeft_W), CharacterDetails.ClavicleLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmLeft_X), CharacterDetails.ArmLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmLeft_Y), CharacterDetails.ArmLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmLeft_Z), CharacterDetails.ArmLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmLeft_W), CharacterDetails.ArmLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronLeft_X), CharacterDetails.PauldronLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronLeft_Y), CharacterDetails.PauldronLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronLeft_Z), CharacterDetails.PauldronLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronLeft_W), CharacterDetails.PauldronLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmLeft_X), CharacterDetails.ForearmLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmLeft_Y), CharacterDetails.ForearmLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmLeft_Z), CharacterDetails.ForearmLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmLeft_W), CharacterDetails.ForearmLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderLeft_X), CharacterDetails.ShoulderLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderLeft_Y), CharacterDetails.ShoulderLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderLeft_Z), CharacterDetails.ShoulderLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderLeft_W), CharacterDetails.ShoulderLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldLeft_X), CharacterDetails.ShieldLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldLeft_Y), CharacterDetails.ShieldLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldLeft_Z), CharacterDetails.ShieldLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldLeft_W), CharacterDetails.ShieldLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowLeft_X), CharacterDetails.ElbowLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowLeft_Y), CharacterDetails.ElbowLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowLeft_Z), CharacterDetails.ElbowLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowLeft_W), CharacterDetails.ElbowLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterLeft_X), CharacterDetails.CouterLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterLeft_Y), CharacterDetails.CouterLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterLeft_Z), CharacterDetails.CouterLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterLeft_W), CharacterDetails.CouterLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristLeft_X), CharacterDetails.WristLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristLeft_Y), CharacterDetails.WristLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristLeft_Z), CharacterDetails.WristLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristLeft_W), CharacterDetails.WristLeft_W.GetBytes());
                        CharacterDetails.WriteLeftArm = false;
                    }
                    if (CharacterDetails.WriteRightArm == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleRight_X), CharacterDetails.ClavicleRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleRight_Y), CharacterDetails.ClavicleRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleRight_Z), CharacterDetails.ClavicleRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClavicleRight_W), CharacterDetails.ClavicleRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmRight_X), CharacterDetails.ArmRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmRight_Y), CharacterDetails.ArmRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmRight_Z), CharacterDetails.ArmRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ArmRight_W), CharacterDetails.ArmRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronRight_X), CharacterDetails.PauldronRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronRight_Y), CharacterDetails.PauldronRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronRight_Z), CharacterDetails.PauldronRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PauldronRight_W), CharacterDetails.PauldronRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmRight_X), CharacterDetails.ForearmRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmRight_Y), CharacterDetails.ForearmRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmRight_Z), CharacterDetails.ForearmRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ForearmRight_W), CharacterDetails.ForearmRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderRight_X), CharacterDetails.ShoulderRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderRight_Y), CharacterDetails.ShoulderRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderRight_Z), CharacterDetails.ShoulderRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShoulderRight_W), CharacterDetails.ShoulderRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldRight_X), CharacterDetails.ShieldRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldRight_Y), CharacterDetails.ShieldRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldRight_Z), CharacterDetails.ShieldRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ShieldRight_W), CharacterDetails.ShieldRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowRight_X), CharacterDetails.ElbowRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowRight_Y), CharacterDetails.ElbowRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowRight_Z), CharacterDetails.ElbowRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ElbowRight_W), CharacterDetails.ElbowRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterRight_X), CharacterDetails.CouterRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterRight_Y), CharacterDetails.CouterRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterRight_Z), CharacterDetails.CouterRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CouterRight_W), CharacterDetails.CouterRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristRight_X), CharacterDetails.WristRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristRight_Y), CharacterDetails.WristRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristRight_Z), CharacterDetails.WristRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WristRight_W), CharacterDetails.WristRight_W.GetBytes());
                        CharacterDetails.WriteRightArm = false;
                    }
                    if (CharacterDetails.WriteClothes == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackALeft_X), CharacterDetails.ClothBackALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackALeft_Y), CharacterDetails.ClothBackALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackALeft_Z), CharacterDetails.ClothBackALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackALeft_W), CharacterDetails.ClothBackALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackARight_X), CharacterDetails.ClothBackARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackARight_Y), CharacterDetails.ClothBackARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackARight_Z), CharacterDetails.ClothBackARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackARight_W), CharacterDetails.ClothBackARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontALeft_X), CharacterDetails.ClothFrontALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontALeft_Y), CharacterDetails.ClothFrontALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontALeft_Z), CharacterDetails.ClothFrontALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontALeft_W), CharacterDetails.ClothFrontALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontARight_X), CharacterDetails.ClothFrontARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontARight_Y), CharacterDetails.ClothFrontARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontARight_Z), CharacterDetails.ClothFrontARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontARight_W), CharacterDetails.ClothFrontARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideALeft_X), CharacterDetails.ClothSideALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideALeft_Y), CharacterDetails.ClothSideALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideALeft_Z), CharacterDetails.ClothSideALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideALeft_W), CharacterDetails.ClothSideALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideARight_X), CharacterDetails.ClothSideARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideARight_Y), CharacterDetails.ClothSideARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideARight_Z), CharacterDetails.ClothSideARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideARight_W), CharacterDetails.ClothSideARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBLeft_X), CharacterDetails.ClothBackBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBLeft_Y), CharacterDetails.ClothBackBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBLeft_Z), CharacterDetails.ClothBackBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBLeft_W), CharacterDetails.ClothBackBLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBRight_X), CharacterDetails.ClothBackBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBRight_Y), CharacterDetails.ClothBackBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBRight_Z), CharacterDetails.ClothBackBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackBRight_W), CharacterDetails.ClothBackBRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBLeft_X), CharacterDetails.ClothFrontBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBLeft_Y), CharacterDetails.ClothFrontBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBLeft_Z), CharacterDetails.ClothFrontBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBLeft_W), CharacterDetails.ClothFrontBLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBRight_X), CharacterDetails.ClothFrontBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBRight_Y), CharacterDetails.ClothFrontBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBRight_Z), CharacterDetails.ClothFrontBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontBRight_W), CharacterDetails.ClothFrontBRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBLeft_X), CharacterDetails.ClothSideBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBLeft_Y), CharacterDetails.ClothSideBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBLeft_Z), CharacterDetails.ClothSideBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBLeft_W), CharacterDetails.ClothSideBLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBRight_X), CharacterDetails.ClothSideBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBRight_Y), CharacterDetails.ClothSideBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBRight_Z), CharacterDetails.ClothSideBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideBRight_W), CharacterDetails.ClothSideBRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCLeft_X), CharacterDetails.ClothBackCLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCLeft_Y), CharacterDetails.ClothBackCLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCLeft_Z), CharacterDetails.ClothBackCLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCLeft_W), CharacterDetails.ClothBackCLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCRight_X), CharacterDetails.ClothBackCRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCRight_Y), CharacterDetails.ClothBackCRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCRight_Z), CharacterDetails.ClothBackCRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothBackCRight_W), CharacterDetails.ClothBackCRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCLeft_X), CharacterDetails.ClothFrontCLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCLeft_Y), CharacterDetails.ClothFrontCLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCLeft_Z), CharacterDetails.ClothFrontCLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCLeft_W), CharacterDetails.ClothFrontCLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCRight_X), CharacterDetails.ClothFrontCRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCRight_Y), CharacterDetails.ClothFrontCRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCRight_Z), CharacterDetails.ClothFrontCRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothFrontCRight_W), CharacterDetails.ClothFrontCRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCLeft_X), CharacterDetails.ClothSideCLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCLeft_Y), CharacterDetails.ClothSideCLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCLeft_Z), CharacterDetails.ClothSideCLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCLeft_W), CharacterDetails.ClothSideCLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCRight_X), CharacterDetails.ClothSideCRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCRight_Y), CharacterDetails.ClothSideCRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCRight_Z), CharacterDetails.ClothSideCRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ClothSideCRight_W), CharacterDetails.ClothSideCRight_W.GetBytes());
                        CharacterDetails.WriteClothes = false;
                    }
                    if (CharacterDetails.WriteWeapons == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponLeft_X), CharacterDetails.WeaponLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponLeft_Y), CharacterDetails.WeaponLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponLeft_Z), CharacterDetails.WeaponLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponLeft_W), CharacterDetails.WeaponLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponRight_X), CharacterDetails.WeaponRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponRight_Y), CharacterDetails.WeaponRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponRight_Z), CharacterDetails.WeaponRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.WeaponRight_W), CharacterDetails.WeaponRight_W.GetBytes());
                        CharacterDetails.WriteWeapons = false;
                    }
                    if (CharacterDetails.WriteLeftHand == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandLeft_X), CharacterDetails.HandLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandLeft_Y), CharacterDetails.HandLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandLeft_Z), CharacterDetails.HandLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandLeft_W), CharacterDetails.HandLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexALeft_X), CharacterDetails.IndexALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexALeft_Y), CharacterDetails.IndexALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexALeft_Z), CharacterDetails.IndexALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexALeft_W), CharacterDetails.IndexALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyALeft_X), CharacterDetails.PinkyALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyALeft_Y), CharacterDetails.PinkyALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyALeft_Z), CharacterDetails.PinkyALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyALeft_W), CharacterDetails.PinkyALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingALeft_X), CharacterDetails.RingALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingALeft_Y), CharacterDetails.RingALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingALeft_Z), CharacterDetails.RingALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingALeft_W), CharacterDetails.RingALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleALeft_X), CharacterDetails.MiddleALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleALeft_Y), CharacterDetails.MiddleALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleALeft_Z), CharacterDetails.MiddleALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleALeft_W), CharacterDetails.MiddleALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbALeft_X), CharacterDetails.ThumbALeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbALeft_Y), CharacterDetails.ThumbALeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbALeft_Z), CharacterDetails.ThumbALeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbALeft_W), CharacterDetails.ThumbALeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBLeft_X), CharacterDetails.IndexBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBLeft_Y), CharacterDetails.IndexBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBLeft_Z), CharacterDetails.IndexBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBLeft_W), CharacterDetails.IndexBLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBLeft_X), CharacterDetails.PinkyBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBLeft_Y), CharacterDetails.PinkyBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBLeft_Z), CharacterDetails.PinkyBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBLeft_W), CharacterDetails.PinkyBLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBLeft_X), CharacterDetails.RingBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBLeft_Y), CharacterDetails.RingBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBLeft_Z), CharacterDetails.RingBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBLeft_W), CharacterDetails.RingBLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBLeft_X), CharacterDetails.MiddleBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBLeft_Y), CharacterDetails.MiddleBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBLeft_Z), CharacterDetails.MiddleBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBLeft_W), CharacterDetails.MiddleBLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBLeft_X), CharacterDetails.ThumbBLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBLeft_Y), CharacterDetails.ThumbBLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBLeft_Z), CharacterDetails.ThumbBLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBLeft_W), CharacterDetails.ThumbBLeft_W.GetBytes());
                        CharacterDetails.WriteLeftHand = false;
                    }
                    if (CharacterDetails.WriteRightHand == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandRight_X), CharacterDetails.HandRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandRight_Y), CharacterDetails.HandRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandRight_Z), CharacterDetails.HandRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HandRight_W), CharacterDetails.HandRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexARight_X), CharacterDetails.IndexARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexARight_Y), CharacterDetails.IndexARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexARight_Z), CharacterDetails.IndexARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexARight_W), CharacterDetails.IndexARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyARight_X), CharacterDetails.PinkyARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyARight_Y), CharacterDetails.PinkyARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyARight_Z), CharacterDetails.PinkyARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyARight_W), CharacterDetails.PinkyARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingARight_X), CharacterDetails.RingARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingARight_Y), CharacterDetails.RingARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingARight_Z), CharacterDetails.RingARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingARight_W), CharacterDetails.RingARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleARight_X), CharacterDetails.MiddleARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleARight_Y), CharacterDetails.MiddleARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleARight_Z), CharacterDetails.MiddleARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleARight_W), CharacterDetails.MiddleARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbARight_X), CharacterDetails.ThumbARight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbARight_Y), CharacterDetails.ThumbARight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbARight_Z), CharacterDetails.ThumbARight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbARight_W), CharacterDetails.ThumbARight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBRight_X), CharacterDetails.IndexBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBRight_Y), CharacterDetails.IndexBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBRight_Z), CharacterDetails.IndexBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.IndexBRight_W), CharacterDetails.IndexBRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBRight_X), CharacterDetails.PinkyBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBRight_Y), CharacterDetails.PinkyBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBRight_Z), CharacterDetails.PinkyBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PinkyBRight_W), CharacterDetails.PinkyBRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBRight_X), CharacterDetails.RingBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBRight_Y), CharacterDetails.RingBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBRight_Z), CharacterDetails.RingBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.RingBRight_W), CharacterDetails.RingBRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBRight_X), CharacterDetails.MiddleBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBRight_Y), CharacterDetails.MiddleBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBRight_Z), CharacterDetails.MiddleBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.MiddleBRight_W), CharacterDetails.MiddleBRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBRight_X), CharacterDetails.ThumbBRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBRight_Y), CharacterDetails.ThumbBRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBRight_Z), CharacterDetails.ThumbBRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ThumbBRight_W), CharacterDetails.ThumbBRight_W.GetBytes());
                        CharacterDetails.WriteRightHand = false;
                    }
                    if (CharacterDetails.WriteWaist == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Waist_X), CharacterDetails.Waist_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Waist_Y), CharacterDetails.Waist_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Waist_Z), CharacterDetails.Waist_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.Waist_W), CharacterDetails.Waist_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterLeft_X), CharacterDetails.HolsterLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterLeft_Y), CharacterDetails.HolsterLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterLeft_Z), CharacterDetails.HolsterLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterLeft_W), CharacterDetails.HolsterLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterRight_X), CharacterDetails.HolsterRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterRight_Y), CharacterDetails.HolsterRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterRight_Z), CharacterDetails.HolsterRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.HolsterRight_W), CharacterDetails.HolsterRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheLeft_X), CharacterDetails.SheatheLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheLeft_Y), CharacterDetails.SheatheLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheLeft_Z), CharacterDetails.SheatheLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheLeft_W), CharacterDetails.SheatheLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheRight_X), CharacterDetails.SheatheRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheRight_Y), CharacterDetails.SheatheRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheRight_Z), CharacterDetails.SheatheRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.SheatheRight_W), CharacterDetails.SheatheRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailA_X), CharacterDetails.TailA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailA_Y), CharacterDetails.TailA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailA_Z), CharacterDetails.TailA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailA_W), CharacterDetails.TailA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailB_X), CharacterDetails.TailB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailB_Y), CharacterDetails.TailB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailB_Z), CharacterDetails.TailB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailB_W), CharacterDetails.TailB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailC_X), CharacterDetails.TailC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailC_Y), CharacterDetails.TailC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailC_Z), CharacterDetails.TailC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailC_W), CharacterDetails.TailC_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailD_X), CharacterDetails.TailD_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailD_Y), CharacterDetails.TailD_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailD_Z), CharacterDetails.TailD_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailD_W), CharacterDetails.TailD_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailE_X), CharacterDetails.TailE_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailE_Y), CharacterDetails.TailE_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailE_Z), CharacterDetails.TailE_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.TailE_W), CharacterDetails.TailE_W.GetBytes());
                        CharacterDetails.WriteWaist = false;
                    }
                    if (CharacterDetails.WriteLeftLeg == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegLeft_X), CharacterDetails.LegLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegLeft_Y), CharacterDetails.LegLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegLeft_Z), CharacterDetails.LegLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegLeft_W), CharacterDetails.LegLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeLeft_X), CharacterDetails.KneeLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeLeft_Y), CharacterDetails.KneeLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeLeft_Z), CharacterDetails.KneeLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeLeft_W), CharacterDetails.KneeLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfLeft_X), CharacterDetails.CalfLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfLeft_Y), CharacterDetails.CalfLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfLeft_Z), CharacterDetails.CalfLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfLeft_W), CharacterDetails.CalfLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynLeft_X), CharacterDetails.PoleynLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynLeft_Y), CharacterDetails.PoleynLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynLeft_Z), CharacterDetails.PoleynLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynLeft_W), CharacterDetails.PoleynLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootLeft_X), CharacterDetails.FootLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootLeft_Y), CharacterDetails.FootLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootLeft_Z), CharacterDetails.FootLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootLeft_W), CharacterDetails.FootLeft_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesLeft_X), CharacterDetails.ToesLeft_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesLeft_Y), CharacterDetails.ToesLeft_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesLeft_Z), CharacterDetails.ToesLeft_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesLeft_W), CharacterDetails.ToesLeft_W.GetBytes());
                        CharacterDetails.WriteLeftLeg = false;
                    }
                    if (CharacterDetails.WriteRightLeg == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegRight_X), CharacterDetails.LegRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegRight_Y), CharacterDetails.LegRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegRight_Z), CharacterDetails.LegRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.LegRight_W), CharacterDetails.LegRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeRight_X), CharacterDetails.KneeRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeRight_Y), CharacterDetails.KneeRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeRight_Z), CharacterDetails.KneeRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.KneeRight_W), CharacterDetails.KneeRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfRight_X), CharacterDetails.CalfRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfRight_Y), CharacterDetails.CalfRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfRight_Z), CharacterDetails.CalfRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.CalfRight_W), CharacterDetails.CalfRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynRight_X), CharacterDetails.PoleynRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynRight_Y), CharacterDetails.PoleynRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynRight_Z), CharacterDetails.PoleynRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.PoleynRight_W), CharacterDetails.PoleynRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootRight_X), CharacterDetails.FootRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootRight_Y), CharacterDetails.FootRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootRight_Z), CharacterDetails.FootRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.FootRight_W), CharacterDetails.FootRight_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesRight_X), CharacterDetails.ToesRight_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesRight_Y), CharacterDetails.ToesRight_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesRight_Z), CharacterDetails.ToesRight_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ToesRight_W), CharacterDetails.ToesRight_W.GetBytes());
                        CharacterDetails.WriteRightLeg = false;
                    }
                    if (CharacterDetails.WriteHelm == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetA_X), CharacterDetails.ExMetA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetA_Y), CharacterDetails.ExMetA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetA_Z), CharacterDetails.ExMetA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetA_W), CharacterDetails.ExMetA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetB_X), CharacterDetails.ExMetB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetB_Y), CharacterDetails.ExMetB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetB_Z), CharacterDetails.ExMetB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetB_W), CharacterDetails.ExMetB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetC_X), CharacterDetails.ExMetC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetC_Y), CharacterDetails.ExMetC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetC_Z), CharacterDetails.ExMetC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetC_W), CharacterDetails.ExMetC_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetD_X), CharacterDetails.ExMetD_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetD_Y), CharacterDetails.ExMetD_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetD_Z), CharacterDetails.ExMetD_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetD_W), CharacterDetails.ExMetD_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetE_X), CharacterDetails.ExMetE_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetE_Y), CharacterDetails.ExMetE_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetE_Z), CharacterDetails.ExMetE_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetE_W), CharacterDetails.ExMetE_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetF_X), CharacterDetails.ExMetF_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetF_Y), CharacterDetails.ExMetF_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetF_Z), CharacterDetails.ExMetF_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetF_W), CharacterDetails.ExMetF_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetG_X), CharacterDetails.ExMetG_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetG_Y), CharacterDetails.ExMetG_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetG_Z), CharacterDetails.ExMetG_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetG_W), CharacterDetails.ExMetG_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetH_X), CharacterDetails.ExMetH_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetH_Y), CharacterDetails.ExMetH_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetH_Z), CharacterDetails.ExMetH_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetH_W), CharacterDetails.ExMetH_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetI_X), CharacterDetails.ExMetI_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetI_Y), CharacterDetails.ExMetI_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetI_Z), CharacterDetails.ExMetI_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetI_W), CharacterDetails.ExMetI_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetJ_X), CharacterDetails.ExMetJ_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetJ_Y), CharacterDetails.ExMetJ_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetJ_Z), CharacterDetails.ExMetJ_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetJ_W), CharacterDetails.ExMetJ_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetK_X), CharacterDetails.ExMetK_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetK_Y), CharacterDetails.ExMetK_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetK_Z), CharacterDetails.ExMetK_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetK_W), CharacterDetails.ExMetK_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetL_X), CharacterDetails.ExMetL_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetL_Y), CharacterDetails.ExMetL_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetL_Z), CharacterDetails.ExMetL_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetL_W), CharacterDetails.ExMetL_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetM_X), CharacterDetails.ExMetM_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetM_Y), CharacterDetails.ExMetM_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetM_Z), CharacterDetails.ExMetM_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetM_W), CharacterDetails.ExMetM_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetN_X), CharacterDetails.ExMetN_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetN_Y), CharacterDetails.ExMetN_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetN_Z), CharacterDetails.ExMetN_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetN_W), CharacterDetails.ExMetN_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetO_X), CharacterDetails.ExMetO_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetO_Y), CharacterDetails.ExMetO_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetO_Z), CharacterDetails.ExMetO_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetO_W), CharacterDetails.ExMetO_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetP_X), CharacterDetails.ExMetP_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetP_Y), CharacterDetails.ExMetP_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetP_Z), CharacterDetails.ExMetP_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetP_W), CharacterDetails.ExMetP_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetQ_X), CharacterDetails.ExMetQ_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetQ_Y), CharacterDetails.ExMetQ_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetQ_Z), CharacterDetails.ExMetQ_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetQ_W), CharacterDetails.ExMetQ_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetR_X), CharacterDetails.ExMetR_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetR_Y), CharacterDetails.ExMetR_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetR_Z), CharacterDetails.ExMetR_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExMetR_W), CharacterDetails.ExMetR_W.GetBytes());
                        CharacterDetails.WriteHelm = false;
                    }
                    if (CharacterDetails.WriteTop == true)
                    {
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopA_X), CharacterDetails.ExTopA_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopA_Y), CharacterDetails.ExTopA_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopA_Z), CharacterDetails.ExTopA_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopA_W), CharacterDetails.ExTopA_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopB_X), CharacterDetails.ExTopB_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopB_Y), CharacterDetails.ExTopB_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopB_Z), CharacterDetails.ExTopB_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopB_W), CharacterDetails.ExTopB_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopC_X), CharacterDetails.ExTopC_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopC_Y), CharacterDetails.ExTopC_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopC_Z), CharacterDetails.ExTopC_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopC_W), CharacterDetails.ExTopC_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopD_X), CharacterDetails.ExTopD_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopD_Y), CharacterDetails.ExTopD_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopD_Z), CharacterDetails.ExTopD_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopD_W), CharacterDetails.ExTopD_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopE_X), CharacterDetails.ExTopE_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopE_Y), CharacterDetails.ExTopE_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopE_Z), CharacterDetails.ExTopE_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopE_W), CharacterDetails.ExTopE_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopF_X), CharacterDetails.ExTopF_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopF_Y), CharacterDetails.ExTopF_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopF_Z), CharacterDetails.ExTopF_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopF_W), CharacterDetails.ExTopF_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopG_X), CharacterDetails.ExTopG_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopG_Y), CharacterDetails.ExTopG_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopG_Z), CharacterDetails.ExTopG_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopG_W), CharacterDetails.ExTopG_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopH_X), CharacterDetails.ExTopH_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopH_Y), CharacterDetails.ExTopH_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopH_Z), CharacterDetails.ExTopH_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopH_W), CharacterDetails.ExTopH_W.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopI_X), CharacterDetails.ExTopI_X.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopI_Y), CharacterDetails.ExTopI_Y.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopI_Z), CharacterDetails.ExTopI_Z.GetBytes());
                        m.writeBytes(GAS(c.Body.Base, c.Body.Bones.ExTopI_W), CharacterDetails.ExTopI_W.GetBytes());
                        CharacterDetails.WriteTop = false;
                    }
                    #endregion

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

                    if (CharacterDetails.FaceCamX.freeze) m.writeBytes(GASG(MemoryManager.Instance.GposeAddress, c.FaceCamX), CharacterDetails.FaceCamX.GetBytes());
                    if (CharacterDetails.FaceCamY.freeze) m.writeBytes(GASG(MemoryManager.Instance.GposeAddress, c.FaceCamY), CharacterDetails.FaceCamY.GetBytes());
                    if (CharacterDetails.FaceCamZ.freeze) m.writeBytes(GASG(MemoryManager.Instance.GposeAddress, c.FaceCamZ), CharacterDetails.FaceCamZ.GetBytes());

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
                        if (CharacterDetails.Emote.value > 7756) CharacterDetails.Emote.value = 7756;
                        m.writeBytes(GAS(c.Emote), CharacterDetails.Emote.GetBytes());
                    }
                    if (CharacterDetails.EmoteOld.freeze)
                    {
                        if (CharacterDetails.EmoteOld.value > 7756) CharacterDetails.EmoteOld.value = 7756;
                        m.writeBytes(GAS(c.EmoteOld), CharacterDetails.EmoteOld.GetBytes());
                    }
                    Thread.Sleep(9);
                }
            }
            catch (Exception)
            {
				//System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace, App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
				worker.CancelAsync();
            }
        }
    }
}
