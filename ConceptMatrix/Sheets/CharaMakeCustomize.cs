using Lumina.Data;
using Lumina.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Sheets
{
    [Sheet("CharaMakeCustomize", columnHash: 0x2ba6bf0f)]
    public class CharaMakeCustomize : IExcelRow
    {
        public byte FeatureID;
        public uint Icon;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            FeatureID = parser.ReadColumn<byte>(0);
            Icon = parser.ReadColumn<uint>(1);
        }
    }
}
