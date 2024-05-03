using System;
using System.Xml.Linq;
using Engine;
using TemplatesDatabase;

namespace Game
{
	public class ShuiPing : SubsystemBlockBehavior
	{
		public ComponentPlayer m_componentPlayer;
		
		public override int[] HandledBlocks
		{
			get
			{
				return new int[]
				{
					414
				};
			}
		}

		public override bool OnUse(Ray3 ray, ComponentMiner componentMiner)
		{
			IInventory inventory = componentMiner.Inventory;
			int activeBlockValue = componentMiner.ActiveBlockValue;
			int num = Terrain.ExtractContents(activeBlockValue);
			if (num == 414)
			{
				object obj = componentMiner.Raycast(ray, RaycastMode.Gathering, true, true, true);
				bool flag2 = obj is TerrainRaycastResult;
				if (flag2)
				{
					CellFace cellFace = ((TerrainRaycastResult)obj).CellFace;
					int cellValue = base.SubsystemTerrain.Terrain.GetCellValue(cellFace.X, cellFace.Y, cellFace.Z);
					int num2 = Terrain.ExtractContents(cellValue);
					int num3 = Terrain.ExtractData(cellValue);
					Block block = BlocksManager.Blocks[num2];
					bool flag3 = block is WaterBlock;
					if (flag3)
					{
						int value = Terrain.ReplaceContents(activeBlockValue, 415);
						inventory.RemoveSlotItems(inventory.ActiveSlotIndex, inventory.GetSlotCount(inventory.ActiveSlotIndex));
						bool flag4 = inventory.GetSlotCount(inventory.ActiveSlotIndex) == 0;
						if (flag4)
						{
							inventory.AddSlotItems(inventory.ActiveSlotIndex, value, 1);
						}
					}
				}
			}
			return true;
		}

		public override void Load(ValuesDictionary valuesDictionary)
		{
			base.Load(valuesDictionary);
			this.m_subsystemGameInfo = base.Project.FindSubsystem<SubsystemGameInfo>(true);
			this.m_subsystemAudio = base.Project.FindSubsystem<SubsystemAudio>(true);
			this.m_subsystemParticles = base.Project.FindSubsystem<SubsystemParticles>(true);
		}

		public SubsystemAudio m_subsystemAudio;

		public SubsystemParticles m_subsystemParticles;

		public SubsystemGameInfo m_subsystemGameInfo;

		public Random m_random = new Random();

		public ComponentPlayer componentPlayer;
	}
}
