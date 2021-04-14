using ConceptMatrix.Properties;
using ConceptMatrix.Sheets;
using ConceptMatrix.ViewModel;
using ConceptMatrix.Views;
using Lumina.Data.Files;
using Lumina.Data.Parsing;
using Lumina.Extensions;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using GearTuple = System.Tuple<int, int, int>;
using WepTuple = System.Tuple<int, int, int, int>;

namespace ConceptMatrix.Utility
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

		public int ModelType { get; set; }

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
			Shield,
			Trash,
		}

		public class CMItem
		{
			public int Index { get; set; }
			public string Name { get; set; }
			public string ModelMain { get; set; }
			public string ModelOff { get; set; }
			public ItemType Type { get; set; }
			public string ClassJobCategory { get; set; }
			public ImageSource Icon { get; set; }

			public override string ToString()
			{
				return Name;
			}
		}

		public class CMVoice
		{
			public byte Voice { get; set; }
			public string Name { get; set; }
			public string Group { get; set; }
		}

		public class CMStain
		{
			public uint Id { get; set; }
			public SolidColorBrush Color { get; set; }
			public string Name { get; set; }

			public override string ToString() => this.Name;
		}

		public class CMWeather
		{
			public ushort Id { get; set; }
			public string Name { get; set; }

			public ImageSource Icon { get; set; }

			public override string ToString() => this.Name;
		}

		public class CMStatus
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Description { get; set; }
			public ImageSource Icon { get; set; }
		}
		public class CMResident
		{
			public int Index { get; set; }
			public string Name { get; set; }
			public GearSet Gear { get; set; }
			public int Model { get; set; }

			public override string ToString()
			{
				return Name;
			}

			public bool IsGoodNpc()
			{
				if ((Gear.Customize[0] != 0|| Model != 0) && Name.Length != 0)
					return true;

				return false;
			}

			public string MakeGearString()
			{
				return $"{EquipmentFlyOut.GearTupleToComma(Gear.HeadGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.BodyGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.HandsGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.LegsGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.FeetGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.EarGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.NeckGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.WristGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.LRingGear)} - {EquipmentFlyOut.GearTupleToComma(Gear.RRingGear)}";
			}
		}
		public class CMCharaMakeCustomizeFeature
		{
			public int Index { get; set; }
			public int FeatureID { get; set; }
			public ImageSource Icon { get; set; }
		}
		public class CMFeature
		{
			public ImageSource Icon { get; set; }
		}
		public class CMCharaMakeCustomizeFeature2
		{
			public int Index { get; set; }
			public int Race { get; set; }
			public int Gender { get; set; }
			public int Tribe { get; set; }
			public List<CMFeature> Features { get; set; }
		}

		public class CMEmote
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

		public class CMTerritoryType
		{
			public string Name { get; set; }
			public int Index { get; set; }
			public CMWeatherRate WeatherRate { get; set; }
		}

		public class CMWeatherRate
		{
			public int Index { get; set; }
			public List<CMWeather> AllowedWeathers { get; set; }
		}
		public class CMMonster
		{
			public int Index { get; set; }
			public bool Real { get; set; }
			public string Name { get; set; }
			public override string ToString()
			{
				return Name;
			}
		}

		public List<CMItem> Items = null;
		public List<CMItem> ItemsProps = null;
		public List<CMTerritoryType> TerritoryTypes = null;
		public List<CMEmote> Emotes;
		public Dictionary<int, CMResident> Residents = null;
		public IEnumerable<CMCharaMakeCustomizeFeature> CharaMakeFeatures = null;
		public List<CMCharaMakeCustomizeFeature2> CharaMakeFeatures2 = null;
		public List<CMMonster> Monsters = null;
		public IEnumerable<CMStatus> Statuses = null;
		public IEnumerable<CMStain> Stains = null;

		public ImageSource Corrupted = App.GetImageStream((System.Drawing.Image)Resources.ResourceManager.GetObject("Corrupted"));

		private List<CMFeature> GetFeatures(int[] features) => (from f in features select new CMFeature { Icon = MainViewModel.gameData.GetIcon(f).GetImage() }).ToList();

		public void GetStains()
		{
			try
			{
				this.Stains = from s in MainViewModel.gameData.GetExcelSheet<Stain>()
							  let colorBytes = BitConverter.GetBytes(s.Color)
							  select new CMStain
							  {
								  Id = s.RowId,
								  Color = new SolidColorBrush(Color.FromRgb(colorBytes[2], colorBytes[1], colorBytes[0])),
								  Name = s.Name.RawString.DefaultIfEmpty("None")
							  };

			}
			catch
			{
				MessageBox.Show("Error occured while loading Stains!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void GetStatuses()
		{
			try
			{
				var statusSheet = MainViewModel.gameData.GetExcelSheet<Status>();
				this.Statuses = from s in statusSheet
								where s.VFX != 0 || s.RowId == 0
								select new CMStatus
								{
									Id = (int)s.RowId,
									Name = s.Name.RawString.DefaultIfEmpty("None"),
									Icon = MainViewModel.gameData.GetIcon(s.Icon)?.GetImage()
								};
			}
			catch (Exception)
			{
				MessageBox.Show("Error occured while loading Statuses!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		/// <summary>
		/// Create the face feature list.
		/// </summary>
		public void MakeCharaMakeFeatureFacialList()
		{
			try
			{
				this.CharaMakeFeatures2 = (from c in MainViewModel.gameData.GetExcelSheet<CharaMakeType>()
										  select new CMCharaMakeCustomizeFeature2
										  {
											  Index = (int)c.RowId,
											  Gender = c.Gender,
											  Race = c.Race,
											  Tribe = c.Tribe,
											  Features = GetFeatures(c.FacialFeatureOptions)
										  }).ToList();
			}
			catch (Exception)
			{
				MessageBox.Show("Error occured while loading Facial Features!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void MakeCharaMakeFeatureList()
		{
			try
			{
				this.CharaMakeFeatures = (from cmc in MainViewModel.gameData.GetExcelSheet<CharaMakeCustomize>()
										 select new CMCharaMakeCustomizeFeature
										 {
											 Index = (int)cmc.RowId,
											 FeatureID = cmc.FeatureID,
											 Icon = MainViewModel.gameData.GetIcon((int)cmc.Icon).GetImage()
										 }).ToList();
			}
			catch (Exception)
			{
				MessageBox.Show("Error occured while loading Character Customize!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
			}
			
		}

		public void EmoteList()
		{
			Emotes = new List<CMEmote>();
			{
				try
				{
					using (var parser = new TextFieldParser(new StringReader(Resources.actiontimeline)))
					{
						parser.TextFieldType = FieldType.Delimited;
						parser.SetDelimiters(",");
						int rowCount = 0;
						parser.ReadFields();
						while (!parser.EndOfData)
						{
							rowCount++;
							var emote = new CMEmote();
							//Processing row
							var fields = parser.ReadFields();
							var fCount = 0;
							emote.Index = int.Parse(fields[0]);
							foreach (var field in fields)
							{
								fCount++;

								if (fCount == 2)
									emote.Name = field;
							}
							if (emote.Name.Contains("normal/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.Realist = true; }
							if (emote.Name.Contains("mon_sp/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.SpeacialReal = true; }
							if (emote.Name.Contains("battle/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.BattleReal = true; }
							if (emote.Name.Contains("human_sp/")) { emote.Name = emote.Name.Remove(0, 9).ToString(); emote.SpeacialReal = true; }
							Emotes.Add(emote);
						}
					}
				}
				catch (Exception)
				{
					Emotes = null;
				}
			}
		}

		public void MonsterList()
		{
			Monsters = new List<CMMonster>();
			{
				try
				{
					using (var parser = new TextFieldParser(new StringReader(Resources.MonsterList)))
					{
						parser.TextFieldType = FieldType.Delimited;
						parser.SetDelimiters(",");
						int rowCount = 0;
						parser.ReadFields();
						while (!parser.EndOfData)
						{
							rowCount++;
							var monster = new CMMonster();
							//Processing row
							var fields = parser.ReadFields();
							var fCount = 0;
							monster.Index = int.Parse(fields[0]);
							foreach (var field in fields)
							{
								fCount++;

								if (fCount == 2)
									monster.Name = field;
							}
							if (monster.Name.Length >= 1)
								monster.Real = true;

							Monsters.Add(monster);
						}
					}
				}

				catch (Exception)
				{
					Monsters = null;
				}
			}
		}

		ItemType AsType(int cat)
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
				case 11:
					return ItemType.Shield;
				case int n when n >= 1 && n <= 10 || n >= 11 && n <= 32 || n == 84 || n >= 87 && n <= 89 || n >= 96 && n <= 99 || n >= 105 && n <= 107:
					return ItemType.Wep;
				default:
					return ItemType.Trash;
			}
		}
		
		public void MakeItemList()
		{
			try
			{
				var itemSheet = MainViewModel.gameData.GetExcelSheet<Item>();

				Items = new List<CMItem>();

				foreach (var i in itemSheet)
					if (i.EquipSlotCategory > 0)
						Items.Add(new CMItem
						{
							Index = (int)i.RowId,
							Name = i.Name,
							ClassJobCategory = i.ClassJobCategory.Value.Name,
							Type = AsType(i.ItemUICategory),
							Icon = MainViewModel.GetLuminaIconImage(i.Icon),
							ModelMain = i.ModelMain.AsQuad().AsModel(),
							ModelOff = i.ItemUICategory == 11 ? i.ModelMain.AsQuad().AsModel() : i.ModelSub.AsQuad().AsModel()
						});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void MakeResidentList()
		{
			Residents = new Dictionary<int, CMResident>();

			try
			{
				var npcResidentSheet = MainViewModel.gameData.GetExcelSheet<ENpcResident>();

				foreach (var npc in npcResidentSheet)
					Residents.Add((int)npc.RowId, new CMResident { Index = (int)npc.RowId, Name = npc.Singular });

				var npcBaseSheet = MainViewModel.gameData.GetExcelSheet<ENpcBase>();

				foreach (var npc in npcBaseSheet)
				{
					var gear = new GearSet();
					var customize = new List<byte>();

					customize.AddRange(new List<byte>()
					{
						Convert.ToByte(npc.Race),
						npc.Gender,
						npc.BodyType,
						npc.Height,
						Convert.ToByte(npc.Tribe),
						npc.Face,
						npc.HairStyle,
						npc.HairHighlight,
						npc.SkinColor,
						npc.EyeHeterochromia,
						npc.HairColor,
						npc.HairHighlightColor,
						npc.FacialFeature,
						npc.FacialFeatureColor,
						npc.Eyebrows,
						npc.EyeColor,
						npc.EyeShape,
						npc.Nose,
						npc.Jaw,
						npc.Mouth,
						npc.LipColor,
						npc.BustOrTone1,
						npc.ExtraFeature1,
						npc.ExtraFeature2OrBust,
						npc.FacePaint,
						npc.FacePaintColor
					});

					gear.ModelType = npc.ModelChara;
					gear.Customize = customize.ToArray();

					WepTuple GetWeaponTuple(ulong model, Stain dye) => new WepTuple((short)model, (short)(model >> 16), (short)(model >> 32), (int)dye.RowId);
					GearTuple GetGearTuple(uint model, Stain dye = null) => new GearTuple((short)model, (short)(model >> 16), dye == null ? 0 : (int)dye.RowId);

					if (npc.NpcEquip.Row > 0)
					{
						gear.MainWep = GetWeaponTuple(npc.NpcEquip.Value.ModelMainHand, npc.NpcEquip.Value.DyeMainHand.Value);
						gear.OffWep = GetWeaponTuple(npc.NpcEquip.Value.ModelOffHand, npc.NpcEquip.Value.DyeOffHand.Value);
						gear.HeadGear = GetGearTuple(npc.NpcEquip.Value.ModelHead, npc.NpcEquip.Value.DyeHead.Value);
						gear.BodyGear = GetGearTuple(npc.NpcEquip.Value.ModelBody, npc.NpcEquip.Value.DyeBody.Value);
						gear.HandsGear = GetGearTuple(npc.NpcEquip.Value.ModelHands, npc.NpcEquip.Value.DyeHands.Value);
						gear.LegsGear = GetGearTuple(npc.NpcEquip.Value.ModelLegs, npc.NpcEquip.Value.DyeLegs.Value);
						gear.FeetGear = GetGearTuple(npc.NpcEquip.Value.ModelFeet, npc.NpcEquip.Value.DyeFeet.Value);
						gear.EarGear = GetGearTuple(npc.NpcEquip.Value.ModelEars);
						gear.NeckGear = GetGearTuple(npc.NpcEquip.Value.ModelNeck);
						gear.WristGear = GetGearTuple(npc.NpcEquip.Value.ModelWrists);
						gear.RRingGear = GetGearTuple(npc.NpcEquip.Value.ModelRightRing);
						gear.LRingGear = GetGearTuple(npc.NpcEquip.Value.ModelLeftRing);
					}
					else
					{
						gear.MainWep = GetWeaponTuple(npc.ModelMainHand, npc.DyeMainHand.Value);
						gear.OffWep = GetWeaponTuple(npc.ModelOffHand, npc.DyeOffHand.Value);
						gear.HeadGear = GetGearTuple(npc.ModelHead, npc.DyeHead.Value);
						gear.BodyGear = GetGearTuple(npc.ModelBody, npc.DyeBody.Value);
						gear.HandsGear = GetGearTuple(npc.ModelHands, npc.DyeHands.Value);
						gear.LegsGear = GetGearTuple(npc.ModelLegs, npc.DyeLegs.Value);
						gear.FeetGear = GetGearTuple(npc.ModelFeet, npc.DyeFeet.Value);
						gear.EarGear = GetGearTuple(npc.ModelEars);
						gear.NeckGear = GetGearTuple(npc.ModelNeck);
						gear.WristGear = GetGearTuple(npc.ModelWrists);
						gear.RRingGear = GetGearTuple(npc.ModelRightRing);
						gear.LRingGear = GetGearTuple(npc.ModelLeftRing);
					}

					Residents[(int)npc.RowId].Gear = gear;
					Residents[(int)npc.RowId].Model = npc.ModelChara;
				}
			}
			catch (Exception)
			{
				Residents = null;
			}
		}

        public void MakeTerritoryTypeList()
        {
			try
            {
				var territorySheet = from t in MainViewModel.gameData.GetExcelSheet<TerritoryType>()
									 where t.PlaceName.Value.Name.RawString.Length > 0
									 select new CMTerritoryType
									 {
										 Index = (int)t.RowId,
										 Name = t.PlaceName.Value.Name
									 };

				TerritoryTypes = territorySheet.ToList();
			}
            catch (Exception ex)
            {
				MessageBox.Show("Error occured while loading TerritoryType!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
			}
        }

		public void MakePropList()
		{
			ItemsProps = new List<CMItem>();
			{
				try
				{
					using (var parser = new TextFieldParser(new StringReader(Resources.PropsList)))
					{
						parser.TextFieldType = FieldType.Delimited;
						parser.SetDelimiters(",");
						int rowCount = 0;
						while (!parser.EndOfData)
						{
							//Processing row
							rowCount++;

							var item = new CMItem();
							var fields = parser.ReadFields();
							var fCount = 0;
							var index = 0;
							if (rowCount == 1)
								continue;
							foreach (var field in fields)
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
							ItemsProps.Add(item);
						}
					}
				}
				catch (Exception)
				{
					ItemsProps = null;
				}
			}
		}
	}
}
