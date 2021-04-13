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
    [Sheet("Race")]
    public class Race : ExcelRow
    {
        public SeString Masculine;
        public SeString Feminine;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            Masculine = parser.ReadColumn<SeString>(0);
            Feminine = parser.ReadColumn<SeString>(1);
        }
    }
}
