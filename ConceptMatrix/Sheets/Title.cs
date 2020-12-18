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
    [Sheet("Title", columnHash: 0x83e3f9ba)]
    public class Title : IExcelRow
    {

        public SeString Masculine;
        public SeString Feminine;
        public bool IsPrefix;
        public ushort Order;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Masculine = parser.ReadColumn<SeString>(0);
            Feminine = parser.ReadColumn<SeString>(1);
            IsPrefix = parser.ReadColumn<bool>(2);
            Order = parser.ReadColumn<ushort>(3);
        }
    }
}
