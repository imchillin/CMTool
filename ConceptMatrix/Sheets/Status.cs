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
    [Sheet("Status", columnHash: 0xec4473bc)]
    public class Status : IExcelRow
    {

        public SeString Name;
        public ushort Icon;
        public ushort VFX;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Name = parser.ReadColumn<SeString>(0);
            Icon = parser.ReadColumn<ushort>(2);
            VFX = parser.ReadColumn<ushort>(7);
        }
    }
}
