using Lumina.Data;
using Lumina.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Sheets
{
    [Sheet("CharaMakeType", columnHash: 0x80d7db6d)]
    public class CharaMakeType : IExcelRow
    {
        public int Race;
        public int Tribe;
        public sbyte Gender;
        public int[] FacialFeatureOptions;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Race = parser.ReadColumn<int>(0);
            Tribe = parser.ReadColumn<int>(1);
            Gender = parser.ReadColumn<sbyte>(2);
            FacialFeatureOptions = new int[7 * 8];
            for (var i = 0; i < 7 * 8; i++)
                FacialFeatureOptions[i] = parser.ReadColumn<int>(3291 + i);
        }
    }
}

