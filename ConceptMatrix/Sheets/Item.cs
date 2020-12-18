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
    public class Item : IExcelRow
    {
        public string Name;
        public ushort Icon;
        public byte ItemUICategory;
        public byte EquipSlotCategory;
        public LazyRow<ClassJobCategory> ClassJobCategory;
        public ulong ModelMain;
        public ulong ModelSub;

        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData(RowParser parser, Lumina.Lumina lumina, Language language)
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Name = parser.ReadColumn<string>(9);
            Icon = parser.ReadColumn<ushort>(10);
            ItemUICategory = parser.ReadColumn<byte>(15);
            EquipSlotCategory = parser.ReadColumn<byte>(17);

            // Shifted by one column in 5.4 for International client.
            if (language == Language.Korean || language == Language.ChineseSimplified || language == Language.ChineseTraditional)
            {
                ClassJobCategory = new LazyRow<ClassJobCategory>(lumina, parser.ReadColumn<byte>(43), language);
                ModelMain = parser.ReadColumn<ulong>(47);
                ModelSub = parser.ReadColumn<ulong>(48);
            }
            else
            {
                ClassJobCategory = new LazyRow<ClassJobCategory>(lumina, parser.ReadColumn<byte>(44), language);
                ModelMain = parser.ReadColumn<ulong>(48);
                ModelSub = parser.ReadColumn<ulong>(49);
            }
        }
    }
}
