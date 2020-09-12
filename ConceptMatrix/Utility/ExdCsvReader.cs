using ConceptMatrix.Properties;
using ConceptMatrix.ViewModel;
using ConceptMatrix.Views;
using Lumina.Data.Files;
using Lumina.Data.Parsing;
using Lumina.Excel.GeneratedSheets;
using Lumina.Extensions;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
			public string ClassJobListStringName { get; set; }
			public TexFile Icon { get; set; }

			public override string ToString()
			{
				return Name;
			}
		}
		public class CMResident
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
		public class CMWeather
		{
			public int Index { get; set; }
			public string Name { get; set; }
            public ImageSource Icon { get; set; }
            public SaintCoinach.Imaging.ImageFile Icon2 { get; set; }
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
		public class CMBgm
		{
			public int Index { get; set; }
			public string Name { get; set; }
			public string Location { get; set; }
			public string Note { get; set; }
		}

		public List<CMItem> Items;
		public List<CMItem> ItemsProps;
		public List<CMTerritoryType> TerritoryTypes;
		public List<CMEmote> Emotes;
		public Dictionary<int, CMResident> Residents;
		public List<CMCharaMakeCustomizeFeature> CharaMakeFeatures;
		public List<CMCharaMakeCustomizeFeature2> CharaMakeFeatures2;
		public List<CMMonster> Monsters;
		public List<CMBgm> BGMs;

		private List<CMFeature> GetFeatures(int[] features)
		{
			// SpecialControl.GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Corrupted"))
			return (from f in features select new CMFeature { Icon = MainViewModel.lumina.GetIcon(f).GetImage() }).ToList();
		}

		/// <summary>
		/// Create the face feature list.
		/// </summary>
		public void MakeCharaMakeFeatureFacialList()
		{
			CharaMakeFeatures2 = new List<CMCharaMakeCustomizeFeature2>();
			try
			{
				var sheet = MainViewModel.lumina.GetExcelSheet<CharaMakeType>();
				foreach (var cmt in sheet)
				{
					var feature = new CMCharaMakeCustomizeFeature2
					{
						Index = (int)cmt.RowId,
						Gender = cmt.Gender,
						Race = (int)cmt.Race.Row,
						Tribe = (int)cmt.Tribe.Row,
						Features = GetFeatures(cmt.FacialFeatureOptions)
					};
					CharaMakeFeatures2.Add(feature);
				}
			}
			catch (Exception)
			{
			}
		}

		public void MakeCharaMakeFeatureList()
		{
			var corruptedImage = SpecialControl.GetImageStream((System.Drawing.Image)Resources.ResourceManager.GetObject("Corrupted"));

			CharaMakeFeatures = new List<CMCharaMakeCustomizeFeature>();
			try
			{
				var cmcSheet = MainViewModel.lumina.GetExcelSheet<CharaMakeCustomize>();
				foreach (var cmc in cmcSheet)
				{
					CharaMakeFeatures.Add(new CMCharaMakeCustomizeFeature
					{
						Index = (int)cmc.RowId,
						FeatureID = cmc.FeatureID,
						Icon = cmc.Icon == 0 ? corruptedImage : MainViewModel.lumina.GetIcon((int)cmc.Icon).GetImage()
					});
				}
			}
			catch (Exception)
			{
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
			var itemSheet = MainViewModel.lumina.GetExcelSheet<Item>();

			Items = new List<CMItem>();

			foreach (var i in itemSheet)
				if (i.EquipSlotCategory.Row > 0)
					Items.Add(new CMItem
					{
						Index = (int)i.RowId,
						Name = i.Name,
						ClassJobListStringName = i.ClassJobCategory.Value.Name,
						Type = AsType((int)i.ItemUICategory.Row),
						Icon = MainViewModel.lumina.GetIcon(i.Icon),
						ModelMain = i.ModelMain.AsQuad().ToString(),
						ModelOff = i.ItemUICategory.Row == 11 ? i.ModelMain.AsQuad().ToString() : i.ModelSub.AsQuad().ToString()
					});
		}

		public void MakeResidentList()
		{
			Residents = new Dictionary<int, CMResident>();

			try
			{
				var npcResidentSheet = MainViewModel.lumina.GetExcelSheet<ENpcResident>();

				foreach (var npc in npcResidentSheet)
					Residents.Add((int)npc.RowId, new CMResident { Index = (int)npc.RowId, Name = npc.Singular });

				var npcBaseSheet = MainViewModel.lumina.GetExcelSheet<ENpcBase>();

				foreach (var npc in npcBaseSheet)
				{
					var gear = new GearSet();
					var customize = new List<byte>();

					customize.AddRange(new List<byte>()
					{
						Convert.ToByte(npc.Race.Row),
						npc.Gender,
						npc.BodyType,
						npc.Height,
						Convert.ToByte(npc.Tribe.Row),
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

					gear.ModelType = (int)npc.ModelChara.Row;
					gear.Customize = customize.ToArray();

					WepTuple GetWeaponTuple(ulong model, Stain dye) => new WepTuple((ushort)model, (ushort)model >> 16, (ushort)model >> 32, (int)dye.RowId);
					GearTuple GetGearTuple(uint model, Stain dye = null) => new GearTuple((ushort)model, (ushort)model >> 16, dye == null ? 0 : (int)dye.RowId);

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
				var territorySheet = from t in MainViewModel.lumina.GetExcelSheet<TerritoryType>()
									 where t.PlaceName.Value.Name.Length > 0
									 select new CMTerritoryType
									 {
										 Index = (int)t.RowId,
										 Name = t.PlaceName.Value.Name
									 };

				TerritoryTypes = territorySheet.ToList();
			}
            catch (Exception)
            {
                TerritoryTypes = null;
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

		public void BGMList()
		{
			BGMs = new List<CMBgm>();
			{
				try
				{
					using (var parser = new TextFieldParser(new StringReader(Resources.BGM)))
					{
						parser.TextFieldType = FieldType.Delimited;
						parser.SetDelimiters(",");
						var rowCount = 0;
						parser.ReadFields();
						while (!parser.EndOfData)
						{
							rowCount++;
							var bgm = new CMBgm();
							//Processing row
							var fields = parser.ReadFields();
							var fCount = 0;
							bgm.Index = int.Parse(fields[0]);
							foreach (var field in fields)
							{
								fCount++;

								if (fCount == 2)
									bgm.Name = field;
								if (fCount == 3)
									bgm.Location = field;
								if (fCount == 4)
									bgm.Note = field;
							}
							BGMs.Add(bgm);
						}
					}
				}

				catch (Exception)
				{
					BGMs = null;
				}
			}
		}
	}
}
