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
    [Sheet("CharaMakeType", columnHash: 0x80d7db6d)]
    public class CharaMakeType : ExcelRow
    {
        public int Race;
        public int Tribe;
        public sbyte Gender;
        public byte[] VoiceStruct;
        public int[] FacialFeatureOptions;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            Race = parser.ReadColumn<int>(0);
            Tribe = parser.ReadColumn<int>(1);
            Gender = parser.ReadColumn<sbyte>(2);
            VoiceStruct = new byte[12];
            for (var i = 0; i < 12; i++)
                VoiceStruct[i] = parser.ReadColumn<byte>(3279 + i);
            FacialFeatureOptions = new int[7 * 8];
            for (var i = 0; i < 7 * 8; i++)
                FacialFeatureOptions[i] = parser.ReadColumn<int>(3291 + i);
        }
    }
}

