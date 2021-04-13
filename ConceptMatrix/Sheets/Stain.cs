using Lumina;
using Lumina.Data;
using Lumina.Excel;
using Lumina.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Sheets
{
    [Sheet("Stain", columnHash: 0xa2420e68)]
    public class Stain : ExcelRow
    {
        public uint Color;
        public byte Shade;
        public SeString Name;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            Color = parser.ReadColumn<uint>(0);
            Shade = parser.ReadColumn<byte>(1);
            Name = parser.ReadColumn<SeString>(3);
        }
    }
}
