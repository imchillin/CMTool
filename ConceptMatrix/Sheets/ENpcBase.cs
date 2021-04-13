using Lumina;
using Lumina.Data;
using Lumina.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Sheets
{
    [Sheet("ENpcBase", columnHash: 0x927347d8)]
    public class ENpcBase : ExcelRow
    {
        public ushort ModelChara;
        public byte Race;
        public byte Gender;
        public byte BodyType;
        public byte Height;
        public byte Tribe;
        public byte Face;
        public byte HairStyle;
        public byte HairHighlight;
        public byte SkinColor;
        public byte EyeHeterochromia;
        public byte HairColor;
        public byte HairHighlightColor;
        public byte FacialFeature;
        public byte FacialFeatureColor;
        public byte Eyebrows;
        public byte EyeColor;
        public byte EyeShape;
        public byte Nose;
        public byte Jaw;
        public byte Mouth;
        public byte LipColor;
        public byte BustOrTone1;
        public byte ExtraFeature1;
        public byte ExtraFeature2OrBust;
        public byte FacePaint;
        public byte FacePaintColor;
        public LazyRow<NpcEquip> NpcEquip;
        public ulong ModelMainHand;
        public LazyRow<Stain> DyeMainHand;
        public ulong ModelOffHand;
        public LazyRow<Stain> DyeOffHand;
        public uint ModelHead;
        public LazyRow<Stain> DyeHead;
        public bool Visor;
        public uint ModelBody;
        public LazyRow<Stain> DyeBody;
        public uint ModelHands;
        public LazyRow<Stain> DyeHands;
        public uint ModelLegs;
        public LazyRow<Stain> DyeLegs;
        public uint ModelFeet;
        public LazyRow<Stain> DyeFeet;
        public uint ModelEars;
        public LazyRow<Stain> DyeEars;
        public uint ModelNeck;
        public LazyRow<Stain> DyeNeck;
        public uint ModelWrists;
        public LazyRow<Stain> DyeWrists;
        public uint ModelLeftRing;
        public LazyRow<Stain> DyeLeftRing;
        public uint ModelRightRing;
        public LazyRow<Stain> DyeRightRing;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            ModelChara = parser.ReadColumn<ushort>(35);
            Race = parser.ReadColumn<byte>(36);
            Gender = parser.ReadColumn<byte>(37);
            BodyType = parser.ReadColumn<byte>(38);
            Height = parser.ReadColumn<byte>(39);
            Tribe = parser.ReadColumn<byte>(40);
            Face = parser.ReadColumn<byte>(41);
            HairStyle = parser.ReadColumn<byte>(42);
            HairHighlight = parser.ReadColumn<byte>(43);
            SkinColor = parser.ReadColumn<byte>(44);
            EyeHeterochromia = parser.ReadColumn<byte>(45);
            HairColor = parser.ReadColumn<byte>(46);
            HairHighlightColor = parser.ReadColumn<byte>(47);
            FacialFeature = parser.ReadColumn<byte>(48);
            FacialFeatureColor = parser.ReadColumn<byte>(49);
            Eyebrows = parser.ReadColumn<byte>(50);
            EyeColor = parser.ReadColumn<byte>(51);
            EyeShape = parser.ReadColumn<byte>(52);
            Nose = parser.ReadColumn<byte>(53);
            Jaw = parser.ReadColumn<byte>(54);
            Mouth = parser.ReadColumn<byte>(55);
            LipColor = parser.ReadColumn<byte>(56);
            BustOrTone1 = parser.ReadColumn<byte>(57);
            ExtraFeature1 = parser.ReadColumn<byte>(58);
            ExtraFeature2OrBust = parser.ReadColumn<byte>(59);
            FacePaint = parser.ReadColumn<byte>(60);
            FacePaintColor = parser.ReadColumn<byte>(61);
            NpcEquip = new LazyRow<NpcEquip>(gameData, parser.ReadColumn<ushort>(63), language);
            ModelMainHand = parser.ReadColumn<ulong>(65);
            DyeMainHand = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(66), language);
            ModelOffHand = parser.ReadColumn<ulong>(67);
            DyeOffHand = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(68), language);
            ModelHead = parser.ReadColumn<uint>(69);
            DyeHead = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(70), language);
            Visor = parser.ReadColumn<bool>(71);
            ModelBody = parser.ReadColumn<uint>(72);
            DyeBody = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(73), language);
            ModelHands = parser.ReadColumn<uint>(74);
            DyeHands = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(75), language);
            ModelLegs = parser.ReadColumn<uint>(76);
            DyeLegs = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(77), language);
            ModelFeet = parser.ReadColumn<uint>(78);
            DyeFeet = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(79), language);
            ModelEars = parser.ReadColumn<uint>(80);
            DyeEars = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(81), language);
            ModelNeck = parser.ReadColumn<uint>(82);
            DyeNeck = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(83), language);
            ModelWrists = parser.ReadColumn<uint>(84);
            DyeWrists = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(85), language);
            ModelLeftRing = parser.ReadColumn<uint>(86);
            DyeLeftRing = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(87), language);
            ModelRightRing = parser.ReadColumn<uint>(88);
            DyeRightRing = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(89), language);
        }
    }
}
