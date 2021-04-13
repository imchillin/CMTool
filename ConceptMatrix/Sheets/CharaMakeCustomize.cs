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
    [Sheet("CharaMakeCustomize")]
    public class CharaMakeCustomize : ExcelRow
    {
        public byte FeatureID;
        public uint Icon;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            FeatureID = parser.ReadColumn<byte>(0);
            Icon = parser.ReadColumn<uint>(1);
        }
    }
}
