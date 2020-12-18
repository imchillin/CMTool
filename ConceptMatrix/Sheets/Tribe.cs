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
    [Sheet("Tribe", columnHash: 0xe74759fb)]
    public class Tribe : IExcelRow
    {

        public SeString Masculine;
        public SeString Feminine;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Masculine = parser.ReadColumn<SeString>(0);
            Feminine = parser.ReadColumn<SeString>(1);
        }
    }
}
