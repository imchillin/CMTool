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
    public class Stain : IExcelRow
    {

        public uint Color;
        public byte Shade;
        public SeString Name;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Color = parser.ReadColumn<uint>(0);
            Shade = parser.ReadColumn<byte>(1);
            Name = parser.ReadColumn<SeString>(3);
        }
    }
}
