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
    [Sheet("TerritoryType", columnHash: 0xb7598447)]
    public class TerritoryType : IExcelRow
    {

        public SeString Name;
        public LazyRow<PlaceName> PlaceName;
        public byte WeatherRate;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Name = parser.ReadColumn<SeString>(0);
            PlaceName = new LazyRow<PlaceName>(lumina, parser.ReadColumn<ushort>(5), language);
            WeatherRate = parser.ReadColumn<byte>(12);
        }
    }
}
