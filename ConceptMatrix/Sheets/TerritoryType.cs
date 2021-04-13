using Lumina;
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
    [Sheet("TerritoryType")]
    public class TerritoryType : ExcelRow
    {
        public SeString Name;
        public LazyRow<PlaceName> PlaceName;
        public byte WeatherRate;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            Name = parser.ReadColumn<SeString>(0);
            PlaceName = new LazyRow<PlaceName>(gameData, parser.ReadColumn<ushort>(5), language);
            WeatherRate = parser.ReadColumn<byte>(12);
        }
    }
}
