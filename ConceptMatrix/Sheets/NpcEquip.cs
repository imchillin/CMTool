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
    [Sheet("NpcEquip", columnHash: 0xe91c87ba)]
    public class NpcEquip : ExcelRow
    {
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

            ModelMainHand = parser.ReadColumn<ulong>(0);
            DyeMainHand = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(1), language);
            ModelOffHand = parser.ReadColumn<ulong>(2);
            DyeOffHand = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(3), language);
            ModelHead = parser.ReadColumn<uint>(4);
            DyeHead = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(5), language);
            Visor = parser.ReadColumn<bool>(6);
            ModelBody = parser.ReadColumn<uint>(7);
            DyeBody = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(8), language);
            ModelHands = parser.ReadColumn<uint>(9);
            DyeHands = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(10), language);
            ModelLegs = parser.ReadColumn<uint>(11);
            DyeLegs = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(12), language);
            ModelFeet = parser.ReadColumn<uint>(13);
            DyeFeet = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(14), language);
            ModelEars = parser.ReadColumn<uint>(15);
            DyeEars = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(16), language);
            ModelNeck = parser.ReadColumn<uint>(17);
            DyeNeck = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(18), language);
            ModelWrists = parser.ReadColumn<uint>(19);
            DyeWrists = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(20), language);
            ModelLeftRing = parser.ReadColumn<uint>(21);
            DyeLeftRing = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(22), language);
            ModelRightRing = parser.ReadColumn<uint>(23);
            DyeRightRing = new LazyRow<Stain>(gameData, parser.ReadColumn<byte>(24), language);
        }
    }
}
