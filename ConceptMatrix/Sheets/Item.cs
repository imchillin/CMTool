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
    [Sheet("Item")]
    public class Item : ExcelRow
    {
        public string Name;
        public ushort Icon;
        public byte ItemUICategory;
        public byte EquipSlotCategory;
        public LazyRow<ClassJobCategory> ClassJobCategory;
        public ulong ModelMain;
        public ulong ModelSub;

        public override void PopulateData(RowParser parser, GameData gameData, Language language)
        {
            base.PopulateData(parser, gameData, language);

            Name = parser.ReadColumn<string>(9);
            Icon = parser.ReadColumn<ushort>(10);
            ItemUICategory = parser.ReadColumn<byte>(15);
            EquipSlotCategory = parser.ReadColumn<byte>(17);

            // Column shifted at 40, reverted in 5.5 for International client, Korean client hasn't changed.
            if (language == Language.ChineseSimplified || language == Language.Korean)
            {
                ClassJobCategory = new LazyRow<ClassJobCategory>(gameData, parser.ReadColumn<byte>(44), language);
                ModelMain = parser.ReadColumn<ulong>(48);
                ModelSub = parser.ReadColumn<ulong>(49);
            }
            else
            {
                ClassJobCategory = new LazyRow<ClassJobCategory>(gameData, parser.ReadColumn<byte>(43), language);
                ModelMain = parser.ReadColumn<ulong>(47);
                ModelSub = parser.ReadColumn<ulong>(48);
            }
        }
    }
}
