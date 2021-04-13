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
	[Sheet("ClassJobCategory")]
	public class ClassJobCategory : ExcelRow
	{
		public SeString Name;

		public override void PopulateData(RowParser parser, GameData gameData, Language language)
		{
			base.PopulateData(parser, gameData, language);

			Name = parser.ReadColumn<SeString>(0);
		}
	}
}
