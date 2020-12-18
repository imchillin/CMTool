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
    [Sheet("Weather", columnHash: 0x02cf2541)]
    public class Weather : IExcelRow
    {

        public int Icon;
        public SeString Name;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Icon = parser.ReadColumn<int>(0);
            Name = parser.ReadColumn<SeString>(1);
        }
    }
}
