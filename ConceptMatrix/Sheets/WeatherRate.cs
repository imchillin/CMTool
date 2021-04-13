using Lumina;
using Lumina.Data;
using Lumina.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Sheets
{
    [Sheet("WeatherRate")]
    public class WeatherRate : ExcelRow
    {
        public struct UnkStruct0Struct
        {
            public int Weather;
            public byte Rate;
        }

        public UnkStruct0Struct[] UnkStruct0;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            UnkStruct0 = new UnkStruct0Struct[8];
            for (var i = 0; i < 8; i++)
            {
				UnkStruct0[i] = new UnkStruct0Struct
				{
					Weather = parser.ReadColumn<int>(i * 2 + 0),
					Rate = parser.ReadColumn<byte>(i * 2 + 1)
				};
			}
        }
    }
}
