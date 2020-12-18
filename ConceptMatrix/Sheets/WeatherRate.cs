using Lumina.Data;
using Lumina.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Sheets
{
    [Sheet("WeatherRate", columnHash: 0x474abce2)]
    public class WeatherRate : IExcelRow
    {
        public struct UnkStruct0Struct
        {
            public int Weather;
            public byte Rate;
        }

        public UnkStruct0Struct[] UnkStruct0;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            UnkStruct0 = new UnkStruct0Struct[8];
            for (var i = 0; i < 8; i++)
            {
                UnkStruct0[i] = new UnkStruct0Struct();
                UnkStruct0[i].Weather = parser.ReadColumn<int>(0 + (i * 2 + 0));
                UnkStruct0[i].Rate = parser.ReadColumn<byte>(0 + (i * 2 + 1));
            }
        }
    }
}
