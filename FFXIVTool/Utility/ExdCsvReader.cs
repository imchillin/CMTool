using FFXIVTool.Properties;
using FFXIVTool.Views;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using GearTuple = System.Tuple<int, int, int>;
using WepTuple = System.Tuple<int, int, int, int>;

namespace FFXIVTool.Utility
{
    public class GearSet
    {
        public GearTuple HeadGear { get; set; }
        public GearTuple BodyGear { get; set; }
        public GearTuple HandsGear { get; set; }
        public GearTuple LegsGear { get; set; }
        public GearTuple FeetGear { get; set; }
        public GearTuple EarGear { get; set; }
        public GearTuple NeckGear { get; set; }
        public GearTuple WristGear { get; set; }
        public GearTuple RRingGear { get; set; }
        public GearTuple LRingGear { get; set; }

        public WepTuple MainWep { get; set; }
        public WepTuple OffWep { get; set; }

        public byte[] Customize { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static GearSet FromJson(string json)
        {
            return JsonConvert.DeserializeObject<GearSet>(json);
        }
    }

    public class ExdCsvReader
    {
        public enum ItemType
        {
            Wep,
            Head,
            Body,
            Hands,
            Legs,
            Feet,
            Ears,
            Neck,
            Wrists,
            Ring,
            Trash,
        }
        public class Item
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string ModelMain { get; set; }
            public string ModelOff { get; set; }
            public int Gender { get; set; }
            public ItemType Type { get; set; }
            public SaintCoinach.Imaging.ImageFile Icon { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
        public class Resident
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public GearSet Gear { get; set; }

            public override string ToString()
            {
                return Name;
            }

            public bool IsGoodNpc()
            {
                if (Gear.Customize[0] != 0 && Name.Length != 0)
                    return true;

                return false;
            }

            public string MakeGearString()
            {
                return $"{EquipmentFlyOut.GearTupleToComma(Gear.HeadGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.BodyGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.HandsGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.LegsGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.FeetGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.EarGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.NeckGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.WristGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.LRingGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.RRingGear)}";
            }
        }
        public class Race
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class Tribe
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class CharaMakeCustomizeFeature
        {
            public int Index { get; set; }
            public int FeatureID { get; set; }
            public ImageSource Icon { get; set; }
        }
        public class Features
        {
            public int FeatureID { get; set; }
            public ImageSource Icon { get; set; }
        }
        public class CharaMakeCustomizeFeature2
        {
            public int Index { get; set; }
            public int Race { get; set; }
            public int Gender { get; set; }
            public int Tribe { get; set; }
            public List <Features> Features { get; set; }
        }
        public class Dye
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }

        public class Emote
        {
            public int Index { get; set; }
            public bool Realist { get; set; }
            public bool SpeacialReal { get; set; }
            public bool BattleReal { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        public class Weather
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class TerritoryType
        {
            public int Index { get; set; }
            public WeatherRate WeatherRate { get; set; }
        }
        public class WeatherRate
        {
            public int Index { get; set; }
            public List<Weather> AllowedWeathers { get; set; }
        }
        public class Monster
        {
            public int Index { get; set; }
            public bool Real { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        public class BGM
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public string Note { get; set; }
        }

        public static Emote[] Emotesx;
        public static BGM[] BGMX;
        public static Monster[] MonsterX;
        public static Dye[] DyesX;
        public Dictionary<int, Item> Items = null;
        public Dictionary<int, Item> ItemsProps = null;
        public Dictionary<int, Weather> Weathers = null;
        public Dictionary<int, WeatherRate> WeatherRates = null;
        public Dictionary<int, TerritoryType> TerritoryTypes = null;
        public Dictionary<int, Dye> Dyes = null;
        public Dictionary<int, Emote> Emotes = null;
        public Dictionary<int, Resident> Residents = null;
        public Dictionary<int, CharaMakeCustomizeFeature> CharaMakeFeatures = null;
        public Dictionary<int, CharaMakeCustomizeFeature2> CharaMakeFeatures2 = null;
        public Dictionary<int, Race> Races = null;
        public Dictionary<int, Tribe> Tribes = null;
        public Dictionary<int, Monster> Monsters = null;
        public Dictionary<int, BGM> BGMs = null;
        private static ImageSource CreateSource(SaintCoinach.Imaging.ImageFile file)
        {
            var argb = SaintCoinach.Imaging.ImageConverter.GetA8R8G8B8(file);
            return System.Windows.Media.Imaging.BitmapSource.Create(
                                       file.Width, file.Height,
                96, 96,
                PixelFormats.Bgra32, null,
                argb, file.Width * 4);
        }
       private List<Features> FeatureD(IEnumerable<SaintCoinach.Xiv.CharaMakeType.CharaMakeFeatureIcon> parse)
        {
            List<Features> NewList = new List<Features>();
           foreach(var Parse in parse)
            {
                try
                {
                    var testw = Parse.FacialFeatureIcon.CommonHeader;
                    NewList.Add(new Features { FeatureID = Parse.Count, Icon = CreateSource(Parse.FacialFeatureIcon) });
                }
                catch
                {
                    NewList.Add(new Features { FeatureID = Parse.Count, Icon = SpecialControl.GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Corrupted")) });
                }
            }
            return NewList;
        }
        public void MakeCharaMakeFeatureFacialList()
        {
            CharaMakeFeatures2 = new Dictionary<int, CharaMakeCustomizeFeature2>();
            try
            {
                var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.CharaMakeType>();
                foreach (var test in sheet)
                {
                 //   rowCount++;
                    CharaMakeCustomizeFeature2 feature = new CharaMakeCustomizeFeature2();;
                    feature.Index = test.Key;
                    feature.Gender = test.Gender;
                    feature.Race = test.Race.Key;
                    feature.Tribe = test.Tribe.Key;
                    //Console.WriteLine($"{testt.Key},{testt.FeatureID}");
                    feature.Features=FeatureD(test.FacialFeatureIcon);
                    CharaMakeFeatures2.Add(test.Key, feature);
                }
            }
            catch (Exception exc)
            {
                //CharaMakeFeatures2 = null;

                throw;

            }
        }
        public void MakeCharaMakeFeatureList()
        {
            CharaMakeFeatures = new Dictionary<int, CharaMakeCustomizeFeature>();
            try
            {
                var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.CharaMakeCustomize>();
                int rowCount = 0;
                foreach (var test in sheet)
                {
                    rowCount++;
                    CharaMakeCustomizeFeature feature = new CharaMakeCustomizeFeature();
                    //Console.WriteLine($"{testt.Key},{testt.FeatureID}");
                    feature.Index = test.Key;
                    feature.FeatureID = test.FeatureID;
                    try
                    {
                        feature.Icon = CreateSource(test.Icon);
                    }
                    catch
                    {
                        feature.Icon = SpecialControl.GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Corrupted"));
                    }
                    CharaMakeFeatures.Add(rowCount, feature);
                }
            }
            catch (Exception exc)
            {
               // CharaMakeFeatures = null;

                throw;

            }
        }
        public CharaMakeCustomizeFeature GetCharaMakeCustomizeFeature(int index, bool getBitMap)
        {
            try
            {
                var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.CharaMakeCustomize>();
                int rowCount = 0;
                foreach (var test in sheet)
                {
                    if (rowCount != index)
                    {
                        rowCount++;
                        continue;
                    }
                    rowCount++;
                    CharaMakeCustomizeFeature feature = new CharaMakeCustomizeFeature();
                    //           Console.WriteLine($"{testt.Key},{testt.FeatureID}");
                    feature.Index = test.Key;
                    feature.FeatureID = test.FeatureID;
                    if (getBitMap) { feature.Icon = CreateSource(test.Icon); }
                    return feature;
                }
            }
            catch (Exception exc)
            {

                throw;

            }

            return null;
        }
        public void TribeList()
        {
            Tribes = new Dictionary<int, Tribe>();
            try
            {
                var TribeSheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Tribe>();
                foreach (var Parse in TribeSheet)
                {
                    Tribe tribe = new Tribe();
                    tribe.Index = Parse.Key;
                    tribe.Name = Parse.Feminine;
                    if (Parse.Key == 0) { tribe.Name = "None"; }
                    Tribes.Add(Parse.Key, tribe);
                    //    Console.WriteLine($"{Parse.Key} {Parse.Feminine}");
                }
            }

            catch (Exception exc)
            {
                Tribes = null;

                throw;

            }
        }
        public void RaceList()
        {
            Races = new Dictionary<int, Race>();
            try
            {
                var RaceSheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Race>();
                foreach (var Parse in RaceSheet)
                {
                    Race race = new Race();
                    race.Index = Parse.Key;
                    race.Name = Parse.Feminine;
                    if (Parse.Key == 0) { race.Name = "None"; }
                    Races.Add(Parse.Key, race);
                }
            }
            catch (Exception exc)
            {
                Races = null;

                throw;

            }
        }
        public void EmoteList()
        {
            Emotes = new Dictionary<int, Emote>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.actiontimeline)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Emote emote = new Emote();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            emote.Index = int.Parse(fields[0]);
                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    emote.Name = field;
                                }
                            }
                            if (emote.Name.Contains("normal/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("mon_sp/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.SpeacialReal = true; }
                            if (emote.Name.Contains("battle/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.BattleReal = true; }
                            if (emote.Name.Contains("human_sp/")) { emote.Name = emote.Name.Remove(0, 9).ToString(); emote.SpeacialReal = true; }
                            //    Console.WriteLine($"{rowCount} - {emote.Name}");
                            Emotes.Add(emote.Index, emote);
                        }
                        //    Console.WriteLine($"{rowCount} Emotes read");
                    }
                }

                catch (Exception exc)
                {
                    Emotes = null;

                    throw;

                }
            }
        }
        public void MonsterList()
        {
            Monsters = new Dictionary<int, Monster>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.MonsterList)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Monster monster = new Monster();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            monster.Index = int.Parse(fields[0]);
                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    monster.Name = field;
                                }
                            }
                            if (monster.Name.Length >= 1) monster.Real = true;
                            // Console.WriteLine($"{rowCount} - {monster.Name}");
                            Monsters.Add(monster.Index, monster);
                        }
                        //Console.WriteLine($"{rowCount} Monsters read");
                    }
                }

                catch (Exception exc)
                {
                    Monsters = null;

                    throw;

                }
            }
        }
        public void DyeList()
        {
            Dyes = new Dictionary<int, Dye>();
            {
                try
                {
                    var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Stain>();
                    foreach (var Parse in sheet)
                    {
                        Dye dye = new Dye();
                        dye.Index = Parse.Key;
                        dye.Name = Parse.Name;
                        if (Parse.Key == 0) { dye.Name = "None"; }
                        Dyes.Add(Parse.Key, dye);
                        //     Console.WriteLine($"{Parse.Key} {Parse.Name}");
                    }
                }
                catch (Exception exc)
                {
                    Dyes = null;

                    throw;

                }
            }
        }
        ItemType Heh(int cat)
        {
            switch (cat)
            {
                case 34:
                    return ItemType.Head;
                case 35:
                    return ItemType.Body;
                case 37:
                    return ItemType.Hands;
                case 36:
                    return ItemType.Legs;
                case 38:
                    return ItemType.Feet;
                case 41:
                    return ItemType.Ears;
                case 40:
                    return ItemType.Neck;
                case 42:
                    return ItemType.Wrists;
                case 43:
                    return ItemType.Ring;
                case int n when (n >= 1 && n <= 32 || n == 84 || n >= 87 && n <= 89 || n >= 96 && n <= 99 || n == 105):
                    return ItemType.Wep;
                default:
                    return ItemType.Trash;
            }
        }
        public void MakeItemList()
        {
            Items = new Dictionary<int, Item>();
            {
                try
                {
                    var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Item>();
                    foreach (var Parse in sheet)
                    {
                        if (Parse.EquipSlotCategory.Key <= 0) continue;
                        var item = new Item();
                        item.Index = Parse.Key;
                        item.Name = Parse.Name;
                        item.Type = Heh(Parse.ItemUICategory.Key);
                        item.ModelMain = Parse.ModelMain.ToString();
                        item.ModelOff = Parse.ModelSub.ToString();
                        if (Parse.Description.ToString().Contains("♀")) item.Gender = 1;
                        else if (Parse.Description.ToString().Contains("♂")) item.Gender = 0;
                        else item.Gender = 2;
                        try
                        {
                            item.Icon = Parse.Icon;

                        }
                        catch
                        {
                            item.Icon = null;
                        }
                        Items.Add(Parse.Key, item);
                    }
                }
                catch (Exception exc)
                {
             //       Items = null;

                    throw;

                }
            }
        }
        public void MakeResidentList()
        {
            Residents = new Dictionary<int, Resident>();

            try
            {
                var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.ENpcResident>();
                foreach (var Parse in sheet)
                {
                    Residents.Add(Parse.Key, new Resident { Index = Parse.Key, Name = Parse.Singular });
                }
                var eNpcBases = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.ENpcBase>();

                foreach (var parse in eNpcBases)
                {
                    //  Console.WriteLine($"{parse.NpcEquip.ModelHead[0]+ parse.NpcEquip.ModelHead[1]* 256},{parse.NpcEquip.ModelHead[2]}");
                    //  Console.WriteLine(parse.NpcEquip.Key);
                    int id = parse.Key;
                    int modelid = parse.ModelID;
                    GearSet gear = new GearSet();
                    List<byte> customize = new List<byte>();
                    customize.AddRange(new List<byte>() { Convert.ToByte(parse.Race), Convert.ToByte(parse.Gender)
                       , Convert.ToByte(parse.BodyType), Convert.ToByte(parse.Height)
                   , Convert.ToByte(parse.Tribe), Convert.ToByte(parse.Face) , Convert.ToByte(parse.HairStyle), Convert.ToByte(parse.HairHighlight)
                   , Convert.ToByte(parse.SkinColor), Convert.ToByte(parse.EyeHeterochromia), Convert.ToByte(parse.HairColor), Convert.ToByte(parse.HairHighlightColor)
                   , Convert.ToByte(parse.FacialFeature), Convert.ToByte(parse.FacialFeatureColor), Convert.ToByte(parse.Eyebrows), Convert.ToByte(parse.EyeColor)
                   , Convert.ToByte(parse.EyeShape), Convert.ToByte(parse.Nose), Convert.ToByte(parse.Jaw), Convert.ToByte(parse.Mouth)
                   , Convert.ToByte(parse.LipColor), Convert.ToByte(parse.BustOrTone1), Convert.ToByte(parse.ExtraFeature1), Convert.ToByte(parse.ExtraFeature2OrBust)
                   , Convert.ToByte(parse.FacePaint), Convert.ToByte(parse.FacePaintColor) });
                    gear.Customize = customize.ToArray();
                    if (parse.NpcEquip.Key > 0)
                    {
                        gear.MainWep = new WepTuple(parse.NpcEquip.ModelMain.Value1, parse.NpcEquip.ModelMain.Value2, parse.NpcEquip.ModelMain.Value3, parse.NpcEquip.DyeMain);
                        gear.OffWep = new WepTuple(parse.NpcEquip.ModelSub.Value1, parse.NpcEquip.ModelSub.Value2, parse.NpcEquip.ModelSub.Value3, parse.NpcEquip.DyeOff);
                        gear.HeadGear = new GearTuple((parse.NpcEquip.ModelHead[0] + parse.NpcEquip.ModelHead[1] * 256), parse.NpcEquip.ModelHead[2], parse.NpcEquip.DyeHead);
                        gear.BodyGear = new GearTuple((parse.NpcEquip.ModelBody[0] + parse.NpcEquip.ModelBody[1] * 256), parse.NpcEquip.ModelBody[2], parse.NpcEquip.DyeBody);
                        gear.HandsGear = new GearTuple((parse.NpcEquip.ModelHands[0] + parse.NpcEquip.ModelHands[1] * 256), parse.NpcEquip.ModelHands[2], parse.NpcEquip.DyeHands);
                        gear.LegsGear = new GearTuple((parse.NpcEquip.ModelLegs[0] + parse.NpcEquip.ModelLegs[1] * 256), parse.NpcEquip.ModelLegs[2], parse.NpcEquip.DyeLegs);
                        gear.FeetGear = new GearTuple((parse.NpcEquip.ModelFeet[0] + parse.NpcEquip.ModelFeet[1] * 256), parse.NpcEquip.ModelFeet[2], parse.NpcEquip.DyeFeet);
                        gear.EarGear = new GearTuple((parse.NpcEquip.ModelEars[0] + parse.NpcEquip.ModelEars[1] * 256), parse.NpcEquip.ModelEars[2], 0);
                        gear.NeckGear = new GearTuple((parse.NpcEquip.ModelNeck[0] + parse.NpcEquip.ModelNeck[1] * 256), parse.NpcEquip.ModelNeck[2], 0);
                        gear.WristGear = new GearTuple((parse.NpcEquip.ModelWrists[0] + parse.NpcEquip.ModelWrists[1] * 256), parse.NpcEquip.ModelWrists[2], 0);
                        gear.RRingGear = new GearTuple((parse.NpcEquip.ModelRightRing[0] + parse.NpcEquip.ModelRightRing[1] * 256), parse.NpcEquip.ModelRightRing[2], 0);
                        gear.LRingGear = new GearTuple((parse.NpcEquip.ModelLeftRing[0] + parse.NpcEquip.ModelLeftRing[1] * 256), parse.NpcEquip.ModelLeftRing[2], 0);
                    }
                    else
                    {
                        gear.MainWep = new WepTuple(parse.ModelMain.Value1, parse.ModelMain.Value2, parse.ModelMain.Value3, parse.DyeMain);
                        gear.OffWep = new WepTuple(parse.ModelSub.Value1, parse.ModelSub.Value2, parse.ModelSub.Value3, parse.DyeOff);
                        gear.HeadGear = new GearTuple((parse.ModelHead[0] + parse.ModelHead[1] * 256), parse.ModelHead[2], parse.DyeHead);
                        gear.BodyGear = new GearTuple((parse.ModelBody[0] + parse.ModelBody[1] * 256), parse.ModelBody[2], parse.DyeBody);
                        gear.HandsGear = new GearTuple((parse.ModelHands[0] + parse.ModelHands[1] * 256), parse.ModelHands[2], parse.DyeHands);
                        gear.LegsGear = new GearTuple((parse.ModelLegs[0] + parse.ModelLegs[1] * 256), parse.ModelLegs[2], parse.DyeLegs);
                        gear.FeetGear = new GearTuple((parse.ModelFeet[0] + parse.ModelFeet[1] * 256), parse.ModelFeet[2], parse.DyeFeet);
                        gear.EarGear = new GearTuple((parse.ModelEars[0] + parse.ModelEars[1] * 256), parse.ModelEars[2], 0);
                        gear.NeckGear = new GearTuple((parse.ModelNeck[0] + parse.ModelNeck[1] * 256), parse.ModelNeck[2], 0);
                        gear.WristGear = new GearTuple((parse.ModelWrists[0] + parse.ModelWrists[1] * 256), parse.ModelWrists[2], 0);
                        gear.RRingGear = new GearTuple((parse.ModelRightRing[0] + parse.ModelRightRing[1] * 256), parse.ModelRightRing[2], 0);
                        gear.LRingGear = new GearTuple((parse.ModelLeftRing[0] + parse.ModelLeftRing[1] * 256), parse.ModelLeftRing[2], 0);
                    }
                    try
                    {
                        Residents[id].Gear = gear;
                    }
                    catch (KeyNotFoundException)
                    {
                        //Console.WriteLine("Did not find corresponding entry for: " + id);
                    }
                }
            }
            catch (Exception exc)
            {
                Residents = null;

                throw;

            }
        }
        public void MakeWeatherRateList()
        {
            if (Weathers == null)
                throw new Exception("Weathers has to be loaded for WeatherRates to be read");

            WeatherRates = new Dictionary<int, WeatherRate>();

            try
            {
                var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.WeatherRate>();
                foreach (var Parse in sheet)
                {
                    WeatherRate rate = new WeatherRate();
                    rate.Index = Parse.Key;
                    rate.AllowedWeathers = new List<Weather>();
                    foreach (var timetodothis in Parse.PossibleWeathers)
                    {

                        if (timetodothis.Key == 0)
                            break;
                        rate.AllowedWeathers.Add(Weathers[timetodothis.Key]);
                    }
                    WeatherRates.Add(Parse.Key, rate);
                }
            }
            catch (Exception exc)
            {
                WeatherRates = null;

                throw;

            }
        }

        public void MakeTerritoryTypeList()
        {
            if (WeatherRates == null)
                throw new Exception("WeatherRates has to be loaded for TerritoryTypes to be read");

            TerritoryTypes = new Dictionary<int, TerritoryType>();

            try
            {

                var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.TerritoryType>();
                foreach (var Parse in sheet)
                {
                    TerritoryType territory = new TerritoryType();
                    territory.Index = Parse.Key;
                    territory.WeatherRate = WeatherRates[Parse.WeatherRate.Key];
                    TerritoryTypes.Add(Parse.Key, territory);
                }
            }
            catch (Exception exc)
            {
                TerritoryTypes = null;

                throw;

            }
        }
        public void MakeWeatherList()
        {
            Weathers = new Dictionary<int, Weather>();
            {
                try
                {
                    var sheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Weather>();
                    foreach (var Parse in sheet)
                    {
                        Weather weather = new Weather();
                        weather.Index = Parse.Key;
                        weather.Name = Parse.Name;
                        Weathers.Add(Parse.Key, weather);
                    }
                }
                catch (Exception exc)
                {
                    Weathers = null;

                    throw;

                }
            }
        }
        public void MakePropList()
        {
            ItemsProps = new Dictionary<int, Item>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.PropsList)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        while (!parser.EndOfData)
                        {
                            //Processing row
                            rowCount++;

                            var item = new Item();
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            int index = 0;
                            if (rowCount == 1)
                                continue;
                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 1)
                                {
                                    int.TryParse(field, out index);
                                }

                                if (fCount == 2)
                                {
                                    item.Name = field;
                                }

                                if (fCount == 3)
                                {
                                    {
                                    var tfield = field.Replace(" ", "");
                                    item.ModelMain = tfield;
                                    }
                                }
                            }
                               //Debug.WriteLine(item.Name + " - ");
                            ItemsProps.Add(index, item);
                        }
                           //. Debug.WriteLine($"ExdCsvReader: {rowCount} items read");
                    }
                }
                catch (Exception exc)
                {
                    ItemsProps = null;

                    throw;

                }
            }
        }
        public void BGMList()
        {
            BGMs = new Dictionary<int, BGM>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.BGM)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            BGM bGM = new BGM();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            bGM.Index = int.Parse(fields[0]);
                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    bGM.Name = field;
                                }
                                if (fCount == 3)
                                {
                                    bGM.Location = field;
                                }
                                if (fCount == 4)
                                {
                                    bGM.Note = field;
                                }
                            }
                            BGMs.Add(bGM.Index, bGM);
                        }
                    }
                }

                catch (Exception exc)
                {
                    BGMs = null;

                    throw;

                }
            }
        }
        public static int[] convertToIntArray(byte[] input)
        {
            int[] NewArray = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                NewArray[i] = input[i] & 0xff;
            }
            return NewArray;
        }
    }
}
