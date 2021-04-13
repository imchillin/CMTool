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
    [Sheet("ENpcResident", columnHash: 0xf74fa88c)]
    public class ENpcResident : ExcelRow
    {
        public SeString Singular;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            Singular = parser.ReadColumn<SeString>(0);
        }
    }
}
