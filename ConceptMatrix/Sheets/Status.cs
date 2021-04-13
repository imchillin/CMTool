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
    [Sheet("Status")]
    public class Status : ExcelRow
    {
        public SeString Name;
        public ushort Icon;
        public ushort VFX;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            Name = parser.ReadColumn<SeString>(0);
            Icon = parser.ReadColumn<ushort>(2);
            VFX = parser.ReadColumn<ushort>(7);
        }
    }
}
